using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections;
using System.Globalization;
using EI;
using EF;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;

namespace MC
{
    class clsProjectChooseWeldRule:clsFrmBase
    {
        String _colbutAdd = "butAdd";
        String _colbutOK = "butOK";
        String _colbutCancel = "but_ChooseFile";
        String _colexcelGrid = "dataGrid";
        String _colrstGrid = "dataGrid";
        String _col = "txtFileName";
        String _grid_FDoDepartID = "CFDoDepartID";
        String _grid_WeldWPS = "CCRuleNum";
        String _grid_del = "CButDelete";
        String _grid_RuleNum = "CRuleNum";
        String _grid_RuleFID = "CRuleFID";
        String _col_RuleTrunn = "dataGrid_RuleTrunn";

        String cmb_SHIP_NO = "cmbSHIP_NO";
        String cmb_TREE_NAMe = "cmbTREE_NAME";
        //----------------------------
        String txtFProcessnum = "FProcessnum";



        DataTable _Weld;
        DataTable _WeldRule;
        DataTable _WeldTrunn;
        DataTable _DoDepartID;

        int cmd_submit = 1004;//提交表单命令
        int cmd_ship_no = 1005;//查询得到可以分配的工程号;
        int cmd_wps = 1006;//查询得到可以匹配使用的wps
        int cmd_depart = 1007;//查询得到可以承接的部门；
        int cmd_Empty_Head = 1008;//查询得到空的表头数据;
        int cmd_Empty_body = 1009;//查询得到空表体数据；
        int cmd_Empty_DoDepartID = 1010;//查询得到部门数据；
        int cmd_SHIP_NO_TREE_NAME_WELD = 1011;//查询的到工程号，分段号所在的所有焊缝信息;
        int cmd_GetWPS_BYFILTER = 1012;//通过查询条件得到WPS数据；
        int cmd_GetWPSTrun = 1013;//通过WPS规程编号得到焊道信息；


        String _filter_GRADE1 = "";
        String _filter_GRADE2 = "";
        String _Filter_WELD_TYPE = "";
        String _filter_THICK1 = "";
        String _filter_THICK2 = "";
        String _filter_WELD2_CODE = "";
        String _filter_WELD_MOD = "";

