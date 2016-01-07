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
    class svrAutoMatchwps : _clsdb
    {
        /// <summary>
        /// 加载未匹配WPS的焊缝数据，并自动匹配
        /// 5112201
        /// </summary>
        /// <returns></returns>
        public DataTable getUnAutoMatchWPSWELDS()
        {
            String selSQL = "select * from View_UnAutoMatchWPS";
            DataTable rsdt = _sqldbhelper.ExecuteDataTable(selSQL);
            return rsdt;
        }
        /// <summary>
        /// 获取已经匹配好WPS的焊缝数据
        /// 5112202
        /// </summary>
        /// <returns></returns>
        public DataTable getWeldswithWPS()
        {
            String selSQL = "select * from t_WELD where RuleNum is not null ";
            DataTable rsdt = _sqldbhelper.ExecuteDataTable(selSQL);
            return rsdt;
        }
        /// <summary>
        /// 更新自动匹配的WPS数据
        /// 5112203
        /// </summary>
        /// <param name="data">FID，RuleNum</param>
        /// <returns></returns>
        public DataTable UpdateAutomatchwps(DataTable data)
        {
            String selSQL = "select * from t_WELD ";
            DataTable rs = _sqldbhelper.UpdateByDataTable(selSQL, data, "FID", 0);
            return rs;
        }
    }
}
