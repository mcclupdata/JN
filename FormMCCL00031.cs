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
    public partial class FormMCCL00031 : Formbase
    {
        private _MyClient _Client = new _MyClient();
        public FormMCCL00031()
        {
            InitializeComponent();
            Initi();
            NavigatorCustomButton cu = this.dataGrid.EmbeddedNavigator.Buttons.CustomButtons.Add();
            cu.Hint = "打印";
            cu.ImageIndex = 10;
            cu.Enabled = true;
            cu.Visible = true;
            this.dataGrid.EmbeddedNavigator.ButtonClick += new NavigatorButtonClickEventHandler(EmbeddedNavigator_ButtonClick);
        }

        void EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Hint == "打印")
            {
                this.dataGrid.ShowPrintPreview();
            }
            //throw new NotImplementedException();
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
            
            this.FSTARTTIMe.EditValue = new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day,8,0,0);
            this.FENDTIME.EditValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 21, 0, 0);
          
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
           
            ENDTIME = Convert.ToDateTime(FENDTIME.EditValue.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
            STARTTIME = Convert.ToDateTime(FSTARTTIMe.EditValue.ToString()).ToString("yyyy-MM-dd HH:mm:ss");
         

            DataTable fdt = new DataTable();
            DataColumn col = new DataColumn(); col.ColumnName = "FSTARTTIME"; col.DataType = typeof(String); fdt.Columns.Add(col);
            col = new DataColumn(); col.ColumnName = "FENDTIME"; col.DataType = typeof(String); fdt.Columns.Add(col);

            DataRow row = fdt.NewRow();
            row["FSTARTTIME"] = STARTTIME; row["FENDTIME"] = ENDTIME; fdt.Rows.Add(row);
            DataTable rsdt = _Client.ServiceCall(clsCMD.cmd_Report_TaskReport, fdt);
            if (rsdt.Rows.Count == 0)
                MessageBox.Show(this, "无数据", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.dataGrid.DataSource    = rsdt;

        }
    }
}
