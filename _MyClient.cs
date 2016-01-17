using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections;
using System.ServiceModel.Channels;
using EI;
using EF;
using MC;
namespace MC
{
     public class _MyClient//:WeldServiceReference.WeldServiceClient
    {
        protected static System.ServiceModel.WSHttpBinding _wshttpbing;
        protected static WeldServiceReference.WeldServiceClient _svrclient;
         //WCF服务器地址，端口
        //const String _WCFSVRDress = "http://10.30.30.51:8734/JN_WELD_Service/Service1/";
        const String _WCFSVRDress = "http://127.0.0.1:8734/JN_WELD_Service/Service1/";
        //const String _WCFSVRDress = "http://10.30.7.34:8734/JN_WELD_Service/Service1/";
        protected void buildConnectSvr()
        {
            //建立连接绑定
            _wshttpbing = new System.ServiceModel.WSHttpBinding(System.ServiceModel.SecurityMode.Message, false);
            TimeSpan timespan = new TimeSpan(0, 10, 0);
            _wshttpbing.CloseTimeout = timespan;
            _wshttpbing.ReceiveTimeout = timespan;
            _wshttpbing.SendTimeout = timespan;
            _wshttpbing.MaxBufferPoolSize = 2147483647;
            _wshttpbing.MaxReceivedMessageSize = 2147483647;
            _wshttpbing.Security.Mode = System.ServiceModel.SecurityMode.None;
            //System.ServiceModel.HttpClientCredentialType.Windows
            _wshttpbing.Security.Transport.ClientCredentialType = System.ServiceModel.HttpClientCredentialType.Windows;
            _wshttpbing.Security.Message.ClientCredentialType = System.ServiceModel.MessageCredentialType.Windows;
            _wshttpbing.ReaderQuotas.MaxDepth = 2147483647;
            _wshttpbing.ReaderQuotas.MaxStringContentLength = 2147483647;
            _wshttpbing.ReaderQuotas.MaxArrayLength = 2147483647;
            _wshttpbing.ReaderQuotas.MaxBytesPerRead = 2147483647;
            _wshttpbing.ReaderQuotas.MaxNameTableCharCount = 2147483647;

            System.ServiceModel.EndpointAddress rometdress = new System.ServiceModel.EndpointAddress(_WCFSVRDress);
            _svrclient = new MC.WeldServiceReference.WeldServiceClient(_wshttpbing, rometdress);
            _svrclient.Endpoint.Binding.CloseTimeout = timespan;
            _svrclient.Endpoint.Binding.OpenTimeout = timespan;
            _svrclient.Endpoint.Binding.ReceiveTimeout = timespan;
            _svrclient.Endpoint.Binding.Name = "WSHttpBinding_IWeldService";
        }
        public _MyClient()
        {

            buildConnectSvr();
            
            //_svrclient.Endpoint.bin
            



           // _svrclient.Endpoint.Address = rometdress;
           // _svrclient.Endpoint.Binding = _wshttpbing;
            //_svrclient.Endpoint.Contract=System.ServiceModel.Description.ContractDescription


        }
        //public DataTable ServiceCall(int cmdcode, DataTable data)
        //{
        //    DataTable cmdTable = new DataTable();
        //    DataColumn cmdco = new DataColumn("cmdcode", typeof(int));
        //    cmdTable.Columns.Add(cmdco);
        //    DataRow row = cmdTable.NewRow();
        //    row[0] = cmdcode;
        //    cmdTable.Rows.Add(row);




        //    EI.EIInfo inBlock = new EI.EIInfo();
            
        //    if (data != null)
        //    {
        //        inBlock.Tables[0].Merge(data.Copy());
               
        //    }
        //    else
        //    {

        //    }
        //    inBlock.Tables.Add();
        //    inBlock.Tables[1].Merge(cmdTable);

        //    EI.EIInfo Block = EITuxedo.CallService("mccl_0001_start", inBlock);


