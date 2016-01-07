using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
namespace JN_WELD_Service
{
    class _clsdb
    {
        protected SqlDbHelper _sqldbhelper;
        public _clsdb()
        {
            _sqldbhelper = new SqlDbHelper();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable Delete(long fid,String tablename)
        {

            long maxFID = 0;
            DataTable rst = new DataTable();
            DataColumn col = new DataColumn("result", typeof(Boolean));
            rst.Columns.Add(col);
            DataColumn col1 = new DataColumn("msg", typeof(String));
            rst.Columns.Add(col1);
            DataColumn col2 = new DataColumn("FID", typeof(long));
            rst.Columns.Add(col2);

            String sql = "Delete from " + tablename + " where FID=@FID";
            SqlParameter para = new SqlParameter();
            para.ParameterName = "@FID";
            para.SqlDbType = SqlDbType.BigInt;
            para.SqlValue = fid;
            ArrayList sqlparams = new ArrayList();
            sqlparams.Add(para);
            _sqldbhelper.ExecuteNonQuery(sql, CommandType.Text, sqlparams);
            return rst;
        }
        /// <summary>
        /// 进行统一查询
        /// </summary>
        /// <param name="data">查询条件</param>
        /// <param name="TableName">查询表或视图</param>
        /// <returns>返回查询结构</returns>
        public DataTable Search(DataTable data ,String TableName)
        {//执行查询工作
            //字段，条件，匹配值，类型
            String sql = "select * from " + TableName + " where 1=1";
            for (int rc = 0; rc < data.Rows.Count; rc++)
            {
                DataRow  row=data.Rows[rc];

                sql += " and " + row[0] + row[1] + "@" + row[0];
                
            }
            ArrayList sqlparams = new ArrayList();
            for (int rc = 0; rc < data.Rows.Count; rc++)
            {
                DataRow row = data.Rows[rc];

                Type t = Type.GetType(row[3].ToString());
                SqlParameter para = new SqlParameter();
                para.ParameterName = "@" + row[0];
                para.SqlDbType = _sqldbhelper.tranDataType2SQl(t);
                para.SqlValue = row[2];

            }
            return _sqldbhelper.ExecuteDataTable(sql, sqlparams);
        }
        /// <summary>
        /// 根据FID进行更新处理；
        /// </summary>
        /// <param name="upFieldstr">需要更新的字段</param>
        /// <param name="upFieldType">需要更新的字段类型</param>
        /// <param name="data">更新数据</param>
        /// <returns></returns>
        /// <param name="Tablename">需要更新的表</param>
        public DataTable Update(String upFieldstr,String upFieldType,String Tablename ,DataTable data)
        {
            long maxFID = 0;
            DataTable rst = new DataTable();
            DataColumn col = new DataColumn("result", typeof(Boolean));
            rst.Columns.Add(col);
            DataColumn col1 = new DataColumn("msg", typeof(String));
            rst.Columns.Add(col1);
            DataColumn col2 = new DataColumn("FID", typeof(long));
            rst.Columns.Add(col2);

            String sql = "Update "+Tablename +" set ";
            String[] upFieldgp = upFieldstr.Split(',');
            String[] upFieldTypegp = upFieldType.Split(',');
            for (int i = 0; i < upFieldgp.Length; i++)
            {
                sql += upFieldgp[i] + " = " + "@" + upFieldgp[i];
                if (i == upFieldgp.Length - 1)
                {
                    sql += " where FID=@FID";
                }
                else
                {
                    sql += " , ";
                }
            }
            for (int rc=0;rc<data.Rows.Count;rc++)
            {
                ArrayList sqlparams = new ArrayList();
                DataRow row=data.Rows[rc];
                for (int i = 0; i < upFieldgp.Length; i++)
                {
                    SqlParameter para = new SqlParameter();
                    para.ParameterName = "@" + upFieldgp[0];
                    para.SqlDbType =_sqldbhelper.tranDataType2SQl(data.Columns[i].DataType);
                    para.SqlValue = row[i];
                    sqlparams.Add(para);
                }
                SqlParameter filterparam = new SqlParameter();
                filterparam.SqlValue = row["FID"];
                filterparam.ParameterName = "@FID";
                filterparam.SqlDbType = SqlDbType.BigInt;
                sqlparams.Add(filterparam);
                _sqldbhelper.ExecuteNonQuery(sql, CommandType.Text, sqlparams);
            }
                return rst;
        }
        //save= insert into table
        /// <summary>
        /// 将数据保存到数据库中insert
        /// </summary>
        /// <param name="fieldstr">字段字符串</param>
        /// <param name="fieldtype">字段类型</param>
        /// <param name="tablename">表名</param>
        /// <param name="data">数据包</param>
        /// <param name="forcount">执行次数</param>
        /// <returns></returns>
        public DataTable Save(String fieldstr ,String fieldtype, String tablename,DataTable data)
        {
            //fieldtype 0--nvarchar 1=int 2=datatime 3=bigint 
            long maxFID = 0;
            DataTable rst = new DataTable();
            DataColumn col = new DataColumn("result", typeof(Boolean));
            rst.Columns.Add(col);
            DataColumn col1 = new DataColumn("msg", typeof(String));
            rst.Columns.Add(col1);
            DataColumn col2 = new DataColumn("FID", typeof(long));
            rst.Columns.Add(col2);
            String sql = "select max(FID) from t_ProcessPlanHeader";
            DataTable dt1 = _sqldbhelper.ExecuteDataTable(sql);
            //获取最大FID;
            if (dt1.Rows.Count == 0)
                maxFID = 0;
            else
                maxFID = Convert.ToInt64(dt1.Rows[0][0]);
            //拼接SQl
             sql = "insert into " + tablename + " (";
            //通过循环拼接字段
            String[] fieldgroup = fieldstr.Split(',');
            String[] fieldtypegp = fieldtype.Split(',');
            for (int i = 0; i < fieldgroup.Length; i++)
            {
                sql += " " + fieldgroup[i];
                if (i < fieldgroup.Length - 1)
                {
                    sql += " , ";
                }
                else
                {
                    sql += " ) values( ";
                }

            }
            //拼接参数
            for (int i = 0; i < fieldgroup.Length; i++)
            {
                sql += " @" + fieldgroup[i];
                if (i < fieldgroup.Length - 1)
                {
                    sql += " , ";
                }
                else
                {
                    sql += " ) ";
                }

            }
           //创建SQlparams
            ////fieldtype 0--nvarchar 1=int 2=datatime 3=bigint
            for (int rowcount=0;rowcount<data.Rows.Count;rowcount++)
            {
                ArrayList sqlparams=new ArrayList();
                DataRow row=data.Rows[rowcount];
                for (int i = 0; i < fieldtypegp.Length; i++)
                {
                    SqlParameter para = new SqlParameter();
                    switch (Convert.ToInt32(fieldtypegp[i]))
                        {
                        case 0:
                               
                                para.SqlDbType = SqlDbType.NVarChar;
                             
                                break;
                        case 1:
                                para.SqlDbType = SqlDbType.Int;
                                break;
                        case 2:
                                para.SqlDbType = SqlDbType.DateTime;
                                break;
                        default:
                                para.SqlDbType = SqlDbType.NVarChar;
                                break;
                        }
                    para.ParameterName = fieldgroup[i];
                    
                    para.SqlValue = row[i];
                    sqlparams.Add(para);
                }
                _sqldbhelper.ExecuteNonQuery(sql, CommandType.Text, sqlparams);
            }
            sql = "select max(FID) from t_ProcessPlanHeader ";
            dt1 = new DataTable();
            dt1 = _sqldbhelper.ExecuteDataTable(sql);
            if (dt1.Rows.Count == 0)
            {
                //执行错误，没有插入创建新的表头
                object[] val = new object[] { false, "数据保存失败", 0 };
                rst.Rows.Add(val);

            }
            else
            {
                object[] val = new object[] { false, "表数据保存成功", dt1.Rows[0][0] };
                rst.Rows.Add(val);

            }
                return rst;
        }
    }
}
