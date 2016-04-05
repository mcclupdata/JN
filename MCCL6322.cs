using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HolisticDefine;

namespace MC
{
    public partial class MCCL6322 : Formbase
    {
        AutoSizeFormClass asc = new AutoSizeFormClass();
        SysDefine SD = new SysDefine();
        List<WeldInfo> listweldinfo = new List<WeldInfo>();
        protected DataTable _criterion;//焊接标准 
        DataTable _alldrvlist;
        DataTable _OTCalldrvlist;
        DataTable efManList_dt;
        int _changeflage = 0;
        int _fillflage = 0;
        int _ManufacturerIDflage = 0;
        public MCCL6322()
        {
            InitializeComponent();
            _fillflage = 1;
            _alldrvlist = this._wcfClient.ServiceCall(6032201, null);
            _OTCalldrvlist = this._wcfClient.ServiceCall(6033101, null);
            efManList_dt = _wcfClient.ServiceCall(509201, null);
        }

        private void efComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DataTable manu_rst = _wcfClient.ServiceCall(clsCMD.cmd_weldEquipManage_getParams, null);
            for (int i = 0; i < efManList_dt.Rows.Count; i++)
            {
                string nom = cobWeldNom.Text;
                if (nom == efManList_dt.Rows[i]["FweldEquipmentID"].ToString())
                {
                    if (efManList_dt.Rows[i]["FweldManufacturerID"].ToString() == "7")
                        _ManufacturerIDflage = 0;
                 
                    else if (efManList_dt.Rows[i]["FweldManufacturerID"].ToString() == "8")
                        _ManufacturerIDflage = 1;
                        
                }
            }
                if (_changeflage == 1)
                {

                    //提醒保存
                    if (MessageBox.Show(this, "提示", "数据已变更，是否保存?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        //调用保存
                        SaveParams();
                        _changeflage = 0;
                    }
                }
                //for (int i = 0; i < 30000; i++) ;
                RefreshConTrols();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);
            //DataGridViewInit();
            weldEquipmentbase webase = new weldEquipmentbase();
            webase.LoadweldEquipment2Tree(ref this.efManList);
            //加载准备数据
            //LoadweldEquipParams();
            //efManList_dt = _wcfClient.ServiceCall(clsCMD.cmd_weldEquipManage_get, null);
            cobWeldNom.Items.Add( efManList_dt.Rows[0]["FweldEquipmentID"].ToString());
            for (int i = 1; i < efManList_dt.Rows.Count; i++)
            {
                string s = efManList_dt.Rows[i]["FweldEquipmentID"].ToString();
                if (s != efManList_dt.Rows[i-1]["FweldEquipmentID"].ToString())
                    cobWeldNom.Items.Add(s);
            }
            cobWeldNom.SelectedIndex = 0;
            RefreshConTrols();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
            //this.WindowState = (System.Windows.Forms.FormWindowState)(2);//记录完控件的初始位置和大小后，再最大化
        }

        //private void efLabel25_Click(object sender, EventArgs e)
        //{

        //}

