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
    /// 焊机监控服务器端处理主对象
    /// </summary>
    class svrWeldEquipmentReal:_clsdb
    {
        /// <summary>
        /// 获取焊机设备的基本信息，焊机位置，焊机编号，焊机部门
        /// </summary>
        /// <returns></returns>
        public DataTable getWeldEquipments()
        {
            DataTable dt;
            String selSQL= "";//= "select t1.* ,t2.FName,T3.FDepartName from t_weldEquipment as T1 ";
                //selSQL+="inner join t_Dictionary as T2 on t2.FTypeID=2 and T2.Fvalue=T1.FweldManufacturerID ";
                //selSQL+=" inner join t_Department as T3 on t3.FID=t1.FDepartID";
            selSQL = "select T1.*,T2.FName as FWeldManuName , case when FStateID=0 then '正常' else '停用' end as  FStateName, T4.FDepartName as FTODepartName from t_weldEquipment as T1 ";
            selSQL+=" inner join t_Dictionary as T2 on T2.FID=T1.FweldManufacturerID ";
            //selSQL+=" inner join t_Dictionary as T3 on T3.FID=t1.FStateID ";
            selSQL+="inner join (";
            selSQL+=" select tt1.FID,tt1.FDepartName as FDepartName from t_Department as TT1 inner join ";
            selSQL += " (select FID,FDepartName from t_Department where Flevel=1) as tt2 on TT1.FParentID=tt2.FID ) as T4 on T4.FID=T1.FDepartID";
            dt=_sqldbhelper.ExecuteDataTable(selSQL);


            return dt;
        }
        /// <summary>
        /// 获取焊机位置信息集合
        /// </summary>
        /// <returns></returns>
        public DataTable getWeldEquipmentPoint()
        {
            DataTable dt;
            String selSQL = "select distinct FDepartName from t_weldEquipment";
            dt = _sqldbhelper.ExecuteDataTable(selSQL);
            return dt;
        }
        /// <summary>
        /// 5092602
        /// </summary>
        /// <param name="fdt"></param>
        /// <returns></returns>
        public DataTable getWledEquipmentRealAndTask(DataTable fdt)
        {
            DataTable weldequids = null;
            if (fdt == null)
                weldequids = svrTimer.getweldEquipmentinfos();
            else
            {
                if (fdt.Rows.Count > 0)
                {
                    String nom = fdt.Rows[0]["nom"].ToString();
                    weldequids = svrTimer.getweldEquipmentinfo(nom);
                }
                else
                {
                    DataTable dt = svrTimer.getweldEquipmentinfos();
                    throw new Exception("参数传递错误");
                }
            }

            DataColumn col=new DataColumn("FName",typeof(String));
            weldequids.Columns.Add(col);
            col = new DataColumn("FSTARTTIME", typeof(String));
            weldequids.Columns.Add(col);
            col = new DataColumn("FENDTIME", typeof(String));
            weldequids.Columns.Add(col);

            String selSQL = "select top 20 t1.FSTARTTIME,t1.FENDTIME,T2.Fnum,t2.FName,t2.FweldDriverID ,t2.PART1_NAME2,t2.PART2_NAME2 ,t2.FDepartName,t2.WELD_T_LEN from View_TaskDoingrec_left as T1 ";
            selSQL += " inner join View_Task_Welder_ALl as T2 on t1.FTaskID=t2.FiD ";
            selSQL += " where  T2.FweldDriverID=@nom";
            selSQL += " order by t1.FSTARTTIME desc";
            
            //get Fname
            for (int i = 0; i < weldequids.Rows.Count; i++)
            {
                ArrayList selparas = new ArrayList();
                SqlParameter pa = new SqlParameter();
                pa.ParameterName = "@nom";
                pa.SqlDbType = SqlDbType.NVarChar;
                pa.SqlValue = weldequids.Rows[i]["nom"].ToString();
                selparas.Add(pa);
                DataTable vdt = _sqldbhelper.ExecuteDataTable(selSQL, selparas);
                if (vdt.Rows.Count > 0)
                {
                    weldequids.Rows[i]["FName"] = vdt.Rows[0]["FName"];
                    weldequids.Rows[i]["FSTARTTIME"] = vdt.Rows[0]["FSTARTTIME"];
                    weldequids.Rows[i]["FENDTIME"] = vdt.Rows[0]["FENDTIME"];
                }
            }
            return weldequids;

        }

        /// <summary>
        /// 通过给定的焊机编号，查询得到焊机的基本信息：预置电流，预置电压，状态
        /// </summary>
        /// <param name="fdt">若没有参数则获取全部，否则只获取一个焊机的基本信息</param>
        /// <returns></returns>
        public DataTable getWeldEquipmentBaseInfo(DataTable fdt)
        {
            if (fdt==null)
                return svrTimer.getweldEquipmentinfos(); 
            if (fdt.Rows.Count > 0)
            {
                String nom = fdt.Rows[0]["nom"].ToString();
                DataTable dt = svrTimer.getweldEquipmentinfo(nom);
                return dt;
            }
            else
            {
                DataTable dt = svrTimer.getweldEquipmentinfos();
                throw new Exception("参数传递错误");
            }
            
        }
        /// <summary>
        /// 通过焊机的nom，获取使用焊机的最前面10位焊工任务信息
        /// 
        /// </summary>
        /// <param name="fdt"></param>
        /// <returns></returns>
        public DataTable getWelderTaskbyWeldEquipID(DataTable fdt)
        {
            //where T2.FweldDriverID=3219

            if (fdt.Rows.Count > 0)
            {
                String weldid = fdt.Rows[0][0].ToString();
                DataTable dt;
                String vS;
                String vE;
                if (fdt.Columns.IndexOf("SFSTARTTIME") >= 0)
                {
                    vS=fdt.Rows[0]["SFSTARTTIME"].ToString();
                }
                else
                {
                    vS = DateTime.Now.ToLongDateString();
                }
                if (fdt.Columns.IndexOf("SFENDTIME")>=0)
                {
                    vE=fdt.Rows[0]["SFENDTIME"].ToString();
                }
                else
                {
                    vE = DateTime.Now.ToLongDateString();
                }
                
               

                String selSQL = "select top 20 t1.FSTARTTIME,t1.FENDTIME,T2.Fnum,t2.FName,t2.FweldDriverID ,t2.PART1_NAME2,t2.PART2_NAME2 ,t2.FDepartName,t2.WELD_T_LEN from View_TaskDoingrec_left as T1 ";
                if (fdt.Columns.IndexOf("SFSTARTTIME") > -1)
                {
                    selSQL = "select  t1.FSTARTTIME,t1.FENDTIME,T2.Fnum,t2.FName,t2.FweldDriverID ,t2.PART1_NAME2,t2.PART2_NAME2 ,t2.FDepartName,t2.WELD_T_LEN from View_TaskDoingrec_left as T1 ";
                }
                selSQL+=" inner join View_Task_Welder_ALl as T2 on t1.FTaskID=t2.FiD ";
                       
                selSQL += " where  T2.FweldDriverID=" + weldid;

                       if (fdt.Columns.IndexOf("SFSTARTTIME") > -1)
                       {
                           selSQL += " and T1.FSTARTTIME>='" + vS + "' and T1.FENDTIME<='" + vE + "'";
                       }

                       
                       selSQL+=" order by t1.FSTARTTIME desc";
                dt = _sqldbhelper.ExecuteDataTable(selSQL);
                return dt;
            }
            else
            {
                throw new Exception("参数传递错误");

            }
        }
        /// <summary>
        /// 获取指定焊机的历史数据，按照任务进行查询5092601
        /// </summary>
        /// <param name="fdt">nom，STARTTIME，ENDTIME</param>
        /// <returns></returns>
        public DataTable getweldEquipmentHistory(DataTable fdt)
        {
            DataRow row = fdt.Rows[0];
            ArrayList selparams = new ArrayList();
            SqlParameter pa = new SqlParameter();
            pa.ParameterName = "@FSTARTTIME";
            pa.SqlDbType = SqlDbType.DateTime;
            pa.SqlValue = row["FSTARTTIME"];
            selparams.Add(pa);
            pa = new SqlParameter();
            pa.ParameterName = "@FENDTIME";
            pa.SqlDbType = SqlDbType.DateTime;
            pa.SqlValue = row["FENDTIME"];
            selparams.Add(pa);
            pa = new SqlParameter();
            pa.ParameterName = "@nom";
            pa.SqlDbType = SqlDbType.NVarChar;
            pa.SqlValue = row["FweldDriverID"];
            selparams.Add(pa);
            
            String selSQL = "select * from t_panasonicDriRecord where (nowtime between @FSTARTTIME and @FENDTIME) and nom=@nom";
            DataTable rst = _sqldbhelper.ExecuteDataTable(selSQL,selparams);
            return rst;
        }
    }
}
