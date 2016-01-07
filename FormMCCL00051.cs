using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EI;
using EF;
using ZedGraph;
namespace MC
{
    public partial class FormMCCL00051 :Formbase
    {

        int cmd_Task_GetDepartInfo = 1025;//获取除parentid=0之外的所有部门信息;
        int cmd_Task_GetDispatchBodyInfos = 1026;//获取一个月范围内的已经分配以及未分配的
        int cmd_Task_GetTaskInfo = 1027;//按照给定的部门，时间查询得到任务列表
        int cmd_Task_GetWelders = 1028;//获取全部焊工信息；

        int cmd_Realtime_GetTaskinfo = 1040;//获取任务详细信息；
        int cmd_Realtime_WeldDricesRealInfo = 1030;//获取焊接的信息；
        int cmd_Realtime_GetCurWelderaskInfos = 1042;//获取当日焊工任务明细；


        int cmd_Hostory_GetRealinfos = 1033;//获取历史记录；
        int cmd_History_Eva = 1043;//历史数据的评估
        int cmd_RealTime_WeldtaskSum = 1041;//获取焊工任务汇总；
        _MyClient _Client = new _MyClient();
        DataTable _Depart;
        DataTable _Welder;
        DataTable _curWelderTasks;//当日的任务，定时器每1分钟更新一次
        DataTable _curWelderTaskinfos;//当日焊工的任务明细；
        int _taskState = 0;//任务查看状态0 正在进行，1 已完成，2 未开始；
        long _taskFID = 0;
        int _weldDriver = 0;
        int _weldChannel = 0;

        DataTable _HistoryTime;//历史数据；
        int _HistoryIndex;
        int tickStart = 0;
        private PointPairList list1 = new PointPairList();
        private PointPairList list2 = new PointPairList();
        private PointPairList listConA = new PointPairList();
        private PointPairList listConV = new PointPairList();
        double y = 0;
        LineItem curve1;
        LineItem curve2;
        LineItem curve_ConA;
        LineItem curve_ConV;
        double _BA = 0;
        double _BV = 0;
        private int timerDrawI = 0;
        private int _Type = 1; //0 实时监控 1 查询
        clsfrmData clsfrm = new clsfrmData();

        public FormMCCL00051()
        {
            InitializeComponent();
            
        }
        private void realtime1_Load(object sender, EventArgs e)
        {
            //初始化页面
            if (_Type == 0)
            {
                //this.button2.Visible = false;
                this.dateTimePicker1.Visible = false;
            }
            else
            {
                //this.button2.Visible = true;
                this.dateTimePicker1.Visible = true;
                //this.dateTimePicker1.Value = DateTime.Now;//DateTime.Now.ToString("yyyy-MM-dd");

            }
            //加载作业区
            //获取组织结构
            _Depart = _Client.ServiceCall(cmd_Task_GetDepartInfo, null);
            //获取焊工信息
            _Welder = _Client.ServiceCall(cmd_Task_GetWelders, null);
            DataView dv = _Depart.DefaultView;
            dv.RowFilter = "Flevel=1";
            DataTable workdt = dv.ToTable();
            this.cobDepart.DataSource = workdt;
            this.cobDepart.DisplayMember = "FDepartName";
            this.cobDepart.ValueMember = "FID";
            if (_Depart.Rows.Count > 0)
            {
                this.cobDepart.SelectedIndex = 0;
                cobDepart_SelectedIndexChanged(this.cobDepart, null);
            }


            this.Datetimetimer.Interval = 1000;
            this.Datetimetimer.Enabled = true;
            //初始化曲线
            this.dateTimePicker1.Value = DateTime.Now;
            Initialization_ZG();
        }

        private void cobDepart_SelectedIndexChanged(object sender, EventArgs e)
        {
            //作业区到班组
            ComboBox workcl = (ComboBox)sender;
            DataRowView workdrw = (DataRowView)workcl.SelectedItem;
            long workid = Convert.ToInt64(workdrw["FID"]);
            //查找工作区为workid的班组
            DataView classdw = _Depart.DefaultView;
            classdw.RowFilter = "FParentID=" + workid;
            DataTable classdt = classdw.ToTable(true, new String[] { "FDepartName", "FID" });

            //classcbo.SelectedIndexChanged += classcbo_SelectedIndexChanged;
            this.cobClass.DataSource = classdt;
            this.cobClass.DisplayMember = "FDepartName";
            this.cobClass.ValueMember = "FID";
        }

