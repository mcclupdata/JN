using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Data.OleDb;
using Microsoft;

namespace EValulate_DEMO
{
    //使用 Office驱动访问Excel文件;
    class ExcelIO
    {
        public ExcelIO()
        {
        }
        public DataTable CSV_Getds(string filePath,String tablename)
        {
            try
            {
             
               

                string OLEDBConnStr = "Provider=Microsoft.Jet.OleDb.4.0;" + "data source=" + filePath + ";Extended Properties='Excel 8.0; HDR=YES; IMEX=1'";


                OleDbDataAdapter oda = new OleDbDataAdapter("select * from [" + tablename + "]", OLEDBConnStr);

                DataSet sourceDataTable = new DataSet();
                oda.Fill(sourceDataTable);
                oda.Dispose();


                GC.Collect();

                return sourceDataTable.Tables[0];



            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return null;
            }

        }
    }
}
