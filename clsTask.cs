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
using DevExpress.XtraExport;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
namespace MC
{
    /// <summary>
    /// 任务单表体Index
    /// </summary>
    public struct _stuTaskBodyIndex
    {
        public long FwelderID;
        public long Fopdepartid;
        public String FSTARTTIME;
        public int delFlage;
        public DataTable Fweldinfos;
    }
    class clsTask:clsFrmBase
    {

        protected int cmd_submit = 1004;//提交表单命令
        protected int cmd_ship_no = 1005;//查询得到可以分配的工程号;
        protected int cmd_wps = 1006;//查询得到可以匹配使用的wps
        protected int cmd_depart = 1007;//查询得到可以承接的部门；
        protected int cmd_Empty_Head = 1008;//查询得到空的表头数据;
        protected int cmd_Empty_body = 1009;//查询得到空表体数据；
        protected int cmd_Empty_DoDepartID = 1010;//查询得到部门数据；
        protected int cmd_get_ship_no = 2001;//获取工程号
        protected int cmd_get_tree_name = 2002;//依据工程号得到分段号
        protected int cmd_SHIP_NO_TREE_NAME_WELD = 1020;//查询的到工程号，分段号所在的所有焊缝信息;
        //protected int cmd_SHIP_NO_TREE_NAME_WELD = 1011;//查询的到工程号，分段号所在的所有焊缝信息;
        protected int cmd_GetWPS_BYFILTER = 1012;//通过查询条件得到WPS数据；
        protected int cmd_GetWPSTrun = 1013;//通过WPS规程编号得到焊道信息；

        protected int cmd_get_Head = 1014;//通过查询条件得到工序计划表头
        protected int cmd_get_Body = 1015;//通过查询条件得到工序计划表体;

        protected int cmd_get_BodyWeldInfos = 1016;//通过查询条件得到工序计划表体内的焊缝及WPS

        protected int cmd_FDispatch_GetProject = 1017;//查询得到可以用于派工的工序计划
        protected int cmd_FDispatch_GetProjectBodyIndex = 1018;//由工序计划FID查询得到工序计划体Index；

        protected int cmd_FDispatch_GetDopartID = 1019;//由工序计划FID查询由ProjectFID找到比工序计划定义中级别要小的部门集合
        protected int cmd_FDispatch_GetDispatchWeldinfos = 1021;//由ProjectFID,SHIP_NO,TREE_NAME,BUFF1的到焊缝FID和匹配的WPSID
        protected int cmd_FDispatch_GetSaveDispatchWeldinfos = 1022;//由ProjectFID,SHIP_NO,TREE_NAME,BUFF1得到派工计划中的焊缝FID和匹配的WPSID

        protected int cmd_FDispatch_GetDispatchHeadByFID=1023;//由派工单的FID获取派工单表头
        protected int cmd_FDispatch_GetDispatchBodyIndex=1024;//由派工单的FID获取派工单表体的Index；

        protected int cmd_Task_GetDepartInfo = 1025;//获取除parentid=0之外的所有部门信息;
        protected int cmd_Task_GetDispatchBodyInfos = 1026;//获取一个月范围内的已经分配以及未分配的
        protected int cmd_Task_GetTaskInfo = 1027;//按照给定的部门，时间查询得到任务列表
        protected int cmd_Task_GetWelders = 1028;//获取全部焊工信息；

        
        //-----6 探肺票?
        protected int cmd_submit_Project_head = 6014;//提交表工序计划表单--表头命令
        protected int cmd_submit_Dispatch_head = 6016;//提交派工单表头
        protected int cmd_submit_Dispatch_body = 6017;//提交派工表体
        protected int cmd_submit_TaskList = 6018;//提交TaskList到数据库；
        protected int cmd_delete_Project = 7001;//删除工序计划表头，表体
        protected int cmd_delete_Dispatch = 7002;//删除派工计划；
        protected int cmd_delete_Task = 7003;//删除任务；

        //---------------独有变量
        protected DataTable _ProjectHead;//工序计划
        protected DataTable _ProjectBodyInfos;//工序计划内容；
        protected DataTable _DispatchHead;//派工计划表头
        protected DataTable _DispatchBodyIndex;//派工计划表体；
        private long _DispatchHeadFID =0;


