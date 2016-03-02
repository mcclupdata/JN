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
    public partial class FormMCCL00014 : Formbase
    {
        public FormMCCL00014()
        {
            InitializeComponent();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGrid_Click(object sender, EventArgs e)
        {

        }

        private void efLabel2_Click(object sender, EventArgs e)
        {

        }

        private void butSeachin_Click(object sender, EventArgs e)
        {
            String str_Field = "";
            String str_Cont = "";
            String str_Val = "";
            if (this.cbbField.SelectedIndex < 0)
                return;
            String str = this.cbbField.Text;
            String[] strg = str.Split('|');
            int k = Convert.ToInt32(strg[0]);
            DevExpress.XtraGrid.Views.Grid.GridView dgv = (DevExpress.XtraGrid.Views.Grid.GridView)this.dataGrid.Views[0];

            str_Field = dgv.Columns[k].FieldName;
            if (this.cbbCondition.SelectedIndex < 0)
                return;
            str_Cont = this.cbbCondition.Text;

            if (this.txtValue.Text.Trim().Length == 0)
                return;
            String rst = "";
            str_Val = this.txtValue.Text;
            str_Val = str_Val.Replace('*', '%');
            if (str_Cont == "like")
            {
                rst = str_Field + " " + str_Cont + " " + "'" + str_Val + "'";
            }
            else
            {
                rst = str_Field + str_Cont + this.txtValue.Text;
            }

            try
            {
                DataView dv = ((DataTable)this.dataGrid.DataSource).DefaultView;
                dv.RowFilter = rst;

            }
            catch (Exception ex) { MessageBox.Show(this, ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }


            return;

        }

        private void butreturn_Click(object sender, EventArgs e)
        {
            DataView dv = ((DataTable)this.dataGrid.DataSource).DefaultView;
            dv.RowFilter = "";
        }

        private void efButton1_Click(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView dgv = (DevExpress.XtraGrid.Views.Grid.GridView)this.dataGrid.Views[0];
            dgv.SelectAll();
            for (int i = 0; i < dgv.RowCount; i++)
            {
                Byte bi = Convert.ToByte(dgv.GetRowCellValue(i, "FChecked"));// (this.dataGrid.Rows[i].Cells["CFChecked"].Value);
                //this.dataGrid.Rows[i].Cells["CFChecked"].Value = 1;
                bi ^= 1;
                dgv.SetRowCellValue(i, "FChecked", Convert.ToInt32(bi));
                dgv.FocusedRowHandle = i;
                
            }
            dgv.SetFocusedRowModified();
           
        }
        //F1 内部搜索
        private void FormMCCL00014_EF_DO_F1(object sender, EF_Args e)
        {
            butSeachin_Click(this.butSeachin, null);
        }
        //F2 还原
        private void FormMCCL00014_EF_DO_F2(object sender, EF_Args e)
        {
            butreturn_Click(this.butreturn, null);

        }
        //F3 全选
        private void FormMCCL00014_EF_DO_F3(object sender, EF_Args e)
        {
            efButton1_Click(this.butSelectAll, null);
        }

        private void view_ColumnFilterChanged(object sender, EventArgs e)
        {
            
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
       

    }
}