        private void efRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.efTabControl2.Enabled = false;
            this.efTabControl3.Enabled = false;
            //_changeflage = 1;
        }

        private void efRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.efTabControl2.Enabled = true;
            this.efTabControl3.Enabled = true;
            //_changeflage = 1;
        }

        private void efButton1_Click(object sender, EventArgs e)
        {
            //DataTable dt = this._wcfClient.ServiceCall(6032201, null);
            SaveParams();
        }
        /// <summary>
        /// 保存下发
        /// </summary>
        public void SaveParams()
        {
            int cmd = 6032801;
            DataRow sada = _alldrvlist.NewRow();
            if (_ManufacturerIDflage == 0)
            {
                cmd = 6032801;
                int vnom = Convert.ToInt32(this.cobWeldNom.Text);
                int vchannl = Convert.ToInt32(this.cobChannel.SelectedIndex);
                
                sada["nom"] = cobWeldNom.Text;
                sada["channel"] = (cobChannel.SelectedIndex + 1).ToString();
                string used = "0";
                if (efRadioButton1.Checked)
                    used = "1";
                sada["used"] = used;
                int vai_up = int.Parse(Textca.Text) + int.Parse(Textwca.Text);
                int vai_down = int.Parse(Textca.Text) - int.Parse(Textwca.Text);
                float vvi_up = float.Parse(Textcv.Text) + float.Parse(Textwcv.Text);
                float vvi_down = float.Parse(Textcv.Text) + float.Parse(Textwcv.Text);
                int va_up = int.Parse(Textha.Text) + int.Parse(Textwha.Text);
                int va_down = int.Parse(Textha.Text) - int.Parse(Textwha.Text);
                float vv_up = float.Parse(Texthv.Text) + float.Parse(Textwhv.Text);
                float vv_down = float.Parse(Texthv.Text) + float.Parse(Textwhv.Text);
                int vaf_up = int.Parse(Textsa.Text) + int.Parse(Textwsa.Text);
                int vaf_down = int.Parse(Textsa.Text) - int.Parse(Textwsa.Text);
                float vvf_up = float.Parse(Textsv.Text) + float.Parse(Textwsv.Text);
                float vvf_down = float.Parse(Textsv.Text) - float.Parse(Textwsv.Text);
                int dwai_up = int.Parse(efTextBox13.Text);
                int dwai_down = int.Parse(efTextBox14.Text);
                int wa_up = int.Parse(efTextBox45.Text);
                int wa_down = int.Parse(efTextBox48.Text);
                int wv_up = int.Parse(efTextBox60.Text);
                int wv_down = int.Parse(efTextBox62.Text);
                float wa_outtime = float.Parse(efTextBox53.Text);
                float wa_TJtime = float.Parse(efTextBox54.Text);
                float waf_outtime = float.Parse(efTextBox66.Text);
                //***************************超限判断*****************************************
                if (vai_up > 1000) vai_up = 1000; if (vai_up < 30) vai_up = 30;
                if (vai_down > 1000) vai_down = 1000; if (vai_down < 30) vai_down = 30;
                if (va_up > 1000) va_up = 1000; if (va_up < 30) va_up = 30;
                if (va_down > 1000) va_down = 1000; if (va_down < 30) va_down = 30;
                if (vaf_up > 1000) vaf_up = 1000; if (vaf_up < 30) vaf_up = 30;
                if (vaf_down > 1000) vaf_down = 1000; if (vaf_down < 30) vaf_down = 30;
                if (vvi_up > 48) vvi_up = 48; if (vvi_up < 10) vvi_up = 10;
                if (vvi_down > 48) vvi_down = 48; if (vvi_down < 10) vvi_down = 10;
                if (vv_up > 48) vv_up = 48; if (vv_up < 10) vv_up = 10;
                if (vv_down > 48) vv_down = 48; if (vv_down < 10) vv_down = 10;
                if (vvf_up > 48) vvf_up = 48; if (vvf_up < 10) vvf_up = 10;
                if (vvf_down > 48) vvf_down = 48; if (vvf_down < 10) vvf_down = 10;
                //电流补偿
                if (dwai_up > 50) dwai_up = 50; if (dwai_up < -50) dwai_up = -50;
                //电压补偿
                if (dwai_down > 5) dwai_down = 5; if (dwai_down < -5) dwai_down = -5;
                if (wa_up > 1000) wa_up = 1000; if (wa_up < 30) wa_up = 30;
                if (wa_down > 1000) wa_down = 1000; if (wa_down < 30) wa_down = 30;
                if (wa_outtime < 0.1) wa_outtime = 0.1f; if (wa_outtime > 25) wa_outtime = 25;
                if (waf_outtime < 0.1) waf_outtime = 0.1f; if (waf_outtime > 25) waf_outtime = 25;
                if (wa_TJtime < 0.1) wa_TJtime = 0.1f; if (wa_TJtime > 25) wa_TJtime = 25;

                if (wv_up > 48) wv_up = 48; if (wv_up < 10) wv_up = 10;
                if (wv_down > 48) wv_down = 48; if (wv_down < 10) wv_down = 10;
                //**************************************************************************
                sada["vai_up"] = vai_up.ToString();
                sada["vai_down"] = vai_down.ToString();
                sada["vvi_up"] = vvi_up.ToString();
                sada["vvi_down"] = vvi_down.ToString();
                try
                {
                    sada["va_up"] = va_up.ToString();
                    sada["va_down"] = va_down.ToString();
                }
                catch
                {
                    MessageBox.Show("焊接电流输入有误！", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    sada["vv_up"] = vv_up.ToString();
                    sada["vv_down"] = vv_down.ToString();
                }
                catch
                {
                    MessageBox.Show("焊接电压输入有误！", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                sada["vaf_up"] = vaf_up.ToString();
                sada["vaf_down"] = vaf_down.ToString();
                sada["vvf_up"] = vvf_up.ToString();
                sada["vvf_down"] = vvf_down.ToString();
                sada["wp"] = cobWP.SelectedIndex;
                sada["mt"] = cobMT.SelectedIndex;
                sada["mp"] = cobMP.SelectedIndex;
                sada["yiyuan"] = cobYiYuan.SelectedIndex;
                sada["wc"] = cobWC.SelectedIndex;
                sada["wd"] = cobWD.SelectedIndex;
                sada["pwtime"] = cobPWTime.SelectedIndex;
                try
                {
                    if ((int.Parse(efTextBox13.Text) >= -50 && int.Parse(efTextBox13.Text) <= 50) || (int.Parse(efTextBox14.Text) >= -5 && int.Parse(efTextBox14.Text) <= 5))
                    {
                        sada["dwai_up"] = dwai_up;
                        sada["dwai_down"] = dwai_down;
                    }
                    else
                    {
                        MessageBox.Show("电流电压补偿值设置有误！");
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("电流电压补偿值设置有误！");
                    return;
                }
                sada["backinfo"] = efTextBox12.Text;
                sada["wa_up"] = wa_up;
                sada["wa_down"] = wa_down;
                sada["wv_up"] = wv_up;
                sada["wv_down"] = wv_down;
                sada["AlarmType"] = cobAlm.Text;
                sada["wa_outtime"] = wa_outtime;
                sada["wa_TJtime"] = wa_TJtime;
                sada["waf_outtime"] = waf_outtime;
            }
            else if (_ManufacturerIDflage == 1)
            {
                cmd = 6033101;
                sada["nom"] = cobWeldNom.Text;
                sada["channel"] = (cobChannel.SelectedIndex + 1).ToString();
                sada["vai_up"] = Textca.ToString();//初期电流
                sada["vvi_up"] = Textcv.ToString();// 初期电压
                sada["va_down"] = Textwha.ToString();//焊接电流微调
                sada["va_up"] = Textha.ToString();//焊接电流
                sada["vaf_up"] = Textsa.ToString();//收弧电流
                sada["vaf_down"] = Textwsa.ToString();//守护电流微调
                sada["vv_down"] = Textwhv.ToString();//焊接电压微调
                sada["vv_up"] = Texthv.ToString();//焊接电压
                sada["vvf_up"] = Textsv.ToString();//收弧电压
                sada["vvf_down"] = Textwsv.ToString();//守护电压微调
                sada["wp"] = cobWP.SelectedIndex;
                sada["mt"] = cobMT.SelectedIndex;
                sada["mp"] = cobMP.SelectedIndex;
                sada["wc"] = cobWC.SelectedIndex;
                sada["wd"] = cobWD.SelectedIndex;
                sada["pwtime"] = cobPWTime.SelectedIndex;
            }
            DataTable editdt = _alldrvlist.Clone();//克隆表
            editdt.ImportRow(sada);
            editdt.AcceptChanges();
            DataTable rs = _wcfClient.ServiceCall(cmd, editdt);
            MessageBox.Show("保存成功", "", MessageBoxButtons.OK, MessageBoxIcon.None);
        }
        /// <summary>
        /// 刷新数据到form
        /// </summary>
        public void RefreshConTrols()
        {
            _fillflage = 0;
            if (_ManufacturerIDflage == 0)
            {
                try
                {
                    //DataTable dt = this._wcfClient.ServiceCall(6032201, null);
                    //    cobWeldNom.Items.Add(dt.Rows[0]["nom"].ToString());
                    //    for (int i = 1; i < dt.Rows.Count; i++)
                    //    {
                    //        string s = dt.Rows[i]["nom"].ToString();
                    //        if (s != dt.Rows[i - 1]["nom"].ToString())
                    //            cobWeldNom.Items.Add(s);
                    //    }
                    _changeflage = 0;
                    DataView dv = _alldrvlist.DefaultView;
                    string s = (cobChannel.SelectedIndex + 1).ToString();//通道
                    dv.RowFilter = "nom=" + cobWeldNom.Text + " and channel=" + s;
                    DataTable ndt = dv.ToTable();
                    if (ndt.Rows.Count == 1)
                    {
                        if (ndt.Rows[0]["used"].ToString() == "1")
                            efRadioButton1.Checked = true;
                        else if (ndt.Rows[0]["used"].ToString() == "0")
                            efRadioButton1.Checked = false;
                        string wca;
                        Textca.Text = imoth(ndt.Rows[0]["vai_up"].ToString(), ndt.Rows[0]["vai_down"].ToString(), out wca);//初期电流
                        Textwca.Text = wca;
                        string wcv;
                        Textcv.Text = vmoth(ndt.Rows[0]["vvi_up"].ToString(), ndt.Rows[0]["vvi_down"].ToString(), out wcv);//初期电压
                        Textwcv.Text = wcv;
                        string wha;
                        Textha.Text = imoth(ndt.Rows[0]["va_up"].ToString(), ndt.Rows[0]["va_down"].ToString(), out wha);//焊接电压
                        Textwha.Text = wha;
                        string whv;
                        Texthv.Text = vmoth(ndt.Rows[0]["vv_up"].ToString(), ndt.Rows[0]["vv_down"].ToString(), out whv);//焊接电流
                        Textwhv.Text = whv;
                        string wsa;
                        Textsa.Text = imoth(ndt.Rows[0]["vaf_up"].ToString(), ndt.Rows[0]["vaf_down"].ToString(), out wsa);//收弧电流
                        Textwsa.Text = wsa;
                        string wsv;
                        Textsv.Text = vmoth(ndt.Rows[0]["vvf_up"].ToString(), ndt.Rows[0]["vvf_down"].ToString(), out wsv);//收弧电压
                        Textwsv.Text = wsv;
                        cobWP.SelectedIndex = comboxsel(ndt.Rows[0]["wp"].ToString());//气体
                        cobMT.SelectedIndex = comboxsel(ndt.Rows[0]["mt"].ToString());//材质
                        cobMP.SelectedIndex = comboxsel(ndt.Rows[0]["wp"].ToString());//脉冲有无
                        cobYiYuan.SelectedIndex = comboxsel(ndt.Rows[0]["yiyuan"].ToString());//输出控制
                        cobWC.SelectedIndex = comboxsel(ndt.Rows[0]["wc"].ToString());//焊接控制
                        cobWD.SelectedIndex = comboxsel(ndt.Rows[0]["wd"].ToString());//丝径
                        cobPWTime.SelectedIndex = comboxsel(ndt.Rows[0]["pwtime"].ToString());//点焊时间
                        efTextBox12.Text = ndt.Rows[0]["backinfo"].ToString();//规范描述
                        efTextBox13.Text = ndt.Rows[0]["dwai_up"].ToString();//电流补偿
                        efTextBox14.Text = ndt.Rows[0]["dwai_down"].ToString();//电压补偿
                        efTextBox45.Text = ndt.Rows[0]["wa_up"].ToString();//报警电流上限
                        efTextBox48.Text = ndt.Rows[0]["wa_down"].ToString();//报警电流下限
                        efTextBox60.Text = ndt.Rows[0]["wv_up"].ToString();//报警电压上限
                        efTextBox62.Text = ndt.Rows[0]["wv_down"].ToString();//报警电压下限
                        //cobAlm.SelectedIndex = comboxsel(ndt.Rows[0]["AlarmType"].ToString());//报警模式选择
                        if (comboxsel(ndt.Rows[0]["AlarmType"].ToString()) == 0)
                        {
                            cobAlm.SelectedIndex = 0;
                        }
                        else if (comboxsel(ndt.Rows[0]["AlarmType"].ToString()) == 1)
                        {
                            cobAlm.SelectedIndex = 1;
                        }
                        else if (comboxsel(ndt.Rows[0]["AlarmType"].ToString()) == 3)
                        {
                            cobAlm.SelectedIndex = 2;
                        }
                        efTextBox53.Text = ndt.Rows[0]["wa_outtime"].ToString();//报警延时时间
                        efTextBox54.Text = ndt.Rows[0]["wa_TJtime"].ToString();//停机冻结时间
                        efTextBox66.Text = ndt.Rows[0]["waf_outtime"].ToString();//停机延时时间
                    }

                }
                catch
                {

                }
                _changeflage = 0;
                _fillflage = 1;
                return;
            }
            if (_ManufacturerIDflage == 1)
            {
                DataView dv = _OTCalldrvlist.DefaultView;
                string s = (cobChannel.SelectedIndex + 1).ToString();//通道
                dv.RowFilter = "MaschineId=" + cobWeldNom.Text + " and channel=" + s;
                DataTable ndt = dv.ToTable();
                if (ndt.Rows.Count == 1)
                {

                    Textca.Text = ndt.Rows[0]["StaElec"].ToString();//初期电流
                    Textcv.Text = ndt.Rows[0]["StaVolt"].ToString();// 初期电压
                    Textwha.Text = ndt.Rows[0]["WorkElec_Trim"].ToString();//焊接电流微调
                    Textha.Text = ndt.Rows[0]["WorkElec"].ToString();//焊接电流
                    Textsa.Text = ndt.Rows[0]["EndElec"].ToString();//收弧电流
                    Textwsa.Text = ndt.Rows[0]["EndElec_Trim"].ToString(); //守护电流微调
                    Textwhv.Text = ndt.Rows[0]["WorkVolt_Trim"].ToString(); //焊接电压微调
                    Texthv.Text = ndt.Rows[0]["WorkVolt"].ToString(); //焊接电压
                    Textsv.Text = ndt.Rows[0]["EndVolt"].ToString();//收弧电压
                    Textwsv.Text = ndt.Rows[0]["EndVolt_Trim"].ToString();//守护电压微调
                    cobWP.SelectedIndex = comboxsel(ndt.Rows[0]["GasType"].ToString());
                    cobMT.SelectedIndex = comboxsel(ndt.Rows[0]["StickMater"].ToString());
                    cobMP.SelectedIndex = comboxsel(ndt.Rows[0]["mp"].ToString());
                    cobWC.SelectedIndex = comboxsel(ndt.Rows[0]["wc"].ToString());
                    cobWD.SelectedIndex = comboxsel(ndt.Rows[0]["StickDiam"].ToString());
                    cobPWTime.SelectedIndex = comboxsel(ndt.Rows[0]["SpotTim"].ToString()); 
                }
                return;
            }
        }
        /// <summary>
        /// 初期焊接收弧电流计算
        /// </summary>
        /// <param name="a">up</param>
        /// <param name="b">down</param>
        /// <param name="wiv">微调</param>
        /// <returns>i</returns>
        public string imoth(string a, string b,out string wi)
        {
            int ii = (int.Parse(a) + int.Parse(b)) / 2;
            string i=ii.ToString();
            int wii = ii - int.Parse(b);
            wi = wii.ToString();
            return i;
        }
        /// <summary>
        /// 初期焊接收弧电压计算
        /// </summary>
        /// <param name="a">up</param>
        /// <param name="b">down</param>
        /// <param name="wv">微调</param>
        /// <returns>v</returns>
        public string vmoth(string a, string b, out string wv)
        {
            double vi = (double.Parse(a) + double.Parse(b)) / 2;
            string v = vi.ToString("0.0");
            double wvi = vi - double.Parse(b);
            wv = wvi.ToString("0.0");
            return v;
        }
        /// <summary>
        /// combox select
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public int comboxsel(string a)
        {
            int selnum;
            selnum = int.Parse(a);
            return selnum;
        }
       /// <summary>
       /// 通道选择发生变化(焊机变更通道变更为1)
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void cobWeldNom_changed(object sender, EventArgs e)
        {
            if (cobWeldNom.Items.Count > 0)
            {
                if (cobChannel.SelectedIndex==0)
                    efComboBox1_SelectedIndexChanged(this.cobChannel, null);
                else
                    cobChannel.SelectedIndex = 0;
                
            }
        }
        /// <summary>
        /// 处理非法字符
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void efTextBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == 13 || e.KeyChar == (char)8)
            {
                e.Handled = false;
            }
        }

        private void efTextBox14_KeyPress(object sender, KeyPressEventArgs e)
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
        /// <summary>
        /// 加载焊机基本参数
        /// </summary>
        protected void LoadweldEquipParams()
        {
            DataTable fdt = new DataTable();
            DataColumn col = new DataColumn();
            col.ColumnName = "params";
            col.DataType = typeof(int);
            fdt.Columns.Add(col);
            DataRow row = fdt.NewRow();
            row[0] = 0;
            fdt.Rows.Add(row);
            //加载焊机厂家
            DataTable manu_rst = _wcfClient.ServiceCall(clsCMD.cmd_weldEquipManage_getParams, fdt);
            //绑定
            //FweldManufacturerID.Properties.DataSource = manu_rst;
            //FweldManufacturerID.Properties.DisplayMember = "FName";
            //FweldManufacturerID.Properties.ValueMember = "FID";
            //if (manu_rst.Rows.Count > 0)
            //    FweldManufacturerID.ItemIndex = 0;
            //加载焊机归属
            //fdt.Rows[0][0] = 1;
            //DataTable departid_dt = _wcfClient.ServiceCall(clsCMD.cmd_weldEquipManage_getParams, fdt);
            //departid_dt.DefaultView.RowFilter = "IsWeld=1 ";
            //departid_dt = departid_dt.DefaultView.ToTable(true, "FID", "FDepartName");
            //FDepartID.Properties.DataSource = departid_dt;
            //FDepartID.Properties.DisplayMember = "FDepartName";
            //FDepartID.Properties.ValueMember = "FID";
            //if (departid_dt.Rows.Count > 0)
            //    FDepartID.ItemIndex = 0;
            //加载位置
            //DataTable point_dt = _wcfClient.ServiceCall(clsCMD.cmd_weldEquipment_weldPoint, null);
            //FDepartName.Properties.Items.Clear();
            //for (int i = 0; i < point_dt.Rows.Count; i++)
            //{
            //    FDepartName.Properties.Items.Add(point_dt.Rows[i][0].ToString());
            //}

            //if (point_dt.Rows.Count > 0)
            //    FDepartName.SelectedIndex = 0;
            //FState.SelectedIndex = 0;
            //加载松下/OTC焊机
            //DataTable welds_dt = _wcfClient.ServiceCall(clsCMD.cmd_weldEquipment_getBase_Bynom, null);
            //DataView welds_dv = welds_dt.DefaultView;
            //DataTable nwelds_dt = welds_dv.ToTable(true, "nom", "equipname");
            //FweldEquipmentID.Properties.DataSource = nwelds_dt;
            //FweldEquipmentID.Properties.DisplayMember = "equipname";
            //FweldEquipmentID.Properties.ValueMember = "nom";
            //if (welds_dt.Rows.Count > 0)
            //    FweldEquipmentID.ItemIndex = 0;
        }
        /// <summary>
        /// ListTree点击刷新界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        private void efManList_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            String nae = e.Node.Name;
            String key = e.Node.Text;
            if (e.Node.Name == e.Node.Text)
                return;
            String nom = e.Node.Name;
            int index =cobWeldNom.Items.IndexOf(nom);
            cobWeldNom.SelectedIndex = index;
        }
        /// <summary>
        /// 界面数据修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cobWP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_fillflage==1)
            _changeflage = 1;
        }

        private void efTextBox12_TextChanged(object sender, EventArgs e)
        {
            if (_fillflage == 1)
            _changeflage = 1;
        }     
        
    }
}