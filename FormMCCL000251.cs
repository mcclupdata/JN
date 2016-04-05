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
    public partial class FormMCCL000251 : Formbase
    {
        clswpsEdit _cls;
        _MyClient _Client = new _MyClient();
        clsFrmBase _clsfrm = new clsFrmBase();
        int _frmType = 0;
        int _taskState = 0;
        int tickStart = 0;
        private PointPairList list1 = new PointPairList();
        private PointPairList list2 = new PointPairList();
        private PointPairList listConA = new PointPairList();
        private PointPairList listConV = new PointPairList();
        private PointPairList listConMxA = new PointPairList();
        private PointPairList listConMxV = new PointPairList();
        private PointPairList listConMiA = new PointPairList();
        private PointPairList listConMiV = new PointPairList();

        double y = 0;
        LineItem curve1;
        LineItem curve2;
        LineItem curve_ConA;
        LineItem curve_ConV;

        LineItem ConMxA;
        LineItem ConMiA;
        LineItem ConMxV;
        LineItem ConMinV;


        double _BA = 0;
        double _BV = 0;
        private int timerDrawI = 0;
        private weldEquipmentbase _weldEquipmentbase = new weldEquipmentbase();
        public FormMCCL000251()
        {
            InitializeComponent();
            _frmType = 0;
            
        }

        private void efGroupBox1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormMCCL0004_Load(object sender, EventArgs e)
        {
            Formbase frm = this;
            //_cls = new clswpsEdit(ref frm);
            //_cls.Load();
            //this.EF_DO_F1 += new EFButtonBar.EFDoFnEventHandler(FormMCCL0004_EF_DO_F1);
            //this.EF_DO_F2 += new EFButtonBar.EFDoFnEventHandler(FormMCCL0004_EF_DO_F2);
            //初始化曲线
            iniZEDGrap();
            //初始化函及设备
            iniEquipmentTree();

        }
        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void FormMCCL0004_EF_DO_F2(object sender, EF_Args e)
        {
            //throw new NotImplementedException();
            _cls.clswpsEdit_Cancel_Click(null, null);
        }
        
        //删除；
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void FormMCCL0004_EF_DO_F1(object sender, EF_Args e)
        {
            //throw new NotImplementedException();
            _cls.clswpsEdit_Delete_Click(null, null);
        }

        private void efPanelStyleXP2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void efTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 初始化曲线
        /// </summary>
        protected void iniZEDGrap()
        {
            GraphPane myPane = zedGraphControl1.GraphPane;
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.GraphPane.GraphObjList.Clear();
            zedGraphControl1.AxisChange();
            zedGraphControl1.Refresh();
            list1.Clear();
            list2.Clear();
            listConA.Clear();
            listConV.Clear();
            listConV.Clear();

            listConMiA.Clear();
            listConMiV.Clear();
            listConMxV.Clear();
            listConMxA.Clear();

            zedGraphControl1.IsEnableHEdit = false;
            zedGraphControl1.IsEnableHZoom = false;
            zedGraphControl1.IsEnableZoom = false;
            //改变图例的位置
            myPane.Legend.Position = ZedGraph.LegendPos.Bottom;
            curve1 = myPane.AddCurve("焊接电流", list1, Color.Blue, SymbolType.None);
            curve2 = myPane.AddCurve("焊接电压", list2, Color.Green, SymbolType.None);
            curve2.IsY2Axis = true;
            curve_ConA = myPane.AddCurve("标准电流", listConA, Color.Red, SymbolType.None);
            curve_ConV = myPane.AddCurve("标准电压", listConV, Color.Black, SymbolType.None);
            curve_ConV.IsY2Axis = true;

            ConMxA = myPane.AddCurve("标准电流上限", listConMxA, Color.DeepPink, SymbolType.None);
            ConMiA = myPane.AddCurve("标准电流下限", listConMiA, Color.DeepPink, SymbolType.None);

            ConMxV = myPane.AddCurve("标准电压上限", listConMxV, Color.DarkBlue, SymbolType.None);
            ConMinV = myPane.AddCurve("标准电压下限", listConMiV, Color.DarkBlue, SymbolType.None);
            ConMxV.IsY2Axis = true;
            ConMinV.IsY2Axis = true;


            //曲线加粗
            curve1.Line.Width = 4.0F;
            curve2.Line.Width = 4.0F;
            curve_ConA.Line.Width = 4.0F;
            curve_ConV.Line.Width = 4.0F;

            ConMiA.Line.Style = System.Drawing.Drawing2D.DashStyle.Dot;
            ConMiA.Line.Width = 1.0F;


            ConMxA.Line.Style = System.Drawing.Drawing2D.DashStyle.Dot;
            ConMxA.Line.Width = 1.0F;

            ConMxV.Line.Style = System.Drawing.Drawing2D.DashStyle.Dot;
            ConMxV.Line.Width = 1.0F;

            ConMinV.Line.Style = System.Drawing.Drawing2D.DashStyle.Dot;
            ConMinV.Line.Width = 1.0F;


            int curcount = zedGraphControl1.GraphPane.CurveList.Count;
            curcount = myPane.CurveList.Count;
            //设置标题
            myPane.Title.Text = "实时曲线";
            //设置X轴说明文字
            myPane.XAxis.Title.Text = "时间";
            //设置Y轴说明文字
            myPane.YAxis.Title.Text = "焊接电流/焊接电压";
            myPane.Chart.Fill = new Fill(Color.White, Color.FromArgb(255, 255, 128), -45F);
            //myPane.Chart.Fill = new Fill(Color.White, Color.LightGray, 45.0f);
            //设置1200个点,假设每50毫秒更新一次,刚好检测1分钟,一旦构造后将不能更改这个值
            //RollingPointPairList list1 = new RollingPointPairList(2400);
            //RollingPointPairList list2 = new RollingPointPairList(2400);
            //开始，增加的线是没有数据点的(也就是list为空)
            //增加一条名称:Voltage，颜色Color.Bule，无符号，无数据的空线条

            Timer_ZED.Interval = 1000;	//设置timer控件的间隔为50毫秒
            Timer_ZED.Enabled = false;	//timer可用
            //RealTimer.Start();			//开始
            myPane.Y2Axis.IsVisible = true;
            myPane.Y2Axis.Scale.Align = AlignP.Inside;
            myPane.Y2Axis.MajorTic.IsOpposite = false;
            myPane.Y2Axis.MinorTic.IsOpposite = false;
            myPane.XAxis.Scale.Format = "dd HH:mm:ss";   //DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") 
            myPane.XAxis.Type = ZedGraph.AxisType.DateAsOrdinal;
            myPane.XAxis.Scale.Min = 0;		//X轴最小值0
            myPane.XAxis.Scale.Max = 5;	//X轴最大30


            myPane.YAxis.Scale.Max = 600;
            myPane.YAxis.Scale.Min = 0;

            myPane.Y2Axis.Scale.Max = 60;
            myPane.Y2Axis.Scale.Min = 0;
           

           

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
            //清除原图

           // zedGraphControl1.GraphPane.CurveList.Clear();
            //zedGraphControl1.GraphPane.YAxisList.Clear();
            //zedGraphControl1.GraphPane.Y2AxisList.Clear();
           // zedGraphControl1.GraphPane.GraphObjList.Clear();
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
        /// <summary>
        /// 绘制历史数据
        /// </summary>
        /// <param name="historyrec">历史数据集合</param>
        protected void GraphHistory(DataTable historyrec)
        {
            zedGraphControl1.GraphPane.CurveList.Clear();
            iniZEDGrap();
            Formbase this_frm = (Formbase)this;
            _clsfrm.FillfrmData2(historyrec, ref this_frm, "");

            if (historyrec.Rows.Count > 0)
            {
                _BA = Convert.ToDouble(historyrec.Rows[0]["va"]);
                _BV = Convert.ToDouble(historyrec.Rows[0]["vv"]);
                DataRow rw = historyrec.Rows[0];
                _clsfrm.FillfrmData(rw, ref this_frm);


                for (int i = 0; 0 < historyrec.Rows.Count; i++)
                {
                   rw = historyrec.Rows[i];
                   double x = (double)new XDate(Convert.ToDateTime(historyrec.Rows[i]["nowtime"]));//焊机返回时间
                   double wa = Convert.ToDouble(historyrec.Rows[i]["wa"]);
                   double wv = Convert.ToDouble(historyrec.Rows[i]["wv"]);
                   list1.Add(x, wa);//电流曲线
                   list2.Add(x, wv);//电压曲线
                   listConA.Add(x, _BA);
                   listConV.Add(x, _BV);

                   listConMxA.Add(x, Convert.IsDBNull(historyrec.Rows[i]["va_up"]) ? 0 : Convert.ToDouble(historyrec.Rows[i]["va_up"]));
                   listConMiA.Add(x, Convert.IsDBNull(historyrec.Rows[i]["va_down"]) ? 0 : Convert.ToDouble(historyrec.Rows[i]["va_down"]));
                   listConMxV.Add(x, Convert.IsDBNull(historyrec.Rows[i]["vv_up"]) ? 0 : Convert.ToDouble(historyrec.Rows[i]["vv_up"]));
                   listConMiV.Add(x, Convert.IsDBNull(historyrec.Rows[i]["vv_down"]) ? 0 : Convert.ToDouble(historyrec.Rows[i]["vv_down"]));
 
                   
                }
            }
            


            

            Scale xScale = zedGraphControl1.GraphPane.XAxis.Scale;
            zedGraphControl1.AxisChange();

            zedGraphControl1.Invalidate();

                
        }
        /// <summary>
        /// 初始化焊机设备tree
        /// 
        /// </summary>
        protected void iniEquipmentTree()
        {
            _weldEquipmentbase.LoadweldEquipment2Tree(ref this.weldEquipList);


            DataTable dt = _Client.ServiceCall(clsCMD.cmd_weldEquipment_Real_PaicTask, null);
            this.dataGrid.DataSource = dt;
            this.Timer_WeldDevs.Start();
        }
        /// <summary>
        /// 指定焊机电流电压曲线显示；
        /// </summary>
        protected void Timer_WeldEquipmentReal()
        {
            
            //获取查看的焊机节点
            TreeNode selNode = this.weldEquipList.SelectedNode;
            if (selNode == null)
            {
                //停止定时器
                Timer_ZED.Stop();
                return;
            }
            if (selNode.Name == selNode.Text)
            {
                //选择的是位置
                Timer_ZED.Stop();
                return;
            }
            //构建查询
            DataTable dtweldFiler = new DataTable();
            DataColumn col = new DataColumn();
            col.ColumnName = "nom";
            col.DataType = typeof(String);
            col.MaxLength = 20;
            dtweldFiler.Columns.Add(col);
            DataRow row = dtweldFiler.NewRow();
            row[0] = selNode.Name;
            dtweldFiler.Rows.Add(row);
            //DataTable dtweldState = _Client.ServiceCall(clsCMD.cmd_weldEquipment_getBase_Bynom, dtweldFiler);


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
                DataTable panansonicinfos = _Client.ServiceCall(clsCMD.cmd_weldEquipment_getBase_Bynom, dtweldFiler);

                if (panansonicinfos.Rows.Count == 0)
                    return;
                Formbase vfrm = (Formbase)this;
                _clsfrm.FillfrmData(panansonicinfos, ref vfrm);
               
                x = (double)new XDate(Convert.ToDateTime(panansonicinfos.Rows[0]["nowtime"]));//焊机返回时间
                wa = Convert.ToDouble(panansonicinfos.Rows[0]["wa"]);
                wv = Convert.ToDouble(panansonicinfos.Rows[0]["wv"]);
                _BA = Convert.ToDouble(panansonicinfos.Rows[0]["va"]);
                _BV = Convert.ToDouble(panansonicinfos.Rows[0]["vv"]);
                listConMxA.Add(x, Convert.IsDBNull(panansonicinfos.Rows[0]["va_up"]) ? 0 : Convert.ToDouble(panansonicinfos.Rows[0]["va_up"]));
                listConMiA.Add(x, Convert.IsDBNull(panansonicinfos.Rows[0]["va_down"]) ? 0 : Convert.ToDouble(panansonicinfos.Rows[0]["va_down"]));
                listConMxV.Add(x, Convert.IsDBNull(panansonicinfos.Rows[0]["vv_up"]) ? 0 : Convert.ToDouble(panansonicinfos.Rows[0]["vv_up"]));
                listConMiV.Add(x, Convert.IsDBNull(panansonicinfos.Rows[0]["vv_down"]) ? 0 : Convert.ToDouble(panansonicinfos.Rows[0]["vv_down"]));
            }
            if (_taskState == 2)//历史数据
            {

                
                //Formbase this_frm = (Formbase)this;
                //if (_HistoryTime == null)
                //    return;
                //if (_HistoryTime.Rows.Count == 0)
                //    return;
                //if (_HistoryIndex < _HistoryTime.Rows.Count)
                //{
                //    DataRow rw = _HistoryTime.Rows[_HistoryIndex];

                //    clsfrm.FillfrmData(rw, ref this_frm);
                //    x = (double)new XDate(Convert.ToDateTime(_HistoryTime.Rows[_HistoryIndex]["NowTime"]));//焊机返回时间
                //    wa = Convert.ToDouble(_HistoryTime.Rows[_HistoryIndex]["wa"]);
                //    wv = Convert.ToDouble(_HistoryTime.Rows[_HistoryIndex]["wv"]);
                //    _HistoryIndex++;
                //}
                //else
                //{
                //    RealTimer.Enabled = false;
                //}
            }
            // 3 seconds per cycle
            list1.Add(x, wa);//电流曲线
            list2.Add(x, wv);//电压曲线
            listConA.Add(x, _BA);
            listConV.Add(x, _BV);

            Scale xScale = zedGraphControl1.GraphPane.XAxis.Scale;
            zedGraphControl1.AxisChange();

            zedGraphControl1.Invalidate();

            if (list.Count >= 50)
            {
                list1.RemoveAt(0);
                list2.RemoveAt(0);
                listConV.RemoveAt(0);
                listConA.RemoveAt(0);
                listConMxA.RemoveAt(0);
                listConMiA.RemoveAt(0);
                listConMxV.RemoveAt(0);
                listConMiV.RemoveAt(0);
            }
            //y = (double)Math.Sin(timerDrawI / 10f);
        }


        /// <summary>
        /// 更新所有焊机基本状态,
        /// </summary>
        protected void UpdateEquipments()
        {
            DataTable dt_EquipState;
            //准备条件参数
            DataTable dt_EquipFilter = new DataTable();
            DataColumn col = new DataColumn();
            col.ColumnName = "nom";
            col.DataType = typeof(String);
            col.MaxLength = 50;
            dt_EquipFilter.Columns.Add(col);
            //请求服务器获取所有焊机的状态信息
            dt_EquipState = _Client.ServiceCall(clsCMD.cmd_weldEquipment_getBase_Bynom, dt_EquipFilter);
            TreeNode selNode = weldEquipList.SelectedNode;
            for (int i = 0; i < dt_EquipState.Rows.Count; i++)
            {
                String sname = dt_EquipState.Rows[i]["nom"].ToString();
                String sstate = dt_EquipState.Rows[i]["state"].ToString();
                if (weldEquipList.Nodes.IndexOfKey(sname) > 0)
                {
                    TreeNode enode = weldEquipList.Nodes[sname];
                    if (sstate == "关闭")
                    {
                        enode.ImageIndex = 1;
                    }
                    else
                    {
                        enode.ImageIndex = 0;
                    }
                }
                //if (sname == selNode.Name)
                //{
                //    //更新细节
                //    this.vv.Text = dt_EquipState.Rows[i]["vv"].ToString();
                //    this.va.Text = dt_EquipState.Rows[i]["va"].ToString();
                //    this.wa.Text = dt_EquipState.Rows[i]["wa"].ToString();
                //    this.wv.Text = dt_EquipState.Rows[i]["wv"].ToString();
                //    this.wp.Text = dt_EquipState.Rows[i]["wp"].ToString();
                //    this.rpm.Text = dt_EquipState.Rows[i]["rpm"].ToString();
                //    this.state.Text = dt_EquipState.Rows[i]["state"].ToString();
                //    this.mt.Text = dt_EquipState.Rows[i]["mt"].ToString();
                //}
            }

        }
        /// <summary>
        /// 加载一个焊机对应的10个任务批次
        /// </summary>
        protected void loadweldEquipmentTask()
        {

            TreeNode selNode = weldEquipList.SelectedNode;
            if (selNode == null)
                return;
            if (selNode.Name == selNode.Text)
                return;

            DataTable dtf = new DataTable();
            DataColumn col = new DataColumn();
            col.ColumnName = "nom";
            col.DataType = typeof(String);
            col.MaxLength = 20;
            dtf.Columns.Add(col);
            DataRow row = dtf.NewRow();
            row[0] = selNode.Name;
            dtf.Rows.Add(row);
            //请求服务器查询
            DataTable dt = _Client.ServiceCall(clsCMD.cmd_weldEquipment_getTask_Bynom, dtf);
            //绑定到Grid
            dataGrid.DataSource = dt;
            dataGrid.Refresh();

        }
        /// <summary>
        /// 焊机实时电流电压数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_ZED_Tick(object sender, EventArgs e)
        {
            Timer_ZED.Stop();
            Timer_WeldEquipmentReal();
            Timer_ZED.Start();
        }
        /// <summary>
        /// 焊机基本状态 1分钟更新一次
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Equip_Tick(object sender, EventArgs e)
        {
            UpdateEquipments();
        }
        /// <summary>
        /// 双击焊机，查看实时电流电压等信息；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void weldEquipList_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode selNode = weldEquipList.SelectedNode;
            if (selNode == null)
                return;
            if (selNode.Name == selNode.Text)
                return;
            
            
            iniZEDGrap();
            Timer_ZED.Start();
            if (_frmType == 1)
            {
                loadweldEquipmentTask();
                Timer_Task.Start();
            }
            //***************modify by junlin 2015-11-14******************
            //获取预制电流电压
            
            //************************************************************
            
        }
        /// <summary>
        /// 更新某焊机的任务信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Task_Tick(object sender, EventArgs e)
        {
            Timer_Task.Stop();
            loadweldEquipmentTask();
            Timer_Task.Start();
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            //if (_frmType == 1)
            //{
            //    int curRowindex = this.gridView1.FocusedRowHandle;
            //    DataTable sdt = (DataTable)this.dataGrid.DataSource;
            //    DataRow row = sdt.Rows[curRowindex];
            //    DataView dv = sdt.Copy().DefaultView;
            //    dv.RowFilter = "FweldDriverID=0";

            //    DataTable fdt = dv.ToTable();
            //    fdt.ImportRow(row);

            //    //开始填写数据
            //    DataTable history = _Client.ServiceCall(clsCMD.cmd_weldEquipment_real_History, fdt);
            //    GraphHistory(history);


            //}



            //MessageBox.Show("OK");
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            int rowindex = gridView1.FocusedRowHandle;
            if (rowindex < 0)
                return;

            String nom = gridView1.GetRowCellValue(rowindex, "nom").ToString();
            try
            {
                TreeNode[] snodes = weldEquipList.Nodes.Find(nom, true);
                if (snodes.Length > 0)
                {
                    weldEquipList.SelectedNode = snodes[0];
                    weldEquipList_NodeMouseClick(null, null);
                    //modify by junlin 2015-11-14
                    //gridView1_Click(null, null);
                }
            }
            catch { }
            

        }

        private void weldEquipList_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //if (weldEquipList.SelectedNode == null)
            //    return;
            //if (weldEquipList.SelectedNode.Name == weldEquipList.SelectedNode.Text)
            //    return;
            //if (e.Node == null)
            //    return;

            //String nom = e.Node.Name;// weldEquipList.SelectedNode.Name;
            //for (int i = 0; i < gridView1.RowCount; i++)
            //{
            //    if (nom == gridView1.GetRowCellValue(i, "nom").ToString())
            //    {
            //        gridView1.SelectRow(i);
            //        gridView1.FocusedRowHandle = i;
            //        i=gridView1.RowCount;
            //    }
            //}
            //Graph
            //zedGraphControl1.GraphPane.CurveList.Clear();
            //iniZEDGrap();
            //Timer_ZED.Start();
            //loadweldEquipmentTask();
            //Timer_Task.Start();

            TreeNode selNode = weldEquipList.SelectedNode;
            if (selNode == null)
                return;
            if (selNode.Name == selNode.Text)
                return;


            iniZEDGrap();
            Timer_ZED.Start();
            if (_frmType == 1)
            {
                loadweldEquipmentTask();
                Timer_Task.Start();
            }

        }

        private void Timer_WeldDevs_Tick(object sender, EventArgs e)
        {
            //刷新设备状态；
            Timer_WeldDevs.Stop();
            DataTable dt = _Client.ServiceCall(clsCMD.cmd_weldEquipment_Real_PaicTask, null);

            DataTable welddt = _Client.ServiceCall(1030, null);


            
            
               
                   
                        for (int j = 0; j < welddt.Rows.Count; j++)
                        {
                            for (int k = 0; k < weldEquipList.Nodes.Count; k++)
                            {
                                TreeNode pnode = _clsfrm.FindTreeNodeByKey(welddt.Rows[j]["nom"].ToString(), weldEquipList.Nodes[k]);//vtree.Nodes[dt_point.Rows[j]["FDepartName"].ToString()];
                                if (pnode != null)
                                {
                                    if (welddt.Rows[j]["state"].ToString() == "关闭")
                                    {
                                        pnode.ForeColor = Color.Gray;
                                    }
                                    if (welddt.Rows[j]["state"].ToString() == "焊接")
                                    {
                                        pnode.ForeColor = Color.Blue;
                                    }
                                    if (welddt.Rows[j]["state"].ToString() == "报警")
                                    {
                                        pnode.ForeColor = Color.Red;
                                    }
                                    if (welddt.Rows[j]["state"].ToString() == "待机")
                                    {
                                        pnode.ForeColor = Color.Green;
                                    }
                                    k = weldEquipList.Nodes.Count;
                                }
                                else
                                {

                                }
                            }
                        }
            

            //this.dataGrid.DataSource = dt;
           // int curIndex = this.gridView1;
            for(int r=0;r<this.gridView1.RowCount;r++)
            {
                String snom=this.gridView1.GetRowCellValue(r,"nom").ToString();
                dt.DefaultView.RowFilter="nom='"+snom+"'";
                DataTable vdt = dt.DefaultView.ToTable();
                if (vdt.Rows.Count == 1)
                {
                    for (int i = 0; i < gridView1.Columns.Count; i++)
                    {
                        String fname = gridView1.Columns[i].FieldName;
                        if (vdt.Columns.IndexOf(fname) > 0)
                        {
                            try
                            {
                                this.gridView1.SetRowCellValue(r, fname, vdt.Rows[0][fname]);
                            }
                            catch { }
                        }
                    }
                }
                 dt.DefaultView.RowFilter="";
            }
            //this.gridView1.FocusedRowHandle = curIndex;
            Timer_WeldDevs.Start();
        }

        private void weldTime_Load(object sender, EventArgs e)
        {

        }
       
    }
}
