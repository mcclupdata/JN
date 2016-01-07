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
    /// <summary>
    /// 部门管理
    /// </summary>
    class svrDepartmags:_clsdb
    {
        /// <summary>
        /// 提取部门数据 5100506
        /// </summary>
        /// <param name="fdt"></param>
        /// <returns></returns>
        public DataTable getDepartments(DataTable fdt)
        {
            DataTable dt;
            String selSQL = "select * from t_Department";
            if (fdt==null)
                selSQL = "select * from t_Department";
            if (fdt.Rows.Count==0)
                selSQL = "select * from t_Department";
            if (fdt.Rows.Count > 0)
            {
                //指定FLevel 按照级别查询
                if (fdt.Columns.IndexOf("FLevel") > 0)
                {
                    selSQL = "select * from t_Department where FLevel="+fdt.Rows[0]["FLevel"].ToString();
                }
                if (fdt.Columns.IndexOf("FID") > 0)
                {
                    selSQL = "select * from t_Department where FID=" + fdt.Rows[0]["FID"].ToString();
                }

            }
            dt = _sqldbhelper.ExecuteDataTable(selSQL);
            return dt;
        }
        /// <summary>
        /// 更新部门数据 5100507
        /// </summary>
        /// <returns>FDepartName,FParentID,Flevel,FID,FDEL</returns>
        public DataTable upDateDepartments(DataTable data)
        {
            String upSQL = "Update t_Department set [FDepartName]=@FDepartName,[FParentID]=@FParentID,[Flevel]=@Flevel,[IsWeld]=@IsWeld where FID=@FID";
            String insertSQL = "Insert into t_Department ([FDepartName],[FParentID],[Flevel],[IsWeld]) values(@FDepartName,@FParentID,@Flevel,@IsWeld)";
            String delSQL = "delete from t_Department where FID=@FID";
            try
            {
                ArrayList sqlparams = new ArrayList();
                SqlParameter pa;
                if (data.Columns.IndexOf("FDel") > 0)
                {
                    //执行删除动作
                    pa = new SqlParameter(); pa.ParameterName = "@FID"; pa.SqlDbType = SqlDbType.BigInt; pa.SqlValue = data.Rows[0]["FID"]; sqlparams.Add(pa);
                    _sqldbhelper.ExecuteNonQuery(delSQL, CommandType.Text, sqlparams);
                }
                else
                {
                    if (Convert.IsDBNull(data.Rows[0]["FID"]))
                    {
                        //新增
                        pa = new SqlParameter(); pa.ParameterName = "@FDepartName"; pa.SqlDbType = SqlDbType.NVarChar; pa.SqlValue = data.Rows[0]["FDepartName"]; pa.Size = 100; sqlparams.Add(pa);
                        pa = new SqlParameter(); pa.ParameterName = "@FParentID"; pa.SqlDbType = SqlDbType.BigInt; pa.SqlValue = data.Rows[0]["FParentID"]; sqlparams.Add(pa);
                        pa = new SqlParameter(); pa.ParameterName = "@Flevel"; pa.SqlDbType = SqlDbType.BigInt; pa.SqlValue = data.Rows[0]["Flevel"]; sqlparams.Add(pa);
                        pa = new SqlParameter(); pa.ParameterName = "@IsWeld"; pa.SqlDbType = SqlDbType.Int; pa.SqlValue = data.Rows[0]["IsWeld"]; sqlparams.Add(pa);

                        _sqldbhelper.ExecuteNonQuery(insertSQL, CommandType.Text, sqlparams);
                    }
                    else
                    {
                        //修改
                        pa = new SqlParameter(); pa.ParameterName = "@FID"; pa.SqlDbType = SqlDbType.BigInt; pa.SqlValue = data.Rows[0]["FID"]; sqlparams.Add(pa);
                        pa = new SqlParameter(); pa.ParameterName = "@FDepartName"; pa.SqlDbType = SqlDbType.NVarChar; pa.SqlValue = data.Rows[0]["FDepartName"]; pa.Size = 100; sqlparams.Add(pa);
                        pa = new SqlParameter(); pa.ParameterName = "@FParentID"; pa.SqlDbType = SqlDbType.BigInt; pa.SqlValue = data.Rows[0]["FParentID"]; sqlparams.Add(pa);
                        pa = new SqlParameter(); pa.ParameterName = "@Flevel"; pa.SqlDbType = SqlDbType.BigInt; pa.SqlValue = data.Rows[0]["Flevel"]; sqlparams.Add(pa);
                        pa = new SqlParameter(); pa.ParameterName = "@IsWeld"; pa.SqlDbType = SqlDbType.Int; pa.SqlValue = data.Rows[0]["IsWeld"]; sqlparams.Add(pa);

                        _sqldbhelper.ExecuteNonQuery(upSQL, CommandType.Text, sqlparams);
                    }
                }
            }
            catch (Exception ex)
            {
                return _sqldbhelper.excuNoqueryRetrun(false, ex.Message, 0);
            }
            return _sqldbhelper.excuNoqueryRetrun(true, "SUCCESS", 0);
        }
    }
}
