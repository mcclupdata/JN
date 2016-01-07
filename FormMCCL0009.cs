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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraExport;
using DevExpress.XtraEditors;
namespace MC
{
    public partial class FormMCCL0009 : Formbase
    {
        clsProjectProcess _cls;
        public long _ProjectHeadID=0;
        public FormMCCL0009()
        {
            InitializeComponent();
            
        }


        private void FormMCCL0009_Load(object sender, EventArgs e)
        {
            Formbase frm = this;
            if (_ProjectHeadID == 0)
                _cls = new clsProjectProcess(ref frm);
            else
                _cls = new clsProjectProcess(_ProjectHeadID,ref frm);
           
        }

        private void but_Del_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
           //GridView g=(GridView)this.dataGrid.Views[0];

           // int r=g.FocusedRowHandle;//((DevExpress.XtraGrid.Views.Grid)this.dataGrid.Views[0])
           // g.FocusedColumn.ColumnEditName
           // MessageBox.Show("object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e");
        }

        private void butAdd_Click(object sender, EventArgs e)
        {

        }

        private void FormMCCL0009_EF_DO_F1(object sender, EF_Args e)
        {
            butAdd_Click(null, null);
        }

        //private void but_Del_Click(object sender, EventArgs e)
        //{
        //    int r = this.gridView1.FocusedRowHandle;


        //    MessageBox.Show("object sender, EvenArge e");
        //}

       
    }
}
