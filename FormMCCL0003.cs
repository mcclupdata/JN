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
    public partial class FormMCCL0003 : Formbase
    {
        clsBatchInputweldinfos _cls;
        public FormMCCL0003()
        {
            InitializeComponent();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormMCCL0003_Load(object sender, EventArgs e)
        {
            Formbase frm = this;
            _cls = new clsBatchInputweldinfos(ref frm);
            
            this.EF_DO_F1 += new EFButtonBar.EFDoFnEventHandler(FormMCCL0003_EF_DO_F1);
            this.EF_DO_F2 += new EFButtonBar.EFDoFnEventHandler(FormMCCL0003_EF_DO_F2);
            this.EF_DO_F3 += new EFButtonBar.EFDoFnEventHandler(FormMCCL0003_EF_DO_F3);
        }

        void FormMCCL0003_EF_DO_F3(object sender, EF_Args e)
        {
            //throw new NotImplementedException();
            _cls.butOK_Click(null, null);
        }

        void FormMCCL0003_EF_DO_F2(object sender, EF_Args e)
        {
            //throw new NotImplementedException();
            _cls.butRead_Click(null, null);
        }

        void FormMCCL0003_EF_DO_F1(object sender, EF_Args e)
        {
            //throw new NotImplementedException();
            _cls.but_ChooseFile_Click(null,null);
        }
    }
}
