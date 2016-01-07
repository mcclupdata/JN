using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MC
{
    public partial class FormMCCL0042 : MC.Formbase
    {
        clsWeldWeldingAdpatEdit clsedit = new clsWeldWeldingAdpatEdit();
        public FormMCCL0042()
        {
            InitializeComponent();
        }

        private void FormMCCL0042_Load(object sender, EventArgs e)
        {
            this.dataGrid.DataSource = clsedit.getWeldWeldingClass();

        }

        private void but_OK_Click(object sender, EventArgs e)
        {
            DataTable dt=(DataTable) this.dataGrid.DataSource;

            dt = clsedit.UpdateWeldWeldingClass(dt);
        }
    }
}
