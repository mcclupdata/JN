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
    public partial class FormMCCL0004 : Formbase
    {
        clswpsEdit _cls;
        public FormMCCL0004()
        {
            InitializeComponent();
            
        }

        private void efGroupBox1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormMCCL0004_Load(object sender, EventArgs e)
        {
            Formbase frm = this;
            _cls = new clswpsEdit(ref frm);
            this.luSHIPNO.Properties.DataSource = _cls._dt_shipno;
            this.luSHIPNO.Properties.DisplayMember = "FSHIP_NO";
            this.luSHIPNO.Properties.ValueMember = "FSHIP_NO";
           // _cls.Load();
            //this.EF_DO_F1 += new EFButtonBar.EFDoFnEventHandler(FormMCCL0004_EF_DO_F1);
            //this.EF_DO_F2 += new EFButtonBar.EFDoFnEventHandler(FormMCCL0004_EF_DO_F2);

        }
        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void FormMCCL0004_EF_DO_F2(object sender, EF_Args e)
        {
            //throw new NotImplementedException();
            _cls.clswpsEdit_Cancel_Click(null, null);
        }
        
        //删除；
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void FormMCCL0004_EF_DO_F1(object sender, EF_Args e)
        {
            //throw new NotImplementedException();
            _cls.clswpsEdit_Delete_Click(null, null);
        }
        /// <summary>
        /// 2015 10 15 修订：增加更新功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butCancel_Click(object sender, EventArgs e)
        {
            

        }

        private void dataGrid_WPS_BindingContextChanged(object sender, EventArgs e)
        {
            int i = 0;
        }

        private void luSHIPNO_EditValueChanged(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)this.dataGrid_WPS.DataSource;
            if (this.luSHIPNO.EditValue.ToString() == "*")
            {
                dt.DefaultView.RowFilter = "";
            }
            else
            {
                dt.DefaultView.RowFilter = "FSHIP_NO='" + this.luSHIPNO.EditValue.ToString() + "'";

            }
        }
    }
}
