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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraExport;
using DevExpress.XtraEditors;
namespace MC
{
    public partial class FormMCCL00032 : Formbase
    {
        private _MyClient _Client;
        private DataTable _weldpoint;
        private DataTable _welds;
        protected int _type=0;
        public FormMCCL00032()
        {
            _Client = new _MyClient();
            InitializeComponent();
           
        }

        protected void showColumn(int start, int end,Boolean IsShow)
        {
            String Colname = "gridColumn";
            for (int i = start; i < end + 1; i++)
            {
                String col = Colname + i.ToString();
                for (int k = 0; k < View.Columns.Count; k++)
                {
                    if (View.Columns[k].Name == col)
                        View.Columns[k].Visible = IsShow;
                }
            }
        }
        /// <summary>
        /// 初始化界面
        /// </summary>
        protected void Initi()
        {
            this.Date.Value = new DateTime(Date2.Value.Year, Date2.Value.Month, Date2.Value.Day, 8, 0, 0);
            this.Date2.Value = new DateTime(Date2.Value.Year, Date2.Value.Month, Date2.Value.Day, 8, 0, 0);
            this.EDate2.Value = new DateTime(Date2.Value.Year, Date2.Value.Month, Date2.Value.Day, 8, 0, 0);
            this.EDate.Value = new DateTime(Date2.Value.Year, Date2.Value.Month, Date2.Value.Day, 8, 0, 0);
            switch (_type)
            {
                case 0://日
                  
                    EDateLab.Visible = false;
                    EDateLab2.Visible = false;
                    EDate2.Visible = false;
                    EDate.Visible = false;
                    break;
                case 1://月
                    Date.CustomFormat = "yyyy-MM";
                    Date.Format = DateTimePickerFormat.Custom;
                    Date2.CustomFormat = "yyyy-MM";
                    Date2.Format = DateTimePickerFormat.Custom;
                    EDateLab.Visible = false;
                    EDateLab2.Visible = false;
                    EDate2.Visible = false;
                    EDate.Visible = false;
                    break;
                case 2://free
                    EDateLab.Visible = true;
                    EDateLab2.Visible = true;
                    EDate2.Visible = true;
                    EDate.Visible = true;
                    break;
            }

      
            //提取焊机并绑定到Fwelds
            DataTable fdt=new DataTable();
            DataColumn col=new DataColumn("FType",typeof(int));fdt.Columns.Add(col);
            DataRow row=fdt.NewRow();row[0]=1;fdt.Rows.Add(row);

            _welds= _Client.ServiceCall(clsCMD.cmd_Report_ReportBase,fdt);

            DataView dv = _welds.Copy().DefaultView;
            _weldpoint = dv.ToTable(true, "FDepartName");

            fdt.Rows.Clear(); fdt.Rows.Add(2);
            DataTable welders = _Client.ServiceCall(clsCMD.cmd_Report_ReportBase, fdt);
            welders = welders.DefaultView.ToTable(true, "FName", "Fnum");
            welders.Rows.Add("所有焊工", "0");
            this.FWelders.Properties.DisplayMember = "FName";
            this.FWelders.Properties.ValueMember = "FName";

            this.FWelders.Properties.DataSource = welders;
            this.FWelders.ItemIndex = welders.Rows.Count+1;

            this.FWELDS.Properties.DisplayMember = "FEquipName";
            this.FWELDS.Properties.ValueMember = "FweldEquipmentID";

            this.FWeldPoint.Properties.DisplayMember = "FDepartName";
            this.FWeldPoint.Properties.ValueMember = "FDepartName";
            _weldpoint.Rows.Add("全部");
            this.FWeldPoint.Properties.DataSource = _weldpoint;
            this.FWeldPoint.ItemIndex = _weldpoint.Rows.Count+1;
           
            


            //

        }
        /// <summary>
        /// 控制指定列的显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chk1_CheckedChanged(object sender, EventArgs e)
        {
            EFCheckBox chk = (EFCheckBox)sender;
            int start = 0;
            int end = 0;
            Boolean ishow = chk.Checked;
            int iindex = Convert.ToInt32(chk.Tag);
            switch (iindex)
            {
                case 0:
                    start=9;end=13;
                    break;
                case 1:
                    start = 14; end = 15;
                    break;
                case 2:
                    start = 16; end = 18;
                    break;
                case 3:
                    start = 19; end = 19;
                    break;
                case 4:
                    start = 20; end = 23;
                    break;
                default:
                    break;
            }
            showColumn(start, end, ishow);

        }
        /// <summary>
        /// 执行查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butOK_Click(object sender, EventArgs e)
        {
            String STARTTIME, ENDTIME, WELDID;
            DateTime LastDay = Date.Value.AddMonths(1).AddDays(-Date.Value.AddMonths(1).Day);

            switch (_type)
            {
                case 0://日

                    STARTTIME = new DateTime(Date.Value.Year, Date.Value.Month, Date.Value.Day, 8, 0, 0).ToString("yyyy-MM-dd HH:mm:ss");

                    ENDTIME = new DateTime(Date.Value.Year, Date.Value.Month, Date.Value.Day, 21, 0, 0).ToString("yyyy-MM-dd HH:mm:ss");


                    break;
                case 1://月
                    STARTTIME = new DateTime(Date.Value.Year, Date.Value.Month, 1, 8, 0, 0).ToString("yyyy-MM-dd HH:mm:ss");

                    ENDTIME = new DateTime(Date.Value.Year, Date.Value.Month, LastDay.Day, 21, 0, 0).ToString("yyyy-MM-dd HH:mm:ss");


                    break;
                case 2://free
                    STARTTIME = new DateTime(Date.Value.Year, Date.Value.Month, Date.Value.Day, 8, 0, 0).ToString("yyyy-MM-dd HH:mm:ss");

                    ENDTIME = new DateTime(EDate.Value.Year, EDate.Value.Month, EDate.Value.Day, 21, 0, 0).ToString("yyyy-MM-dd HH:mm:ss");
                    break;
                default:
                    STARTTIME = new DateTime(Date.Value.Year, Date.Value.Month, Date.Value.Day, 8, 0, 0).ToString("yyyy-MM-dd HH:mm:ss");

                    ENDTIME = new DateTime(Date.Value.Year, Date.Value.Month, Date.Value.Day, 21, 0, 0).ToString("yyyy-MM-dd HH:mm:ss");


                    break;
            }



            String nom = this.FWELDS.EditValue.ToString();

            DataTable fdt = new DataTable();
            DataColumn col = new DataColumn(); col.ColumnName = "FSTARTTIME"; col.DataType = typeof(String); fdt.Columns.Add(col);
            col = new DataColumn(); col.ColumnName = "FENDTIME"; col.DataType = typeof(String); fdt.Columns.Add(col);
            col = new DataColumn(); col.ColumnName = "nom"; col.DataType = typeof(String); fdt.Columns.Add(col);
            col = new DataColumn(); col.ColumnName = "FDepartName"; col.DataType = typeof(String); fdt.Columns.Add(col);

            DataRow row = fdt.NewRow();
            row["FSTARTTIME"] = STARTTIME; row["FENDTIME"] = ENDTIME; row["nom"] = FWELDS.EditValue.ToString() == "0" ? "" : FWELDS.EditValue.ToString(); row["FDepartName"] = FWeldPoint.EditValue.ToString() == "全部" ? "" : FWeldPoint.EditValue.ToString();
            fdt.Rows.Add(row);
            DataTable rsdt = _Client.ServiceCall(clsCMD.cmd_Report_weldReport_weld, fdt);
            if (rsdt.Rows.Count == 0)
                MessageBox.Show(this, "无数据", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.dataGrid.DataSource    = rsdt;

        }
        /// <summary>
        /// 焊机位置与焊机联动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FWeldPoint_EditValueChanged(object sender, EventArgs e)
        {
            if (_welds == null)
                return;
            DataView dv = _welds.Copy().DefaultView;
            String point = this.FWeldPoint.EditValue.ToString();
            if (point == "全部")
                return;

            dv.RowFilter = "FDepartName='" + point+"'";
            DataTable dt = dv.ToTable(true, "FDepartName", "FweldEquipmentID", "FEquipName");
            dt.Rows.Add("所有焊机", "0", "所有焊机");
            FWELDS.Properties.DataSource = dt;
            FWELDS.ItemIndex = dt.Rows.Count + 1;
            
        }

        private void butOK2_Click(object sender, EventArgs e)
        {
            String STARTTIME, ENDTIME, WELDID;

            DateTime LastDay = Date2.Value.AddMonths(1).AddDays(-Date2.Value.AddMonths(1).Day);

            switch (_type)
            {
                case 0://日

                    STARTTIME = new DateTime(Date2.Value.Year, Date2.Value.Month, Date2.Value.Day, 8, 0, 0).ToString("yyyy-MM-dd HH:mm:ss");

                    ENDTIME = new DateTime(Date2.Value.Year, Date2.Value.Month, Date2.Value.Day, 21, 0, 0).ToString("yyyy-MM-dd HH:mm:ss");


                    break;
                case 1://月
                    STARTTIME = new DateTime(Date2.Value.Year, Date2.Value.Month, 1, 8, 0, 0).ToString("yyyy-MM-dd HH:mm:ss");

                    ENDTIME = new DateTime(Date2.Value.Year, Date2.Value.Month, LastDay.Day, 21, 0, 0).ToString("yyyy-MM-dd HH:mm:ss");


                    break;
                case 2://free
                    STARTTIME = new DateTime(Date2.Value.Year, Date2.Value.Month, Date2.Value.Day, 8, 0, 0).ToString("yyyy-MM-dd HH:mm:ss");

                    ENDTIME = new DateTime(EDate2.Value.Year, EDate2.Value.Month, EDate2.Value.Day, 21, 0, 0).ToString("yyyy-MM-dd HH:mm:ss");
                    break;
                default:
                    STARTTIME = new DateTime(Date2.Value.Year, Date2.Value.Month, Date2.Value.Day, 8, 0, 0).ToString("yyyy-MM-dd HH:mm:ss");

                    ENDTIME = new DateTime(Date2.Value.Year, Date2.Value.Month, Date2.Value.Day, 21, 0, 0).ToString("yyyy-MM-dd HH:mm:ss");


                    break;
            }


            String nom = this.FWELDS.EditValue.ToString();

            DataTable fdt = new DataTable();
            DataColumn col = new DataColumn(); col.ColumnName = "FSTARTTIME"; col.DataType = typeof(String); fdt.Columns.Add(col);
            col = new DataColumn(); col.ColumnName = "FENDTIME"; col.DataType = typeof(String); fdt.Columns.Add(col);
            col = new DataColumn(); col.ColumnName = "FName"; col.DataType = typeof(String); fdt.Columns.Add(col);
            //col = new DataColumn(); col.ColumnName = "FDepartName"; col.DataType = typeof(String); fdt.Columns.Add(col);

            DataRow row = fdt.NewRow(); fdt.Rows.Clear();
            row["FSTARTTIME"] = STARTTIME; row["FENDTIME"] = ENDTIME; row["FName"] = FWelders.EditValue.ToString() == "所有焊工"|| FWelders.EditValue.ToString() == "0"? "" : FWelders.EditValue.ToString(); //row["FDepartName"] = FWeldPoint.EditValue.ToString() == "全部要" ? "" : FWeldPoint.EditValue.ToString();
            fdt.Rows.Add(row);
            DataTable rsdt = _Client.ServiceCall(clsCMD.cmd_Report_WeldReport_Welder, fdt);
            if (rsdt.Rows.Count == 0)
                MessageBox.Show(this, "无数据", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.dataGrid2.DataSource = rsdt;

        }

        private void FormMCCL00032_Load(object sender, EventArgs e)
        {
            Initi();
            NavigatorCustomButton cu = this.dataGrid.EmbeddedNavigator.Buttons.CustomButtons.Add();
            cu.Hint = "打印";
            cu.ImageIndex = 10;
            cu.Enabled = true;
            cu.Visible = true;
            cu = this.dataGrid2.EmbeddedNavigator.Buttons.CustomButtons.Add();
            cu.Hint = "打印";
            cu.ImageIndex = 10;
            cu.Enabled = true;
            cu.Visible = true;
            
            //添加打印按钮
           // for (int k = 0; k < this.dataGrid.EmbeddedNavigator.Buttons.CustomButtons.Count; k++)
           // {
              //  if (this.dataGrid.EmbeddedNavigator.Buttons.CustomButtons[k].Tag == "Print")
               // {
                //    NavigatorCustomButton but = this.dataGrid.EmbeddedNavigator.Buttons.CustomButtons[k];
            this.dataGrid.EmbeddedNavigator.ButtonClick += new NavigatorButtonClickEventHandler(EmbeddedNavigator_ButtonClick);
            this.dataGrid2.EmbeddedNavigator.ButtonClick += new NavigatorButtonClickEventHandler(EmbeddedNavigator_ButtonClick);

            // }
            //}

        }

        void EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            DevExpress.XtraGrid.GridControlNavigator but = (DevExpress.XtraGrid.GridControlNavigator)sender;
            if (e.Button.Hint=="打印")
            {
                Control cl = but.Parent;
                EFDevGrid dg = (EFDevGrid)cl;
                dg.ShowPrintPreview();

            }
            //if (but)
            //String str = but.Tag.ToString();

            //throw new NotImplementedException();
        }

        private void dataGrid_EF_GridBar_Refresh_Event(object sender, NavigatorButtonClickEventArgs e)
        {

        }
    }
}
