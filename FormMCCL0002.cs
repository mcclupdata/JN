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
    public partial class FormMCCL0002 : Formbase
    {
        clsBatchinputwps _cls;
        public FormMCCL0002()
        {
            InitializeComponent();
            
        }

        private void efGroupBox2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGrid_WPSSub_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void efDevGrid2_Click(object sender, EventArgs e)
        {

        }

        private void But_ChooseFile_Click(object sender, EventArgs e)
        {

        }

        private void FormMCCL0002_Load(object sender, EventArgs e)
        {
            Formbase frm = this;
            _cls = new clsBatchinputwps(ref frm);
            this.EF_DO_F1 += new EFButtonBar.EFDoFnEventHandler(FormMCCL0002_EF_DO_F1);
            this.EF_DO_F2 += new EFButtonBar.EFDoFnEventHandler(FormMCCL0002_EF_DO_F2);
            this.EF_DO_F3 += new EFButtonBar.EFDoFnEventHandler(FormMCCL0002_EF_DO_F3);
        }

        void FormMCCL0002_EF_DO_F3(object sender, EF_Args e)
        {
            //throw new NotImplementedException();
            this._cls.butOK_Click(null,null);
        }

        void FormMCCL0002_EF_DO_F2(object sender, EF_Args e)
        {
            //throw new NotImplementedException();
            this._cls.butRead_Click(null, null);
        }

        void FormMCCL0002_EF_DO_F1(object sender, EF_Args e)
        {
            //throw new NotImplementedException();
            this._cls.but_ChooseFile_Click(null,null);
        }

        private void efButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
