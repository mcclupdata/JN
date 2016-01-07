using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MC
{
    public partial class FormMCCL00034 : MC.Formbase
    {
        _MyClient _Client = new _MyClient();
        DataTable _dt_welderClass=null;
        public FormMCCL00034()
        {
            InitializeComponent();
            dataGrid.EF_GridBar_Remove_Event += this.dataGrid_EF_GridBar_Remove_Event;
            dataGrid2.EF_GridBar_Remove_Event += this.dataGrid_EF_GridBar_Remove_Event;
        }

        private void FormMCCL00034_Load(object sender, EventArgs e)
        {
            //加载部门
            DataTable depart_dt = _Client.ServiceCall(clsCMD.cmd_welderedit_getwelderdepart, null);
            this.FDepartLookUpEdit.DataSource = depart_dt;
            this.DepartList.Properties.DataSource = depart_dt;
            
            //Lib
            DataTable libs_dt = _Client.ServiceCall(clsCMD.cmd_welderedit_getLibs, null);
            this.FlibLookUpEdit.DataSource = libs_dt;
            //Load welders
            DataTable welders_dt = _Client.ServiceCall(clsCMD.cmd_welderedit_getwelders, null);
            welders_dt.AcceptChanges();
            if (welders_dt.Rows[1].RowState == DataRowState.Modified)
            {
            }
            this.dataGrid.DataSource = welders_dt;
            DataTable state_dt = new DataTable();
            DataColumn col;
            col = new DataColumn(); col.ColumnName = "FName"; col.DataType = typeof(String); col.MaxLength = 10; state_dt.Columns.Add(col);
            col = new DataColumn(); col.ColumnName = "FID"; col.DataType = typeof(int);  state_dt.Columns.Add(col);
            DataRow ndr = state_dt.NewRow();
            ndr[0] = "Normal"; ndr[1] = 0; state_dt.Rows.Add(ndr);
            ndr = state_dt.NewRow();
            ndr[0] = "Exception"; ndr[1] = 1; state_dt.Rows.Add(ndr);
            FStateItemLookUpEdit1.DataSource = state_dt;
            //控制Page
            
            this.Tabs.SelectedTabPage = this.welderPage;
            this.classPage.PageVisible = false;
           
            //load weldersclass
            _dt_welderClass = _Client.ServiceCall(clsCMD.cmd_welderedit_getwelderClass, null);
            _dt_welderClass.AcceptChanges();
            this.dataGrid2.DataSource = _dt_welderClass;
            //bing class
            DataTable dt_class = _Client.ServiceCall(clsCMD.cmd_welderedit_get_weldClass, null);
            this.ClassLookUpEdit.DataSource = dt_class;
            this.CleanDelData();

            
        }

        private void DepartList_EditValueChanged(object sender, EventArgs e)
        {
            ((DataTable)this.dataGrid.DataSource).DefaultView.RowFilter = "Fdepart=" + DepartList.EditValue;
        }

        private void leveButton_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //MessageBox.Show("OK");
            //查看或编辑焊工等级
            long vwelderFID = 0;
            int rindex = this.View.FocusedRowHandle;
            if (Convert.IsDBNull(this.View.GetRowCellValue(rindex, "FID")) == true)
            {
                MessageBox.Show("焊工尚未保存，请保存后处理");
                return;
            }
            vwelderFID =Convert.ToInt64(this.View.GetRowCellValue(rindex, "FID"));
            _dt_welderClass.DefaultView.RowFilter = "FWELDERID=" + vwelderFID;
            DataTable vdt = _dt_welderClass.DefaultView.ToTable();
            if (vdt.Rows.Count == 0)
            {
                DataRow nr=_dt_welderClass.NewRow();
                nr["FID"] = -1;
                nr["FWELDERID"] = vwelderFID;
                nr["FWELDLEVENID"] =0;

                _dt_welderClass.Rows.Add(nr);
            }
            _dt_welderClass.DefaultView.RowFilter = "FWELDERID=" + vwelderFID;
            this.dataGrid2.Update();
            //this.classPage.Parent=this.Tabs;
            this.welderPage.PageVisible=false;
            this.classPage.PageVisible = true;
            this.Tabs.SelectedTabPage = this.classPage;
        }

        private void dataGrid2_EF_GridBar_AddRow_Event(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            //增加新等级
            DataTable dt = (DataTable)this.dataGrid2.DataSource;
            DataRow nr = dt.NewRow();
            long vwelderFID = 0;
            int rindex = this.View.FocusedRowHandle;
            vwelderFID =Convert.ToInt64( this.View.GetRowCellValue(rindex, "FID"));
            nr["FID"] = 0;
            nr["FWELDERID"] = vwelderFID;
            ((DataTable)this.dataGrid2.DataSource).Rows.Add(nr);
        }

        private void but_Ret_Click(object sender, EventArgs e)
        {
           
            DataTable vdt= _dt_welderClass.DefaultView.ToTable();
            if (vdt.Rows.Count > 0)
            {
                for (int i = 0; i < vdt.Rows.Count; i++)
                {
                    if (Convert.ToInt32(vdt.Rows[i]["FWELDLEVENID"]) == 0)
                    {
                        MessageBox.Show("焊工等级未确定");
                        return;
                    }
                }
            }
            this.classPage.PageVisible = false;
            this.welderPage.PageVisible = true;
            this.Tabs.SelectedTabPage = this.welderPage;

        }

        private void efButton1_Click(object sender, EventArgs e)
        {
            //提交保存数据
            //提交焊工数据
            if (MessageBox.Show(this, "是否提交数据?", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                DataTable dt_welders = (DataTable)this.dataGrid.DataSource;

                DataTable vdt = dt_welders.GetChanges(DataRowState.Modified);

                if (vdt != null && vdt.Rows.Count > 0)
                {
                    _Client.ServiceCall(clsCMD.cmd_welderedit_UpdateWelders, vdt,0);
                }

                vdt = dt_welders.GetChanges(DataRowState.Added);

                if (vdt != null && vdt.Rows.Count > 0)
                {
                    _Client.ServiceCall(clsCMD.cmd_welderedit_UpdateWelders, vdt, 1);
                }
                //vdt = dt_welders.GetChanges(DataRowState.Deleted);
                vdt = getDelData(this.dataGrid.Name);
                if (vdt != null && vdt.Rows.Count > 0)
                {
                    _Client.ServiceCall(clsCMD.cmd_welderedit_UpdateWelders, vdt, 2);
                }






                DataTable dt_weldersClass = (DataTable)this.dataGrid2.DataSource;

                vdt = dt_weldersClass.GetChanges(DataRowState.Modified);

                if (vdt != null && vdt.Rows.Count > 0)
                {
                    _Client.ServiceCall(clsCMD.cmd_welderedit_UpdateWelderClass, vdt, 0);
                }
                vdt = dt_weldersClass.GetChanges(DataRowState.Added);

                if (vdt != null && vdt.Rows.Count > 0)
                {
                    _Client.ServiceCall(clsCMD.cmd_welderedit_UpdateWelderClass, vdt, 1);
                }

                //vdt = dt_weldersClass.GetChanges(DataRowState.Deleted);
                vdt = this.getDelData(this.dataGrid2.Name);
                if (vdt != null && vdt.Rows.Count > 0)
                {
                    _Client.ServiceCall(clsCMD.cmd_welderedit_UpdateWelderClass, vdt, 2);
                }


                
                MessageBox.Show(this, "提交数据保存成功", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FormMCCL00034_Load(null, null);
            }
            else
            {
                return;
            }
            //提交焊工等级及信息
        }
    }
}
