using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections;
namespace JN_WELD_Service
{
    /// <summary>
    /// 第一次由工序计划单进行派工；
    /// </summary>
    class svrFirstDispatch:_clsdb
    {

       
        /// <summary>
        /// 获取可用于派工的工序计划；
        /// </summary>
        /// <returns></returns>
        public DataTable GetProject()
        {
            String sql = "select FID ,FProcessname,FProcessnum,FSTARTTIME,FENDTIME,FISControl,FProcessState from t_ProcessPlanHeader ";
            //sql += "	where FID not in(Select FProjectHeadID from t_DispatchingBody where FSTATE=0) ";
            DataTable dt = _sqldbhelper.ExecuteDataTable(sql);
            return dt;
        }
        /// <summary>
        /// 通过工序计划FID获取Body的工程号，分段号，阶段,承接部门
        /// </summary>
        /// <param name="fdata">FID</param>
        /// <returns></returns>
        public DataTable GetProjectBody_SHIP_NO(DataTable fdata)
        {
            DataRow rw = fdata.Rows[0];
            String sql = "select distinct SHIP_NO ,TREE_NAME ,BUFF1,FDoDepartID ,FDepartName from view_ProjectDetail  where FID=" + rw[0];
            DataTable dt = _sqldbhelper.ExecuteDataTable(sql);
            return dt;
        }
        /// <summary>
        /// 获取可以用户分配的部门
        /// </summary>
        /// <param name="fdat">FDopartID=FLevel</param>
        /// <returns></returns>
        public DataTable GetCanDoDepart(DataTable fdat)
        {
            DataRow rw = fdat.Rows[0];
            //long FID = Convert.ToInt64(rw["FParentID"]);
            long FID = Convert.ToInt64(rw[0]);
            //String sql = "select * from t_ProcessPlanHeader where FID=" + FID;
            //DataTable projecth = _sqldbhelper.ExecuteDataTable(sql);
            //int vleve = 0;
            //if (projecth.Rows.Count > 0)
            //{
            //    vleve = Convert.ToInt32(projecth.Rows[0]["FDepartID"]);
            //}
            //迁移修改
            long p =Convert.ToInt64( rw[0]);
            String sql = "";
            if (p == 0)
            {
                sql = "Select FID as VALUE, FDepartName as NAME ,FParentID from t_Department where Flevel=2";// +rw[0];

            }
            else
            {
                sql = "Select FID, FDepartName from t_Department where FParentID="+rw[0];
            }
            DataTable dt = _sqldbhelper.ExecuteDataTable(sql);
            return dt;
        }
        /// <summary>
        /// 获取已经存在的派工计划表头信息；
        /// </summary>
        /// <param name="fdata">FID</param>
        /// <returns></returns>
        public DataTable GetDispatchHead(DataTable fdata)
        {
            String sql = "select * from  t_DispatchingHeader";
            sql += " where FID=@FID ";
            ArrayList sqlparas = new ArrayList();
            DataRow r = fdata.Rows[0];
            for (int i = 0; i < fdata.Columns.Count; i++)
            {
                SqlParameter par = new SqlParameter();
                par.ParameterName = "@" + fdata.Columns[i].ColumnName;
                par.SqlDbType = _sqldbhelper.tranDataType2SQl(fdata.Columns[i].DataType);
                par.SqlValue = r[i];
                sqlparas.Add(par);
            }
            DataTable rs = _sqldbhelper.ExecuteDataTable(sql, sqlparas);
            return rs;

        }
        /// <summary>
        /// 获取派工单列表
        /// </summary>
        /// <param name="fdata"></param>
        /// <returns></returns>
        public DataTable GetDispatchHead()
        {
            String sql = "select * from t_DispatchingHeader order by FDispatchSTARTTIME desc";
            return _sqldbhelper.ExecuteDataTable(sql);
        }
        /// <summary>
        /// 获取已经存在的派工计划表体的焊缝和WPS信息；
        /// </summary>
        /// <param name="fdata">FDispatchHeadID</param>
        /// <returns></returns>
        public DataTable GetDispatchBodyIndex(DataTable fdata)
        {
            String sql = "select distinct FOPDEPARTID,TREE_NAME,SHIP_NO,BUFF1,FProjectHeadID,FParentDepartID,FOPDEPARTID  from t_DispatchingBody ";
            sql += " inner join t_WELD on t_WELD.FID=t_DispatchingBody.FweldID where FDispatchHeadID=@FDispatchHeadID";
            ArrayList sqlparas = new ArrayList();
            DataRow r = fdata.Rows[0];
            for (int i = 0; i < fdata.Columns.Count; i++)
            {
                SqlParameter par = new SqlParameter();
                par.ParameterName = "@" + fdata.Columns[i].ColumnName;
                par.SqlDbType = _sqldbhelper.tranDataType2SQl(fdata.Columns[i].DataType);
                par.SqlValue = r[i];
                sqlparas.Add(par);
            }
            DataTable rs = _sqldbhelper.ExecuteDataTable(sql, sqlparas);
            return rs;

        }
        //删除派工计划；
        /// <summary>
        ///删除派工计划；
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable DeleteDispatch(DataTable data,int type)
        {
            long FID = 0;
            int int_rs = 0;
            int isEdit = 0;

            DataRow row = data.Rows[0];
            FID=Convert.ToInt64(row[0]);
            String sql;
            isEdit = Convert.ToInt32(row[1]);
            if (isEdit == 1)
            {
                sql = "delete from  t_DispatchingBody  where FDispatchHeadID=" + FID;
               // sql += " delete from t_DispatchingHeader where FID=" + FID;
            }
            else
            {
                sql = "delete from  t_DispatchingBody  where FDispatchHeadID=" + FID;
                sql += " delete from t_DispatchingHeader where FID=" + FID;
            }
            _sqldbhelper.ExecuteNonQuery(sql);




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




     


            if (int_rs ==-1)
            {
                //执行错误，没有插入创建新的表头
                object[] val = new object[] { false, "删除失败", 0 };
                rst.Rows.Add(val);

            }
            else
            {
                object[] val = new object[] { true, "删除成功", int_rs };
                rst.Rows.Add(val);

            }
            return rst;
        }
        /// <summary>
        /// 新建派工计划是获取到的焊缝和WPS信息；
        /// </summary>
        /// <param name="fdata"></param>
        /// <returns></returns>
        public DataTable GetDispatchWeldInfoWps(DataTable fdata)
        {
            long vFDispatchHeadID = 0;
            DataTable rs=new DataTable();
          //  vFDispatchHeadID = Convert.ToInt64(fdata.Rows[0]["FDispatchHeadID"]);
            
                //String sql = "select 0 as FOPDEPARTID ,FWELDID,FWELDWPSID ,FProjectBodyID from view_ProjectDetail";
                //sql += " where FID=@FID and SHIP_NO=@SHIP_NO and TREE_NAME=@TREE_NAME and BUFF1=@BUFF1 and FDoDepartID=@FDoDepartID";

            String sql = "select k.*,TP.RuleNum,TP.FID as RuleFID,PART1_NAME2,PART2_NAME2,t.THICK1,t.THICK2,t.GRADE1,t.GRADE2,WELD_T_LEN,t.WELD_MOD,WELD_POS,t.WELD1_CODE,t.WELD2_CODE,t.WELD_TYPE ";
                sql+=" from ( select 0 as FChecked,0 AS FID, 0 as FOPDEPARTID ,FWELDID,FWELDWPSID ,FProjectBodyID,0 as FProjectHeadID from view_ProjectDetail ";
                sql+="where FID=@FID and SHIP_NO=@SHIP_NO and TREE_NAME=@TREE_NAME and BUFF1=@BUFF1 and FDoDepartID=@FDoDepartID ";
                sql+=" and FWELDID  not in (Select FWELDID from t_DispatchingBody) ";
                sql+=" union ";
                sql += " select 1 as FChecked,t_DispatchingBody.FID, FOPDEPARTID,FWELDID,FWELDWPSID,0 as FProjectBodyID,FProjectHeadID from t_DispatchingBody ";
                sql+=" inner join t_WELD on t_WELD.FID=t_DispatchingBody.FWELDID ";
                sql+=" where FDispatchHeadID=@FDispatchHeadID and FOPDEPARTID=@FOPDEPARTID and FParentDepartID=@FDoDepartID ";
                sql+=" and t_WELD.SHIP_NO=@SHIP_NO and t_WELD.TREE_NAME=@TREE_NAME and t_WELD.BUFF1=@BUFF1 ";
                sql += ") as k";
                sql += " inner join t_WELD as t on t.FID=k.FWELDID  left join t_wps_RULE as TP on TP.FID=k.FWELDWPSID ";
                ArrayList sqlparas = new ArrayList();
                DataRow r = fdata.Rows[0];
                for (int i = 0; i < fdata.Columns.Count; i++)
                {
                    SqlParameter par = new SqlParameter();
                    par.ParameterName = "@" + fdata.Columns[i].ColumnName;
                    par.SqlDbType = _sqldbhelper.tranDataType2SQl(fdata.Columns[i].DataType);
                    par.SqlValue = r[i];
                    sqlparas.Add(par);
                }
                rs = _sqldbhelper.ExecuteDataTable(sql, sqlparas);
            
        
            return rs;

        }
        /// <summary>
        /// 新建派工计划是获取到的焊缝和WPS信息；
        /// </summary>
        /// <param name="fdata"></param>
        /// <returns></returns>
        public DataTable GetSavedDispatchWeldInfoWPS(DataTable fdata)
        {
            String sql = "select FID,  FOPDEPARTID ,FWELDID,FWELDWPSID ,FProjectBodyID from t_DispatchingBody";
            sql += " where FID=@FID and SHIP_NO=@SHIP_NO and TREE_NAME=@TREE_NAME and BUFF1=@BUFF1";
            ArrayList sqlparas = new ArrayList();
            DataRow r = fdata.Rows[0];
            for (int i = 0; i < fdata.Columns.Count; i++)
            {
                SqlParameter par = new SqlParameter();
                par.ParameterName = "@" + fdata.Columns[i].ColumnName;
                par.SqlDbType = _sqldbhelper.tranDataType2SQl(fdata.Columns[i].DataType);
                par.SqlValue = r[i];
                sqlparas.Add(par);
            }
            DataTable rs = _sqldbhelper.ExecuteDataTable(sql, sqlparas);
            return rs;

        }

