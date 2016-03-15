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
    /// 任务单；
    /// </summary>
    class svrTask:_clsdb
    {
        /// <summary>
        /// 获取班组的派工单的表体信息
        /// </summary>
        /// <param name="fdata">班组，时间--FOPDEPARTID==FDepartID，FSTARTTIME==Ftime</param>
        /// <returns></returns>
        public DataTable GetDispathInfos(DataTable fdata)
        {
            //DataRow row=fdata.Rows[0];
            //ArrayList sqlparams = new ArrayList();
            //SqlParameter para = new SqlParameter();
            //para.ParameterName = "FDepartID";
            //para.SqlDbType = SqlDbType.BigInt;
            //para.SqlValue = Convert.ToInt64(row["FOPDEPARTID"]);
            //sqlparams.Add(para);
            //para = new SqlParameter();
            //para.ParameterName = "Ftime";
            //para.SqlDbType = SqlDbType.BigInt;
            //para.SqlValue = Convert.ToInt64(row["FSTARTTIME"]);
            //sqlparams.Add(para);
            //String sql = "select case when Isnull(t_TaskListBody.FID,0)=0 then 0 else 1 end as FISTasked, View_DispatchBodyInfos.* from view_DispatchBodyInfos";
            //sql += " left join t_TaskListBody on t_TaskListBody.FWELDID=View_DispatchBodyInfos.FWELDID ";
            //sql+=" where FOPDEPARTID=@FDepartID and FDispatchSTARTTIME<@Ftime and FDispatchENDTIME>@Ftime";
            String sql = "select 0 as WeldCount ,* from View_TaskList_withWait ";//where FDispatchSTARTTIME<='"+DateTime.Now.ToShortDateString()+" and FDispatchENDTIME";
            DataTable dt = _sqldbhelper.ExecuteDataTable(sql);
            return dt ;

        }
        /// <summary>
        /// 获取所有可用焊工信息；
        /// </summary>
        /// <returns></returns>
        public DataTable GetWelders()
        {
            String sql = "select * from view_welders ";
            return _sqldbhelper.ExecuteDataTable(sql);
        }
        //根据焊工等级，过滤焊缝
        /// <summary>
        /// 根据焊工等级，过滤焊缝
        /// </summary>
        /// <param name="fdata">FWELDID,</param>
        /// <returns></returns>
        public DataTable CheckWeldWeldingClass(DataTable fdata, String welderNum)
        {

            String welds = "'',";
            for (int i = 0; i < fdata.Rows.Count; i++)
            {
                welds += fdata.Rows[i][0].ToString() + ",";
            }
            if (welds.Length > 1)
            {
                welds = welds.Substring(0, welds.Length - 1);
            }
            String selSQL = "";
            selSQL += "Select View_WeldWeldingClass.FID,view_welders.FName,view_welders.FID as welderid from View_WeldWeldingClass ";
            selSQL += " inner join view_welders on ";
            selSQL += " View_WeldWeldingClass.WELDING_MOD=view_welders.WeldingProcessAb and View_WeldWeldingClass.WELDING_CLASS=view_welders.WeldingClass ";
            selSQL += " where view_welders.FName='{0}' and View_WeldWeldingClass.FID in ({1})";
            selSQL = String.Format(selSQL, welderNum,welds);
            DataTable rsdt = _sqldbhelper.ExecuteDataTable(selSQL);

            return rsdt;
        }
        //根据焊工等级，过滤焊缝
        /// <summary>
        /// 根据焊工等级，过滤焊缝
        /// </summary>
        /// <param name="fdata">FWELDID,</param>
        /// <returns></returns>
        public DataTable CheckWeldWeldingClass(DataTable fdata,long welderID)
        {

            String welds = "";
            for (int i = 0; i < fdata.Rows.Count; i++)
            {
                welds += fdata.Rows[i][0].ToString() + ",";
            }
            if (welds.Length > 1)
            {
                welds = welds.Substring(0, welds.Length - 1);
            }
            String selSQL = "";
            selSQL += "Select View_WeldWeldingClass.FID,view_welders.FName,view_welders.FID as welderid from View_WeldWeldingClass ";
            selSQL += " inner join view_welders on ";
            selSQL += " View_WeldWeldingClass.WELDING_MOD=view_welders.WeldingProcessAb and View_WeldWeldingClass.WELDING_CLASS=view_welders.WeldingClass ";
            selSQL += " where view_welders.FID={0} and View_WeldWeldingClass.FID in ({1})";
            selSQL = String.Format(selSQL, welderID,welds);
            DataTable rsdt = _sqldbhelper.ExecuteDataTable(selSQL);

            return rsdt;
        }


        /// <summary>
        /// 获取部门信息；
        /// </summary>
        /// <returns></returns>
        public DataTable GetDepartments()
        {
            String sql = "select  * from t_Department where FParentID>0";
            return _sqldbhelper.ExecuteDataTable(sql);
        }
        /// <summary>
        /// 获取任务明细（含待分派的）；
        /// </summary>
        /// <returns></returns>
        public DataTable GetWeldFrTaskListwithDispatch()
        {
            String sql = "select 0  as WeldCount ,* from View_TaskList_withWait ";//where FWELDID not in (select FWeldID from t_TaskListBody)";
            return _sqldbhelper.ExecuteDataTable(sql);
        }
        /// <summary>
        /// 通过日期,部门查询到已经存在的任务单
        /// </summary>班组，时间--FOPDEPARTID==FDepartID，FSTARTTIME==Ftime
        /// <returns></returns>
        public DataTable GetTaskByTime(DataTable fd)
        {
            DataRow row = fd.Rows[0];
            ArrayList sqlparams = new ArrayList();
            SqlParameter para = new SqlParameter();
            para.ParameterName = "FDepartID";
            para.SqlDbType = SqlDbType.BigInt;
            para.SqlValue = Convert.ToInt64(row["FOPDEPARTID"]);
            sqlparams.Add(para);
            para = new SqlParameter();
            para.ParameterName = "Ftime";
            para.SqlDbType = SqlDbType.BigInt;
            para.SqlValue = Convert.ToInt64(row["FSTARTTIME"]);
            sqlparams.Add(para);
            String sql = "Select 1 as FIsSelected,* from view_TaskList where FOPDEPARTID=@FDepartID and FSTARTTIME=@Ftime";
            DataTable rst = _sqldbhelper.ExecuteDataTable(sql, sqlparams);
            return rst;
        }
        
        //删除任务单；
        /// <summary>
        ///删除任务单；
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable DeleteTask(DataTable data)
        {
            //获取焊缝通道信息
        
            String filer = "wpsid=";
            String delSQL = "delete from t_TaskListBody where Fwelderid=@Fwelderid and FSTARTTIME=@FSTARTTIME";
            data.Columns["FDispatchSTARTTIME"].ColumnName = "FSTARTTIME";
            
          

            long vwelderid = 0, vweldid = 0, vweldwpsid = 0, vweldwpstrunid = 0;
            String vstarttime = DateTime.Now.ToShortDateString();
            int int_rs = 0;
            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataTable dvt = new DataTable();
                ArrayList sqlpars = new ArrayList();
                vweldwpsid = 0;
                DataRow row = data.Rows[i];
                vwelderid = Convert.ToInt64(row["FWELDERID"]);
                //vweldid = Convert.ToInt64(row["FWELDID"]);
                vstarttime = Convert.ToString(row["FSTARTTIME"]);
                SqlParameter pa = new SqlParameter();
                pa.ParameterName = "@Fwelderid";
                pa.SqlDbType = SqlDbType.BigInt;
                pa.SqlValue = vwelderid;
                sqlpars.Add(pa);
                pa = new SqlParameter();
                pa.ParameterName = "@FSTARTTIME";
                pa.SqlDbType = SqlDbType.SmallDateTime;
                pa.SqlValue = vstarttime;
                sqlpars.Add(pa);
                int_rs+=_sqldbhelper.ExecuteNonQuery(delSQL, CommandType.Text, sqlpars);

            }


            DataTable rst = new DataTable();
            DataColumn colrs = new DataColumn("result", typeof(Boolean));
            rst.Columns.Add(colrs);
            DataColumn col1 = new DataColumn("msg", typeof(String));
            rst.Columns.Add(col1);
            DataColumn col2 = new DataColumn("FID", typeof(long));
            rst.Columns.Add(col2);







            if (int_rs == 0)
            {
                //执行错误，没有插入创建新的表头
                object[] val = new object[] { false, "删除失败失败", 0 };
                rst.Rows.Add(val);

            }
            else
            {
                object[] val = new object[] { true, "表删除成功", 1 };
                rst.Rows.Add(val);

            }
            return rst;

        }
       
        /// <summary>
        /// 保存任务单
        /// </summary>
        /// <param name="data">任务单：FWELDID ,FWELDERID，FWELDWPSID，FWELDWPSTRUNID，FWELDERID,FSTARTTIME</param>
        /// <returns>处理结果</returns>
        public DataTable SaveTask(DataTable data)
        {
            //任务开始时间不能变更；

            //[FDispatchBodyID] ,[FActOpStartTime],[FActOpEndTime],[FweldDriverID],[FSTATE]
            //,[FWelderID],[FWELDID],[FWELDWPSID],[FWPSTRUNID],[FSTARTTIME],[FweldDriverTRUNID]
            //获取焊缝通道信息
            //String sql1 = "select t_wps_WELDTUN.FID as FID , t_wps_RULE.RuleNum,t_wps_RULE.FID as wpsid from t_wps_WELDTUN";
            //sql1+=" inner join t_wps_RULE on t_wps_RULE.RuleNum=t_wps_WELDTUN.RuleNum";

            //DataTable wpstrun = _sqldbhelper.ExecuteDataTable(sql1);



            
            //String filer = "wpsid=";
            //DataView dv = wpstrun.DefaultView;
            long vFIndex = DateTime.Now.ToFileTime();

            data.Columns["FDispatchSTARTTIME"].ColumnName = "FSTARTTIME";
            //DataColumn col = new DataColumn();
            //col.ColumnName = "FWPSTRUNID";
            //col.DataType = typeof(long);
            //col.DefaultValue = 0;
            //data.Columns.Add(col);
            String strField = "FWELDID,FWELDWPSID,FSTARTTIME,FWelderID,FIndex";
            String[] strFieldGP = strField.Split(',');
            String insertSql = "Insert into t_TaskListBody ("+strField+") values(";
            for (int i = 0; i < strFieldGP.Length; i++)
            {
                insertSql += "@" + strFieldGP[i] + ",";
            }
            insertSql = insertSql.Substring(0, insertSql.Length - 1)+")";
            //insertSql += "@FIndex";
            //更新任务SQL
            String updateSQL = "Update t_TaskListBody set FWELDID=@FWELDID,FWELDWPSID=@FWELDWPSID,FSTARTTIME=@FSTARTTIME,FWelderID=@FWelderID,FIndex=@FIndex where FID=@FID";
            //删除任务SQL;
            String deleteSQL = "delete from t_TaskListBody where FID=@FID";
            //获取焊工已经存在的任务
            String selSQL = "Select * from t_TaskListBody where FIndex=@FIndex and FWelderID=@FWelderID";
            
            

            //分解焊工、时间
            DataView dv = data.Copy().DefaultView;
           // dv.RowFilter = "FIndex<>0";
            DataTable dt = dv.ToTable(true,"FWelderID","FIndex");
          

            
            String vfid = "-1";
            String vwelderid = "0";
            for (int index = 0; index < dt.Rows.Count; index++)
            {
                DataRow dr=dt.Rows[index];
                //加载该焊工在该时间的任务
                ArrayList selSQLParas = new ArrayList();
                
                SqlParameter selpa = new SqlParameter();
                selpa.ParameterName = "@FWelderID";
                selpa.SqlDbType = SqlDbType.BigInt;
                selpa.SqlValue = Convert.ToInt64(dr["FWelderID"]);
                selSQLParas.Add(selpa);
                //selpa = new SqlParameter();
                //selpa.ParameterName = "@FSTARTTIME";
                //selpa.SqlDbType = SqlDbType.DateTime;
                //selpa.SqlValue = dr["FSTARTTIME"];
                //selSQLParas.Add(selpa);
                selpa = new SqlParameter();
                selpa.ParameterName = "@FIndex";
                selpa.SqlDbType = SqlDbType.BigInt;
                selpa.SqlValue = dr["FIndex"];
                selSQLParas.Add(selpa);


                DataTable seldt = _sqldbhelper.ExecuteDataTable(selSQL, selSQLParas);
                //要处理的数据中过滤出该焊工在该时间的任务
                DataView vdv = data.Copy().DefaultView;
                String rowf="FWelderID={0}";
                        
                rowf=String.Format(rowf,dt.Rows[index]["FWelderID"].ToString());
                vdv.RowFilter = rowf;
                DataTable vdt = vdv.ToTable();
                    //DateTime ds = Convert.ToDateTime(vstarttime);

                    //vstarttime = ds.ToString("yyyy-MM-dd");
                    //处理数据  插入、更新、删除
               
                for (int i = 0; i < vdt.Rows.Count; i++)
                {
                    //构造SQL参数

                    ArrayList sqlparams = new ArrayList();
                    SqlParameter pa = new SqlParameter();
                    pa.ParameterName = "@FWELDID";
                    pa.SqlDbType = SqlDbType.BigInt;
                    pa.SqlValue = vdt.Rows[i]["FWELDID"];
                    sqlparams.Add(pa);
                    pa = new SqlParameter();
                    pa.ParameterName = "@FWELDWPSID";
                    pa.SqlDbType = SqlDbType.BigInt;
                    pa.SqlValue = vdt.Rows[i]["FWELDWPSID"];
                    sqlparams.Add(pa);

                    pa = new SqlParameter();
                    pa.ParameterName = "@FSTARTTIME";
                    pa.SqlDbType = SqlDbType.DateTime;
                    pa.SqlValue = vdt.Rows[i]["FSTARTTIME"];
                    sqlparams.Add(pa);
                    pa = new SqlParameter();
                    pa.ParameterName = "@FWelderID";
                    pa.SqlDbType = SqlDbType.BigInt;
                    pa.SqlValue = vdt.Rows[i]["FWelderID"];
                    sqlparams.Add(pa);
                    //pa = new SqlParameter();
                    //pa.ParameterName = "@FIndex";
                    //pa.SqlDbType = SqlDbType.BigInt;
                    //pa.SqlValue = vdt.Rows[i]["FIndex"];
                    //sqlparams.Add(pa);

                        if (Convert.ToInt64(vdt.Rows[i]["FID"]) == 0)
                        {
                            //如果在原始数据库中不存在则插入；
                            selpa = new SqlParameter();
                            selpa.ParameterName = "@FIndex";
                            selpa.SqlDbType = SqlDbType.BigInt;
                            selpa.SqlValue = vFIndex;
                            sqlparams.Add(selpa);
                            //vwelderid.IndexOf("," + vdt.Rows[i]["FWelderID"].ToString()) < 0 &&
                            if ( vfid.IndexOf(","+vdt.Rows[i]["FWeldID"].ToString())<0)
                            {
                                _sqldbhelper.ExecuteNonQuery(insertSql, CommandType.Text, sqlparams);
                                vwelderid += "," + vdt.Rows[i]["FWelderID"].ToString();
                                vfid += "," + vdt.Rows[i]["FID"].ToString();
                            }
                        }
                        else
                        {
                            //如果在原始数据库中存在则更新；
                            pa = new SqlParameter();
                            pa.ParameterName = "@FID";
                            pa.SqlDbType = SqlDbType.BigInt;
                            pa.SqlValue = vdt.Rows[i]["FID"];
                            sqlparams.Add(pa);
                            selpa = new SqlParameter();
                            selpa.ParameterName = "@FIndex";
                            selpa.SqlDbType = SqlDbType.BigInt;
                            selpa.SqlValue = vFIndex;
                            sqlparams.Add(selpa);

                            _sqldbhelper.ExecuteNonQuery(updateSQL, CommandType.Text, sqlparams);
                            vfid +=","+ vdt.Rows[i]["FID"].ToString();
                        }
                        
                      
                }
                //如果在待保存数据中不存在则删除
                DataView del_dv = seldt.Copy().DefaultView;
                del_dv.RowFilter = "FID NOT in (" + vfid + ")";
                DataTable del_dt = del_dv.ToTable();

                for (int delindex = 0; delindex < del_dt.Rows.Count; delindex++)
                {
                    long delfid =Convert.ToInt64( del_dt.Rows[delindex]["FID"]);
                    ArrayList delParams = new ArrayList();
                   SqlParameter  pa = new SqlParameter();
                    pa.ParameterName = "@FID";
                    pa.SqlDbType = SqlDbType.BigInt;
                    pa.SqlValue = del_dt.Rows[delindex]["FID"];
                    delParams.Add(pa);

                    _sqldbhelper.ExecuteNonQuery(deleteSQL, CommandType.Text, delParams);
                 }
                    
                
                
            }

               

            DataTable rst = new DataTable();
            DataColumn colrs = new DataColumn("result", typeof(Boolean));
            rst.Columns.Add(colrs);
            DataColumn col1 = new DataColumn("msg", typeof(String));
            rst.Columns.Add(col1);
            DataColumn col2 = new DataColumn("FID", typeof(long));
            rst.Columns.Add(col2);




           


            if (0 != 0)
            {
                //执行错误，没有插入创建新的表头
                object[] val = new object[] { false, "表头插入失败", 0 };
                rst.Rows.Add(val);

            }
            else
            {
                object[] val = new object[] { true, "数据保存成功", 1 };
                rst.Rows.Add(val);

            }
            return rst;


        }
        /// <summary>
        /// 保存新创建的派工单；
        /// </summary>
        /// <param name="data">保存表头</param>
        /// <returns>返回表头的FID</returns>
        public DataTable SaveDispatchHead(DataTable data)
        {
            //工序计划名称,工序计划编码,开始时间,结束时间,状态
            //下发部门,下发时间,状态,是否管控
            //Fname,Fnum,FSTARTTIME,FENDTIME,Fstate,FDepartID,Fdate,FState,FISControl
            Boolean exres = false;
            String msg = "";

            long maxFID = 0;
            DataTable rst = new DataTable();
            DataColumn col = new DataColumn("result", typeof(Boolean));
            rst.Columns.Add(col);
            DataColumn col1 = new DataColumn("msg", typeof(String));
            rst.Columns.Add(col1);
            DataColumn col2 = new DataColumn("FID", typeof(long));
            rst.Columns.Add(col2);

            String sql = "select max(FID) from t_DispatchingHeader";
            DataTable dt1 = _sqldbhelper.ExecuteDataTable(sql);
            //获取最大FID;
            if (dt1.Rows.Count == 0)
                maxFID = 0;
            else
            {
                if (Convert.IsDBNull(dt1.Rows[0][0]))
                    maxFID = 0;
                else
                    maxFID = Convert.ToInt64(dt1.Rows[0][0]);
            }
            //return rst;
            DataRow row = data.Rows[0];
            //sql = "inert into t_ProcessPlanHeader (Fname,Fnum,FSTARTTIME,FENDTIME,Fstate,FDepartID,Fdate,FISControl) values(";
            //sql += " '" + row["Fname"] + "','" + row["Fnum"] + "','" + row["FSTARTTIME"] + "','" + row["FENDTIME"] + "'," + row["Fstate"] + "," + row["FDepartID"] + ",'" + row["Fdate"] + "'," + row["FISControl"] + ")";
            //_sqldbhelper.ExecuteNonQuery(sql);
            sql = "insert into t_DispatchingHeader (";
            for (int i = 0; i < data.Columns.Count - 1; i++)
            {

                sql += data.Columns[i].ColumnName + " , ";
            }
            sql += data.Columns[data.Columns.Count - 1].ColumnName + ") values(";
            for (int i = 0; i < data.Columns.Count - 1; i++)
            {

                sql += "@" + data.Columns[i].ColumnName + " , ";
            }
            sql += "@" + data.Columns[data.Columns.Count - 1].ColumnName + " ) ";
            ArrayList sqlparas = new ArrayList();
            DataRow rw = data.Rows[0];

            for (int i = 0; i < data.Columns.Count; i++)
            {
                SqlParameter para = new SqlParameter();
                para.ParameterName = "@" + data.Columns[i].ColumnName;
                //para.SqlDbType = _sqldbhelper.tranDataType2SQl(rw[i].GetType());
                para.SqlValue = rw[i];
                sqlparas.Add(para);
            }
            int int_rs = _sqldbhelper.ExecuteNonQuery(sql, CommandType.Text, sqlparas);


            sql = "select max(FID) from t_DispatchingHeader ";
            dt1 = new DataTable();
            dt1 = _sqldbhelper.ExecuteDataTable(sql);
            if (dt1.Rows.Count == 0)
            {
                //执行错误，没有插入创建新的表头
                object[] val = new object[] { false, "表头插入失败", 0 };
                rst.Rows.Add(val);

            }
            else
            {
                object[] val = new object[] { true, "表头插入成功", dt1.Rows[0][0] };
                rst.Rows.Add(val);

            }
            return rst;

        }
        /// <summary>
        /// 获取部门列表，包含级别，名称，内码，上级部门
        /// </summary>
        /// <returns></returns>
        public DataTable GetDepartment()
        {
            String selSQL = "select * from t_Department";
            DataTable rst = _sqldbhelper.ExecuteDataTable(selSQL);
            return rst;
        }
        //获取焊工的任务列表
        /// <summary>
        /// 通过班组，时间，获取所有焊工的任务列表
        /// </summary>
        /// <param name="fdt">0 班组ID FDepartID， 1 时间值</param>
        /// <returns></returns>
        public DataTable GetWelderTaskList(DataTable fdt)
        {
            String selSQL="select * from View_TaskList_ForEditShow_Sum ";
            
            selSQL += " where FDepart=@FDepartID and FSTARTTIME=@FSTARTTIME order by FSTARTTIME ,FwelderID desc";
            //提取参数
            ArrayList selparams = new ArrayList();
            SqlParameter pa = new SqlParameter();
            pa.ParameterName = "@FDepartID";
            pa.SqlDbType = SqlDbType.BigInt;
            pa.SqlValue = fdt.Rows[0]["FDepartID"];
            selparams.Add(pa);
            pa = new SqlParameter();
            pa.ParameterName = "@FSTARTTIME";
            pa.SqlDbType = SqlDbType.DateTime;
            pa.SqlValue = fdt.Rows[0]["FSTARTTIME"];
            selparams.Add(pa);
            DataTable rst = _sqldbhelper.ExecuteDataTable(selSQL, selparams);
            return rst;
        }
    }
}
