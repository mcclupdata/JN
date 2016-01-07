using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
namespace JN_WELD_Service
{
    /// <summary>
    /// 焊工信息--批量导入；查询
    /// </summary>
    class clsdbwelders
    {
        SqlDbHelper _sqlhelper = new SqlDbHelper();
        /// <summary>
        /// 构造函数
        /// </summary>
        public clsdbwelders()
        {

        }
        /// <summary>
        /// 客户端从excel读取数据，并打包到DataTable中，传递给服务器函数，将数据批量插入数据库中的t_welder表中；
        /// 执行方法为：1将数据写入到临时表中，2 通过查询语句批量导入到数据库中 3 反馈信息到客户端
        /// </summary>
        /// <param name="dt">要导入的焊工信息</param>
        /// <returns>导入结果汇报</returns>
        public DataTable batchinput(DataTable dt)
        {
            //WelderName	IdentificationCard	WeldingProcessAb	FWELDLEVENNAME	WeldingClass	WelderWorkerID	WelderDepartment	WelderWorkPlace	WelderLaborServiceTeam
            //姓名	身份证	焊接方法	对/角接	等级	工号	部门	作业区	劳务队
            //0,0,0,
            DataTable resule = new DataTable();
            String sql = "Create Table tmpwelder (WelderName nvarchar(100), IdentificationCard nvarchar(100),WeldingProcessAb nvarchar(100),WeldingType nvarchar(100),";
            sql += "WeldingClass nvarchar(100),WelderWorkerID nvarchar(100), WelderDepartment nvarchar(100), WelderWorkPlace nvarchar(100), WelderLaborServiceTeam nvarchar(100))";
            //创建临时表
            _sqlhelper.ExecuteNonQuery(sql);
            //整理数据；
            //将导入的数据保存到数据库的临时表中

            sql = "insert into tmpwelder (WelderName,IdentificationCard,WeldingProcessAb,WeldingClass,WeldingType,WelderWorkerID,WelderDepartment,WelderWorkPlace,WelderLaborServiceTeam)";
            String sqlvalue = "";
            String cmdsql = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow  row=dt.Rows[i];
                sqlvalue = " values('" + row["WelderName"].ToString() + "','" + row["IdentificationCard"].ToString() + "','" + row["WeldingProcessAb"].ToString() + "','";
                sqlvalue += row["WeldingClass"].ToString() + "','" + row["WeldingType"].ToString() + "','" + row["WelderWorkerID"].ToString() + "','" + row["WelderDepartment"].ToString() + "','" + row["WelderWorkPlace"].ToString() + "','" + row["WelderLaborServiceTeam"].ToString() + "'";
                cmdsql = sql + sqlvalue;
                _sqlhelper.ExecuteNonQuery(cmdsql);
                cmdsql = "";
                sqlvalue = "";
            }
                //进行数据匹配：焊接方法-对/角接 --等级--工作范围
                //t_welderleve
            //调用存储过程处理数据并返回结果。
            String sqlProname = "batchinputwelder";
            DataTable res = _sqlhelper.ExecuteProcedureNoParams(sqlProname);
           //执行查询结果；

            return res;
        }
    }
}
