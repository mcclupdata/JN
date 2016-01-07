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
    class svrWPSEdit:_clsdb
    {
        String tmpField = "WelderName,IdentificationCard,WeldingProcessAb,WeldingType,WeldingClass,WelderWorkerID,WelderDepartment,WelderWorkPlace,WelderWorkClass,WelderLaborServiceTeam";
        String tmpFieldType = "0,0,0,0,0,0,0,0,0,0";
        DataTable sData;
        String sql = "";
        String Tablename = "";

        public svrWPSEdit()
        {
            //sData = data;
        }
        /// <summary>
        /// 加载WPS规程主规程
        /// </summary>
        /// <returns></returns>
        public DataTable LoadWPS()
        {
            String sql = "select * from t_wps_rule where FID>0";
            return _sqldbhelper.ExecuteDataTable(sql);
        }
        /// <summary>
        /// 批量更新WPS  命令代码5101401
        /// </summary>
        /// <param name="data">待更新数据</param>
        /// <returns>执行结果</returns>
        public DataTable UpdateWPS(String data,int vtype)
        {
            DataTable dt = new DataTable();
            String selwpsSQL = "Select * from t_wps_RULE where FID>0";
            //DataSet ds = _sqldbhelper.ExecuteDataSet(selwpsSQL+" where FID=0");
            dt = clsConvertXMLDataTable.ConvertXMLToDataTable(data); ;//clsConvertXMLDataTable.ConvertXMLtoDataSet(data, ds);

            dt = _sqldbhelper.UpdateByDataTable(selwpsSQL, dt, "FID",vtype);
           
            return dt;
        }
        /// <summary>
        /// 批量更新WPS子规程 5101402
        /// </summary>
        /// <param name="data">待更新数据</param>
        /// <returns>执行结果</returns>
        public DataTable UpdateSUBWPS(String data,int vtype)
        {
            DataTable dt = new DataTable();
            String selwpsSQL = "Select * from t_wps_WELDTUN";
            DataSet ds = _sqldbhelper.ExecuteDataSet(selwpsSQL);
            dt = clsConvertXMLDataTable.ConvertXMLtoDataSet(data, ds);
             dt = _sqldbhelper.UpdateByDataTable(selwpsSQL, dt, "FID",vtype);

            return dt;
        }


        /// <summary>
        /// 加载WPS子规程
        /// </summary>
        /// <returns></returns>
        public DataTable LoadWPSSub()
        {
            String sql = "select  * from t_wps_WELDTUN";
            return _sqldbhelper.ExecuteDataTable(sql);
        }
        /// <summary>
        /// 删除WPS规程
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable DeleteWPS(DataTable data)
        {
            String delsql_wpssub = "delete from t_wps_weldtun where RuleNum=@RuleNum";
            String delsql_wps = "delete from t_wps_Rule where RuleNum=@RuleNum";

            DataTable rst = new DataTable();
            DataColumn colrs = new DataColumn("result", typeof(Boolean));
            rst.Columns.Add(colrs);
            DataColumn col1 = new DataColumn("msg", typeof(String));
            rst.Columns.Add(col1);
            DataColumn col2 = new DataColumn("FID", typeof(long));
            rst.Columns.Add(col2);

            for (int i = 0; i < data.Rows.Count; i++)
            {
                ArrayList delparams = new ArrayList();
                SqlParameter pa = new SqlParameter("@RuleNum", SqlDbType.NVarChar);
                pa.SqlValue = data.Rows[i]["RuleNum"];
                delparams.Add(pa);
                _sqldbhelper.ExecuteNonQuery(delsql_wpssub, CommandType.Text, delparams);
                _sqldbhelper.ExecuteNonQuery(delsql_wps, CommandType.Text, delparams);
            }
            DataRow nrw = rst.NewRow();
            nrw["FID"] = 0; nrw["result"] = 0; nrw["msg"] = "删除完成";
            rst.Rows.Add(nrw);
            return rst;

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
