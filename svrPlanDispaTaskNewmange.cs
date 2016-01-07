using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace JN_WELD_Service
{
    /// <summary>
    /// 工序计划、派工单、任务单 新 管理后台处理
    /// </summary>
    class svrPlanDispaTaskNewmange:_clsdb
    {
        /// <summary>
        /// 获取工序计划表头 
        /// 6010101
        /// </summary>
        /// <returns></returns>
        public DataTable getPlanHead()
        {
            String selSQL = "select * from t_ProcessPlanHeader";
            DataTable dt = _sqldbhelper.ExecuteDataTable(selSQL);
            return dt;
        }
        /// <summary>
        /// 获取派工单表头 
        /// 6010104
        /// </summary>
        /// <returns></returns>
        public DataTable getDispatchHead()
        {
            String selSQL = "select FID,FDispatchName,FDispatchNum,FDispatchSTARTTIME,FDispatchENDTIME from t_DispatchingHeader";
            DataTable dt = _sqldbhelper.ExecuteDataTable(selSQL);
            return dt;
        }
        /// <summary>
        /// 获取工序计划表体--索引
        /// 6010102
        /// </summary>
        /// <param name="fdata">工序计划单FID</param>
        /// <returns></returns>
        public DataTable getPanBodyIndex(DataTable fdata)
        {
            String selSQL = "";
            long ProjectFID=0;
            selSQL += " select T.* ,T1.FDepartName from ( ";
            selSQL += " select COUNT(FWELDID)  as FWeldCount ,FDoDepartID,FProjectHeadID from t_ProcessPlanBody ";
            selSQL += " where FProjectHeadID={0} ";
            selSQL += "  group by  FDoDepartID,FProjectHeadID ";
            selSQL += " ) as T ";
            selSQL += " inner join t_Department as T1 on T1.FID=T.FDoDepartID ";
            if (fdata.Rows.Count == 0)
            {
                ProjectFID = 0;
            }
            else
            {
                ProjectFID =Convert.ToInt64( fdata.Rows[0][0]);
            }
            selSQL = String.Format(selSQL, ProjectFID);
            DataTable dt = _sqldbhelper.ExecuteDataTable(selSQL);
            return dt; 
        }
        /// <summary>
        /// 获取派工单表体--索引
        /// 6010105
        /// </summary>
        /// <param name="fdata">工序计划单FID</param>
        /// <returns></returns>
        public DataTable getDispatchBodyIndex(DataTable fdata)
        {
            String selSQL = "";
            long DispatchFID = 0;
            selSQL += "Select T.*,T1.FDepartName as FOPDEPARTNAME , T2.FDepartName as FPARENTDEPARTNAME from ( ";
            selSQL += "select FDispatchHeadID ,FOPDEPARTID,FParentDepartID , COUNT(FWELDID) as FweldCount from t_DispatchingBody ";
            selSQL += "where FDispatchHeadID={0}";
            selSQL += "group by FDispatchHeadID ,FOPDEPARTID,FParentDepartID  ";
            selSQL += ") as T ";
            selSQL += "inner join t_Department as T1 on T.FOPDEPARTID=T1.FID ";
            selSQL += "inner join t_Department as T2 on T.FParentDepartID=T2.FID ";
            if (fdata.Rows.Count == 0)
            {
                DispatchFID = 0;
            }
            else
            {
                DispatchFID = Convert.ToInt64(fdata.Rows[0][0]);
            }
            selSQL = String.Format(selSQL, DispatchFID);
            DataTable dt = _sqldbhelper.ExecuteDataTable(selSQL);
            return dt;
        }
        /// <summary>
        /// 获取工序计划表体中部门所分配的焊缝信息；
        /// 6010103
        /// </summary>
        /// <param name="fdata">ProjectID ， FDoDepartID</param>
        /// <returns></returns>
        public DataTable getPanBodyList(DataTable fdata)
        {
            String selSQL = "";
            selSQL += " select T.FWELDID,T1.SHIP_NO,T1.BUFF1,T1.AS3,T1.TREE_NAME,T1.RuleNum, T1.PART1_NAME2+'-'+T1.PART2_NAME2+'-'+T1.WELD_NO as FWeldName from t_ProcessPlanBody as T ";
            selSQL += " inner join t_WELD as T1 on T.FWELDID=T1.FID";
            selSQL += " where T.FProjectHeadID={0} and T.FDoDepartID={1}";
            selSQL += " --left join t_wps_RULE as T2 on T2.RuleNum=T1.RuleNum";
            long vprojectid = 0;
            long vdodepartid = 0;
            if (fdata.Rows.Count > 0)
            {
                vprojectid = Convert.ToInt64(fdata.Rows[0][0]);
                vdodepartid = Convert.ToInt64(fdata.Rows[0][1]);
            }
            selSQL = String.Format(selSQL, vprojectid, vdodepartid);
            DataTable dt = _sqldbhelper.ExecuteDataTable(selSQL);
            return dt;
        }
        /// <summary>
        /// 获取派工单表体中部门所分配的焊缝信息；
        /// 6010106
        /// </summary>
        /// <param name="fdata">DispatchID ， FDoDepartID</param>
        /// <returns></returns>
        public DataTable getDispatchBodyList(DataTable fdata)
        {
            String selSQL = "";
            selSQL += " select T.FWELDID,T1.SHIP_NO,T1.BUFF1,T1.AS3,T1.TREE_NAME,T1.RuleNum, T1.PART1_NAME2+'-'+T1.PART2_NAME2+'-'+T1.WELD_NO as FWeldName from t_DispatchingBody as T ";
            selSQL += "inner join t_WELD as T1 on T.FWELDID=T1.FID ";
            selSQL += "where T.FDispatchHeadID={0} and T.FOPDEPARTID={1} ";
            long vdispatchid = 0;
            long vdodepartid = 0;
            if (fdata.Rows.Count > 0)
            {
                vdispatchid = Convert.ToInt64(fdata.Rows[0][0]);
                vdodepartid = Convert.ToInt64(fdata.Rows[0][1]);
            }
            selSQL = String.Format(selSQL, vdispatchid, vdodepartid);
            DataTable dt = _sqldbhelper.ExecuteDataTable(selSQL);
            return dt;
        }

    }
}