        //    DataTable retTable = new DataTable();
        //    DataColumn rect = new DataColumn();
        //    rect.ColumnName = "F1";
        //    rect.DataType = typeof(long);
        //    retTable.Columns.Add(rect);


        //    if (Block.Tables.Count > 0 )
        //    {
        //        return Block.Tables[0];
        //    }
        //    else
        //    {
        //        return new DataTable();
        //    }
        //}

        ///// <summary>
        ///// 进一步封装服务器调用程序,传入数据带Change
        ///// </summary>
        ///// <param name="?"></param>
        ///// <returns></returns>
        public DataTable ServiceCall(int cmdcode, DataTable data, long vtype)
        {

            MC.WeldServiceReference.CompositeType sdata = new MC.WeldServiceReference.CompositeType();
            MC.WeldServiceReference.CompositeType rsdt = new MC.WeldServiceReference.CompositeType();
            sdata.CmdCode = cmdcode;
            sdata.StringValue = vtype.ToString();
            if (data == null)
            {
                sdata.RowsCount = 0;
                sdata.weldDataTable = "";


            }
            else
            {
                if (data.Rows.Count == 0)
                {
                    sdata.RowsCount = 0;
                    sdata.weldDataTable = clsConvertXMLDataTable.ConvertDataTableToSchema(data);
                }
                else
                {
                    sdata.RowsCount = data.Rows.Count;
                    sdata.weldDataTable = clsConvertXMLDataTable.ConvertDataTableToXML(data);
                }
            }
            //MC.WeldServiceReference.WeldServiceClient _client = new MC.WeldServiceReference.WeldServiceClient();


            //_client.Endpoint.Name="WSHttpBinding_IWeldService";
            //_client.Endpoint.Address=new System.ServiceModel.EndpointAddress("http://127.0.0.1:8734/JN_WELD_Service/Service1/");
            //_client.Endpoint.Binding=wshttpbing;
            ////_client.Endpoint.Contract=new System.ServiceModel.Description.ContractDescription("WSHttpBinding_IWeldService","WeldServiceReference.IWeldService");
            ////_client.Endpoint.
            //_client.Open();
            //_client.Close();

            //rsdt = ServiceCall(sdata);


            if (_svrclient.State != System.ServiceModel.CommunicationState.Opened)
            {
                //switch (_svrclient.State)
                //{
                //    case System.ServiceModel.CommunicationState.Faulted:
                //        _svrclient.Close();
                //        _svrclient.Open();
                //        break;
                //    case System.ServiceModel.CommunicationState.Closed:
                //        _svrclient.Open();
                //        break;
                //    default:
                //        break;
                //}
                buildConnectSvr();

            }
            try
            {
                rsdt = _svrclient.ServiceCall(sdata);
            }
            catch (Exception ex)
            {
                if (_svrclient.State != System.ServiceModel.CommunicationState.Opened)
                {
                    buildConnectSvr();
                    try
                    {
                        rsdt = _svrclient.ServiceCall(sdata);
                    }
                    catch (Exception nex)
                    {
                        throw nex;
                    }
                }
            }

            //if (rsdt.RowsCount == 0)
            // return clsConvertXMLDataTable.ConvertxmlSchemaToDataTable(rsdt.weldDataTable);
            //else
            return clsConvertXMLDataTable.ConvertXMLToDataTable(rsdt.weldDataTable);

        }
        
