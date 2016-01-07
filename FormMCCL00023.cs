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
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
namespace MC
{
    public partial class FormMCCL00023 : Formbase
    {
        DataTable _data;
        clsfrmData clsfrm = new clsfrmData();
        public FormMCCL00023(DataTable vdata)
        {
            InitializeComponent();
            _data = vdata;
            Formbase frm = (Formbase)this;
            clsfrm.FillfrmData2(_data, ref frm, "");
            this.dataGrid.DataSource = _data;
        }
        private void butOK_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "是否确定开始该任务？", "请确认", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
            else
            {
                return;
            }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "是否确定取消该任务？", "请确认", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
    }
}
