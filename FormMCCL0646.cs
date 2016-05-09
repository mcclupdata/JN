using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace MC
{
    public partial class FormMCCL0646 : Formbase
    {
        DataTable _alarmlist;
        DataTable _countlist;
        //DataTable dt_point;
        String fnum;
        _MyClient _Client = new _MyClient();
        clsFrmBase _clsfrm = new clsFrmBase();
        int cmd_alm = 6040701;
        int cmd_cot = 6040702;
        int tickStart = 0;
        private PointPairList list1 = new PointPairList();
        private PointPairList list2 = new PointPairList();
        private PointPairList listConA = new PointPairList();
        private PointPairList listConV = new PointPairList();
        private PointPairList listConMxA = new PointPairList();
        private PointPairList listConMxV = new PointPairList();
        private PointPairList listConMiA = new PointPairList();
        private PointPairList listConMiV = new PointPairList();
        private PointPairList Listgood = new PointPairList();
        double y = 0;
        LineItem curve1;
        LineItem curve2;
        LineItem curve_ConA;
        LineItem curve_ConV;
        LineItem ConMxA;
        LineItem ConMiA;
        LineItem ConMxV;
        LineItem ConMinV;
        LineItem curGood;
        double _BA = 0;
        double _BV = 0;
        string name;
        string daexbody;
        int rowindex = 0;
        DateTime SDtime;
        DateTime EDtime;
        private weldEquipmentbase _weldEquipmentbase = new weldEquipmentbase();
        PointPairList list = new PointPairList();   //zhu
        public FormMCCL0646()
        {
            InitializeComponent();
        }

        private void FormMCCL0646_Load(object sender, EventArgs e)
        {
            weldWorkerbase webase = new weldWorkerbase();
            //dt_point = _Client.ServiceCall(clsCMD.cmd_weldEquipment_weldPoint, null);
            webase.LoadwelderTree(ref this.Treeview_welders);
            StartTime.Value = Convert.ToDateTime("08:00:00");
            iniZEDGrap();
            this.gridView2.OptionsView.ColumnAutoWidth = true;
        }
        /// <summary>
        /// 初始化曲线
        /// </summary>
        protected void iniZEDGrap()
        {
            //折线图初始化
            GraphPane myPane = zedGraphControl1.GraphPane;
            GraphPane myPane2 = zedGraphControl2.GraphPane;
 
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

            Listgood.Clear();

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

            //curGood = myPane2.AddCurve("合格率", Listgood, Color.DarkBlue,SymbolType.Square);

            //myPane2.YAxis.MajorGrid.IsVisible = true;
            ////myPane.XAxis.MajorGrid.Color = Color.Gray;
            //myPane2.YAxis.MajorGrid.Color = Color.Gray;


            //myPane2.XAxis.MajorTic.IsBetweenLabels = true;
            ////myPane2.XAxis.Scale.TextLabels = labels;
            //myPane2.XAxis.Type = AxisType.Text;
            //// myPane.Fill = new Fill(Color.White, Color.FromArgb(200, 200, 255), 45.0f);
            //myPane2.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45.0f);


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

            //curGood.Line.Style = System.Drawing.Drawing2D.DashStyle.Solid;
            //curGood.Line.Width = 1.0F;

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

            //Timer_ZED.Interval = 1000;	//设置timer控件的间隔为50毫秒
            //Timer_ZED.Enabled = false;	//timer可用
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

            myPane2.XAxis.Scale.Min = 0;	//X轴最小值0
            myPane2.XAxis.Scale.Max = 100;


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
            //柱状图初始化
            GraphPane myPane1 = zedGraphControl2.GraphPane;
            zedGraphControl2.GraphPane.CurveList.Clear();
            zedGraphControl2.GraphPane.GraphObjList.Clear();
            zedGraphControl2.AxisChange();
            zedGraphControl2.Refresh();
            zedGraphControl2.IsEnableHEdit = false;
            zedGraphControl2.IsEnableHZoom = false;
            zedGraphControl2.IsEnableZoom = false;
            list.Clear();
            myPane1.Title.IsVisible = false;
            myPane1.XAxis.Title.IsVisible = false;
            myPane1.YAxis.Title.IsVisible = false;
            myPane1.XAxis.Scale.Min = 0;	//X轴最小值0
            myPane1.XAxis.Scale.Max = 80;	//X轴最大30
            myPane1.YAxis.Scale.Max = 100;
            myPane1.YAxis.Scale.Min = 0;

            zedGraphControl2.Invalidate();
        }

        private Boolean InitialzedGraph(int index)
        {
            switch (index)
            {
                case 0:
                    break;
                case 1:

                    break;
                default: break;
            }
            return false;
        }
        /// <summary>
        /// 柱状图
        /// </summary>
        /// <param name="zgc"></param>
        private void CreateGraphz(ZedGraphControl zgc)
        {

            //得到GraphPane的引用

            zedGraphControl2.GraphPane.CurveList.Clear();
            zedGraphControl2.GraphPane.GraphObjList.Clear();
            zedGraphControl2.AxisChange();
            zedGraphControl2.Refresh();

            list.Clear();

            GraphPane myPane = zgc.GraphPane;

            string[] labels = new string[100];
            
            //Random rand = new Random();
            DataTable _cpcountlist = _alarmlist.Copy();// _countlist.Copy();
            DataView dv = _cpcountlist.DefaultView;
            //if (rowindex == 0)
            //    return;
            //name = gridView2.GetRowCellValue(rowindex, "Fname").ToString();

            //string s = string.Format("Starttme >= '{0}' and Endtme <= '{1}' and FName ='{2}'", SDtime, EDtime, name);
            //dv.RowFilter = s;
            DataTable ndt = dv.ToTable();
            labels = new string[ndt.Rows.Count];
            zedGraphControl2.GraphPane.XAxis.Scale.Max = ndt.Rows.Count;
            for (int x = 0; x < ndt.Rows.Count; x++)         //赋值
            {
                double y = Convert.ToInt32((double.Parse(ndt.Rows[x]["good"].ToString()) / (Convert.ToInt32(ndt.Rows[x]["allc"])))*100);
                list.Add(x, y);
                labels[x] = Convert.ToString(x);
                //Listgood.Add(x, y);
            }

           BarItem myCurve = myPane.AddBar("", list, Color.Blue);
            //Listgood = list;

            myCurve.Bar.Fill = new Fill(Color.White, Color.Blue, 45f);

            //对图像添加灰色网格
            myPane.XAxis.MajorGrid.IsVisible = true;

            zedGraphControl2.AxisChange();
            zedGraphControl2.Invalidate();
        }
        /// <summary>
        /// 折线图
        /// </summary>
        /// <param name="zgc"></param>
        private void CreateGraphx(ZedGraphControl zgc,DataTable data)
        {
            double x = 0;
            double wa = 0;
            double wv = 0;
            //DataTable _cpcountlist = _countlist.Copy();
            //DataView dv = _cpcountlist.DefaultView;
            //if (rowindex == 0) return;
            //name = gridView2.GetRowCellValue(rowindex, "Fname").ToString();
            ////dv.RowFilter = "nowtime1 between" + StartTime.Value + "and " + EndTime.Value;
            //string.Format("nowtime1 >= '{0}' and date <= '{1}' and FName ='{2}'", SDtime, EDtime,name);
            //DataTable ndt = dv.ToTable();
            DataTable ndt = data;
            for (int i = 0; i < ndt.Rows.Count; i++)
            {
                x = (double)new XDate(Convert.ToDateTime(ndt.Rows[i]["nowtime1"]));//焊机返string.Format("date >= '{0}' and date <= '{1}'",StartDate,EndDate)回时间
                wa = Convert.ToDouble(ndt.Rows[i]["wa"]);
                wv = Convert.ToDouble(ndt.Rows[i]["wv"]);
                _BA = Convert.ToDouble(ndt.Rows[i]["va"]);
                _BV = Convert.ToDouble(ndt.Rows[i]["vv"]);
                listConMxA.Add(x, Convert.IsDBNull(ndt.Rows[i]["va_up"]) ? 0 : Convert.ToDouble(ndt.Rows[0]["va_up"]));
                listConMiA.Add(x, Convert.IsDBNull(ndt.Rows[i]["va_down"]) ? 0 : Convert.ToDouble(ndt.Rows[0]["va_down"]));
                listConMxV.Add(x, Convert.IsDBNull(ndt.Rows[i]["vv_up"]) ? 0 : Convert.ToDouble(ndt.Rows[0]["vv_up"]));
                listConMiV.Add(x, Convert.IsDBNull(ndt.Rows[i]["vv_down"]) ? 0 : Convert.ToDouble(ndt.Rows[0]["vv_down"]));
                list1.Add(x, wa);//电流曲线
                list2.Add(x, wv);//电压曲线
                listConA.Add(x, _BA);
                listConV.Add(x, _BV);
            }
            Scale xScale = zedGraphControl1.GraphPane.XAxis.Scale;
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }

        private void efButton2_Click(object sender, EventArgs e)
        {
            
            DataToExcel re = new DataToExcel();
            object objRtn = new object();
            string fname;//文件焊工名
            int n=0;
            string[] dtfname = new string[255];//表内焊工名
            string zname;
            if (_alarmlist.Rows.Count > 0)
            {
                dtfname[0] = _alarmlist.Rows[0]["Fname"].ToString();
                n++;
                for (int i = 1; i < _alarmlist.Rows.Count; i++)
                {
                    zname = _alarmlist.Rows[i]["Fname"].ToString();
                    if (zname != _alarmlist.Rows[i - 1]["Fname"].ToString())
                    {
                        dtfname[n] = zname;
                        n++;
                    }
                }
                for (int i = 0; i < n; i++)
                {
                    DataTable _cpalmlist = _alarmlist.Copy();
                    DataView dv = _cpalmlist.DefaultView;
                    string sn = "Fname=" + "'" + dtfname[i] + "'";
                    dv.RowFilter = sn;
                    DataTable ndt = dv.ToTable();
                    _cpalmlist.Columns.Remove("Fname");
                    _cpalmlist.Columns.Remove("minid");
                    _cpalmlist.Columns.Remove("Maxid");
                    _cpalmlist.Columns.Remove("allc");
                    string fn = dtfname[i];
                    string daex;
                    daex = "姓名:"+fn + "  " + daexbody;
                    fname = re.toexcel(_cpalmlist, 1,daex);
                    if (fname != null)
                        re.RunExcelMacro(fname, "模板1", new Object[] { }, out objRtn, false);
                    else
                        return;
                }
            }
            //}
            //catch
            //{

            //}
            
            
        }

        private void efButton1_Click(object sender, EventArgs e)
        {
              iniZEDGrap();
              SDtime = Convert.ToDateTime(CheckData.Value.Year.ToString() + '/' + CheckData.Value.Month.ToString() + '/' + CheckData.Value.Day.ToString() + ' '
                 + StartTime.Value.Hour.ToString() + ':' + StartTime.Value.Minute.ToString() + ':' + StartTime.Value.Second.ToString());
              EDtime = Convert.ToDateTime(CheckData.Value.Year.ToString() + '/' + CheckData.Value.Month.ToString() + '/' + CheckData.Value.Day.ToString() + ' '
                 + EndTime.Value.Hour.ToString() + ':' + EndTime.Value.Minute.ToString() + ':' + EndTime.Value.Second.ToString());
              daexbody = "查询时间:" + SDtime.ToString() + "-" + EDtime.ToString();
              DataTable dt = new DataTable();
              dt.Columns.Add("SDTime", typeof(DateTime));
              dt.Columns.Add("EDTime", typeof(DateTime));
              dt.Columns.Add("Fnum", typeof(String));
              DataRow dr = dt.NewRow();
              dr["SDTime"] = SDtime;
              dr["EDTime"] = EDtime;
              if (this.Treeview_welders.SelectedNode == null)
              {
                  MessageBox.Show(this, "请选择焊工", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  return;
              }
              string nae = this.Treeview_welders.SelectedNode.Name;
              string key = this.Treeview_welders.SelectedNode.Text;
              if (nae == key)
                  return;
              String  welderNum = nae;



              try
              {
                  dr["Fnum"] = welderNum;
              }
              catch
              {
                  MessageBox.Show("请选择焊工", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                  return;
              }
              dt.Rows.Add(dr);
              _alarmlist = _Client.ServiceCall(cmd_alm, dt);
              _countlist = _Client.ServiceCall(cmd_cot, dt);
              this.efDevGrid1.DataSource = _alarmlist;
              this.gridView2.OptionsView.ColumnAutoWidth = true;
             // try
             // {
                  
                 // CreateGraphx(zedGraphControl1,);
                  gridView2_RowClick(null,null);
                  CreateGraphz(zedGraphControl2);
             // }
             // catch
              //{
              //    return;
              //}
        }

        private void efTreeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string nae = e.Node.Name;
            string key = e.Node.Text;
            if (e.Node.Name == e.Node.Text)
                return;
            fnum = e.Node.Name;
        }
        /// <summary>
        /// 重现焊接曲线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            //获取ID范围值
            long startid = 0;
            long endid = 0;
            int rowindex = this.gridView2.FocusedRowHandle ;
            startid = Convert.ToInt64(this.gridView2.GetRowCellValue(rowindex, "minid"));
            endid = Convert.ToInt64(this.gridView2.GetRowCellValue(rowindex, "Maxid"));
            String filter = " id >= {0} and id <={1}";
            filter = String.Format(filter, startid, endid);
            DataTable vdt = _countlist.Copy();
            vdt.DefaultView.RowFilter = filter;
            iniZEDGrap();
            DataTable dt = vdt.DefaultView.ToTable();
            CreateGraphx(this.zedGraphControl1, dt);
            CreateGraphz(zedGraphControl2);
        }
    }
}