         ///// <summary>
        ///// 进一步封装服务器调用程序,传入数据带Change
        ///// </summary>
        ///// <param name="?"></param>
        ///// <returns></returns>
        public DataTable ServiceCall(int cmdcode, DataTable data, String vtype)
        {

            MC.WeldServiceReference.CompositeType sdata = new MC.WeldServiceReference.CompositeType();
            MC.WeldServiceReference.CompositeType rsdt = new MC.WeldServiceReference.CompositeType();
            sdata.CmdCode = cmdcode;
            sdata.StringValue = vtype;
            if (data == null)
            {
                sdata.RowsCount = 0;
                sdata.weldDataTable = "";


            }
            else
            {
                if (data.Rows.Count == 0)
                {
                    sdata.RowsCount = 0;
                    sdata.weldDataTable = clsConvertXMLDataTable.ConvertDataTableToSchema(data);
                }
                else
                {
                    sdata.RowsCount = data.Rows.Count;
                    sdata.weldDataTable = clsConvertXMLDataTable.ConvertDataTableToXML(data);
                }
            }
            //MC.WeldServiceReference.WeldServiceClient _client = new MC.WeldServiceReference.WeldServiceClient();


            //_client.Endpoint.Name="WSHttpBinding_IWeldService";
            //_client.Endpoint.Address=new System.ServiceModel.EndpointAddress("http://127.0.0.1:8734/JN_WELD_Service/Service1/");
            //_client.Endpoint.Binding=wshttpbing;
            ////_client.Endpoint.Contract=new System.ServiceModel.Description.ContractDescription("WSHttpBinding_IWeldService","WeldServiceReference.IWeldService");
            ////_client.Endpoint.
            //_client.Open();
            //_client.Close();

            //rsdt = ServiceCall(sdata);


            if (_svrclient.State != System.ServiceModel.CommunicationState.Opened)
            {
                //switch (_svrclient.State)
                //{
                //    case System.ServiceModel.CommunicationState.Faulted:
                //        _svrclient.Close();
                //        _svrclient.Open();
                //        break;
                //    case System.ServiceModel.CommunicationState.Closed:
                //        _svrclient.Open();
                //        break;
                //    default:
                //        break;
                //}
                buildConnectSvr();

            }
            try
            {
                rsdt = _svrclient.ServiceCall(sdata);
            }
            catch (Exception ex)
            {
                if (_svrclient.State != System.ServiceModel.CommunicationState.Opened)
                {
                    buildConnectSvr();
                    try
                    {
                        rsdt = _svrclient.ServiceCall(sdata);
                    }
                    catch (Exception nex)
                    {
                        throw nex;
                    }
                }
            }

            //if (rsdt.RowsCount == 0)
            // return clsConvertXMLDataTable.ConvertxmlSchemaToDataTable(rsdt.weldDataTable);
            //else
            return clsConvertXMLDataTable.ConvertXMLToDataTable(rsdt.weldDataTable);

        }

        ///// <summary>
        ///// 进一步封装服务器调用程序,传入数据带Change
        ///// </summary>
        ///// <param name="?"></param>
        ///// <returns></returns>
        public DataTable ServiceCall(int cmdcode, DataTable data,int vtype)
        {

            MC.WeldServiceReference.CompositeType sdata = new MC.WeldServiceReference.CompositeType();
            MC.WeldServiceReference.CompositeType rsdt = new MC.WeldServiceReference.CompositeType();
            sdata.CmdCode = cmdcode;
            sdata.StringValue = vtype.ToString();
            if (data == null)
            {
                sdata.RowsCount = 0;
                sdata.weldDataTable = "";


            }
            else
            {
                if (data.Rows.Count == 0)
                {
                    sdata.RowsCount = 0;
                    sdata.weldDataTable = clsConvertXMLDataTable.ConvertDataTableToSchema(data);
                }
                else
                {
                    sdata.RowsCount = data.Rows.Count;
                    sdata.weldDataTable = clsConvertXMLDataTable.ConvertDataTableToXML(data);
                }
            }
            //MC.WeldServiceReference.WeldServiceClient _client = new MC.WeldServiceReference.WeldServiceClient();


            //_client.Endpoint.Name="WSHttpBinding_IWeldService";
            //_client.Endpoint.Address=new System.ServiceModel.EndpointAddress("http://127.0.0.1:8734/JN_WELD_Service/Service1/");
            //_client.Endpoint.Binding=wshttpbing;
            ////_client.Endpoint.Contract=new System.ServiceModel.Description.ContractDescription("WSHttpBinding_IWeldService","WeldServiceReference.IWeldService");
            ////_client.Endpoint.
            //_client.Open();
            //_client.Close();

            //rsdt = ServiceCall(sdata);


            if (_svrclient.State != System.ServiceModel.CommunicationState.Opened)
            {
                //switch (_svrclient.State)
                //{
                //    case System.ServiceModel.CommunicationState.Faulted:
                //        _svrclient.Close();
                //        _svrclient.Open();
                //        break;
                //    case System.ServiceModel.CommunicationState.Closed:
                //        _svrclient.Open();
                //        break;
                //    default:
                //        break;
                //}
                buildConnectSvr();

            }
            try
            {
                rsdt = _svrclient.ServiceCall(sdata);
            }
            catch (Exception ex)
            {
                if (_svrclient.State != System.ServiceModel.CommunicationState.Opened)
                {
                    buildConnectSvr();
                    try
                    {
                        rsdt = _svrclient.ServiceCall(sdata);
                    }
                    catch (Exception nex)
                    {
                        throw nex;
                    }
                }
            }

            //if (rsdt.RowsCount == 0)
            // return clsConvertXMLDataTable.ConvertxmlSchemaToDataTable(rsdt.weldDataTable);
            //else
            return clsConvertXMLDataTable.ConvertXMLToDataTable(rsdt.weldDataTable);

        }