        //--------------------------------------------独有变量
        public String _choosedRuleNum = "";
        public long _choosedRuleFID = 0;
        protected DataRow _row;
        /// <summary>
        /// 获取配置好的WPS
        /// </summary>
        /// <returns></returns>
        //public DataTable get_WeldDT()
        //{
        //    return _Weld;
        //}
        ///// <summary>
        ///// 设定需要配置的WPS
        ///// </summary>
        ///// <param name="value"></param>
        //public void set_WeldDT(DataTable value)
        //{
        //    _Weld = value;
        //}
        public clsProjectChooseWeldRule(DataRow row,Formbase param)
        {
            FormMCCL00020 frm = new FormMCCL00020();
            _frm = frm;
            _row = row;
            Initcls();
            if (_frm.ShowDialog(param) == DialogResult.OK)
            {

            }
           
        }
        String _ship_NO = "";
        public clsProjectChooseWeldRule(DataRow row, Formbase param,String shipno)
        {
            FormMCCL00020 frm = new FormMCCL00020();
            _frm = frm;
            _row = row;
            _ship_NO = shipno;
            Initcls();
            if (_frm.ShowDialog(param) == DialogResult.OK)
            {

            }

        }
        protected bool Initcls()
        {
            
            //注册butOK事件
            EFButton butok = (EFButton)FindControl("butOK");
            int allWPS=0;
            //butok.Click += butok_Click;
            //通过过滤得到WPS数据
            try
            {
                _filter_GRADE1 = (String)_row["GRADE1"];
                _filter_GRADE2 = Convert.IsDBNull(_row["GRADE2"]) == false ? "" : _row["GRADE2"].ToString();
                _filter_THICK1 = (String)_row["THICK1"].ToString();
                _filter_THICK2 = (String)_row["THICK2"].ToString();
                _filter_WELD_MOD = (String)_row["WELD_MOD"].ToString();
                _Filter_WELD_TYPE = (String)_row["WELD_TYPE"].ToString();
                _filter_WELD2_CODE = (String)_row["WELD2_CODE"].ToString();
            }
            catch(Exception tex)
            {
                allWPS=1;
            }
          
            //构件DT传输参数;
            DataTable dt = new DataTable();
            DataColumn col = new DataColumn();
            col.ColumnName = "GRADE1";
            col.DataType = typeof(String);
            col.MaxLength = 50;
            dt.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = "GRADE2";
            col.DataType = typeof(String);
            col.MaxLength = 50;
            dt.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = "THICK1";
            col.DataType = typeof(String);
            col.MaxLength = 50;
            dt.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = "THICK2";
            col.DataType = typeof(String);
            col.MaxLength = 50;
            dt.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = "WELD_MOD";
            col.DataType = typeof(String);
            col.MaxLength = 50;
            dt.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = "WELD_TYPE";
            col.DataType = typeof(String);
            col.MaxLength = 50;
            dt.Columns.Add(col);
            //CWELD2_CODE
            col = new DataColumn();
            col.ColumnName = "WELD2_CODE";
            col.DataType = typeof(String);
            col.MaxLength = 50;
            dt.Columns.Add(col);
            //CWELD_MOD
          


            DataRow drow = dt.NewRow();
            drow["GRADE1"] =  _filter_GRADE1;
            drow["GRADE2"] =  _filter_GRADE2;
            drow["THICK1"] =  _filter_THICK1; 
            drow["THICK2"] =  _filter_THICK2;
            drow["WELD_TYPE"] =_Filter_WELD_TYPE; 
            drow["WELD2_CODE"] = _filter_WELD2_CODE; 
            drow["WELD_MOD"] =_filter_WELD_MOD; 
            dt.Rows.Add(drow);
            //请求服务器
            EFDevGrid weldDT = (EFDevGrid)FindControl(_colrstGrid);
            GridView efV = (GridView)weldDT.Views[0];
            //WeldServiceReference.CompositeType sdata = new WeldServiceReference.CompositeType();
            //sdata.CmdCode = cmd_GetWPS_BYFILTER;
            //sdata.RowsCount = 2;
           
                //if (sdata.RowsCount > 0)
                //{
                    //sdata.weldDataTable = clsConvertXMLDataTable.ConvertDataTableToXML(dt);

                   // WeldServiceReference.CompositeType srst = _Client.ServiceCall(sdata);
                    //_Weld = clsConvertXMLDataTable.ConvertXMLToDataTable(srst.weldDataTable);
            _Weld = _Client.ServiceCall(cmd_GetWPS_BYFILTER, dt);
            if (allWPS==0)
            {
                if (_row.Table.Columns.IndexOf("SHIP_NO") < 0)
                {
                    _Weld.DefaultView.RowFilter = "FSHIP_NO='" + _ship_NO + "'";
                }
                else
                {
                    _Weld.DefaultView.RowFilter = "FSHIP_NO='" + _row["SHIP_NO"].ToString() + "'";
                }
            }
            weldDT.DataSource = _Weld;
            RepositoryItemButtonEdit but = (RepositoryItemButtonEdit)efV.Columns["but_Choose"].ColumnEdit;
            but.ButtonClick += weldDT_CellContentClick;

            
                    //weldDT.AutoGenerateColumns = false;
                    //注册点击事件查看焊道信息l
                    //weldDT.CellContentClick += weldDT_CellContentClick;
                //} 
           
           //注册选择按钮消息；
            //FormMCCL00020 vfrm = (FormMCCL00020)_frm;
            //vfrm.EF_DO_F1+=new EFButtonBar.EFDoFnEventHandler(vfrm_EF_DO_F1);
            
            return false;
        }
        public clsProjectChooseWeldRule(ref Formbase frm , DataRow row)
        {

            _frm = frm;
            _row = row;
            Initcls();
        }
        //点击选定按钮产生的事件；
        void butok_Click(object sender, EventArgs e)
        {
            EFDevGrid ef = (EFDevGrid)FindControl(_colrstGrid);

            GridView dgv = (GridView)ef.Views[0];// FindControl(_colrstGrid);
            if (dgv.SelectedRowsCount == 0)
            {
                MessageBox.Show("请选择需要的WPS");
                return;
            }
            else
            {
               // DataGridViewRow row = dgv.SelectedRows[0];
                int rindex = dgv.FocusedRowHandle;
                _choosedRuleFID = Convert.ToInt64(dgv.GetRowCellValue(rindex,"FID"));// row.Cells["CFID"].Value);
                _choosedRuleNum = dgv.GetRowCellValue(rindex, "RuleNum").ToString();//(String)row.Cells["CRuleNum"].Value;
                _frm.Close() ;
            }
            //throw new NotImplementedException();
        }
        //点击任意内容显示
        void weldDT_CellContentClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //DataGridView dgv=(DataGridView)sender;
            //DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e
            GridView dgv=(GridView)((EFDevGrid)FindControl("dataGrid")).Views[0];

