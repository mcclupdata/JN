using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using System.Xml;

namespace MC
{
    static class clsConvertXMLDataTable
    {


        static public DataTable ConvertxmlSchemaToDataTable(String xmlschema)
        {

            if (xmlschema.Length == 0)
                return null;
            StringReader stream = null;
            XmlTextReader reader = null;
            try
            {
                DataTable ndt = new DataTable();
                stream = new StringReader(xmlschema);//读取字符串中的信息
                reader = new XmlTextReader(stream);//获取stream中的数据
                ndt.ReadXmlSchema(reader);//DataSet获取Xmlrdr中的数据
                return ndt;
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

        static public String ConvertDataTableToSchema(DataTable xmlDT)
        {
           

            MemoryStream stream = null;
            XmlTextWriter writer = null;
            String xml = "";
            try
            {
                stream = new MemoryStream();
                writer = new XmlTextWriter(stream, Encoding.Default);//根据stream实例化writer
                xmlDT.TableName = "dt";
                xmlDT.WriteXmlSchema(writer);//获取DataTable中的数据


                int count = (int)stream.Length;
                byte[] arr = new byte[count];
                stream.Seek(0, SeekOrigin.Begin);
                stream.Read(arr, 0, count);
                xml=Encoding.GetEncoding("gb2312").GetString(arr).Trim();
                 //解决中文乱码问题
               // DataTable ndt = ConvertxmlSchemaToDataTable(xml);
                //UTF8Encoding utf = new UTF8Encoding();
                //return utf.GetString(arr).Trim();
                return xml;
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


        /// <summary>
        /// 将xml转DataTable
        /// </summary>
        /// <param name="xmlData"></param>
        /// <returns></returns>
        static public DataTable ConvertXMLToDataTable(string xmlData)
        {
            StringReader stream = null;
            XmlTextReader reader = null;
            try
            {
                DataSet xmlDS = new DataSet();
                stream = new StringReader(xmlData);//读取字符串中的信息
                reader = new XmlTextReader(stream);//获取stream中的数据
                xmlDS.ReadXml(reader, XmlReadMode.ReadSchema);//DataSet获取Xmlrdr中的数据
                return xmlDS.Tables[0];
            }
            catch (Exception e)
            {
                return null ;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }
        /// <summary>
        /// 传递修改值
        /// </summary>
        /// <param name="xmlDT"></param>
        /// <returns></returns>
        static public string ConvertDataTableToXMLWithChange(DataTable xmlDT)
        {
            MemoryStream stream = null;
            XmlTextWriter writer = null;
            try
            {
                ;
                stream = new MemoryStream();
                writer = new XmlTextWriter(stream, Encoding.GetEncoding("gb2312"));//根据stream实例化writer
                xmlDT.TableName = "dt";
                //
                xmlDT.WriteXml(writer, XmlWriteMode.DiffGram);//获取DataTable中的数据


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
        /// <summary>
        /// 将DataTable转xml
        /// </summary>
        /// <param name="xmlDT"></param>
        /// <returns></returns>
        static public string ConvertDataTableToXML(DataTable xmlDT)
        {
            MemoryStream stream = null;
            XmlTextWriter writer = null;
            try
            {
                stream = new MemoryStream();
                writer = new XmlTextWriter(stream, Encoding.GetEncoding("gb2312"));//根据stream实例化writer
                xmlDT.TableName = "dt";
                xmlDT.WriteXml(writer, XmlWriteMode.WriteSchema);//获取DataTable中的数据


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
