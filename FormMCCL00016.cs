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
namespace MC
{
    public partial class FormMCCL00016 : Formbase
    {
        clsProjectProcess _cls;
        public FormMCCL00016()
        {
            InitializeComponent();
            
        }

        private void FormMCCL00016_Load(object sender, EventArgs e)
        {
            Formbase frm = this;
            _cls = new clsProjectProcess(ref frm);
        }

        
    }
}
