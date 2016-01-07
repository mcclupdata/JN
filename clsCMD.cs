using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MC
{
    static class clsCMD
    {
        /// <summary>
        /// 获取焊机位置命令
        /// </summary>
        public static int cmd_weldEquipment_weldPoint=0509202;//获取焊机位置命令
        /// <summary>
        /// 获取焊机集合命令
        /// </summary>
        public static int cmd_weldEquipment_get = 0509201;//获取焊机集合命令；
        /// <summary>
        /// 焊机监控--通过给定的焊机编号，查询得到焊机的基本信息：预置电流，预置电压，状态
        /// </summary>
        public static int cmd_weldEquipment_getBase_Bynom = 0509203;//焊机监控--通过给定的焊机编号，查询得到焊机的基本信息：预置电流，预置电压，状态
        public static int cmd_weldEquipment_getTask_Bynom = 0509204;//焊机监控--通过焊机的nom，获取使用焊机的最前面10位焊工任务信息
        public static int cmd_weldEquipManage_getParams = 0509205;//焊机总成--加载焊机基本参数；
        public static int cmd_weldEquipManage_getAll = 0509206;///焊机总成--加载当前存在的焊机；
        public static int cmd_weldEquipManage_getManu = 0509207;//焊机总成--加载焊机厂家
        public static int cmd_weldEquipManage_get = 0509208;//焊机总成--加载所有焊机集合
        public static int cmd_weldEquipManage_getUpdate = 0509209;//焊机总成--提交保存焊机信息
        public static int cmd_weldEquipManage_getOneweldEquipInfo = 05092010;//焊机总成--依据焊机编号，加载焊机管理的基本信息；
        /// <summary>
        /// 焊机区间报表 5100501
        /// </summary>
        public static int cmd_Report_WeldSectionRp = 5100501;
        /// <summary>
        /// 日/月/自定义报表--焊机 5100502
        /// </summary>
        public static int cmd_Report_weldReport_weld = 5100502;
        /// <summary>
        /// 日/月/自定义报表--焊工 5100503
        /// </summary>
        public static int cmd_Report_WeldReport_Welder = 5100503;
        /// <summary>
        /// 任务报表 5100504
        /// </summary>
        public static int cmd_Report_TaskReport = 5100504;
        /// <summary>
        /// 分别提取 0焊机位置集合，1焊机集合，2焊工集合 5100505
        /// </summary>
        public static int cmd_Report_ReportBase = 5100505;
        /// <summary>
        /// 提取部门数据 5100506
        /// </summary>
        public static int cmd_DepartMgs_Departments = 5100506;
        /// <summary>
        /// 更新部门数据 5100507
        /// </summary>
        public static int cmd_DepartMgs_upDateDepartments = 5100507;
      

        /// <summary>
        /// 按照焊机编号 获取历史数据；
        /// </summary>
        public static int cmd_Hostory_GetRealinfos = 1033;
        /// <summary>
        /// 获取指定焊机的历史数据，按照任务进行查询5092601
        /// </summary>
        public static int cmd_weldEquipment_real_History = 5092601;
        /// <summary>
        /// get equipment and task
        /// </summary>
        public static int cmd_weldEquipment_Real_PaicTask = 5092602;
       /// <summary>
        /// 批量更新WPS  命令代码5101401
       /// </summary>
        public static int cmd_wpsedit_upwps = 5101401;
        /// <summary>
        /// 批量更新WPSSub  命令代码5101402
        /// </summary>
        public static int cmd_wpsedit_upwps_sub = 5101402;

        /// <summary>
        /// 获取焊工所在班组及其全称信息 5101501
        /// </summary>
        public static int cmd_welderedit_getwelderdepart = 5101501;
        /// <summary>
        /// 获取所有焊工信息 5101502
        /// </summary>
        public static int cmd_welderedit_getwelders = 5101502;

        /// <summary>
        /// 获取所有工程队信息 5101503
        /// </summary>
        public static int cmd_welderedit_getLibs = 5101503;


        /// <summary>
        /// 获取焊工焊接等级数据 5101504
        /// </summary>
        public static int cmd_welderedit_getwelderClass = 5101504;


        /// <summary>
        /// 获取焊接等级信息 5101505
        /// </summary>
        public static int cmd_welderedit_get_weldClass = 5101505;

        /// <summary>
        /// 更新焊工基础数据 5101506
        /// </summary>
        public static int cmd_welderedit_UpdateWelders = 5101506;

        /// <summary>
        /// 更新焊工焊接等级信息 5101507
        /// </summary>
        public static int cmd_welderedit_UpdateWelderClass = 5101507;
        /// <summary>
        /// 获取焊接等级信息库内容 5101508
        /// </summary>
        public static int cmd_welderedit_getweldModesTable = 5101508;

        /// <summary>
        /// 更新焊接等级信息库内容 5101509
        /// </summary>
        public static int cmd_welderedit_UpdateweldModesTable = 5101509;
        /// <summary>
        /// 获取焊缝数据 5101510
        /// </summary>
        public static int cmd_welderedit_getWeldTable = 5101510;
        /// <summary>
        /// 更新焊缝数据 5101511
        /// </summary>
        public static int cmd_welderedit_Updateweldtable = 5101511;
         /// <summary>
        /// 获船型缝数据 5101512
        /// </summary>
        public static int cmd_welderedit_getSHIP_MOD = 5101512;
        
        /// <summary>
        /// //合并焊缝数据并更新一个数据包
        // 511801:
        /// </summary>
        public static int cmd_ClassweldsMerg_Merge = 5111801;
        /// <summary>
        /// 获取班组未分配的焊缝集合;
        /// </summary>
        public static int cmd_ClassweldsMerg_GetWeldByClassID = 5111802;
        /// <summary>
        /// 获取打包焊缝后所包含的焊缝集合
        /// 5112001
        /// </summary>
        public static int cmd_ClassweldsMerg_GetMergedweldsByClassID = 5112001;
     
       /// <summary>
        /// 获取默认WPS集合
        /// 5112101
       /// </summary>
        public static int cmd_DefaultWPS_GetDefaultWPSs = 5112101;
        /// <summary>
        /// 获取当前使用的默认WPS
        /// 5112102
        /// </summary>
        public static int cmd_DefaultWPS_GetCurDefaultWPS = 5112102;
        /// <summary>
        /// 设置当前使用的默认wps
        /// 5112103
        /// </summary>
        public static int cmd_DefaultWPS_SetCurDefaultWPS = 5112103;
        /// <summary>
        /// 更新默认WPS数据
        /// 5112104
        /// </summary>
        public static int cmd_DefaultWPS_UpdateDefaultWPS = 5112104;
        /// <summary>
        ///更新默认SUbWPS
        ///5112105
        /// </summary>
        public static int cmd_DefaultWPS_UpdateDefaultSubWPS = 5112105;
        /// <summary>
        /// 获取默认SubWPS
        /// 5112106
        /// </summary>
        public static int cmd_DefaultWPS_GetDefaultSubWPS = 5112106;
        /// <summary>
        /// 加载未匹配WPS的焊缝数据，并自动匹配
        /// 5112201
        /// </summary>
        public static int cmd_AutoMatchWPS_GetUnAutoWPS = 5112201;
        /// <summary>
        /// 获取已经匹配好WPS的焊缝数据
        /// 5112202
    /// </summary>
        public static int cmd_AutoMatchWPS_GetWeldwithWPS = 5112202;
        /// <summary>
        /// 更新自动匹配的WPS数据
        /// 5112203
        /// </summary>
        public static int cmd_AutoMatchWPS_UpdateWPS = 5112203;
        /// <summary>
        /// 获取焊缝匹配的焊机的通道信息，并显示分配或设定的焊机通道与焊道信息
        /// </summary>
        public static int cmd_WeldTask_CheckWPSAndPreChannel = 5112501;
    }
}
