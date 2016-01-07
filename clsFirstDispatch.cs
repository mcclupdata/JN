using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Globalization;
using EI;
using EF;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.Repository;

namespace MC
{

    public struct _stuDispatchBodyInfo //派工单表体内容;
    {
        public long _ProjectFID;
        public String _Project_SHIP_NO;
        public String _Project_TREE_NAME;
        public String _Project_BUFF1;
        public long _Project_DoDepart;
        public DataTable _Project_WeldInfos;
        public long _DoDepartID;
        public int _delete;
        public long FOPERID;//班组ID
    }
    class clsFirstDispatch:clsFrmBase
    {

        int cmd_submit = 1004;//提交表单命令
        int cmd_ship_no = 1005;//查询得到可以分配的工程号;
        int cmd_wps = 1006;//查询得到可以匹配使用的wps
        int cmd_depart = 1007;//查询得到可以承接的部门；
        int cmd_Empty_Head = 1008;//查询得到空的表头数据;
        int cmd_Empty_body = 1009;//查询得到空表体数据；
        int cmd_Empty_DoDepartID = 1010;//查询得到部门数据；
        int cmd_get_ship_no = 2001;//获取工程号
        int cmd_get_tree_name = 2002;//依据工程号得到分段号
        int cmd_SHIP_NO_TREE_NAME_WELD = 1020;//查询的到工程号，分段号所在的所有焊缝信息;
        //int cmd_SHIP_NO_TREE_NAME_WELD = 1011;//查询的到工程号，分段号所在的所有焊缝信息;
        int cmd_GetWPS_BYFILTER = 1012;//通过查询条件得到WPS数据；
        int cmd_GetWPSTrun = 1013;//通过WPS规程编号得到焊道信息；

        int cmd_get_Head = 1014;//通过查询条件得到工序计划表头
        int cmd_get_Body = 1015;//通过查询条件得到工序计划表体;

        int cmd_get_BodyWeldInfos = 1016;//通过查询条件得到工序计划表体内的焊缝及WPS

        int cmd_FDispatch_GetProject = 1017;//查询得到可以用于派工的工序计划
        int cmd_FDispatch_GetProjectBodyIndex = 1018;//由工序计划FID查询得到工序计划体Index；

        int cmd_FDispatch_GetDopartID = 1019;//由工序计划FID查询由ProjectFID找到比工序计划定义中级别要小的部门集合
        int cmd_FDispatch_GetDispatchWeldinfos = 1021;//由ProjectFID,SHIP_NO,TREE_NAME,BUFF1的到焊缝FID和匹配的WPSID
        int cmd_FDispatch_GetSaveDispatchWeldinfos = 1022;//由ProjectFID,SHIP_NO,TREE_NAME,BUFF1得到派工计划中的焊缝FID和匹配的WPSID

        int cmd_FDispatch_GetDispatchHeadByFID=1023;//由派工单的FID获取派工单表头
        int cmd_FDispatch_GetDispatchBodyIndex=1024;//由派工单的FID获取派工单表体的Index；
        int cmd_FDispatch_Delete = 56282;//删除派工单;
        
        
        //-----6 探肺票?
        int cmd_submit_Project_head = 6014;//提交表工序计划表单--表头命令
        int cmd_submit_Dispatch_head = 6016;//提交派工单表头
        int cmd_submit_Dispatch_body = 6017;//提交派工表体
        int cmd_delete_Project = 7001;//删除工序计划表头，表体
        int cmd_delete_Dispatch = 7002;//删除派工计划；