        private void cobClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            //班组绑定焊工
            ComboBox workcl = (ComboBox)sender;
            DataRowView workdrw = (DataRowView)workcl.SelectedItem;
            long classid = Convert.ToInt64(workdrw["FID"]);
            //获取焊工以及焊工的状态信息；
            //DataView tmpdv = _Welder.Copy().DefaultView;
            //String rowfilter = "Fdepart=" + classid;
            //tmpdv.RowFilter = rowfilter;
            //DataTable vdt = tmpdv.ToTable();
            DataTable fd = new DataTable();
            fd.Columns.Add("FSTARTTIME", typeof(String));
            fd.Columns.Add("FDEPART", typeof(long));

            DataRow row = fd.NewRow();
            //实时监控
            if (_Type == 0)
                row["FSTARTTIME"] = DateTime.Now.ToString("yyyy-MM-dd");
            else
            {

                row["FSTARTTIME"] = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            }
            row["FDEPART"] = classid;
            fd.Rows.Add(row);
            _curWelderTasks = _Client.ServiceCall(cmd_RealTime_WeldtaskSum, fd);

            this.dataGrid_Welder.DataSource = _curWelderTasks;
            this.dataGrid_Welder.Refresh();
        }

        private void dataGrid_Welder_CellContentDoubleClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            //双击得到下一项数据 查看已完成任务；正在进行任务；待完成任务
            //DataGridView dgv = (DataGridView)sender;
            DevExpress.XtraGrid.Views.Grid.GridView dgv = (DevExpress.XtraGrid.Views.Grid.GridView)this.dataGrid_Welder.Views[0]; //(DevExpress.XtraGrid.Views.Grid.GridView)sender;

            int RowHandle = dgv.FocusedRowHandle;

            if (RowHandle < 0)
                return;
            String celname = dgv.FocusedColumn.FieldName;//e.Column.Name;
            long fwelderid =Convert.ToInt64(dgv.GetRowCellValue(RowHandle,"FID"));// Convert.ToInt64(dgv.Rows[e.RowIndex].Cells["CFID"].Value);
            DataView vdv;//= _curWelderTasks.DefaultView;
            String rowfilter = "";
            DataTable vdt;
            DataTable fd = new DataTable();
            fd.Columns.Add("FSTARTTIME", typeof(String));
            fd.Columns.Add("FWELDERID", typeof(long));
            DataRow row = fd.NewRow();
            if (_Type == 0)
                row["FSTARTTIME"] = DateTime.Now.ToString("yyyy-MM-dd");
            else
                row["FSTARTTIME"] = this.dateTimePicker1.Value.ToString("yyyy-MM-dd");
            row["FWELDERID"] = fwelderid;
            fd.Rows.Add(row);



            //_curWelderTaskinfos = _Client.ServiceCall(cmd_Realtime_GetCurWelderaskInfos, fd);
            //rowfilter = "FActOpStartTime IS not null and FActOpEndTime IS  null and FWelderID={0} ";
            //vdv = _curWelderTaskinfos.Copy().DefaultView;

            //vdv.RowFilter = String.Format(rowfilter, fwelderid);
            //vdt = vdv.ToTable();
            //_taskState = 0;


            _curWelderTaskinfos = _Client.ServiceCall(cmd_Realtime_GetCurWelderaskInfos, fd);
            vdv = _curWelderTaskinfos.Copy().DefaultView;
            rowfilter = "FActOpStartTime IS not null and FActOpEndTime IS not null and FWelderID={0} ";
            vdv.RowFilter = String.Format(rowfilter, fwelderid);
            vdt = vdv.ToTable();
            _taskState = 2;



