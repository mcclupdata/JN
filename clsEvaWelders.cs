using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace MC
{
    

    class clsEvaWelders:clsfrmData
    {
        private static int CMD_getEvaluationrpt_Welds = 15122201;
        private static int CMD_getEvaluationrpt_Welders = 15122202;
       
        private static int CMD_getAllWeldType = 15122203;
        public DataTable getEvaluation_Welders(String fnum,String sdt,String edt)
        {
            DataTable fdt = new DataTable();
            fdt.Columns.Add("Fnum", typeof(String));
            fdt.Columns.Add("STARTDATE", typeof(String));
            fdt.Columns.Add("ENDDATE", typeof(String));
            fdt.Rows.Add(fnum,sdt,edt);
            DataTable rsdt = _Client.ServiceCall(CMD_getEvaluationrpt_Welders, fdt);
            return rsdt;
        }
        public DataTable getAllWeldType()
        {
            DataTable dt = _Client.ServiceCall(CMD_getAllWeldType, null);
            return dt;
        }
        public DataTable getEvaluationrpt_Welds(String SHIP_NO,  String BUFF1, String AS3, String TREE_NAME)
        {
            DataTable fdt = new DataTable();
            fdt.Columns.Add("SHIP_NO", typeof(String));
            //fdt.Columns.Add("BLK_NO", typeof(String));
            fdt.Columns.Add("BUFF1", typeof(String));
            fdt.Columns.Add("TREE_NAME", typeof(String));
            fdt.Columns.Add("AS3", typeof(String));
            fdt.Rows.Add(SHIP_NO, BUFF1, TREE_NAME, AS3);
            DataTable dt = _Client.ServiceCall(CMD_getEvaluationrpt_Welds, fdt);
            return dt;
        }
    }
}
