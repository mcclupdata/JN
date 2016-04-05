using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections;
using HolisticDefine;
namespace JN_WELD_Service
{
    class svrWelderparamsedit:_clsdb
    {

        SysDefine _SD = new SysDefine();
        public svrWelderparamsedit()
        {
            INIClass incls = new INIClass();
            String sxip = incls.getPQMDIP();
            _SD.TestDB(sxip);
        }

        /// <summary>
        /// 更新焊机参数
        /// 6032801
        /// </summary>
        /// <returns></returns>
        public DataTable UpdatCode(DataTable data, int vtype)
        {
            Update(data);
            return data;
        }
        //保存规范
        private void Update(DataTable data)
        {
           
            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow r = data.Rows[i];
                StandardDataClass sdc = new StandardDataClass();
                sdc.nom = Convert.ToInt32(r["nom"]);// int.Parse(cobWeldNom.Text);
                sdc.channel = Convert.ToInt32(r["channel"]); //cobChannel.SelectedIndex + 1;
                sdc.used = 1;
                sdc.used = 0;
                sdc.wp = Convert.ToInt32(r["wp"]);
                sdc.mt = Convert.ToInt32(r["mt"]);
                sdc.wd = Convert.ToInt32(r["wd"]);
                if (Convert.ToInt32(r["wc"]) == 0)
                {
                    sdc.wc = 1;
                }
                else if (Convert.ToInt32(r["wc"]) == 1)
                {
                    sdc.wc = 3;
                }
                else if (Convert.ToInt32(r["wc"]) == 2)
                {
                    sdc.wc = 5;
                }
                else if (Convert.ToInt32(r["wc"]) == 3)
                {
                    sdc.wc = 2;
                }
                sdc.yiyuan = Convert.ToInt32(r["yiyuan"]);

                sdc.mp = Convert.ToInt32(r["mp"]);
                sdc.pwtime = Convert.ToSingle(r["pwtime"]);
                sdc.vai_up = Convert.ToInt32(r["vai_up"]);
                sdc.vai_down = Convert.ToInt32(r["vai_down"]);
                sdc.va_up = Convert.ToInt32(r["va_up"]);
                sdc.va_down = Convert.ToInt32(r["va_down"]);
                sdc.vaf_up = Convert.ToInt32(r["vaf_up"]);
                sdc.vaf_down = Convert.ToInt32(r["vaf_down"]);

                sdc.vvi_up = Convert.ToSingle(r["vvi_up"]);
                sdc.vvi_down = Convert.ToSingle(r["vvi_down"]);
                sdc.vv_up = Convert.ToSingle(r["vv_up"]);
                sdc.vv_down = Convert.ToSingle(r["vv_down"]);
                sdc.vvf_up = Convert.ToSingle(r["vvf_up"]);
                sdc.vvf_down = Convert.ToSingle(r["vvf_down"]);
                sdc.dwai_up =Convert.ToInt32(r["dwai_up"]);
                sdc.dwai_down = Convert.ToInt32(r["dwai_down"]);
                //try
                //{
                //    if ((int.Parse(textBox2.Text) >= -50 && int.Parse(textBox2.Text) <= 50) || (int.Parse(textBox3.Text) >= -5 && int.Parse(textBox3.Text) <= 5))
                //    {
                        //sdc.dwai_up =Convert.ToInt32(r["dwai_up"]);
                        //sdc.dwai_down = Convert.ToInt32(r["dwai_down"]);
                //    }
                //    else
                //    {
                //        MessageBox.Show("电流电压补偿值设置有误！");
                //        return;
                //    }
                //}
                //catch
                //{
                //    MessageBox.Show("电流电压补偿值设置有误！");
                //    return;
                //}

                sdc.backinfo = (r["backinfo"]).ToString();

                //报警参数设置
                sdc.wa_up = Convert.ToInt32(r["wa_up"]);
                sdc.wa_down = Convert.ToInt32(r["wa_down"]);
                sdc.wv_up = Convert.ToSingle(r["wv_up"]);
                sdc.wv_down = Convert.ToSingle(r["wv_down"]);

                //不启用
                //只报警
                //报警停机
                ////if (comboBox4.SelectedIndex == 0)
                ////{
                    sdc.AlarmType = 0;
                //}
                //else if (comboBox4.SelectedIndex == 1)
                //{
                    sdc.AlarmType = 1;
                //}
                //else if (comboBox4.SelectedIndex == 2)
                //{
                    sdc.AlarmType = 3;
                //}

                sdc.wai_outtime = Convert.ToSingle(r["wai_outtime"]);         //起弧延时时间
                sdc.wa_outtime = Convert.ToSingle(r["wa_outtime"]);          //报警延时时间
                sdc.waf_outtime = Convert.ToSingle(r["waf_outtime"]);      //停机冻结时间 
                sdc.wa_TJtime = Convert.ToSingle(r["wa_TJtime"]);           //停机延时时间

                sdc.dwai_outtime = Convert.ToSingle(r["dwai_outtime"]);        //修正周期
                sdc.dwa_up = 500;
                sdc.dwa_down = 30;
                //if (cobYiYuan.SelectedIndex == 1)
                //{
                    sdc.dwa_up = Convert.ToInt32(r["dwa_up"]);//焊接电流限流上限
                    sdc.dwa_down = Convert.ToInt32(r["dwa_down"]);//焊接电流限流下限
                //}
                sdc.dwaf_up = 500;
                sdc.dwaf_down = 30;
                sdc.dwaf_outtime = Convert.ToSingle(r["dwaf_outtime"]); //允许超限时间
                sdc.dwa_outtime = Convert.ToSingle(r["dwa_outtime"]);

                //更新设置规范函数
                _SD.Update(sdc);
                _SD.DownLoadStandard(Convert.ToInt32(r["nom"]), 1);
            }
        }
        //public void Down(DataTable data, int vtype)
        //{
        //    for (int i = 0; i < data.Rows.Count; i++)
        //    {
        //        DataRow r = data.Rows[i];
        //        //下传规范
        //        _SD.DownLoadStandard(Convert.ToInt32(r["nom"]), 1);
        //    }
        //}
        //public void LockChannel(DataTable data, int vtype)
        //{
        //    for (int i = 0; i < data.Rows.Count; i++)
        //    {
        //        DataRow r = data.Rows[i];
        //        //通道锁定
        //        _SD.DownLoadStandard(Convert.ToInt32(r["nom"]), 3);
        //    }
        //}
        //public void UnLock(DataTable data, int vtype)
        //{
        //    for (int i = 0; i < data.Rows.Count; i++)
        //    {
        //        DataRow r = data.Rows[i];
        //        //取消锁定
        //        _SD.DownLoadStandard(Convert.ToInt32(r["nom"]), 4); 

        //    }
        //}
    }
}
