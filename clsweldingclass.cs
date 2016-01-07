using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Globalization;
using EI;
using EF;
using DevExpress.XtraExport;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
namespace MC
{
    

    class clsweldingclass : clsFrmBase
    {
        private static int cmd_Getweldingclass = 5120201;
        private static int cmd_Updateweldingclass = 5120202;
        public DataTable Loadweldingclass()
        {
            DataTable vdt = _Client.ServiceCall(cmd_Getweldingclass, null);
            vdt.AcceptChanges();
            return vdt;
        }
        public void Updateweldingclass(DataTable data)
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
                rsdt = _Client.ServiceCall(cmd_Updateweldingclass, ndt, 1);
            }
            if (udt.Rows.Count > 0)
            {
                rsdt = _Client.ServiceCall(cmd_Updateweldingclass, udt, 0);
            }
            if (ddt.Rows.Count > 0)
            {
                rsdt = _Client.ServiceCall(cmd_Updateweldingclass, ddt, 2);
            }
        }

    }
}
