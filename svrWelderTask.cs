using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections;

namespace JN_WELD_Service

{
    /// <summary>
    /// 处理焊工进行现场操作
    /// </summary>
    class svrWelderTask:_clsdb
    {
        /// <summary>
        /// 获取历史的监控数据；
        /// </summary>
        /// <param name="dt">FID 是任务的FID</param>
        /// <returns></returns>
        public DataTable GetHistoryRealInfos(DataTable dt)
        {
            String sql="select * from t_panasonicDriRecord ";
                    sql+=" inner join t_TaskListBody on t_panasonicDriRecord.nom=t_TaskListBody.FweldDriverID ";
                    sql+=" and t_panasonicDriRecord.channel=t_TaskListBody.FweldDriverTRUNID ";
                   sql+=" and t_panasonicDriRecord.nowtime>=t_TaskListBody.FActOpStartTime and t_panasonicDriRecord.nowtime<=FActOpEndTime ";
                    sql += " and t_TaskListBody.FID=@FID order by nowtime";
                    long fid = Convert.ToInt32(dt.Rows[0]["FID"]);
                    ArrayList sqlparas = new ArrayList();
                    SqlParameter pa = new SqlParameter();
                    pa.ParameterName = "@FID";
                    pa.SqlDbType = SqlDbType.BigInt;
                    pa.SqlValue = fid;
                    sqlparas.Add(pa);
                    return _sqldbhelper.ExecuteDataTable(sql, sqlparas);
        }
        /// <summary>
        /// 通过t_TaskListBody的FID获取详细的焊缝+焊道信息表
        /// </summary>
        /// <param name="fdata">FID</param>
        /// <returns></returns>
        public DataTable GetWelderWeldWithWPSInfoByFID_UNDIS(DataTable fdata)
        {
            DataTable rst;
            //获取FID
            long vFID = 0;
            vFID = Convert.ToInt64(fdata.Rows[0]["FWELDID"]);
            String sql = "select FID,FWelderID,FSTARTTIME,FName,Fnum,PART1_NAME2,PART2_NAME2,WELD_PASS,WELD_PASS_ATTRIB,WELD_MOD,WELD_MATERIAL,WELD_I_MAX,WELD_I_MIN,WELD_V_MAX,WELD_V_MIN from View_Task_Welder_ALL";
            sql += " where FWELDID=" + vFID;
            String selSQL = "";
            selSQL+=" select 0  as FID,0 as FWelderID,'' as FSTARTTIME,'' as FName,'' as Fnum,PART1_NAME2,PART2_NAME2,WELD_PASS,WELD_PASS_ATTRIB ";
            selSQL+=" ,t_wps_WELDTUN.WELD_MOD,t_wps_WELDTUN.WELD_MATERIAL,WELD_I_MAX,WELD_I_MIN,WELD_V_MAX,WELD_V_MIN  ";
            selSQL+=" from t_DispatchingBody  ";
            selSQL+=" inner join t_wps_RULE on t_wps_RULE.FID=t_DispatchingBody.FWELDWPSID ";
            selSQL+=" inner join t_wps_WELDTUN on t_wps_RULE.RuleNum=t_wps_WELDTUN.RuleNum ";
            selSQL += " inner join t_WELD on t_WELD.FID=t_DispatchingBody.FWELDID ";
            selSQL += " where t_DispatchingBody.FWELDID=" + vFID;


            rst = _sqldbhelper.ExecuteDataTable(selSQL);
            return rst;
        }
        /// <summary>
        /// 通过t_TaskListBody的FID获取详细的焊缝+焊道信息表
        /// </summary>
        /// <param name="fdata">FID</param>
        /// <returns></returns>
        public DataTable GetWelderWeldWithWPSInfoByFID(DataTable fdata)
        {
            DataTable rst;
            //获取FID
            long vFID = 0;
            vFID = Convert.ToInt64(fdata.Rows[0]["FWELDID"]);
            String sql = "select FID,FWelderID,FSTARTTIME,FName,Fnum,PART1_NAME2,PART2_NAME2,WELD_PASS,WELD_PASS_ATTRIB,WELD_MOD,WELD_MATERIAL,WELD_I_MAX,WELD_I_MIN,WELD_V_MAX,WELD_V_MIN from View_Task_Welder_ALL";
            sql+=" where FWELDID="+vFID;
            rst=_sqldbhelper.ExecuteDataTable(sql);
            return rst;
        }

