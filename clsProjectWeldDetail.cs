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
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;

namespace MC
{
    /// <summary>
    /// 工序计划-焊缝数据--wps匹配；
    /// </summary>
    class clsProjectWeldDetail:clsFrmBase
    {

        String _colbutAdd = "butAdd";
        String _colbutOK = "butOK";
        String _colbutCancel = "but_ChooseFile";
        String _colexcelGrid = "dataGrid";
        String _colrstGrid = "dataGrid";
        String _col = "txtFileName";
        String _grid_FDoDepartID = "FDoDepartID";
        String _grid_WeldWPS = "CCRuleNum";
        String _grid_del = "CButDelete";
        String _grid_RuleNum = "RuleNum";
        String _grid_RuleFID = "RuleFID";


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
        int cmd_SHIP_NO_TREE_NAME_WELD = 1020;//查询的到工程号，分段号所在的所有焊缝信息;

        //-----------独有变量;
        protected String _SHIP_NO="";
        protected String _TREE_NAME="";
        public ProjectBodyInfo _BBINFO ;
        protected String _NotINFweldID="0";
        protected _stuDispatchBodyInfo _BBINFO1;
        protected DataTable _DT;
        public clsProjectWeldDetail(ref _stuDispatchBodyInfo bbinfo, Formbase frm)
        {
            //frmProjectWeldWPSDetail frm = new frmProjectWeldWPSDetail();
            _frm = frm;
            _SHIP_NO = bbinfo._Project_SHIP_NO;
            _TREE_NAME = bbinfo._Project_TREE_NAME;
            EFDevGrid weldDT = (EFDevGrid)FindControl(_colrstGrid);
            GridView efGridView = (GridView)weldDT.Views[0];
            efGridView.Columns["RuleFID"].FieldName = "FWELDWPSID";
            //efGridView.Columns[FWELDWPSID].
          //  _BBINFO =bbinfo;
            _DT = bbinfo._Project_WeldInfos;
            initicls();
            //frm.ShowDialog(parent);
            //bbinfo = _BBINFO;
            bbinfo._Project_WeldInfos = _DT;
        }


        public clsProjectWeldDetail(ref ProjectBodyInfo bbinfo,Formbase parent)
        {
            //frmProjectWeldWPSDetail frm = new frmProjectWeldWPSDetail();
            FormMCCL00014 frm = new FormMCCL00014();
            _frm = frm;
            _SHIP_NO = bbinfo.SHIP_NO;
            _TREE_NAME = bbinfo.TREE_NAME;
            //_BBINFO = bbinfo;
            _DT = bbinfo.Weld_WPS;
            initicls();
            if (frm.ShowDialog(parent)==DialogResult.OK)
            //bbinfo=_BBINFO;
            bbinfo.Weld_WPS = _DT;
        }

