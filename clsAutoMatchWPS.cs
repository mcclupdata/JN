using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using EI;
using EF;

namespace MC
{
    class clsAutoMatchWPS:clsFrmBase
    {
        /// <summary>
        /// 加载所有默认WPS
        /// </summary>
        /// <returns></returns>
        public DataTable LoadDefaultWPS()
        {
            DataTable dt = _Client.ServiceCall(clsCMD.cmd_DefaultWPS_GetDefaultWPSs, null);
            DataView dv = dt.DefaultView;
            return dv.ToTable(true, "FID", "RuleNum");

        }

        /// <summary>
        /// 加载所有未匹配WPS的焊缝数据
        /// </summary>
        /// <returns></returns>
        public DataTable loadUnmatchwpswelds()
        {
            DataTable rs = _Client.ServiceCall(clsCMD.cmd_AutoMatchWPS_GetUnAutoWPS, null);
            return rs;
        }
        public DataTable loadWeldswithWPS()
        {
            DataTable rs = _Client.ServiceCall(clsCMD.cmd_AutoMatchWPS_GetWeldwithWPS, null);
            return rs;
        }
        /// <summary>
        /// 更新自动匹配WPS数据
        /// </summary>
        /// <returns></returns>
        public DataTable UpdateAutpmatchWPS(DataTable data)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("FID", typeof(long)); dt.Columns.Add("RuleNum", typeof(String));
            for (int i = 0; i < data.Rows.Count; i++)
            {
                if (data.Rows[i]["RuleNum"] != null)
                {
                    if (data.Rows[i]["RuleNum"].ToString().Length>0)
                    {
                        DataRow nr = dt.NewRow();
                        nr[0] = data.Rows[i]["FID"];
                        nr[1] = data.Rows[i]["RuleNum"];
                        dt.Rows.Add(nr);
                    }
                }
            }
            if (dt.Rows.Count > 0)
            {
                DataTable urs = _Client.ServiceCall(clsCMD.cmd_AutoMatchWPS_UpdateWPS, dt);
            }
            return dt;
        }
    }
}
