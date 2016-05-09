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
    class svrClassMergeWeld:svrTask
    {
        //测试实时数据抓取;
       //  SqlDbHelper _sqldhelper = new SqlDbHelper();
       //  panasonicClass _panansoincSvr = new panasonicClass();  
       //  DataTable _vdt;
       // //
       // public DataTable RealRec()
       // {
       //     String xml=_panansoincSvr.GetPanasponicDrives();
       //    DataTable dt = clsConvertXMLDataTable.ConvertXMLToDataTable(xml);
       //    //将数据保存到数据库中；

       //    String sql = "insert into t_PanasonicDriRecord (";

       //    for (int i = 0; i < _vdt.Columns.Count-1; i++)
       //    {
       //        if (_vdt.Columns[i].ColumnName!="FID")
       //        sql += _vdt.Columns[i].ColumnName + ",";
       //    }
       //    if (_vdt.Columns[_vdt.Columns.Count - 1].ColumnName != "FID")
       //    sql += _vdt.Columns[_vdt.Columns.Count - 1].ColumnName + ") values(";

       //    for (int i = 0; i < _vdt.Columns.Count - 1; i++)
       //    {
       //        if (_vdt.Columns[i].ColumnName != "FID")
       //        sql += "@" + _vdt.Columns[i].ColumnName + ",";
       //    }
       //    if (_vdt.Columns[_vdt.Columns.Count - 1].ColumnName != "FID")
       //        sql += "@" + _vdt.Columns[_vdt.Columns.Count - 1].ColumnName + ")";

       //        for (int i = 0; i < dt.Rows.Count; i++)
       //        {

       //            String fv = "";
       //            if (dt.Rows[i]["state"].ToString() == "关闭" || dt.Rows[i]["state"].ToString() == "待机")
       //            {
       //                //不记录到数据中
       //            }
       //            else
       //            {
       //                ArrayList sqlparas = new ArrayList();
       //                for (int k = 0; k < _vdt.Columns.Count; k++)
       //                {
       //                    if (_vdt.Columns[k].ColumnName != "FID")
       //                    {
       //                        SqlParameter par = new SqlParameter();
       //                        par.ParameterName = "@" + _vdt.Columns[k].ColumnName;
       //                        par.SqlDbType = _sqldhelper.tranDataType2SQl(_vdt.Columns[k].DataType);
       //                        try
       //                        {
       //                            par.SqlValue = dt.Rows[i][_vdt.Columns[k].ColumnName];
       //                            fv += dt.Rows[i][_vdt.Columns[k].ColumnName].ToString() + ",";
       //                        }
       //                        catch { }
       //                        sqlparas.Add(par);
       //                    }
                           
       //                }
       //                _sqldhelper.ExecuteNonQuery(sql, CommandType.Text, sqlparas);
       //            }
       //        }
       //}
       // }


        /// <summary>
        /// 合并焊缝数据并更新一个数据包
        /// 5111801
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable Classmergweld(DataTable idata)
        {
            //将需要合并的焊缝数据进行处理；
            //将字段FIsMerge做合并标志 1
            //将字段FParentID 标志代表
            //准备获取焊缝数据
            String weldIDstr = "";
            long parentid = Convert.ToInt64(idata.Rows[0]["FweldID"]);
            String bakname = Convert.ToString(idata.Rows[0]["FNewName"]);
            for (int i = 0; i < idata.Rows.Count; i++)
            {
                weldIDstr += idata.Rows[i]["FweldID"].ToString() + ",";
            }
            weldIDstr = weldIDstr.Substring(0, weldIDstr.Length - 1);
            String sql = "select * from t_WELD where FID in (" + weldIDstr + ")";
            DataTable vdata = _sqldbhelper.ExecuteDataTable(sql);

            String selSQL = "select * from t_WELD where FID in (" + weldIDstr + ")";


            for (int i = 0; i < vdata.Rows.Count; i++)
            {
                vdata.Rows[i]["FParentID"] = parentid;//代表焊缝ID
                vdata.Rows[i]["FNewName"] = bakname;
                //data.Rows[i]["FIsMerge"] = 1;//合并标志

            }
            DataTable cdata = vdata.Copy();
            DataTable dt = _sqldbhelper.UpdateByDataTable(selSQL, cdata, "FID", 0);
            //从任务表t_TaskListBody删除除了第一个焊缝
            DataTable deldt = new DataTable();
            DataColumn col = new DataColumn(); col.ColumnName = "FWELDID"; col.DataType = typeof(long); deldt.Columns.Add(col);
            String delWELDID = "";
            for (int i = 0; i < idata.Rows.Count; i++)
            {
                if (Convert.ToInt64(idata.Rows[i]["FWELDID"]) != parentid)
                {
                    DataRow nr = deldt.NewRow(); nr[0] = idata.Rows[i]["FWELDID"]; deldt.Rows.Add(nr);
                    delWELDID += Convert.ToInt64(idata.Rows[i]["FWELDID"]) + ",";
                }
            }

            //将焊缝任务从任务表中删除
            String delselSQL = "Select * from t_DispatchingBody";
            deldt = _sqldbhelper.UpdateByDataTable(delselSQL, deldt, "FWELDID", 2);
            //合并焊缝删除
            //select FWELDWPSID,FWELDID from t_TaskListBody
            //select FWELDWPSID,FWELDID  from t_DispatchingBody
            //select FWELDWPSID,FWELDID from t_ProcessPlanBody


            //修改其wps
            //将保留的焊缝所在的任务对应的WPS编号设定为默认系列0
            String seltask = "select * from t_DispatchingBody where Fweldid=" + parentid;
            DataTable dt_task = _sqldbhelper.ExecuteDataTable(seltask);
            long vcurWPS = 0;
            svrDefaultWPS vsvr = new svrDefaultWPS();
            DataTable defaultdt= vsvr.getCurDefaultWPS();
            if (defaultdt == null)
                vcurWPS = 0;
            else
            {
                if (defaultdt.Rows.Count > 0)
                {
                    vcurWPS=Convert.ToInt64(defaultdt.Rows[0]["Fvalue"]);
                }
                else
                {
                    vcurWPS = 0;
                }
            }

            dt_task.Rows[0]["FWELDWPSID"] = vcurWPS;
            DataTable rs_dt = _sqldbhelper.UpdateByDataTable(seltask, dt_task, "FID", 0);

            //获取合并后的热舞
            String newSQL = "select * from t_DispatchingBody where FWELDID=" + parentid;
            rs_dt = new DataTable();
            rs_dt = _sqldbhelper.ExecuteDataTable(newSQL);

            return rs_dt;

        }
        /// <summary>
        /// 获取班组未分配的焊缝集合;
        /// 5111802
        /// </summary>
        /// <returns></returns>
        public DataTable getClassUndispatchWeldes(DataTable fdt)
        {
            long classid = 0;
            if (fdt != null && fdt.Rows.Count == 1)
            {
                classid = Convert.ToInt64(fdt.Rows[0][0]);
            }
            String sql = "";
            sql+=" select T1.*,T2.FWelderID from [View_DispatchBodyInfos] as T1 ";
            sql+=" left join t_TaskListBody as T2 on T1.FWELDID=T2.FWeldID ";
            sql+=" inner join t_WELD as T3 on T3.FID=T1.FWELDID ";
            sql += " where T2.FWELDID is  null and  T3.FParentID=0 ";
            DataTable dt = _sqldbhelper.ExecuteDataTable(sql) ;// GetWeldFrTaskListwithDispatch();
            DataView dv = dt.DefaultView;
            dv.RowFilter = "FOPDEPARTID="+classid.ToString();
            DataTable ndt = dv.ToTable();
            return ndt;
        }
        /// <summary>
        /// 还原打包焊缝;
        /// 15111803
        /// </summary>
        /// <returns>FWelderID , FDispatchHeadID , </returns>
        public DataTable RollBackMerge(DataTable data)
        {
            DataTable dt = new DataTable();
            return dt;
        }
        /// <summary>
        /// 获取打包焊缝后所包含的焊缝集合
        /// 5112001
        /// </summary>
        /// <returns></returns>
        public DataTable GetMergedWelds(DataTable fdt)
        {
            String selSQL = "select t_DispatchingBody.FID, t_DispatchingBody.FWELDID, FWELDWPSID,FNewName,t_WPS_RULE.RuleNum,RuleName,SHIP_NO,BLK_NO,TREE_NAME,WELD_NO,PART1_NAME2,PART2_NAME2,AS3,BUFF1 ,FParentID from t_Weld ";
            selSQL+=" inner join t_DispatchingBody on t_WELD.FID=t_DispatchingBody.FWELDID ";
            selSQL += " inner join t_WPS_RULE on t_WPS_RULE.FID=t_DispatchingBody.FWELDWPSID ";
            selSQL+=" where t_WELD.FParentID=t_WELD.FID and t_DispatchingBody.FOPDEPARTID= ";
            long classid = 0;
            if (fdt != null && fdt.Rows.Count == 1)
            {
                classid = Convert.ToInt64(fdt.Rows[0][0]);
            }
            selSQL += classid.ToString();
            DataTable rsdt = _sqldbhelper.ExecuteDataTable(selSQL);
            return rsdt;
        }
        /// <summary>
        /// 更新合并后焊缝的WPS;6030901
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable UpdateMargedweldwps(DataTable data)
        {
            String sql = "Select FID,FWELDWPSID from t_DispatchingBody";
            DataTable rs=_sqldbhelper.UpdateByDataTable(sql, data, "FID", 0);
            return rs;
        
        }
        /// <summary>
        /// 获取包内的焊缝 6042702
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable GetBagWelds(DataTable data)
        {
            long indexWeldFID = 0;
            indexWeldFID = Convert.ToInt64(data.Rows[0][0]);
            //String selSQL = "select t_WELD.*,t_DispatchingBody.FID as vFID  , t_DispatchingBody.FWELDID from t_WELD inner join t_DispatchingBody on t_DispatchingBody.FWELDID=t_WELD.FParentID where t_DispatchingBody.FID={0}";
            //selSQL = String.Format(selSQL, indexWeldFID);
            //DataTable rs = _sqldbhelper.ExecuteDataTable(selSQL);



            String sql = "";
            sql += " select T1.*,T2.FWelderID from [View_DispatchBodyInfos] as T1 ";
            sql += " left join t_TaskListBody as T2 on T1.FWELDID=T2.FWeldID ";
            sql += " inner join t_WELD as T3 on T3.FID=T1.FWELDID ";
            sql += " where T2.FWELDID is  null and  T3.FParentID= "+indexWeldFID;

            sql="select T1.* ,T3.FParentID from [View_DispatchBodyInfos] as T1    inner join t_WELD as T3 on T3.FID=T1.FWELDID ";
            sql += " where T3.FParentID=( select FWELDID from t_DispatchingBody where FID={0})";
            sql = "select *,FID as FWELDID from t_WELD where FParentID=(select FWELDID from t_DispatchingBody where FID={0})";
            sql = String.Format(sql, indexWeldFID);
            DataTable dt = _sqldbhelper.ExecuteDataTable(sql);// GetWeldFrTaskListwithDispatch();



            return dt;
        }
        /// <summary>
        /// 取消合并的焊缝 6042701
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable CancelMargedwelds(DataTable data)
        {
            DataTable rs;
            //获取合并后焊缝的FID;
            long vFID = Convert.ToInt64(data.Rows[0]["FID"]);

            String selSQL = "";
            //得到保内的所有焊缝的FIDs
            DataTable pagwelds;
            selSQL = "select t_WELD.*,t_DispatchingBody.FID as vFID from t_WELD inner join t_DispatchingBody on t_DispatchingBody.FWELDID=t_WELD.FParentID where t_WELD.FID<>t_WELD.FParentID and  t_DispatchingBody.FID=" + vFID.ToString();
            pagwelds = _sqldbhelper.ExecuteDataTable(selSQL);
            //得到包标志信息
            selSQL = "select * from t_DispatchingBody where FID=" + vFID.ToString();
            DataTable indexWeld = _sqldbhelper.ExecuteDataTable(selSQL);
            //将焊缝还原
            DataTable rtdata = indexWeld.Clone();
            for (int i = 0; i < pagwelds.Rows.Count; i++)
            {
                if (pagwelds.Rows[i]["FID"].ToString() != indexWeld.Rows[0]["FWELDID"])
                {
                    DataRow nRow = rtdata.NewRow();
                    //,FDispatchHeadID,FProjectHeadID,FSTATE,FOPDEPARTID,FWELDID,FWELDWPSID,FParentDepartID
                    nRow["FDispatchHeadID"] = indexWeld.Rows[0]["FDispatchHeadID"];
                    nRow["FProjectHeadID"] = indexWeld.Rows[0]["FProjectHeadID"];
                    nRow["FSTATE"] = indexWeld.Rows[0]["FSTATE"];
                    nRow["FOPDEPARTID"] = indexWeld.Rows[0]["FOPDEPARTID"];
                    nRow["FWELDWPSID"] = indexWeld.Rows[0]["FWELDWPSID"];
                    nRow["FParentDepartID"] = indexWeld.Rows[0]["FParentDepartID"];
                    nRow["FWELDID"] = pagwelds.Rows[i]["FID"];
                    rtdata.Rows.Add(nRow);
                }

            }
            //更新数据库--作业区
            String upSQL = "select * from t_DispatchingBody";
            rs = _sqldbhelper.UpdateByDataTable(upSQL, rtdata, "FID", 1);
            //更新数据库--焊缝;
            upSQL = "Update t_WELD set FParentID=0,FNewName='' where FParentID=" + indexWeld.Rows[0]["FWELDID"].ToString();// vFID.ToString();
            rs = _sqldbhelper.ExecuteDataTable(upSQL);
            return rs;
        }
    }
}
