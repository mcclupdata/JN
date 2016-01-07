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
using DevExpress.XtraReports;
using DevExpress.XtraGrid.Views.Grid;
namespace MC
{
    public partial class FormMCCL00018: Formbase
    {
        public FormMCCL00018()
        {
            InitializeComponent();
            
        }
        int cmd_frmDispatchBillMag_GetBILL = 1036;//获取派工单列表
        _MyClient _Client = new _MyClient();
      

        protected Boolean GetDispatchHead()
        {
            DataTable dt = _Client.ServiceCall(cmd_frmDispatchBillMag_GetBILL, null);
            this.dataGrid.DataSource = dt;
            return false;
        }
        /// <summary>
        /// 双击进行编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void dataGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //双击进行编辑；
            GridView dgv = (GridView)sender;
            long fid = 0;
            FormMCCL0006 frm = new FormMCCL0006();
            Formbase vfrm = (Formbase)frm;
            fid = Convert.ToInt64(dgv.GetRowCellValue(e.RowIndex,"FID"));//dgv.Rows[e.RowIndex].Cells["CFID"].Value);
            clsFirstDispatch cls = new clsFirstDispatch(fid,ref vfrm);
            
        }

        private void butReflash_Click(object sender, EventArgs e)
        {
            GetDispatchHead();
        }

        private void butEdit_Click(object sender, EventArgs e)
        {
            GridView efGridView = (GridView)this.dataGrid.Views[0];
            DataRow row = efGridView.GetFocusedDataRow();

            if (efGridView.SelectedRowsCount == 0)
            {
                MessageBox.Show("请选择工序计划后点击编辑");
                return;
            }
            long fid = 0;
            

            fid = Convert.ToInt64(row["FID"]);//this.dataGrid.SelectedRows[0].Cells["CFID"].Value);
            FormMCCL0006 frm = new FormMCCL0006();
            frm._HeadID = fid;
            frm.ShowDialog(this);
            //Formbase vfrm = (Formbase)frm;
            //clsFirstDispatch cls = new clsFirstDispatch(fid,ref vfrm);
            GetDispatchHead();
        }

        private void frmDispatchBillMag_Load(object sender, EventArgs e)
        {
            GetDispatchHead();
        }

        private void butDel_Click(object sender, EventArgs e)
        {
            GridView efGridView = (GridView)this.dataGrid.Views[0];
            DataRow row = efGridView.GetFocusedDataRow();
            if (efGridView.SelectedRowsCount == 0)
            {
                MessageBox.Show("请选择工序计划后点击编辑");
                return;
            }
            long fid = 0;
            fid = Convert.ToInt64(row["FID"]);//this.dataGrid.SelectedRows[0].Cells["CFID"].Value);
            Formbase frm = this;
            clsFirstDispatch cls = new clsFirstDispatch(ref frm);
            cls.Delete(fid);
            GetDispatchHead();
        }

        private void FormMCCL00018_EF_PRE_DO_F1(object sender, EF_Args e)
        {
            butReflash_Click(this.butReflash, null);
        }

        private void FormMCCL00018_EF_PRE_DO_F2(object sender, EF_Args e)
        {
            butEdit_Click(this.butEDit, null);
        }

        private void FormMCCL00018_EF_PRE_DO_F3(object sender, EF_Args e)
        {
            butDel_Click(this.butDel, null);
        }
    }
}
