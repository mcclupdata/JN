using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections;
using HolisticDefine;
using System.Reflection;
using System.Threading;

namespace JN_WELD_Service
{
    class svrDevices:_clsdb
    {

        static OTCDevices otcdevices;
        static panasonicDevices panasondevices;
        /// <summary>
        /// 焊机设备底层接口
        /// </summary>
        /// 
        public svrDevices()
        {
            if (otcdevices == null)
                otcdevices = new OTCDevices();
            if (panasondevices == null)
                panasondevices = new panasonicDevices();

        }

        /// <summary>
        /// 获取所有焊机的通道信息；
        /// </summary>
        /// <returns></returns>
        public DataTable GetPanasoicDrivesChannelInfos()
        {
            DataTable dt = new DataTable();
            return dt;
        }
        /// <summary>
        /// 获取焊机实时数据
        /// </summary>
        /// <returns></returns>
        public DataTable getweldEquipmentinfos()
        {
            DataTable dt_pa = panasondevices.GetDrives();
            DataTable dt_otc = otcdevices.GetDrives();
            dt_pa.Merge(dt_otc);
            return dt_pa; 
        }
        /// <summary>
        /// 下载WPS参数
        /// </summary>
        /// <param name="row"></param>
        /// <param name="WeldDevice"></param>
        public void changeset(ref  DataRow row, String WeldDevice)
        {
            //查询得到焊机的种类
            String selSQL = "";
            selSQL+="Select FweldEquipmentID  ,Fvalue from t_weldEquipment ";
            selSQL += " inner join t_Dictionary on t_Dictionary.FID=t_weldEquipment.FweldManufacturerID ";
            selSQL += " where FweldEquipmentID='" + WeldDevice + "'";
            DataTable dt_weldinfo = _sqldbhelper.ExecuteDataTable(selSQL);
            if (dt_weldinfo == null)
            {
                Console.WriteLine(String.Format("未能找到编号为{0}的焊机信息,无法下载参数", WeldDevice));
                return;
            }
            if (dt_weldinfo.Rows.Count == 0)
            {
                Console.WriteLine(String.Format("未能找到编号为{0}的焊机信息,无法下载参数", WeldDevice));
                return;
            }
            int devicetype = Convert.ToInt32(dt_weldinfo.Rows[0]["Fvalue"]);
            switch (devicetype)
            {
                case 0:
                    panasondevices.changeset(ref row, WeldDevice);
                   
                    break;
                case 1:
                    otcdevices.changeset(ref row, WeldDevice);
                    break;
                default:
                    break;
            }
            return;
        }
    }
}