        /// <summary>
        /// 保存派工单表体
        /// </summary>
        /// <param name="data">派工单</param>
        /// <returns>处理结果</returns>
        public DataTable SaveDispatchBody(DataTable data)
        {
            DataView data_dv = data.DefaultView;
            data_dv.RowFilter = "FChecked=1";
            data=data_dv.ToTable();
            String insertsql = "insert into t_DispatchingBody (FDispatchHeadID,FProjectHeadID,FSTATE,FOPDEPARTID,FWELDID,FWELDWPSID,FParentDepartID ) values(";
            insertsql += " @FDispatchHeadID,@FProjectHeadID,@FSTATE,@FOPDEPARTID,@FWELDID,@FWELDWPSID,@FParentDepartID)";
            //FDispatchHeadID,FProjectHeadID,FSTATE,FOPDEPARTID,FWELDID,FWELDWPSID,FParentDepartID 
            String updatesql = "Update t_DispatchingBody set FDispatchHeadID=@FDispatchHeadID,FProjectHeadID=@FProjectHeadID, FSTATE=@FSTATE,FOPDEPARTID=@FOPDEPARTID,FWELDID=@FWELDID,FWELDWPSID=@FWELDWPSID,FParentDepartID=@FParentDepartID ";
            updatesql += " where FID=@FID";
            String delsql="delete from t_DispatchingBody where FID=@FID";
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
            //查询得到已经存在数据
            String selsql = "select * from t_DispatchingBody where FProjectHeadID=@FProjectHeadID and FDispatchHeadID=@FDispatchHeadID  and FOPDEPARTID=@FOPDEPARTID";
            DataView dv = data.Copy().DefaultView;
            DataTable dt = dv.ToTable(true, "FProjectHeadID", "FDispatchHeadID", "FOPDEPARTID");
            ArrayList sSqlParamList = new ArrayList();
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                SqlParameter para = new SqlParameter();
                para.ParameterName = "@" + dt.Columns[i].ColumnName;
                para.SqlDbType = _sqldbhelper.tranDataType2SQl(dt.Columns[i].DataType);
                sSqlParamList.Add(para);
            }

