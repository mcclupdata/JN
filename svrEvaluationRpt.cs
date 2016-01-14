using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace JN_WELD_Service
{
    /// <summary>
    /// 评估报表数据处理
    /// </summary>
    class svrEvaluationRpt:_clsdb
    {
        /// <summary>
        /// 以焊缝为索引，统计数据 15122201
        /// </summary>
        /// <param name="fdt">SHIP_NO,BUFF1,BLK_NO,AS3</param>
        /// <returns></returns>
        public DataTable getEvaluationrpt_Welds(DataTable fdt)
        {
            //String shipno = "", blkno = "", buff1 = "", as3 = "";
            String selSQL = "";
            String strfilter = "";
            selSQL+=" select S.SHIP_NO,S.BUFF1,S.BLK_NO,S.AS3,S.TREE_NAME, sum(Leve1) as L1 ,sum(Leve2) as L2 ,sum(Leve3) as L3,sum(Leve4) as L4 from (";
            selSQL+=" select T.FTaskID,T.G,T1.FActOpStartTime,t1.FActOpEndTime ,t1.FWELDID,t1.FWelderID,t1.FweldDriverID ";
            selSQL+=" ,T2.FName,t2.Fnum,";
            selSQL += " T3.SHIP_NO,T3.BLK_NO,T3.BUFF1,t3.AS3,T3.PART1_NAME2,T3.TREE_NAME,";
            selSQL+=" T4.FDepartName as DepartName1,T5.FDepartName as DepartName2,";
            selSQL+=" case when T.G between 0 and 59 then 1 else 0 end as Leve1,";
            selSQL+=" case when T.G between 60 and 79 then 1 else 0 end as Leve2,";
            selSQL+=" case when T.G between 80 and 89 then 1 else 0 end as Leve3,";
            selSQL+=" case when T.G between 90 and 100 then 1 else 0 end as Leve4";
            selSQL+=" from t_EvaluateRec as T";
            selSQL+=" inner join t_TaskListBody as T1 on T.FTaskID=T1.FID";
            selSQL+=" inner join t_Welder as T2 on T2.FID=T1.FWelderID";
            selSQL+=" inner join t_WELD as T3 on T3.FID=T1.FWELDID";
            selSQL+=" inner join t_Department as T4 on T4.FID=T2.Fdepart";
            selSQL+=" inner join t_Department as T5 on T5.FID=T4.FParentID";
            selSQL+=" ) as S";
            selSQL+=" where {0}";
            selSQL += " group by S.SHIP_NO,S.BUFF1,S.BLK_NO,S.AS3,S.TREE_NAME";
            //提取过滤参数
            if (fdt.Rows.Count == 0)
            {
                strfilter = " 1=1 ";
            }
            else
            {
                if (Convert.ToString(fdt.Rows[0]["SHIP_NO"]) != "%%")
                {
                    strfilter += " SHIP_NO='" + fdt.Rows[0]["SHIP_NO"].ToString() + "'  and ";
                }
                else
                {
                    strfilter += " SHIP_NO like '%%' and  ";
                }
                if (Convert.ToString(fdt.Rows[0]["BUFF1"]) != "%%")
                {
                    strfilter += " BUFF1='" + fdt.Rows[0]["BUFF1"].ToString() + "'  and ";
                }
                else
                {
                    strfilter += " BUFF1 like '%%' and  ";
                }

                if (Convert.ToString(fdt.Rows[0]["AS3"]) != "%%")
                {
                    strfilter += " AS3='" + fdt.Rows[0]["AS3"].ToString() + "'  and ";
                }
                else
                {
                    strfilter += " AS3 like '%%' and  ";
                }
                if (Convert.ToString(fdt.Rows[0]["TREE_NAME"]) != "%%")
                {
                    strfilter += " TREE_NAME='" + fdt.Rows[0]["TREE_NAME"].ToString() + "'  ";
                }
                else
                {
                    strfilter += " TREE_NAME like '%%'   ";
                }
            }
            selSQL = String.Format(selSQL, strfilter);
            DataTable dt = _sqldbhelper.ExecuteDataTable(selSQL);
            return dt;
        }
        /// <summary>
        /// 按焊工为索引查询评估结果 15122202
        /// </summary>
        /// <param name="fdt">Fnum,startdate ,enddate</param>
        /// <returns></returns>
        public DataTable getEvaluationrpt_Welders(DataTable fdt)
        {
            String selSQL = "";
            String strFilter = "";
            selSQL += " select T.FTaskID,T.G,T.Gv,T.Gx,T.Gy,T.Gz,T1.FActOpStartTime,t1.FActOpEndTime ,t1.FWELDID,t1.FWelderID,t1.FweldDriverID ";
            selSQL +=" ,T2.FName,t2.Fnum,";
            selSQL +=" T3.SHIP_NO,T3.BLK_NO,T3.BUFF1,t3.AS3,T3.PART1_NAME2,";
            selSQL +=" T4.FDepartName as DepartName1,T5.FDepartName as DepartName2";
            selSQL +=" from t_EvaluateRec as T";
            selSQL +=" inner join t_TaskListBody as T1 on T.FTaskID=T1.FID";
            selSQL +=" inner join t_Welder as T2 on T2.FID=T1.FWelderID";
            selSQL +=" inner join t_WELD as T3 on T3.FID=T1.FWELDID";
            selSQL +=" inner join t_Department as T4 on T4.FID=T2.Fdepart";
            selSQL +=" inner join t_Department as T5 on T5.FID=T4.FParentID";
            selSQL += " where {0}";
            selSQL += " order by FActOpEndTime desc";
            if (fdt.Rows.Count == 0)
            {
                strFilter = " 1=1 ";
            }
            else
            {
                if (Convert.IsDBNull(fdt.Rows[0]["Fnum"]) == false)
                {
                    strFilter = " t2.Fnum='" + fdt.Rows[0]["Fnum"].ToString() +"' and ";
                }
                else
                {
                    strFilter = " t2.Fnum like '%%'" + " and ";
                }
                //if (Convert.IsDBNull(fdt.Rows[0]["STARTDATE"]) == false)
               // {
                strFilter += " t1.FActOpEndTime between '" + fdt.Rows[0]["STARTDATE"].ToString() + "' and '" + fdt.Rows[0]["ENDDATE"].ToString()+"'";
                //}
               // else
                //{
                   // strFilter = " t2.Fnum like '%%'" + " and ";
               // }
            }
            selSQL = String.Format(selSQL, strFilter);
            DataTable dt = _sqldbhelper.ExecuteDataTable(selSQL);
            return dt;

        }
        /// <summary>
        /// 获取评估焊缝的所有分组：15122203
        /// </summary>
        /// <returns></returns>
        public DataTable getAllWeldType()
        {
            String selSQL = "";
            selSQL += " select distinct T3.SHIP_NO,T3.BLK_NO,T3.BUFF1,t3.AS3,T3.TREE_NAME ";
            selSQL += " from t_EvaluateRec as T";
            selSQL += " inner join t_TaskListBody as T1 on T.FTaskID=T1.FID";
            selSQL += " inner join t_WELD as T3 on T3.FID=T1.FWELDID";
            return _sqldbhelper.ExecuteDataTable(selSQL);
        }
    }
}
