using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using EI;
using EF;
namespace MC
{
    class clswpsEdit : clsFrmBase
    {
        String contr_dataGrid_wps = "dataGrid_WPS";
        String contr_dataGrid_wpssub = "dataGrid_WPSSub";
        String contr_tabdataGrid = "tabdataGrid";
        String contr_but_Delete = "butDelete";
        String contr_but_Cancel = "butCancel";
        int cmd_WPSEdit_Load_WPS = 57051;//加载WPS
        int cmd_WPSEdit_Load_WPSSub = 57052;//加载WPSSub
        int cmd_WPSEdit_Delete = 57053;
        DataTable _dt_wpssub;
        public DataTable _dt_shipno;
        public void Load()
        {
            DataTable dt_wps = _Client.ServiceCall(cmd_WPSEdit_Load_WPS, null);
            _dt_wpssub = _Client.ServiceCall(cmd_WPSEdit_Load_WPSSub, null);

            _dt_shipno = dt_wps.DefaultView.ToTable(true, "FSHIP_NO");
            _dt_shipno.Rows.Add("*");
            _dt_shipno.DefaultView.Sort = "FSHIP_NO";
            Control cl = FindControl(contr_dataGrid_wps);
            //((DataGridView)cl).AutoGenerateColumns = true;
            //((DataGridView)cl).AllowUserToAddRows = false;
            //((DataGridView)cl).ReadOnly = false;
            DataRow dr = dt_wps.Rows[0];
            dt_wps.AcceptChanges();
            _dt_wpssub.AcceptChanges();
            dr = dt_wps.Rows[0];
            ((EFDevGrid)cl).DataSource = dt_wps;
          

            DevExpress.XtraGrid.Views.Grid.GridView wpsview = (DevExpress.XtraGrid.Views.Grid.GridView)((EFDevGrid)cl).Views[0];
            
            
           // wpsview.PopulateColumns();
            wpsview.Columns["FID"].Visible = false;
            //cl = FindControl(contr_dataGrid_wpssub);
            //((DataGridView)cl).AutoGenerateColumns = true;
            //((DataGridView)cl).AllowUserToAddRows = false;
            //((EFDevGrid)cl).ReadOnly = true;
        }
        public clswpsEdit(ref Formbase frm)
        {
            _frm = frm;
            Load();
            Control cl = FindControl(contr_dataGrid_wps);
            DevExpress.XtraGrid.Views.Grid.GridView view=(DevExpress.XtraGrid.Views.Grid.GridView)((EF.EFDevGrid)cl).Views[0];
            //((EF.EFDevGrid)cl).Views[0]. .CellDoubleClick += clswpsEdit_CellDoubleClick;
            view.RowClick+= clswpsEdit_CellDoubleClick;
            
            cl = FindControl(contr_but_Delete);
            ((EFButton)cl).Click += clswpsEdit_Delete_Click;
            cl = FindControl(contr_but_Cancel);
            ((EFButton)cl).Click += clswpsEdit_Update;

        }

    
        public void clswpsEdit_Cancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(_frm, "确定退出？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _frm.Close();
                
            }
        }
        /// <summary>
        /// 2015-10-15 修订
        /// 获取更新数据并提交给数据库；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void clswpsEdit_Update(Object sender, EventArgs e)
        {
            //提取WPS数据
            if (MessageBox.Show(_frm, "是否确定更新？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.No)
                return;
            ((EF.EFDevGrid)FindControl(contr_dataGrid_wps)).Update();
            DataTable dt_wps =(DataTable) ((EF.EFDevGrid)FindControl(contr_dataGrid_wps)).DataSource;
            DataTable sdt_wps = dt_wps.GetChanges(DataRowState.Modified);//dt_wps.Clone();
            //for (int k = 0; k < dt_wps.Rows.Count; k++)
            //{
            //    DataRow dr = dt_wps.Rows[k];
            //    if (dr.RowState == DataRowState.Modified)
            //    {
            //        sdt_wps.ImportRow(dr);
            //    }
            //}
            if (sdt_wps.Rows.Count > 0)
            {
               
               sdt_wps= _Client.ServiceCall(clsCMD.cmd_wpsedit_upwps, sdt_wps,0);
               MessageBox.Show(_frm, "主规程更新完成", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
               sdt_wps.Rows.Clear();
               sdt_wps.AcceptChanges();
            }
            
            sdt_wps = dt_wps.GetChanges(DataRowState.Added);

            if (sdt_wps!=null && sdt_wps.Rows.Count > 0)
            {

                sdt_wps = _Client.ServiceCall(clsCMD.cmd_wpsedit_upwps, sdt_wps, 1);
                MessageBox.Show(_frm, "主规程增加完成", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sdt_wps.Rows.Clear();
                sdt_wps.AcceptChanges();
            }
           
            sdt_wps = dt_wps.GetChanges(DataRowState.Deleted);

            if (sdt_wps != null && sdt_wps.Rows.Count > 0)
            {

                sdt_wps = _Client.ServiceCall(clsCMD.cmd_wpsedit_upwps, sdt_wps, 2);
                MessageBox.Show(_frm, "主规程删除完成", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            //提取subwps
            _dt_wpssub.DefaultView.RowFilter = "";
            DataTable sdt_subwps;//=_dt_wpssub.Clone();
            ((EF.EFDevGrid)FindControl(contr_dataGrid_wpssub)).Update();
            DataTable dt_subwps=(DataTable) ((EF.EFDevGrid)FindControl(contr_dataGrid_wpssub)).DataSource;
            if (dt_subwps == null)
                return;
            sdt_subwps = dt_subwps.GetChanges(DataRowState.Modified);
            if (sdt_subwps !=null && sdt_subwps.Rows.Count > 0)
            {
                sdt_subwps = _Client.ServiceCall(clsCMD.cmd_wpsedit_upwps_sub, sdt_subwps);
                MessageBox.Show(_frm, "子规程更新完成", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sdt_subwps.Rows.Clear();
                sdt_subwps.AcceptChanges();
            }
        
            sdt_subwps = dt_subwps.GetChanges(DataRowState.Added);
            if (sdt_subwps != null &&  sdt_subwps.Rows.Count > 0)
            {
                sdt_subwps = _Client.ServiceCall(clsCMD.cmd_wpsedit_upwps_sub, sdt_subwps);
                MessageBox.Show(_frm, "子规程增加完成", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sdt_subwps.Rows.Clear();
                sdt_subwps.AcceptChanges();
            }

            sdt_subwps = dt_subwps.GetChanges(DataRowState.Deleted);
            if (sdt_subwps != null &&  sdt_subwps.Rows.Count > 0)
            {
                sdt_subwps = _Client.ServiceCall(clsCMD.cmd_wpsedit_upwps_sub, sdt_subwps);
                MessageBox.Show(_frm, "子规程删除完成", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            Load();
        }

        /// <summary>
        /// 执行删除任务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void clswpsEdit_Delete_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            Control cl = FindControl(contr_dataGrid_wps);

            EFDevGrid dgv = (EFDevGrid)cl;
            DevExpress.XtraGrid.Views.Grid.GridView efGridView = (DevExpress.XtraGrid.Views.Grid.GridView)dgv.Views[0];
            
            int rindex = efGridView.FocusedRowHandle;
            if (rindex < 0)
            {
                MessageBox.Show(_frm, "请选择要删除的WPS", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
  
            //dgv.Update();
            DataTable dt = ((DataTable)dgv.DataSource).Clone() ;
            if (dt == null)
            {
                MessageBox.Show(_frm, "没有数据用于删除", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataRow row = dt.NewRow();
            row["RuleNum"] = efGridView.GetRowCellValue(rindex, "RuleNum");
            dt.Rows.Add(row);
            //DataView dv = dt.Copy().DefaultView;
            //dv.RowFilter = "FSelected=1";
           // DataTable rdt = dv.ToTable();
            if (dt.Rows.Count > 0)
            {
                if (MessageBox.Show(_frm, "确定删除？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //执行删除动作;
                    _Client.ServiceCall(cmd_WPSEdit_Delete, dt);
                    Load();
                }
            }
            else
            {
            }
        }

        public void clswpsEdit_CellDoubleClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView dgv = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            int rindex = e.RowHandle;
            String vRulenum = Convert.ToString(dgv.GetRowCellValue(rindex,"RuleNum")) ;//Convert.ToString( dgv.Rows[e.].Cells["CRuleNum"].Value);
            //DataView dv = _dt_wpssub.Copy().DefaultView;
            //dv.RowFilter = "RuleNum='" + dgv.GetRowCellValue(rindex,"RuleNum").ToString()+"'";//dgv.Rows[e.RowIndex].Cells["CRuleNum"].Value.ToString() + "'";
            _dt_wpssub.DefaultView.RowFilter = "RuleNum='" + dgv.GetRowCellValue(rindex, "RuleNum").ToString() + "'";

            Control cl = FindControl(contr_dataGrid_wpssub);
            ((EF.EFDevGrid)cl).DataSource = _dt_wpssub;// dv.ToTable();
            DevExpress.XtraGrid.Views.Grid.GridView wpsview = (DevExpress.XtraGrid.Views.Grid.GridView)((EFDevGrid)cl).Views[0];
           // wpsview.PopulateColumns();
            cl = FindControl("tabControl1");
            ((TabControl)cl).SelectTab("tabPage2");
            //throw new NotImplementedException();
        }
       
    }
}
