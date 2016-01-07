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
    /// 工序计划数据处理
    /// </summary>
    class svrdbProject : _clsdb
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public svrdbProject()
        {

        }
        /// <summary>
        /// 删除工序计划表单表体，除非其已经派工
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable DeleteProject(DataTable data)
        {
            DataRow rw = data.Rows[0];

            DataTable rst = new DataTable();
            DataColumn col = new DataColumn("result", typeof(Boolean));
            rst.Columns.Add(col);
            DataColumn col1 = new DataColumn("msg", typeof(String));
            rst.Columns.Add(col1);
            DataColumn col2 = new DataColumn("FID", typeof(long));
            rst.Columns.Add(col2);


            String sql_qu = "Select Count(FID) from t_DispatchingBody where FProjectHeadID=@FID";
            ArrayList sqlparas = new ArrayList();
            SqlParameter par = new SqlParameter();
            par.ParameterName = "@" + "FID";
            par.SqlDbType = SqlDbType.BigInt;
            par.SqlValue = rw["FID"];
            sqlparas.Add(par);
            DataTable fin = _sqldbhelper.ExecuteDataTable(sql_qu, sqlparas);

            DataRow selrw=fin.Rows[0];

            if (Convert.ToInt64(selrw[0]) > 0)
            {
                object[] val = new object[] { false, "不能删除", 0 };
                rst.Rows.Add(val);
                return rst;
            }


            String sql = "delete from t_ProcessPlanHeader where FID=@FID  ";

           
            int int_rs = _sqldbhelper.ExecuteNonQuery(sql, CommandType.Text, sqlparas);

            sql = "delete from t_ProcessPlanBody where FProjectHeadID=@FID";
            int_rs = _sqldbhelper.ExecuteNonQuery(sql, CommandType.Text, sqlparas);
           
            if (int_rs == 0)
            {
                //执行错误，没有插入创建新的表头
                object[] val = new object[] { false, "删除失败", 0 };
                rst.Rows.Add(val);

            }
            else
            {
                object[] val = new object[] { true, "删除陈工", int_rs };
                rst.Rows.Add(val);

            }
            return rst;
        }
        /// <summary>
        /// 获取所有工序计划
        /// </summary>
        /// <returns></returns>
        public DataTable GetProjectHead()
        {
            String sql = "select * from t_processPlanHeader order by FSTARTTIME desc";
       
            DataTable rsdt = _sqldbhelper.ExecuteDataTable(sql);
            return rsdt;
        }
        /// <summary>
        /// 得到工序计划表头
        /// </summary>
        /// <param name="HeadFID"></param>
        /// <returns></returns>
        public DataTable GetProjectHead(long HeadFID)
        {
            //select * from t_processPlanHeader
           // String sql = "select distinct SHIP_ID,SHIP_NO,TREE_NAME,FProjectHeadID,FDoDepartID from (select * from  view_ProjectDetail where FID=@FID) as k ";
            String sql = "select * from t_processPlanHeader where FID=@FID";
            ArrayList sqlparas = new ArrayList();
            SqlParameter para = new SqlParameter();
            para.ParameterName = "@FID";
            para.SqlDbType = SqlDbType.BigInt;
            para.SqlValue = HeadFID;
            sqlparas.Add(para);
            DataTable rsdt = _sqldbhelper.ExecuteDataTable(sql, sqlparas);
            return rsdt;
        }
        /// <summary>
        /// 查询得到工序计划表体Index
        /// </summary>
        /// <param name="HeadFID"></param>
        /// <returns></returns>
        public DataTable GetProjectBodyIndex(DataTable fdata)
        {
            String sql = "select distinct SHIP_ID,SHIP_NO,TREE_NAME,FProjectHeadID,FDoDepartID from (select * from  view_ProjectDetail where FID=@FID) as k ";
            ArrayList sqlparas = new ArrayList();
            SqlParameter para = new SqlParameter();
            DataRow frw = fdata.Rows[0];
            para.ParameterName = "@FID";
            para.SqlDbType = SqlDbType.BigInt;
            para.SqlValue = frw["FID"];
            sqlparas.Add(para);
            DataTable rsdt=_sqldbhelper.ExecuteDataTable(sql,sqlparas);
            return rsdt;
        }
        /// <summary>
        /// 通过必要的过滤得到WPS数据；
        /// </summary>
        /// <param name="fdt"></param>
        /// <returns></returns>
        public DataTable GetWPSByFilter(DataTable fdt)
        {
            String sql = " select * from t_wps_RULE";// where charindex(@GRADE1, GRADE1)>0  and charindex(@GRADE2,GRADE2 )>0 and WELD_TYPE=@WELD_TYPE and (@THICK1>=THICK1 and @THICK2<=THICK2) and WELD2_CODE=@WELD2_CODE and WELD_MOD=@WELD_MOD";
            DataRow row = fdt.Rows[0];
            ArrayList sqlparams = new ArrayList();
            for (int i = 0; i < fdt.Columns.Count; i++)
            {
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@" + fdt.Columns[i].ColumnName;
                param.SqlDbType = _sqldbhelper.tranDataType2SQl(fdt.Columns[i].DataType);
                param.SqlValue = row[i];
                sqlparams.Add(param);
            }
            DataTable rst = _sqldbhelper.ExecuteDataTable(sql, sqlparams);
            return rst;
        }
        /// <summary>
        /// 通过工程号得到分段号；
        /// </summary>
        /// <param name="fdata"></param>
        /// <returns></returns>
        public DataTable GetTREE_NAME_WithFilter(DataTable fdata)
        {
            String sql = "select distinct TREE_NAME from t_WELD  where FID not in (select FweldID from t_ProcessPlanBody)  ";

            DataRow row = fdata.Rows[0];
            for (int i = 0; i < fdata.Columns.Count; i++)
            {
                sql += " and " + fdata.Columns[i].ColumnName + " = @" + fdata.Columns[i].ColumnName;

            }
            ArrayList sqlparams = new ArrayList();
            for (int i = 0; i < fdata.Columns.Count; i++)
            {
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@" + fdata.Columns[i].ColumnName;
                param.SqlDbType = _sqldbhelper.tranDataType2SQl(fdata.Columns[i].DataType);
                //String n = (String)row[i];
                param.SqlValue = row[i].ToString();
                sqlparams.Add(param);
            }
            DataTable dt = _sqldbhelper.ExecuteDataTable(sql, sqlparams);
            return dt; 
        }
        /// <summary>
        /// 查询得到需要进行工序计划安排的工程号；
        /// </summary>
        /// <param name="fdata"></param>
        /// <returns></returns>
        public DataTable GetSHIP_NO()
        {
            String sql = "select distinct SHIP_NO from t_WELD  where FID not in (select FID from t_ProcessPlanBody)";

            
       
            DataTable dt = _sqldbhelper.ExecuteDataTable(sql);
            return dt; 
        }
        /// <summary>
        /// 通过工序计划表头FID查询得到表体内焊缝的详细信息
        /// </summary>
        /// <param name="filterdata"></param>
        /// <returns></returns>
        public DataTable GetProjectBody_WeldInfo(DataTable filterdata)
        {
            //String sql = "Select Isnull(t_wps_RULE.RuleNum,0) as RuleNum ,IsNull(t_wps_RULE.FID,0)  as RuleFID, t_Weld.* ,t_ProcessPlanBody.FID as ProcessPlanBodyID from  t_ProcessPlanBody ";
            //sql += " inner join t_WELD on t_WELD.FID=t_ProcessPlanBody.FWELDID ";
            //sql += " left join t_wps_RULE on t_ProcessPlanBody.FWELDWPSID=t_wps_RULE.FID ";
            //sql += "where 1=1 ";

            DataRow row = filterdata.Rows[0];
            //for (int i = 0; i < filterdata.Columns.Count; i++)
            //{
            //    sql += " and " + filterdata.Columns[i].ColumnName + " = @" + filterdata.Columns[i].ColumnName;

            //}
            String sql = "select * from (";
            sql+="Select IsNull(t_wps_RULE.FID,0)  as RuleFID, t_Weld.* ,t_ProcessPlanBody.FID as ProcessPlanBodyID , 1 as FChecked from  t_ProcessPlanBody  ";
            sql+="inner join t_WELD on t_WELD.FID=t_ProcessPlanBody.FWELDID  ";
            sql+=" left join t_wps_RULE on t_ProcessPlanBody.FWELDWPSID=t_wps_RULE.FID ";
            sql += "  where  SHIP_NO =@SHIP_NO  and TREE_NAME = @TREE_NAME and FProjectHeadID = @FProjectHeadID and FDoDepartID=@FDoDepartID";
            sql+=" union ";
            //sql+=" Select isnull(RuleNum,0) as RuleNum  ,0  as RuleFID, t_Weld.* ,0 as ProcessPlanBodyID ,0 as FChecked  from  t_WELD  ";
            sql+=" Select isNull(t_wps_RULE.FID,0) as RuleFID, t_Weld.* ,0 as ProcessPlanBodyID ,0 as FChecked  from  t_WELD ";
            sql += " left join t_wps_RULE on t_wps_RULE.RuleNum=t_WELD.RuleNum";
            sql+=" where SHIP_NO =@SHIP_NO  and TREE_NAME = @TREE_NAME ";
            sql += " and t_WELD.FID not in (select FWELDID from t_ProcessPlanBody )";
            sql += ") as K order by FChecked desc";
            ArrayList sqlparams = new ArrayList();
            for (int i = 0; i < filterdata.Columns.Count; i++)
            {
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@" + filterdata.Columns[i].ColumnName;
                param.SqlDbType = _sqldbhelper.tranDataType2SQl(filterdata.Columns[i].DataType);
                param.SqlValue = row[i];
                sqlparams.Add(param);
            }
            DataTable dt = _sqldbhelper.ExecuteDataTable(sql, sqlparams);
            return dt; 
        }
        /// <summary>
        /// 通过给定的条件查询得到焊缝信息；
        /// </summary>
        /// <param name="filterdata"></param>
        /// <returns></returns>
        public DataTable GetWeldinfoByFilter(DataTable filterdata)
        {
            //String sql = "Select '' as RuleNum ,0  as RuleFID, * from  t_weld  ";
            ////sql+=" inner join t_WELD on t_WELD.FID=t_ProcessPlanBody.FWELDID ";
            ////sql+=" left join t_wps_RULE on t_ProcessPlanBody.FWELDWPSID=t_wps_RULE.FID "; 
            //sql+=" where 1=1 ";

            DataRow row=filterdata.Rows[0];
            //for (int i=0;i<filterdata.Columns.Count;i++)
            //{
            //    sql+=" and "+filterdata.Columns[i].ColumnName+" = @"+filterdata.Columns[i].ColumnName;

            //}
            String sql="Select '0' as RuleNum ,0  as RuleFID, t_Weld.* ,0 as ProcessPlanBodyID ,0 as FChecked  from  t_WELD  ";
            sql+=" where   SHIP_NO =@SHIP_NO  and TREE_NAME = @TREE_NAME ";
            sql += " and t_WELD.FID not in (select FWELDID from t_ProcessPlanBody )";
            ArrayList sqlparams=new ArrayList();
            for (int i=0;i<filterdata.Columns.Count;i++)
            {
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@"+filterdata.Columns[i].ColumnName;
                param.SqlDbType = _sqldbhelper.tranDataType2SQl(filterdata.Columns[i].DataType);
                param.SqlValue = row[i];
                sqlparams.Add(param);
            }
            DataTable dt = _sqldbhelper.ExecuteDataTable(sql, sqlparams);
            return dt; 
        }

        /// <summary>
        /// 获取部门信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDepart()
        {
            String sql = "select convert(varchar(20),FID) as FDoDepartID ,FDepartName from t_Department where Flevel=1";
            DataTable rst = _sqldbhelper.ExecuteDataTable(sql);
            return rst;
        }
        /// <summary>
        /// 获取空表体
        /// </summary>
        /// <returns></returns>
        public DataTable GetemptyBody()
        {
            //获取空的工序计划表头;
            String sql = "select * from t_ProcessPlanBody where FID=0";
            DataTable rst = _sqldbhelper.ExecuteDataTable(sql);
            return rst;
        }
        /// <summary>
        /// 获取空表头
        /// </summary>
        /// <returns></returns>
        public DataTable GetemptyHead()
        {
            //获取空的工序计划表头;
            String sql = "select * from t_ProcessPlanHeader where FID=0";
            DataTable rst = _sqldbhelper.ExecuteDataTable(sql);
            return rst;
        }
        /// <summary>
        /// 获取工序计划表头
        /// </summary>
        /// <returns></returns>
        public DataTable GetHead(DataTable fdata)
        {
            //获取空的工序计划表头;
            String sql = "select * from t_ProcessPlanHeader where 1=1";
            ArrayList sqlparas = new ArrayList();
            DataRow row=fdata.Rows[0];
            for (int i = 0; i < fdata.Columns.Count; i++)
            {
                SqlParameter par = new SqlParameter();
                par.ParameterName = "@" + fdata.Columns[i].ColumnName;
                par.SqlDbType = _sqldbhelper.tranDataType2SQl(fdata.Columns[i].GetType());
                par.SqlValue = row[i];
                sqlparas.Add(par);
                sql += " and " + fdata.Columns[i].ColumnName + "=@" + fdata.Columns[i].ColumnName;
            }
            DataTable rst = _sqldbhelper.ExecuteDataTable(sql,sqlparas);
            return rst;
        }
        /// <summary>
        /// 更新工序计划表体内容：更新逻辑为：FProjectHeadID=FProjectHeadID ，FWELDID=FWELDID
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable SaveProjectBody(DataTable data)
        {

            String Fieldstr = "FProjectHeadID,FWELDID,FWELDWPSID,FDoDepartID";
            DataTable rst = new DataTable();
            DataColumn col = new DataColumn("result", typeof(Boolean));
            rst.Columns.Add(col);
            DataColumn col1 = new DataColumn("msg", typeof(String));
            rst.Columns.Add(col1);
            DataColumn col2 = new DataColumn("FID", typeof(long));
            rst.Columns.Add(col2);
            DataView dv = data.Copy().DefaultView;
            DataTable dt = dv.ToTable(true, "FProjectHeadID","FDoDepartID");
            long vFProjectHeadID = 0;
            long vFDoDepartID = 0;
            String update = "update t_ProcessPlanBody set FWELDWPSID=@FWELDWPSID,FDoDepartID=@FDoDepartID where FProjectHeadID=@FProjectHeadID and FWELDID=@FWELDID";
            String insert = "insert into t_ProcessPlanBody(FProjectHeadID,FWELDID,FWELDWPSID,FDoDepartID) ";
            insert += " values(@FProjectHeadID,@FWELDID,@FWELDWPSID,@FDoDepartID)";




            object[] val;
            if (dt.Rows.Count > 0)
            {
                vFProjectHeadID =Convert.ToInt64( dt.Rows[0]["FProjectHeadID"]);
                vFDoDepartID = Convert.ToInt64(dt.Rows[0]["FDoDepartID"]);
            }
            else
            {
                val = new object[] { true, "未获取到工序计划表头FID", 1 };
                rst.Rows.Add(val);
                return rst;
            }
            String sql = "select * from t_ProcessPlanBody where FProjectHeadID=" + vFProjectHeadID+" and FDoDepartID="+vFDoDepartID ;
            DataTable sDT = _sqldbhelper.ExecuteDataTable(sql);
            ArrayList sqlparasList = new ArrayList();
            //准备参数
            for (int i = 0; i < sDT.Columns.Count; i++)
            {
                if (Fieldstr.IndexOf(sDT.Columns[i].ColumnName)>=0)
                {
                    SqlParameter par = new SqlParameter();
                    par.ParameterName = "@" + sDT.Columns[i].ColumnName;
                    par.SqlDbType = _sqldbhelper.tranDataType2SQl(sDT.Columns[i].DataType);
                    sqlparasList.Add(par);
                }
            }


            
            String finishWELDID = "0";
            String FinishWELDWPS = "0";

            for (int i = 0; i < data.Rows.Count; i++)
            {
                    
                dv = sDT.Copy().DefaultView;
                dv.RowFilter = "FProjectHeadID=" + vFProjectHeadID + " and FWELDID=" + Convert.ToInt64(data.Rows[i]["FWELDID"]);
                DataTable vdt = dv.ToTable();
                finishWELDID+=","+Convert.ToInt64(data.Rows[i]["FWELDID"]);

                for (int k = 0; k < sqlparasList.Count; k++)
                {
                    try
                    {
                        String fieldname = ((SqlParameter)sqlparasList[k]).ParameterName;
                        fieldname = fieldname.Substring(1);

                        ((SqlParameter)sqlparasList[k]).SqlValue = data.Rows[i][fieldname];
                    }
                    catch { }
                 
                }
                if (vdt.Rows.Count == 1)
                {
                    //执行更新；

                    _sqldbhelper.ExecuteNonQuery(update, CommandType.Text, sqlparasList);

                }
                else
                {
                    if (vdt.Rows.Count == 0)
                    {
                        _sqldbhelper.ExecuteNonQuery(insert, CommandType.Text, sqlparasList);
                    }

                    //执行插入

                }
            }
            //判断是否存在要删除的数据
            dv = sDT.Copy().DefaultView;
            dv.RowFilter = "FWELDID not in(" + finishWELDID + ") and FProjectHeadID=" + vFProjectHeadID;

            dt = dv.ToTable();
            String delete = "delete from t_ProcessPlanBody where FID=";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                long vfid = Convert.ToInt64(dt.Rows[i]["FID"]);
                _sqldbhelper.ExecuteNonQuery(delete + vfid);
            }



            val = new object[] { true, "工序计划更新成功", 1 };
            rst.Rows.Add(val);

                return rst;

        }
        /// <summary>
        /// 保存工序计划表体
        /// </summary>
        /// <param name="data">工序计划</param>
        /// <returns>处理结果</returns>
        public DataTable SaveProjectBody_Un(DataTable data )
        {
            
            String sql = "insert into t_ProcessPlanBody (";

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
            
            int int_rs = 0;
            for (int rowindex = 0; rowindex < data.Rows.Count; rowindex++)
            {
                ArrayList sqlparas = new ArrayList();
                DataRow rw = data.Rows[rowindex];

                for (int i = 0; i < data.Columns.Count; i++)
                {
                    SqlParameter para = new SqlParameter();
                    para.ParameterName = "@" + data.Columns[i].ColumnName;
                    //para.SqlDbType = _sqldbhelper.tranDataType2SQl(rw[i].GetType());
                    para.SqlValue = rw[i];
                    sqlparas.Add(para);
                }
                int_rs = _sqldbhelper.ExecuteNonQuery(sql, CommandType.Text, sqlparas);
            }


            if (int_rs == 0)
            {
                //执行错误，没有插入创建新的表头
                object[] val = new object[] { false, "表头插入失败", 0 };
                rst.Rows.Add(val);

            }
            else
            {
                object[] val = new object[] { true, "表头插入成功", int_rs };
                rst.Rows.Add(val);

            }
            return rst;

           
        }
        /// <summary>
        /// 更新工序计划头；
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public DataTable UpdateProjectHead(DataTable dt)
        {

            DataTable rst = new DataTable();
            DataColumn col = new DataColumn("result", typeof(Boolean));
            rst.Columns.Add(col);
            DataColumn col1 = new DataColumn("msg", typeof(String));
            rst.Columns.Add(col1);
            DataColumn col2 = new DataColumn("FID", typeof(long));
            rst.Columns.Add(col2);

            long vFID =Convert.ToInt64( dt.Rows[0]["FID"]);
            String sql = "select * from t_ProcessPlanHeader where FID=" + dt.Rows[0]["FID"]; 
            //获取原始数据
            String updatesql = "update t_ProcessPlanHeader set ";
            for (int i = 0; i < dt.Columns.Count-1; i++)
            {
                if (dt.Columns[i].ColumnName!="FID")
                updatesql += dt.Columns[i].ColumnName + "=@" + dt.Columns[i].ColumnName+",";
            }
            //dt.Columns.Count-1
            if (dt.Columns[dt.Columns.Count - 1].ColumnName != "FID")
            updatesql += dt.Columns[dt.Columns.Count - 1].ColumnName + "=@" + dt.Columns[dt.Columns.Count - 1].ColumnName ;
            if (updatesql.Substring(updatesql.Length - 1) == ",")
                updatesql=updatesql.Substring(0, updatesql.Length - 1);

            updatesql += " where FID=@FID";
            //准备数据
            ArrayList sqlparlst = new ArrayList();
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (dt.Columns[i].ColumnName != "FID")
                {
                    SqlParameter par = new SqlParameter();
                    par.ParameterName="@" + dt.Columns[i].ColumnName;
                    par.SqlDbType = _sqldbhelper.tranDataType2SQl(dt.Columns[i].DataType);
                    par.SqlValue = dt.Rows[0][dt.Columns[i].ColumnName];
                    sqlparlst.Add(par);
                }
            }
            SqlParameter fidpar = new SqlParameter();
            fidpar.ParameterName = "@FID";
            fidpar.SqlDbType = SqlDbType.BigInt;
            fidpar.SqlValue = vFID;
            sqlparlst.Add(fidpar);
            int rsc = _sqldbhelper.ExecuteNonQuery(updatesql, CommandType.Text, sqlparlst);
            if (rsc == 0)
            {
                //执行错误，没有插入创建新的表头
                object[] val = new object[] { false, "工序计划表头更新失败", 0 };
                rst.Rows.Add(val);

            }
            else
            {
                object[] val = new object[] { true, "工序计划表头更新成功", 1 };
                rst.Rows.Add(val);

            }
            return rst;
        }
        /// <summary>
        /// 保存新创建的工序计划；
        /// </summary>
        /// <param name="data">保存表头</param>
        /// <returns>返回表头的FID</returns>
        public DataTable SaveProjectHead(DataTable data)
        {
            //工序计划名称,工序计划编码,开始时间,结束时间,状态
            //下发部门,下发时间,状态,是否管控
            //Fname,Fnum,FSTARTTIME,FENDTIME,Fstate,FDepartID,Fdate,FState,FISControl
            Boolean exres = false;
            String msg = "";

            long maxFID = 0;
            DataTable rst = new DataTable();
            DataColumn col=new DataColumn("result",typeof(Boolean));
            rst.Columns.Add(col);
            DataColumn col1 = new DataColumn("msg", typeof(String));
            rst.Columns.Add(col1);
            DataColumn col2 = new DataColumn("FID", typeof(long));
            rst.Columns.Add(col2);
            //判断是否是更新
            try
            {
                long vFID = Convert.ToInt64(data.Rows[0]["FID"]);
                return UpdateProjectHead(data);
            }
            catch(Exception err)
            {
                String errmsg = err.Message;
                
            }
            String sql = "select max(FID) from t_ProcessPlanHeader";
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
            DataRow row=data.Rows[0];
            //sql = "inert into t_ProcessPlanHeader (Fname,Fnum,FSTARTTIME,FENDTIME,Fstate,FDepartID,Fdate,FISControl) values(";
            //sql += " '" + row["Fname"] + "','" + row["Fnum"] + "','" + row["FSTARTTIME"] + "','" + row["FENDTIME"] + "'," + row["Fstate"] + "," + row["FDepartID"] + ",'" + row["Fdate"] + "'," + row["FISControl"] + ")";
            //_sqldbhelper.ExecuteNonQuery(sql);
            sql = "insert into t_ProcessPlanHeader (";
            for (int i = 0; i < data.Columns.Count-1; i++)
            {
                
                sql += data.Columns[i].ColumnName+" , ";
            }
            sql += data.Columns[data.Columns.Count - 1].ColumnName+") values(";
            for (int i = 0; i < data.Columns.Count - 1; i++)
            {

                sql += "@"+data.Columns[i].ColumnName + " , ";
            }
            sql += "@" + data.Columns[data.Columns.Count - 1].ColumnName + " ) ";
            ArrayList sqlparas = new ArrayList();
            DataRow rw=data.Rows[0];

            for (int i = 0; i < data.Columns.Count; i++)
            {
                SqlParameter para = new SqlParameter();
                para.ParameterName = "@" + data.Columns[i].ColumnName;
                //para.SqlDbType = _sqldbhelper.tranDataType2SQl(rw[i].GetType());
                para.SqlValue = rw[i];
                sqlparas.Add(para);
            }
            int int_rs=_sqldbhelper.ExecuteNonQuery(sql,CommandType.Text, sqlparas);


            sql = "select max(FID) from t_ProcessPlanHeader ";
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
                object[] val = new object[] { true, "表头插入成功",dt1.Rows[0][0] };
                rst.Rows.Add(val);
                
            }
            return rst;

        }
    }
}
