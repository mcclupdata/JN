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

    public struct ProjectBodyInfo
    {
        public DataTable Weld_WPS;
        public long DEPARTID;//作业区
        public String SHIP_NO;
        public String TREE_NAME;
        public int indexnum;
    }

    /// <summary>
    /// 焊缝数据导入
    /// </summary>
    class clsProjectProcess:clsFrmBase
    {
        String _colbutAdd= "butAdd";
        String _colbutOK = "butOK";
        String _colbutCancel = "but_ChooseFile";
        String _colexcelGrid = "dataGrid";
        String _colrstGrid = "dataGrid";
        String _col = "txtFileName";
        String _grid_FDoDepartID = "CFDoDepartID";
        String _grid_WeldWPS = "CButWeld";
        String _grid_del = "CButDelete";
        //----------------------------
        String txtFProcessnum = "FProcessnum";
        

 
        DataTable _processHead;
        DataTable _processBody;
        DataTable _proessBodyIndex;
        DataTable _DoDepartID;
        
        int cmd_submit = 1004;//提交表工序计划表单--表头命令
        int cmd_submit_Project_head = 6014;//提交表工序计划表单--表头命令
        int cmd_submit_Project_Body = 6015;//提交工序计划表体命令；
        int cmd_delete_Project = 7001;//删除工序计划表头，表体；
        int cmd_ship_no = 1005;//查询得到可以分配的工程号;
        int cmd_wps = 1006;//查询得到可以匹配使用的wps
        int cmd_depart = 1007;//查询得到可以承接的部门；
        int cmd_Empty_Head = 1008;//查询得到空的表头数据;
        int cmd_Empty_body = 1009;//查询得到空表体数据；
        int cmd_get_Head = 1014;//通过查询条件得到工序计划表头
        int cmd_get_Body = 1015;//通过查询条件得到工序计划表体;
        int cmd_get_BodyWeldInfos = 1016;//通过查询条件得到工序计划表体内的焊缝及WPS
        int cmd_Empty_DoDepartID = 1010;//查询得到部门数据；
        int cmd_get_ship_no = 2001;//获取工程号
        int cmd_get_tree_name = 2002;//依据工程号得到分段号
        int cmd_exc_sql = 56281;//执行SQL语句返回Table；

        //---------独有变量
        ArrayList _Bodylist = new ArrayList();
        private long _ProjectFID = 0;

        protected long ProjectFID
        {
            get { return _ProjectFID; }
            set { _ProjectFID = value; }
        }



        //MC.WeldServiceReference.CompositeType sdata;



        public clsProjectProcess(long fid,ref Formbase frm)
        {
            _ProjectFID = fid;
            //FormMCCL0009 frm = new FormMCCL0009();
            _frm = frm;
            Initialization_cls();
           
            //_frm.ShowDialog();
        }

        /// <summary>
        /// 构造
        /// </summary>
        /// <returns></returns>
        protected DataTable GetProcessbodyIndex()
        {
            DataTable dt = new DataTable();
            DataColumn col = new DataColumn();
            col.ColumnName = "FID";
            col.DataType = typeof(int);
            dt.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = "SHIP_ID";
            col.DataType = typeof(String);
            col.MaxLength = 50;
            dt.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = "SHIP_NO";
            col.DataType = typeof(String);
            col.MaxLength = 50;
            dt.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = "TREE_NAME";
            col.DataType = typeof(String);
            col.MaxLength = 50;
            dt.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = "FDoDepartID";
            col.DataType = typeof(long);
            //col.MaxLength = 50;
            dt.Columns.Add(col);

            return dt;


        }
        //空构造；
        public clsProjectProcess()
        {
        }
        //删除一个工序计划；
        /// <summary>
        /// 删除一个工序计划
        /// </summary>
        /// <param name="vFID">工序计划HeaderFID</param>
        /// <returns>执行结果</returns>
        public Boolean Delete(long vFID)
        {
            //查询该工序计划是否被使用
            String sql = "select COUNT(FID) from t_DispatchingBody where FProjectHeadID=" + vFID;
            DataTable fdt = new DataTable();
            DataColumn col = new DataColumn();
            col.ColumnName = "FSql";
            col.DataType = typeof(String);
            fdt.Columns.Add(col);
            DataRow ndr = fdt.NewRow();
            ndr[0] = sql;
            fdt.Rows.Add(ndr);
            DataTable rst= _Client.ServiceCall(cmd_exc_sql, fdt);
            int co = Convert.ToInt32(rst.Rows[0][0]);
            if (co > 0)
            {
                MessageBox.Show(_frm, "已经派工，不能删除!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            fdt = new DataTable();
            col = new DataColumn();
            col.ColumnName = "FID";
            col.DataType = typeof(long);
            fdt.Columns.Add(col);
            ndr = fdt.NewRow();
            ndr[0] = vFID;
            fdt.Rows.Add(ndr);
            rst = _Client.ServiceCall(cmd_delete_Project, fdt);
            MessageBox.Show(_frm, "删除成功!", "Success！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }
        protected Boolean Initialization_cls()
        {
            Control cl = this.FindControl(_colbutAdd);
            cl.Click += butAdd_Click;
            cl = this.FindControl("butOK");
            cl.Click += butOK_Click;
            //初始化表头数据;
            cl = new Control();
            cl = this.FindControl(txtFProcessnum);


            EF.EFDevGrid efGrid = (EF.EFDevGrid)FindControl("dataGrid");
            GridView efGridView = (GridView)efGrid.Views[0];

            int vcmdcode = 0;
            //初始化表头数据
            if (_ProjectFID == 0)
            {
                //产生工序编号；年+周+时间
                GregorianCalendar gc = new GregorianCalendar();
                
                int weekOfYear = gc.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
                EFLabelText lbnum = (EFLabelText)cl;
                lbnum.EFEnterText = "JN-P-" + DateTime.Now.Year + "-" + weekOfYear.ToString() + "-" + DateTime.Now.Hour.ToString() + "-" + DateTime.Now.Minute.ToString();
                
                ((EFLabelText)cl).ReadOnly = true;

                vcmdcode = cmd_Empty_body;

                //sdata = new WeldServiceReference.CompositeType();
                //sdata.CmdCode = cmd_Empty_Head;
                //sdata.RowsCount = 0;
                //初始化时间范围；
                cl = new Control();
                cl = this.FindControl("FSTARTTIME");
                DateTime FirstDay = DateTime.Now.AddDays(-DateTime.Now.Day + 1);
                ((DateTimePicker)cl).Value = FirstDay;
                DateTime LastDay = DateTime.Now.AddMonths(1).AddDays(-DateTime.Now.AddMonths(1).Day);
                cl = new Control();
                cl = this.FindControl("FENDTIME");
                ((DateTimePicker)cl).Value = LastDay;
                cl = this.FindControl("FDepartID");
                ((EFComboBox)cl).SelectedIndex = 0;
                cl = this.FindControl("FISControl");
                ((ComboBox)cl).SelectedIndex = 0;
                cl = this.FindControl("FProcessState");
                ((ComboBox)cl).SelectedIndex = 0;

            }
            else
            {
                //sdata = new WeldServiceReference.CompositeType();

                //sdata.CmdCode = cmd_get_Head;
                vcmdcode = cmd_get_Head;

                DataTable fdata = new DataTable();
                DataColumn col = new DataColumn();
                col.ColumnName = "FID";
                col.DataType = typeof(long);
                fdata.Columns.Add(col);
                DataRow row = fdata.NewRow();
                row["FID"] = _ProjectFID;
                fdata.Rows.Add(row);
                //sdata.weldDataTable = clsConvertXMLDataTable.ConvertDataTableToXML(fdata);
                //sdata.RowsCount = 1;
                DataTable vdt = _Client.ServiceCall(vcmdcode, fdata);
                if (vdt.Rows.Count == 0)
                {
                    _processHead = vdt;//clsConvertXMLDataTable.ConvertxmlSchemaToDataTable(srst.weldDataTable);
                }
                else
                {
                    _processHead = vdt;// clsConvertXMLDataTable.ConvertXMLToDataTable(srst.weldDataTable);
                    
                    FillfrmData(_processHead, ref _frm);
                }
            }

            //WeldServiceReference.CompositeType srst = _Client.ServiceCall(sdata);
            


            //初始化表体概要数据;
            //sdata = new WeldServiceReference.CompositeType();
            if (_ProjectFID == 0)
            {//创建
                //sdata.CmdCode = cmd_Empty_body;
                //sdata.RowsCount = 0;
                //srst = new WeldServiceReference.CompositeType();
                //srst = _Client.ServiceCall(sdata);
                DataTable vdt_0 = _Client.ServiceCall(cmd_Empty_body, null);
                _processBody = vdt_0;// clsConvertXMLDataTable.ConvertxmlSchemaToDataTable(srst.weldDataTable);
                _proessBodyIndex = GetProcessbodyIndex();
            }
            else
            {//编辑；
                //srst = new WeldServiceReference.CompositeType();
                //sdata.CmdCode = cmd_get_Body;
                //sdata.RowsCount = 1;

                DataTable fdata = new DataTable();
                DataColumn col = new DataColumn();
                col.ColumnName = "FID";
                col.DataType = typeof(long);
                fdata.Columns.Add(col);
                DataRow row = fdata.NewRow();
                row["FID"] = _ProjectFID;
                fdata.Rows.Add(row);
                DataTable vdt_1 = _Client.ServiceCall(cmd_get_Body, fdata);

                //sdata.weldDataTable = clsConvertXMLDataTable.ConvertDataTableToXML(fdata);

                
               // srst = _Client.ServiceCall(sdata);
                _proessBodyIndex = vdt_1;// clsConvertXMLDataTable.ConvertXMLToDataTable(srst.weldDataTable);
                //获取焊缝信息;
                _Bodylist.Clear();
                for (int i = 0; i < _proessBodyIndex.Rows.Count; i++)
                {
                    DataRow nrw=_proessBodyIndex.Rows[i];
                    ProjectBodyInfo bb = FindBodyInfo(nrw["SHIP_NO"].ToString(), nrw["TREE_NAME"].ToString(), Convert.ToInt64(nrw["FDoDepartID"]));
                    
                }


            }
            //绑定到Grid中；
           // Control dataGrid = FindControl(_colexcelGrid);
            //
            //((EF.EFDevGrid)dataGrid).DataError += clsProjectProcess_DataError;

            //DataRow nrow = _proessBodyIndex.NewRow();
            /*
            nrow["Indexnum"]=1;
            nrow["SHIP_ID"]="RE";
            nrow["SHIP_NO"]="2008";
            nrow["TREE_NAME"] = "07002";
            nrow["FDoDepartID"] = 1;
           
            _proessBodyIndex.Rows.Add(nrow);
             */

           // ((EF.EFDevGrid)dataGrid).AutoGenerateColumns = true;
           efGrid.DataSource = _proessBodyIndex;
            //将Combox 部门绑定
            //DataGridViewComboBoxColumn cmbox = (DataGridViewComboBoxColumn)((DataGridView)dataGrid).Columns[_grid_FDoDepartID];
            //DataGridViewButtonCell cmbut = (DataGridViewButtonCell)((DataGridView)dataGrid).Columns[_grid_WeldWPS];

            //sdata = new WeldServiceReference.CompositeType();
            //sdata.CmdCode = cmd_Empty_DoDepartID;
            //sdata.RowsCount = 0;
            //srst = new WeldServiceReference.CompositeType();
            DataTable srst = _Client.ServiceCall(cmd_Empty_DoDepartID,null);

            if (srst.Rows.Count == 0)
            {
                MessageBox.Show("没有组织信息");
                return false;
            }
            _DoDepartID = srst;//clsConvertXMLDataTable.ConvertXMLToDataTable(srst.weldDataTable);
            //cmbox.Items.Clear();
            //cmbox.DataSource = _DoDepartID;
            //cmbox.ValueMember = "FDoDepartID";
            //cmbox.DisplayMember = "FDepartName";

            //cmbox.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            //
            //DataGridViewButtonColumn butcol = (DataGridViewButtonColumn)((DataGridView)dataGrid).Columns[_grid_WeldWPS];
            //butcol.Text = "配置WPS";
            RepositoryItemLookUpEdit lookuo= (RepositoryItemLookUpEdit)efGridView.Columns["FDoDepartID"].ColumnEdit;
            _DoDepartID.Columns["FDoDepartID"].ColumnName = "VALUE";
            _DoDepartID.Columns["FDepartName"].ColumnName = "NAME";

            DevGridView_bingLookUp(ref lookuo, _DoDepartID);
            
            efGridView.ShownEditor += new EventHandler(efGridView_ShownEditor);

            //修改为注册各自的对象；
            RepositoryItemButtonEdit but = (RepositoryItemButtonEdit)efGridView.Columns["but_Welds"].ColumnEdit;
            but.ButtonClick += clsProjectProcess_CellContentClick;//new EventHandler();
            RepositoryItemButtonEdit but_del = (RepositoryItemButtonEdit)efGridView.Columns["but_Del"].ColumnEdit;
            but_del.ButtonClick += clsProjectProcess_CellContentClick;
            //String ssss = but.Name;

            //efGridView.RowCellClick += clsProjectProcess_CellContentClick;
            //初始化工程号
            //sdata = new WeldServiceReference.CompositeType();
            //sdata.CmdCode = cmd_get_ship_no;
            //sdata.RowsCount = 0;

            srst = _Client.ServiceCall(cmd_get_ship_no,null);
            if (srst.Rows.Count > 0)
            {
                DataTable ship_no_dt =srst ;//clsConvertXMLDataTable.ConvertXMLToDataTable(srst.weldDataTable);
                //工程号变更事件注册
                ComboBox cmbb_ship_no = (ComboBox)FindControl("SHIP_NO");
                cmbb_ship_no.SelectedIndexChanged += cmbb_ship_no_SelectedIndexChanged;
                cmbb_ship_no.DataSource = ship_no_dt;
                cmbb_ship_no.ValueMember = "SHIP_NO";
                cmbb_ship_no.DisplayMember = "SHIP_NO";
                cmbb_ship_no.SelectedIndex = 0;

            }
            return true;
        }

        void efGridView_ShownEditor(object sender, EventArgs e)
        {
            //throw new NotImplementedException();

        }

        public clsProjectProcess(ref Formbase frm)
        {
            _frm = frm;
            //注册添加事件
            _ProjectFID = 0;
            Initialization_cls();
        }

        
        /// <summary>
        /// 工程号修改，联动分段号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void cmbb_ship_no_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable filterdt = new DataTable();
            DataColumn col = new DataColumn();
            col.ColumnName = "SHIP_NO";
            col.DataType = typeof(String);
            col.MaxLength = 50;
            filterdt.Columns.Add(col);
            DataRow row = filterdt.NewRow();
            System.Data.DataRowView x = (System.Data.DataRowView)((ComboBox)sender).SelectedItem;
            
            
            row["SHIP_NO"] = x.Row["SHIP_NO"];
            //return;
            filterdt.Rows.Add(row);
            //sdata = new WeldServiceReference.CompositeType();
            //sdata.CmdCode = cmd_get_tree_name;
            //sdata.RowsCount = 1;
            //sdata.weldDataTable = clsConvertXMLDataTable.ConvertDataTableToXML(filterdt);
            //WeldServiceReference.CompositeType srst = new WeldServiceReference.CompositeType();

            DataTable srst = _Client.ServiceCall(cmd_get_tree_name,filterdt);
            if (srst.Rows.Count > 0)
            {
                DataTable ship_no_dt = srst;//clsConvertXMLDataTable.ConvertXMLToDataTable(srst.weldDataTable);
                //工程号变更事件注册
                ComboBox cmbb_ship_no = (ComboBox)FindControl("TREE_NAME");
                
               
                cmbb_ship_no.ValueMember = "TREE_NAME";
                cmbb_ship_no.DisplayMember = "TREE_NAME";
                cmbb_ship_no.DataSource = ship_no_dt;
                cmbb_ship_no.SelectedIndex = 0;

            }
            //throw new NotImplementedException();
        }
        /// <summary>
        /// 删除表体索引
        /// </summary>
        /// <param name="ship_no"></param>
        /// <param name="tree_name"></param>
        /// <returns></returns>
        public void DeleteBodyInfo(String ship_no, String tree_name)
        {
            //ProjectBodyInfo bb = new ProjectBodyInfo();
            for (int i = 0; i < _Bodylist.Count; i++)
            {
                ProjectBodyInfo bb = (ProjectBodyInfo)_Bodylist[i];
                if (bb.SHIP_NO == ship_no && bb.TREE_NAME == tree_name)
                {
                     _Bodylist.Remove(bb);
                }
            }
           
        }
        /// <summary>
        /// 更新_bodyLisgt
        /// </summary>
        /// <param name="bb"></param>
        public void UpdateBodyList(ProjectBodyInfo bb)
        {
            ProjectBodyInfo bbl;
            for (int i = 0; i < _Bodylist.Count; i++)
            {
                bbl = (ProjectBodyInfo)_Bodylist[i];
                if (bbl.SHIP_NO == bb.SHIP_NO && bbl.TREE_NAME == bb.TREE_NAME && bb.DEPARTID==bbl.DEPARTID)
                {
                    _Bodylist[i] = bb;
                    return;
                }
            }
        }
        public DataTable GetProjectBody_weldinfos(String ship_no, String tree_name,long vDoDepartID)
        {

            //WeldServiceReference.CompositeType sdata = new WeldServiceReference.CompositeType();


            DataTable fdata = new DataTable();
            //构件查询条件
            DataColumn col = new DataColumn();
            col.ColumnName = "SHIP_NO";
            col.DataType = typeof(String);
            col.MaxLength = 100;
            fdata.Columns.Add(col);
            col = new DataColumn();
            col.ColumnName = "TREE_NAME";
            col.DataType = typeof(String);
            col.MaxLength = 100;
            fdata.Columns.Add(col);
            col = new DataColumn();
            col.ColumnName = "FProjectHeadID";
            col.DataType = typeof(long);
            fdata.Columns.Add(col);
            col = new DataColumn();
            col.ColumnName = "FDoDepartID";
            col.DataType = typeof(long);
            fdata.Columns.Add(col);

            DataRow nrw = fdata.NewRow();
            nrw["SHIP_NO"] = ship_no;
            nrw["TREE_NAME"] = tree_name;
            nrw["FProjectHeadID"] = _ProjectFID;
            nrw["FDoDepartID"] = vDoDepartID;
            fdata.Rows.Add(nrw);


            //sdata.CmdCode = cmd_get_BodyWeldInfos;
            //sdata.RowsCount = 1;
            //sdata.weldDataTable = clsConvertXMLDataTable.ConvertDataTableToXML(fdata);
            //sdata = _Client.ServiceCall(sdata);

            DataTable rsdt = _Client.ServiceCall(cmd_get_BodyWeldInfos, fdata) ;
            //if (sdata.RowsCount > 0)
            //{
            //    rsdt = _Client.ServiceCall(cmd_get_BodyWeldInfos, fdata);// clsConvertXMLDataTable.ConvertXMLToDataTable(sdata.weldDataTable);
            //}
            //else
            //{
            //    rsdt = null;
            //}
            return rsdt;

  



        }
        public String GetnotInFWeldID()
        {
            String nostr = "0";
            for (int i = 0; i < _Bodylist.Count; i++)
            {
                ProjectBodyInfo bb = (ProjectBodyInfo)_Bodylist[i];
                DataView dv = bb.Weld_WPS.Copy().DefaultView;
                dv.RowFilter = "FChecked=1";
                DataTable dt = dv.ToTable();
                for (int k = 0; k < dt.Rows.Count; k++)
                {
                    nostr += "," + dt.Rows[k]["FID"].ToString();
                }
            }
            return nostr;
        }
        /// <summary>
        /// 查询得到表体索引List，有则返回，无则增加；
        /// </summary>
        /// <param name="ship_no"></param>
        /// <param name="tree_name"></param>
        /// <returns></returns>
        public ProjectBodyInfo FindBodyInfo(String ship_no, String tree_name,long vDoDepartid)
        {
            ProjectBodyInfo bb = new ProjectBodyInfo();
            DataView dv;
            DataTable dt;
            for (int i = 0; i < _Bodylist.Count; i++)
            {
                bb = (ProjectBodyInfo)_Bodylist[i];
                if (bb.SHIP_NO == ship_no && bb.TREE_NAME == tree_name && bb.DEPARTID==vDoDepartid)
                {
                    //if (_ProjectFID == 0)
                    //{
                        //bb.Weld_WPS = GetProjectBody_weldinfos(ship_no, tree_name);
                    String usedweldid = "0";
                  
                    for (int ii = 0; ii < _Bodylist.Count; ii++)
                    {
                        ProjectBodyInfo cc= (ProjectBodyInfo)_Bodylist[ii];
                        if (ii != i)
                        {
                            dv=cc.Weld_WPS.Copy().DefaultView;
                            dv.RowFilter="FChecked=1";
                            dt=dv.ToTable();
                            for (int k = 0; k < dt.Rows.Count; k++)
                            {
                                usedweldid += "," + dt.Rows[k]["FID"].ToString();
                            }
                        }
                    }
                    dv = bb.Weld_WPS.Copy().DefaultView;
                    dv.RowFilter = "FID NOT IN (" + usedweldid + ")";
                    bb.Weld_WPS = dv.ToTable();
                        return bb;
                   // }
                   // else
                   // {
                        //编辑；
                   //     bb.Weld_WPS = GetProjectBody_weldinfos(ship_no, tree_name);
                        
                  //  }
                }
            }
            bb.TREE_NAME = tree_name;
            bb.SHIP_NO = ship_no;
            bb.DEPARTID = vDoDepartid;
           // if (_ProjectFID == 0)
           // {
            dt=GetProjectBody_weldinfos(ship_no, tree_name,vDoDepartid);
           
            String strNotIn = GetnotInFWeldID();
            dv = dt.Copy().DefaultView;
            dv.RowFilter = "FID NOT IN (" + strNotIn+")";
            bb.Weld_WPS = dv.ToTable();
           // }
           // else
           // {
                //编辑；
           //     bb.Weld_WPS = GetProjectBody_weldinfos(ship_no, tree_name);
            //}
            _Bodylist.Add(bb);
            return bb;
        }
        /// <summary>
        /// 处理内容被点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        void clsProjectProcess_CellContentClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //throw new NotImplementedException();
            
            //DevExpress.XtraEditors.ButtonEdit but = (RepositoryItemButtonEdit)sender;
            GridView dgv = (GridView)((EFDevGrid)FindControl("dataGrid")).Views[0];
            int rindex = dgv.FocusedRowHandle;
            String butName = dgv.FocusedColumn.ColumnEditName;
            //int cindex=dgv.FocusedColumn
            if (butName == "but_Welds") // _grid_WeldWPS)
            {
                //进行进入焊缝信息配置WPS界面
                //if (dgv.RowCount<0)
                //    return;
                
                //DataGridViewRow row = dgv.Rows[rindex];
                String ship_id =dgv.GetRowCellValue(rindex,"SHIP_ID").ToString() ;//row.Cells["CSHIP_ID"].Value.ToString() ;
                String ship_no = dgv.GetRowCellValue(rindex,"SHIP_NO").ToString();//row.Cells["CSHIP_NO"].Value.ToString();
                String tree_name = dgv.GetRowCellValue(rindex, "TREE_NAME").ToString(); //row.Cells["CTREE_NAME"].Value.ToString();
                //如果没有给定作业区，提示先配置作业区；
                long vFDopartid=0;
                if (Convert.IsDBNull(dgv.GetRowCellValue(rindex,"FDoDepartID")))//row.Cells["CFDoDepartID"].Value))
                {
                    MessageBox.Show(_frm, "请先分配作业区后操作", "提示", MessageBoxButtons.OK);
                    return;
                }
                else
                    vFDopartid = Convert.ToInt64(dgv.GetRowCellValue(rindex,"FDoDepartID"));

             
                ProjectBodyInfo bbinfo = FindBodyInfo(ship_no, tree_name,vFDopartid);
                
                clsProjectWeldDetail cls = new clsProjectWeldDetail(ref bbinfo,_frm);

                UpdateBodyList(bbinfo);

               
            }
            if (butName == "but_Del") // _grid_del)
            {
                //删除一条记录；
                //if (dgv.RowCount == 1)
                //    return;
                //DataGridViewRow row = dgv.GetRow(rindex);// dgv.Rows[e.RowIndex];
                String ship_no,tree_name;
                ship_no = Convert.ToString(dgv.GetRowCellValue(rindex, "SHIP_NO"));// row.Cells["CSHIP_NO"].Value);
                tree_name = Convert.ToString(dgv.GetRowCellValue(rindex, "TREE_NAME"));// row.Cells["CTREE_NAME"].Value);
                del_processBodyIndex(ship_no, tree_name);
                DeleteBodyInfo(ship_no, tree_name);

               
                dgv.RefreshData();
            }
        }
        protected void del_processBodyIndex(String ship_no,String tree_name)
        {
            for (int i = 0; i < _proessBodyIndex.Rows.Count; i++)
            {
                DataRow row = _proessBodyIndex.Rows[i];
                if (row["SHIP_NO"].ToString() == ship_no && row["TREE_NAME"].ToString() == tree_name)
                {
                    _proessBodyIndex.Rows.Remove(row);
                    return;
                }

            }
        }
        void clsProjectProcess_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //throw new NotImplementedException();
        }
        /// <summary>
        /// 点击添加按钮处理事件，将选择的SHIP_NO和TREE_NAME添加到表体中；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void butAdd_Click(object sender, EventArgs e)
        {
            //产生序号
            DataRowView comview_shipno = (DataRowView)((EF.EFComboBox)FindControl("SHIP_NO")).SelectedItem;
            DataRowView comview_treename = (DataRowView)((EF.EFComboBox)FindControl("TREE_NAME")).SelectedItem;
            String ship_no = comview_shipno["SHIP_NO"].ToString();

            String tree_name= comview_treename["TREE_NAME"].ToString();
            //for (int i = 0; i < _Bodylist.Count; i++)
            //{
            //    ProjectBodyInfo bb = (ProjectBodyInfo)_Bodylist[i];
            //    if (bb.SHIP_NO == ship_no && bb.TREE_NAME == tree_name)
            //    {
            //        MessageBox.Show("已经添加了！");
            //        return;
            //    }
            //}
            for (int i = 0; i < _proessBodyIndex.Rows.Count; i++)
            {
                DataRow row = _proessBodyIndex.Rows[i];
                //row["Indexnum"] = i + 1;

            }
          
           
            
            DataRow nrow = _proessBodyIndex.NewRow();
            //nrow["Indexnum"] = _proessBodyIndex.Rows.Count+1;
            nrow["SHIP_ID"] = "RE";
            nrow["SHIP_NO"] = comview_shipno["SHIP_NO"].ToString();
            nrow["TREE_NAME"] = comview_treename["TREE_NAME"].ToString() ;
            _proessBodyIndex.Rows.Add(nrow);
            //暂停使用这段代码
            /*
            ProjectBodyInfo bbinfo = new ProjectBodyInfo();
            bbinfo.indexnum = _proessBodyIndex.Rows.Count + 1;
            bbinfo.SHIP_NO = comview_shipno["SHIP_NO"].ToString(); ;
            bbinfo.TREE_NAME = comview_treename["TREE_NAME"].ToString();
            //bbinfo.Weld_WPS = GetProjectBody_weldinfos(bbinfo.SHIP_NO, bbinfo.TREE_NAME);
            _Bodylist.Add(bbinfo);
             * 
             * /
             */
            //((DataGridView)FindControl(_colrstGrid)).DataSource = _proessBodyIndex;
            //((DataGridView)FindControl(_colrstGrid)).Update();
            ((EFDevGrid)FindControl(_colrstGrid)).Update();

            //nrow["FDoDepartID"] = 1;
            //throw new NotImplementedException();
        }

        /// <summary>
        /// 检测界面输入的真确性
        /// </summary>
        /// <returns></returns>
        protected Boolean CheckData()
        {
            try
            {
                Control cl = new Control();
                cl = this.FindControl("FSTARTTIME");
                DateTime FirstDay = ((DateTimePicker)cl).Value;
                cl = new Control();
                cl = this.FindControl("FENDTIME");
                DateTime LastDay = ((DateTimePicker)cl).Value;
                if (DateTime.Compare(LastDay, FirstDay) < 0)
                {
                    throw new Exception("计划开始时间大于结束时间");
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(_frm, ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
           
             
          
        }
        /// <summary>
        /// 提交新的工序计划
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butOK_Click(object sender, EventArgs e)
        {
            //获取DataTable，转XML，向服务器发送命令，获取返回结果；

            if (MessageBox.Show(_frm, "是否确定保存?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            //提取界面的数据；
            clsfrmData fdata = new clsfrmData();
            //检测数据规范
            if (CheckData() == false)
                return;
            DataTable headdt = fdata.getDataFrom(_frm, "SHIP_NO,TREE_NAME");

            long headFID = 0;

            //for (int i = 0; i < _Bodylist.Count; i++)
            //{
            //    ProjectBodyInfo bb = (ProjectBodyInfo)_Bodylist[i];
            //    DataTable bobyinfo = bb.Weld_WPS;
            //    String Fieldstr = "";
            //    for (int k = 0; k < bobyinfo.Columns.Count; k++)
            //    {
            //        Fieldstr += bobyinfo.Columns[k].ColumnName + ",";
            //    }
            //}
            //return;
            String xml="";
            if (_ProjectFID > 0)
            {
                //将原来的数据库中的记录全部删除；
                /*
                DataTable deldata = new DataTable();
                DataColumn col = new DataColumn();
                col.ColumnName = "FID";
                col.DataType = typeof(long);
                deldata.Columns.Add(col);
                DataRow delrow = deldata.NewRow();
                delrow[0] = _ProjectFID;
                deldata.Rows.Add(delrow);



                 xml= clsConvertXMLDataTable.ConvertDataTableToXML(deldata);
                sdata = new WeldServiceReference.CompositeType();
                sdata.CmdCode = cmd_delete_Project;
                sdata.weldDataTable = xml;
                sdata.RowsCount = 1;
                WeldServiceReference.CompositeType delrst = _Client.ServiceCall(sdata);
                DataTable delcallRsDT = clsConvertXMLDataTable.ConvertXMLToDataTable(delrst.weldDataTable);
                //显示结果
                if (Convert.ToBoolean(delcallRsDT.Rows[0][0]) == false)
                {
                    MessageBox.Show(delcallRsDT.Rows[0][1].ToString());
                    return;
                }
                */
                DataColumn col = new DataColumn();
                col.ColumnName = "FID";
                col.DataType = typeof(long);
                headdt.Columns.Add(col);
                headdt.Rows[0]["FID"] = _ProjectFID;

            }

            //xml = clsConvertXMLDataTable.ConvertDataTableToXML(headdt);
            //sdata = new WeldServiceReference.CompositeType();
            //sdata.CmdCode = cmd_submit_Project_head;
            //sdata.weldDataTable = xml;
            //sdata.RowsCount = 1;
            //WeldServiceReference.CompositeType rst = _Client.ServiceCall(sdata);
            //DataTable callRsDT = clsConvertXMLDataTable.ConvertXMLToDataTable(rst.weldDataTable);

            DataTable callRsDT = _Client.ServiceCall(cmd_submit_Project_head, headdt);


            //显示结果
            if (Convert.ToInt64(callRsDT.Rows[0][0]) <=0)
            {
                MessageBox.Show(callRsDT.Rows[0][1].ToString());
                return;
            }
            else
            {
                if (_ProjectFID > 0)
                {
                    headFID = _ProjectFID;
                }
                else
                {
                    headFID = Convert.ToInt64(callRsDT.Rows[0][2]);
                }
                //RuleNum,RuleFID,FID as WeldFID,SHIP_ID,SHIP_NO,BLK_NO,TREE_NAME,WELD_NO,PART1_NAME2,PART2_NAME2,AS3,BUFF1,THICK1,THICK2,WELD1_CODE,WELD2_CODE,GRADE1,GRADE2,WELD_TYPE,ASS1_NAME,WELD_ANGLE_H,ASS2_NAME,WELD_COUNT,PART1_TYPE,PART2_TYPE,TIP_ANGLE,WELD_T_LEN,WELD_NOTE,WELD_POS,WELD_MOD
                //保存表体信息；
                String noField = "RuleNum,SHIP_ID,SHIP_NO,BLK_NO,TREE_NAME,WELD_NO,PART1_NAME2,PART2_NAME2,AS3,BUFF1,THICK1,THICK2,WELD1_CODE,WELD2_CODE,GRADE1,GRADE2,WELD_TYPE,ASS1_NAME,WELD_ANGLE_H,ASS2_NAME,WELD_COUNT,PART1_TYPE,PART2_TYPE,TIP_ANGLE,WELD_T_LEN,WELD_NOTE,WELD_POS,WELD_MOD";
                
                for (int i = 0; i < _Bodylist.Count; i++)
                {
                    ProjectBodyInfo bb = (ProjectBodyInfo)_Bodylist[i];
                    DataTable bobyinfo = bb.Weld_WPS;
                    DataRow indeRow=_proessBodyIndex.Rows[i];
                    DataColumn col=new DataColumn();
                    col.ColumnName=_proessBodyIndex.Columns["FDoDepartID"].ColumnName;
                    col.DataType=_proessBodyIndex.Columns["FDoDepartID"].DataType;
                    try
                    {
                        bobyinfo.Columns.Add(col);
                    }
                    catch { }
                   col=new DataColumn();
                   col.ColumnName = "FProjectHeadID";
                   col.DataType = typeof(long);
                   try
                   {
                       bobyinfo.Columns.Add(col);
                   }
                   catch { }
                 
                   bobyinfo.Columns["FID"].ColumnName="FWELDID";
                   bobyinfo.Columns["RuleFID"].ColumnName="FWELDWPSID";


                    String Fieldstr = "";
                    for (int k = 0; k < bobyinfo.Rows.Count; k++)
                    {
                        DataRow dr=bobyinfo.Rows[k];
                        dr["FDoDepartID"]=indeRow["FDoDepartID"];
                        dr["FProjectHeadID"]=headFID;
                    }

                    //String tmpnoField = "," + noField + ",";
                    String[] strGP = noField.Split(',');
                    for (int colnum=0;colnum<strGP.Length;colnum++)
                        {
                            try
                            {
                                bobyinfo.Columns.Remove(strGP[colnum]);
                            }
                            catch { }

                        }
                    //调用远程服务器，执行插入工序计划表体；
                    DataView dv = bobyinfo.DefaultView;
                    dv.RowFilter = "FChecked=1";
                    DataTable vdt = dv.ToTable();//提取选中的焊缝数据进行保存；


                    //xml = clsConvertXMLDataTable.ConvertDataTableToXML(vdt);
                    //sdata = new WeldServiceReference.CompositeType();
                    //sdata.CmdCode = cmd_submit_Project_Body;
                    //sdata.weldDataTable = xml;
                    //long ldn = sdata.weldDataTable.Length;
                    //sdata.RowsCount = 1;
                    //rst = _Client.ServiceCall(sdata);

                    callRsDT = _Client.ServiceCall(cmd_submit_Project_Body, vdt);

                    //callRsDT = clsConvertXMLDataTable.ConvertXMLToDataTable(rst.weldDataTable);
                    //显示结果
                    //if (Convert.ToBoolean(callRsDT.Rows[0][0]) == false)
                    //{
                    //    MessageBox.Show(callRsDT.Rows[0][1].ToString());
                    //    return;
                    //}
                    //else
                    //{
                    //}



                    //String fiels="";
                    //for (int colnum=0;colnum<bobyinfo.Columns.Count;colnum++)
                    //    {
                    //       fiels+=bobyinfo.Columns[colnum].ColumnName+",";

                    //    }
                }
                
            }
            MessageBox.Show(_frm, "保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _frm.Close();
            
        }
      
        /// <summary>
        /// 焊缝WPS数据；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void but_Weld(object sender, EventArgs e)
        {
            //打开文件
            String filter = "excel filer(*.xls)|*.xls"; ;
            //this._filename=this.Openfile(_colfilename, filter);

        }
    }
}
