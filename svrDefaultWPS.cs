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
    /// <summary>
    /// 当前默认WPS设定与管理
    /// </summary>
    class svrDefaultWPS:_clsdb
    {
        /// <summary>
        /// 获取默认WPS集合
        /// 5112101
        /// </summary>
        /// <returns></returns>
        public DataTable getDefaultWPSs()
        {
            String selSQL = "select * from t_wps_RULE where FID<=0";
            DataTable rsdt = _sqldbhelper.ExecuteDataTable(selSQL);
            return rsdt;
        }
        /// <summary>
        /// 获取默认SUBWPS集合
        /// 5112106
        /// </summary>
        /// <returns></returns>
        public DataTable getDefaultSubWPSs()
        {
            String selSQL = "select  * from t_wps_WELDTUN";
            DataTable rsdt = _sqldbhelper.ExecuteDataTable(selSQL);
            return rsdt;
        }
        /// <summary>
        /// 获取当前使用的默认WPS
        /// 5112102
        /// </summary>
        /// <returns></returns>
        public DataTable getCurDefaultWPS()
        {
            String selSQL = "select FID,FName,FTypeID,Fnum,Fvalue from t_Dictionary where FTypeID=5";
            DataTable rsdt = _sqldbhelper.ExecuteDataTable(selSQL);
            return rsdt;
        }
        /// <summary>
        /// 设置当前使用的默认wps
        /// 5112103
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable setCurDefaultWPS(DataTable data)
        {
            long fid = 14;
            String selSQL = "select * from t_Dictionary where FID=14";
            DataTable rsdt=_sqldbhelper.UpdateByDataTable(selSQL, data, "FID", 0);
            return rsdt;
        }
        /// <summary>
        /// 更新默认WPS数据
        /// 5112104
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable UpdateDefalutwpss(DataTable data)
        {
            String selSQL = "select * from t_wps_RULE where FID<=0";
            DataTable rsdt = _sqldbhelper.UpdateByDataTable(selSQL,data,"FID", 0);
            return rsdt;
        }
        /// <summary>
        /// 更新默认Subwps数据
        /// 5112105
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable UpdateDefaultsubwpss(DataTable data)
        {

            String selSQL = "select * from t_wps_WELDTUN ";
            DataTable rsdt = _sqldbhelper.UpdateByDataTable(selSQL, data, "FID", 0);
            return rsdt;
        }
    }
}
