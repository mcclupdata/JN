using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MC
{
    public partial class FormMCCL00039 : MC.Formbase
    {
        private clsweldingclass cls = new clsweldingclass();
        public FormMCCL00039()
        {
            InitializeComponent();
        }

        private void FormMCCL00039_Load(object sender, EventArgs e)
        {
           // this.gridView.OptionsView.ColumnAutoWidth = true;
            this.dataGrid.DataSource = cls.Loadweldingclass();
        }

        private void butUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "确定更新?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataTable data = (DataTable)this.dataGrid.DataSource;
                cls.Updateweldingclass(data);
                this.dataGrid.DataSource = cls.Loadweldingclass();
            }
        }
    }
}
