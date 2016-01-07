using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections;

namespace JN_WELD_Service
{
    /// <summary>
    /// 焊工编辑管理
    /// </summary>
    class svrWelderEdit:_clsdb
    {
        /// <summary>
        /// 获取焊工所在班组及其全称信息 5101501
        /// </summary>
        /// <returns>返回结果</returns>
        public DataTable getDepart()
        {
            String selSQL = "";
            selSQL += "select T1.FID,IsNull((Select FDepartName from t_Department as T2 where T2.FID=T1.FParentID),'')+T1.FDepartName as FDepartNa from t_Department as T1 ";
            selSQL+=" where T1.Flevel=2 ";
            DataTable dt = _sqldbhelper.ExecuteDataTable(selSQL);
            return dt;
        }
        /// <summary>
        /// 获取所有焊工信息 5101502
        /// </summary>
        /// <returns></returns>
        public DataTable getWelders()
        {
            String selSQL = "select * from t_Welder";
            DataTable dt = _sqldbhelper.ExecuteDataTable(selSQL);
            return dt;
            
        }
        /// <summary>
        /// 获取所有工程队信息 5101503
        /// </summary>
        /// <returns></returns>
        public DataTable getLibs()
        {
            String selSQL = "select FID,FName from t_Dictionary where FTypeID=1";
            DataTable dt = _sqldbhelper.ExecuteDataTable(selSQL);
            return dt;

        }
        /// <summary>
        /// 获取焊工焊接等级数据 5101504
        /// </summary>
        /// <returns></returns>
        public DataTable getWelderClass(DataTable fdt)
        {
             String selSQL;
            if (fdt == null || fdt.Rows.Count == 0)
            {
                selSQL = "select FID,FWELDERID,FWELDLEVENID from t_WelderMod";
            }
            else
            {
                selSQL = "select FID,FWELDERID,FWELDLEVENID from t_WelderMod where FWelderID=" + fdt.Rows[0][0].ToString();
            }
            //ArrayList sqlparams = new ArrayList();
            //SqlParameter pa = new SqlParameter(); pa.ParameterName = ""; pa.SqlDbType = SqlDbType.BigInt; pa.SqlValue = fdt.Rows[0][0]; sqlparams.Add(pa);
            DataTable dt = _sqldbhelper.ExecuteDataTable(selSQL);
            return dt;

        }   
        /// <summary>
        /// 获取焊接等级信息 5101505
        /// </summary>
        /// <returns></returns>
        public DataTable getWeldCLass()
        {
            String selSQL = "select FID,'['+WeldingProcessName+']'+'-'+'['+WeldingProcessAb+']'+'-'+'['+WeldingType+']'+'-'+'['+FWorkDisk+']'+'-'+'['+WeldingClass+']' as FName  from t_WeldMods";
            DataTable dt = _sqldbhelper.ExecuteDataTable(selSQL);
            return dt;

        }
        /// <summary>
        /// 更新焊工基础数据 5101506
        /// </summary>
        /// <returns></returns>
        public DataTable Updatewelders(DataTable data,int vtype)
        {
            String selSQL = "select * from t_Welder";
           // DataSet ds = _sqldbhelper.ExecuteDataSet(selSQL);
           // DataTable dt = clsConvertXMLDataTable.ConvertXMLtoDataSet(xml, ds);
            DataTable dt = _sqldbhelper.UpdateByDataTable(selSQL, data, "FID", vtype);
            return dt;
        }
        /// <summary>
        /// 更新焊工焊接等级信息 5101507
        /// </summary>
        /// <returns></returns>
        public DataTable Updatewelders_WeldClass(DataTable data ,int vtype)
        {
            String selSQL = "select FID,FWELDERID,FWELDLEVENID from t_WelderMod";
            //DataSet ds = _sqldbhelper.ExecuteDataSet(selSQL);
            DataTable dt ;

            dt = _sqldbhelper.UpdateByDataTable(selSQL, data, "FID",vtype);
            return dt;
        }
        /// <summary>
        /// 获取焊接等级信息库内容 5101508
        /// </summary>
        /// <returns>焊接等级库</returns>
        public DataTable getweldModeTable()
        {
            String selSQL = "select FID,WeldingProcessName,WeldingProcessAb,WeldingType,FWorkDisk,WeldingClass from t_WeldMods ";
            DataTable dt = _sqldbhelper.ExecuteDataTable(selSQL);
            return dt;
        }
        /// <summary>
        /// 更新焊接等级信息库内容 5101509
        /// </summary>
        /// <param name="data"></param>
        /// <param name="vtype"></param>
        /// <returns></returns>
        public DataTable UpdateweldModeTable(DataTable data,int vtype)
        {
            String upSQL = "select * from t_WeldMods";
            DataTable dt = _sqldbhelper.UpdateByDataTable(upSQL, data, "FID", vtype);
            return  dt;
        }
        /// <summary>
        /// 获取焊缝信息 5101510
        /// </summary>
        /// <param name="data"></param>
        /// <param name="vtype"></param>
        /// <returns></returns>
        public DataTable getWeldTable()
        {
            String selSQL = "select * from t_WELD";
            DataTable dt = _sqldbhelper.ExecuteDataTable(selSQL);
            return dt;
        }
        /// <summary>
        /// 更新焊缝信息 5101511
        /// </summary>
        /// <param name="data"></param>
        /// <param name="vtype"></param>
        /// <returns></returns>
        public DataTable UpdateWeldTable(DataTable data,int vtype)
        {


            String selSQL = "select * from t_WELD";
            DataTable dt = _sqldbhelper.UpdateByDataTable(selSQL,data,"FID",vtype);
            return dt;
        }
        //select FID,FName from t_Dictionary where FTypeID=4 获取船型
        /// <summary>
        /// 获取船型信息 5101512
        /// </summary>
        /// <param name="data"></param>
        /// <param name="vtype"></param>
        /// <returns></returns>
        public DataTable getSHIP_MOD()
        {
            String selSQL = "select FID,FName from t_Dictionary where FTypeID=4";
            DataTable dt = _sqldbhelper.ExecuteDataTable(selSQL);
            return dt;
        }
        /// <summary>
        /// 更新船型 5101513
        /// </summary>
        /// <param name="data"></param>
        /// <param name="vtype"></param>
        /// <returns></returns>
        public DataTable UpdateSHIP_MOD(DataTable data, int vtype)
        {
            String selSQL = "select FID,FName,FTypeID from t_Dictionary where FTypeID=4";
            DataTable dt = _sqldbhelper.UpdateByDataTable(selSQL, data, "FID", vtype);
            return dt;
        }
    }
}
