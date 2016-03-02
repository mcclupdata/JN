using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MC
{
    public partial class FormMCCL00036 : MC.Formbase
    {
        public FormMCCL00036()
        {
            InitializeComponent();
            //注册删除时间
            this.dataGrid.EF_GridBar_Remove_Event+=this.dataGrid_EF_GridBar_Remove_Event;
        }
        /// <summary>
        /// 准备数据
        /// </summary>
        /// <returns></returns>
        protected Boolean vLoad()
        {

            //准备数据
            //加载船型
            DataTable dt_shipmod = _wcfClient.ServiceCall(clsCMD.cmd_welderedit_getSHIP_MOD, null);
            this.LookUp_SM.Properties.DataSource = dt_shipmod;
            //加载所有焊缝数据
            DataTable dt_welds = _wcfClient.ServiceCall(clsCMD.cmd_welderedit_getWeldTable, null);
            dt_welds.AcceptChanges();

            this.dataGrid.DataSource = dt_welds;
           // this.dataGrid.b
            this.ItemLookUp_SHIPMOD.DataSource = dt_shipmod;
            //this.View.PopulateColumns(dt_welds);
            this.View.Columns["SHIP_MOD"].ColumnEdit = this.ItemLookUp_SHIPMOD;
            this.View.Columns["FID"].Visible=true;
            return false;
        }
        /// <summary>
        /// 讲修改数据保存到数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_OK_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "是否提交数据?", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                DataTable dt_welds = (DataTable)this.dataGrid.DataSource;

                DataTable vdt = dt_welds.GetChanges(DataRowState.Modified);

                if (vdt != null && vdt.Rows.Count > 0)
                {
                    _wcfClient.ServiceCall(clsCMD.cmd_welderedit_Updateweldtable, vdt, 0);
                    MessageBox.Show(this, "变更数据提交完成", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                vdt = dt_welds.GetChanges(DataRowState.Added);

                if (vdt != null && vdt.Rows.Count > 0)
                {
                    _wcfClient.ServiceCall(clsCMD.cmd_welderedit_Updateweldtable, vdt, 1);
                    MessageBox.Show(this, "新增数据完成", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                //vdt = dt_welders.GetChanges(DataRowState.Deleted);
                vdt = getDelData(this.dataGrid.Name);
                if (vdt != null && vdt.Rows.Count > 0)
                {
                    _wcfClient.ServiceCall(clsCMD.cmd_welderedit_Updateweldtable, vdt, 2);
                    MessageBox.Show(this, "删除数据完成", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                vLoad();
            }
        }

        private void LookUp_SM_EditValueChanged(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dataGrid.DataSource;
            object ss = this.LookUp_SM.EditValue;
            long ship_mod_id=Convert.ToInt64(this.LookUp_SM.EditValue);
            dt.DefaultView.RowFilter = "SHIP_MOD=" + ship_mod_id;
           // dataGrid.Update;
        }

        private void FormMCCL00036_Load(object sender, EventArgs e)
        {
            vLoad();
        }

    }
}
