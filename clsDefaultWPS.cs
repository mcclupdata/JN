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
    class clsDefaultWPS:clsFrmBase
    {
        public DataTable getDefaultWPS()
        {
            DataTable rsdt = _Client.ServiceCall(clsCMD.cmd_DefaultWPS_GetDefaultWPSs, null);
            rsdt.Columns.Add("FsetDefault", typeof(String));
            return rsdt;
        }
        public long getDefaultWPSFID()
        {
            DataTable rsdt = _Client.ServiceCall(clsCMD.cmd_DefaultWPS_GetCurDefaultWPS, null);
            if (rsdt != null)
            {
                if (rsdt.Rows.Count == 1)
                {
                    return Convert.ToInt64(rsdt.Rows[0]["Fvalue"]);
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }
        public DataTable getDefaultSubWPS()
        {
            DataTable rsdt = _Client.ServiceCall(clsCMD.cmd_DefaultWPS_GetDefaultSubWPS, null);
            return rsdt;
        }
        public DataTable UpdateDefaultWPS(DataTable data)
        {
            DataTable rsdt = _Client.ServiceCall(clsCMD.cmd_DefaultWPS_UpdateDefaultWPS, data);
            return rsdt;
        }
        public DataTable UpdateDefaultSubWPS(DataTable subdata)
        {
            DataTable rsdt = _Client.ServiceCall(clsCMD.cmd_DefaultWPS_UpdateDefaultSubWPS, subdata);
            return rsdt;
        }
        public DataTable SetDefaultWPS(long vfid)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Fvalue", typeof(long)); dt.Columns.Add("FID", typeof(long));
            dt.Rows.Add(vfid,14);
            DataTable rsdt = _Client.ServiceCall(clsCMD.cmd_DefaultWPS_SetCurDefaultWPS, dt);
            return rsdt;
        }
    }
}