        //-------Task--------------------------
        protected DataTable _Depart;//涉及的部门集合
        protected DataTable _TaskList;//任务单
        protected ArrayList _TaskIndex = new ArrayList();
        protected DataTable _Welder;//焊工信息表；
        protected DataTable _TaskIndexList;//任务单Index表
        protected ArrayList _TaskIndex_Deleted = new ArrayList();
        protected int _EditFlage = 0;//新建，1编辑 在编辑状态不允许增加，只能编辑一个焊工的任务。
        protected long _Edit_WelderID = 0;//焊工内码
        protected String _Edit_TaskDate = "";//焊工任务时间
        protected long DispatchHeadFID
        {
            get { return _DispatchHeadFID; }
            set { _DispatchHeadFID = value; }
        }
       
        public clsTask(ref Formbase frm)
        {
            
            //_frm = new frmTask();
            _frm = frm;
            Initialization_cls();
            //_frm.MdiParent = parentfrm;
            //_frm.Show();
            //_frm.WindowState = FormWindowState.Maximized;

        }
        public clsTask()
        {
        }
        public clsTask(int veditflage, ref Formbase frm)
        {
            _EditFlage = veditflage;
            //_Edit_TaskDate = vtaskDate;
            //_Edit_WelderID = vwelderID;
            _frm =frm;// new frmTask();
            Initialization_cls();
            //Initialization_Edit();
            //_frm.MdiParent = parentfrm;
            //_frm.Show();
            //_frm.WindowState = FormWindowState.Maximized;
        }
        public clsTask(int veditflage,ref Formbase frm,long vwelderID,String vtaskDate)
        {
            _EditFlage = veditflage;
            _Edit_TaskDate = vtaskDate;
            _Edit_WelderID = vwelderID;
            _frm =frm ;// new frmTask();
            //Initialization_cls();
            Initialization_Edit();
           //_frm.MdiParent = parentfrm;
           // _frm.Show();
           // _frm.WindowState = FormWindowState.Maximized;
        }
        protected Boolean Initialization_Edit()
        {
            //获取组织结构
            EFDevGrid dataGrid = (EFDevGrid)FindControl("dataGrid");
            GridView efGridView = (GridView)dataGrid.Views[0];

            _Depart = _Client.ServiceCall(cmd_Task_GetDepartInfo, null);
            //获取焊工信息
            _Welder = _Client.ServiceCall(cmd_Task_GetWelders, null);

            //过滤得到一个焊工
            DataView welderDV = _Welder.DefaultView;
            welderDV.RowFilter = "FID=" + _Edit_WelderID;
            _Welder = welderDV.ToTable();


            //绑定到部门Combox中
            EFComboBox work = (EFComboBox)FindControl("WorkGroup");
            

            DataView dv = _Depart.Copy().DefaultView;
            //绑定班组到Comboxh中
            EFComboBox classcbo = (EFComboBox)FindControl("ClassGroup");
            DataView clsdv = _Depart.Copy().DefaultView;
            long classid = Convert.ToInt64(_Welder.Rows[0]["Fdepart"]);
            clsdv.RowFilter = "Flevel=2 and FID=" + _Welder.Rows[0]["Fdepart"].ToString();
            DataTable clsworkdt = clsdv.ToTable();
            classcbo.DataSource = clsworkdt;
            classcbo.DisplayMember = "FDepartName";
            classcbo.ValueMember = "FID";
            classcbo.Refresh();
            classcbo.SelectedIndex = 0;
         
            //找到焊工所在的部门ID
            dv.RowFilter = "Flevel=1 and FID=" + clsworkdt.Rows[0]["FParentID"].ToString();
            DataTable workdt = dv.ToTable();
            work.DataSource = workdt;
            work.DisplayMember = "FDepartName";
            work.ValueMember = "FID";
            work.SelectedIndex = 0;
            //绑定显示焊工的内容
            EFComboBox weldercbo = (EFComboBox)FindControl("WelderGroup");
            weldercbo.DataSource = _Welder;
            weldercbo.DisplayMember = "FName";
            weldercbo.ValueMember = "FID";
          
            weldercbo.SelectedIndex = 0;
            //禁止显示添加按钮
            EFButton butAdd = (EFButton)FindControl("butAdd");
            butAdd.Visible = false;
            //初始化该焊工的任务内容；
            _TaskList = _Client.ServiceCall(cmd_Task_GetDispatchBodyInfos, null);
            DataTable tmp = _TaskList.Copy();
            DataView tmpdv = tmp.DefaultView;
            String vfstr =  "FTasked=1 and FWelderID={0} and FDispatchSTARTTIME=#{1}# and FDispatchENDTIME=#{1}# ";
            //_Edit_WelderID
            vfstr = String.Format(vfstr, _Edit_WelderID, _Edit_TaskDate);

            tmpdv.RowFilter =vfstr ;//"FTasked=1 and FWelderID={0} and FDispatchSTARTTIME=#{1}# and FDispatchENDTIME=#{1}# ";
            _TaskIndexList = tmpdv.ToTable(true, new string[] { "WeldCount", "FwelderID", "FwelderName", "FDepartName", "FDispatchSTARTTIME", "FOPDEPARTID" }).Copy();
            EFDevGrid dvg = (EFDevGrid)FindControl("dataGrid");
            //GridView efGridView = (GridView)dvg.Views[0];
            dvg.DataSource = _TaskIndexList;

            if (_TaskIndexList.Rows.Count > 0)
            {
                
                for (int i = 0; i < _TaskIndexList.Rows.Count; i++)
                {
                    String str = Convert.ToDateTime(_TaskIndexList.Rows[i]["FDispatchSTARTTIME"]).ToString("yyyy-MM-dd");
                    Control vtl = FindControl("FSTARTTIME");
                    ((EFDateTimePicker2)vtl).Value = Convert.ToDateTime(_TaskIndexList.Rows[i]["FDispatchSTARTTIME"]);
                    _TaskIndexList.Rows[i]["FDispatchSTARTTIME"] = str;
                    _stuTaskBodyIndex bb = FindTaskIndex(Convert.ToInt64(_TaskIndexList.Rows[i]["FwelderID"]), Convert.ToString(_TaskIndexList.Rows[i]["FDispatchSTARTTIME"]), Convert.ToInt64(_TaskIndexList.Rows[i]["FOPDEPARTID"]));
                }

            }
            //注册选择焊缝按钮事件;
            //dvg.CellContentClick += dataGrid_CellContentClick;
            //efGridView.RowCellClick += dataGrid_CellContentClick;
            //dvg.DataError += dataGrid_DataError;
            //注册保存按钮
            RepositoryItemButtonEdit butd = (RepositoryItemButtonEdit)efGridView.Columns["CBUTDELETE"].ColumnEdit;
            butd.ButtonClick += dataGrid_CellContentClick;
            RepositoryItemButtonEdit buta = (RepositoryItemButtonEdit)efGridView.Columns["CCWELD"].ColumnEdit;
            buta.ButtonClick += dataGrid_CellContentClick;
            EFButton butok = (EFButton)FindControl("butOK");
            butok.Click += butok_Click;

            return true;
        }