        ///// <summary>
        ///// 进一步封装服务器调用程序
        ///// </summary>
        ///// <param name="?"></param>
        ///// <returns></returns>
        public  DataTable ServiceCall(int cmdcode, DataTable data)
        {

            MC.WeldServiceReference.CompositeType sdata = new MC.WeldServiceReference.CompositeType();
            MC.WeldServiceReference.CompositeType rsdt = new MC.WeldServiceReference.CompositeType();
            sdata.CmdCode = cmdcode;
            if (data == null)
            {
                sdata.RowsCount = 0;
                sdata.weldDataTable = "";


            }
            else
            {
                if (data.Rows.Count == 0)
                {
                    sdata.RowsCount = 0;
                    sdata.weldDataTable = clsConvertXMLDataTable.ConvertDataTableToSchema(data);
                }
                else
                {
                    sdata.RowsCount = data.Rows.Count;
                    sdata.weldDataTable = clsConvertXMLDataTable.ConvertDataTableToXML(data);
                }
            }
            //MC.WeldServiceReference.WeldServiceClient _client = new MC.WeldServiceReference.WeldServiceClient();

            
            //_client.Endpoint.Name="WSHttpBinding_IWeldService";
            //_client.Endpoint.Address=new System.ServiceModel.EndpointAddress("http://127.0.0.1:8734/JN_WELD_Service/Service1/");
            //_client.Endpoint.Binding=wshttpbing;
            ////_client.Endpoint.Contract=new System.ServiceModel.Description.ContractDescription("WSHttpBinding_IWeldService","WeldServiceReference.IWeldService");
            ////_client.Endpoint.
            //_client.Open();
            //_client.Close();
            
            //rsdt = ServiceCall(sdata);


            if (_svrclient.State != System.ServiceModel.CommunicationState.Opened)
            {
                //switch (_svrclient.State)
                //{
                //    case System.ServiceModel.CommunicationState.Faulted:
                //        _svrclient.Close();
                //        _svrclient.Open();
                //        break;
                //    case System.ServiceModel.CommunicationState.Closed:
                //        _svrclient.Open();
                //        break;
                //    default:
                //        break;
                //}
                buildConnectSvr();
                
            }
            try
            {
                rsdt = _svrclient.ServiceCall(sdata);
            }
            catch (Exception ex)
            {
                if (_svrclient.State != System.ServiceModel.CommunicationState.Opened)
                {
                    buildConnectSvr();
                    try
                    {
                        rsdt = _svrclient.ServiceCall(sdata);
                    }
                    catch (Exception nex)
                    {
                        throw nex;
                    }
                }
            }

            //if (rsdt.RowsCount == 0)
               // return clsConvertXMLDataTable.ConvertxmlSchemaToDataTable(rsdt.weldDataTable);
            //else
                return clsConvertXMLDataTable.ConvertXMLToDataTable(rsdt.weldDataTable);

        }
    }
}
