using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MC
{
    public partial class FormMCCL00432 :FormMCCL0043
    {
        public FormMCCL00432()
        {
            InitializeComponent();
            _cls = new clsProjectDispatchTaskmange(1);
        }

        private void FormMCCL00432_Load(object sender, EventArgs e)
        {
            this.Head.DataSource = _cls.getHead();
        }

        private void HeadGridView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            long vheadid = 0;
            vheadid = Convert.ToInt64(this.HeadGridView.GetRowCellValue(e.RowHandle, "FID"));
            this.BodyIndex.DataSource = _cls.getBodyIndex(vheadid);
        }

        private void BodyIndexView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            long vprojectheadid, fdodepartid = 0;
            vprojectheadid = Convert.ToInt64(this.BodyIndexView.GetRowCellValue(e.RowHandle, "FDispatchHeadID"));
            fdodepartid = Convert.ToInt64(this.BodyIndexView.GetRowCellValue(e.RowHandle, "FOPDEPARTID"));
            this.BodyList.DataSource = _cls.getBodyList(vprojectheadid, fdodepartid);
        }

        private void repositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            int rindex = 0;
            rindex = this.HeadGridView.FocusedRowHandle;
            if (rindex < 0)
                return;
            long fid = Convert.ToInt64(this.HeadGridView.GetRowCellValue(rindex, "FID")); ;//this.dataGrid.SelectedRows[0].Cells["CFID"].Value);
            FormMCCL0006 frm = new FormMCCL0006();
            frm._HeadID = fid;
            frm.ShowDialog(this);
        }
    }
}
