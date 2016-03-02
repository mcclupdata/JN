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
    /// h焊接位置，代码库维护
    /// </summary>
    class svrweldcodepostEdit:_clsdb
    {
        /// <summary>
        /// 获取全部坡口代码数据
        /// 6030101
        /// </summary>
        /// <returns></returns>
        public DataTable getCODE()
        {
            DataTable vdt = new DataTable();
            String selSQL = "select * from t_WELD_CODE";
            vdt = _sqldbhelper.ExecuteDataTable(selSQL);
            return vdt;
        }
        /// <summary>
        /// 获取全部焊接位置数据
        /// 6030102
        /// </summary>
        /// <returns></returns>
        public DataTable getPOST()
        {
            DataTable vdt = new DataTable();
            String selSQL = "select * from t_WELD_POST";
            vdt = _sqldbhelper.ExecuteDataTable(selSQL);
            return vdt;
        }
        /// <summary>
        /// 更新坡口代码
        /// 6030103
        /// </summary>
        /// <returns></returns>
        public DataTable UpdatCode(DataTable data,int vtype)
        {
            DataTable vdt = new DataTable();
            String selSQL = "select * from t_WELD_CODE";
            vdt = _sqldbhelper.UpdateByDataTable(selSQL, data, "FID",vtype);
            return vdt;
        }
        /// <summary>
        /// 更新位置代码
        /// 6030104
        /// </summary>
        /// <returns></returns>
        public DataTable UpdatPost(DataTable data,int vtype)
        {
            DataTable vdt = new DataTable();
            String selSQL = "select * from t_WELD_POST";
            vdt = _sqldbhelper.UpdateByDataTable(selSQL, data, "FID", vtype);
            if (vdt == null)
                vdt = data;
            return vdt;
        }
        /// <summary>
        /// 插入新坡口数据
        /// 6030105
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable InsertCode(DataTable data)
        {
            DataTable vdt = new DataTable();
            String selSQL = "select * from t_WELD_CODE";
            vdt = _sqldbhelper.UpdateByDataTable(selSQL, data, "FID", 1);
            return vdt;
        }
        /// <summary>
        /// 插入新位置数据
        /// 6030106
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable InsertPOST(DataTable data)
        {
            DataTable vdt = new DataTable();
            String selSQL = "select * from t_WELD_POST";
            vdt = _sqldbhelper.UpdateByDataTable(selSQL, data, "FID", 1);
            return vdt;
        }
        /// <summary>
        /// 删除坡口
        /// 6030107
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable DeleteCODE(DataTable data)
        {
            DataTable vdt = new DataTable();
            String selSQL = "select * from t_WELD_CODE";
            vdt = _sqldbhelper.UpdateByDataTable(selSQL, data, "FID", 2);
            return vdt;
        }
        /// <summary>
        /// 删除位置
        /// 6030107
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable DeletePOST(DataTable data)
        {
            DataTable vdt = new DataTable();
            String selSQL = "select * from t_WELD_POST";
            vdt = _sqldbhelper.UpdateByDataTable(selSQL, data, "FID", 2);
            return vdt;
        }
       
    }
}
