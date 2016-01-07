using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//引用dll
using HolisticDefine;

namespace JN_WELD_Service
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //引用HolisticDefine中的类
        //HolisticDefine包含SysDefine、WeldInfo、StandardDataClass三个类
        public SysDefine SD = new SysDefine();
        public List<WeldInfo> listweldinfo = new List<WeldInfo>();

        private void Form1_Load(object sender, EventArgs e)
        {
            DataGridViewInit();
        }

        //连接数据库
        private void button1_Click(object sender, EventArgs e)
        {
            if (SD.TestDB(textBox1.Text))
            {
                Console.WriteLine("连接成功");
                button2.Enabled = true;
            }
            else
            {
                Console.WriteLine("连接失败");
            }
        }

         //表格初始化
        public void DataGridViewInit()
        {
            //表格初始化操作
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            int Length = 32;
            string[] HeaderText = new string[32] { "焊机序号", "设备编号", "工作状态", "机型", "初期电流", "初期电压", "预置电流", "预置电压", "收弧电流", "收弧电压", "焊接电流", "焊接电压", "送丝速度", "气体", "材质", "丝径", "焊接控制", "脉冲有无", "点焊时间", "操作者", "故障类型", "任务编号","工件温度", "气体流量", "瞬时功率", "上传时间", "开机时间", "关机时间", "焊接时间", "工作时间", "当前通道", "通道数量" };
            string[] HeaderName = new string[32] { "nom", "equipname", "state", "name", "vai", "vvi", "va", "vv", "vaf", "vvf", "wa", "wv", "rpm", "wp", "mt", "wd", "wc", "mp", "pwtime", "emplon", "errnom", "PieceNum", "PieceTemp", "GasFlux", "Power", "NowTime", "StartTime", "EndTime", "weldTime", "workTime", "channel", "channelcount" };
            int[] HeaderWidth = new int[32] { 80, 80, 80, 80, 80, 80, 80, 80, 80, 80, 80, 80, 80, 60, 90, 80, 80, 80, 80, 80, 90, 130, 80, 80, 80, 120, 130, 130, 80, 80, 80, 80 };
            for (int i = 0; i < Length; i++)
            {
                dataGridView1.Columns.Add(HeaderName[i], HeaderText[i]);
                this.dataGridView1.Columns[i].Width = HeaderWidth[i];
                this.dataGridView1.Columns[i].DataPropertyName = HeaderName[i];
            }
        }

        //获取焊接信息
        public void button2_Click(object sender, EventArgs e)
        {
            listweldinfo = SD.SelectWeldInfo();


            //{ "焊机序号", "设备编号", "工作状态", "机型", "初期电流", "初期电压", "预置电流", "预置电压", "收弧电流", "收弧电压", "焊接电流", "焊接电压", "送丝速度", "气体", "材质", "丝径", "焊接控制", "脉冲有无", "点焊时间", "操作者", "故障类型", "任务编号","工件温度", "气体流量", "瞬时功率", "上传时间", "开机时间", "关机时间", "焊接时间", "工作时间", "当前通道", "通道数量" };
            //{ "nom", "equipname", "state", "name", "vai", "vvi", "va", "vv", "vaf", "vvf", "wa", "wv", "rpm", "wp", "mt", "wd", "wc", "mp", "pwtime", "emplon", "errnom", "PieceNum", "PieceTemp", "GasFlux", "Power", "NowTime", "StartTime", "EndTime", "weldTime", "workTime", "channel", "channelcount" };

            //
            String fields = "";
           // System.Reflection.PropertyInfo[] pis = t.GetProperties(System.Reflection.BindingFlags.Public);
            //焊机信息
            DataTable dt = new DataTable();
            Type t = typeof(WeldInfo);
            System.Reflection.FieldInfo[] pps = t.GetFields(System.Reflection.BindingFlags.Public|System.Reflection.BindingFlags.Instance);
            foreach (System.Reflection.FieldInfo ff in pps)
            {
                //fields += ff.Name + "  :  ";
                DataColumn col = new DataColumn();
                col.ColumnName = ff.Name;
                col.DataType = typeof(String);
                col.MaxLength = 50;
                dt.Columns.Add(col);

            }
            for (int i=0;i<listweldinfo.Count;i++)
            {
            //添加数据
                DataRow row=dt.NewRow();
                WeldInfo wi=listweldinfo[i];
                for (int k = 0; k < dt.Columns.Count; k++)
                {
                    String name = dt.Columns[k].ColumnName;
                   row[name]=Convert.ToString(t.GetField(name).GetValue(wi));
                }
                dt.Rows.Add(row);
            }
            //焊道信息
            DataTable chanDT = new DataTable();
            List<StandardDataClass> list_sdc = SD.SelectAll();
            Type chantt = typeof(StandardDataClass);
            System.Reflection.FieldInfo[] chanpps = chantt.GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            fields = "";
            foreach (System.Reflection.FieldInfo chanff in chanpps)
            {
                fields += chanff.Name + "  :  ";
                DataColumn col = new DataColumn();
                col.ColumnName = chanff.Name;
                col.DataType = typeof(String);
                col.MaxLength = 50;
                chanDT.Columns.Add(col);

            }
            for (int i = 0; i < list_sdc.Count; i++)
            {
                //添加数据
                DataRow row = chanDT.NewRow();
                StandardDataClass wi = list_sdc[i];
                for (int k = 0; k < chanDT.Columns.Count; k++)
                {
                    String name = chanDT.Columns[k].ColumnName;
                    row[name] = Convert.ToString(chantt.GetField(name).GetValue(wi));
                }
                chanDT.Rows.Add(row);
            }


                RefreshTable(listweldinfo);

            if (listweldinfo.Count > 0)
            {
                cobWeldNom.SelectedIndex = 0;
                button3.Enabled = true;
                button5.Enabled = true;
                button7.Enabled = true;
                button6.Enabled = true;
            }
        }

        //更新界面表格数据
        public void RefreshTable(List<WeldInfo> listweldinfo)
        {
            try
            {
                if (listweldinfo.Count != dataGridView1.Rows.Count)
                {
                    dataGridView1.Rows.Clear();
                    cobWeldNom.Items.Clear();
                    for (int i = 0; i < listweldinfo.Count; i++)
                    {
                        cobWeldNom.Items.Add(listweldinfo[i].nom);
                    }
                    dataGridView1.Rows.Add(listweldinfo.Count);
                    //设置表格行高
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        dataGridView1.Rows[i].Height = 17;
                    }
                }
                for (int i = 0; i < listweldinfo.Count; i++)
                {
                    dataGridView1.Rows[i].Cells["nom"].Value = listweldinfo[i].nom;//焊机序号
                    dataGridView1.Rows[i].Cells["equipname"].Value = listweldinfo[i].equipname;//设备编号
                    dataGridView1.Rows[i].Cells["state"].Value = listweldinfo[i].state;//工作状态
                    dataGridView1.Rows[i].Cells["name"].Value = listweldinfo[i].name;//机型
                    dataGridView1.Rows[i].Cells["vai"].Value = listweldinfo[i].vai;//初期电流
                    dataGridView1.Rows[i].Cells["vvi"].Value = listweldinfo[i].vvi;//初期电压
                    dataGridView1.Rows[i].Cells["va"].Value = listweldinfo[i].va;//预置电流
                    dataGridView1.Rows[i].Cells["vv"].Value = listweldinfo[i].vv;//预置电压
                    dataGridView1.Rows[i].Cells["vaf"].Value = listweldinfo[i].vaf;//收弧电流
                    dataGridView1.Rows[i].Cells["vvf"].Value = listweldinfo[i].vvf;//收弧电压
                    dataGridView1.Rows[i].Cells["wa"].Value = listweldinfo[i].wa;//焊接电流
                    dataGridView1.Rows[i].Cells["wv"].Value = listweldinfo[i].wv;//焊接电压
                    dataGridView1.Rows[i].Cells["rpm"].Value = listweldinfo[i].rpm;//送丝速度
                    dataGridView1.Rows[i].Cells["wp"].Value = listweldinfo[i].wp;//气体
                    dataGridView1.Rows[i].Cells["mt"].Value = listweldinfo[i].mt;//材质
                    dataGridView1.Rows[i].Cells["wd"].Value = listweldinfo[i].wd;//丝径
                    dataGridView1.Rows[i].Cells["wc"].Value = listweldinfo[i].wc;//焊接控制
                    dataGridView1.Rows[i].Cells["mp"].Value = listweldinfo[i].mp;//脉冲有无
                    dataGridView1.Rows[i].Cells["pwtime"].Value = listweldinfo[i].pwtime;//点焊时间
                    dataGridView1.Rows[i].Cells["emplon"].Value = listweldinfo[i].emplon;//操作者
                    dataGridView1.Rows[i].Cells["errnom"].Value = listweldinfo[i].errnom;//故障类型
                    dataGridView1.Rows[i].Cells["piecenum"].Value = listweldinfo[i].piecenum;//任务编号
                    dataGridView1.Rows[i].Cells["piecetemp"].Value = listweldinfo[i].piecetemp;//工件温度
                    dataGridView1.Rows[i].Cells["gasflux"].Value = listweldinfo[i].gasflux;//气体流量
                    dataGridView1.Rows[i].Cells["power"].Value = listweldinfo[i].power;//瞬时功率
                    dataGridView1.Rows[i].Cells["nowtime"].Value = listweldinfo[i].nowtime;//上传时间
                    dataGridView1.Rows[i].Cells["starttime"].Value = listweldinfo[i].starttime;//开机时间
                    dataGridView1.Rows[i].Cells["endtime"].Value = listweldinfo[i].endtime;//关机时间
                    dataGridView1.Rows[i].Cells["weldtime"].Value = listweldinfo[i].weldtime;//焊接时间
                    dataGridView1.Rows[i].Cells["worktime"].Value = listweldinfo[i].worktime;//工作时间
                    dataGridView1.Rows[i].Cells["channel"].Value = listweldinfo[i].channel;//当前通道
                    dataGridView1.Rows[i].Cells["channelcount"].Value = listweldinfo[i].channelcount;//通道数量
                }
            }
            catch
            { }
        }

        public void cobWeldNom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cobWeldNom.Items.Count > 0)
            {
                cobChannel.SelectedIndex = 0;
            }
        }

        public void cobChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshConTrols();
        }

        //更新规范界面数据
        public void RefreshConTrols()
        {
            //查询通道规范函数
            List<StandardDataClass> list_sdc = SD.SelectAll();

            try
            {
                for (int i = 0; i < list_sdc.Count; i++)
                {
                    if (int.Parse(cobWeldNom.Text) == list_sdc[i].nom && cobChannel.SelectedIndex + 1 == list_sdc[i].channel)
                    {
                        //通道禁用启用
                        if (list_sdc[i].used == 0)
                        {
                            radioButton1.Checked = false;
                            radioButton2.Checked = true;
                        }
                        else
                        {
                            radioButton1.Checked = true;
                            radioButton2.Checked = false;
                        }

                        cobWP.SelectedIndex = list_sdc[i].wp;//气体
                        cobMT.SelectedIndex = list_sdc[i].mt;//材质
                        cobWD.SelectedIndex = list_sdc[i].wd;//丝径

                        if (list_sdc[i].wc == 1)//焊接控制
                        {
                            cobWC.SelectedIndex = 0;
                        }
                        else if (list_sdc[i].wc == 3)
                        {
                            cobWC.SelectedIndex = 1;
                        }
                        else if (list_sdc[i].wc == 5)
                        {
                            cobWC.SelectedIndex = 2;
                        }
                        else if (list_sdc[i].wc == 2)
                        {
                            cobWC.SelectedIndex = 3;
                        }
                        else
                        {
                            cobWC.SelectedIndex = 0;
                        }

                        cobMP.SelectedIndex = list_sdc[i].mp;//脉冲有无
                        cobPWTime.Text = list_sdc[i].pwtime.ToString("0");//点焊时间
                        cobYiYuan.SelectedIndex = list_sdc[i].yiyuan;//输出控制

                        txtwa_up.Text = list_sdc[i].dwa_up.ToString();
                        txtwa_down.Text = list_sdc[i].dwa_down.ToString();
                        txtwa_ot.Text = list_sdc[i].dwa_outtime.ToString();
                        txtadf.Text = list_sdc[i].dwai_outtime.ToString();      //调整周期  单位 毫秒


                        //*******************************预置参数设置*******************************
                        txtvai.Text = ((list_sdc[i].vai_up + list_sdc[i].vai_down) / 2).ToString();
                        txtvai_wt.Text = ((list_sdc[i].vai_up + list_sdc[i].vai_down) / 2 - list_sdc[i].vai_down).ToString();
                        txtva.Text = ((list_sdc[i].va_up + list_sdc[i].va_down) / 2).ToString();
                        txtva_wt.Text = ((list_sdc[i].va_up + list_sdc[i].va_down) / 2 - list_sdc[i].va_down).ToString();
                        txtvaf.Text = ((list_sdc[i].vaf_up + list_sdc[i].vaf_down) / 2).ToString();
                        txtvaf_wt.Text = ((list_sdc[i].vaf_up + list_sdc[i].vaf_down) / 2 - list_sdc[i].vaf_down).ToString();
                        txtvvi.Text = ((list_sdc[i].vvi_up + list_sdc[i].vvi_down) / 2).ToString("0.0");
                        txtvvi_wt.Text = ((list_sdc[i].vvi_up + list_sdc[i].vvi_down) / 2 - list_sdc[i].vvi_down).ToString("0.0");
                        txtvv.Text = ((list_sdc[i].vv_up + list_sdc[i].vv_down) / 2).ToString("0.0");
                        txtvv_wt.Text = ((list_sdc[i].vv_up + list_sdc[i].vv_down) / 2 - list_sdc[i].vv_down).ToString("0.0");
                        txtvvf.Text = ((list_sdc[i].vvf_up + list_sdc[i].vvf_down) / 2).ToString("0.0");
                        txtvvf_wt.Text = ((list_sdc[i].vvf_up + list_sdc[i].vvf_down) / 2 - list_sdc[i].vvf_down).ToString("0.0");
                        textBox4.Text = list_sdc[i].backinfo;//规范描述
                        if (list_sdc[i].dwai_up > 50) list_sdc[i].dwai_up = 50;
                        if (list_sdc[i].dwai_up < -50) list_sdc[i].dwai_up = -50;
                        if (list_sdc[i].dwai_down > 5) list_sdc[i].dwai_down = 5;
                        if (list_sdc[i].dwai_down < -5) list_sdc[i].dwai_down = -5;
                        textBox2.Text = list_sdc[i].dwai_up.ToString();     //电流补偿值
                        textBox3.Text = list_sdc[i].dwai_down.ToString();   //电压补偿值

                        //*******************************报警参数设置*******************************
                        txtwabj_up.Text = list_sdc[i].wa_up.ToString();
                        txtwabj_down.Text = list_sdc[i].wa_down.ToString();
                        txt_BJtime.Text = list_sdc[i].wa_outtime.ToString();
                        txt_BJv_U.Text = list_sdc[i].wv_up.ToString();
                        txt_BJv_D.Text = list_sdc[i].wv_down.ToString();
                        txt_QHtime.Text = list_sdc[i].wai_outtime.ToString();
                        txt_TD_CoTime.Text = list_sdc[i].waf_outtime.ToString();
                        txt_TJtime.Text = list_sdc[i].wa_TJtime.ToString();

                        if (list_sdc[i].AlarmType == 0)
                        {
                            comboBox4.SelectedIndex = 0;
                        }
                        else if (list_sdc[i].AlarmType == 1)
                        {
                            comboBox4.SelectedIndex = 1;
                        }
                        else if (list_sdc[i].AlarmType == 3)
                        {
                            comboBox4.SelectedIndex = 2;
                        }                      
                    }
                }
            }
            catch
            { }
        }

        public void cobYiYuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            //分别状态下焊机不支持设置限流参数
            if (cobYiYuan.SelectedIndex == 0)
            {
                groupBox7.Visible = false;
            }
            else
            {
                groupBox7.Visible = true;
            }

        }

        //保存规范
        public void button3_Click(object sender, EventArgs e)
        {
            StandardDataClass sdc = new StandardDataClass();
            sdc.nom = int.Parse(cobWeldNom.Text);
            sdc.channel = cobChannel.SelectedIndex + 1;
            if (radioButton1.Checked) sdc.used = 1;
            if (radioButton2.Checked) sdc.used = 0;
            sdc.wp = cobWP.SelectedIndex;
            sdc.mt = cobMT.SelectedIndex;
            sdc.wd = cobWD.SelectedIndex;
            if (cobWC.SelectedIndex == 0)
            {
                sdc.wc = 1;
            }
            else if (cobWC.SelectedIndex == 1)
            {
                sdc.wc = 3;
            }
            else if (cobWC.SelectedIndex == 2)
            {
                sdc.wc = 5;
            }
            else if (cobWC.SelectedIndex == 3)
            {
                sdc.wc = 2;
            }
            sdc.yiyuan = cobYiYuan.SelectedIndex;

            sdc.mp = cobMP.SelectedIndex;
            sdc.pwtime = float.Parse(cobPWTime.Text);
            sdc.vai_up = Convert.ToInt32(Convert.ToDouble(txtvai.Text)) +Convert.ToInt32(Convert.ToDouble(txtvai_wt.Text));
            sdc.vai_down = Convert.ToInt32(Convert.ToDouble(txtvai.Text)) - Convert.ToInt32(Convert.ToDouble(txtvai_wt.Text));
            sdc.va_up = Convert.ToInt32(Convert.ToDouble(txtva.Text)) + Convert.ToInt32(Convert.ToDouble(txtva_wt.Text));
            sdc.va_down = Convert.ToInt32(Convert.ToDouble(txtva.Text)) - Convert.ToInt32(Convert.ToDouble(txtva_wt.Text));
            sdc.vaf_up = Convert.ToInt32(Convert.ToDouble(txtvaf.Text)) + Convert.ToInt32(Convert.ToDouble(txtvaf_wt.Text));
            sdc.vaf_down = Convert.ToInt32(Convert.ToDouble(txtvaf.Text)) - Convert.ToInt32(Convert.ToDouble(txtvaf_wt.Text));

            sdc.vvi_up = float.Parse(txtvvi.Text) + float.Parse(txtvvi_wt.Text);
            sdc.vvi_down = float.Parse(txtvvi.Text) - float.Parse(txtvvi_wt.Text);
            sdc.vv_up = float.Parse(txtvv.Text) + float.Parse(txtvv_wt.Text);
            sdc.vv_down = float.Parse(txtvv.Text) - float.Parse(txtvv_wt.Text);
            sdc.vvf_up = float.Parse(txtvvf.Text) + float.Parse(txtvvf_wt.Text);
            sdc.vvf_down = float.Parse(txtvvf.Text) - float.Parse(txtvvf_wt.Text);

            try
            {
                if ((Convert.ToInt32(Convert.ToDouble(textBox2.Text)) >= -50 && Convert.ToInt32(Convert.ToDouble(textBox2.Text)) <= 50) || (Convert.ToInt32(Convert.ToDouble(textBox3.Text)) >= -5 && Convert.ToInt32(Convert.ToDouble(textBox3.Text)) <= 5))
                {
                    sdc.dwai_up = int.Parse(textBox2.Text);
                    sdc.dwai_down = int.Parse(textBox3.Text);
                }
                else
                {
                    Console.WriteLine("电流电压补偿值设置有误！");
                    return;
                }
            }
            catch
            {
                Console.WriteLine("电流电压补偿值设置有误！");
                return;
            }

            sdc.backinfo = textBox4.Text;

            //报警参数设置
            sdc.wa_up = int.Parse(txtwabj_up.Text);
            sdc.wa_down = int.Parse(txtwabj_down.Text);
            sdc.wv_up = float.Parse(txt_BJv_U.Text);
            sdc.wv_down = float.Parse(txt_BJv_D.Text);

            //不启用
            //只报警
            //报警停机
            if (comboBox4.SelectedIndex == 0)
            {
                sdc.AlarmType = 0;
            }
            else if (comboBox4.SelectedIndex == 1)
            {
                sdc.AlarmType = 1;
            }
            else if (comboBox4.SelectedIndex == 2)
            {
                sdc.AlarmType = 3;
            }

            sdc.wai_outtime = float.Parse(txt_QHtime.Text);         //起弧延时时间
            sdc.wa_outtime = float.Parse(txt_BJtime.Text);          //报警延时时间
            sdc.waf_outtime = float.Parse(txt_TD_CoTime.Text);      //停机冻结时间 
            sdc.wa_TJtime = float.Parse(txt_TJtime.Text);           //停机延时时间

            sdc.dwai_outtime = float.Parse(txtadf.Text);        //修正周期
            sdc.dwa_up = 500;
            sdc.dwa_down = 30;
            if (cobYiYuan.SelectedIndex == 1)
            {
                sdc.dwa_up = int.Parse(txtwa_up.Text);//焊接电流限流上限
                sdc.dwa_down = int.Parse(txtwa_down.Text);//焊接电流限流下限
            }
            sdc.dwaf_up = 500;
            sdc.dwaf_down = 30;
            sdc.dwaf_outtime = float.Parse(txtwa_ot.Text); //允许超限时间
            sdc.dwa_outtime = float.Parse(txtwa_ot.Text);

            //***************************超限判断*****************************************
            if (sdc.vai_up > 1000) sdc.vai_up = 1000; if (sdc.vai_up < 30) sdc.vai_up = 30;
            if (sdc.vai_down > 1000) sdc.vai_down = 1000; if (sdc.vai_down < 30) sdc.vai_down = 30;
            if (sdc.va_up > 1000) sdc.va_up = 1000; if (sdc.va_up < 30) sdc.va_up = 30;
            if (sdc.va_down > 1000) sdc.va_down = 1000; if (sdc.va_down < 30) sdc.va_down = 30;
            if (sdc.vaf_up > 1000) sdc.vaf_up = 1000; if (sdc.vaf_up < 30) sdc.vaf_up = 30;
            if (sdc.vaf_down > 1000) sdc.vaf_down = 1000; if (sdc.vaf_down < 30) sdc.vaf_down = 30;
            if (sdc.vvi_up > 48) sdc.vvi_up = 48; if (sdc.vvi_up < 10) sdc.vvi_up = 10;
            if (sdc.vvi_down > 48) sdc.vvi_down = 48; if (sdc.vvi_down < 10) sdc.vvi_down = 10;
            if (sdc.vv_up > 48) sdc.vv_up = 48; if (sdc.vv_up < 10) sdc.vv_up = 10;
            if (sdc.vv_down > 48) sdc.vv_down = 48; if (sdc.vv_down < 10) sdc.vv_down = 10;
            if (sdc.vvf_up > 48) sdc.vvf_up = 48; if (sdc.vvf_up < 10) sdc.vvf_up = 10;
            if (sdc.vvf_down > 48) sdc.vvf_down = 48; if (sdc.vvf_down < 10) sdc.vvf_down = 10;

            if (sdc.dwa_up > 1000) sdc.dwa_up = 1000; if (sdc.dwa_up < 30) sdc.dwa_up = 30;
            if (sdc.dwa_down > 1000) sdc.dwa_down = 1000; if (sdc.dwa_down < 30) sdc.dwa_down = 30;

            //电流补偿
            if (sdc.dwai_up > 50) sdc.dwai_up = 50; if (sdc.dwai_up < -50) sdc.dwai_up = -50;
            //电压补偿
            if (sdc.dwai_down > 5) sdc.dwai_down = 5; if (sdc.dwai_down < -5) sdc.dwai_down = -5; 

            if (sdc.dwaf_up > 1000) sdc.dwaf_up = 1000; if (sdc.dwaf_up < 30) sdc.dwaf_up = 30;
            if (sdc.dwaf_down > 1000) sdc.dwaf_down = 1000; if (sdc.dwaf_down < 30) sdc.dwaf_down = 30;

            if (sdc.dwa_outtime < 0.1) sdc.dwa_outtime = 0.1f; if (sdc.dwa_outtime > 10) sdc.dwa_outtime = 10;
            if (sdc.dwaf_outtime < 0.1) sdc.dwaf_outtime = 0.1f; if (sdc.dwaf_outtime > 10) sdc.dwaf_outtime = 10;
            if (sdc.dwai_outtime < 10) sdc.dwai_outtime = 10; if (sdc.dwai_outtime > 500) sdc.dwai_outtime = 500;

            if (sdc.wa_up > 1000) sdc.wa_up = 1000; if (sdc.wa_up < 30) sdc.wa_up = 30;
            if (sdc.wa_down > 1000) sdc.wa_down = 1000; if (sdc.wa_down < 30) sdc.wa_down = 30;
            if (sdc.wa_outtime < 0.1) sdc.wa_outtime = 0.1f; if (sdc.wa_outtime > 25) sdc.wa_outtime = 25;
            if (sdc.waf_outtime < 0.1) sdc.waf_outtime = 0.1f; if (sdc.waf_outtime > 25) sdc.waf_outtime = 25;
            if (sdc.wa_TJtime < 0.1) sdc.wa_TJtime = 0.1f; if (sdc.wa_TJtime > 25) sdc.wa_TJtime = 25;

            if (sdc.wv_up > 48) sdc.wv_up = 48; if (sdc.wv_up < 10) sdc.wv_up = 10;
            if (sdc.wv_down > 48) sdc.wv_down = 48; if (sdc.wv_down < 10) sdc.wv_down = 10;
            if (sdc.wai_outtime < 0) sdc.wai_outtime = 0f; if (sdc.wai_outtime > 3) sdc.wai_outtime = 3;
            //**************************************************************************

           //更新设置规范函数
           SD.Update(sdc);
        }

        //下传规范
        public void button5_Click(object sender, EventArgs e)
        {
            int WeldNom = int.Parse(cobWeldNom.Text);
            if (listweldinfo[cobWeldNom.SelectedIndex].state != "报警" && listweldinfo[cobWeldNom.SelectedIndex].state != "关闭")
            {
                //下传规范函数
                SD.DownLoadStandard(WeldNom, 1);
                Console.WriteLine("参数下载成功！");
            }
        }

        //通道锁定
        public void button7_Click(object sender, EventArgs e)
        {
            int WeldNom = int.Parse(cobWeldNom.Text);
            if (listweldinfo[cobWeldNom.SelectedIndex].state != "报警" && listweldinfo[cobWeldNom.SelectedIndex].state != "关闭")
            {
                //下传规范函数
                SD.DownLoadStandard(WeldNom, 3);
                Console.WriteLine("规范下载成功！");
            }
        }

        //取消锁定
        private void button6_Click(object sender, EventArgs e)
        {
            int WeldNom = int.Parse(cobWeldNom.Text);
            if (listweldinfo[cobWeldNom.SelectedIndex].state != "报警" && listweldinfo[cobWeldNom.SelectedIndex].state != "关闭")
            {
                //下传规范函数
                SD.DownLoadStandard(WeldNom, 4);
            }
        }

        //处理文本框中的非法字符
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == 13 || e.KeyChar == (char)8)
            {
                e.Handled = false;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x20 || e.KeyChar == ',')
            {
                e.KeyChar = (char)0;  //禁止空格键及逗号
            }
            if ((e.KeyChar == 0x2D) && (((TextBox)sender).Text.Length == 0))
            {
                //处理负数
            }
            if (e.KeyChar > 0x20)
            {
                try
                {
                    double.Parse(((TextBox)sender).Text + e.KeyChar.ToString());
                }
                catch
                {
                    e.KeyChar = (char)0;   //处理非法字符
                }
            }
        }

        private void textBox2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == 13 || e.KeyChar == (char)8 || ((e.KeyChar == 0x2D) && (((TextBox)sender).Text.Length == 0)))
            {
                e.Handled = false;
            }
        }

        private void textBox3_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x20 || e.KeyChar == ',')
            {
                e.KeyChar = (char)0;  //禁止空格键及逗号
            }
            if ((e.KeyChar == 0x2D) && (((TextBox)sender).Text.Length == 0))
            {
                //处理负数
                e.KeyChar = (char)0x2D;   //处理非法字符
            }
            else if (e.KeyChar > 0x20)
            {
                try
                {
                    double.Parse(((TextBox)sender).Text + e.KeyChar.ToString());
                }
                catch
                {
                    e.KeyChar = (char)0;   //处理非法字符
                }
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(278, 245);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.ResumeLayout(false);
            InitializeComponent1();

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

    }
}
