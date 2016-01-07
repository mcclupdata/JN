﻿using System;
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
    public partial class FormMCCL00025 : EF.EFForm
    {
        clswpsEdit _cls;
        _MyClient _Client = new _MyClient();
        clsFrmBase _clsfrm = new clsFrmBase();
        int _taskState = 0;
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
        private weldEquipmentbase _weldEquipmentbase = new weldEquipmentbase();
        public FormMCCL00025()
        {
            InitializeComponent();
            
        }

        private void efGroupBox1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormMCCL0004_Load(object sender, EventArgs e)
        {
            EFForm frm = this;
            //_cls = new clswpsEdit(ref frm);
            //_cls.Load();
            this.EF_DO_F1 += new EFButtonBar.EFDoFnEventHandler(FormMCCL0004_EF_DO_F1);
            this.EF_DO_F2 += new EFButtonBar.EFDoFnEventHandler(FormMCCL0004_EF_DO_F2);
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
            curve1 = myPane.AddCurve("焊接电流", list1, Color.Blue, SymbolType.None);
            curve2 = myPane.AddCurve("焊接电压", list2, Color.Green, SymbolType.None);
            curve_ConA = myPane.AddCurve("标准电流", listConA, Color.Red, SymbolType.None);
            curve_ConV = myPane.AddCurve("标准电压", listConV, Color.Black, SymbolType.None);

            //设置标题
            myPane.Title.Text = "实时曲线";
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
        /// 初始化焊机设备tree
        /// 
        /// </summary>
        protected void iniEquipmentTree()
        {
            _weldEquipmentbase.LoadweldEquipment2Tree(ref this.weldEquipList);
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
            DataRow row = dtweldFiler.NewRow();
            row[0] = selNode.Name;
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

                
                EFForm vfrm = (EFForm)this;
                _clsfrm.FillfrmData(panansonicinfos, ref vfrm);

                x = (double)new XDate(Convert.ToDateTime(panansonicinfos.Rows[0]["NowTime"]));//焊机返回时间
                wa = Convert.ToDouble(panansonicinfos.Rows[0]["wa"]);
                wv = Convert.ToDouble(panansonicinfos.Rows[0]["wv"]);
            }
            if (_taskState == 2)//历史数据
            {
                //EFForm this_frm = (EFForm)this;
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

            if (list.Count >= 200)
            {
                list1.RemoveAt(0);
                list2.RemoveAt(0);
                listConV.RemoveAt(0);
                listConA.RemoveAt(0);
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
            Timer_WeldEquipmentReal();
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
            zedGraphControl1.GraphPane.CurveList.Clear();
            Timer_ZED.Start();
            loadweldEquipmentTask();
            Timer_Task.Start();
            
        }
        /// <summary>
        /// 更新某焊机的任务信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Task_Tick(object sender, EventArgs e)
        {
            loadweldEquipmentTask();
        }
    }
}