        /// <summary>
        /// 加载班组未分配的焊缝集合
        /// </summary>
        /// <param name="fdt"> Fnum 焊工工号，班组ID</param>
        /// <returns></returns>
        public DataTable GetUnDispTaskList(DataTable fdt)
        {
            String selSQL = "";
            selSQL+="select 0 as Ftype, 0 as FID, 0 as FDispatchBodyID, null  as FActOpStartTime, null as FActOpEndTime,'0' as FweldDriverID,0 as FSTATE ";
            selSQL+=", T6.FID as FWelderID ,T1.FWELDID, T1.FWELDWPSID ,0 as FWPSTRUNID ,GETDATE() as FSTARTTIME ";
            //selSQL+=", @welderid as FWelderID ,T1.FWELDID, T1.FWELDWPSID ,0 as FWPSTRUNID ,GETDATE() as FSTARTTIME ";
            selSQL += " ,T6.FName, @Fnum as Fnum, T6.Fdepart, T5.SHIP_ID, ";// " ,T6.FName, T6.Fnum, T6.Fdepart, T5.SHIP_ID,  ";
                                 selSQL+=" T5.SHIP_NO, T5.TREE_NAME, T5.WELD_NO, T5.PART1_NAME2, T5.PART2_NAME2,T5.FNewName, "; 
                                 selSQL+=" T5.BUFF1, T5.AS3, T5.BLK_NO, T3.FDepartName,  '未开始'  AS FSTATE_DES, "; 
                                 selSQL+=" T5.WELD_COUNT, T5.WELD_T_LEN, T5.WELD_POS, T5.WELD_MOD,  ";
                                 selSQL+=" 0 as FweldDriverTRUNID  ";                    
            //selSQL+=",T2.FDispatchSTARTTIME,T2.FDispatchENDTIME ,T3.FDepartName as OPName ,T4.FDepartName  as ParentName  ";
            selSQL+="from t_DispatchingBody as T1  ";
            selSQL+="inner join t_DispatchingHeader as T2 on T2.FID=T1.FDispatchHeadID ";
            selSQL+="inner join t_Department as T3 on T3.FID=T1.FOPDEPARTID ";
            //selSQL+="inner join t_Department as T4 on T4.FID=T1.FParentDepartID ";
            selSQL+="INNER JOIN  dbo.t_WELD as T5 ON T5.FID = T1.FWELDID ";
            selSQL += " inner join t_welder as T6 on T6.Fnum=@Fnum and T1.FOPDEPARTID=T6.Fdepart ";//"inner join t_welder as T6 on T6.FID=@welderid ";
            selSQL += "where T1.FWELDID not in (Select FWELDID from t_TaskListBody) ";
            selSQL += " and T2.FDispatchSTARTTIME <=@NOWTIME and T2.FDispatchENDTIME>=@ENDTIME ";//and T1.FOPDEPARTID=@classid";
            //屏蔽合并
            selSQL += " and (T5.FParentID =0 or T5.FParentID=T5.FID or T5.FParentID is null )";
            ArrayList sqlparams = new ArrayList();
            SqlParameter pa;
            pa = new SqlParameter(); pa.SqlDbType =SqlDbType.NVarChar; pa.ParameterName = "@Fnum"; pa.SqlValue = fdt.Rows[0]["Fnum"]; sqlparams.Add(pa);
            pa = new SqlParameter(); pa.SqlDbType = SqlDbType.DateTime; pa.ParameterName = "@NOWTIME"; pa.SqlValue = new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day,0,0,0); sqlparams.Add(pa);
            pa = new SqlParameter(); pa.SqlDbType = SqlDbType.DateTime; pa.ParameterName = "@ENDTIME"; pa.SqlValue = pa.SqlValue = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,21, 0, 0); sqlparams.Add(pa);
            DataTable rdt = _sqldbhelper.ExecuteDataTable(selSQL, sqlparams);
            return rdt;
        }
        /// <summary>
        /// 获取符合日期的任务
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public DataTable GetWelderTaskLists(DataTable dt)
        {
            String sql = "Select  0 as Ftype, * from View_Task_Welder_Index where FSTARTTIME=@FSTARTTIME";
            sql += " union ";
            sql += "Select  0 as Ftype, * from View_Task_Welder_Index where FState=1 and FSTARTTIME<>@FSTARTTIME";
            ArrayList sqlpars = new ArrayList();
            SqlParameter par = new SqlParameter();
            par.ParameterName = "@FSTARTTIME";
            par.SqlDbType = SqlDbType.SmallDateTime;
            par.SqlValue = dt.Rows[0][0];
            sqlpars.Add(par);
            DataTable rs = _sqldbhelper.ExecuteDataTable(sql, sqlpars);
            return rs;
        }
        /// <summary>
        /// 检测焊机设备内置WPS是否符合要求 且要求不能多条焊缝处理
        /// 5112501
        /// </summary>
        /// <returns>0 没有命中 >0 命中</returns>
        public DataTable CheckEqumswps(DataTable dt)
        {
            svrDevices pcls = new svrDevices();
            DataTable wpss = new DataTable() ;
            String sesql = "select * from View_Task_Welder_ALL where FID=0";
            wpss = _sqldbhelper.ExecuteDataTable(sesql);
            wpss.Columns.Add("preChannel", typeof(int));

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                long vFID = Convert.ToInt64(dt.Rows[i]["FID"]);

                String selsql = "select * from View_Task_Welder_ALL";
                selsql += " where FWELDID=" + vFID;
                DataTable wps = _sqldbhelper.ExecuteDataTable(selsql);
                wps.Columns.Add("preChannel", typeof(int));
                for (int k = 0; k < wps.Rows.Count; k++)
                {
                    DataRow row = wps.Rows[k];
                    String vnom = dt.Rows[i]["FweldDriverID"].ToString();
                    int prechannel =0;//= pcls.testEqumsChannelparams(row, vnom);
                    wps.Rows[k]["prechannel"] = prechannel;
                    wpss.ImportRow(wps.Rows[k]);
                }
            }
            return wpss;
        }


        /// <summary>
        /// 更新一个任务的状态和时间
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public DataTable UpdateTaskState(DataTable dt)
        {
            int state = Convert.ToInt32(dt.Rows[0]["FSTATE"]);
            long FID = Convert.ToInt64(dt.Rows[0]["FID"]);
            String vnom = dt.Rows[0]["FweldDriverID"].ToString();
           
             DataTable rst = new DataTable();
            DataColumn colrs = new DataColumn("result", typeof(Boolean));
            rst.Columns.Add(colrs);
            DataColumn col1 = new DataColumn("msg", typeof(String));
            rst.Columns.Add(col1);
            DataColumn col2 = new DataColumn("FID", typeof(long));
            rst.Columns.Add(col2);

           
                //是需要进行合并处理的数据；需要先进行处理
                //此时的FID为任务编号;
               //存在未分配的焊缝，自动进行分配
              
                
           svrTask vtask = new svrTask();
            //dt=dt.Copy().DefaultView.ToTable(true, "FID", "FWELDID", "FWELDWPSID", "FSTARTTIME", "FWelderID");
           DataView vdv = dt.Copy().DefaultView;
           vdv.RowFilter = "FID=0";

            DataTable dt_insertTask =vdv.ToTable(true, "FID", "FWELDID", "FWELDWPSID", "FSTARTTIME", "FWelderID");
            dt_insertTask.Columns["FSTARTTIME"].ColumnName = "FDispatchSTARTTIME";
            dt_insertTask.Columns.Add("FIndex", typeof(long));
            long vindex = DateTime.Now.ToFileTime();
            String ntime=DateTime.Now.ToString("yyyy-MM-dd");
            String insertFWelds = "";
            for (int k = 0; k < dt_insertTask.Rows.Count; k++)
            {
                
                    dt_insertTask.Rows[k]["FIndex"] = vindex;
                    dt_insertTask.Rows[k]["FDispatchSTARTTIME"] = ntime;

                    insertFWelds += dt_insertTask.Rows[k]["FWELDID"].ToString() + ",";
                 
            }
            if (dt_insertTask.Rows.Count > 0)
            {
                vtask.SaveTask(dt_insertTask);
                insertFWelds = insertFWelds.Substring(0, insertFWelds.Length - 1);
                String selFIDSQL = "select FID,FWELDID from t_TaskListBody  where FWELDID in (" + insertFWelds +")";
                DataTable dt_FID = _sqldbhelper.ExecuteDataTable(selFIDSQL);
                for (int k = 0; k < dt_FID.Rows.Count; k++)
                {
                    long vfid = 0; long vweldid = 0;
                    vfid = Convert.ToInt64(dt_FID.Rows[k][0]);
                    vweldid = Convert.ToInt64(dt_FID.Rows[k][1]);
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        if (Convert.ToInt64(dt.Rows[j]["FWELDID"]) == vweldid)
                        {
                            dt.Rows[j]["FID"] = vfid;
                        }
                    }
                }
            }
            //如果传入多条数据，则进行合并处理
            if (dt.Rows.Count > 1)
            {
                dt = this.mergweld(dt);
                dt.Rows[0]["FweldDriverID"] = vnom;
                dt.Rows[0]["FSTATE"] = state;
            }
                    
                 
                
             
                
           


            //向松下服务器发送指令
            //if (Convert.ToInt64(dt.Rows[0]["FID"])==0)
            //{
            //    DataTable dt_insertTask = dt.Copy().DefaultView.ToTable(true, "FID","FWELDID","FWELDWPSID","FSTARTTIME","FWelderID");
            //    dt_insertTask.Columns["FSTARTTIME"].ColumnName = "FDispatchSTARTTIME";
            //    dt_insertTask.Columns.Add("FIndex", typeof(long));
            //    long vindex=DateTime.Now.ToFileTime();
            //    for (int i = 0; i < dt_insertTask.Rows.Count; i++)
            //    {
            //        dt_insertTask.Rows[0]["FIndex"] = vindex;
            //        dt_insertTask.Rows[0]["FDispatchSTARTTIME"] = DateTime.Now.ToString("yyyy-MM-dd");
            //    }
            //    svrTask vtask = new svrTask();
            //    //增加新的任务
            //    vtask.SaveTask(dt_insertTask);
            //    String selFIDSQL = "select * from t_TaskListBody  where FWELDID=" + dt.Rows[0]["FWELDID"].ToString();
            //    DataTable dt_FID = _sqldbhelper.ExecuteDataTable(selFIDSQL);
            //    dt.Rows[0]["FID"] = dt_FID.Rows[0][0];
            //}
            long lastnom = 0;
            if (state != 1)
            {
                String sellastnom = "select Fnom from t_Task_DoingRec where FID=(select Max(FID) from  t_Task_DoingRec where FTaskID={0})";
                sellastnom = String.Format(sellastnom, FID);
                DataTable Lastnom_dt = _sqldbhelper.ExecuteDataTable(sellastnom);
                if (Lastnom_dt != null && Lastnom_dt.Rows.Count>0)
                {
                    lastnom = Convert.ToInt64(Lastnom_dt.Rows[0][0]);
                }
            }
            String sql = "", insertSQL = "insert into t_Task_DoingRec (FTaskID,FSTARTTIME,FSTATE,Fnom) values(@FID,@sTime,@FSTATE,@Fnom)";
            //0 未开始 1 开始 2 完成 3 取消 4,挂起，5 重新开始
            switch (state)
            {
                case 1://1 开始
                    {
                        sql = "Update t_TasklistBody set FSTATE=@FSTATE , FActOpStartTime=@sTime ,FweldDriverID=@FweldDriverID";
                        
                        break;
                    }
                case 2://完成任务
                    {
                        sql = "Update t_TasklistBody set FSTATE=@FSTATE , FActOpEndTime=@sTime";
                        break;
                    }
                case 0://取消任务
                    {
                        sql = "Update t_TasklistBody set FSTATE=@FSTATE , FActOpStartTime=null , FActOpEndTime=null ,FweldDriverID=@FweldDriverID";
                        break;
                    }
                case 4://挂起任务
                    {
                        sql = "Update t_TasklistBody set FSTATE=@FSTATE ";
                        break;
                    }
                case 5://继续任务
                    {
                        //修改状态为1
                        dt.Rows[0]["FSTATE"] = 1;
                        sql = "Update t_TasklistBody set FSTATE=@FSTATE ";
                        break;
                    }
                case 6://切换焊机;
                    {
                        //修改状态为1
                        dt.Rows[0]["FSTATE"] = 6;
                        sql = "Update t_TasklistBody set FSTATE=@FSTATE ";
                        break;
                    }
                default:
                    {
                      
                            //执行错误，没有插入创建新的表头
                            object[] val = new object[] { false, "表头插入失败", 0 };
                            rst.Rows.Add(val);

                       
                         break;
                    }
                   
            }
            state = Convert.ToInt32(dt.Rows[0]["FSTATE"]);
            sql+=" where FID=@FID";
            long fid = Convert.ToInt64(dt.Rows[0]["FID"]);
            String sTime = DateTime.Now.ToLongDateString();
            ArrayList sqlpars = new ArrayList();
            SqlParameter par = new SqlParameter();
            par.ParameterName = "@FID";
            par.SqlDbType = SqlDbType.BigInt;
            par.SqlValue = fid;
            sqlpars.Add(par);
            
            par = new SqlParameter();
            par.ParameterName = "@FSTATE";
            par.SqlDbType = SqlDbType.Int;
            par.SqlValue = state;
            sqlpars.Add(par);

            par = new SqlParameter();
            par.ParameterName = "@sTime";
            par.SqlDbType = SqlDbType.DateTime;
            par.SqlValue = DateTime.Now ;
            sqlpars.Add(par);
            //FweldDriverTRUNID=@FweldDriverTRUNID ,FweldDriverID=@FweldDriverID
            

            par = new SqlParameter();
            par.ParameterName = "@FweldDriverID";
            par.SqlDbType = SqlDbType.BigInt;
            par.SqlValue = dt.Rows[0]["FweldDriverID"];
            sqlpars.Add(par);

            par = new SqlParameter();
            par.ParameterName = "@Fnom";
            par.SqlDbType = SqlDbType.BigInt;
            par.SqlValue =lastnom;// dt.Rows[0]["FweldDriverID"];
            sqlpars.Add(par);


            //获取焊道信息
            long vFID = 0; long vFWELDID = 0;

            vFID = Convert.ToInt64(fid);
            vFWELDID = Convert.ToInt64(dt.Rows[0]["FWELDID"]);
            String selsql = "select * from View_Task_Welder_ALL";
            selsql += " where FWELDID=" + vFWELDID;
            DataTable wps = _sqldbhelper.ExecuteDataTable(selsql);
            //添加字段保存实际使用的焊机通道;
            wps.Columns.Add("FActChannel",typeof(int));


      
         


            //向松下服务器发送执行指令
            switch (state)
            {
                case 1:case 0://开始
                    {
                        svrDevices mcls = new svrDevices();
                        for (int k = 0; k < wps.Rows.Count; k++)
                        {
                            //判断是否与焊机默认WPS一致;
                            
                            //查找到目标焊机;

                            DataRow wpsrow = wps.Rows[k];
                            mcls.changeset(ref wpsrow,Convert.ToString(dt.Rows[0]["FweldDriverID"]));
                            //记录本次焊缝的实际使用通道;
                            //[FTaskID] [bigint] NOT NULL,
	                        //[FSTARTTIME] [datetime] NULL,
	                        //[FWELDPASS] [int] NOT NULL,
	                        //[FWELDCHANNEL] [int] NOT NULL,
	                        //[FSTATE] [int] NULL,
	                        //[FWPSID] [bigint] NULL,
                            if (wpsrow["FActChannel"].ToString().Length > 0)
                            {
                                String insertTaskDoingChannleSQL = "insert into [t_Task_Doing_Channel] (FTaskID,FWELDPASS,FWELDCHANNEL,FWPSID,FWeldDevice,FSTARTTIME) values(";
                                insertTaskDoingChannleSQL += Convert.ToInt64(dt.Rows[0]["FID"]).ToString() + "," + wpsrow["WELD_PASS"].ToString() + "," + wpsrow["FActChannel"].ToString() + "," + wpsrow["FWELDWPSID"].ToString() + ",'" + dt.Rows[0]["FweldDriverID"].ToString() + "','" + DateTime.Now.ToShortDateString() + "')";
                                _sqldbhelper.ExecuteNonQuery(insertTaskDoingChannleSQL);
                            }
                        }

                        break;
                    }
                case 2:
                    {
                        /* 调整到后面
                        String proname = "evaluate_weld";
                        SqlParameter[] StoredProcedureparas = new SqlParameter[2];
                        SqlParameter spa = new SqlParameter();
                        spa.ParameterName = "@PID";
                        spa.SqlDbType = SqlDbType.BigInt;
#if DEBUG
                        spa.SqlValue = 13;
#else
                         spa.SqlValue = fid;
#endif

                        StoredProcedureparas[0] = spa;
                        spa = new SqlParameter();
                        spa.ParameterName = "@WELD_PASS";
                        spa.SqlDbType = SqlDbType.Int;
                        spa.SqlValue = 0;
                        StoredProcedureparas[1] = spa;
                        DataTable rpdt = _sqldbhelper.ExecuteDataTable(proname, CommandType.StoredProcedure, StoredProcedureparas);
                        
                         */
                         break;
                    }
                case 3:case 5:case 4:case 6:
                    {
                        break;
                    }
                default:
                    {
                        object[] val = new object[] { false, "状态不正确", 0 };
                        rst.Rows.Add(val);
                        return rst;
                        break;
                    }
            }
          
            int int_rs = _sqldbhelper.ExecuteNonQuery(sql, CommandType.Text, sqlpars);
            int_rs = _sqldbhelper.ExecuteNonQuery(insertSQL, CommandType.Text, sqlpars);
            if (int_rs== 0)
            {
                //执行错误，没有插入创建新的表头
                object[] val = new object[] { false, "更新失败", 0 };
                rst.Rows.Add(val);

            }
            else
            {
                object[] val = new object[] { true, "更新成功", 1 };
                rst.Rows.Add(val);

            }
            
            if (state == 2)
            {
                String proname = "evaluate_weld";
                SqlParameter[] StoredProcedureparas = new SqlParameter[2];
                SqlParameter spa = new SqlParameter();
                spa.ParameterName = "@PID";
                spa.SqlDbType = SqlDbType.BigInt;
#if DEBUG
                spa.SqlValue = 13;
#else
                         spa.SqlValue = fid;
#endif

                StoredProcedureparas[0] = spa;
                spa = new SqlParameter();
                spa.ParameterName = "@WELD_PASS";
                spa.SqlDbType = SqlDbType.Int;
                spa.SqlValue = 0;
                StoredProcedureparas[1] = spa;
                DataTable rpdt = _sqldbhelper.ExecuteDataTable(proname, CommandType.StoredProcedure, StoredProcedureparas);
                        
            }
            return rst;
        }
        /// <summary>
        /// 获取焊工当前日期时间的工作状态
        /// </summary>
        /// <returns>curDATETIME</returns>
        public DataTable GetWelderCurDateState()
        {
            //利用输入的时间到天查看焊工的状态
            String curDatetime = DateTime.Now.ToString("yyyy-MM-dd");
            String sql = "select *,(select COUNT(FID) from t_TaskListBody where t_TaskListBody.FWelderID=t_Welder.FID ";
                    sql+=" and FActOpStartTime IS not null and FActOpEndTime IS  null and FSTARTTIME=@FSTARTTIME ) as Doing,";
                    sql+=" (select COUNT(FID) from t_TaskListBody where t_TaskListBody.FWelderID=t_Welder.FID ";
                    sql+=" and FActOpStartTime IS  null and FActOpEndTime IS  null and FSTARTTIME=@FSTARTTIME) as UnDoing ";
                    sql+=" from t_Welder ";
            DataTable rsdt= _sqldbhelper.ExecuteDataTable(sql);
            return rsdt;
        }
        /// <summary>
        /// 合并焊缝数据并更新一个数据包
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable mergweld(DataTable idata)
        {
            //将需要合并的焊缝数据进行处理；
            //将字段FIsMerge做合并标志 1
            //将字段FParentID 标志代表
            //准备获取焊缝数据
            String weldIDstr = "";
            long parentid = Convert.ToInt64(idata.Rows[0]["FweldID"]);
            for (int i = 0; i < idata.Rows.Count; i++)
            {
                weldIDstr += idata.Rows[i]["FweldID"].ToString() + ",";
            }
            weldIDstr = weldIDstr.Substring(0, weldIDstr.Length - 1);
            String sql = "select * from t_WELD where FID in (" + weldIDstr + ")";
            DataTable vdata = _sqldbhelper.ExecuteDataTable(sql);

            String selSQL = "select * from t_WELD where FID in (" + weldIDstr + ")";
           
           
            for (int i = 0; i < vdata.Rows.Count; i++)
            {
                vdata.Rows[i]["FParentID"] = parentid;//代表焊缝ID
                //data.Rows[i]["FIsMerge"] = 1;//合并标志

            }
            DataTable cdata = vdata.Copy();
            DataTable dt = _sqldbhelper.UpdateByDataTable(selSQL, cdata, "FID", 0);
            //从任务表t_TaskListBody删除除了第一个焊缝
            DataTable deldt = new DataTable();
            DataColumn col = new DataColumn(); col.ColumnName = "FID"; col.DataType = typeof(long); deldt.Columns.Add(col);
            String delWELDID="";
            for (int i = 0; i < idata.Rows.Count; i++)
            {
                if (Convert.ToInt64(idata.Rows[i]["FWELDID"]) != parentid)
                {
                    DataRow nr = deldt.NewRow(); nr[0] = idata.Rows[i]["FID"]; deldt.Rows.Add(nr);
                    delWELDID+=Convert.ToInt64(idata.Rows[i]["FWELDID"])+",";
                }
            }
           
            //将焊缝任务从任务表中删除
                String delselSQL = "Select * from t_TaskListBody";
                deldt = _sqldbhelper.UpdateByDataTable(delselSQL, deldt, "FID", 2);
                //合并焊缝删除
                //select FWELDWPSID,FWELDID from t_TaskListBody
                //select FWELDWPSID,FWELDID  from t_DispatchingBody
                //select FWELDWPSID,FWELDID from t_ProcessPlanBody
              
          
            //修改其wps
             //将保留的焊缝所在的任务对应的WPS编号设定为默认系列0
                String seltask = "select * from t_TaskListBody where Fweldid=" + parentid;
                DataTable dt_task = _sqldbhelper.ExecuteDataTable(seltask);
                long vcurWPS = 0;
            svrDefaultWPS vsvr = new svrDefaultWPS();
            DataTable defaultdt= vsvr.getCurDefaultWPS();
            if (defaultdt == null)
                vcurWPS = 0;
            else
            {
                if (defaultdt.Rows.Count > 0)
                {
                    vcurWPS=Convert.ToInt64(defaultdt.Rows[0]["Fvalue"]);
                }
                else
                {
                    vcurWPS = 0;
                }
            }

            dt_task.Rows[0]["FWELDWPSID"] = vcurWPS;
            DataTable rs_dt = _sqldbhelper.UpdateByDataTable(seltask, dt_task, "FID", 0);
            
            //获取合并后的热舞
            String newSQL = "select * from t_TaskListBody where FWELDID=" + parentid;
            rs_dt = new DataTable();
            rs_dt = _sqldbhelper.ExecuteDataTable(newSQL);

            return rs_dt;

        }
    }
}