            for (int rowindex = 0; rowindex < dt.Rows.Count; rowindex++)
            {
                for (int i = 0; i < sSqlParamList.Count; i++)
                {
                    SqlParameter pa = (SqlParameter)sSqlParamList[i];
                    pa.SqlValue = dt.Rows[rowindex][pa.ParameterName.Substring(1, pa.ParameterName.Length - 1)];
                    sSqlParamList[i] = pa;
                }

                DataTable sdata = _sqldbhelper.ExecuteDataTable(selsql,sSqlParamList);


                int int_rs = 0;

                ArrayList sqlparas = new ArrayList();



                for (int i = 0; i < sdata.Columns.Count; i++)
                {
                   
                        SqlParameter para = new SqlParameter();
                        para.ParameterName = "@" + sdata.Columns[i].ColumnName;
                        para.SqlDbType = _sqldbhelper.tranDataType2SQl(sdata.Columns[i].DataType);
                        //para.SqlValue = rw[i];
                        sqlparas.Add(para);
                    
                }
                String instr = "0";
                String delfid = "0";
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    long vfid = 0;
                    try
                    {
                        vfid = Convert.ToInt64(data.Rows[i]["FID"]);

                    }
                    catch
                    {
                        vfid = 0;
                    }
                    if (vfid == 0)
                    {
                        //插入新的数据
                        ArrayList insertParams = new ArrayList();
                        for (int kk = 0; kk < sqlparas.Count; kk++)
                        {
                            
                            SqlParameter ps = (SqlParameter)sqlparas[kk];
                            if (ps.ParameterName != "@FID")
                            {
                                try
                                {
                                    ps.SqlValue = data.Rows[i][ps.ParameterName.Substring(1, ps.ParameterName.Length - 1)];
                                }
                                catch { ps.SqlValue = 0; }
                                insertParams.Add(ps);
                            }
                           
                        }
                        _sqldbhelper.ExecuteNonQuery(insertsql, CommandType.Text, insertParams);
                    }
                    else
                    {
                        //跟新素具
                        ArrayList insertParams = new ArrayList();
                        for (int kk = 0; kk < sqlparas.Count; kk++)
                        {
                            SqlParameter ps = (SqlParameter)sqlparas[kk];
                           // if (ps.ParameterName != "@FID")

                            try
                            {
                                ps.SqlValue = data.Rows[i][ps.ParameterName.Substring(1, ps.ParameterName.Length - 1)];
                            }
                            catch { ps.SqlValue = 0; }
                            insertParams.Add(ps);
                        }
                        delfid += ","+data.Rows[i]["FID"].ToString();
                        _sqldbhelper.ExecuteNonQuery(updatesql, CommandType.Text, sqlparas);

                    }

                }
                //执行删除任务
                DataView delDV = sdata.Copy().DefaultView;
                delDV.RowFilter = "FID NOT IN(" + delfid + ")";
                DataTable delDT = delDV.ToTable(true,"FID");
                ArrayList delparams = new ArrayList();
                SqlParameter delpa = new SqlParameter("@FID", SqlDbType.BigInt);
                delparams.Add(delpa);
                for (int k = 0; k < delDT.Rows.Count; k++)
                {
                    delpa = (SqlParameter)delparams[0];
                    delpa.SqlValue = delDT.Rows[k][0];
                    delparams[0] = delpa;
                    _sqldbhelper.ExecuteNonQuery(delsql, CommandType.Text, delparams);
                }


                  
                

            }

           
            
