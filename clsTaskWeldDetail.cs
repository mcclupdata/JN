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
using DevExpress.XtraExport;
using DevExpress.XtraEditors.Repository;
namespace MC
{
    /// <summary>
    /// 工序计划-焊缝数据--wps匹配；
    /// </summary>
    class clsTaskWeldDetail:clsFrmBase
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
        /// <summary>
        /// 焊工等级与焊缝等级要求匹配 By FWeldID；
        /// </summary>
        int cmd_WeldWeldingClass_Adapt_ByWelderID = 5123101;
        int cmd_WeldWeldingClass_Adapt_ByWelderNum = 5123102;
        //-----------独有变量;
        protected String _SHIP_NO="";
        protected String _TREE_NAME="";
        public _stuTaskBodyIndex _BBINFO ;
        public String _WelderName="";
        public String _TaskTime="";


        public DataTable checkWeldWeldingClassAD(DataTable weldinfos,String weldernum)
        {
            //调用服务器传入焊工ID，焊缝ID进行等级匹配
            //构造要检测的焊缝列
            DataTable welds_dt = new DataTable();
            welds_dt.Columns.Add("FID", typeof(long));
            for (int i = 0; i < weldinfos.Rows.Count; i++)
            {
                welds_dt.Rows.Add(Convert.ToInt64(weldinfos.Rows[i]["FWeldID"]));
            }
            DataTable rsdt = _Client.ServiceCall(cmd_WeldWeldingClass_Adapt_ByWelderNum, welds_dt, weldernum);
            String AdaptOKWeldIDs = "";
            rsdt = rsdt.DefaultView.ToTable(true, "FID");
            for (int i = 0; i < rsdt.Rows.Count; i++)
            {
                AdaptOKWeldIDs += rsdt.Rows[i]["FID"] + ",";
            }
            if (rsdt.Rows.Count > 0)
                AdaptOKWeldIDs = AdaptOKWeldIDs.Substring(0, AdaptOKWeldIDs.Length - 1);
            else
                AdaptOKWeldIDs = "0";
            weldinfos.DefaultView.RowFilter = "FWeldID in (" + AdaptOKWeldIDs + ")";
            return weldinfos.Copy().DefaultView.ToTable();


        }

        public clsTaskWeldDetail()
        {

        }
        public clsTaskWeldDetail(ref _stuTaskBodyIndex bbinfo,Form parent,String weldername,long welderid)
        {
            //frmTaskWeldWPSDetail frm = new frmTaskWeldWPSDetail();
            FormMCCL0007 frm = new FormMCCL0007();
            _frm = frm;
            _TaskTime = bbinfo.FSTARTTIME;
            _WelderName = weldername;
            _BBINFO = bbinfo;
            //调用服务器传入焊工ID，焊缝ID进行等级匹配
            //构造要检测的焊缝列
            DataTable welds_dt = new DataTable();
            welds_dt.Columns.Add("FID",typeof(long));
            for (int i = 0; i < bbinfo.Fweldinfos.Rows.Count;i++ )
            {
                welds_dt.Rows.Add(Convert.ToInt64(bbinfo.Fweldinfos.Rows[i]["FWeldID"]));
            }
            DataTable rsdt = _Client.ServiceCall(cmd_WeldWeldingClass_Adapt_ByWelderID, welds_dt, welderid);
            String AdaptOKWeldIDs = "";
            rsdt=rsdt.DefaultView.ToTable(true,"FID");
            for (int i = 0; i < rsdt.Rows.Count; i++)
            {
                AdaptOKWeldIDs += rsdt.Rows[i]["FID"]+",";
            }
            if (rsdt.Rows.Count > 0)
                AdaptOKWeldIDs = AdaptOKWeldIDs.Substring(0, AdaptOKWeldIDs.Length - 1);
            else
                AdaptOKWeldIDs = "0";
            bbinfo.Fweldinfos.DefaultView.RowFilter = "FWeldID in (" + AdaptOKWeldIDs + ")";

                initicls();
            if (frm.ShowDialog(parent)==DialogResult.OK)
            bbinfo=_BBINFO;
        }