        /// <summary>
        /// 初始化累
        /// </summary>
        /// <returns></returns>
        protected Boolean Initialization_cls()
        {
            EFDevGrid dataGrid = (EFDevGrid)FindControl("dataGrid");
            GridView efGridView = (GridView)dataGrid.Views[0];

            //获取组织结构
            _Depart = _Client.ServiceCall(cmd_Task_GetDepartInfo, null);
            //获取焊工信息
            _Welder = _Client.ServiceCall(cmd_Task_GetWelders, null);
      
            //绑定到部门Combox中
            EFComboBox work = (EFComboBox)FindControl("WorkGroup");
            DataView dv = _Depart.DefaultView;
            dv.RowFilter = "Flevel=1";
            DataTable workdt = dv.ToTable();
            work.DataSource = workdt;
            work.DisplayMember = "FDepartName";
            work.ValueMember = "FID";
            work.SelectedIndexChanged += work_SelectedIndexChanged;
            work_SelectedIndexChanged(work, null);
            EFComboBox classcbo = (EFComboBox)FindControl("ClassGroup");
            classcbo.SelectedIndexChanged += classcbo_SelectedIndexChanged;
            classcbo_SelectedIndexChanged(classcbo, null);
            EFComboBox weldercbo = (EFComboBox)FindControl("WelderGroup");
            weldercbo.SelectedIndexChanged += weldercbo_SelectedIndexChanged;
            weldercbo_SelectedIndexChanged(weldercbo, null);
            //注册增加按钮事件
            EFButton butAdd = (EFButton)FindControl("butAdd");
            butAdd.Click += butAdd_Click;
            //获取待分配的任务
            String tes="";
            _TaskList = _Client.ServiceCall(cmd_Task_GetDispatchBodyInfos,null);
            //for (int ii=0;ii<_TaskList.Columns.Count;ii++)
            //{
            //    tes += _TaskList.Columns[ii].ColumnName;
            //}
            DataTable tmp = _TaskList.Copy();
            DataView tmpdv = tmp.DefaultView;
            //产生TaskIndexList；
            if (_EditFlage == 0)
            {
                //新建
                tmpdv.RowFilter = "FwelderID=-1";
            }
            else
            {
                //编辑
                tmpdv.RowFilter = "FwelderID<>0";
            }
            
            
            //FWelderID,FWeldName,FDepartName,FDispatchSTARTTIM
            _TaskIndexList = tmpdv.ToTable(true, new string[] { "WeldCount","FwelderID", "FwelderName", "FDepartName", "FDispatchSTARTTIME", "FOPDEPARTID" }).Copy();
            EFDevGrid dvg = (EFDevGrid)FindControl("dataGrid");
            GridView EFGridView = (GridView)dvg.Views[0];
            dvg.DataSource = _TaskIndexList;
            if (_TaskIndexList.Rows.Count > 0)
            {
                for (int i = 0; i < _TaskIndexList.Rows.Count; i++)
                {
                    String str = Convert.ToDateTime(_TaskIndexList.Rows[i]["FDispatchSTARTTIME"]).ToString("yyyy-MM-dd");
                    _TaskIndexList.Rows[i]["FDispatchSTARTTIME"] = str;
                    _stuTaskBodyIndex bb = FindTaskIndex(Convert.ToInt64(_TaskIndexList.Rows[i]["FwelderID"]), Convert.ToString(_TaskIndexList.Rows[i]["FDispatchSTARTTIME"]), Convert.ToInt64(_TaskIndexList.Rows[i]["FOPDEPARTID"]));
                }

            }
            //注册选择焊缝按钮事件;
            //dvg.CellContentClick += dataGrid_CellContentClick;
            //EFGridView.RowCellClick += dataGrid_CellContentClick;// new RowCellClickEventHandler(EFGridView_RowCellClick);
            RepositoryItemButtonEdit butd = (RepositoryItemButtonEdit)efGridView.Columns["CBUTDELETE"].ColumnEdit;
            butd.ButtonClick += dataGrid_CellContentClick;
            RepositoryItemButtonEdit buta = (RepositoryItemButtonEdit)efGridView.Columns["CCWELD"].ColumnEdit;
            buta.ButtonClick += dataGrid_CellContentClick;
            
            //dvg.DataError += dataGrid_DataError;
            //注册保存按钮
            EFButton butok = (EFButton)FindControl("butOK");
            butok.Click+=butok_Click;
            return false;
                        
        }

       
        //void dataGrid_DataError(object sender,  EFDevGridDataErrorEventArgs e)
        //{
        //    //throw new NotImplementedException();
        //}
        /// <summary>
        /// 点击焊缝按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void dataGrid_CellContentClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            GridView dgv = (GridView)((EFDevGrid)FindControl("dataGrid")).Views[0];
            int rindex = dgv.FocusedRowHandle;
            String bName = dgv.FocusedColumn.Name;


