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
    /// 焊工等级标准库维护管理
    /// </summary>
    class svrweldingclass:_clsdb
    {
        /// <summary>
        /// 获取全部要焊工等级标准库
        /// 5120201
        /// </summary>
        /// <returns></returns>
        public DataTable getweldingclass()
        {
            DataTable vdt = new DataTable();
            String selSQL = "select * from t_WeldMods";
            vdt = _sqldbhelper.ExecuteDataTable(selSQL);
            return vdt;
        }
        /// <summary>
        /// 更新焊工等级标准库
        /// 5120202
        /// </summary>
        /// <returns></returns>
        public DataTable Updateweldingclass(DataTable data)
        {
            DataTable vdt = new DataTable();
            String selSQL = "select * from t_WeldMods";
            vdt = _sqldbhelper.UpdateByDataTable(selSQL, data, "FID", 0);
            return vdt;
        }
        /// <summary>
        /// 插入新的焊工等级标准
        /// 5120203
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable Insertweldingclass(DataTable data)
        {
            DataTable vdt = new DataTable();
            String selSQL = "select * from t_WeldMods";
            vdt = _sqldbhelper.UpdateByDataTable(selSQL, data, "FID", 1);
            return vdt;
        }
        /// <summary>
        /// 删除焊工等级标准库
        /// 5120204
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable Deleteweldingclass(DataTable data)
        {
            DataTable vdt = new DataTable();
            String selSQL = "select * from t_WeldMods";
            vdt = _sqldbhelper.UpdateByDataTable(selSQL, data, "FID", 2);
            return vdt;
        }
        /// <summary>
        /// 获取焊工等级与焊缝等级匹配规则库信息；
        /// 5123103
        /// </summary>
        /// <returns></returns>
        public DataTable GetWeldWeldingClass()
        {
            DataTable vdt = new DataTable();
            String selSQL = "select * from t_WeldingWeldClass";
            vdt = _sqldbhelper.ExecuteDataTable(selSQL);
            return vdt;
        }
        /// <summary>
        /// 更新焊工等级与焊缝等级匹配规则库信息
        /// 5123104
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="vtype"></param>
        /// <returns></returns>
        public DataTable UpdateWeldWeldingClass(DataTable data, int vtype)
        {
            DataTable vdt = new DataTable();
            String selSQL = "select * from t_WeldingWeldClass";
            vdt = _sqldbhelper.UpdateByDataTable(selSQL, data, "FID", vtype);
            return vdt;
        }
    }
}