        protected bool initicls()
        {
                 //初始化界面；
            //ComboBox cmbshipnobox = (ComboBox)FindControl(cmb_SHIP_NO);
            //ComboBox cmbtreenamebox = (ComboBox)FindControl(cmb_TREE_NAMe);
            //cmbshipnobox.Items.Add(_SHIP_NO);
            //cmbshipnobox.Text = _SHIP_NO;
            //cmbtreenamebox.Items.Add(_TREE_NAME);
            //cmbtreenamebox.Text = _TREE_NAME;
            //加载所有焊缝数据；
            EFDevGrid weldDT = (EFDevGrid)FindControl(_colrstGrid);
            GridView efGridView =(GridView) weldDT.Views[0];
            //if (_BBINFO.Fweldinfos == null)
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
            weldDT.DataSource = _BBINFO.Fweldinfos;
           // weldDT.AutoGenerateColumns = true;
            //注册选择规程按钮;
            //weldDT.CellContentClick += weldDT_CellContentClick;
            RepositoryItemButtonEdit but = (RepositoryItemButtonEdit)efGridView.Columns["CCRuleNum"].ColumnEdit;
            but.ButtonClick += weldDT_CellContentClick;

            //efGridView.RowCellClick += weldDT_CellContentClick;
           // weldDT.DataError += weldDT_DataError;

            EFButton butok = (EFButton)FindControl("butOK");
            EFButton butcancel = (EFButton)FindControl("butCancel");
            //注册完成按钮；
            butok.Click += butok_Click;
            //注册取消按钮
            butcancel.Click += butcancel_Click;
            //注册选择项
            //DataGridViewCheckBoxColumn ccol = (DataGridViewCheckBoxColumn)weldDT.Columns["CFTasked"];
           // ccol.ValueType = typeof(int);

            return true;
        }

        void weldDT_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //throw new NotImplementedException();
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
            _BBINFO.Fweldinfos =(DataTable) weldDT.DataSource;
            for (int i = 0; i < _BBINFO.Fweldinfos.Rows.Count; i++)
            {
                //if (Convert.ToInt32(_BBINFO.Fweldinfos.Rows[i]["FTasked"]) ==1)
                //{
                //    _BBINFO.Fweldinfos.Rows[i]["FTasked"] = 1;
                //}

            }
            _frm.DialogResult = DialogResult.OK;
                _frm.Close();
            //throw new NotImplementedException();

        }
        //public clsProjectWeldDetail(ref Form frm, String SHIP_NO, String TREE_NAME)
        //{
        //    _frm = frm;
        //    _SHIP_NO = SHIP_NO;
        //    _TREE_NAME = TREE_NAME;
        //    initicls();
        //}
        /// <summary>
        /// Grid中，点击选择规程按钮触发事件；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void weldDT_CellContentClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

            GridView dgv = (GridView)((EFDevGrid)FindControl("dataGrid")).Views[0];
            String bName = dgv.FocusedColumn.Name;
            int rindex = dgv.FocusedRowHandle;

            if (bName == _grid_WeldWPS)
            {
                //进行WPS配置
                if (dgv.RowCount==1)
                    return;
               // DataGridViewRow row = dgv.Rows[e.RowIndex];
                DataRow row = dgv.GetFocusedDataRow();
                //得到焊缝数据的GRADE,WELD_TYPE,THICK1,THICK2,WELD2_CODE,WELD_MOD
                Formbase vfrm = (Formbase)_frm;
                clsProjectChooseWeldRule clsfrm = new clsProjectChooseWeldRule(row,vfrm);
              
                    //得到匹配的WPS数据
                if (clsfrm._choosedRuleFID > 0)
                {
                    dgv.SetRowCellValue(rindex,"RuleFID",clsfrm._choosedRuleFID);//_grid_RuleFID].Value = clsfrm._choosedRuleFID;
                    dgv.SetRowCellValue(rindex, "RuleNum", clsfrm._choosedRuleNum);//row.Cells[_grid_RuleNum].Value = clsfrm._choosedRuleNum;
                }
              
            }
            //throw new NotImplementedException();
        }
    }
}
