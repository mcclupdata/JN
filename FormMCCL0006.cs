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
namespace MC
{
    public partial class FormMCCL0006 : Formbase
    {
        clsFirstDispatch _cls;
        public long _HeadID=0;
        public FormMCCL0006()
        {
            InitializeComponent();
            
        }

        private void dataGrid_Click(object sender, EventArgs e)
        {
            
        }

        private void FormMCCL0006_Load(object sender, EventArgs e)
        {
            Formbase frm = this;
            if (_HeadID == 0)
                _cls = new clsFirstDispatch(ref frm);
            else
                _cls = new clsFirstDispatch(_HeadID, ref frm);
            this.gridView2.OptionsView.ColumnAutoWidth = true;
            //MessageBox.Show(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            //String s = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            //String[] gs=s.Split('/');
            //String n = "";
            //for (int i = 3; i < gs.Length - 1; i++)
            //{
            //    n+=gs[i]+"/";
            //}
            //MessageBox.Show(n);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void efGroupBox1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void FDispatchSTARTTIME_ValueChanged(object sender, EventArgs e)
        {

        }

        private void efDevGrid1_Click(object sender, EventArgs e)
        {

        }

        private void efDevGrid1_Click_1(object sender, EventArgs e)
        {

        }
        //删除按钮
        private void ItemButton_del_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //DevExpress.XtraGrid.Views.Grid.GridView v=this.dataGrid.Views[0];
            //_cls.clsFirstDispatch_CellContentClick(sender, e);
           
        }

        private void butAdd_Click(object sender, EventArgs e)
        {

        }

     
    }
}
