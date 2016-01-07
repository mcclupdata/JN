using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.Sql;
using System.Xml;
using System.IO;
using EF;
using EI;
namespace MC
{
   public class clsFrmBase:clsfrmData
    {
        
        protected Control FindControl(String colname)
        {
            Control[] cls = _frm.Controls.Find(colname, true);
            if (cls.Length == 0)
            {
                MessageBox.Show("没有找到控件");
                return null;
            }
            //注册打开文件的事件
            Control cl = cls[0];
            return cl;
            

        }
        protected DevExpress.XtraGrid.Views.Grid.GridView FindControl(String colname,String gridname)
        {
            Control[] cls = _frm.Controls.Find(colname, true);
            if (cls.Length > 0)
            {
                Control rcn=cls[0];
                if (typeof(EF.EFDevGrid) == rcn.GetType())
                {
                    EF.EFDevGrid efg=(EF.EFDevGrid)rcn;
                    for (int i = 0; i < efg.Views.Count; i++)
                    {
                        if (efg.Views[i].Name == gridname)
                        {
                            return (DevExpress.XtraGrid.Views.Grid.GridView)efg.Views[i];
                        }
                    }
                }
            }
            return null;
        }
        public Control FindControl(String colname,ref Formbase frm)
        {
            Control[] cls = frm.Controls.Find(colname, true);
            if (cls.Length == 0)
            {
               // MessageBox.Show("没有找到控件");
                return null;
            }
            //注册打开文件的事件
            Control cl = cls[0];
            return cl;

        }

        ~clsFrmBase()
        {
            GC.Collect();
        }

        public String  Openfile(String colname, String filter)
        {
            OpenFileDialog otext=new OpenFileDialog();
            String filename="";
            otext.InitialDirectory = "C:\\";
            otext.RestoreDirectory = true;
                    //otext.CheckFileExists=true;
                    //otext.CheckPathExists=true;
                    otext.Filter=filter;//"excel filer(*.xls)|*.xls";
                    otext.CheckFileExists = true;
                   if(otext.ShowDialog(_frm)==DialogResult.OK)
                   {
                       filename = otext.FileName;
                       Control[] cls=_frm.Controls.Find(colname,true);
                       if (cls.Length == 0)
                       {
                           MessageBox.Show("缺少控件");
                           return "";
                       }
                       else
                       {
                           Control cl = cls[0];
                           EFLabelText ltxt = (EFLabelText)cl;

                           ltxt.EFEnterText = filename;
                           return filename;
                       }
                    }
                  else
                    {
                        return "" ;
                    } 
                    
        }

        /// <summary>
        /// 将xml转DataTable
        /// </summary>
        /// <param name="xmlData"></param>
        /// <returns></returns>
        protected DataTable ConvertXMLToDataTable(string xmlData)
        {
            StringReader stream = null;
            XmlTextReader reader = null;
            try
            {
                DataSet xmlDS = new DataSet();
                stream = new StringReader(xmlData);//读取字符串中的信息
                reader = new XmlTextReader(stream);//获取stream中的数据
                xmlDS.ReadXml(reader);//DataSet获取Xmlrdr中的数据
                return xmlDS.Tables[0];
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }
        /// <summary>
        /// 将DataTable转xml
        /// </summary>
        /// <param name="xmlDT"></param>
        /// <returns></returns>
        protected string ConvertDataTableToXML(DataTable xmlDT)
        {
            MemoryStream stream = null;
            XmlTextWriter writer = null;
            try
            {
                stream = new MemoryStream();
                writer = new XmlTextWriter(stream, Encoding.Default);//根据stream实例化writer
                xmlDT.TableName = "dt";
                xmlDT.WriteXml(writer);//获取DataTable中的数据
                int count = (int)stream.Length;
                byte[] arr = new byte[count];
                stream.Seek(0, SeekOrigin.Begin);
                stream.Read(arr, 0, count);
                return Encoding.GetEncoding("gb2312").GetString(arr).Trim();//解决中文乱码问题
                //UTF8Encoding utf = new UTF8Encoding();
                //return utf.GetString(arr).Trim();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }

    }
}