        //---------------独有变量
        protected DataTable _ProjectHead;//工序计划
        protected DataTable _ProjectBodyInfos;//工序计划内容；
        protected DataTable _DispatchHead;//派工计划表头
        protected DataTable _DispatchBodyIndex;//派工计划表体；
        private long _DispatchHeadFID =0;
        protected DataTable _Depart_dt;
        protected long DispatchHeadFID
        {
            get { return _DispatchHeadFID; }
            set { _DispatchHeadFID = value; }
        }
        protected Boolean UpdateDispatchBodyIndex(_stuDispatchBodyInfo bb)
        {
            for (int i = 0; i < _DispatchBodyInfos.Count; i++)
            {
                _stuDispatchBodyInfo dio = (_stuDispatchBodyInfo)_DispatchBodyInfos[i];
                //dio._Project_DoDepart==dodepartid &&
                if (dio._ProjectFID == bb._ProjectFID && dio._Project_SHIP_NO ==bb._Project_SHIP_NO && dio._Project_TREE_NAME == bb._Project_TREE_NAME && dio._Project_BUFF1 ==bb._Project_BUFF1 && dio.FOPERID == bb.FOPERID)
                {
                    _DispatchBodyInfos[i] = bb;
                    return true;
                }
            }
            return false;

        }
        /// <summary>
        /// 查找派工单表体内容；
        /// </summary>
        /// <returns></returns>
        protected _stuDispatchBodyInfo FindstrDispatchBodyinfo(int DoType,long fid,String shipno,String treename,String buff1,long dodepartid,long vFOPERID)
        {
            for (int i = 0; i < _DispatchBodyInfos.Count; i++)
            {
                _stuDispatchBodyInfo dio =(_stuDispatchBodyInfo) _DispatchBodyInfos[i];
                //dio._Project_DoDepart==dodepartid &&
                if ( dio._ProjectFID == fid && dio._Project_SHIP_NO == shipno && dio._Project_TREE_NAME == treename && dio._Project_BUFF1 == buff1 && dio.FOPERID==vFOPERID)
                {
                    return dio;
                }
            }
            //创建一个新的
            if (DoType == 1)
            {
                return new _stuDispatchBodyInfo();
            }
            
            
            
            
            
            
            
            
            
            _stuDispatchBodyInfo ndio = new _stuDispatchBodyInfo() ;
            ndio._ProjectFID = fid; ndio._Project_SHIP_NO = shipno; ndio._Project_TREE_NAME = treename; ndio._Project_BUFF1 = buff1;// ndio._Project_DoDepart = dodepartid;
            ndio.FOPERID = vFOPERID;
            //得到焊缝详细信息；
            //FID=@FID and SHIP_NO=@SHIP_NO and TREE_NAME=@TREE_NAME and BUFF1=@BUFF1
            DataTable fdata = new DataTable();
            DataColumn col = new DataColumn();
            col.ColumnName = "FID";
            col.DataType = typeof(long);
            col.DefaultValue = 0;
            fdata.Columns.Add(col);
            col = new DataColumn();
            col.ColumnName = "SHIP_NO";
            col.DataType = typeof(String);
            col.MaxLength = 50;
            col.DefaultValue = 0;
            fdata.Columns.Add(col);
            col = new DataColumn();
            col.ColumnName = "TREE_NAME";
            col.DataType = typeof(String);
            col.MaxLength = 50;
            col.DefaultValue = 0;
            fdata.Columns.Add(col);
            col = new DataColumn();
            col.ColumnName = "BUFF1";
            col.DataType = typeof(String);
            col.MaxLength = 50;
            col.DefaultValue = 0;
            fdata.Columns.Add(col);
            col = new DataColumn();
            col.ColumnName = "FDoDepartID";
            col.DataType = typeof(long);
            
            col.DefaultValue = 0;


            fdata.Columns.Add(col);

            col = new DataColumn();
            col.ColumnName = "FDispatchHeadID";
            col.DataType = typeof(long);
            col.DefaultValue = 0;
            fdata.Columns.Add(col);
            col = new DataColumn();
            col.ColumnName = "FOPDEPARTID";
            col.DataType = typeof(long);
            col.DefaultValue = 0;
            fdata.Columns.Add(col);


            DataRow r = fdata.NewRow();
            r["FID"]=fid;
            r["SHIP_NO"]=shipno;
            r["TREE_NAME"]=treename;
            r["BUFF1"]=buff1;
            r["FDoDepartID"] = dodepartid;
            r["FDispatchHeadID"] = _DispatchHeadFID;
            r["FOPDEPARTID"] = vFOPERID;
            fdata.Rows.Add(r);
            //获取要进行分配给班组的焊缝数据；
            String finishweldid = "0";
            DataTable tmpweldinfos = _Client.ServiceCall(cmd_FDispatch_GetSaveDispatchWeldinfos, fdata);
             for (int k = 0; k < _DispatchBodyInfos.Count; k++)
                {
                    DataView vdv = ((_stuDispatchBodyInfo)_DispatchBodyInfos[k])._Project_WeldInfos.Copy().DefaultView;
                    vdv.RowFilter = "FChecked=1";
                    DataTable vdt = vdv.ToTable();
                    for (int kk = 0; kk < vdt.Rows.Count; kk++)
                    {
                        finishweldid += "," + vdt.Rows[kk]["FWELDID"].ToString();
                    }
                }
             DataView vwelddv = tmpweldinfos.Copy().DefaultView;

             vwelddv.RowFilter = "FWELDID NOT IN (" + finishweldid + ")";
             ndio._Project_WeldInfos = vwelddv.ToTable(); //_Client.ServiceCall(cmd_FDispatch_GetSaveDispatchWeldinfos, fdata);
            _DispatchBodyInfos.Add(ndio);
            return ndio;
        }
        protected ArrayList _DispatchBodyInfos=new ArrayList();
        public void BuildDispatchBodyIndex()
        {
            _DispatchBodyIndex = new DataTable();

            DataColumn col = new DataColumn();

            //col.ColumnName = "FID"; col.DataType = typeof(long); col.DefaultValue = 0; _DispatchBodyIndex.Columns.Add(col);
            col = new DataColumn(); col.ColumnName = "FProjectHeadID"; col.DataType = typeof(long); col.DefaultValue = 0; _DispatchBodyIndex.Columns.Add(col);
            col = new DataColumn(); col.ColumnName = "SHIP_NO"; col.DataType = typeof(String); col.DefaultValue = ""; _DispatchBodyIndex.Columns.Add(col);
            col = new DataColumn(); col.ColumnName = "TREE_NAME"; col.DataType = typeof(String); col.DefaultValue = ""; _DispatchBodyIndex.Columns.Add(col);
            col = new DataColumn(); col.ColumnName = "BUFF1"; col.DataType = typeof(String); col.DefaultValue = ""; _DispatchBodyIndex.Columns.Add(col);
            col = new DataColumn(); col.ColumnName = "FOPDEPARTID"; col.DataType = typeof(long); col.DefaultValue = 0; _DispatchBodyIndex.Columns.Add(col);
            col = new DataColumn(); col.ColumnName = "FDoDepartID"; col.DataType = typeof(long); col.DefaultValue = 0; _DispatchBodyIndex.Columns.Add(col);
            col = new DataColumn(); col.ColumnName = "FDepartName"; col.DataType = typeof(String); col.DefaultValue = ""; _DispatchBodyIndex.Columns.Add(col);
            //FParentDepartID
            col = new DataColumn(); col.ColumnName = "FParentDepartID"; col.DataType = typeof(long); col.DefaultValue = 0; _DispatchBodyIndex.Columns.Add(col);
            //col = new DataColumn(); col.ColumnName = "FEndDepartID"; col.DataType = typeof(long); col.DefaultValue = 0; _DispatchBodyIndex.Columns.Add(col);
            //col = new DataColumn(); col.ColumnName = "FDispatchState"; col.DataType = typeof(int); col.DefaultValue = 0; _DispatchBodyIndex.Columns.Add(col);
            //col = new DataColumn(); col.ColumnName = "FParentDispatchID"; col.DataType = typeof(long); col.DefaultValue = 0; _DispatchBodyIndex.Columns.Add(col);
            //col = new DataColumn(); col.ColumnName = "FEndDepartIDClass"; col.DataType = typeof(int); col.DefaultValue = 0; _DispatchBodyIndex.Columns.Add(col);
            
        }
        /// <summary>
        /// 构件派工计划表头；
        /// </summary>
        protected void BuildDispatchHead()
        {
            _DispatchHead = new DataTable();
            DataColumn col = new DataColumn();
            //FID	long
            //FProjectHeadID	String
            //FDispatchNum	String
            //FSTARTTIME	DateTime
            //FENDTIME	DateTime
            //FBeginDepartID	long
            //FEndDepartID	long
            //FFDispatchState	int
            //FParentDispatchID	long
            //FEndDepartIDClass	int
            col.ColumnName = "FID";            col.DataType=typeof(long);            col.DefaultValue=0;            _DispatchHead.Columns.Add(col);
            col = new DataColumn(); col.ColumnName = "FDispatchName"; col.DataType = typeof(String); col.DefaultValue = ""; _DispatchHead.Columns.Add(col);
            col = new DataColumn(); col.ColumnName = "FDispatchNum"; col.DataType = typeof(String); col.DefaultValue = ""; _DispatchHead.Columns.Add(col);
            col = new DataColumn(); col.ColumnName = "FDispatchSTARTTIME"; col.DataType = typeof(String); col.DefaultValue = DateTime.Now.ToShortDateString(); _DispatchHead.Columns.Add(col);
            col = new DataColumn(); col.ColumnName = "FDispatchENDTIME"; col.DataType = typeof(String); col.DefaultValue = DateTime.Now.ToShortDateString(); _DispatchHead.Columns.Add(col);
            col = new DataColumn(); col.ColumnName = "FBeginDepartID"; col.DataType = typeof(long); col.DefaultValue = 0; _DispatchHead.Columns.Add(col);
            col = new DataColumn(); col.ColumnName = "FEndDepartID"; col.DataType = typeof(long); col.DefaultValue = 0; _DispatchHead.Columns.Add(col);
            col = new DataColumn(); col.ColumnName = "FDispatchState"; col.DataType = typeof(int); col.DefaultValue = 0; _DispatchHead.Columns.Add(col);
            col = new DataColumn(); col.ColumnName = "FParentDispatchID"; col.DataType = typeof(long); col.DefaultValue = 0; _DispatchHead.Columns.Add(col);
            col = new DataColumn(); col.ColumnName = "FEndDepartIDClass"; col.DataType = typeof(int); col.DefaultValue = 0; _DispatchHead.Columns.Add(col);
        }
        public clsFirstDispatch(ref Formbase frm)
        {
            _frm = frm;
            Initialization_cls();
        }
        //public clsFirstDispatch(Formbase frm)
        //{
        //    _frm = frm;
        //}
       
