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
    public partial class FormMCCL00013 : Formbase
    {
        clsBatchInputweldinfos _cls;
        public FormMCCL00013()
        {
            InitializeComponent();
            
        }

       

        private void FormMCCL00013_Load(object sender, EventArgs e)
        {
            Formbase frm = this;
            _cls = new clsBatchInputweldinfos(ref frm);
        }

        private void but_ChooseFile_Click(object sender, EventArgs e)
        {

        }

        private void butRead_Click(object sender, EventArgs e)
        {

        }
    }
}