                object[] val = new object[] { true, "表头插入成功", 0 };
                rst.Rows.Add(val);

            
            return rst;


        }
        /// <summary>
        /// 删除派工单
        /// </summary>
        /// <param name="dt">数据包</param>
        /// <returns></returns>
        public DataTable DeleteDispatch(DataTable dt)
        {
            DataTable rst = new DataTable();
            DataColumn col = new DataColumn("result", typeof(Boolean));
            rst.Columns.Add(col);
            DataColumn col1 = new DataColumn("msg", typeof(String));
            rst.Columns.Add(col1);
            DataColumn col2 = new DataColumn("FID", typeof(long));
            rst.Columns.Add(col2);
            String selSQL = "select COUNT(FID) from t_DispatchingBody where FDispatchHeadID=@FDispatchHeadID and FWELDID in (select FWELDID from t_TaskListBody)";
            long vFDispatchHeadID = 0;
            vFDispatchHeadID = Convert.ToInt64(dt.Rows[0]["FID"]);
            SqlParameter pa = new SqlParameter();
            pa.ParameterName = "@FDispatchHeadID";
            pa.SqlDbType = SqlDbType.BigInt;
            pa.SqlValue = vFDispatchHeadID;
            ArrayList sqlLst = new ArrayList();
            sqlLst.Add(pa);
            DataTable seldt = _sqldbhelper.ExecuteDataTable(selSQL,sqlLst);
            if (Convert.ToInt32(seldt.Rows[0][0]) > 0)
            {
                object[] val = new object[] { true, "该派工单已经产生任务单，不能删除", 0 };
                rst.Rows.Add(val);
                return rst;
            }
            String delSQL="delete from t_DispatchingHeader where FID=@FDispatchHeadID;";
            delSQL += " delete from t_DispatchingBody where FDispatchHeadID=@FDispatchHeadID";
            int int_rs=_sqldbhelper.ExecuteNonQuery(delSQL,CommandType.Text,sqlLst);

            object[] val1 = new object[] { false, "该派工单删除完成", 0 };
                rst.Rows.Add(val1);
            return rst;
        }
        /// <summary>
        /// 更新派工单的表头
        /// </summary>
        /// <param name="dt">数据包</param>
        /// <returns></returns>
        public DataTable UpDateDispatchHead(DataTable dt)
        {
            DataTable rst = new DataTable();
            DataColumn col = new DataColumn("result", typeof(Boolean));
            rst.Columns.Add(col);
            DataColumn col1 = new DataColumn("msg", typeof(String));
            rst.Columns.Add(col1);
            DataColumn col2 = new DataColumn("FID", typeof(long));
            rst.Columns.Add(col2);
            long vFID = Convert.ToInt64(dt.Rows[0]["FID"]);
            String sql = "select * from t_DispatchingHeader where FID=" + vFID;
            DataTable sDT = _sqldbhelper.ExecuteDataTable(sql);
            String upSQL = "update t_DispatchingHeader set ";
            //构造UPDATE语句
            for (int i = 0; i < sDT.Columns.Count; i++)
            {
                if (sDT.Columns[i].ColumnName != "FID")
                {
                    upSQL+= sDT.Columns[i].ColumnName + "=@" + sDT.Columns[i].ColumnName+",";
                }


            }
            upSQL = upSQL.Substring(0, upSQL.Length - 1);
            upSQL += " where FID=" + vFID;
            //构造UPDATE参数
            ArrayList sqlparams = new ArrayList();
            for (int i = 0; i < sDT.Columns.Count; i++)
            {
                if (sDT.Columns[i].ColumnName != "FID")
                {
                    SqlParameter pa = new SqlParameter();
                    pa.ParameterName = "@" + sDT.Columns[i].ColumnName;
                    pa.SqlDbType = _sqldbhelper.tranDataType2SQl(sDT.Columns[i].DataType);
                    pa.SqlValue = dt.Rows[0][sDT.Columns[i].ColumnName];
                    sqlparams.Add(pa);
                }
            }
            //执行更新派工单表头
            _sqldbhelper.ExecuteNonQuery(upSQL, CommandType.Text, sqlparams);

            object[] val = new object[] { true, "表头插入成功", vFID };
            rst.Rows.Add(val);

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
            //获取FDispatchHeadID
            
            //return rst;
            DataRow row = data.Rows[0];

            long vFDispatchHeadID = 0;
            try
            {
                vFDispatchHeadID = Convert.ToInt64( row["FID"]);
            }
            catch { vFDispatchHeadID = 0; }
            //sql = "inert into t_ProcessPlanHeader (Fname,Fnum,FSTARTTIME,FENDTIME,Fstate,FDepartID,Fdate,FISControl) values(";
            //sql += " '" + row["Fname"] + "','" + row["Fnum"] + "','" + row["FSTARTTIME"] + "','" + row["FENDTIME"] + "'," + row["Fstate"] + "," + row["FDepartID"] + ",'" + row["Fdate"] + "'," + row["FISControl"] + ")";
            //_sqldbhelper.ExecuteNonQuery(sql);
            if (vFDispatchHeadID == 0)
            {
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
            else
            {
                return UpDateDispatchHead(data);
            }

        }
    }
}
