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
    class panasonicDevices : JN_WELD_Service.IDevices
    {
        Form1 _frm = new Form1();
        public int _DriversID = 0;
        public int _DriverChannID = 0;
        public panasonicDevices()
        {
            String sxip = "";
            INIClass incls = new INIClass();
            sxip = incls.getPQMDIP();
            _frm.SD.TestDB(sxip);
        }
        /// <summary>
        /// 获取松下焊机及其状态
        /// </summary>
        /// <returns></returns>
        public DataTable GetDrives()
        {
            //{ "焊机序号", "设备编号", "工作状态", "机型", "初期电流", "初期电压", "预置电流", "预置电压", "收弧电流", "收弧电压", "焊接电流", "焊接电压", "送丝速度", "气体", "材质", "丝径", "焊接控制", "脉冲有无", "点焊时间", "操作者", "故障类型", "任务编号","工件温度", "气体流量", "瞬时功率", "上传时间", "开机时间", "关机时间", "焊接时间", "工作时间", "当前通道", "通道数量" };
            //{ "nom", "equipname", "state", "name", "vai", "vvi", "va", "vv", "vaf", "vvf", "wa", "wv", "rpm", "wp", "mt", "wd", "wc", "mp", "pwtime", "emplon", "errnom", "PieceNum", "PieceTemp", "GasFlux", "Power", "NowTime", "StartTime", "EndTime", "weldTime", "workTime", "channel", "channelcount" };
            List<WeldInfo> listweldinfo = _frm.SD.SelectWeldInfo();
            //
            String fields = "";
            // System.Reflection.PropertyInfo[] pis = t.GetProperties(System.Reflection.BindingFlags.Public);
            //焊机信息
            DataTable dt = new DataTable();
            Type t = typeof(WeldInfo);
            System.Reflection.FieldInfo[] pps = t.GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            foreach (System.Reflection.FieldInfo ff in pps)
            {
                //fields += ff.Name + "  :  ";
                DataColumn col = new DataColumn();
                col.ColumnName = ff.Name;
                col.DataType = typeof(String);
                col.MaxLength = 50;
                dt.Columns.Add(col);

            }
            for (int i = 0; i < listweldinfo.Count; i++)
            {
                //添加数据
                DataRow row = dt.NewRow();
                WeldInfo wi = listweldinfo[i];
                for (int k = 0; k < dt.Columns.Count; k++)
                {
                    String name = dt.Columns[k].ColumnName;
                    row[name] = Convert.ToString(t.GetField(name).GetValue(wi));
                }
                dt.Rows.Add(row);
            }
            return dt;
            //焊道信息
        }
        /// <summary>
        /// 获取松下焊机的通道参数配置
        /// </summary>
        /// <returns></returns>
        public DataTable GetDrivesChannelInfos()
        {
            DataTable chanDT = new DataTable();
            List<StandardDataClass> list_sdc = _frm.SD.SelectAll();
            Type chantt = typeof(StandardDataClass);
            System.Reflection.FieldInfo[] chanpps = chantt.GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            
            foreach (System.Reflection.FieldInfo chanff in chanpps)
            {
                
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
            return chanDT;
        }
        public void show()
        {
           // _frm.Show();
        }
        /// <summary>
        /// 检测焊机自身的WPS参数是否存在符合要求的，如存在则返回其通道号
        /// </summary>
        /// <param name="row"></param>
        /// <param name="WeldDevice"></param>
        /// <returns></returns>
        public int testEqumsChannelparams(DataRow row, String WeldDevice)
        {

            int nom = 0;
            int channelid = 0;
            nom = Convert.ToInt32(WeldDevice);// Convert.ToInt32(row["FweldDriverID"]);
            channelid = Convert.ToInt32(row["WELD_PASS"]);

            //判断当前焊机中将要使用的通道参数是否匹配


            //DataTable welddevices = GetPanasoicDrivesChannelInfos();

            //DataView tmpdv = welddevices.DefaultView;
            //tmpdv.RowFilter = "nom=" + WeldDevice + " and channel="+channelid;
            //DataTable pdt = tmpdv.ToTable();



            //String sxip = "";
            //INIClass incls = new INIClass();
            //sxip = incls.getPQMDIP();
            //_frm.SD.TestDB(sxip);

            //获取焊机信息

            _frm.button2_Click(null, null);
            //切换焊机
            for (int i = 0; i < _frm.cobWeldNom.Items.Count; i++)
            {
                if (Convert.ToInt32(_frm.cobWeldNom.Items[i]) == nom)
                {
                    _frm.cobWeldNom.SelectedIndex = i;
                }
            }
            //调用cobWeldNom变更谢欢
            _frm.cobWeldNom_SelectedIndexChanged(_frm.cobWeldNom, null);
            //选定通道
            //检测当前焊机的默认WPS是否符合要求
            int isexits = 0;
            for (int i = 0; i < _frm.cobChannel.Items.Count; i++)
            {
                _frm.cobChannel.SelectedIndex = i;

                _frm.cobChannel_SelectedIndexChanged(_frm.cobChannel, null);

                //检测条件是否匹配；
                double va, vv, iva, ivv, vvmx, vvmi, vimx, vimi, vib, vvb;
                double ivvmx, ivvmi, ivimx, ivimi, ivib, ivvb, iirang, ivrang;

                va = Convert.ToDouble(_frm.txtva.Text);
                vv = Convert.ToDouble(_frm.txtvv.Text);



                iva = Convert.ToDouble(row["WELD_I"]);
                ivv = Convert.ToDouble(row["WELD_V"]);





                //vimi = Convert.ToDouble(row["WELD_I_MIN"]);
                //vimx = Convert.ToDouble(row["WELD_I_MAX"]);
                //vvmx = Convert.ToDouble(row["WELD_V_MAX"]);
                //vvmi = Convert.ToDouble(row["WELD_V_MIN"]);
                //vib = Convert.ToDouble(row["WELD_V"]);
                //vvb = Convert.ToDouble(row["WELD_V"]);
                //double virang = Convert.ToDouble((vimx - vimi) / 2);
                //double vvrang = Convert.ToDouble((vvmx - vvmi) / 2);
                ////
                //iirang = Convert.ToDouble(_frm.txtva_wt.Text);// = irang.ToString();
                //ivrang = double.Parse(_frm.txtvv_wt.Text);//= vrang.ToString();


                //ivimx = Convert.ToDouble(_frm.txtwabj_up.Text);//= imx.ToString();
                //ivimi = Convert.ToDouble(_frm.txtwabj_down.Text); //= imi.ToString();
                //ivvmx = Convert.ToDouble(_frm.txt_BJv_U.Text);// = vmx.ToString();
                //ivvmi = Convert.ToDouble(_frm.txt_BJv_D.Text);// = vmi.ToString();
                //ivimx = Convert.ToDouble(_frm.txtwa_up.Text);//= imx.ToString();
                //ivimi = Convert.ToDouble(_frm.txtwa_down.Text);// = imi.ToString();

                double eqva,eqvv;
                eqva=Convert.ToDouble(_frm.txtva.Text);
                eqvv=Convert.ToDouble(_frm.txtvv.Text);
                //if (Convert.ToDouble(System.Math.Abs((vimx - ivimx))) == 0 && Convert.ToDouble(System.Math.Abs((vimi - ivimi))) == 0 && Convert.ToDouble(System.Math.Abs((vvmx - ivvmx))) == 0 && Convert.ToDouble(System.Math.Abs((vvmi - ivvmi))) == 0)
                if (System.Math.Abs(Convert.ToDouble(iva - eqva)) < 0.5 && System.Math.Abs(Convert.ToDouble(ivv - eqvv)) < 0.5)
                {
                    //命中;
                    return i+1;
                }
                

            }
            return 0;
        }
        /// <summary>
        /// 下载参数;
        /// </summary>
        /// <param name="row"></param>
        /// <param name="WeldDevice"></param>
        public void changeset(ref  DataRow row,String WeldDevice)
        {
            //_frm.SD.TestDB("127.0.0.1");//链接数据库

            int nom = 0;
            int channelid = 0;
            nom =Convert.ToInt32( WeldDevice);// Convert.ToInt32(row["FweldDriverID"]);
            channelid = Convert.ToInt32(row["WELD_PASS"]);

            //判断当前焊机中将要使用的通道参数是否匹配


            //DataTable welddevices = GetPanasoicDrivesChannelInfos();

            //DataView tmpdv = welddevices.DefaultView;
            //tmpdv.RowFilter = "nom=" + WeldDevice + " and channel="+channelid;
            //DataTable pdt = tmpdv.ToTable();



            //String sxip = "";
            //INIClass incls = new INIClass();
            //sxip = incls.getPQMDIP();
            //_frm.SD.TestDB(sxip);

            //获取焊机信息
            
            _frm.button2_Click(null, null);
            //切换焊机
            for (int i = 0; i < _frm.cobWeldNom.Items.Count;i++ )
            {
                if (Convert.ToInt32(_frm.cobWeldNom.Items[i]) == nom)
                {
                    _frm.cobWeldNom.SelectedIndex = i;
                }
            }

            //调用cobWeldNom变更谢欢
            _frm.cobWeldNom_SelectedIndexChanged(_frm.cobWeldNom, null);


            //选定通道
            if (_frm.cobChannel.Items.Count < channelid)
            {
                Console.WriteLine(String.Format("准备焊道为{0},焊机最大通道数{1} 因此不能下载", channelid, _frm.cobChannel.Items.Count));
                return;
            }

            _frm.cobChannel.SelectedIndex = channelid-1;

            _frm.cobChannel_SelectedIndexChanged(_frm.cobChannel, null);

            //检测当前焊机的默认WPS是否符合要求
            int isexits = 0;
            //for (int i = 0; i < _frm.cobChannel.Items.Count; i++)
            //{
            //    _frm.cobChannel.SelectedIndex = i;

            //    _frm.cobChannel_SelectedIndexChanged(_frm.cobChannel, null);

                //检测条件是否匹配；
                //double va, vv, iva, ivv, vvmx, vvmi, vimx, vimi, vib, vvb;
                //double ivvmx, ivvmi, ivimx, ivimi, ivib, ivvb, iirang, ivrang;
                //va = Convert.ToDouble(_frm.txtva.Text);
                //vv = Convert.ToDouble(_frm.txtvv.Text);


                double iva,ivv;
                iva = Convert.ToDouble(row["WELD_I"]);
                ivv = Convert.ToDouble(row["WELD_V"]);





                //vimi = Convert.ToDouble(row["WELD_I_MIN"]);
                //vimx = Convert.ToDouble(row["WELD_I_MAX"]);
                //vvmx = Convert.ToDouble(row["WELD_V_MAX"]);
                //vvmi = Convert.ToDouble(row["WELD_V_MIN"]);
                //vib = Convert.ToDouble(row["WELD_V"]);
                //vvb = Convert.ToDouble(row["WELD_V"]);
                //double virang = Convert.ToDouble((vimx - vimi) / 2);
                //double vvrang = Convert.ToDouble((vvmx - vvmi) / 2);
                ////
                //iirang = Convert.ToDouble(_frm.txtva_wt.Text);// = irang.ToString();
                //ivrang = double.Parse(_frm.txtvv_wt.Text);//= vrang.ToString();


                //ivimx = Convert.ToDouble(_frm.txtwabj_up.Text);//= imx.ToString();
                //ivimi = Convert.ToDouble(_frm.txtwabj_down.Text); //= imi.ToString();
                //ivvmx = Convert.ToDouble(_frm.txt_BJv_U.Text);// = vmx.ToString();
                //ivvmi = Convert.ToDouble(_frm.txt_BJv_D.Text);// = vmi.ToString();
                //ivimx = Convert.ToDouble(_frm.txtwa_up.Text);//= imx.ToString();
                //ivimi = Convert.ToDouble(_frm.txtwa_down.Text);// = imi.ToString();
                double eqva, eqvv;
                eqva = Convert.ToDouble(_frm.txtva.Text);
                eqvv = Convert.ToDouble(_frm.txtvv.Text);
                //if (Convert.ToDouble(System.Math.Abs((vimx - ivimx))) == 0 && Convert.ToDouble(System.Math.Abs((vimi - ivimi))) == 0 && Convert.ToDouble(System.Math.Abs((vvmx - ivvmx))) == 0 && Convert.ToDouble(System.Math.Abs((vvmi - ivvmi))) == 0)
                if (System.Math.Abs(Convert.ToDouble(iva - eqva)) < 0.5 && System.Math.Abs(Convert.ToDouble(ivv - eqvv)) < 0.5)
                {
                    row["FActChannel"] = channelid; 
                     Console.WriteLine(String.Format("焊道{0}参数,命中通道{0},无需下载",channelid,channelid));
                    return ;
                }


            //}
            //没有命中，则下载WPS数据；
            _frm.cobChannel.SelectedIndex = channelid - 1;
            _frm.cobChannel_SelectedIndexChanged(_frm.cobChannel, null);



            row["FActChannel"] = channelid;
            if (Convert.ToInt64(row["FWELDWPSID"]) > -100)
            {
                //测试修改一个值，然后进行修改；

                //---药芯碳钢
                //WELD_MATERIAL	String	cobMT
                int dcid = Convert.ToInt32(row["WELD_PASS"]);

               // _frm.cobChannel.SelectedIndex = dcid;

                _frm.cobChannel_SelectedIndexChanged(null, null);

                //材质
                for (int i = 0; i < _frm.cobMT.Items.Count; i++)
                {
                    if (_frm.cobMT.Items[0].ToString() == Convert.ToString(row["WELD_MATERIAL"]))
                        _frm.cobMT.SelectedIndex = i;

                }

                //WELD_WIRE_DIA	Decimal	cobWD
                //丝径
                for (int i = 0; i < _frm.cobWD.Items.Count; i++)
                {
                    if (_frm.cobWD.Items[i].ToString()== Convert.ToString(row["WELD_WIRE_DIA"]))
                        _frm.cobWD.SelectedIndex = i;

                }

                //WELD_I	Decimal	txtva
                //焊接电流
                _frm.txtva.Text = Convert.ToString(row["WELD_I"]);
                //WELD_V	Decimal	txtvv
                //焊接电压
                _frm.txtvv.Text = Convert.ToString(row["WELD_V"]);
                //WELD_I_MAX	Decimal	txtwa_up
                //焊接电流上限
                _frm.txtwa_up.Text = Convert.ToString(row["WELD_I_MAX"]);
                //WELD_I_MIN	Decimal	txtwa_down
                //焊接电流下限
                _frm.txtwa_down.Text = Convert.ToString(row["WELD_I_MIN"]);
                //CLOSEING_I	Decimal	txtvaf
                //收弧电流
                _frm.txtvaf.Text = Convert.ToString(row["CLOSEING_I"]);
                //CLOSEING_V	Decimal	txtvvf
                //收弧电压
                _frm.txtvvf.Text = Convert.ToString(row["CLOSEING_V"]);
                //PLUS	int	cobMP
                int imx = 0, imi = 0, vmx = 0, vmi = 0, ib = 0, vb = 0;
                imi = Convert.ToInt32(row["WELD_I_MIN"]);
                imx = Convert.ToInt32(row["WELD_I_MAX"]);
                vmx = Convert.ToInt32(row["WELD_V_MAX"]);
                vmi = Convert.ToInt32(row["WELD_V_MIN"]);
                ib = Convert.ToInt32(row["WELD_V"]);
                vb = Convert.ToInt32(row["WELD_V"]);
                int irang = (imx-imi) / 2;
                int vrang = (vmx-vmi) / 2;
                //
                //焊接电流微调
                _frm.txtva_wt.Text = irang.ToString();
                //焊接电压微调
                _frm.txtvv_wt.Text = vrang.ToString();
                //焊接电流报警上
                _frm.txtwabj_up.Text = imx.ToString();
                //焊接电流报警下
                _frm.txtwabj_down.Text = imi.ToString();
                //焊接电压报警上下限
                _frm.txt_BJv_U.Text = vmx.ToString();
                _frm.txt_BJv_D.Text = vmi.ToString();
                //焊接电流上限
                _frm.txtwa_up.Text = imx.ToString();
                _frm.txtwa_down.Text = imi.ToString();

                //_frm.cobMP.SelectedText = Convert.ToString(row["PLUS"]);
                //有无脉冲
                for (int i = 0; i < _frm.cobMP.Items.Count; i++)
                {
                    if (_frm.cobMP.Items[i].ToString() == Convert.ToString(row["PLUS"]))
                        _frm.cobMP.SelectedIndex = i;

                }
                //FWELDWPSID WELD_MATERIAL,WELD_WIRE_DIA,WELD_I,WELD_V,WELD_I_MAX,WELD_I_MIN,CLOSEING_I
                //,CLOSEING_V,PLUS
                //_frm.ShowDialog();
                
            }
            //保存参数
            _frm.button3_Click(null, null);
            //下载参数
            Thread.Sleep(3000);
            _frm.button5_Click(null, null);
            Thread.Sleep(2000);
            //_DriversID = int.Parse(_frm.cobWeldNom.Text);
            //_DriverChannID = _frm.cobChannel.SelectedIndex + 1;
            _frm.button7_Click(null, null);

        }
        ~panasonicDevices()
        {
            _frm.Dispose();
        }

        
    }
}
