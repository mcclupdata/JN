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
    /// 焊缝信息处理对象
    /// </summary>
    class clsdbweld:_clsdb
    {
       
        public clsdbweld()
        {
        }
        /// <summary>
        /// 批量导入焊缝数据
        /// </summary>
        /// <param name="data">从Excel文件中去读的数据</param>
        /// <returns></returns>
        public DataTable batchinputwelds(DataTable data)
        {
            long maxfid = 0;
            //获取最大值
            String sqlmx = "select max(fid) from t_weld";
            DataTable dt1= _sqldbhelper.ExecuteDataTable(sqlmx);
            if (dt1 == null)
            {
                return null;
            }
            if (dt1.Rows.Count == 0)
            {
                maxfid = 0;
            }
            else
            {
                maxfid =Convert.ToInt64( dt1.Rows[0][0]);
            }

            String sql = "insert into t_weld(SHIP_ID,SHIP_NO,BLK_NO,TREE_NAME,WELD_NO,PART1_NAME2,PART2_NAME2,AS3";
            sql+=",BUFF1,THICK1,THICK2,WELD1_CODE,WELD2_CODE,GRADE1,GRADE2,WELD_TYPE,ASS1_NAME,WELD_ANGLE_H,ASS2_NAME,WELD_COUNT,";
            sql+="PART1_TYPE,PART2_TYPE,TIP_ANGLE,WELD_T_LEN,WELD_NOTE,WELD_POS,WELD_MOD)";
            String sqlvalue = "";
            String sqlcmd = "";
            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow row=data.Rows[i];
                sqlvalue = " values('" + row["SHIP_ID"] + "','" + row["SHIP_NO"] + "','" + row["BLK_NO"] + "','" + row["TREE_NAME"] + "','" + row["WELD_NO"] + "','" + row["PART1_NAME2"] + "','" + row["PART2_NAME2"] + "','" + row["AS3"] + "','";
                sqlvalue += row["BUFF1"] + "','" + row["THICK1"] + "','" + row["THICK2"] + "','" + row["WELD1_CODE"] + "','" + row["WELD2_CODE"] + "','" + row["GRADE1"] + "','" + row["GRADE2"] + "','" + row["WELD_TYPE"] + "','" + row["ASS1_NAME"] + "','" + row["WELD_ANGLE_H"] + "','" + row["ASS2_NAME"] + "','" + row["WELD_COUNT"] + "','";
                sqlvalue += row["PART1_TYPE"] + "','" + row["PART2_TYPE"] + "','" + row["TIP_ANGLE"] + "','" + row["WELD_T_LEN"] + "','" + row["WELD_NOTE"] + "','" + row["WELD_POS"] + "','" + row["WELD_COUNT"] + "')";
                sqlcmd = sql + sqlvalue;
                this._sqldbhelper.ExecuteNonQuery(sqlcmd);
            }
            //返回导入的数据结果集
            sql = "select * from t_weld where FID>" + maxfid.ToString();
            dt1 = new DataTable();
            dt1 = _sqldbhelper.ExecuteDataTable(sql);
            return dt1;

        }

    }
}
