﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Globalization;
using EI;
using EF;
using DevExpress.XtraExport;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
namespace MC
{
    class clsClassMargwelds:clsTask
    {
        /// <summary>
        /// 焊缝合并，更新合并后新焊缝的WPS 命令；
        /// </summary>
        static int cmd_Margwelds_UpnewWPS = 6030901;
        /// <summary>
        /// 焊缝合并，更新合并后新焊缝的WPS
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable UpdateMargedWeldWPS(DataTable vdata)
        {
            //提取修改后的数据;
            DataTable data= vdata.GetChanges(DataRowState.Modified);
            if (data == null)
                return vdata;

            //对字段进行过滤，保留FID和FWELDWPSID
            for (int i = 0; i < data.Columns.Count; i++)
            {
                if (data.Columns.IndexOf("FID") > -1 || data.Columns.IndexOf("FWELDWPSID") > -1)
                {
                }
                else
                {
                    data.Columns.Remove(data.Columns[i]);
                }

            }
            data.AcceptChanges();
            DataTable rs=_Client.ServiceCall(cmd_Margwelds_UpnewWPS, data);
            return rs;
        }
        public clsClassMargwelds(ref Formbase frm)
        {
            this._frm = frm;
            Initial();
        }
        public clsClassMargwelds()
        {
            Initial();
        }
        /// <summary>
        /// 初始化界面要素
        /// </summary>
        /// <returns></returns>
        protected Boolean Initial()
        {
            //填充作业区
            _Depart = _Client.ServiceCall(cmd_Task_GetDepartInfo, null);
            //获取焊工信息
            _Welder = _Client.ServiceCall(cmd_Task_GetWelders, null);

            //绑定到部门Combox中
            EFComboBox work = (EFComboBox)FindControl("WorkGroup");
            DataView dv = _Depart.DefaultView;
            dv.RowFilter = "Flevel=1";
            DataTable workdt = dv.ToTable();
            work.DataSource = workdt;
            work.DisplayMember = "FDepartName";
            work.ValueMember = "FID";
            //设定部门联动班组
            work.SelectedIndexChanged += work_SelectedIndexChanged;
            work_SelectedIndexChanged(work, null);
            //设定班组加载焊缝
   

            


            return false;
        }
        /// <summary>
        /// 获取班组待分配的待合并的焊缝数据集合;
        /// </summary>
        /// <param name="classid"></param>
        /// <returns></returns>
        public DataTable getClassWeldsForMerge(long classid)
        {
            DataTable fdata = new DataTable();
            fdata.Columns.Add("FClassID", typeof(long));
            DataRow nr = fdata.NewRow(); nr[0] = classid; fdata.Rows.Add(nr);
            DataTable rs = _Client.ServiceCall(clsCMD.cmd_ClassweldsMerg_GetWeldByClassID, fdata);
            //rs.Columns.Add("FChecked", typeof(int));
            DataColumn col = new DataColumn(); col.ColumnName = "FChecked"; col.DataType = typeof(int); col.DefaultValue = 0;
            rs.Columns.Add(col);
            return rs;
        }
        /// <summary>
        /// 获取班组已合并的焊缝数据集合;
        /// </summary>
        /// <param name="classid"></param>
        /// <returns></returns>
        public DataTable getClassMergedwelds(long classid)
        {
            DataTable fdata = new DataTable();
            fdata.Columns.Add("FClassID", typeof(long));
            DataRow nr = fdata.NewRow(); nr[0] = classid; fdata.Rows.Add(nr);
            DataTable rs = _Client.ServiceCall(clsCMD.cmd_ClassweldsMerg_GetMergedweldsByClassID, fdata);
            //rs.Columns.Add("FChecked", typeof(int));
            DataColumn col = new DataColumn(); col.ColumnName = "FChecked"; col.DataType = typeof(int); col.DefaultValue = 0;
            rs.Columns.Add(col);
            rs.AcceptChanges();
            return rs;
        }
        /// <summary>
        /// 执行合并
        /// </summary>
        /// <returns></returns>
        public DataTable MergeWelds(DataTable data)
        {
            if (data.Rows.Count > 1)
            {
                return _Client.ServiceCall(clsCMD.cmd_ClassweldsMerg_Merge, data);
            }
            else
            {
                return null;
            }
        }
    }
}