            if (bName == "CCWELD")
            {
                long vwelderid = Convert.ToInt64(dgv.GetRowCellValue(rindex, "FWelderID"));// dgv.Rows[e.RowIndex].Cells["CFWelderID"].Value);
                String vStarttime = Convert.ToString(dgv.GetRowCellValue(rindex, "FDispatchSTARTTIME"));//dgv.Rows[e.RowIndex].Cells["CFSTARTTIME"].Value);
                long vwelderpartid = Convert.ToInt64(dgv.GetRowCellValue(rindex, "FOPDEPARTID"));//dgv.Rows[e.RowIndex].Cells["CFDepart"].Value);
                String vweldername = Convert.ToString(dgv.GetRowCellValue(rindex, "FDepartName"));//dgv.Rows[e.RowIndex].Cells["CFDepartName"].Value);
                _stuTaskBodyIndex bb = FindTaskIndex(vwelderid, vStarttime, vwelderpartid);

                clsTaskWeldDetail cls = new clsTaskWeldDetail(ref bb, _frm, vweldername,vwelderid);

                int cc = GetFinishTaskCount(bb);
                dgv.SetRowCellValue(rindex, "WeldCount", cc);// dgv.Rows[e.RowIndex].Cells["CWeldCount"].Value = cc;
                UpDateTaskIndex(bb);
                //更新
                

            }
            //执行删除任务
            if (bName == "CBUTDELETE")
            {
                long vwelderid = Convert.ToInt64(dgv.GetRowCellValue(rindex, "FWelderID"));//dgv.Rows[e.RowIndex].Cells["CFWelderID"].Value);
                String vStarttime = Convert.ToString(dgv.GetRowCellValue(rindex, "FSTARTTIME"));//dgv.Rows[e.RowIndex].Cells["CFSTARTTIME"].Value);
                long vwelderpartid = Convert.ToInt64(dgv.GetRowCellValue(rindex, "FDepart"));//dgv.Rows[e.RowIndex].Cells["CFDepart"].Value);
                String vweldername = Convert.ToString(dgv.GetRowCellValue(rindex, "FDepartName"));//dgv.Rows[e.RowIndex].Cells["CFDepartName"].Value);

                for (int i = 0; i < _TaskIndexList.Rows.Count; i++)
                {
                    DataRow row=_TaskIndexList.Rows[i];
                    if (Convert.ToInt64(row["FWelderID"]) == vwelderid && Convert.ToString(row["FDispatchSTARTTIME"]) == vStarttime)
                    {
                        _TaskIndexList.Rows.Remove(row);
                    }
                }


                dgv.RefreshData();

                _stuTaskBodyIndex bb = FindTaskIndex(vwelderid, vStarttime, vwelderpartid);
                _TaskIndex_Deleted.Add(bb);
                _TaskIndex.Remove(bb);
                //更新


            }
            //throw new NotImplementedException();
        }
        /// <summary>
        /// 更新TaskIndex结构体
        /// </summary>
        /// <param name="bb"></param>
        /// <returns></returns>
        protected Boolean UpDateTaskIndex(_stuTaskBodyIndex bb)
        {
            for (int i = 0; i < _TaskIndex.Count; i++)
            {
                _stuTaskBodyIndex stu1 = (_stuTaskBodyIndex)_TaskIndex[i];
                if (stu1.Fopdepartid == bb.Fopdepartid && stu1.FwelderID ==bb.FwelderID && stu1.FSTARTTIME == bb.FSTARTTIME)
                {
                    _TaskIndex.Remove(stu1);
                    _TaskIndex.Add(bb);
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 查找TaskIndex结构体
        /// </summary>
        /// <param name="vwelderid"></param>
        /// <param name="vstarttime"></param>
        /// <param name="vopdepartid"></param>
        /// <returns></returns>
        protected _stuTaskBodyIndex FindTaskIndex(long vwelderid,String vstarttime,long vopdepartid )
        {
            if (vstarttime.Length == 0)
                vstarttime = DateTime.Now.ToShortDateString();
            DateTime ds = Convert.ToDateTime(vstarttime);

            vstarttime = ds.ToString("yyyy-MM-dd");

            for (int i = 0; i < _TaskIndex.Count; i++)
            {
                _stuTaskBodyIndex stu1 =(_stuTaskBodyIndex) _TaskIndex[i];
                if (stu1.Fopdepartid == vopdepartid && stu1.FwelderID == vwelderid && stu1.FSTARTTIME == vstarttime)
                {
                    return stu1;
                }
            }
            //创建一个新的TaskIndex；
            _stuTaskBodyIndex nstu = new _stuTaskBodyIndex();
            nstu.Fopdepartid = vopdepartid;
            nstu.FSTARTTIME = vstarttime;
            nstu.FwelderID = vwelderid;
            //加载可用的焊缝信息 FOPDEPARTID FSTARTTIME
            DataTable tmpt = _TaskList.Copy();

            //_TaskList.DefaultView.RowFilter = "";
            DataView tasklistdv = tmpt.DefaultView;
            String taskedWeldid = "0";
            for (int i = 0; i < _TaskIndex.Count; i++)
            {
                _stuTaskBodyIndex stu2 = (_stuTaskBodyIndex)_TaskIndex[i];
                DataTable dt1 = stu2.Fweldinfos;
                for (int k = 0; k < dt1.Rows.Count; k++)
                {
                    if (Convert.ToInt32(dt1.Rows[k]["FTasked"]) == 1)
                    {
                        taskedWeldid +=","+ dt1.Rows[k]["FweldID"] ;
                    }
                }
                
               
            }
           // vstarttime = "2015/5/10";
           
            //tasklistdv.RowFilter = "";
            //nstu.Fweldinfos = tasklistdv.ToTable().Copy();
            String rowfilter = "";
            //if (_EditFlage == 1)
            //{//编辑模式
                rowfilter = "FweldID not in ({0}) and FOPDEPARTID={1} and  FDispatchSTARTTIME<=#{2}#  and FDispatchENDTIME>=#{3}# and (FwelderID={4} or FWelderID=0)";
                rowfilter = string.Format(rowfilter, taskedWeldid, vopdepartid, vstarttime, vstarttime,vwelderid);
                tasklistdv.RowFilter = "";
            //}
            //else
            //{//创建模式
            //    rowfilter = "FweldID not in ({0}) and FOPDEPARTID={1} and  FDispatchSTARTTIME<=#{2}#  and FDispatchENDTIME>=#{3}#";
            //    rowfilter = string.Format(rowfilter, taskedWeldid, vopdepartid, vstarttime, vstarttime);
            //    tasklistdv.RowFilter = "";
            //}
            //rowfilter = "FweldID not in ("+taskedWeldid+") and FOPDEPARTID="+vopdepartid+" and  FDispatchSTARTTIME<=#"+vstarttime+"#  and FDispatchENDTIME>=#"+vstarttime+"#";
            tasklistdv.RowFilter = rowfilter;
            

            nstu.Fweldinfos = tasklistdv.ToTable();
            tasklistdv.RowFilter = "";
            _TaskIndex.Add(nstu);
            return nstu;

        }
        /// <summary>
        /// 增加一个焊工的本日任务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void butAdd_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //得到焊工FID，和任务计划时间；
            long welderid = 0;
            long welderdepart = 0;
            String weldername = "";
            String welderDepartname = "";
            String strTime = "";


            EFComboBox weldcbo = (EFComboBox)FindControl("WelderGroup");
            DataRowView welderdrv = (DataRowView)weldcbo.SelectedItem;
            
            welderid = Convert.ToInt64(welderdrv["FID"]);
            weldername = Convert.ToString(welderdrv["Fname"]);

           //通过过滤的到部门
            EFComboBox departcbo = (EFComboBox)FindControl("ClassGroup");
            DataRowView departdv = (DataRowView)departcbo.SelectedItem;
            welderdepart = Convert.ToInt64(departdv["FID"]);
            welderDepartname = Convert.ToString(departdv["FDepartName"]);


            //获取日期
            EFDateTimePicker2 dtp = (EFDateTimePicker2)FindControl("FSTARTTIME");
            strTime = dtp.Value.ToShortDateString();

            //----新思路

            DataView taskindexlist_dv =_TaskIndexList.DefaultView;
          
            //--查找是否存在
            taskindexlist_dv.RowFilter = " FWelderID=" + welderid + " and FDispatchSTARTTIME='" + strTime + "' and FDispatchSTARTTIME='" + strTime + "'";
            DataTable dt = taskindexlist_dv.ToTable(true, new string[] { "WeldCount","FwelderID", "FwelderName", "FDepartName", "FDispatchSTARTTIME", "FOPDEPARTID" }).Copy();
            if (dt.Rows.Count == 0)
            {
                //进行添加
                
                DataRow row = _TaskIndexList.NewRow();
                row["FWelderID"] = welderid;
                row["FwelderName"] = weldername;
                row["FDepartName"] = welderDepartname;
                row["FDispatchSTARTTIME"] = strTime;
                row["FOPDEPARTID"] = welderdepart;
                

                _stuTaskBodyIndex bb = FindTaskIndex(welderid, strTime, welderdepart);
                int cc = GetFinishTaskCount(bb);
                row["WeldCount"] = cc;
                _TaskIndexList.Rows.Add(row);
                EFDevGrid dgv = (EFDevGrid)FindControl("dataGrid");
                taskindexlist_dv.RowFilter = "";
                dgv.DataSource = _TaskIndexList;
                dgv.Refresh();
                


            }
            else
            {
                MessageBox.Show("已经分配任务了");
            }



        }
        protected int GetFinishTaskCount(_stuTaskBodyIndex bb)
        {
            DataView dv= bb.Fweldinfos.DefaultView;
            dv.RowFilter = "FTasked=" + 1;
            DataTable dt = dv.ToTable();
            int cc = dt.Rows.Count;
            dv.RowFilter = "";
            return cc;
        }
        /// <summary>
        /// 焊工选择确定后加载 如果是编辑状态，则加载该焊工在该时间点的TaskList
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void weldercbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }
        /// <summary>
        /// 作业区选择变化；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void work_SelectedIndexChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            //找到符合条件的作业区所包含的班组
            EFComboBox workcl = (EFComboBox)sender;
            DataRowView workdrw = (DataRowView)workcl.SelectedItem;
            long workid = Convert.ToInt64(workdrw["FID"]);
            //查找工作区为workid的班组
            DataView classdw = _Depart.DefaultView;
            classdw.RowFilter = "FParentID=" + workid;
            DataTable classdt = classdw.ToTable(true, new String[] { "FDepartName", "FID" });
            EFComboBox classcbo = (EFComboBox)FindControl("ClassGroup");
            //classcbo.SelectedIndexChanged += classcbo_SelectedIndexChanged;
            classcbo.DataSource = classdt;
            classcbo.DisplayMember = "FDepartName";
            classcbo.ValueMember = "FID";
            //classcbo.SelectedIndexChanged += classcbo_SelectedIndexChanged;

        }
        /// <summary>
        /// 班组关联变化到焊工；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void classcbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            EFComboBox classcbo = (EFComboBox)sender;
            //获取班组的ID
            DataRowView classdrv = (DataRowView)classcbo.SelectedItem;
            long classid = Convert.ToInt64(classdrv["FID"]);
            //过滤焊工信息得到焊工列表到EFComboBox
            DataView welderdv = _Welder.DefaultView;
            welderdv.RowFilter = "fdepart=" + classid;
            DataTable welderdt = welderdv.ToTable(true, new String[] { "FName", "FID" });
            EFComboBox weldercbo = (EFComboBox)FindControl("WelderGroup");
            weldercbo.DataSource = welderdt;
            weldercbo.DisplayMember = "FName";
            weldercbo.ValueMember = "FID";

        }

        void BUFF1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ;
            DataRowView shipnodrv = (DataRowView)((EFComboBox)FindControl("SHIP_NO")).SelectedItem;
            String ship_no = Convert.ToString(shipnodrv["SHIP_NO"]);
            DataRowView treenamedrv = (DataRowView)((EFComboBox)FindControl("TREE_NAME")).SelectedItem;
            String tree_name = Convert.ToString(treenamedrv["TREE_NAME"]);
            DataRowView buff1drv = (DataRowView)((EFComboBox)FindControl("BUFF1")).SelectedItem;
            String buff1 = Convert.ToString(buff1drv["BUFF1"]);

            _ProjectBodyInfos.DefaultView.RowFilter = "";
            _ProjectBodyInfos.DefaultView.RowFilter = "TREE_NAME='" + tree_name + "' and SHIP_NO='" + ship_no + "' and BUFF1='"+buff1+"'";

            EFComboBox cl = (EFComboBox)FindControl("FDoDepartID");
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
        public Boolean DeleteTask(long vwelderid, String starttime)
        {
            DataTable fdt = new DataTable();
            DataColumn col = new DataColumn();
            col.ColumnName = "FDispatchSTARTTIME";
            col.DataType = typeof(String);
            fdt.Columns.Add(col);
            col = new DataColumn();
            col.ColumnName = "FWELDERID";
            col.DataType=typeof(long);
            fdt.Columns.Add(col);
            DataRow dro = fdt.NewRow();
            dro["FWELDERID"] = vwelderid;
            dro["FDispatchSTARTTIME"] = starttime;
            fdt.Rows.Add(dro);
            DataTable rsdt = _Client.ServiceCall(cmd_delete_Task, fdt);
            return true;
        }
        /// <summary>
        /// 提交派工计划
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void butok_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(_frm, "是否确定保存?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            DataTable rsdt;
            for (int i = 0; i < _TaskIndex_Deleted.Count; i++)
            {
                _stuTaskBodyIndex bb = (_stuTaskBodyIndex)_TaskIndex_Deleted[i];
                DataTable data = bb.Fweldinfos;
                DataView dv = data.DefaultView;
                dv.RowFilter = "FTasked=1";
                DataTable ndata = dv.ToTable();
                for (int ii = 0; ii < ndata.Rows.Count; ii++)
                {
                    ndata.Rows[ii]["FWelderID"] = bb.FwelderID;
                    ndata.Rows[ii]["FDispatchSTARTTIME"] = bb.FSTARTTIME;
                }
                rsdt = _Client.ServiceCall(cmd_delete_Task, ndata);
                //rsdt = _Client.ServiceCall(cmd_submit_TaskList, ndata);
            }
            for (int i = 0; i < _TaskIndex.Count; i++)
            {
                _stuTaskBodyIndex bb=(_stuTaskBodyIndex)_TaskIndex[i];
                EFDevGrid datagrid=(EFDevGrid)FindControl("dataGrid");
                DataView grid_dv = ((DataTable)datagrid.DataSource).Copy().DefaultView;
                grid_dv.RowFilter = "FWelderID=" + bb.FwelderID;
                DataTable grid_dt = grid_dv.ToTable();
                DataTable data = bb.Fweldinfos;
                DataView dv = data.DefaultView;
                dv.RowFilter = "FTasked=1";
                DataTable ndata = dv.ToTable();
                for (int ii = 0; ii < ndata.Rows.Count;ii++)
                {
                    ndata.Rows[ii]["FWelderID"] = bb.FwelderID;
                    ndata.Rows[ii]["FDispatchSTARTTIME"] = grid_dt.Rows[0]["FDispatchSTARTTIME"];
                }
                //在服务器端修改插入、编辑、更新模式
                //rsdt = _Client.ServiceCall(cmd_delete_Task, ndata);
                rsdt = _Client.ServiceCall(cmd_submit_TaskList, ndata);
            }
            MessageBox.Show(_frm, "保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _frm.Close();
        }
        /// <summary>
        /// 处理删除表体内容动作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void clsFirstDispatch_CellContentClick(object sender, RowCellClickEventArgs e)
        {
            EFDevGrid dgv=(EFDevGrid)sender;

            if (e.Column.Name == "CbutDelete")
            {
                
            }
            if (e.Column.Name == "CFOPDEPARTID")
            {
              
            }
            //throw new NotImplementedException();
        }

        //void clsFirstDispatch_DataError(object sender, EFDevGridDataErrorEventArgs e)
        //{
        //    //throw new NotImplementedException();
        //}
        /// <summary>
        /// 增加派工计划表体信息
        

    }
}
