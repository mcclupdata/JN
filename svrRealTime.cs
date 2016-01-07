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
    class svrRealTime : _clsdb
    {
        /// <summary>
        /// 1043 获取历史数据的评估结果
        /// </summary>
        /// <param name="fd"></param>
        /// <returns></returns>
        public DataTable GetHistoryEvaResult(DataTable fd)
        {
            String proname = "evaluate_weld";
            SqlParameter[] sqlparas = new SqlParameter[2];
            SqlParameter pa = new SqlParameter();
            pa.ParameterName = "@PID";
            pa.SqlDbType = SqlDbType.BigInt;
            pa.SqlValue = fd.Rows[0]["FID"];
            sqlparas[0] = pa;
            pa = new SqlParameter();
            pa.ParameterName = "@WELD_PASS";
            pa.SqlDbType = SqlDbType.BigInt;
            pa.SqlValue = fd.Rows[0]["channel"];
            sqlparas[1] = pa;
            DataTable dt = _sqldbhelper.ExecuteDataTable(proname, CommandType.StoredProcedure, sqlparas);
            return dt;

        }
        //1042 
        /// <summary>
        /// 获取焊工任务的详细信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetWelderTaskInfos(DataTable fd)
        {
            String sql = " select  * from View_Task_Welder_ALL where FSTARTTIME=@FSTARTTIME and FWelderID=@FWELDERID";
            ArrayList sqlparas = new ArrayList();
            SqlParameter pa = new SqlParameter();
            pa.ParameterName = "@FSTARTTIME";
            pa.SqlDbType = SqlDbType.DateTime;
            pa.SqlValue = fd.Rows[0]["FSTARTTIME"];
            sqlparas.Add(pa);
            pa = new SqlParameter();
            pa.ParameterName = "@FWELDERID";
            pa.SqlDbType = SqlDbType.BigInt;
            pa.SqlValue = fd.Rows[0]["FWELDERID"];
            sqlparas.Add(pa);
            DataTable dt = _sqldbhelper.ExecuteDataTable(sql, sqlparas);
            return dt;

        }

        /// <summary>
        /// 获取焊工给定日期的任务小结 1041
        /// </summary>
        /// <returns></returns>
        public DataTable GetWelderTaskSum(DataTable fd)
        {
            string sql = "select *,";
            sql += "(Select COUNT(FID) from t_TaskListBody where FSTARTTIME=@FSTARTTIME and FActOpStartTime is null and FActOpEndTime is null  and FWELDERID=t_welder.FID) as Undo ,";
            sql += "(Select COUNT(FID) from t_TaskListBody where FSTARTTIME=@FSTARTTIME and FActOpStartTime is not null and FActOpEndTime is null and FWELDERID=t_welder.FID) as Doing ,";
            sql += "(Select COUNT(FID) from t_TaskListBody where FSTARTTIME=@FSTARTTIME and FActOpStartTime is not null and FActOpEndTime is not null and FWELDERID=t_welder.FID) as Done ";
            sql += " from  t_welder where fdepart=@fdepart ";
            String sTime = "";
            long fdepartid = 0;
            ArrayList sqlparas = new ArrayList();
            SqlParameter pa = new SqlParameter();
            pa.ParameterName = "@FSTARTTIME";
            pa.SqlDbType = SqlDbType.DateTime;
            pa.SqlValue = fd.Rows[0]["FSTARTTIME"];
            sqlparas.Add(pa);
            pa = new SqlParameter();
            pa.ParameterName = "@fdepart";
            pa.SqlDbType = SqlDbType.BigInt;
            pa.SqlValue = fd.Rows[0]["FDEPART"];
            sqlparas.Add(pa);
            DataTable dt = _sqldbhelper.ExecuteDataTable(sql, sqlparas);
            return dt;
        }
    }
}
