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
    public partial class FormMCCL00024 : EF.EFForm
    {
        clsBatchinputwelder _cls;
        public FormMCCL00024()
        {
            InitializeComponent();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGrid_Click(object sender, EventArgs e)
        {

        }

        private void FormMCCL00011_Load(object sender, EventArgs e)
        {
            //EFForm frm = this;
            //_cls = new clsBatchinputwelder(ref frm);
            //this.EF_DO_F1 += new EFButtonBar.EFDoFnEventHandler(FormMCCL00011_EF_DO_F1);

        }
        #region  F2查询
        void FormMCCL00011_EF_DO_F1(object sender, EF_Args e)
        {
            //throw new NotImplementedException();
            //this.but_ChooseFile
            MessageBox.Show("F1");
        }
        #endregion
    }
}
