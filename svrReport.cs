using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace JN_WELD_Service
{
    /// <summary>
    /// 报表数据处理
    /// </summary>
    class svrReport:_clsdb
    {
        /// <summary>
        /// 焊机区间报表 5100501
        /// </summary>
        /// <param name="fdt">开始时间 FSTARTTIME，结束时间 FENDTIME，焊机编号 nom</param>
        /// <returns></returns>
        public DataTable getWeldSectionRp(DataTable fdt)
        {
            String selSQL = "";
            selSQL = "select FSTARTTIME,FENDTIME,FweldDriverID, Fnum,FTaskID,FName,";
            selSQL+=" avg(va) as va ,avg(vaf) as vaf , avg(vai) as vai ,avg(vv) as vv, avg(vvf) as vvf,"; 
            selSQL+="avg(vvi) as vvi,avg(wv) as wv,SUM(Isnull(rpm,0)*1.5) as sum_rpm,sum(ISNULL(rpm,0)*1) as sum_rp ,SUM(wv*wa*1.2) as sum_eng,SUM(gasflux) sum_gas,";
                    selSQL+="AVG(wa) as wa,SUM(good) as good,SUM(nor) as nor ,SUM(err) as err,SUM(surpass) as surpass,MAX(weldtime) as weldtime ,MAX(worktime) as worktime";
                    selSQL += " from";
                    selSQL+="(";
                    selSQL+="select T.FSTARTTIME,T.FENDTIME,FTaskID,T1.FweldDriverID, T1.FWelderID,T1.FDepartName,T1.Fnum,T1.FName,T1.PART1_NAME2,T1.PART2_NAME2,";
                    selSQL+="case when wa between VA-20 and va+20 then 1 else 0 end as good,";
                    selSQL+="case when (wa between VA-40 and va-20) OR (wa between VA+20 and va+40) then 1 else 0 end as nor,";
                    selSQL+="case when wa<va-40 OR (wa>va+40) then 1 else 0 end as err,";
                    selSQL+="case when wa>va then 1 else 0 end as surpass ,";
                   selSQL+=" T2.* from View_TaskDoingrec_1 as T";
                   selSQL+=" inner join View_Task_Welder_Index as T1 on t1.FID=T.FTaskID";
                   selSQL+=" inner join t_weldEquipment as T3 on T3.FweldEquipmentID =T1.FweldDriverID";
                   selSQL+=" inner join t_PanasonicDriRecord as T2 on T2.nowtime between T.FSTARTTIME and T.FENDTIME and T2.nom=T1.FweldDriverID";
                   selSQL+=" where T1.FweldDriverID=@nom and t.FSTARTTIME>@FSTARTTIME and t.FENDTIME<@FENDTIME";
                   selSQL+=" ) as Tb  Group by FSTARTTIME,FENDTIME,FweldDriverID, Fnum,FTaskID,FName";
            //准备参数
                   if (fdt.Columns.IndexOf("FSTARTTIME") < 0 || fdt.Columns.IndexOf("FENDTIME") < 0 || fdt.Columns.IndexOf("nom") < 0)
                   {
                       return _sqldbhelper.excuNoqueryRetrun(false, "缺少参数", 0);
                   }
                   ArrayList sqlparams = new ArrayList();
                   SqlParameter pa;
                   pa = new SqlParameter(); pa.ParameterName = "@FSTARTTIME"; pa.SqlDbType = SqlDbType.DateTime; pa.SqlValue = fdt.Rows[0]["FSTARTTIME"]; sqlparams.Add(pa);
                   pa = new SqlParameter(); pa.ParameterName = "@FENDTIME"; pa.SqlDbType = SqlDbType.DateTime; pa.SqlValue = fdt.Rows[0]["FENDTIME"]; sqlparams.Add(pa);
                   pa = new SqlParameter(); pa.ParameterName = "@nom"; pa.SqlDbType = SqlDbType.NVarChar; pa.Size = 50; pa.SqlValue = fdt.Rows[0]["nom"]; sqlparams.Add(pa);
                   DataTable dt = _sqldbhelper.ExecuteDataTable(selSQL, sqlparams);
                   return dt;

        }
        /// <summary>
        /// 日/月/自定义报表--焊机 5100502
        /// </summary>
        /// <param name="fdt">开始时间 FSTARTTIME,截止时间 FENDTIME,焊机位置 FDepartName,焊机编号 nom</param>
        /// <returns></returns>
        public DataTable getweldReport_weld(DataTable fdt)
        {
            String selSQL = "";
            //selSQL+="select nom,starttime,wp,mt,wd,FDepartName,FEquipname, SUM(wv*wa*1.2) as sum_eng, SUM(gasflux) sum_gas ,SUM(Isnull(rpm,0)*1.5) as sum_rpm, MAX(weldtime) as weldtime ,MAX(worktime) as worktime ";
            selSQL += "select nom as FweldDriverID,starttime as FSTARTTIME ,MAX(endtime) as FENDTIME,wp,mt,wd,FDepartName,FEquipname, SUM(wv*wa*1.2) as sum_eng, SUM(gasflux) sum_gas ,SUM(Isnull(rpm,0)*1.5) as sum_rpm, MAX(weldtime) as weldtime ,MAX(worktime) as worktime ";
            selSQL+=" from t_PanasonicDriRecord ";
            selSQL+=" inner join t_weldEquipment as T3 on T3.FweldEquipmentID =t_PanasonicDriRecord.nom ";
            selSQL+=" where 1=1 and ";
            if ((Convert.IsDBNull(fdt.Rows[0]["nom"])?"":fdt.Rows[0]["nom"].ToString()).Length>0 )
            selSQL+="nom=@nom and ";
            if ((Convert.IsDBNull(fdt.Rows[0]["FDepartName"]) ? "" : fdt.Rows[0]["FDepartName"].ToString()).Length > 0) //Convert.IsDBNull(fdt.Rows[0]["FDepartName"]) == false || fdt.Rows[0]["FDepartName"].ToString().Length>0)
                selSQL+=" FDepartName=@FDepartName and  ";
            selSQL+=" starttime between @FSTARTTIME and @FENDTIME ";
            selSQL += " group by FDepartName,FEquipname,nom ,starttime,wp,mt,wd ";
            //准备参数
            ArrayList sqlparams = new ArrayList();
            SqlParameter pa;
            pa = new SqlParameter(); pa.ParameterName = "FSTARTTIME"; pa.SqlDbType = SqlDbType.NVarChar; pa.Size = 50; pa.SqlValue = fdt.Rows[0]["FSTARTTIME"]; sqlparams.Add(pa);
            pa = new SqlParameter(); pa.ParameterName = "FENDTIME"; pa.SqlDbType = SqlDbType.NVarChar; pa.Size = 50; pa.SqlValue = fdt.Rows[0]["FENDTIME"]; sqlparams.Add(pa);
            pa = new SqlParameter(); pa.ParameterName = "nom"; pa.SqlDbType = SqlDbType.NVarChar; pa.Size = 50; pa.SqlValue = fdt.Rows[0]["nom"]; sqlparams.Add(pa);
            pa = new SqlParameter(); pa.ParameterName = "FDepartName"; pa.SqlDbType = SqlDbType.NVarChar; pa.Size = 50; pa.SqlValue = fdt.Rows[0]["FDepartName"]; sqlparams.Add(pa);

            DataTable dt = _sqldbhelper.ExecuteDataTable(selSQL, sqlparams);
            return dt;

        }
        /// <summary>
        /// 日/月/自定义报表--焊工 5100503
        /// </summary>
        /// <param name="fdt">焊工名FName,开始时间FSTARTTIME,截止时间FENDTIME</param>
        /// <returns></returns>
        public DataTable getWeldReport_Welder(DataTable fdt)
        {
            String selSQL = "";
            selSQL += " select nom as FweldDriverID,starttime as FSTARTTIME ,MAX(endtime) as FENDTIME,wp,mt,wd,Fname,Fnum,FdepartName,weldPointName,";
            selSQL+=" SUM(wv*wa*1.2) as sum_eng, SUM(gasflux) sum_gas ,SUM(Isnull(rpm,0)*1.5) as sum_rpm, MAX(weldtime) as weldtime ,MAX(worktime) as worktime";
            selSQL+=" from ";
            selSQL+=" ( ";
            selSQL += " select T.FSTARTTIME,T.FENDTIME,FTaskID,T1.FweldDriverID, T1.FWelderID,T1.FDepartName,T1.Fnum,T1.FName,T1.PART1_NAME2,T1.PART2_NAME2,T3.FDepartName as weldPointName,";
            selSQL+=" case when wa between VA-20 and va+20 then 1 else 0 end as good,";
            selSQL+=" case when (wa between VA-40 and va-20) OR (wa between VA+20 and va+40) then 1 else 0 end as nor,";
            selSQL+=" case when wa<va-40 OR (wa>va+40) then 1 else 0 end as err,";
            selSQL+=" case when wa>va then 1 else 0 end as surpass ,";
            selSQL+=" T2.* from View_TaskDoingrec_1 as T";
            selSQL+=" inner join View_Task_Welder_Index as T1 on t1.FID=T.FTaskID";
            selSQL+=" inner join t_weldEquipment as T3 on T3.FweldEquipmentID =T1.FweldDriverID";

            selSQL+=" inner join t_PanasonicDriRecord as T2 on T2.nowtime between T.FSTARTTIME and T.FENDTIME and T2.nom=T1.FweldDriverID";
            selSQL += " where 1=1 and ";
            if ((Convert.IsDBNull(fdt.Rows[0]["FName"]) ? "" : fdt.Rows[0]["FName"].ToString()).Length > 0)//Convert.IsDBNull(fdt.Rows[0]["FName"]) == false || fdt.Rows[0]["FName"].ToString().Length>0)
                selSQL+="FName=@FName  and ";
            selSQL += "starttime between @FSTARTTIME and @FENDTIME ";
            selSQL+=" ) as S";
            selSQL += " group by nom ,starttime,wp,mt,wd,Fname,Fnum,FdepartName,weldPointName";
            //准备参数
            ArrayList sqlparams = new ArrayList();
            SqlParameter pa;
            pa = new SqlParameter(); pa.ParameterName = "FSTARTTIME"; pa.SqlDbType = SqlDbType.NVarChar; pa.Size = 50; pa.SqlValue = fdt.Rows[0]["FSTARTTIME"]; sqlparams.Add(pa);
            pa = new SqlParameter(); pa.ParameterName = "FENDTIME"; pa.SqlDbType = SqlDbType.NVarChar; pa.Size = 50; pa.SqlValue = fdt.Rows[0]["FENDTIME"]; sqlparams.Add(pa);
            pa = new SqlParameter(); pa.ParameterName = "FName"; pa.SqlDbType = SqlDbType.NVarChar; pa.Size = 50; pa.SqlValue = fdt.Rows[0]["FName"]; sqlparams.Add(pa);

            DataTable dt = _sqldbhelper.ExecuteDataTable(selSQL, sqlparams);
            return dt;

        }

        /// <summary>
        /// 任务报表 5100504
        /// </summary>
        /// <param name="fdt">开始时间 FSTARTTIME，结束时间 FENDTIME</param>
        /// <returns></returns>
        public DataTable getTaskReport(DataTable fdt)
        {
            String selSQL = "";
            selSQL = "select FSTARTTIME,FENDTIME,FweldDriverID, FWelderID,FDepartName,Fnum,FTaskID,FName,";//channel
            selSQL += " avg(va) as va ,avg(vaf) as vaf , avg(vai) as vai ,avg(vv) as vv, avg(vvf) as vvf,";
            selSQL += "avg(vvi) as vvi,avg(wv) as wv,SUM(Isnull(rpm,0)*1.5) as sum_rpm,sum(ISNULL(rpm,0)*1) as sum_rp ,SUM(wv*wa*1.2) as sum_eng,SUM(gasflux) sum_gas,";
            selSQL += "AVG(wa) as wa,SUM(good) as good,SUM(nor) as nor ,SUM(err) as err,SUM(surpass) as surpass,MAX(weldtime) as weldtime ,MAX(worktime) as worktime";
            selSQL += " from";
            selSQL += "(";
            selSQL += "select T.FSTARTTIME,T.FENDTIME,FTaskID,T1.FweldDriverID, T1.FWelderID,T1.FDepartName,T1.Fnum,T1.FName,T1.PART1_NAME2,T1.PART2_NAME2,";
            selSQL += "case when wa between VA-20 and va+20 then 1 else 0 end as good,";
            selSQL += "case when (wa between VA-40 and va-20) OR (wa between VA+20 and va+40) then 1 else 0 end as nor,";
            selSQL += "case when wa<va-40 OR (wa>va+40) then 1 else 0 end as err,";
            selSQL += "case when wa>va then 1 else 0 end as surpass ,";
            selSQL += " T2.* from View_TaskDoingrec_1 as T";
            selSQL += " inner join View_Task_Welder_Index as T1 on t1.FID=T.FTaskID";
            selSQL += " inner join t_weldEquipment as T3 on T3.FweldEquipmentID =T1.FweldDriverID";
            selSQL += " inner join t_PanasonicDriRecord as T2 on T2.nowtime between T.FSTARTTIME and T.FENDTIME and T2.nom=T1.FweldDriverID";
            selSQL += " where  t.FSTARTTIME>@FSTARTTIME and t.FENDTIME<@FENDTIME";
            selSQL += " ) as Tb  Group by FSTARTTIME,FENDTIME,FweldDriverID, FWelderID,FDepartName,Fnum,FTaskID,Fname";//channel
            //准备参数
            if (fdt.Columns.IndexOf("FSTARTTIME") < 0 || fdt.Columns.IndexOf("FENDTIME") < 0 )
            {
                return _sqldbhelper.excuNoqueryRetrun(false, "缺少参数", 0);
            }
            ArrayList sqlparams = new ArrayList();
            SqlParameter pa;
            pa = new SqlParameter(); pa.ParameterName = "@FSTARTTIME"; pa.SqlDbType = SqlDbType.DateTime; pa.SqlValue = fdt.Rows[0]["FSTARTTIME"]; sqlparams.Add(pa);
            pa = new SqlParameter(); pa.ParameterName = "@FENDTIME"; pa.SqlDbType = SqlDbType.DateTime; pa.SqlValue = fdt.Rows[0]["FENDTIME"]; sqlparams.Add(pa);
            //pa = new SqlParameter(); pa.ParameterName = "@nom"; pa.SqlDbType = SqlDbType.NVarChar; pa.Size = 50; pa.SqlValue = fdt.Rows[0]["nom"]; sqlparams.Add(pa);
            DataTable dt = _sqldbhelper.ExecuteDataTable(selSQL, sqlparams);
            return dt;
        }
        /// <summary>
        /// 分别提取 0焊机位置集合，1焊机集合，2焊工集合 5100505
        /// </summary>
        /// <param name="fdt"></param>
        /// <returns></returns>
        public DataTable getReportBase(DataTable fdt)
        {
            int type = Convert.IsDBNull(fdt.Rows[0]["FType"]) ? 0 : Convert.ToInt32(fdt.Rows[0]["FType"]);
            String selSQL = "select distinct FDepartName from t_weldEquipment";
            switch (type)
            {
                case 0:
                    selSQL = "select distinct FDepartName from t_weldEquipment";
                    break;
                case 1:
                    selSQL = "select FID,FDepartName,FweldEquipmentID,FDepartID,FEquipName from t_weldEquipment";
                    break;
                case 2:
                    selSQL = "select FName,Fnum,Fdepart from t_Welder";
                    break;
                default:

                    break;
            }
            DataTable dt = _sqldbhelper.ExecuteDataTable(selSQL);
            return dt;
        }
    }
}
