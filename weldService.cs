using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using System.Xml;
namespace JN_WELD_Service
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“Service1”。
    public class weldService : IWeldService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }
       
        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        string IWeldService.GetData(int value)
        {
            throw new NotImplementedException();
        }

        CompositeType IWeldService.GetDataUsingDataContract(CompositeType composite)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 客户端调用服务器处理入口
        /// </summary>
        /// <param name="cmd">指令及参数</param>
        /// <returns></returns>
        CompositeType IWeldService.ServiceCall(CompositeType cmd)
        {
            CompositeType rst = new CompositeType();
            DataTable dt=null;

            if (cmd.weldDataTable.Length==0)
                dt = null;
            else
             dt = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
            
            switch(cmd.CmdCode)
                {
                    //处理主要任务，所有任务按照10000起始编号进行
                case 10001:
                        break;
                case 1002://执行导入焊工数据
                        {
                            
                            svrBatchInputWelder cls = new svrBatchInputWelder(dt);
                            dt = cls.Execut();//执行
                            rst.RowsCount = dt.Rows.Count;
                            String xml = clsConvertXMLDataTable.ConvertDataTableToXML(dt);
                            rst.BoolValue = true;
                            rst.weldDataTable = xml;
                            break;
                        }
                case 1003://执行导入焊缝数据;
                        {
                            svrBatchInputWeldinfos cls = new svrBatchInputWeldinfos(dt);
                            dt = cls.Execut();//执行
                            rst.RowsCount = dt.Rows.Count;
                            String xml = clsConvertXMLDataTable.ConvertDataTableToXML(dt);
                            rst.BoolValue = true;
                            rst.weldDataTable = xml;
                            break;
                        }
                case 1009://查询得到空工序计划表体数据
                        {
                            svrdbProject cls = new svrdbProject();
                            DataTable empbd= cls.GetemptyBody();
                            empbd.TableName = "processbody";
                            rst.RowsCount = empbd.Rows.Count;
                            String xml = clsConvertXMLDataTable.ConvertDataTableToSchema(empbd);
                            rst.BoolValue = true;
                            rst.weldDataTable = xml;
                            break;
                        }
                case 1008://查询得到空工序计划表头数据
                        {
                            svrdbProject cls = new svrdbProject();
                            DataTable empbd = cls.GetemptyHead();
                            empbd.TableName = "processhead";

                            rst.RowsCount = empbd.Rows.Count;
                            String xml = clsConvertXMLDataTable.ConvertDataTableToSchema(empbd);
                            rst.BoolValue = true;
                            rst.weldDataTable = xml;
                            break;
                        }
                case 1010://查询得到部门数据
                    {
                        svrdbProject cls = new svrdbProject();
                        DataTable empbd = cls.GetDepart();
                        empbd.TableName = "DoDepart";

                        rst.RowsCount = empbd.Rows.Count;
                        String xml = clsConvertXMLDataTable.ConvertDataTableToXML(empbd);
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                case 1011://查询的到工程号，分段号所在的所有焊缝信
                    {
                        svrdbProject cls = new svrdbProject();
                        DataTable filter = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        DataTable empbd = cls.GetWeldinfoByFilter(filter);
                        empbd.TableName = "Weldinfos";

                        rst.RowsCount = empbd.Rows.Count;
                        String xml ;
                        if (rst.RowsCount==0)
                            xml=clsConvertXMLDataTable.ConvertDataTableToSchema(empbd);
                        else
                            xml= clsConvertXMLDataTable.ConvertDataTableToXML(empbd);
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                case 1012://1012;//通过查询条件得到WPS数据
                    {
                        svrdbProject cls = new svrdbProject();
                        DataTable filter = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);

                        DataTable empbd = cls.GetWPSByFilter(filter);
                        empbd.TableName = "wpsrule";

                        rst.RowsCount = empbd.Rows.Count;
                        String xml;
                        if (rst.RowsCount == 0)
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(empbd);
                        else
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(empbd);
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
               
                case 1014:////1014;//通过查询条件得到工序计划表?
                    {
                        svrdbProject cls = new svrdbProject();
                        DataTable fdt = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        DataTable empbd = cls.GetHead(fdt);
                        empbd.TableName = "ProjectHead";

                        rst.RowsCount = empbd.Rows.Count;
                        String xml;
                        if (rst.RowsCount == 0)
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(empbd);
                        else
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(empbd);
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                case 1015:////1015;//通过查询条件得到工序计划表体Index?
                    {
                        svrdbProject cls = new svrdbProject();
                        DataTable fdt = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        DataTable empbd = cls.GetProjectBodyIndex(fdt);
                        empbd.TableName = "ProjectBodyIndex";

                        rst.RowsCount = empbd.Rows.Count;
                        String xml;
                        if (rst.RowsCount == 0)
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(empbd);
                        else
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(empbd);
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                case 1016:////通过查询条件得到工序计划表体内的焊缝及WPS
                    {
                        svrdbProject cls = new svrdbProject();
                        DataTable fdt = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        DataTable empbd = cls.GetProjectBody_WeldInfo(fdt);
                        empbd.TableName = "ProjectBodyWeldInfos";

                        rst.RowsCount = empbd.Rows.Count;
                        String xml;
                        if (rst.RowsCount == 0)
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(empbd);
                        else
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(empbd);
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                   //1016;//通过查询条件得到工序计划表体内的焊缝及WPS
                case 1017:// 1017;//查询得到可以用于派工的工序计划
                    {
                        svrFirstDispatch cls = new svrFirstDispatch();
                      
                        DataTable rsdt = cls.GetProject();
                        rsdt.TableName = "Project";

                        rst.RowsCount = rsdt.Rows.Count;
                        String xml;
                        if (rst.RowsCount == 0)
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(rsdt);
                        else
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(rsdt);
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                case 10171:// 1017;//查询得到可以用于派工的工序计划
                    {
                        svrFirstDispatch cls = new svrFirstDispatch();

                        DataTable rsdt = cls.GetProject();
                        rsdt.TableName = "Project";

                        rst.RowsCount = rsdt.Rows.Count;
                        String xml;
                        if (rst.RowsCount == 0)
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(rsdt);
                        else
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(rsdt);
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                case 1018:// 1018;//由工序计划FID查询得到工序计划体Index；
                    {
                        svrFirstDispatch cls = new svrFirstDispatch();
                        DataTable fdt = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        DataTable empbd = cls.GetProjectBody_SHIP_NO(fdt);
                        empbd.TableName = "ProjectBodyIndex";

                        rst.RowsCount = empbd.Rows.Count;
                        String xml;
                        if (rst.RowsCount == 0)
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(empbd);
                        else
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(empbd);
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                case 10181:// 1018;//由工序计划FID查询得到工序计划体Index；
                    {
                        svrFirstDispatch cls = new svrFirstDispatch();
                        DataTable fdt = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        DataTable empbd = cls.GetProjectBody_SHIP_NO(fdt);
                        empbd.TableName = "ProjectBodyIndex";

                        rst.RowsCount = empbd.Rows.Count;
                        String xml;
                        if (rst.RowsCount == 0)
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(empbd);
                        else
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(empbd);
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                case 1019:// 1019;//由工序计划FID查询得到可用的部门
                    {
                        svrFirstDispatch cls = new svrFirstDispatch();
                        DataTable fdt = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        DataTable empbd = cls.GetCanDoDepart(fdt);
                        empbd.TableName = "CandoDepart";

                        rst.RowsCount = empbd.Rows.Count;
                        String xml;
                        if (rst.RowsCount == 0)
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(empbd);
                        else
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(empbd);
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                case 10191:// 1019;//由工序计划FID查询得到可用的部门
                    {
                        svrFirstDispatch cls = new svrFirstDispatch();
                        DataTable fdt = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        DataTable empbd = cls.GetCanDoDepart(fdt);
                        empbd.TableName = "CandoDepart";

                        rst.RowsCount = empbd.Rows.Count;
                        String xml;
                        if (rst.RowsCount == 0)
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(empbd);
                        else
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(empbd);
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                   // 


                //cmd_SHIP_NO_TREE_NAME_WELD = 1020;
                case 1020:////查询的到工程号，分段号所在的所有焊缝信息;
                    {
                        svrdbProject cls = new svrdbProject();
                        DataTable fdt = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        DataTable empbd = cls.GetWeldinfoByFilter(fdt);
                        empbd.TableName = "1020";

                        rst.RowsCount = empbd.Rows.Count;
                        String xml;
                        if (rst.RowsCount == 0)
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(empbd);
                        else
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(empbd);
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                case 1022:////由工序计划得到焊缝WPS信息;
                    {
                        svrFirstDispatch cls = new svrFirstDispatch();
                        DataTable fdt = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        DataTable empbd = cls.GetDispatchWeldInfoWps(fdt);
                        empbd.TableName = "WeldInfos";

                        rst.RowsCount = empbd.Rows.Count;
                        String xml;
                        if (rst.RowsCount == 0)
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(empbd);
                        else
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(empbd);
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                case 10221:////由工序计划得到焊缝WPS信息;
                    {
                        svrFirstDispatch cls = new svrFirstDispatch();
                        DataTable fdt = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        DataTable empbd = cls.GetDispatchWeldInfoWps(fdt);
                        empbd.TableName = "WeldInfos";

                        rst.RowsCount = empbd.Rows.Count;
                        String xml;
                        if (rst.RowsCount == 0)
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(empbd);
                        else
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(empbd);
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                    //int cmd_FDispatch_GetDispatchHeadByFID = 1023;//由派工单的FID获取派工单表头
                case 1023:////由派工单的FID获取派工单表头
                    {
                        svrFirstDispatch cls = new svrFirstDispatch();
                        DataTable fdt = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        DataTable empbd = cls.GetDispatchHead(fdt);
                        empbd.TableName = "WeldInfos";

                        rst.RowsCount = empbd.Rows.Count;
                        String xml;
                        if (rst.RowsCount == 0)
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(empbd);
                        else
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(empbd);
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                case 10231:////由派工单的FID获取派工单表头
                    {
                        svrFirstDispatch cls = new svrFirstDispatch();
                        DataTable fdt = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        DataTable empbd = cls.GetDispatchHead(fdt);
                        empbd.TableName = "WeldInfos";

                        rst.RowsCount = empbd.Rows.Count;
                        String xml;
                        if (rst.RowsCount == 0)
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(empbd);
                        else
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(empbd);
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                    //int cmd_FDispatch_GetDispatchBodyIndex = 1024;//由派工单的FID获取派工单表体的Index；
                case 1024:////由派工单的FID获取派工单表体的Index
                    {
                        svrFirstDispatch cls = new svrFirstDispatch();
                        DataTable fdt = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        DataTable empbd = cls.GetDispatchBodyIndex(fdt);
                        empbd.TableName = "WeldInfos";

                        rst.RowsCount = empbd.Rows.Count;
                        String xml;
                        if (rst.RowsCount == 0)
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(empbd);
                        else
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(empbd);
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                case 10241:////由派工单的FID获取派工单表体的Index
                    {
                        svrFirstDispatch cls = new svrFirstDispatch();
                        DataTable fdt = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        DataTable empbd = cls.GetDispatchBodyIndex(fdt);
                        empbd.TableName = "WeldInfos";

                        rst.RowsCount = empbd.Rows.Count;
                        String xml;
                        if (rst.RowsCount == 0)
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(empbd);
                        else
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(empbd);
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                case 1025:////任务单--获取可用部门
                    {
                        svrTask cls = new svrTask();
                        DataTable fdt = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        DataTable empbd = cls.GetDepartments();
                        empbd.TableName = "WeldInfos";

                        rst.RowsCount = empbd.Rows.Count;
                        String xml;
                        if (rst.RowsCount == 0)
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(empbd);
                        else
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(empbd);
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                case 1026:////任务单--获取已经分派的任务以及未分派的焊缝信息
                    {
                        svrTask cls = new svrTask();
                        DataTable fdt = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        DataTable empbd = cls.GetWeldFrTaskListwithDispatch();
                        empbd.TableName = "WeldFrTaskListwithDispatch";

                        rst.RowsCount = empbd.Rows.Count;
                        String xml;
                        if (rst.RowsCount == 0)
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(empbd);
                        else
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(empbd);
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                //1028
                case 1028:////任务单--获取所有焊工信息
                    {
                        svrTask cls = new svrTask();
                        DataTable fdt = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        DataTable empbd = cls.GetWelders();
                        empbd.TableName = "Task_welders";

                        rst.RowsCount = empbd.Rows.Count;
                        String xml;
                        if (rst.RowsCount == 0)
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(empbd);
                        else
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(empbd);
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                case 1029:////任务单--获取所有焊工的当日的焊接任务；
                    {
                        svrWelderTask cls = new svrWelderTask();
                        DataTable fdt = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        DataTable empbd = cls.GetWelderTaskLists(fdt);
                        empbd.TableName = "Task_welders";

                        rst.RowsCount = empbd.Rows.Count;
                        String xml;
                        if (rst.RowsCount == 0)
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(empbd);
                        else
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(empbd);
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                case 102901:////获取班组未分配的焊缝；
                    {
                        svrWelderTask cls = new svrWelderTask();
                        DataTable fdt = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        DataTable empbd = cls.GetUnDispTaskList(fdt);
                        empbd.TableName = "Task_welders";

                        rst.RowsCount = empbd.Rows.Count;
                        String xml;
                        if (rst.RowsCount == 0)
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(empbd);
                        else
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(empbd);
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                case 1030:////1030;//查询得到焊机名，编号，状态
                    {
                        svrDevices cls = new svrDevices();
                       // DataTable fdt = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        DataTable empbd = cls.getweldEquipmentinfos();//GetPanasponicDrives();
                        empbd.TableName = "Task_welders";

                        rst.RowsCount = empbd.Rows.Count;
                        String xml;
                        if (rst.RowsCount == 0)
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(empbd);
                        else
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(empbd);
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                case 1031:////1031;//查询得到焊机Channel信息
                    {
                        svrDevices cls = new svrDevices();
                        // DataTable fdt = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        DataTable empbd = cls.GetPanasoicDrivesChannelInfos();
                        empbd.TableName = "Task_welders";

                        rst.RowsCount = empbd.Rows.Count;
                        String xml;
                        if (rst.RowsCount == 0)
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(empbd);
                        else
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(empbd);
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                case 1033:////1033得到历史记录的数据；
                    {
                        svrWelderTask cls = new svrWelderTask();
                        DataTable fdt = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        DataTable empbd = cls.GetHistoryRealInfos(dt);
                        empbd.TableName = "Task_welders";

                        rst.RowsCount = empbd.Rows.Count;
                        String xml;
                        if (rst.RowsCount == 0)
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(empbd);
                        else
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(empbd);
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                case 1034:////1034获取所有工序计划；
                    {
                        svrdbProject cls = new svrdbProject();
                        //DataTable fdt = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        DataTable empbd = cls.GetProjectHead();
                        empbd.TableName = "projectheafd";

                        rst.RowsCount = empbd.Rows.Count;
                        String xml;
                        if (rst.RowsCount == 0)
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(empbd);
                        else
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(empbd);
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                case 1036:////1035获取所有派工单信息；
                    {
                        svrFirstDispatch cls = new svrFirstDispatch();
                        //DataTable fdt = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        DataTable empbd = cls.GetDispatchHead();
                        empbd.TableName = "projectheafd";

                        rst.RowsCount = empbd.Rows.Count;
                        String xml;
                        if (rst.RowsCount == 0)
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(empbd);
                        else
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(empbd);
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                //1041按照给定的时间看焊工的任务汇总
                case 1041:////1035获取所有派工单信息；
                    {
                        svrRealTime cls = new svrRealTime();
                        DataTable fdt = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        DataTable empbd = cls.GetWelderTaskSum(fdt);
                        empbd.TableName = "projectheafd";

                        rst.RowsCount = empbd.Rows.Count;
                        String xml;
                        if (rst.RowsCount == 0)
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(empbd);
                        else
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(empbd);
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                case 1042:////1042获取当日焊工当日任务明细；
                    {
                        svrRealTime cls = new svrRealTime();
                        DataTable fdt = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        DataTable empbd = cls.GetWelderTaskInfos(fdt);
                        empbd.TableName = "GetWelderTaskInfos";

                        rst.RowsCount = empbd.Rows.Count;
                        String xml;
                        if (rst.RowsCount == 0)
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(empbd);
                        else
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(empbd);
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                //1043 获取某一任务的评估结果
                case 1043:////1042获取当日焊工当日任务明细；
                    {
                        svrRealTime cls = new svrRealTime();
                        DataTable fdt = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        DataTable empbd = cls.GetHistoryEvaResult(fdt);
                        empbd.TableName = "GetWelderTaskInfos";

                        rst.RowsCount = empbd.Rows.Count;
                        String xml;
                        if (rst.RowsCount == 0)
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(empbd);
                        else
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(empbd);
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                case 2001://获取工程号
                    {
                        svrdbProject cls = new svrdbProject();
                       
                        DataTable empbd = cls.GetSHIP_NO();
                        empbd.TableName = "SHIP_NO";

                        rst.RowsCount = empbd.Rows.Count;
                        String xml;
                        if (rst.RowsCount == 0)
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(empbd);
                        else
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(empbd);
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                case 2002://通过工程号得到分段号
                    {
                        svrdbProject cls = new svrdbProject();
                        DataTable filter = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        DataTable empbd = cls.GetTREE_NAME_WithFilter(filter);
                        empbd.TableName = "TREE_NAME";

                        rst.RowsCount = empbd.Rows.Count;
                        String xml;
                        if (rst.RowsCount == 0)
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(empbd);
                        else
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(empbd);
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                case 56291://获取焊工任务中的莫一条焊缝，带WPS，带WPS通道信息，由FID索引
                    {
                        svrWelderTask cls = new svrWelderTask();
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        DataTable srdt = cls.GetWelderWeldWithWPSInfoByFID(data);
                        srdt.TableName = "ExcutResult";

                        rst.RowsCount = srdt.Rows.Count;
                        String xml;
                        if (rst.RowsCount == 0)
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(srdt);
                        else
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(srdt);
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                case 562911://获取焊工任务中的莫一条焊缝，带WPS，带WPS通道信息，由FID索引
                    {
                        svrWelderTask cls = new svrWelderTask();
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        DataTable srdt = cls.GetWelderWeldWithWPSInfoByFID_UNDIS(data);
                        srdt.TableName = "ExcutResult";

                        rst.RowsCount = srdt.Rows.Count;
                        String xml;
                        if (rst.RowsCount == 0)
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(srdt);
                        else
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(srdt);
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                case 57041://将wps数据中的主规程导入到数据库中
                    {
                        svrBatchInputWPS cls = new svrBatchInputWPS();
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        DataTable srdt = cls.Savetotmp_wps(data);
                        srdt.TableName = "wps";

                        rst.RowsCount = srdt.Rows.Count;
                        String xml;
                        if (rst.RowsCount == 0)
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(srdt);
                        else
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(srdt);
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                case 57042://将wps数据中的子规程导入到数据库中
                    {
                        svrBatchInputWPS cls = new svrBatchInputWPS();
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        DataTable srdt = cls.Savetotmp_wpssub(data);
                        srdt.TableName = "wpssub";

                        rst.RowsCount = srdt.Rows.Count;
                        String xml;
                        if (rst.RowsCount == 0)
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(srdt);
                        else
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(srdt);
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                case 57051://加载WPS主规程
                    {
                        svrWPSEdit cls = new svrWPSEdit();
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        DataTable srdt = cls.LoadWPS();
                        srdt.TableName = "wps";

                        rst.RowsCount = srdt.Rows.Count;
                        String xml;
                        if (rst.RowsCount == 0)
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(srdt);
                        else
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(srdt);
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                case 57052://加载WPS主规程
                    {
                        svrWPSEdit cls = new svrWPSEdit();
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        DataTable srdt = cls.LoadWPSSub();
                        srdt.TableName = "wpssub";

                        rst.RowsCount = srdt.Rows.Count;
                        String xml;
                        if (rst.RowsCount == 0)
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(srdt);
                        else
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(srdt);
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                case 57053://删除规程
                    {
                        svrWPSEdit cls = new svrWPSEdit();
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        DataTable srdt = cls.DeleteWPS(data);
                        srdt.TableName = "del_wps";

                        rst.RowsCount = srdt.Rows.Count;
                        String xml;
                        if (rst.RowsCount == 0)
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(srdt);
                        else
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(srdt);
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                case 6014://提交表工序计划表单--表头命令
                    {
                        svrdbProject cls = new svrdbProject();
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        DataTable srdt = cls.SaveProjectHead(data);
                        srdt.TableName = "SaveProjectHead";

                        rst.RowsCount = srdt.Rows.Count;
                        String xml;
                        if (rst.RowsCount == 0)
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(srdt);
                        else
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(srdt);
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                case 6015://提交表工序计划表单--表体命令
                    {
                        svrdbProject cls = new svrdbProject();
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        DataTable srdt = cls.SaveProjectBody(data);
                        srdt.TableName = "SaveProjectBody";

                        rst.RowsCount = srdt.Rows.Count;
                        String xml;
                        if (rst.RowsCount == 0)
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(srdt);
                        else
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(srdt);
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                case 6016://提交表派工单表单--表头命令
                    {
                        svrFirstDispatch cls = new svrFirstDispatch();
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        DataTable srdt = cls.SaveDispatchHead(data);
                        srdt.TableName = "SaveDispatchHead";

                        rst.RowsCount = srdt.Rows.Count;
                        String xml;
                        if (rst.RowsCount == 0)
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(srdt);
                        else
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(srdt);
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                case 60161://提交表派工单表单--表头命令
                    {
                        svrFirstDispatch cls = new svrFirstDispatch();
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        DataTable srdt = cls.SaveDispatchHead(data);
                        srdt.TableName = "SaveDispatchHead";

                        rst.RowsCount = srdt.Rows.Count;
                        String xml;
                        if (rst.RowsCount == 0)
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(srdt);
                        else
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(srdt);
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                case 6017://提交派工单表单--表体命令
                    {
                        svrFirstDispatch cls = new svrFirstDispatch();
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        DataTable srdt = cls.SaveDispatchBody(data);
                        srdt.TableName = "SaveDispatchBody";

                        rst.RowsCount = srdt.Rows.Count;
                        String xml;
                        if (rst.RowsCount == 0)
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(srdt);
                        else
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(srdt);
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                case 60171://提交派工单表单--表体命令
                    {
                        svrFirstDispatch cls = new svrFirstDispatch();
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        DataTable srdt = cls.SaveDispatchBody(data);
                        srdt.TableName = "SaveDispatchBody";

                        rst.RowsCount = srdt.Rows.Count;
                        String xml;
                        if (rst.RowsCount == 0)
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(srdt);
                        else
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(srdt);
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                //6018//提交任务单
                case 6018://提交任务单
                    {
                        svrTask cls = new svrTask();
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        DataTable srdt = cls.SaveTask(data);
                        srdt.TableName = "SaveTaskBody";

                        rst.RowsCount = srdt.Rows.Count;
                        String xml;
                        if (rst.RowsCount == 0)
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(srdt);
                        else
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(srdt);
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                //int cmd_delete_Project = 7001;//删除工序计划表头，表体
                case 7001://删除工序计划表头，表体
                    {
                        svrdbProject cls = new svrdbProject();
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        DataTable srdt = cls.DeleteProject(data);
                        srdt.TableName = "ExcutResult";

                        rst.RowsCount = srdt.Rows.Count;
                        String xml;
                        if (rst.RowsCount == 0)
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(srdt);
                        else
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(srdt);
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                //int cmd_delete_Project = 7001;//删除工序计划表头，表体
                case 7002://删除派工计划
                    {
                        svrFirstDispatch cls = new svrFirstDispatch();
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        DataTable srdt = cls.DeleteDispatch(data);
                        srdt.TableName = "ExcutResult";

                        rst.RowsCount = srdt.Rows.Count;
                        String xml;
                        if (rst.RowsCount == 0)
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(srdt);
                        else
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(srdt);
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                case 70021://删除派工计划
                    {
                        svrFirstDispatch cls = new svrFirstDispatch();
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        DataTable srdt = cls.DeleteDispatch(data);
                        srdt.TableName = "ExcutResult";

                        rst.RowsCount = srdt.Rows.Count;
                        String xml;
                        if (rst.RowsCount == 0)
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(srdt);
                        else
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(srdt);
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                case 7003://删除任务
                    {
                        svrTask cls = new svrTask();
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        DataTable srdt = cls.DeleteTask(data);
                        srdt.TableName = "ExcutResult";

                        rst.RowsCount = srdt.Rows.Count;
                        String xml;
                        if (rst.RowsCount == 0)
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(srdt);
                        else
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(srdt);
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                case 7004://更新焊工任务
                    {
                        svrWelderTask cls = new svrWelderTask();
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        DataTable srdt = cls.UpdateTaskState(data);
                        srdt.TableName = "ExcutResult";

                        rst.RowsCount = srdt.Rows.Count;
                        String xml;
                        if (rst.RowsCount == 0)
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(srdt);
                        else
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(srdt);
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                case 56271://按照班组，时间，提取任务计划
                    {
                        svrTask cls = new svrTask();
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        DataTable srdt = cls.GetWelderTaskList(data);
                        srdt.TableName = "TaskList";

                        rst.RowsCount = srdt.Rows.Count;
                        String xml;
                        if (rst.RowsCount == 0)
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(srdt);
                        else
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(srdt);
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                case 56272://获取部门详细信息；
                    {
                        svrTask cls = new svrTask();
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        DataTable srdt = cls.GetDepartments();
                        srdt.TableName = "Department";

                        rst.RowsCount = srdt.Rows.Count;
                        String xml;
                        if (rst.RowsCount == 0)
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(srdt);
                        else
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(srdt);
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                case 56281://直接执行SQL语句
                    {
                        SqlDbHelper _sqldb = new SqlDbHelper();
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        String sql =Convert.ToString( data.Rows[0][0]);
                        data = new DataTable();
                        data = _sqldb.ExecuteDataTable(sql);
                        data.TableName = "sql";
                        rst.RowsCount = data.Rows.Count;
                        String xml;
                        if (rst.RowsCount == 0)
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(data);
                        else
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(data);
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                case 56282://删除派工单
                    {
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        String sql = Convert.ToString(data.Rows[0][0]);
                        
                        svrFirstDispatch svr = new svrFirstDispatch();
                        DataTable sdt = svr.DeleteDispatch(data);
                        rst.RowsCount = data.Rows.Count;
                        String xml;
                        if (rst.RowsCount == 0)
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        else
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                        
                    }
                    //焊机监控--获取焊机设备集合
                case 509201:
                    {
                        svrWeldEquipmentReal svr = new svrWeldEquipmentReal();
                        DataTable sdt = svr.getWeldEquipments();
                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);
                            
                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }

                //焊机监控--获取焊机设备位置集合
                case 509202:
                    {

                        svrWeldEquipmentReal svr = new svrWeldEquipmentReal();
                        DataTable sdt = svr.getWeldEquipmentPoint();
                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;

                        
                    }
                //焊机监控--通过给定的焊机编号，查询得到焊机的基本信息：预置电流，预置电压，状态
                case 509203:
                    {
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);

                        svrWeldEquipmentReal svr = new svrWeldEquipmentReal();
                        DataTable sdt = svr.getWeldEquipmentBaseInfo(data);
                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;

                        
                    }
                //焊机监控--通过焊机的nom，获取使用焊机的最前面10位焊工任务信息
                case 509204:
                    {
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);

                        svrWeldEquipmentReal svr = new svrWeldEquipmentReal();
                        DataTable sdt = svr.getWelderTaskbyWeldEquipID(data);
                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                        
                    }
                //焊机总成--获取焊机基本参数集合；
                case 509205:
                    {
                        //svrweldEquipmentmanage svr = new svrweldEquipmentmanage();
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);

                        svrweldEquipmentmanage svr = new svrweldEquipmentmanage();
                        DataTable sdt = svr.getweldEquipParams(data);
                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                //焊机总成--加载当前存在的焊机；
                case 509206:
                    {
                        break;
                    }
                //焊机总成--加载焊机厂家
                case 509207:
                    {

                        break;
                    }
                //焊机总成--加载所有焊机集合
                case 509208:
                    {
                        break;
                    }
                //焊机总成--提交保存焊机信息
                case 509209:
                    {
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);

                        svrweldEquipmentmanage svr = new svrweldEquipmentmanage();
                        DataTable sdt = svr.UpdateweldEquipmentInfo(data);
                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                //获取指定焊机的历史数据，按照任务进行查询5092601
                case 5092601:
                    {
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);

                        svrWeldEquipmentReal svr = new svrWeldEquipmentReal();
                        DataTable sdt = svr.getweldEquipmentHistory(data);
                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                case 5092602:
                    {
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);

                        svrWeldEquipmentReal svr = new svrWeldEquipmentReal();
                        DataTable sdt = svr.getWledEquipmentRealAndTask(data);
                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                       

                    }
                case 5100501:
                    {
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);

                        svrReport svr = new svrReport();
                        DataTable sdt = svr.getWeldSectionRp(data);
                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                       

                    }
                case 5100502:
                    {
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);

                        svrReport svr = new svrReport();
                        DataTable sdt = svr.getweldReport_weld(data);
                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                       

                    }
                case 5100503:
                    {
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);

                        svrReport svr = new svrReport();
                        DataTable sdt = svr.getWeldReport_Welder(data);
                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;


                    }
                case 5100504:
                    {
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);

                        svrReport svr = new svrReport();
                        DataTable sdt = svr.getTaskReport(data);
                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;


                    }
                case 5100505:
                    {
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);

                        svrReport svr = new svrReport();
                        DataTable sdt = svr.getReportBase(data);
                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;


                    }
                case 5100506:
                    {
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);

                        svrDepartmags svr = new svrDepartmags();
                        DataTable sdt = svr.getDepartments(data);
                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;


                    }
                case 5100507:
                    {
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);

                        svrDepartmags svr = new svrDepartmags();
                        DataTable sdt = svr.upDateDepartments(data);
                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;


                    }
                    //批量更新WPS  命令代码5101401
                case 5101401:
                    {
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);

                        svrWPSEdit svr = new svrWPSEdit();
                        DataTable sdt = svr.UpdateWPS(cmd.weldDataTable,Convert.ToInt32(cmd.StringValue));
                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;


                    }
                //批量更新WPS子规程 5101402
                case 5101402:
                    {
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);

                        svrWPSEdit svr = new svrWPSEdit();
                        DataTable sdt = svr.UpdateSUBWPS(cmd.weldDataTable, Convert.ToInt32(cmd.StringValue));
                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;


                    }
                    //获取焊工所在班组及其全称信息 5101501
                case 5101501:
                    {
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);

                        svrWelderEdit svr = new svrWelderEdit();
                        DataTable sdt = svr.getDepart();
                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;


                    }
                //获取所有焊工信息 5101502
                case 5101502:
                    {
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);

                        svrWelderEdit svr = new svrWelderEdit();
                        DataTable sdt = svr.getWelders();
                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;


                    }
                //获取所有工程队信息 5101503
                case 5101503:
                    {
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);

                        svrWelderEdit svr = new svrWelderEdit();
                        DataTable sdt = svr.getLibs();
                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;


                    }
                //获取焊工焊接等级数据 5101504
                case 5101504:
                    {
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);

                        svrWelderEdit svr = new svrWelderEdit();
                        DataTable sdt = svr.getWelderClass(data);
                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;


                    }
                //获取焊接等级信息 5101505
                case 5101505:
                    {
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);

                        svrWelderEdit svr = new svrWelderEdit();
                        DataTable sdt = svr.getWeldCLass();
                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;


                    }
                //更新焊工基础数据 5101506
                case 5101506:
                    {
                       DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);

                        svrWelderEdit svr = new svrWelderEdit();
                        int vtype = Convert.ToInt32(cmd.StringValue);
                       DataTable sdt = svr.Updatewelders(data,vtype);
                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;


                    }
                //更新焊工焊接等级信息 5101507
                case 5101507:
                    {
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        int vtype = Convert.ToInt32(cmd.StringValue);
                        svrWelderEdit svr = new svrWelderEdit();
                        DataTable sdt = svr.Updatewelders_WeldClass(data,vtype);
                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;


                    }
                //获取焊接等级信息库内容 5101508
                case 5101508:
                    {
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        //int vtype = Convert.ToInt32(cmd.StringValue);
                        svrWelderEdit svr = new svrWelderEdit();
                        DataTable sdt = svr.getweldModeTable();
                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;


                    }
                //更新焊接等级信息库内容 5101509
                case 5101509:
                    {
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        int vtype = Convert.ToInt32(cmd.StringValue);
                        svrWelderEdit svr = new svrWelderEdit();
                        DataTable sdt = svr.UpdateweldModeTable(data, vtype);
                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;


                    }
                //获取焊缝数据 5101510
                case 5101510:
                    {
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        //int vtype = Convert.ToInt32(cmd.StringValue);
                        svrWelderEdit svr = new svrWelderEdit();
                        DataTable sdt = svr.getWeldTable();
                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;


                    }
                //更新焊缝数据 5101509
                case 5101511:
                    {
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        int vtype = Convert.ToInt32(cmd.StringValue);
                        svrWelderEdit svr = new svrWelderEdit();
                        DataTable sdt = svr.UpdateWeldTable(data, vtype);
                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;


                    }
                    //获取船型数据 5101512
                case 5101512:
                    {
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        //int vtype = Convert.ToInt32(cmd.StringValue);
                        svrWelderEdit svr = new svrWelderEdit();
                        DataTable sdt = svr.getSHIP_MOD();
                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;


                    }

                //更新船型数据 5101512
                case 5101513:
                    {
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        int vtype = Convert.ToInt32(cmd.StringValue);
                        svrWelderEdit svr = new svrWelderEdit();
                        DataTable sdt = svr.UpdateSHIP_MOD(data, vtype);
                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;


                    }
                //合并焊缝数据并更新一个数据包
                case 5111801:
                    {
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);

                        svrClassMergeWeld svr = new svrClassMergeWeld();
                        DataTable sdt = svr.Classmergweld(data);
                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;


                    }
                //获取班组未分配的焊缝集合;
                case 5111802:
                    {
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                       // int vtype = Convert.ToInt32(cmd.StringValue);
                        svrClassMergeWeld svr = new svrClassMergeWeld();
                        DataTable sdt = svr.getClassUndispatchWeldes(data);
                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;


                    }
                ///获取打包焊缝后所包含的焊缝集合
                /// 5112001
                /// 
                case 5112001:
                    {
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        // int vtype = Convert.ToInt32(cmd.StringValue);
                        svrClassMergeWeld svr = new svrClassMergeWeld();
                        DataTable sdt = svr.GetMergedWelds(data);
                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;


                    }
                /// 获取默认WPS集合
                /// 5112101
                case 5112101:
                    {
                        //DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        // int vtype = Convert.ToInt32(cmd.StringValue);
                        svrDefaultWPS svr = new svrDefaultWPS();
                        DataTable sdt = svr.getDefaultWPSs();
                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                /// 获取当前使用的默认WPS
                /// 5112102
                case 5112102:
                    {
                        //DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        // int vtype = Convert.ToInt32(cmd.StringValue);
                        svrDefaultWPS svr = new svrDefaultWPS();
                        DataTable sdt = svr.getCurDefaultWPS();
                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                ///设置当前使用的默认wps
                /// 5112103
                /// 
                case 5112103:
                    {
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        // int vtype = Convert.ToInt32(cmd.StringValue);
                        svrDefaultWPS svr = new svrDefaultWPS();
                        DataTable sdt = svr.setCurDefaultWPS(data);
                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                /// 更新默认WPS数据
                /// 5112104
                case 5112104:
                    {
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        // int vtype = Convert.ToInt32(cmd.StringValue);
                        svrDefaultWPS svr = new svrDefaultWPS();
                        DataTable sdt = svr.UpdateDefalutwpss(data);
                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                /// 更新默认Subwps数据
                /// 5112105
                case 5112105:
                    {
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        // int vtype = Convert.ToInt32(cmd.StringValue);
                        svrDefaultWPS svr = new svrDefaultWPS();
                        DataTable sdt = svr.UpdateDefaultsubwpss(data);
                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                /// 获取默认Subwps数据
                /// 5112106
                case 5112106:
                    {
                        //DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        // int vtype = Convert.ToInt32(cmd.StringValue);
                        svrDefaultWPS svr = new svrDefaultWPS();
                        DataTable sdt = svr.getDefaultSubWPSs();
                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                /// <summary>
                /// 加载未匹配WPS的焊缝数据，并自动匹配
                /// 5112201
                /// </summary>
                case 5112201:
                    {
                        //DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        // int vtype = Convert.ToInt32(cmd.StringValue);
                        svrAutoMatchwps svr = new svrAutoMatchwps();
                        DataTable sdt = svr.getUnAutoMatchWPSWELDS();
                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                /// <summary>
                /// 获取已经匹配好WPS的焊缝数据
                /// 5112202
                /// </summary>
                case 5112202:
                    {
                        //DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        // int vtype = Convert.ToInt32(cmd.StringValue);
                        svrAutoMatchwps svr = new svrAutoMatchwps();
                        DataTable sdt = svr.getWeldswithWPS();
                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                /// <summary>
                /// 更新自动匹配的WPS数据
                /// 5112203
                /// </summary>
                case 5112203:
                    {
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        // int vtype = Convert.ToInt32(cmd.StringValue);
                        svrAutoMatchwps svr = new svrAutoMatchwps();
                        DataTable sdt = svr.UpdateAutomatchwps(data);
                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                /// 检测焊机设备内置WPS是否符合要求 且要求不能多条焊缝处理
                /// 5112501
                case 5112501:
                    {
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        // int vtype = Convert.ToInt32(cmd.StringValue);
                        svrWelderTask svr = new svrWelderTask();
                        DataTable sdt = svr.CheckEqumswps(data);
                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                /// 获取焊工等级标准库
                /// 5120201
                case 5120201:
                    {
                        //DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        // int vtype = Convert.ToInt32(cmd.StringValue);
                        svrweldingclass svr = new svrweldingclass();
                        DataTable sdt = svr.getweldingclass();
                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                /// 更新焊工等级标准库
                /// 5120202
                case 5120202:
                    {
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        int vtype = Convert.ToInt32(cmd.StringValue);
                        svrweldingclass svr = new svrweldingclass();
                        DataTable sdt = new DataTable() ;
                        switch (vtype)
                        {
                            case 0:
                                sdt = svr.Updateweldingclass(data);
                                break;
                            case 1:
                                sdt = svr.Insertweldingclass(data);
                                break;
                            case 2:
                                sdt = svr.Deleteweldingclass(data);
                                break;
                            default:
                                break;
                        }
                      
                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                /// <summary>
                /// 以焊缝为索引，统计数据 15122201
                /// </summary>
                case 15122201:
                    {
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        //int vtype = Convert.ToInt32(cmd.StringValue);
                        svrEvaluationRpt svr = new svrEvaluationRpt();
                        DataTable sdt = new DataTable();
                        sdt = svr.getEvaluationrpt_Welds(data);

                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                /// <summary>
                /// 按焊工为索引查询评估结果 15122202
                /// </summary>
                case 15122202:
                    {
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        //int vtype = Convert.ToInt32(cmd.StringValue);
                        svrEvaluationRpt svr = new svrEvaluationRpt();
                        DataTable sdt = new DataTable();
                        sdt = svr.getEvaluationrpt_Welders(data);

                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                /// <summary>
                /// 获取评估焊缝的所有分组：15122203
                /// </summary>
                case 15122203:
                    {
                        //DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        //int vtype = Convert.ToInt32(cmd.StringValue);
                        svrEvaluationRpt svr = new svrEvaluationRpt();
                        DataTable sdt = new DataTable();
                        sdt = svr.getAllWeldType();

                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                case 5123101:
                    {
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        long vtype = Convert.ToInt64(cmd.StringValue);
                        svrTask svr = new svrTask();
                        DataTable sdt = new DataTable();
                        sdt = svr.CheckWeldWeldingClass(data,vtype);

                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                case 5123102:
                    {
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        String vtype = cmd.StringValue;
                        svrTask svr = new svrTask();
                        DataTable sdt = new DataTable();
                        sdt = svr.CheckWeldWeldingClass(data, vtype);

                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                case 5123103:
                    {
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        //String vtype = cmd.StringValue;
                        svrweldingclass svr = new svrweldingclass();
                        DataTable sdt = new DataTable();
                        sdt = svr.GetWeldWeldingClass();

                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                case 5123104:
                    {
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        int vtype = Convert.ToInt32(cmd.StringValue);
                        svrweldingclass svr = new svrweldingclass();
                        DataTable sdt = new DataTable();
                        sdt = svr.UpdateWeldWeldingClass(data,vtype);

                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
        /// <summary>
        /// 获取工序计划表头 
        /// 6010101
        /// </summary>
                case 6010101:
                    {
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        //int vtype = Convert.ToInt32(cmd.StringValue);
                        svrPlanDispaTaskNewmange svr = new svrPlanDispaTaskNewmange();
                        DataTable sdt = new DataTable();
                        sdt = svr.getPlanHead();

                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                /// <summary>
                /// 获取派工单表头 
                /// 6010104
                /// </summary>
                case 6010104:
                    {
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        //int vtype = Convert.ToInt32(cmd.StringValue);
                        svrPlanDispaTaskNewmange svr = new svrPlanDispaTaskNewmange();
                        DataTable sdt = new DataTable();
                        sdt = svr.getDispatchHead();

                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                /// <summary>
                /// 获取工序计划表体--索引
                /// 6010102
                /// </summary>
                case 6010102:
                    {
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        //int vtype = Convert.ToInt32(cmd.StringValue);
                        svrPlanDispaTaskNewmange svr = new svrPlanDispaTaskNewmange();
                        DataTable sdt = new DataTable();
                        sdt = svr.getPanBodyIndex(data);

                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                /// <summary>
                /// 获取派工单表体--索引
                /// 6010105
                /// </summary>
                case 6010105:
                    {
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        //int vtype = Convert.ToInt32(cmd.StringValue);
                        svrPlanDispaTaskNewmange svr = new svrPlanDispaTaskNewmange();
                        DataTable sdt = new DataTable();
                        sdt = svr.getDispatchBodyIndex(data);

                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                /// <summary>
                /// 获取工序计划表体中部门所分配的焊缝信息；
                /// 6010103
                /// </summary>
                case 6010103:
                    {
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        //int vtype = Convert.ToInt32(cmd.StringValue);
                        svrPlanDispaTaskNewmange svr = new svrPlanDispaTaskNewmange();
                        DataTable sdt = new DataTable();
                        sdt = svr.getPanBodyList(data);

                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                /// <summary>
                /// 获取派工单表体中部门所分配的焊缝信息；
                /// 6010106
                /// </summary>
                case 6010106:
                    {
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        //int vtype = Convert.ToInt32(cmd.StringValue);
                        svrPlanDispaTaskNewmange svr = new svrPlanDispaTaskNewmange();
                        DataTable sdt = new DataTable();
                        sdt = svr.getDispatchBodyList(data);

                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                /// <summary>
                /// 获取全部坡口代码数据
                /// 6030101
                /// </summary>
                case 6030101:
                    {
                        //DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        //int vtype = Convert.ToInt32(cmd.StringValue);
                        svrweldcodepostEdit svr = new svrweldcodepostEdit();
                        DataTable sdt = new DataTable();
                        sdt = svr.getCODE();

                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                /// <summary>
                /// 获取全部焊接位置数据
                /// 6030102
                /// </summary>
                case 6030102:
                    {
                        //DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        //int vtype = Convert.ToInt32(cmd.StringValue);
                        svrweldcodepostEdit svr = new svrweldcodepostEdit();
                        DataTable sdt = new DataTable();
                        sdt = svr.getPOST();

                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                /// <summary>
                /// 更新坡口代码
                /// 6030103
                /// </summary>
                case 6030103:
                    {
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        int vtype = Convert.ToInt32(cmd.StringValue);
                        svrweldcodepostEdit svr = new svrweldcodepostEdit();
                        DataTable sdt = new DataTable();

                        sdt = svr.UpdatCode(data, vtype);

                        String xml;
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                /// <summary>
                /// 更新位置代码
                /// 6030104
                /// </summary>
                case 6030104:
                    {
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        int vtype = Convert.ToInt32(cmd.StringValue);
                        svrweldcodepostEdit svr = new svrweldcodepostEdit();
                        DataTable sdt = new DataTable();

                        sdt = svr.UpdatPost(data, vtype);

                        String xml;
                        
                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                /// <summary>
                /// 更新合并后焊缝的WPS;
                /// 6030901
                /// 
                /// </summary>
                case 6030901:
                    {
                        DataTable data = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);
                        //int vtype = Convert.ToInt32(cmd.StringValue);
                        svrClassMergeWeld svr = new svrClassMergeWeld();
                        DataTable sdt = new DataTable();

                        sdt = svr.UpdateMargedweldwps(data);

                        String xml;

                        if (sdt.Rows.Count == 0)
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(sdt);
                        }
                        else
                        {
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(sdt);

                        }
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                case 6032201://1012;//通过查询条件得到WPS数据
                    {
                        panasonicDevices cls = new panasonicDevices();
                        DataTable filter = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);

                        DataTable empbd = cls.GetDrivesChannelInfos();
                        empbd.TableName = "wpsrule";

                        rst.RowsCount = empbd.Rows.Count;
                        String xml;
                        if (rst.RowsCount == 0)
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(empbd);
                        else
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(empbd);
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                case 6033101://1012;//通过查询条件得到WPS数据
                    {
                        OTCDevices cls = new OTCDevices();
                        DataTable filter = clsConvertXMLDataTable.ConvertXMLToDataTable(cmd.weldDataTable);

                        DataTable empbd = cls.GetDrivesChannelInfos();
                        empbd.TableName = "wpsrule";

                        rst.RowsCount = empbd.Rows.Count;
                        String xml;
                        if (rst.RowsCount == 0)
                            xml = clsConvertXMLDataTable.ConvertDataTableToSchema(empbd);
                        else
                            xml = clsConvertXMLDataTable.ConvertDataTableToXML(empbd);
                        rst.BoolValue = true;
                        rst.weldDataTable = xml;
                        break;
                    }
                case 9001://开启定时器
                    {
                        //svrTimer.Start();
                        
                        break;
                    }
                case 9002://关闭定时器
                    {
                        //svrTimer.Stop();
                        ///都会接受对方
                        break;
                    }
                default:
                        break;

                }
            //throw new NotImplementedException();
            return rst;
        }
        /// <summary>
        /// 将xml转DataTable
        /// </summary>
        /// <param name="xmlData"></param>
        /// <returns></returns>
        private DataTable ConvertXMLToDataTable(string xmlData)
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
        private string ConvertDataTableToXML(DataTable xmlDT)
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
