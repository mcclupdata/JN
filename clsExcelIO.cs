using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Data;
using System.Data.OleDb;
//using Office;

namespace MC
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
                String fileType = "";
                int lst=filePath.LastIndexOf('.');
                fileType = filePath.Substring(lst + 1, filePath.Length - lst-1);
                string OLEDBConnStr="";
                if (fileType.ToLower() == "xls")
                    OLEDBConnStr = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + filePath +  ";Extended Properties='Excel 8.0;HDR=YES;IMEX=1'";
                else
                    OLEDBConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + filePath +  ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1'";

            
                // = "Provider=Microsoft.Jet.OleDb.4.0;" + "data source=" + filePath + ";Extended Properties='Excel 8.0; HDR=YES; IMEX=1'";


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