            //switch (celname)
            //{
            //    case "CDoing":
            //        {
            //            //查看正在进行的
            //            _curWelderTaskinfos = _Client.ServiceCall(cmd_Realtime_GetCurWelderaskInfos, fd);
            //            rowfilter = "FActOpStartTime IS not null and FActOpEndTime IS  null and FWelderID={0} ";
            //            vdv = _curWelderTaskinfos.Copy().DefaultView;

            //            vdv.RowFilter = String.Format(rowfilter, fwelderid);
            //            vdt = vdv.ToTable();
            //            _taskState = 0;
            //            break;
            //        }
            //    case "CUnDo":
            //        {
            //            //查看未开始的
            //            _curWelderTaskinfos = _Client.ServiceCall(cmd_Realtime_GetCurWelderaskInfos, fd);
            //            vdv = _curWelderTaskinfos.Copy().DefaultView;
            //            rowfilter = "FActOpStartTime IS  null and FActOpEndTime IS  null and FWelderID={0} ";
            //            vdv.RowFilter = String.Format(rowfilter, fwelderid);
            //            vdt = vdv.ToTable();
            //            _taskState = 1;
            //            break;
            //        }
            //    case "CDone":
            //        {
            //            _curWelderTaskinfos = _Client.ServiceCall(cmd_Realtime_GetCurWelderaskInfos, fd);
            //            vdv = _curWelderTaskinfos.Copy().DefaultView;
            //            rowfilter = "FActOpStartTime IS not null and FActOpEndTime IS not null and FWelderID={0} ";
            //            vdv.RowFilter = String.Format(rowfilter, fwelderid);
            //            vdt = vdv.ToTable();
            //            _taskState = 2;
            //            //查看完成的；
            //            break;
            //        }
            //    default:
            //        {
            //            return;

            //        }

