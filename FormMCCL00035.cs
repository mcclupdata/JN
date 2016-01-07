using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace MC
{
    public partial class FormMCCL00035 : MC.Formbase
    {
        public FormMCCL00035()
        {
            InitializeComponent();
            this.dataGrid.EF_GridBar_Remove_Event += this.dataGrid_EF_GridBar_Remove_Event;
        }
        
        
        protected void vLoad()
        {
            //加载焊接登记表信息
            DataTable dt= _wcfClient.ServiceCall(clsCMD.cmd_welderedit_getweldModesTable, null);
            dt.AcceptChanges();
            this.dataGrid.DataSource = dt;
            this.CleanDelData();
            


        }

        private void but_OK_Click(object sender, EventArgs e)
        {
            //提交保存数据
            //提交增加数据
            if (MessageBox.Show(this, "是否提交数据？", "消息", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                DataTable dt = (DataTable)this.dataGrid.DataSource;
                DataTable data;//= dt.GetChanges(DataRowState.Added);
                DataTable rdt;
                data = dt.GetChanges(DataRowState.Added);
                if (data != null && data.Rows.Count > 0)
                {
                    rdt = _wcfClient.ServiceCall(clsCMD.cmd_welderedit_UpdateweldModesTable, data, 1);
                }
                //修改数据
                data = dt.GetChanges(DataRowState.Modified);
                if (data != null && data.Rows.Count > 0)
                {
                    rdt = _wcfClient.ServiceCall(clsCMD.cmd_welderedit_UpdateweldModesTable, data, 0);
                }
                //删除
               // data = dt.GetChanges(DataRowState.Deleted);
                //data.AcceptChanges();
                data = getDelData(this.dataGrid.Name);

                if (data != null && data.Rows.Count > 0)
                {
                    
                   rdt = _wcfClient.ServiceCall(clsCMD.cmd_welderedit_UpdateweldModesTable, data, 2);
                   data.Rows.Clear();
                   
                }

                vLoad();
            }

        }

        private void FormMCCL00035_Load(object sender, EventArgs e)
        {
            vLoad();
        }

    
    }
}
