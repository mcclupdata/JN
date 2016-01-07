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
    class svrBatchInputWeldinfos:_clsdb
    {
        String tmpField = "SHIP_ID,SHIP_NO,BLK_NO,TREE_NAME,WELD_NO,PART1_NAME2,PART2_NAME2,AS3,BUFF1,THICK1,THICK2,WELD1_CODE,WELD2_CODE,GRADE1,GRADE2,WELD_TYPE,ASS1_NAME,WELD_ANGLE_H,ASS2_NAME,WELD_COUNT,PART1_TYPE,PART2_TYPE,TIP_ANGLE,WELD_T_LEN,WELD_NOTE,WELD_POS,WELD_MOD,RuleNum,ANGEL1,ANGEL2,ANGEL3";
        String tmpFieldType = "0,0,0,0,0,0,0,0,0,6,6,0,0,0,0,0,0,6,0,2,0,0,0,0,0,0,0,0,6,6,6";
        /// <summary>
        /// 2015-12-16 将数据源中的RuleNum更改为WPS_NO
        /// </summary>
        String sourceField = "SHIP_ID,SHIP_NO,BLK_NO,TREE_NAME,WELD_NO,PART1_NAME2,PART2_NAME2,AS3,BUFF1,THICK1,THICK2,WELD1_CODE,WELD2_CODE,GRADE1,GRADE2,WELD_TYPE,ASS1_NAME,WELD_ANGLE_H,ASS2_NAME,WELD_COUNT,PART1_TYPE,PART2_TYPE,TIP_ANGLE,WELD_T_LEN,WELD_NOTE,WELD_POS,WELD_MOD,WPS_NO,ANGEL1,ANGEL2,ANGEL3";

        DataTable sData;
        String sql = "";
        String Tablename = "";

        public svrBatchInputWeldinfos(DataTable data)
        {
            sData = data;
        }
        public DataTable Execut()
        {
            DataTable dt;
            //清除临时表的数据
            sql = "truncate  table tmpWeldinfos";
            _sqldbhelper.ExecuteNonQuery(sql);
            //保存到临时表中;
            sql = "insert into tmpWeldinfos (" + tmpField + ") values(";
            String[] fieldgp = tmpField.Split(',');
            /// <summary>
            /// 2015-12-16 将数据源中的RuleNum更改为WPS_NO
            /// </summary>
            String[] sourceFields = sourceField.Split(',');
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
                  
                    para.ParameterName = "@" +fieldgp[i];
                    para.SqlDbType = SqlDbType.NVarChar;
                    /// <summary>
                    /// 2015-12-16 将数据源中的RuleNum更改为WPS_NO
                    /// </summary>
                    para.SqlValue = row[sourceFields[i]];
                    paras.Add(para);
                }
                _sqldbhelper.ExecuteNonQuery(sql, CommandType.Text, paras);
            }
            //调用存储过程进行数据整理；
            String proname = "batchinputweldinfos";
            dt=_sqldbhelper.ExecuteProcedureNoParams(proname);
            //完成导入，并将结果返回；
            return dt;
        }
    }
}
