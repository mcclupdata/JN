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
    public partial class FormMCCL00030 : Formbase
    {
        private _MyClient _Client = new _MyClient();
        public FormMCCL00030()
        {
            InitializeComponent();
            Initi();
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
            this.Date.Value = DateTime.Now;
            this.FSTARTTIME.EditValue = "08:00:00";
            this.FENDTIME.EditValue = "21:00:00";
            //提取焊机并绑定到Fwelds
            DataTable fdt=new DataTable();
            DataColumn col=new DataColumn("FType",typeof(int));fdt.Columns.Add(col);
            DataRow row=fdt.NewRow();row[0]=1;fdt.Rows.Add(row);

            DataTable dt_welds= _Client.ServiceCall(clsCMD.cmd_Report_ReportBase,fdt);
            dt_welds = dt_welds.DefaultView.ToTable(true, "FDepartName","FweldEquipmentID","FEquipName");
            //DataRow nr= dt_welds.NewRow();
            //nr["FDepartName"] = "所有"; nr["FweldEquipmentID"] = "0"; nr["FEquipName"] = "所有焊机";

            this.FWELDS.Properties.DisplayMember = "FEquipName";
            this.FWELDS.Properties.ValueMember = "FweldEquipmentID";
            this.FWELDS.Properties.DataSource=dt_welds;
            FWELDS.ItemIndex = 0;

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
            //STARTTIME = this.Date.Value.ToString("yyyy-MM-dd");
            String s=FSTARTTIME.EditValue.ToString();
            String[] ss=s.Split(':');
            DateTime dtes = new DateTime(Date.Value.Year, Date.Value.Month, Date.Value.Day, Convert.ToInt32(ss[0]), Convert.ToInt32(ss[1]), Convert.ToInt32(ss[2]));
            STARTTIME = dtes.ToString("yyyy-MM-dd HH:mm:ss");
            String en = FENDTIME.EditValue.ToString();
            String[] sen = en.Split(':');
            DateTime dteen = new DateTime(Date.Value.Year, Date.Value.Month, Date.Value.Day, Convert.ToInt32(sen[0]), Convert.ToInt32(sen[1]), Convert.ToInt32(sen[2]));
            ENDTIME = dteen.ToString("yyyy-MM-dd HH:mm:ss");

            String nom = this.FWELDS.EditValue.ToString();

            DataTable fdt = new DataTable();
            DataColumn col = new DataColumn(); col.ColumnName = "FSTARTTIME"; col.DataType = typeof(String); fdt.Columns.Add(col);
            col = new DataColumn(); col.ColumnName = "FENDTIME"; col.DataType = typeof(String); fdt.Columns.Add(col);
            col = new DataColumn(); col.ColumnName = "nom"; col.DataType = typeof(String); fdt.Columns.Add(col);

            DataRow row = fdt.NewRow();
            row["FSTARTTIME"] = STARTTIME; row["FENDTIME"] = ENDTIME; row["nom"] = nom; fdt.Rows.Add(row);
            DataTable rsdt = _Client.ServiceCall(clsCMD.cmd_Report_WeldSectionRp, fdt);
            if (rsdt.Rows.Count == 0)
                MessageBox.Show(this, "无数据", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.dataGrid.DataSource    = rsdt;

        }
    }
}
