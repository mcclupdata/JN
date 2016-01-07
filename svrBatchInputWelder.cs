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
    class svrBatchInputWelder:_clsdb
    {
        String tmpField = "WelderName,IdentificationCard,WeldingProcessAb,WeldingType,WeldingClass,WelderWorkerID,WelderDepartment,WelderWorkPlace,WelderWorkClass,WelderLaborServiceTeam";
        String tmpFieldType = "0,0,0,0,0,0,0,0,0,0";
        DataTable sData;
        String sql = "";
        String Tablename = "";

        public svrBatchInputWelder(DataTable data)
        {
            sData = data;
        }
        public DataTable Execut()
        {
            DataTable dt ;//= vdt;
            //清除临时表的数据
            sql = "truncate  table tmpWelder";
            
            _sqldbhelper.ExecuteNonQuery(sql);
           

            //保存到临时表中;
            sql = "insert into tmpWelder (" + tmpField + ") values(";
            String[] fieldgp = tmpField.Split(',');
            for (int i = 0; i < fieldgp.Length; i++)
            {
                sql += "@"+fieldgp[i];
                if (i == fieldgp.Length - 1)
                {
                    sql+=")";
                }
                else
                {
                    sql += ",";
                }
            }
            for (int rc = 0; rc < sData.Rows.Count; rc++)
            {
                DataRow row = sData.Rows[rc];
                ArrayList paras = new ArrayList();
                for (int i = 0; i < fieldgp.Length; i++)
                {
                    SqlParameter para = new SqlParameter();
                    para.ParameterName = "@" + fieldgp[i];
                    para.SqlDbType = SqlDbType.NVarChar;
                    para.SqlValue = row[fieldgp[i]];
                    paras.Add(para);
                }
                _sqldbhelper.ExecuteNonQuery(sql, CommandType.Text, paras);
            }
            //调用存储过程进行数据整理；
            String proname = "batchinputwelder";
            dt=_sqldbhelper.ExecuteProcedureNoParams(proname);
            //完成导入，并将结果返回；
            return dt;
        }
    }
}