            int rindex = dgv.FocusedRowHandle;

            if (rindex<0)
            {
                MessageBox.Show("请选择需要的WPS");
                return;
            }
            else
            {
                //dgv.GetFocusedRow()
                //DataRow row = dgv.Rows[e.RowIndex];

                _choosedRuleFID = Convert.ToInt64(dgv.GetRowCellValue(rindex,"FID"));//row.Cells["CFID"].Value);
                _choosedRuleNum = dgv.GetRowCellValue(rindex, "RuleNum").ToString();// (String)row.Cells["CRuleNum"].Value;
                _frm.DialogResult = DialogResult.OK;
                _frm.Close();
            }
            return;

            //if (dgv.Columns[e.ColumnIndex].Name == "CRuleTrunn")
            //{
            //    //得到WPS编号
            //    DataGridViewRow row=dgv.Rows[e.RowIndex];
            //    String RuleNum =(String)row.Cells[e.ColumnIndex].Value;
            //    DataTable dt = new DataTable();
            //    DataColumn col = new DataColumn();
            //    col.ColumnName = "FieldName";
            //    col.DataType = typeof(String);
            //    col.MaxLength = 50;
            //    dt.Columns.Add(col);
            //    col = new DataColumn();
            //    col.ColumnName = "FilterValue";
            //    col.DataType = typeof(String);
            //    col.MaxLength = 50;
            //    dt.Columns.Add(col);
            //    DataRow drow = dt.NewRow();
            //    drow["FieldName"] = "RuleNum"; drow["FilterValue"] = RuleNum; dt.Rows.Add(drow);
            //    //请求服务器
            //    DataGridView weldDT = (DataGridView)FindControl(_col_RuleTrunn);
            //    WeldServiceReference.CompositeType sdata = new WeldServiceReference.CompositeType();
            //    sdata.CmdCode = cmd_GetWPS_BYFILTER;
            //    sdata.RowsCount = 2;
            //    sdata.weldDataTable = clsConvertXMLDataTable.ConvertDataTableToXML(dt);

            //    WeldServiceReference.CompositeType srst = _Client.ServiceCall(sdata);
            //    if (sdata.RowsCount > 0)
            //    {
            //        _Weld = clsConvertXMLDataTable.ConvertXMLToDataTable(srst.weldDataTable);
            //        weldDT.DataSource = _Weld;
            //        weldDT.Columns.Clear();
            //        weldDT.AutoGenerateColumns =true;
            //        //注册点击事件查看焊道信息l
                   
            //    }

            //}
            //throw new NotImplementedException();
        }
    }
}
