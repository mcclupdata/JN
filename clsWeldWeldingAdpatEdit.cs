using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace MC
{
    class clsWeldWeldingAdpatEdit:clsFrmBase
    {
        int cmd_GetWeldWeldingClass=5123103;
        int cmd_UpdateWeldWeldingClass=5123104;
        public DataTable getWeldWeldingClass()
        {
           DataTable dt= _Client.ServiceCall(cmd_GetWeldWeldingClass,null);
           dt.AcceptChanges();
           return dt;
        }
        public DataTable UpdateWeldWeldingClass(DataTable data)
        {
            DataTable ndt = data.Clone();
            DataTable udt=data.Clone();
            DataTable ddt=data.Clone();
            for (int k = 0; k < data.Rows.Count; k++)
            {
                DataRow r = data.Rows[k];
                if (r.RowState == DataRowState.Added)
                {
                    ndt.ImportRow(r);
                }
                if (r.RowState == DataRowState.Modified)
                {
                    udt.ImportRow(r);
                }
                if (r.RowState == DataRowState.Deleted)
                {
                    DataRow ddr = ddt.NewRow();
                    ddr["FID"] = data.Rows[k]["FID", DataRowVersion.Original];
                    ddt.Rows.Add(ddr);
                }


            }
            DataTable rsdt = new DataTable();
            if (ndt.Rows.Count > 0)
            {
                rsdt = _Client.ServiceCall(cmd_UpdateWeldWeldingClass, ndt, 1);
            }
            if (udt.Rows.Count > 0)
            {
                rsdt = _Client.ServiceCall(cmd_UpdateWeldWeldingClass, udt, 0);
            }
            if (ddt.Rows.Count > 0)
            {
                rsdt = _Client.ServiceCall(cmd_UpdateWeldWeldingClass, ddt, 2);
            }
            return rsdt;
        
        }
    }
}
