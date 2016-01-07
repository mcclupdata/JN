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
using DevExpress.XtraReports;

namespace MC
{
    public partial class FormMCCL00015 : Formbase
    {
        int cmd_ProjectMag_GetProject = 1034;//获取工序计划列表
        _MyClient _Client = new _MyClient();
        public FormMCCL00015()
        {
            InitializeComponent();
            
        }

        protected Boolean GetProject()
        {
            DataTable dt = _Client.ServiceCall(cmd_ProjectMag_GetProject, null);
            this.dataGrid.DataSource = dt;
            //this.dataGrid.AutoGenerateColumns = true;
            return false;
        }
        /// <summary>
        /// 双击进行编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void dataGrid_CellContentDoubleClick(object sender, RowCellClickEventArgs e)
        {
            //双击进行编辑；
            GridView dgv = (GridView)sender;
            long fid = 0;
            fid = Convert.ToInt64(dgv.GetRowCellValue(e.RowHandle, "FID")) ;//dgv.Rows[e.RowIndex].Cells["CFID"].Value);
            //clsProjectProcess cls = new clsProjectProcess(fid);

        }

        private void butReflash_Click(object sender, EventArgs e)
        {
            GetProject();
        }

        private void butEdit_Click(object sender, EventArgs e)
        {
            GridView efGridView = (GridView)this.dataGrid.Views[0];
            if (efGridView.SelectedRowsCount == 0)
            {
                MessageBox.Show("请选择工序计划后点击编辑");
                return;
            }
            long fid = 0;
            DataRow row=efGridView.GetFocusedDataRow();
            fid = Convert.ToInt64(row["FID"]);//this.dataGrid.SelectedRows[0].Cells["CFID"].Value);
            //clsProjectProcess cls = new clsProjectProcess(fid);
            FormMCCL0009 frm = new FormMCCL0009();
            frm._ProjectHeadID = fid;
            frm.ShowDialog(this);
            GetProject();
        }

        private void frmProjectMag_Load(object sender, EventArgs e)
        {
            GetProject();
        }

        private void butDel_Click(object sender, EventArgs e)
        {
            GridView efGridView = (GridView)this.dataGrid.Views[0];
            if (efGridView.SelectedRowsCount == 0)
            {
                MessageBox.Show("请选择工序计划后点击编辑");
                return;
            }
            long fid = 0;
            DataRow row = efGridView.GetFocusedDataRow();
            fid = Convert.ToInt64(row["FID"]);//this.dataGrid.SelectedRows[0].Cells["CFID"].Value);
            clsProjectProcess cls = new clsProjectProcess();
            cls.Delete(fid);
            GetProject();

        }

        private void FormMCCL00015_EF_DO_F1(object sender, EF_Args e)
        {
            butReflash_Click(this.butReflash, null);
        }

        private void FormMCCL00015_EF_DO_F2(object sender, EF_Args e)
        {
            butEdit_Click(this.butEDit, null);
        }

        private void FormMCCL00015_EF_DO_F3(object sender, EF_Args e)
        {
            butDel_Click(this.butDel, null);
        }
    }
}