            //}
            this.dataGrid_Task.DataSource = vdt;
            this.dataGrid_Task.Refresh();
            this.tabControl2.SelectedTab = this.tabTasks;

        }

        protected void Initialization_ZG()
        {
            GraphPane myPane = zedGraphControl1.GraphPane;
            curve1 = myPane.AddCurve("焊接电流", list1, Color.Blue, SymbolType.None);
            curve2 = myPane.AddCurve("焊接电压", list2, Color.Green, SymbolType.None);
            
            curve_ConA = myPane.AddCurve("标准电流", listConA, Color.Red, SymbolType.None);
            curve_ConV = myPane.AddCurve("标准电压", listConV, Color.Black, SymbolType.None);
            curve_ConV.IsY2Axis = true;
            curve2.IsY2Axis = true;
            //设置标题
            myPane.Title.Text = "历史曲线";
            //设置X轴说明文字
            myPane.XAxis.Title.Text = "时间";
            //设置Y轴说明文字
            myPane.YAxis.Title.Text = "焊接电流/焊接电压";
            
            myPane.Chart.Fill = new Fill(Color.White, Color.LightGray, 45.0f);
            //myPane.Chart.Fill = new Fill(Color.White, Color.LightGray, 45.0f);
            //设置1200个点,假设每50毫秒更新一次,刚好检测1分钟,一旦构造后将不能更改这个值
            //RollingPointPairList list1 = new RollingPointPairList(2400);
            //RollingPointPairList list2 = new RollingPointPairList(2400);
            //开始，增加的线是没有数据点的(也就是list为空)
            //增加一条名称:Voltage，颜色Color.Bule，无符号，无数据的空线条

            RealTimer.Interval = 1000;	//设置timer控件的间隔为50毫秒
            RealTimer.Enabled = false;	//timer可用
            //RealTimer.Start();			//开始
            myPane.Y2Axis.IsVisible = true;
            myPane.Y2Axis.Scale.Align = AlignP.Center;
            myPane.Y2Axis.MajorTic.IsOpposite = false;
            myPane.Y2Axis.MinorTic.IsOpposite = false;
            myPane.Y2Axis.Scale.Max = 60;
            myPane.Y2Axis.Scale.Min = 0;
            myPane.Y2Axis.MajorGrid.IsVisible = true;//设置X虚线 
            myPane.Y2Axis.MajorGrid.IsVisible = true;//设置Y虚线
            

            myPane.XAxis.Scale.Format = "dd HH:mm:ss";   //DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") 
            myPane.XAxis.Type = ZedGraph.AxisType.DateAsOrdinal;
            myPane.XAxis.Scale.Min = 0;		//X轴最小值0
            myPane.XAxis.Scale.Max = 5;	//X轴最大30
            myPane.YAxis.Scale.Max = 600;
            myPane.YAxis.Scale.Min = 0;

         
           
            //myPane.XAxis.Scale.MinorStep = 0.02;//X轴小步长1,也就是小间隔
            //myPane.XAxis.Scale.MajorStep = 0.1;//X轴大步长为5，也就是显示文字的大间隔
            myPane.XAxis.MajorGrid.IsVisible = true;//设置X虚线 
            myPane.YAxis.MajorGrid.IsVisible = true;//设置Y虚线
            //改变轴的刻度
            //zedGraphControl1.AxisChange();
            // Show the x axis grid
            //   myPane.XAxis.MajorGrid.IsVisible = true;
            //    myPane.YAxis.MajorTic.IsOpposite = true;
            //  myPane.YAxis.MinorTic.IsOpposite = true;
            // Don't display the Y zero line
            //保存开始时间
            tickStart = Environment.TickCount;

            zedGraphControl1.IsShowPointValues = true;
            //zedGraphControl1.PointValueEvent += new ZedGraphControl.PointValueHandler(MyPointValueHandler);
            // OPTIONAL: Add a custom context menu item
            //   zedGraphControl1.ContextMenuBuilder += new ZedGraphControl.ContextMenuBuilderEventHandler(MyContextMenuBuilder);

            // OPTIONAL: Handle the Zoom Event
            //zedGraphControl1.ZoomEvent += new ZedGraphControl.ZoomEventHandler(MyZoomEvent);
            //zedGraphControl1.AxisChange();
            // Make sure the Graph gets redrawn
            zedGraphControl1.Invalidate();
        }

        private void dataGrid_Task_CellContentDoubleClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            //双击查看 1 已经完成数据查看历史曲线和评估数据,2 查看正在进行的实时数据；

            double bA, bV;
            DevExpress.XtraGrid.Views.Grid.GridView dgv = (DevExpress.XtraGrid.Views.Grid.GridView)this.dataGrid_Task.Views[0];

            int RowHandle = dgv.FocusedRowHandle;


            _taskFID =Convert.ToInt64(dgv.GetRowCellValue(RowHandle,"FID"));// Convert.ToInt64(this.dataGrid_Task.Rows[e.RowIndex].Cells["CTaskFID"].Value);
            // _weldDriver = Convert.ToInt32(this.dataGrid_Task.Rows[e.RowIndex].Cells["CFweldDriverID"].Value);
            // _weldChannel = Convert.ToInt32(this.dataGrid_Task.Rows[e.RowIndex].Cells["FweldDriverTRUNID"].Value);
            DataView vdv = ((DataTable)this.dataGrid_Task.DataSource).Copy().DefaultView;
            vdv.RowFilter = "FID=" + _taskFID;
            DataTable vdt = vdv.ToTable();
            _weldChannel = Convert.ToInt32(vdt.Rows[0]["FweldDriverTRUNID"]);
            _weldDriver = Convert.ToInt32(vdt.Rows[0]["FweldDriverID"]);
            long wpsid = Convert.ToInt64(vdt.Rows[0]["FWELDWPSID"]);


            DataTable fdt = new DataTable();
            DataColumn col = new DataColumn();
            col.ColumnName = "FID";
            col.DataType = typeof(long);
            fdt.Columns.Add(col);
            col = new DataColumn();
            col.ColumnName = "nom";
            col.DataType = typeof(int);
            fdt.Columns.Add(col);
            col = new DataColumn();
            col.ColumnName = "channel";
            col.DataType = typeof(int);
            fdt.Columns.Add(col);

            RealTimer.Stop();
            RealTimer.Enabled = false;
            DataRow row = fdt.NewRow();
            row[0] = _taskFID;
            fdt.Rows.Add(row);
            row["channel"] = _weldChannel;
            //DataTable taskDT = _Client.ServiceCall(cmd_Realtime_GetTaskinfo, fdt);
            Formbase this_frm = (Formbase)this;
            clsfrm.FillfrmData2(vdt, ref this_frm, "");

            switch (_taskState)
            {
                case 0:
                    {//查看正在进行的任务
                        //获取任务信息；

                        //将任务信息填写到界面；

                        //开启定时器进行刷新
                        DataTable panansonicinfos = _Client.ServiceCall(cmd_Realtime_WeldDricesRealInfo, null);
                        DataView tmpdv = panansonicinfos.Copy().DefaultView;
                        tmpdv.RowFilter = "nom=" + _weldDriver + " and channel=" + _weldChannel;
                        DataTable tmpdt = tmpdv.ToTable();
                        clsfrm.FillfrmData2(tmpdt, ref this_frm, "");
                        if (wpsid != 0)
                        {
                            _BA = Convert.ToDouble(vdt.Rows[0]["WELD_I"]);
                            _BV = Convert.ToDouble(vdt.Rows[0]["WELD_V"]);

                        }
                        else
                        {
                            _BA = Convert.ToDouble(tmpdt.Rows[0]["va"]);
                            _BV = Convert.ToDouble(tmpdt.Rows[0]["vv"]);
                        }
                        //开启定时器进行实时数据显示
                        RealTimer.Enabled = true;
                        list1.Clear();
                        list2.Clear();
                        listConV.Clear();
                        listConA.Clear();
                        RealTimer.Start();

                        //获取当前焊机状态信息；
                        break;
                    }
                case 1://查看已经完成的任务
                    {

                        _HistoryTime = _Client.ServiceCall(cmd_Hostory_GetRealinfos, fdt);
                        _HistoryIndex = 0;
                        clsfrm.FillfrmData2(_HistoryTime, ref this_frm, "");

                        if (wpsid != 0)
                        {
                            _BA = Convert.ToDouble(vdt.Rows[0]["WELD_I"]);
                            _BV = Convert.ToDouble(vdt.Rows[0]["WELD_V"]);

                        }
                        else
                        {
                            _BA = Convert.ToDouble(_HistoryTime.Rows[0]["va"]);
                            _BV = Convert.ToDouble(_HistoryTime.Rows[0]["vv"]);
                        }


                        //开启定时器进行实时数据显示
                        RealTimer.Enabled = true;
                        list1.Clear();
                        list2.Clear();
                        listConV.Clear();
                        listConA.Clear();
                        RealTimer.Start();
                        break;
                    }
                case 2://还未完成的任务
                    {
                        _HistoryTime = _Client.ServiceCall(cmd_Hostory_GetRealinfos, fdt);
                        _HistoryIndex = 0;
                        clsfrm.FillfrmData2(_HistoryTime, ref this_frm, "");
                        if (wpsid != 0)
                        {
                            _BA = Convert.ToDouble(vdt.Rows[0]["WELD_I"]);
                            _BV = Convert.ToDouble(vdt.Rows[0]["WELD_V"]);

                        }
                        else
                        {
                            _BA = Convert.ToDouble(_HistoryTime.Rows[0]["va"]);
                            _BV = Convert.ToDouble(_HistoryTime.Rows[0]["vv"]);
                        }
                        //计算得到评分结果值

                        //参数为Task FID ,channel
                        if (wpsid != 0)
                        {
                            DataTable vev = _Client.ServiceCall(cmd_History_Eva, fdt);
                            clsfrm.FillfrmData2(vev, ref this_frm, "");
                        }

                        //开启定时器进行实时数据显示
                        list1.Clear();
                        list2.Clear();
                        listConV.Clear();
                        listConA.Clear();

                        RealTimer.Enabled = true;
                        RealTimer.Start();
                        break;
                    }
                default:
                    {
                        return;
                    }
            }

        }
        /// <summary>
        /// 实时监控开启
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RealTimer_Tick(object sender, EventArgs e)
        {

            //确保CurveList不为空
            if (zedGraphControl1.GraphPane.CurveList.Count <= 0)
            {
                return;
            }

            //取Graph第一个曲线，也就是第一步:在GraphPane.CurveList集合中查找CurveItem
            LineItem curve = zedGraphControl1.GraphPane.CurveList[0] as LineItem;
            if (curve == null)
            {
                return;
            }

            //第二步:在CurveItem中访问PointPairList(或者其它的IPointList)，根据自己的需要增加新数据或修改已存在的数据
            IPointListEdit list = curve.Points as IPointListEdit;
            // If this is null, it means the reference at curve.Points does not
            // support IPointListEdit, so we won't be able to modify it
            if (list == null)
            {
                return;
            }

            //---进行取值操作
            //double x = (double)new XDate(DateTime.Now.AddSeconds(100.00));
            double x = 0;
            double wa = 0;
            double wv = 0;
            if (_taskState == 0)//实时数据
            {
                DataTable panansonicinfos = _Client.ServiceCall(cmd_Realtime_WeldDricesRealInfo, null);

                DataView vdv = panansonicinfos.DefaultView;
                String rowfilter = "nom=" + "1329";//this.FweldDriverID.Text;
                vdv.RowFilter = rowfilter;
                DataTable vdt = vdv.ToTable();
                Formbase vfrm = (Formbase)this;
                clsfrm.FillfrmData(vdt, ref vfrm);

                x = (double)new XDate(Convert.ToDateTime(vdt.Rows[0]["NowTime"]));//焊机返回时间
                wa = Convert.ToDouble(vdt.Rows[0]["wa"]);
                wv = Convert.ToDouble(vdt.Rows[0]["wv"]);
            }
            if (_taskState == 2)//历史数据
            {
                Formbase this_frm = (Formbase)this;
                if (_HistoryTime == null)
                    return;
                if (_HistoryTime.Rows.Count == 0)
                    return;
                if (_HistoryIndex < _HistoryTime.Rows.Count)
                {
                    DataRow rw = _HistoryTime.Rows[_HistoryIndex];

                    clsfrm.FillfrmData(rw, ref this_frm);
                    x = (double)new XDate(Convert.ToDateTime(_HistoryTime.Rows[_HistoryIndex]["NowTime"]));//焊机返回时间
                    wa = Convert.ToDouble(_HistoryTime.Rows[_HistoryIndex]["wa"]);
                    wv = Convert.ToDouble(_HistoryTime.Rows[_HistoryIndex]["wv"]);
                    _HistoryIndex++;
                }
                else
                {
                    RealTimer.Enabled = false;
                }
            }
            // 3 seconds per cycle
            list1.Add(x, wa);//电流曲线
            list2.Add(x, wv);//电压曲线
            listConA.Add(x, _BA);
            listConV.Add(x, _BV);

            Scale xScale = zedGraphControl1.GraphPane.XAxis.Scale;
            zedGraphControl1.AxisChange();

            zedGraphControl1.Invalidate();

            if (list.Count >= 200)
            {
                list1.RemoveAt(0);
                list2.RemoveAt(0);
                listConV.RemoveAt(0);
                listConA.RemoveAt(0);
            }
            //y = (double)Math.Sin(timerDrawI / 10f);

        }
        private void Datetimetimer_Tick(object sender, EventArgs e)
        {
            this.Label4.Text = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (cobClass.SelectedIndex >= 0)
                cobClass_SelectedIndexChanged(cobClass, null);

        }
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void zedGraphControl1_DoubleClick(object sender, EventArgs e)
        {
            if (RealTimer.Enabled == true)
                RealTimer.Enabled = false;
        }


        private void gridView2_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            dataGrid_Welder_CellContentDoubleClick(sender, e);
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            dataGrid_Task_CellContentDoubleClick(sender,e);
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void dataGrid_Welder_DoubleClick(object sender, EventArgs e)
        {
            dataGrid_Welder_CellContentDoubleClick(sender, null);
        }

        private void gridView2_Click(object sender, EventArgs e)
        {
           // MessageBox.Show("OK");
        }

        private void dataGrid_Task_DoubleClick(object sender, EventArgs e)
        {
            dataGrid_Task_CellContentDoubleClick(sender,null);
        }

        private void FormMCCL00051_EF_DO_F1(object sender, EF_Args e)
        {
            this.button1_Click(null, null);
        }
       
    }
}
