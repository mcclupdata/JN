using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.IO;
using System.Xml;
namespace JN_WELD_Service
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService1”。
    [ServiceContract(Namespace = "JN.WELD.Service")]
    public interface IWeldService
    {
        [OperationContract]
        string GetData(int value);
        
        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);
        [OperationContract]
        CompositeType ServiceCall(CompositeType cmd);

        // TODO: 在此添加您的服务操作
    }

    // 使用下面示例中说明的数据约定将复合类型添加到服务操作。
    // 可以将 XSD 文件添加到项目中。在生成项目后，可以通过命名空间“JN_WELD_Service.ContractType”直接使用其中定义的数据类型。
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";
        DataTable _datatable = null;
        String xmlDataTale = "";
        int _cmdCode = 0;
        int _RowsCount = 0;
        [DataMember]
        public Int32 CmdCode
        {
            get { return _cmdCode; }
            set { _cmdCode = value; }

        }
        [DataMember]
        public Int32 RowsCount
        {
            get { return _RowsCount; }
            set { _RowsCount = value; }

        }
        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }
        [DataMember]
        public String weldDataTable
        {
            get {
                if (_datatable == null)
                    return xmlDataTale;
               // if (_datatable.Rows.Count == 0)
                //{
                  //  _RowsCount = 0;
                   // return clsConvertXMLDataTable.ConvertDataTableToXML(_datatable);
                //}
                return clsConvertXMLDataTable.ConvertDataTableToXML(_datatable);}
            set { this.xmlDataTale  =value ;
            if (this.xmlDataTale == null)
                return;
            else
            {
               // if (_RowsCount == 0)
                   // _datatable = clsConvertXMLDataTable.ConvertxmlSchemaToDataTable(this.xmlDataTale);
               // else

                    _datatable = clsConvertXMLDataTable.ConvertXMLToDataTable(xmlDataTale);
            }
            
            }
        }
        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
         
    }
}
