using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections;
namespace JN_WELD_Service
{
    /// <summary>
    /// 后台处理焊工信息导入；
    /// </summary>
    class svrBatchInputWPS:_clsdb
    {
        String tmpField = "WelderName,IdentificationCard,WeldingProcessAb,WeldingType,WeldingClass,WelderWorkerID,WelderDepartment,WelderWorkPlace,WelderWorkClass,WelderLaborServiceTeam";
        String tmpFieldType = "0,0,0,0,0,0,0,0,0,0";
        DataTable sData;
        String sql = "";
        String Tablename = "";

        public svrBatchInputWPS()
        {
            //sData = data;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data_wpssub"></param>
        /// <returns></returns>
        public DataTable Savetotmp_wpssub(DataTable data_wpssub)
        {
            //保存到临时表中;
            try
            {
                String cnnstr = _sqldbhelper.ConnectionString;
                SqlBulkCopy bcp = new SqlBulkCopy(cnnstr);
                bcp.DestinationTableName = "tmpwpssub";
                bcp.WriteToServer(data_wpssub);
                DataTable dt = _sqldbhelper.ExecuteProcedureNoParams("Batchinputwpssub");

                return dt;
            }
            catch (Exception ex)
            {
                String s = ex.Message;
                return null;
            }
        }
        /// <summary>
        /// 将WPS数据保存到临时表中
        /// </summary>
        /// <param name="data_wps"></param>
        /// <returns></returns>
        public DataTable Savetotmp_wps(DataTable data_wps)
        {
            //保存到临时表中;
            String cnnstr = _sqldbhelper.ConnectionString;
            SqlBulkCopy bcp = new SqlBulkCopy(cnnstr);
            bcp.DestinationTableName = "tmpwps";
            bcp.WriteToServer(data_wps);
            DataTable dt = _sqldbhelper.ExecuteProcedureNoParams("Batchinputwps");
            return dt;
        }
        public DataTable Execut(String proname)
        {
            DataTable dt;
            //清除临时表的数据
      
            //调用存储过程进行数据整理；
       
            dt=_sqldbhelper.ExecuteProcedureNoParams(proname);
            //完成导入，并将结果返回；
            return dt;
        }
    }
}