        public clsFirstDispatch(long fid,ref Formbase frm)
        {
            _DispatchHeadFID = fid;
            _frm = frm;// new frmPFirstDispatch();
            Initialization_cls();
            //_frm.ShowDialog();
        }

        public Boolean Delete(long vFID)
        {
            DataTable fdt = new DataTable();
            DataColumn col = new DataColumn();
            col.ColumnName = "FID";
            col.DataType = typeof(long);
            fdt.Columns.Add(col);
            DataRow ndr = fdt.NewRow();
            ndr[0] = vFID;
            fdt.Rows.Add(ndr);
            DataTable rst=_Client.ServiceCall(cmd_FDispatch_Delete, fdt);
            MessageBox.Show(_frm, rst.Rows[0][1].ToString(), "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }
        protected void LoadDispatchHead()
        {
        }
        protected void LoadDispatchBodyIndex()
        {
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
                cl = this.FindControl("FDispatchSTARTTIME");
                DateTime FirstDay = ((EFDateTimePicker)cl).Value;
                cl = new Control();
                cl = this.FindControl("FDispatchENDTIME");


                DateTime LastDay = ((EFDateTimePicker)cl).Value;
                if (DateTime.Compare(LastDay, FirstDay) < 0)
                {
                    throw new Exception("开始时间大于结束时间");
                }
                DateTime PSTART, PEND;
                cl = new Control();
                cl = this.FindControl("FSTARTTIME");
                PSTART = Convert.ToDateTime(((EFLabelText)cl).EFEnterText);
                cl=new Control();cl=this.FindControl("FENDTIME");
                PEND = DateTime.Now;
                if (cl.GetType() == typeof(EFLabelText))
                {
                    PEND = Convert.ToDateTime(((EFLabelText)cl).EFEnterText);
                }
                if (cl.GetType() == typeof(EFTextBox))
                {
                    PEND = Convert.ToDateTime(((EFTextBox)cl).Text);
                }
                if (cl.GetType() == typeof(TextBox))
                {
                    PEND = Convert.ToDateTime(((TextBox)cl).Text);
                }
                
                if (DateTime.Compare(PSTART, FirstDay) > 0)
                {
                    throw new Exception("派工开始时间早于计划开始时间");
                }
                if (DateTime.Compare(PEND, LastDay) < 0)
                {
                    throw new Exception("派工结束时间晚于计划结束时间");
                }
                //检测派工单名称不能为空
                cl = FindControl("FDispatchName");
                if (((EFLabelText)cl).EFEnterText.Length == 0)
                {
                    throw new Exception("派工单名称不能为空");
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(_frm, ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }



        }
        /// <summary>
        /// 初始化累
        /// </summary>
        /// <returns></returns>
        protected Boolean Initialization_cls()
        {
            //获取可以使用的工序计划
           // frmPFirstDispatch frm = (frmPFirstDispatch)_frm;
            FormMCCL0006 frm = (FormMCCL0006)_frm;
            clsfrmData clsfrmdata = new clsfrmData();

            if (_DispatchHeadFID == 0)
            {
                //构件表头数据
                BuildDispatchHead();
                //构件表体Index
                BuildDispatchBodyIndex();
                //获取可以使用的工序计划信息
                
               //初始化时间
                //初始化时间范围；
                DateTime dt = DateTime.Now; 
                DateTime startWeek = dt.AddDays(1 - Convert.ToInt32(dt.DayOfWeek.ToString("d")));  //本周周一
                DateTime endWeek = startWeek.AddDays(6);  //本周周日
                Control cl = new Control();
                cl = this.FindControl("FDispatchSTARTTIME");
               
                ((DateTimePicker)cl).Value = startWeek;
                
                cl = new Control();
                cl = this.FindControl("FDispatchENDTIME");
                ((DateTimePicker)cl).Value = endWeek;
                
                //产生新的派工单编号
                cl = new Control();
                cl = this.FindControl("FDispatchNum");
                //产生工序编号；年+周+时间
                GregorianCalendar gc = new GregorianCalendar();
                int weekOfYear = gc.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
                EFLabelText ltxt = (EFLabelText)cl;
                ltxt.EFEnterText = "JN-D1-" + DateTime.Now.Year + "-" + weekOfYear.ToString() + "-" + DateTime.Now.Hour.ToString() + "-" + DateTime.Now.Minute.ToString();
                //((TextBox)cl).ReadOnly = true;
                ltxt.ReadOnly = true;
            }
            else
            {
                //编辑派工单
                //获取派工计划的表头信息
                DataTable headfdt = new DataTable();
                DataColumn col = new DataColumn();
                col.DataType = typeof(long);
                col.ColumnName = "FID";
                col.DefaultValue = 0;
                headfdt.Columns.Add(col);
                DataRow nr = headfdt.NewRow();
                nr["FID"] = _DispatchHeadFID;
                headfdt.Rows.Add(nr);
                _DispatchHead = _Client.ServiceCall(cmd_FDispatch_GetDispatchHeadByFID, headfdt);
                clsfrmdata.FillfrmData2(_DispatchHead,ref _frm,"");
                //加载派工计划的表体Index
                DataRow hearr = _DispatchHead.Rows[0];
                _DispatchHeadFID = Convert.ToInt64(hearr["FID"]);
                headfdt.Columns[0].ColumnName="FDispatchHeadID";
                ((DataRow)headfdt.Rows[0])[0]=_DispatchHeadFID;
                _DispatchBodyIndex = _Client.ServiceCall(cmd_FDispatch_GetDispatchBodyIndex,headfdt );




                //构件结构；
                for (int i = 0; i < _DispatchBodyIndex.Rows.Count; i++)
                {
                    long vdhFID; String vshipno, vtreename, vbuff1;
                    long vdd=0;
                    long vFOPDepartid = 0;
                    //FOPDEPARTID,TREE_NAME,SHIP_NO,BUFF1,FProjectHeadID
                    DataRow dbrow = _DispatchBodyIndex.Rows[i];
                    vdhFID = Convert.ToInt64(dbrow["FProjectHeadID"]);
                    vshipno = Convert.ToString(dbrow["SHIP_NO"]);
                    vtreename = Convert.ToString(dbrow["TREE_NAME"]);
                    vbuff1 = Convert.ToString(dbrow["BUFF1"]);
                    vdd=Convert.ToInt64(dbrow["FParentDepartID"]);
                    vFOPDepartid = Convert.ToInt64(dbrow["FOPDEPARTID"]);
                    _stuDispatchBodyInfo bbi = FindstrDispatchBodyinfo(0,vdhFID, vshipno, vtreename, vbuff1,vdd,vFOPDepartid);
                    _DispatchBodyInfos.Add(bbi);

                }
            }
            Control vcl=FindControl("dataGrid",_frm);
            DevExpress.XtraGrid.Views.Grid.GridView v=(GridView)((EF.EFDevGrid)vcl).Views[0];
            v.ShownEditor+=new EventHandler(v_ShownEditor);
            v.RowCellClick += new RowCellClickEventHandler(v_RowCellClick);
            //绑定部门
            DataTable vdt = new DataTable();
            DataColumn departf_cl = new DataColumn();
            departf_cl.ColumnName = "FParentID";
            departf_cl.DataType = typeof(long);
            vdt.Columns.Add(departf_cl);
            DataRow dr = vdt.NewRow();
            dr[0] = 0;
            vdt.Rows.Add(dr);

            _Depart_dt = _Client.ServiceCall(cmd_FDispatch_GetDopartID, vdt);
            //Control lookup_cl = FindControl("LookUpEdit");
            RepositoryItemLookUpEdit lookedit = (RepositoryItemLookUpEdit)v.Columns["FOPDEPARTID"].ColumnEdit;
            //绑定数据库
            DevGridView_bingLookUp(ref lookedit, _Depart_dt);

            _ProjectHead = _Client.ServiceCall(cmd_FDispatch_GetProject, null);
            EF.EFComboBox cbb = (EF.EFComboBox)FindControl("FProcessname");
            cbb.SelectedIndexChanged += FProcessname_SelectedIndexChanged;
            //绑定事件；
            cbb = new EF.EFComboBox();
            cbb = (EF.EFComboBox)FindControl("SHIP_NO");
            cbb.SelectedIndexChanged += SHIP_NO_SelectedIndexChanged;
            //绑定事件；
            cbb = new EF.EFComboBox();
            cbb = (EF.EFComboBox)FindControl("TREE_NAME");
            cbb.SelectedIndexChanged += TREE_NAME_SelectedIndexChanged;
            //FDoDepartID
            cbb = new EF.EFComboBox();
            cbb = (EF.EFComboBox)FindControl("BUFF1");
            cbb.SelectedIndexChanged += BUFF1_SelectedIndexChanged;
            //工序计划名称绑定;
            cbb = (EF.EFComboBox)FindControl("FProcessname");
            clsfrmdata.FillComboxData(_ProjectHead, "FID", "FProcessname", ref cbb);
            //添加按钮事件
            EFButton but = new EFButton();
            but = (EFButton)FindControl("butAdd");
            but.Click += butAdd_Click;
            //((DataGridView)FindControl("dataGrid")).DataError += clsFirstDispatch_DataError;
            //((DataGridView)FindControl("dataGrid")).DataSource = _DispatchBodyIndex;
            ((EF.EFDevGrid)FindControl("dataGrid")).DataSource = _DispatchBodyIndex;
            //注册GridViw按钮事件
            RepositoryItemButtonEdit but1 =(RepositoryItemButtonEdit) v.Columns["CbutDelete"].ColumnEdit;
            but1.ButtonClick += clsFirstDispatch_CellContentClick;
            //CAssign
            RepositoryItemButtonEdit but2 = (RepositoryItemButtonEdit)v.Columns["CAssign"].ColumnEdit;
            but2.ButtonClick += clsFirstDispatch_CellContentClick;

            //EF.EFDevGrid dgv = (EF.EFDevGrid)FindControl("dataGrid");
            //DevExpress.XtraGrid.Views.Grid.GridView dgv_view=(DevExpress.XtraGrid.Views.Grid.GridView)dgv.Views[0];

            //DataTable vdt = new DataTable();
            //DataColumn vcl = new DataColumn();
            //vcl.ColumnName = "FParentID";
            //vcl.DataType = typeof(long);
            //vdt.Columns.Add(vcl);
            //DataRow dr = vdt.NewRow();

            //dr[0] = 0;// Convert.ToInt64(dgv.Rows[_DispatchBodyIndex.Rows.Count - 1].Cells["CFDoDepartID"].Value);
            //vdt.Rows.Add(dr);

            for (int i = 0; i < _DispatchBodyIndex.Rows.Count; i++)
            {
                //vdt.Rows[0][0] = Convert.ToInt64(dgv_view.GetRowCellValue(i, "CFParentDepartID"));//Convert.ToInt64(dgv.Rows[i].Cells["CFParentDepartID"].Value);
                //DataGridViewComboBoxCell cmbox = (DataGridViewComboBoxCell)dgv.Rows[i].Cells["CFOPDEPARTID"];

                //DataTable candoDepart = _Client.ServiceCall(cmd_FDispatch_GetDopartID, vdt);
                //cmbox.DataSource = candoDepart;
                //cmbox.DisplayMember = "FDepartName";
                //cmbox.ValueMember = "FID";

            }
            //CbutDelete
            //((EF.EFDevGrid)FindControl("dataGrid")).AllowUserToAddRows = false;
            //v=(GridView)((EF.EFDevGrid)FindControl("dataGrid")).Views[0];

            //v.RowCellClick+= clsFirstDispatch_CellContentClick;
            
            //注册保存按钮
            EFButton butok = (EFButton)FindControl("butOK");
            butok.Click += butok_Click;
            //注册取消按钮
            EFButton butcc = (EFButton)FindControl("butCancel");
            butcc.Click += butcc_Click;
            return true;
        }

        void v_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            //throw new NotImplementedException();
        }
        /// <summary>
        /// 显示编辑器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void  v_ShownEditor(object sender, EventArgs e)
        {
 	        //throw new NotImplementedException();
            GridView efGridView = (GridView)((EFDevGrid)FindControl("dataGrid")).Views[0];

            if (efGridView.FocusedColumn.ColumnEdit !=null && efGridView.FocusedColumn.ColumnEdit.GetType() == typeof(RepositoryItemLookUpEdit))
            {
                GridView v = (GridView)sender;
                int rowindex = v.FocusedRowHandle;
                String filer = "FParentID=" + v.GetRowCellValue(rowindex, "FParentDepartID").ToString();
                DevGridView_bingLookUp_ShowEditor(ref sender, e, filer);
            }
        }

        void BUFF1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ;
            DataRowView shipnodrv = (DataRowView)((ComboBox)FindControl("SHIP_NO")).SelectedItem;
            String ship_no = Convert.ToString(shipnodrv["SHIP_NO"]);
            DataRowView treenamedrv = (DataRowView)((ComboBox)FindControl("TREE_NAME")).SelectedItem;
            String tree_name = Convert.ToString(treenamedrv["TREE_NAME"]);
            DataRowView buff1drv = (DataRowView)((ComboBox)FindControl("BUFF1")).SelectedItem;
            String buff1 = Convert.ToString(buff1drv["BUFF1"]);

            _ProjectBodyInfos.DefaultView.RowFilter = "";
            _ProjectBodyInfos.DefaultView.RowFilter = "TREE_NAME='" + tree_name + "' and SHIP_NO='" + ship_no + "' and BUFF1='"+buff1+"'";

            EF.EFComboBox cl = (EF.EFComboBox)FindControl("FDoDepartID");
            DataView dv = _ProjectBodyInfos.DefaultView;
            DataTable shipno_dt = dv.ToTable(true, new String[]{"FDoDepartID","FDepartName"});
            clsfrmData fd = new clsfrmData();
            fd.FillComboxData(shipno_dt, "FDoDepartID", "FDepartName", ref cl);
        }
        /// <summary>
        /// 取消本次操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void butcc_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }
        /// <summary>
        /// 提交派工计划
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void butok_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if (MessageBox.Show(_frm, "是否确定保存?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            if (CheckData())
            {
                //MessageBox.Show(_frm, "时间错误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_DispatchHeadFID > 0)
            {
                //删除派工单
                DataTable vd1 = new DataTable();
                DataColumn col = new DataColumn();
                col.ColumnName = "FID";
                col.DataType = typeof(long);
                vd1.Columns.Add(col);
                col = new DataColumn();
                col.ColumnName = "isEdit";
                col.DataType = typeof(int);
                vd1.Columns.Add(col);
                DataRow nr1 = vd1.NewRow();
                nr1[0] = _DispatchHeadFID;
                nr1[1] = 1;//编辑模式
                vd1.Rows.Add(nr1);
               
                //vd1 = _Client.ServiceCall(cmd_delete_Dispatch, vd1);
              //  if (Convert.ToBoolean(vd1.Rows[0][0]) == false)
               // {
               //     MessageBox.Show(vd1.Rows[0][1].ToString());
               //     return;
               // }
            }
             long vDispatchHeadID=0;
            //提取派工计划表头信息
            //clsfrmData getfrmdata = new clsfrmData();
            //getfrmdata.getDataFrom(_frm, ref _DispatchHead);
            getDataFrom(_frm, ref _DispatchHead);
            if (_DispatchHeadFID==0)
                _DispatchHead.Columns.Remove("FID");
            //保存派工计划表头；
            DataTable headrs = _Client.ServiceCall(cmd_submit_Dispatch_head, this._DispatchHead);
            if (Convert.ToBoolean(headrs.Rows[0][0]) == false)
            {
                MessageBox.Show(headrs.Rows[0][1].ToString());
                return;
            }
            else
            {
                vDispatchHeadID = Convert.ToInt64(headrs.Rows[0][2]);
            }
            if (_DispatchHeadFID != 0)
                vDispatchHeadID = _DispatchHeadFID;
            //保存派工计划表体；
            //FDispatchHeadID++
            //FWELDID
            //FWELDWPSID
            //FProjectHeadID++
            //FSTATE
            //FOPDEPARTID++
            // FOPDEPARTID ,FWELDID,FWELDWPSID ,FProjectBodyID
            for (int i = 0; i < _DispatchBodyIndex.Rows.Count; i++)
            {
                DataRow r = _DispatchBodyIndex.Rows[i];
                String vSHIP_NO="";
                long vFProjectID=0;
                String vTREE_NAME="";
                String vBUFF1="";
                long vFOPDEPARTID = 0;
                vFProjectID = Convert.ToInt64(r["FProjectHeadID"]);
                vFOPDEPARTID = Convert.ToInt64(r["FOPDEPARTID"]);
                vSHIP_NO = Convert.ToString(r["SHIP_NO"]);
                vTREE_NAME = Convert.ToString(r["TREE_NAME"]);
                vBUFF1 = Convert.ToString(r["BUFF1"]);
                long vFParentDepartID = Convert.ToInt64(r["FParentDepartID"]);
               long vdd =0;// Convert.ToInt64(r["FDoDepartID"]);
                long vFopdepartid = Convert.ToInt64(r["FOPDEPARTID"]);
                _stuDispatchBodyInfo bb = FindstrDispatchBodyinfo(1,vFProjectID,vSHIP_NO,vTREE_NAME,vBUFF1,vdd,vFopdepartid);
                if (bb._Project_WeldInfos != null)
                {
                    //删除不需要的列
                    //FOPDEPARTID ,FWELDID,FWELDWPSID ,FProjectBodyID，FOPDEPARTID
                    //必要的字段FDispatchHeadID，FWELDID，FWELDWPSID，FProjectHeadID,
                    //bb._Project_WeldInfos.Columns.Remove("FID");
                    //bb._Project_WeldInfos.Columns["FProjectBodyID"].ColumnName = "FProjectHeadID";
                    DataColumn col = new DataColumn();
                    col.ColumnName = "FDispatchHeadID";
                    col.DataType = typeof(long);
                    bb._Project_WeldInfos.Columns.Add(col);
                    col = new DataColumn();
                    col.ColumnName = "FParentDepartID";
                    col.DataType = typeof(long);
                    bb._Project_WeldInfos.Columns.Add(col);

                    //将DispatchHeadID和DoDepartID会写到DataTable
                    for (int ri = 0; ri < bb._Project_WeldInfos.Rows.Count; ri++)
                    {
                        DataRow ro = bb._Project_WeldInfos.Rows[ri];
                        ro["FOPDEPARTID"] = vFopdepartid;
                        ro["FDispatchHeadID"] = vDispatchHeadID;
                        ro["FProjectHeadID"] = vFProjectID;
                        ro["FParentDepartID"] = vFParentDepartID;
                    }
                    _Client.ServiceCall(cmd_submit_Dispatch_body, bb._Project_WeldInfos);

                }



            }


            MessageBox.Show(_frm, "保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _frm.Close();

        }
        /// <summary>
        /// 处理删除表体内容动作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void clsFirstDispatch_CellContentClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView dgv=(DevExpress.XtraGrid.Views.Grid.GridView)((EFDevGrid)FindControl("dataGrid")).Views[0];

            //int RowInex=dgv.GetSelectedRows()[0];
            int rindex = dgv.FocusedRowHandle;
            String colname = dgv.FocusedColumn.Name;
            if (colname == "CAssign")
            {
                if (Convert.IsDBNull(dgv.GetRowCellValue(rindex,"FOPDEPARTID")))
                {
                    MessageBox.Show(_frm, "请先选择班组后操作", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (Convert.ToInt32(dgv.GetRowCellValue(rindex,"FOPDEPARTID"))==0)
                {
                    MessageBox.Show(_frm, "请先选择班组后操作", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int index = 0;
                String usedweldid = "0";
                ////DataGridViewRow r = dgv.Rows[e.RowIndex];
                //GridViewInfo _viewInfo = (GridViewInfo)dgv.GetViewInfo();
                //GridDataRowInfo r = (GridDataRowInfo)_viewInfo.RowsInfo[rindex];

                _stuDispatchBodyInfo bb = FindstrDispatchBodyinfo(0, Convert.ToInt64(dgv.GetRowCellValue(rindex, "FProjectHeadID")), dgv.GetRowCellValue(rindex, "SHIP_NO").ToString(), dgv.GetRowCellValue(rindex, "TREE_NAME").ToString(), dgv.GetRowCellValue(rindex, "BUFF1").ToString(), Convert.ToInt64(dgv.GetRowCellValue(rindex,"FParentDepartID")), Convert.ToInt64(dgv.GetRowCellValue(rindex, "FOPDEPARTID")));
                String selfweldid = "0";
               
                    DataView _Project_WeldInfos_DV = bb._Project_WeldInfos.Copy().DefaultView;
                    _Project_WeldInfos_DV.RowFilter = "FChecked=1";
                    DataTable _Project_WeldInfos_DT = _Project_WeldInfos_DV.ToTable();
                    for (int kk = 0; kk < bb._Project_WeldInfos.Rows.Count; kk++)
                    {
                        selfweldid += "," + bb._Project_WeldInfos.Rows[kk]["FWELDID"].ToString();
                    }
                
                for (int k = 0; k < _DispatchBodyInfos.Count; k++)
                {
                    DataView vdv = ((_stuDispatchBodyInfo)_DispatchBodyInfos[k])._Project_WeldInfos.Copy().DefaultView;
                    vdv.RowFilter = "FChecked=1";
                    DataTable vdt = vdv.ToTable();
                    for (int kk = 0; kk < vdt.Rows.Count; kk++)
                    {
                        String vweldid = vdt.Rows[kk]["FWELDID"].ToString();
                        if (selfweldid.IndexOf(vweldid) == 0)
                            usedweldid += "," + vweldid;
                    }
                }
                bb._Project_WeldInfos.DefaultView.RowFilter = "FWELDID NOT IN (" + usedweldid + ")";
                bb._Project_WeldInfos = bb._Project_WeldInfos.DefaultView.ToTable();
                FormMCCL00014 wps_effrm = new FormMCCL00014();
                Formbase wps_frm = wps_effrm;
                clsProjectWeldDetail cls = new clsProjectWeldDetail(ref bb, wps_frm);
                wps_effrm.ShowDialog(_frm);
                UpdateDispatchBodyIndex(bb);
            }


            if (colname == "CbutDelete")
            {
               // DataGridViewRow r=dgv.Rows[e.RowIndex];
                rindex = dgv.FocusedRowHandle;
                //Boolean b = (dgv.GetRowCellValue(rindex, "CTREE_NAME"));
                String trname = Convert.IsDBNull(dgv.GetRowCellValue(rindex, "CTREE_NAME"))==false ? "" : dgv.GetRowCellValue(rindex, "CTREE_NAME").ToString();

                _stuDispatchBodyInfo bb = FindstrDispatchBodyinfo(1, Convert.ToInt64(dgv.GetRowCellValue(rindex, "FProjectHeadID")), dgv.GetRowCellValue(rindex, "SHIP_NO").ToString(), Convert.IsDBNull(dgv.GetRowCellValue(rindex, "CTREE_NAME"))==false ? "" : dgv.GetRowCellValue(rindex, "CTREE_NAME").ToString(), dgv.GetRowCellValue(rindex, "BUFF1").ToString(), Convert.ToInt64(dgv.GetRowCellValue(rindex, "FParentDepartID")), Convert.ToInt64(dgv.GetRowCellValue(rindex, "FOPDEPARTID")));
                if (Convert.IsDBNull(bb))
                    return;
                _DispatchBodyInfos.Remove(bb);
                
                //dgv.Rows.RemoveAt(e.RowIndex);
                dgv.DeleteRow(rindex);
               // _DispatchBodyIndex = (DataTable)dgv.DataSource;
                //dgv.Refresh();
                
            }
            if (colname == "CFOPDEPARTID")
            {
                long fdodepartid=0;
                DataTable dt = new DataTable();
                DataColumn col = new DataColumn();
                col.ColumnName = "FParentID";
                col.DataType = typeof(long);
                dt.Columns.Add(col);
                DataRow dr = dt.NewRow();
               // if (_DispatchHeadFID==0)
                   // dr[0] = Convert.ToInt64(dgv.Rows[e.RowIndex].Cells["CFDoDepartID"].Value);
               // else
                    dr[0] = Convert.ToInt64(dgv.GetRowCellValue(rindex,"FParentDepartID"));
                //dt.Rows.Add(dr);
                String filter="FParentID="+dr[0].ToString();
               
                //DataGridViewComboBoxCell cmbox = (DataGridViewComboBoxCell)dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
                //DataTable candoDepart = _Client.ServiceCall(cmd_FDispatch_GetDopartID, dt);
                //cmbox.DataSource = candoDepart;
                //cmbox.DisplayMember = "FDepartName";
                //cmbox.ValueMember = "FID";
                //这里需要增加下垃圾;
            }
            //throw new NotImplementedException();
        }

        void clsFirstDispatch_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //throw new NotImplementedException();
        }
        /// <summary>
        /// 增加派工计划表体信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void butAdd_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            long vProjectFID = 0;
            String vSHIP_NO = "";
            String vTREE_NAME = "";
            String vBUFF1 = "";
            Control cl = FindControl("FProcessname");
            DataRowView drw = (DataRowView)((ComboBox)cl).SelectedItem;
            vProjectFID = Convert.ToInt64(drw["FID"]);

            cl = FindControl("SHIP_NO");
            drw = (DataRowView)((ComboBox)cl).SelectedItem;
            vSHIP_NO = Convert.ToString(drw["SHIP_NO"]);

            cl = FindControl("TREE_NAME");
            drw = (DataRowView)((ComboBox)cl).SelectedItem;
            vTREE_NAME = Convert.ToString(drw["TREE_NAME"]);

            cl = FindControl("BUFF1");
            drw = (DataRowView)((ComboBox)cl).SelectedItem;
            vBUFF1 = Convert.ToString(drw["BUFF1"]);
            cl = FindControl("FDoDepartID");
            drw = (DataRowView)((ComboBox)cl).SelectedItem;
            long vdd = Convert.ToInt64(drw["FDoDepartID"]);

            //判断是否已经存在
            if (_DispatchBodyIndex.Rows.Count>0)
            {
                DataView dv = _DispatchBodyIndex.DefaultView;
                //dv.RowFilter = "FProjectHeadID=" + vProjectFID + " and SHIP_NO='" + vSHIP_NO + "' and TREE_NAME='" + vTREE_NAME + "' and BUFF1='" + vBUFF1 + "'";//and FDoDepartID="+vdd;
                dv.RowFilter = "FOPDEPARTID=0";
                DataTable vdt = dv.ToTable();
                if (vdt.Rows.Count > 0)
                {
                    dv.RowFilter = "";
                    MessageBox.Show("已经添加了");
                    return;
                }
                else
                {
                    dv.RowFilter = "";
                }
            }
            //暂时停用这段代码，修改为点击焊缝时进行分配
            /*
            _stuDispatchBodyInfo dbi = FindstrDispatchBodyinfo(vProjectFID,vSHIP_NO,vTREE_NAME,vBUFF1,vdd);
            
            _DispatchBodyInfos.Add(dbi);
             */
            DataRow nrow = _DispatchBodyIndex.NewRow();
            nrow["FProjectHeadID"] = vProjectFID;
            nrow["SHIP_NO"] = vSHIP_NO;
            nrow["TREE_NAME"] = vTREE_NAME;
            nrow["BUFF1"] = vBUFF1;
            nrow["FOPDEPARTID"] = 0;
            nrow["FDoDepartID"] = 0;
            nrow["FParentDepartID"] = vdd;
            _DispatchBodyIndex.Rows.Add(nrow);
            EF.EFDevGrid dgv = (EFDevGrid)FindControl("dataGrid");
            //((DataGridView)FindControl("dataGrid")).DataSource = _DispatchBodyIndex;
            //((DataGridView)FindControl("dataGrid")).Refresh();
            dgv.DataSource = _DispatchBodyIndex;

            //将可用部门进行绑定
            long fdodepartid = 0;
            DataTable dt = new DataTable();
            DataColumn col = new DataColumn();
            col.ColumnName = "FParentID";
            col.DataType = typeof(long);
            dt.Columns.Add(col);
            DataRow dr = dt.NewRow();
            dr[0] = 0;// Convert.ToInt64(dgv.Rows[_DispatchBodyIndex.Rows.Count - 1].Cells["CFDoDepartID"].Value);
            dt.Rows.Add(dr);
            for (int i = 0; i < _DispatchBodyIndex.Rows.Count; i++)
            {
                //这里需要增加下拉框是新建；
                //dt.Rows[0][0] = Convert.ToInt64(dgv"CFDoDepartID"].Value);
                //DataGridViewComboBoxCell cmbox = (DataGridViewComboBoxCell)dgv.Rows[i].Cells["CFOPDEPARTID"];
                //DataTable candoDepart = _Client.ServiceCall(cmd_FDispatch_GetDopartID, dt);
                //cmbox.DataSource = candoDepart;
                //cmbox.DisplayMember = "FDepartName";
                //cmbox.ValueMember = "FID";
            }

        }
        /// <summary>
        /// 分段号变化关联事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void TREE_NAME_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView drv = (DataRowView)((ComboBox)sender).SelectedItem;
            String tree_name = Convert.ToString(drv["TREE_NAME"]);
            DataRowView shipnodrv = (DataRowView)((ComboBox)FindControl("SHIP_NO")).SelectedItem;
            String ship_no = Convert.ToString(shipnodrv["SHIP_NO"]);
            _ProjectBodyInfos.DefaultView.RowFilter = "";
            _ProjectBodyInfos.DefaultView.RowFilter = "TREE_NAME='" + tree_name + "' and SHIP_NO='"+ship_no+"'";

            EF.EFComboBox cl = (EF.EFComboBox)FindControl("BUFF1");
            DataView dv = _ProjectBodyInfos.DefaultView;
            DataTable shipno_dt = dv.ToTable(true, "BUFF1");
            //clsfrmData fd = new clsfrmData();
            FillComboxData(shipno_dt, "BUFF1", "BUFF1", ref cl);
        }
        /// <summary>
        /// 工程号变化关联事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void SHIP_NO_SelectedIndexChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            DataRowView drv = (DataRowView)((ComboBox)sender).SelectedItem;
            String ship_no = Convert.ToString(drv["SHIP_NO"]);
            _ProjectBodyInfos.DefaultView.RowFilter = ""; ;
            _ProjectBodyInfos.DefaultView.RowFilter = "SHIP_NO='" + ship_no + "'";

            EF.EFComboBox cl = (EF.EFComboBox)FindControl("TREE_NAME");
            DataView dv = _ProjectBodyInfos.DefaultView;
            DataTable shipno_dt = dv.ToTable(true, "TREE_NAME");
            clsfrmData fd = new clsfrmData();
            fd.FillComboxData(shipno_dt, "TREE_NAME", "TREE_NAME", ref cl);
            

        }
        /// <summary>
        /// 工序计划变化后关联事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void FProcessname_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataRowView drv = (DataRowView)((ComboBox)sender).SelectedItem;
            long vFID = Convert.ToInt64(drv["FID"]);
            DataTable fdata = new DataTable();
            DataColumn col = new DataColumn();
            col.ColumnName = "FID";
            col.DataType = typeof(long);
            fdata.Columns.Add(col);
            DataRow vrow = fdata.NewRow();
            vrow["FID"] = vFID;
            fdata.Rows.Add(vrow);
            _Client.ServiceCall(cmd_FDispatch_GetDopartID, fdata);
            _ProjectBodyInfos = _Client.ServiceCall(cmd_FDispatch_GetProjectBodyIndex, fdata);

            EF.EFComboBox cl = (EF.EFComboBox)FindControl("SHIP_NO");
            DataView dv = _ProjectBodyInfos.DefaultView;
            DataTable shipno_dt = dv.ToTable(true, "SHIP_NO");
            clsfrmData fd = new clsfrmData();
            DataView dv_projectHead = _ProjectHead.Copy().DefaultView;
            dv_projectHead.RowFilter = "FID=" + vFID;
            DataTable dt_filterProjectHead = dv_projectHead.ToTable();
            fd.FillfrmData2(dt_filterProjectHead, ref _frm, "FID ,FProcessname");
            fd.FillComboxData(shipno_dt, "SHIP_NO", "SHIP_NO", ref cl);
            //throw new NotImplementedException();
            //绑定承接部门
            //DataGridViewComboBoxColumn cmbox = (DataGridViewComboBoxColumn)((DataGridView)FindControl("dataGrid")).Columns["CFOPDEPARTID"];
            //DataTable candoDepart = _Client.ServiceCall(cmd_FDispatch_GetDopartID, fdata);
            //cmbox.DataSource = candoDepart;
            //cmbox.DisplayMember = "FDepartName";
            //cmbox.ValueMember = "FID";

        }

    }
}
