using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections;
namespace JN_WELD_Service
{
    public static class svrTimer
    {
         static Timer _timer;
         static SqlDbHelper _sqldhelper = new SqlDbHelper();
         static svrDevices _panansoincSvr = new svrDevices();
         static DataTable _vdt;
       public static void Start()
       {
           if (_timer ==null)
           {
               _timer = new Timer(1000);//定时器1秒工作一次；
               _timer.Elapsed += _timer_Elapsed;
               _timer.Enabled = true;
               String sql = "select * from t_PanasonicDriRecord where FID=0";
               _vdt = _sqldhelper.ExecuteDataTable(sql);

               _timer.Start();
           }
           else
           {
               
           }
       }
       public static void Stop()
       {
           if (_timer == null)
           {
               
           }
           else
           {
               _timer.Stop();
           }
       }

        /// <summary>
        /// 获取指定焊机的当前状态
        /// </summary>
        /// <param name="nom"></param>
        /// <returns></returns>
       public static DataTable getweldEquipmentinfo(String nom)
       {
           
           
           DataTable dt = _panansoincSvr.getweldEquipmentinfos();

           DataView dv = dt.DefaultView;
           dv.RowFilter = "nom=" + nom;
           DataTable rdt = dv.ToTable();
           return rdt;
       }
       /// <summary>
       /// 获取焊机集合的当前状态
       /// </summary>
       /// <param name="nom"></param>
       /// <returns></returns>
       public static DataTable getweldEquipmentinfos()
       {


           DataTable dt = _panansoincSvr.getweldEquipmentinfos();//GetPanasponicDrives();
           return dt;
       }

       static void _timer_Elapsed(object sender, ElapsedEventArgs e)
       {
           //throw new NotImplementedException();
            //获取松下焊机数据，并保存到数据库中
           DataTable dt = _panansoincSvr.getweldEquipmentinfos();//GetPanasponicDrives();
           //将数据保存到数据库中；

           String sql = "insert into t_PanasonicDriRecord (";

           for (int i = 0; i < _vdt.Columns.Count-1; i++)
           {
               if (_vdt.Columns[i].ColumnName!="FID")
               sql += _vdt.Columns[i].ColumnName + ",";
           }
           if (_vdt.Columns[_vdt.Columns.Count - 1].ColumnName != "FID")
           sql += _vdt.Columns[_vdt.Columns.Count - 1].ColumnName + ") values(";

           for (int i = 0; i < _vdt.Columns.Count - 1; i++)
           {
               if (_vdt.Columns[i].ColumnName != "FID")
               sql += "@" + _vdt.Columns[i].ColumnName + ",";
           }
           if (_vdt.Columns[_vdt.Columns.Count - 1].ColumnName != "FID")
               sql += "@" + _vdt.Columns[_vdt.Columns.Count - 1].ColumnName + ")";

               for (int i = 0; i < dt.Rows.Count; i++)
               {

                   String fv = "";
                   if (dt.Rows[i]["state"].ToString() == "关闭" || dt.Rows[i]["state"].ToString() == "待机")
                   {
                       //不记录到数据中
                   }
                   else
                   {
                       ArrayList sqlparas = new ArrayList();
                       for (int k = 0; k < _vdt.Columns.Count; k++)
                       {
                           if (_vdt.Columns[k].ColumnName != "FID")
                           {
                               SqlParameter par = new SqlParameter();
                               par.ParameterName = "@" + _vdt.Columns[k].ColumnName;
                               par.SqlDbType = _sqldhelper.tranDataType2SQl(_vdt.Columns[k].DataType);
                               try
                               {
                                   par.SqlValue = dt.Rows[i][_vdt.Columns[k].ColumnName];
                                   fv += dt.Rows[i][_vdt.Columns[k].ColumnName].ToString() + ",";
                               }
                               catch { }
                               sqlparas.Add(par);
                           }
                           
                       }
                       _sqldhelper.ExecuteNonQuery(sql, CommandType.Text, sqlparas);
                   }
               }
       }
    }
}
