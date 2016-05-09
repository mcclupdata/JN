using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
namespace MC
{
    public partial class FormMCCL0040CS : Formbase
    {
        _MyClient _Client = new _MyClient();
        clsEvaWelders _cls = new clsEvaWelders();
        DataTable data;
        String check;
        public FormMCCL0040CS()
        {
            InitializeComponent();
        }

        private void FormMCCL0040CS_Load(object sender, EventArgs e)
        {
            DataTable depart_dt = _Client.ServiceCall(clsCMD.cmd_welderedit_getwelderdepart, null);
            depart_dt.Rows.Add(0, "全部");
            depart_dt.DefaultView.Sort = "FID";
            this.FDepartLookUpEdit.DataSource = depart_dt;
            this.DepartList.Properties.DataSource = depart_dt;
            
            //Lib
            DataTable libs_dt = _Client.ServiceCall(clsCMD.cmd_welderedit_getLibs, null);
            this.FlibLookUpEdit.DataSource = libs_dt;
            //Load welders
            DataTable welders_dt = _Client.ServiceCall(clsCMD.cmd_welderedit_getwelders, null);
            this.welderdataGrid.DataSource = welders_dt;
            this.StartDate.Value = DateTime.Now;
            this.EndDate.Value = DateTime.Now.AddDays(1);
        }

        private void DepartList_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt64(DepartList.EditValue) == 0)
            {
                ((DataTable)this.welderdataGrid.DataSource).DefaultView.RowFilter = "";// "Fdepart=" + DepartList.EditValue;
            }
            else
            {
                ((DataTable)this.welderdataGrid.DataSource).DefaultView.RowFilter = "Fdepart=" + DepartList.EditValue;
            }
        }
        
        /// <summary>
        /// 查看一个焊工的数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void weldergridView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            int eRowhandle = e.RowHandle;
            String fnum = this.weldergridView.GetRowCellValue(eRowhandle, "Fnum").ToString();
            string name = this.weldergridView.GetRowCellValue(eRowhandle, "FName").ToString();
            String startdt = this.StartDate.Value.ToShortDateString();
            String enddt = this.EndDate.Value.AddDays(1).ToShortDateString();
            check = name + "  " + startdt + "--" + enddt;
            data=_cls.getEvaluation_Welders(fnum,startdt,enddt);
            this.evadataGrid.DataSource = data;
            initZEG(data);
    
        }
        private Boolean initZEG(DataTable data)
        {
            //得到GraphPane的引用
            PointPairList list1 = new PointPairList();
            PointPairList list2 = new PointPairList();
            PointPairList list3 = new PointPairList();
            PointPairList list4 = new PointPairList();
            PointPairList list5 = new PointPairList();
            GraphPane myPane = this.zedGraphControl1.GraphPane;
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl1.GraphPane.GraphObjList.Clear();
            zedGraphControl1.AxisChange();
            zedGraphControl1.Refresh();
            list1.Clear();
            list2.Clear();
            list3.Clear();
            list4.Clear();
            list5.Clear();
            myPane.CurveList.Clear();

            myPane.Title.Text = "";
            myPane.XAxis.Title.Text = "";
            myPane.YAxis.Title.Text = "";

           

            //Random rand = new Random();

            //for (double x = 0; x < 5; x++)
            //{
            //    double y = rand.NextDouble() * 100;
            //    double y2 = rand.NextDouble() * 100;
            //    double y3 = rand.NextDouble() * 100;
            //    list.Add(x, y);
            //    list2.Add(x, y2);
            //    list3.Add(x, y3);
            //}
            if (data.Rows.Count == 0)
                return false;
            string[] labels = new string[data.Rows.Count];//= { "域名", "主机", "数据库", "邮局", "套餐" };
            for (int i = 0; i < data.Rows.Count; i++)
            {
                list1.Add(i, Convert.ToDouble(data.Rows[i]["Gx"]));
                list2.Add(i, Convert.ToDouble(data.Rows[i]["Gy"]));
                list3.Add(i, Convert.ToDouble(data.Rows[i]["Gz"]));
                list4.Add(i, Convert.ToDouble(data.Rows[i]["Gv"]));
                list5.Add(i, Convert.ToDouble(data.Rows[i]["G"]));
                labels[i] = "任务" + i;
            }
            BarItem myCurve = myPane.AddBar("电流偏离", list1, Color.Blue);
            myCurve.Bar.Fill = new Fill(Color.White, Color.Blue, 45f);
            BarItem myCurve2 = myPane.AddBar("电流离散", list2, Color.Red);
            myCurve2.Bar.Fill = new Fill(Color.White, Color.Red, 45f);
            BarItem myCurve3 = myPane.AddBar("电压离散", list3, Color.Green);
            myCurve3.Bar.Fill = new Fill(Color.White, Color.Green, 45f);
            BarItem myCurve4 = myPane.AddBar("速度偏离", list4, Color.Green);
            myCurve4.Bar.Fill = new Fill(Color.White, Color.LightPink, 45f);
            BarItem myCurve5 = myPane.AddBar("评估总分", list5, Color.Green);
            myCurve5.Bar.Fill = new Fill(Color.White, Color.Red, 45f);
            //对图像添加灰色网格
            myPane.XAxis.MajorGrid.IsVisible = true;
            myPane.YAxis.MajorGrid.IsVisible = true;
            myPane.XAxis.MajorGrid.Color = Color.Gray;
            myPane.YAxis.MajorGrid.Color = Color.Gray;

            myPane.XAxis.MajorTic.IsBetweenLabels = true;
            
            myPane.XAxis.Scale.TextLabels = labels;
            myPane.XAxis.Type = AxisType.Text;
            myPane.Fill = new Fill(Color.White, Color.FromArgb(200, 200, 255), 45.0f);
            myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45.0f);
            this.zedGraphControl1.AxisChange();
            this.zedGraphControl1.Refresh();
            return false;
        }

        private void efButton1_Click(object sender, EventArgs e)
        {
            DataToExcel weuate = new DataToExcel();
            object objRtn = new object();
            string filen;
            filen = weuate.toexcel(data, 1, check);
            weuate.RunExcelMacro(filen, "Macro3", new Object[] { }, out objRtn, false);
        }
    }
}
