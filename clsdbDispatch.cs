using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
namespace JN_WELD_Service
{
    /// <summary>
    /// 派工单处理
    /// </summary>
    class clsdbDispatch:_clsdb
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public clsdbDispatch()
        {
        }
        /// <summary>
        /// 保存派工单表体
        /// </summary>
        /// <param name="data">工序计划</param>
        /// <returns>处理结果</returns>
        public DataTable SaveDispatchBody(DataTable data )
        {
            

            DataTable rst = new DataTable();
            DataColumn col = new DataColumn("result", typeof(Boolean));
            rst.Columns.Add(col);
            DataColumn col1 = new DataColumn("msg", typeof(String));
            rst.Columns.Add(col1);
            DataColumn col2 = new DataColumn("FID", typeof(long));
            rst.Columns.Add(col2);
            //派工表头内码	FDispatchHeadID
            //工序计划表体内码	FProjectBodyID
            //状态	FSTATE
            //执行部门	FOPDEPARTID

            String sql = "insert into t_DispatchingBody (FDispatchHeadID,FProjectBodyID,FSTATE,FOPDEPARTID)";
            sql += " values(@FDispatchHeadID,@FProjectBodyID,@FSTATE,@FOPDEPARTID)";
            //定义sql参数 7
            SqlParameter[] pars = new SqlParameter[4];
            
            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow row = data.Rows[i];
                row=data.Rows[i];
                pars[0].ParameterName = "@FDispatchHeadID";
                pars[0].SqlDbType = SqlDbType.BigInt;
                pars[0].SqlValue = row["FDispatchHeadID"];

                pars[1].ParameterName = "@FProjectBodyID";
                pars[1].SqlDbType = SqlDbType.BigInt;
                pars[1].SqlValue = row["FProjectBodyID"];

                pars[2].ParameterName = "@FSTATE";
                pars[2].SqlDbType = SqlDbType.Int;
                pars[2].SqlValue = row["FSTATE"];

                pars[3].ParameterName = "@FOPDEPARTID";
                pars[3].SqlDbType = SqlDbType.BigInt;
                pars[3].SqlValue = row["FOPDEPARTID"];
                _sqldbhelper.ExecuteNonQuery(sql, CommandType.Text, pars);

            }
            object[] val = new object[] { false, "派工单表体保存成功",0};
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
            //工序计划表头内码,派工单编码，开始时间，结束时间，派工单位，承接单位，状态，上级派工单内码，承接单位类别

            // FProjectHeadID，Fnum，FSTARTTIME，FENDTIME，FBeginDepartID，FEndDepartID，Fstate，FParentDispatchID，FDoDepartTypeID
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

            String sql = "select max(FID) from t_DispatchingHeader";
            DataTable dt1 = _sqldbhelper.ExecuteDataTable(sql);
            //获取最大FID;
            if (dt1.Rows.Count == 0)
                maxFID = 0;
            else
                maxFID = Convert.ToInt64(dt1.Rows[0][0]);
            return rst;
            DataRow row = data.Rows[0];
            sql = "inert into t_DispatchingHeader (FProjectHeadID,Fnum,FSTARTTIME,FENDTIME,FBeginDepartID,FEndDepartID,Fstate,FParentDispatchID,FDoDepartTypeID) values(";
            sql += " values(@FProjectHeadID,@Fnum,@FSTARTTIME,@FENDTIME,@FBeginDepartID,@FEndDepartID,@Fstate,@FParentDispatchID,@FDoDepartTypeID)";

            SqlParameter[] pars=new SqlParameter[9];
            pars[0].SqlDbType = SqlDbType.BigInt;
            pars[0].ParameterName = "@FProjectHeadID";
            pars[0].Value = row["FProjectHeadID"];

            pars[1].SqlDbType = SqlDbType.NVarChar;
            pars[1].ParameterName = "@Fnum";
            pars[1].Value = row["Fnum"];

            pars[2].SqlDbType = SqlDbType.DateTime;
            pars[2].ParameterName = "@FSTARTTIME";
            pars[2].Value = row["FSTARTTIME"];

            pars[3].SqlDbType = SqlDbType.DateTime;
            pars[3].ParameterName = "@FENDTIME";
            pars[3].Value = row["FENDTIME"];

            pars[4].SqlDbType = SqlDbType.BigInt;
            pars[4].ParameterName = "@FBeginDepartID";
            pars[4].Value = row["FBeginDepartID"];

            pars[5].SqlDbType = SqlDbType.BigInt;
            pars[5].ParameterName = "@FEndDepartID";
            pars[5].Value = row["FEndDepartID"];

            pars[5].SqlDbType = SqlDbType.Int;
            pars[5].ParameterName = "@Fstate";
            pars[5].Value = row["Fstate"];

            pars[6].SqlDbType = SqlDbType.BigInt;
            pars[6].ParameterName = "@FParentDispatchID";
            pars[6].Value = row["FParentDispatchID"];


            pars[7].SqlDbType = SqlDbType.Int;
            pars[7].ParameterName = "@FDoDepartTypeID";
            pars[7].Value = row["FDoDepartTypeID"];






            _sqldbhelper.ExecuteNonQuery(sql,CommandType.Text,pars);
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
                object[] val = new object[] { false, "表头插入成功",dt1.Rows[0][0] };
                rst.Rows.Add(val);
                
            }
            return rst;

        }
    }
}
