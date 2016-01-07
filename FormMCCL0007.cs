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
    public partial class FormMCCL0007 : Formbase
    {
        public FormMCCL0007()
        {
            InitializeComponent();
            
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
            str_Field = this.gridview.Columns[k].FieldName;
           
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
            ((DataTable)this.dataGrid.DataSource).DefaultView.RowFilter = "";
        }

        private void butSelectAll_Click(object sender, EventArgs e)
        {
            
            for (int i = 0; i < this.gridview.RowCount; i++)
            {
                //DataRow r =(DataRow) gridview.GetRow(i);
                Byte bi = Convert.ToByte(gridview.GetRowCellValue(i, "FTasked"));
                //this.dataGrid.Rows[i].Cells["CFChecked"].Value = 1;
                bi ^= 1;
               // r["FTasked"] = Convert.ToInt32(bi);
                gridview.SetRowCellValue(i, "FTasked", bi);
                gridview.FocusedRowHandle = i;
            }
            gridview.SetFocusedRowModified();
        }

        private void FormMCCL0007_Load(object sender, EventArgs e)
        {
            //for (int i = 0; i < this.gridview.Columns.Count; i++)
            //{
            //    this.cbbField.Items.Add(i + "|" + this.gridview.Columns[i].Caption);
            //}
            //this.cbbCondition.SelectedIndex = 0;
        }
        //F1==搜索
        private void FormMCCL0007_EF_DO_F1(object sender, EF_Args e)
        {
            butSeachin_Click(this.butSeachin, null);
        }
        //F3==全选
        private void FormMCCL0007_EF_DO_F3(object sender, EF_Args e)
        {
            butSelectAll_Click(this.butSelectAll, null);
        }
        //F2==还原
        private void FormMCCL0007_EF_DO_F2(object sender, EF_Args e)
        {
            butreturn_Click(butreturn, null);

        }
    }
}
