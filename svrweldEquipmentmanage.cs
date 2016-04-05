using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections;
namespace JN_WELD_Service
{
    /// <summary>
    /// 焊机管理处理
    /// </summary>
    class svrweldEquipmentmanage:_clsdb
    {
        /// <summary>
        /// 获取焊机管理的基本参数（字典）集合
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public DataTable getweldEquipParams(DataTable vparams)
        {
            DataTable rdt;
            int type = 0;
            if (vparams.Rows.Count == 0)
                type = 0;
            else
            {
                type = Convert.ToInt32(vparams.Rows[0][0]);
            }
            String selSQL = "";
            switch (type)
            {
                case 0:
                    //焊机生产厂商
                    selSQL = "select FID,FName from t_Dictionary where FTypeID=2 ";
                    break;
                case 1:
                    //获取班组
                    //selSQL="select t1.FID,t2.FDepartName+'-'+t1.FDepartName as FDepartName from t_Department as T1 inner join ";
                    selSQL = "select t1.FID,t1.FDepartName as FDepartName ,T1.IsWeld from t_Department as T1 inner join ";

                    selSQL+=" (select FID,FDepartName from t_Department where Flevel=1) as t2 ";
                    selSQL += " on T1.FParentID=t2.FID order by FDepartName";
                    break;
           
                case 2:
                    //获取焊机状态
                    selSQL = "select FID,FName from t_Dictionary where FTypeID=3";
                    break;
                default:
                    
                    selSQL = "select FID,FName from t_Dictionary where FTypeID=2 ";
                    break;

            }
            rdt = _sqldbhelper.ExecuteDataTable(selSQL);
            return rdt;
        }
        /// <summary>
        /// 查询被管理焊机的所有信息
        /// </summary>
        /// <returns></returns>
        public DataTable getweldEquipmentInfos(DataTable fdt)
        {
            DataTable rdt;
            String selSQL = "select T1.*,T2.FName as FWeldManuName , T3.FName as FStateName, T4.FDepartName as FDepartName from t_weldEquipment as T1";
                   selSQL+=" inner join t_Dictionary as T2 on T2.FID=T1.FweldManufacturerID inner join t_Dictionary as T3 on T3.FID=t1.FStateID ";
                   selSQL+=" inner join ( select tt1.FID,tt2.FDepartName+'-'+tt1.FDepartName as FDepartName from t_Department as TT1 inner join ";
                   selSQL+=" (select FID,FDepartName from t_Department where Flevel=1) as tt2 on TT1.FParentID=tt2.FID ) as T4 on T4.FID=T1.FDepartID";
            if (fdt.Rows.Count == 0)
            {

            }
            else
            {
                selSQL += " where FweldEquipmentID='" + fdt.Rows[0][0].ToString() + "'"; 
            }
            rdt = _sqldbhelper.ExecuteDataTable(selSQL);
            return rdt;
        }
        /// <summary>
        /// 提交数据到数据库
        /// </summary>
        /// <param name="data">FDepartName,FweldEquipmentID,FweldManufacturerID,FStateID,FDepartID,FEquipName，FID,FDEL</param>
        /// <returns></returns>
        public DataTable UpdateweldEquipmentInfo(DataTable data)
        {
            //[FID] [bigint] IDENTITY(1,1) NOT NULL,
	        //[FDepartName] [nvarchar](50) NOT NULL,
	        //[FweldEquipmentID] [nvarchar](50) NOT NULL,
	        //[FweldManufacturerID] [bigint] NOT NULL,
	        //[FStateID] [bigint] NULL,
	        //[FDepartID] [bigint] NULL,
	        //[FEquipName] [nvarchar](100) NULL,
            String upSQL = "";
            String delSQL = "";
            String insertSQL = "";
            String strField = "FDepartName,FweldEquipmentID,FweldManufacturerID,FStateID,FDepartID,FEquipName";
            upSQL = "update t_weldEquipment set FDepartName=@FDepartName ,FweldEquipmentID=@FweldEquipmentID,FweldManufacturerID=@FweldManufacturerID,";
            upSQL += " FStateID=@FStateID,FEquipName=@FEquipName where FID=@FID";
            insertSQL = "insert into t_weldEquipment (FDepartName,FweldEquipmentID,FweldManufacturerID,FStateID,FDepartID,FEquipName) ";
            insertSQL += " values(@FDepartName,@FweldEquipmentID,@FweldManufacturerID,@FStateID,@FDepartID,@FEquipName)";
            delSQL = "delete from t_weldEquipment where FID=@FID";
            ArrayList upparams = new ArrayList();
            ArrayList insertparams = new ArrayList();
            ArrayList delparams = new ArrayList();
            //准备参数;
            SqlParameter par = new SqlParameter();
            par.ParameterName = "FDepartName";
            par.SqlDbType = SqlDbType.NVarChar;
            par.Value = data.Rows[0]["FDepartName"].ToString();
            upparams.Add(par);
            insertparams.Add(par);
            par = new SqlParameter();
            par.ParameterName = "FweldEquipmentID";
            par.SqlDbType = SqlDbType.NVarChar;
            par.Value = data.Rows[0]["FweldEquipmentID"].ToString();
            upparams.Add(par);
            insertparams.Add(par);
            par = new SqlParameter();
            par.ParameterName = "FweldManufacturerID";
            par.SqlDbType = SqlDbType.BigInt;
            par.Value = Convert.ToInt64(data.Rows[0]["FweldManufacturerID"]);
            upparams.Add(par);
            insertparams.Add(par);
            par = new SqlParameter();
            par.ParameterName = "FStateID";
            par.SqlDbType = SqlDbType.BigInt;
            par.Value = Convert.ToInt64(data.Rows[0]["FStateID"]);
            upparams.Add(par);
            insertparams.Add(par);
            par = new SqlParameter();
            par.ParameterName = "FDepartID";
            par.SqlDbType = SqlDbType.BigInt;
            par.Value = Convert.ToInt64(data.Rows[0]["FDepartID"]);
            upparams.Add(par);
            insertparams.Add(par);
            par = new SqlParameter();
            par.ParameterName = "FEquipName";
            par.SqlDbType = SqlDbType.NVarChar;
            par.Value = data.Rows[0]["FEquipName"].ToString();
            upparams.Add(par);
            insertparams.Add(par);
            DataTable rdt;

            String upsql = "select * from t_weldEquipment";

            if (Convert.ToInt64(Convert.IsDBNull(data.Rows[0]["FID"])?0:data.Rows[0]["FID"]) == 0)
            {
                //插入
               // int rs = _sqldbhelper.ExecuteNonQuery(insertSQL, CommandType.Text, insertparams);
                rdt=_sqldbhelper.UpdateByDataTable(upsql, data, "FID",1);
            }
            else
            {
                if (data.Columns.IndexOf("FDEL")>-1 && Convert.ToInt32(data.Rows[0]["FDEL"])==1)
                {
                    //删除
                    SqlParameter delpa = new SqlParameter();
                    delpa.ParameterName = "FID";
                    delpa.SqlDbType = SqlDbType.BigInt;
                    delpa.SqlValue = Convert.ToInt64(data.Rows[0]["FID"]);
                    delparams.Add(delpa);

                    //int rs = _sqldbhelper.ExecuteNonQuery(delSQL,CommandType.Text, delparams);
                    rdt = _sqldbhelper.UpdateByDataTable(upsql, data, "FID", 2);
                }

                else
                {
                    SqlParameter delpa = new SqlParameter();
                    delpa.ParameterName = "FID";
                    delpa.SqlDbType = SqlDbType.BigInt;
                    delpa.SqlValue = Convert.ToInt64(data.Rows[0]["FID"]);
                    upparams.Add(delpa);

                    //int rs = _sqldbhelper.ExecuteNonQuery(upSQL, CommandType.Text, upparams);
                    rdt = _sqldbhelper.UpdateByDataTable(upsql, data, "FID", 0);
                }

            }
            DataTable rst = _sqldbhelper.excuNoqueryRetrun(true, "数据更新成功", 0);
            return rst;
        }
        
    }
}
