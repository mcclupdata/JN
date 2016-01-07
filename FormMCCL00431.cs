using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MC
{
    public partial class FormMCCL00431 : FormMCCL0043
    {
        public FormMCCL00431()
        {
            InitializeComponent();
            _cls = new clsProjectDispatchTaskmange(0);
        }
        /// <summary>
        /// 进行编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            int rindex = this.HeadGridView.FocusedRowHandle;
            if (rindex < 0)
                return;
            long fid = Convert.ToInt64(this.HeadGridView.GetRowCellValue(rindex, "FID")); ;//this.dataGrid.SelectedRows[0].Cells["CFID"].Value);

            FormMCCL0009 frm = new FormMCCL0009();
            frm._ProjectHeadID = fid;
            frm.ShowDialog(this);
        }

        private void FormMCCL00431_Load(object sender, EventArgs e)
        {
            this.Head.DataSource = _cls.getHead();

        }
        /// <summary>
        /// 查看表体Index
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HeadGridView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            long vheadid = 0;
            vheadid = Convert.ToInt64(this.HeadGridView.GetRowCellValue(e.RowHandle, "FID"));
            this.BodyIndex.DataSource = _cls.getBodyIndex(vheadid);
        }
        /// <summary>
        /// 查看焊缝列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BodyIndexView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            //FProjectHeadID  FDoDepartID
            long vprojectheadid, fdodepartid = 0;
            vprojectheadid = Convert.ToInt64(this.BodyIndexView.GetRowCellValue(e.RowHandle, "FProjectHeadID"));
            fdodepartid = Convert.ToInt64(this.BodyIndexView.GetRowCellValue(e.RowHandle, "FDoDepartID"));
            this.BodyList.DataSource = _cls.getBodyList(vprojectheadid, fdodepartid);
        }
    }
}
