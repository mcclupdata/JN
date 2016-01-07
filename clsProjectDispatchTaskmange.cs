using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace MC
{
    /// <summary>
    /// 工序计划、派工单管理 
    /// </summary>
    public class clsProjectDispatchTaskmange:clsFrmBase
    {
        /// <summary>
        /// 获取工序计划表头 
        /// 6010101
        /// </summary>
        int cmd_getPlanHead = 6010101;
         /// <summary>
        /// 获取派工单表头 
        /// 6010104
        /// </summary>
        /// <returns></returns>
        int cmd_getDispatchHead = 6010104;
        /// <summary>
        /// 获取工序计划表体--索引
        /// 6010102
        /// </summary>
        /// <param name="fdata">工序计划单FID</param>
        /// <returns></returns>
        int cmd_getPanBodyIndex = 6010102;
        /// <summary>
        /// 获取派工单表体--索引
        /// 6010105
        /// </summary>
        /// <param name="fdata">工序计划单FID</param>
        /// <returns></returns>
        int cmd_getDispatchBodyIndex = 6010105;
        /// <summary>
        /// 获取工序计划表体中部门所分配的焊缝信息；
        /// 6010103
        /// </summary>
        /// <param name="fdata">ProjectID ， FDoDepartID</param>
        /// <returns></returns>
        int cmd_getPanBodyList = 6010103;
        /// <summary>
        /// 获取派工单表体中部门所分配的焊缝信息；
        /// 6010106
        /// </summary>
        /// <param name="fdata">DispatchID ， FDoDepartID</param>
        /// <returns></returns>
        int cmd_getDispatchBodyList = 6010106;

        int _type = 0;
        public clsProjectDispatchTaskmange(int vtype)
        {
            _type = vtype;
        }
        /// <summary>
        /// 获取表单头
        /// </summary>
        /// <returns></returns>
        public DataTable getHead()
        {
            DataTable head_dt = new DataTable() ;
            if (_type == 0)
            {
                head_dt = _Client.ServiceCall(cmd_getPlanHead, null);
            }
            if (_type == 1)
            {
                head_dt = _Client.ServiceCall(cmd_getDispatchHead, null);
            }
            return head_dt;
        }
        /// <summary>
        /// 获取表单体的索引值
        /// </summary>
        /// <param name="vfid"></param>
        /// <returns></returns>
        public DataTable getBodyIndex(long vfid)
        {
            DataTable BodyIndex_dt = new DataTable();
            DataTable fdata = new DataTable();
            fdata.Columns.Add("FID", typeof(long));
            fdata.Rows.Add(vfid);
            if (_type == 0)
            {
                BodyIndex_dt = _Client.ServiceCall(cmd_getPanBodyIndex, fdata);
            }
            if (_type == 1)
            {
                BodyIndex_dt = _Client.ServiceCall(cmd_getDispatchBodyIndex, fdata);
            }
            return BodyIndex_dt;
        }
        /// <summary>
        /// 获取表单内的焊缝细节
        /// </summary>
        /// <param name="headid"></param>
        /// <param name="vid"></param>
        /// <returns></returns>
        public DataTable getBodyList(long headid, long vid)
        {
            DataTable BodyList_dt = new DataTable();
            DataTable fdata = new DataTable();
            fdata.Columns.Add("FID", typeof(long));
            fdata.Columns.Add("vID", typeof(long));
            fdata.Rows.Add(headid,vid);
            if (_type == 0)
            {
                BodyList_dt = _Client.ServiceCall(cmd_getPanBodyList, fdata);
            }
            if (_type == 1)
            {
                BodyList_dt = _Client.ServiceCall(cmd_getDispatchBodyList, fdata);
            }
            return BodyList_dt;

        }
    }
}
