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
    //hh
    /// <summary>
    /// 任务单处理
    /// </summary>
    class clsdbTask:_clsdb
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public clsdbTask()
        {
        }
        /// <summary>
        /// 保存任务单表体
        /// </summary>
        /// <param name="data">任务单表体内容</param>
        /// <returns>处理结果</returns>
        public DataTable SaveTaskBody(DataTable data )
        {
            

            DataTable rst = new DataTable();
            DataColumn col = new DataColumn("result", typeof(Boolean));
            rst.Columns.Add(col);
            DataColumn col1 = new DataColumn("msg", typeof(String));
            rst.Columns.Add(col1);
            DataColumn col2 = new DataColumn("FID", typeof(long));
            rst.Columns.Add(col2);
           //任务单表头内码	FTASKHEADID
            //派工单表体内吗	FDispatchBodyID
            //实际执行时间	FActOpStartTime
            //实际结束时间	FActOpEndTime
            //实际执行焊机ID	FweldDriverID
            //状态	FSTATE
            //执行焊工	FWelderID
            String fieldstr = "FTASKHEADID,FDispatchBodyID,FActOpStartTime,FActOpEndTime,FweldDriverID,FSTATE,FWelderID";

            String sql = "insert into t_DispatchingBody (FDispatchHeadID,FProjectBodyID,FSTATE,FOPDEPARTID)";
            sql += " values(@FDispatchHeadID,@FProjectBodyID,@FSTATE,@FOPDEPARTID)";
            //定义sql参数 7
            SqlParameter[] pars = new SqlParameter[4];
            
            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow row=data.Rows[i];
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
        /// 保存新创建的任务单；
        /// </summary>
        /// <param name="data">保存任务单表头</param>
        /// <returns>返回表头的FID</returns>
        public DataTable SaveTaskHead(DataTable data)
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

            String sql = "select max(FID) from t_TaskListHeader";
            DataTable dt1 = _sqldbhelper.ExecuteDataTable(sql);
            //获取最大FID;
            if (dt1.Rows.Count == 0)
                maxFID = 0;
            else
                maxFID = Convert.ToInt64(dt1.Rows[0][0]);
            return rst;
            DataRow row = data.Rows[0];
            // 工序计划表头内码	FProjectHeadID
            // 派工单表头内码	FDispatchHeadID
            // 计划开始时间	FPROJETSTARTTIME
            // 计划结束时间	FPROJECTENDTIME
            //下达单位	FORDERDEPART
            // 任务单编号	FTASKNUM
            // 实际开始时间	FACTSTARTTIME
            // 实际结束时间	FACTENDTIME
            // 承接焊工	FWELDER
            // 状态	FSTATE

            sql = "inert into t_TaskListHeader (FProjectHeadID,FDispatchHeadID,FPROJETSTARTTIME,FPROJECTENDTIME,FORDERDEPART,FTASKNUM,FACTSTARTTIME,FACTENDTIME,FWELDER,FSTATE) values(";
            sql += " values(@FProjectHeadID,@FDispatchHeadID,@FPROJETSTARTTIME,@FPROJECTENDTIME,@FORDERDEPART,@FTASKNUM,@FACTSTARTTIME,@FACTENDTIME,@FWELDER,@FSTATE)";


            // 工序计划表头内码	FProjectHeadID
            // 派工单表头内码	FDispatchHeadID
            // 计划开始时间	FPROJETSTARTTIME
            // 计划结束时间	FPROJECTENDTIME
            //下达单位	FORDERDEPART
            // 任务单编号	FTASKNUM
            // 实际开始时间	FACTSTARTTIME
            // 实际结束时间	FACTENDTIME
            // 承接焊工	FWELDER
            // 状态	FSTATE
            SqlParameter[] pars=new SqlParameter[11];
            //FProjectHeadID
            pars[0].SqlDbType = SqlDbType.BigInt;
            pars[0].ParameterName = "@FProjectHeadID";
            pars[0].Value = row["FProjectHeadID"];
            //FDispatchHeadID
            pars[1].SqlDbType = SqlDbType.BigInt;
            pars[1].ParameterName = "@FDispatchHeadID";
            pars[1].Value = row["FDispatchHeadID"];
            //FPROJETSTARTTIME
            pars[2].SqlDbType = SqlDbType.DateTime;
            pars[2].ParameterName = "@FPROJETSTARTTIME";
            pars[2].Value = row["FPROJETSTARTTIME"];
            //FPROJECTENDTIME
            pars[3].SqlDbType = SqlDbType.DateTime;
            pars[3].ParameterName = "@FPROJECTENDTIME";
            pars[3].Value = row["FPROJECTENDTIME"];
            //FORDERDEPART
            pars[4].SqlDbType = SqlDbType.BigInt;
            pars[4].ParameterName = "@FORDERDEPART";
            pars[4].Value = row["FORDERDEPART"];
            //FTASKNUM
            pars[5].SqlDbType = SqlDbType.NVarChar;
            pars[5].ParameterName = "@FTASKNUM";
            pars[5].Value = row["FTASKNUM"];
            //FACTSTARTTIME
            pars[6].SqlDbType = SqlDbType.DateTime;
            pars[6].ParameterName = "@FACTSTARTTIME";
            pars[6].Value = row["FACTSTARTTIME"];
            //FACTENDTIME
            pars[7].SqlDbType = SqlDbType.DateTime;
            pars[7].ParameterName = "@FACTENDTIME";
            pars[7].Value = row["FACTENDTIME"];

            //FWELDER
            pars[8].SqlDbType = SqlDbType.BigInt;
            pars[8].ParameterName = "@FWELDER";
            pars[8].Value = row["FWELDER"];
            //FSTATE
            pars[9].SqlDbType = SqlDbType.Int;
            pars[9].ParameterName = "@FSTATE";
            pars[9].Value = row["FSTATE"];

         






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
