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
    class svrWelder:_clsdb
    {
        public DataTable Updatealm(DataTable dt)
        {
            DataTable rpdt = null;
            if (dt.Rows.Count == 1)
            {
                String proname = "GroupWeldEval";
                SqlParameter[] StoredProcedureparas = new SqlParameter[3];
                SqlParameter spa = new SqlParameter();
                spa.ParameterName = "@SDTime";
                spa.SqlDbType = SqlDbType.DateTime;
                spa.SqlValue = Convert.ToDateTime(dt.Rows[0]["SDTime"].ToString());
                StoredProcedureparas[0] = spa;

                spa = new SqlParameter();
                spa.ParameterName = "@EDTime";
                spa.SqlDbType = SqlDbType.DateTime;
                spa.SqlValue = Convert.ToDateTime(dt.Rows[0]["EDTime"].ToString());
                StoredProcedureparas[1] = spa;

                spa = new SqlParameter();
                spa.ParameterName = "@nom";
                spa.SqlDbType = SqlDbType.BigInt;
                spa.SqlValue = Convert.ToInt32(dt.Rows[0]["nom"].ToString());
                StoredProcedureparas[2] = spa;
                rpdt = _sqldbhelper.ExecuteDataTable(proname, CommandType.StoredProcedure, StoredProcedureparas);
            }
            return rpdt;
            
        }
        public DataTable Updatecot(DataTable dt)
        {
            DataTable rpdt = null;
            if (dt.Rows.Count == 1)
            {
                String proname = "GroupWeldEval_Data";
                SqlParameter[] StoredProcedureparas = new SqlParameter[3];
                SqlParameter spa = new SqlParameter();
                spa.ParameterName = "@SDTime";
                spa.SqlDbType = SqlDbType.DateTime;
                spa.SqlValue = Convert.ToDateTime(dt.Rows[0]["SDTime"].ToString());
                StoredProcedureparas[0] = spa;

                spa = new SqlParameter();
                spa.ParameterName = "@EDTime";
                spa.SqlDbType = SqlDbType.DateTime;
                spa.SqlValue = Convert.ToDateTime(dt.Rows[0]["EDTime"].ToString());
                StoredProcedureparas[1] = spa;

                spa = new SqlParameter();
                spa.ParameterName = "@nom";
                spa.SqlDbType = SqlDbType.BigInt;
                spa.SqlValue = Convert.ToInt32(dt.Rows[0]["nom"].ToString());
                StoredProcedureparas[2] = spa;
                rpdt = _sqldbhelper.ExecuteDataTable(proname, CommandType.StoredProcedure, StoredProcedureparas);
            }
            return rpdt;

        }
    }
}