        protected bool initicls()
        {
                 //初始化界面；
            //EFComboBox cmbshipnobox = (EFComboBox)FindControl(cmb_SHIP_NO);
            //EFComboBox cmbtreenamebox = (EFComboBox)FindControl(cmb_TREE_NAMe);
            //cmbshipnobox.Items.Add(_SHIP_NO);
            //cmbshipnobox.Text = _SHIP_NO;
            //cmbtreenamebox.Items.Add(_TREE_NAME);
            //cmbtreenamebox.Text = _TREE_NAME;
            //加载所有焊缝数据；
            EFDevGrid weldDT = (EFDevGrid)FindControl(_colrstGrid);
            GridView efGridView=(GridView)weldDT.Views[0];
            //if (_BBINFO.Weld_WPS == null)
            //{
                
            //    WeldServiceReference.CompositeType sdata = new WeldServiceReference.CompositeType();
            //    sdata.CmdCode = cmd_SHIP_NO_TREE_NAME_WELD;
            //    //构造查询条件
            //    DataTable fdt = new DataTable();
            //    DataColumn col = new DataColumn();
            //    col.ColumnName = "SHIP_NO";
            //    col.DataType = typeof(String);
            //    col.MaxLength = 50;
            //    fdt.Columns.Add(col);
            //    col = new DataColumn();
            //    col.ColumnName = "TREE_NAME";
            //    col.DataType = typeof(String);
            //    col.MaxLength = 50;
            //    fdt.Columns.Add(col);
            //    DataRow row = fdt.NewRow();
            //    row["SHIP_NO"] = _SHIP_NO;
            //    row["TREE_NAME"] = _TREE_NAME;
            //    fdt.Rows.Add(row);


            //    sdata.RowsCount = fdt.Rows.Count;
            //    sdata.weldDataTable = clsConvertXMLDataTable.ConvertDataTableToXML(fdt);
            //    WeldServiceReference.CompositeType srst = _Client.ServiceCall(sdata);
            //    if (sdata.RowsCount > 0)
            //    {
            //        _Weld = clsConvertXMLDataTable.ConvertXMLToDataTable(srst.weldDataTable);
            //        _BBINFO.Weld_WPS = _Weld;
            //    }
            //}
            //weldDT.Columns.Clear();
            weldDT.DataSource =_DT;
            //weldDT.AutoGenerateColumns = true;
            //注册选择规程按钮;
            //weldDT.CellContentClick += weldDT_CellContentClick;
            //efGridView.RowCellClick += weldDT_CellContentClick;
            RepositoryItemButtonEdit but = (RepositoryItemButtonEdit)efGridView.Columns["CCRuleNum"].ColumnEdit;
            but.ButtonClick += weldDT_CellContentClick;
            EFButton butok = (EFButton)FindControl("butOK");
            EFButton butcancel = (EFButton)FindControl("butCancel");
            //注册完成按钮；
            butok.Click += butok_Click;
            //注册取消按钮
            butcancel.Click += butcancel_Click;


            return true;
        }
        /// <summary>
        /// 取消按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void butcancel_Click(object sender, EventArgs e)
        {
            _frm.DialogResult = DialogResult.Cancel;
            _frm.Close();
           // throw new NotImplementedException();
        }
        //完成操作，并关闭界面；
        void butok_Click(object sender, EventArgs e)
        {
            EFDevGrid weldDT = (EFDevGrid)FindControl(_colrstGrid);
            DevExpress.XtraGrid.Views.Grid.GridView dgv = (DevExpress.XtraGrid.Views.Grid.GridView )weldDT.Views[0];
           
            int k=(int)dgv.GetRowCellValue(dgv.FocusedRowHandle, "FChecked");
            weldDT.Update();
            _DT=(DataTable) weldDT.DataSource;
            //DataView dv = _DT.Copy().DefaultView;
            //dv.RowFilter = "FChecked=1";
            //DataTable dt = dv.ToTable();
            //int cc = dt.Rows.Count;
            //weldDT.Views[0].RefreshData();
            //EFDevGrid weldDT2 = (EFDevGrid)FindControl("efDevGrid1");
            //weldDT2.DataSource = dt;

            _frm.Close();
            //throw new NotImplementedException();

        }
        public clsProjectWeldDetail(ref Formbase frm, String SHIP_NO, String TREE_NAME)
        {
            _frm = frm;
            _SHIP_NO = SHIP_NO;
            _TREE_NAME = TREE_NAME;
            initicls();
        }
        /// <summary>
        /// Grid中，点击选择规程按钮触发事件；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void weldDT_CellContentClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
        
            GridView dgv = (GridView)((EFDevGrid)FindControl("dataGrid")).Views[0];
            int rindex = dgv.FocusedRowHandle;
            if (rindex < 0)
                return;
            //if (e.Column.Name == _grid_WeldWPS)
            //{
                //进行WPS配置
                //if (dgv.SelectedRowsCount==1)
                //    return;
               
                DataRow row = ((DataRowView)dgv.GetRow(rindex)).Row;// Rows[e.RowIndex];
                //得到焊缝数据的GRADE,WELD_TYPE,THICK1,THICK2,WELD2_CODE,WELD_MOD
            clsProjectChooseWeldRule clsfrm;
                if (((DataView)dgv.DataSource).ToTable().Columns.IndexOf("FSHIP_NO") < 0)
                {
                    clsfrm = new clsProjectChooseWeldRule(row, _frm, _SHIP_NO);
                }
                else
                {
                clsfrm = new clsProjectChooseWeldRule(row, _frm);// new clsProjectChooseWeldRule(row, _frm);
                }
                    //得到匹配的WPS数据
                if (clsfrm._choosedRuleFID > 0)
                {
                    dgv.SetRowCellValue(rindex,_grid_RuleFID,clsfrm._choosedRuleFID);
                    //row.Cells[_grid_RuleNum].Value = clsfrm._choosedRuleNum;
                    dgv.SetRowCellValue(rindex, _grid_RuleNum, clsfrm._choosedRuleNum);
                }
                    //dgv.Refresh();
                    dgv.RefreshData();
            //}
            //throw new NotImplementedException();
        }
    }
}
