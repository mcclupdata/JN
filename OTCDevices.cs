using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
namespace JN_WELD_Service
{
    
    class OTCDevices:IDevices
    {
        static System.ServiceModel.BasicHttpBinding _basehttpbinding;
        static OTCweldService.SetCardPortTypeClient _otcClient;
        static String OTCServiceDress;
        static int Maxchannel;

        static String[]  GasType={"CO2","MAG","MIG-Ar98%-2%O2"};//：气体类型，数值类型，0：CO2；1：MAG，3 ：MIG-Ar98%-2%O2
        //static StickDiam[]：焊丝直径，数值类型，10：Φ1.0；12：Φ1.2，14 ：Φ1.4，16：Φ1.6
        static String[] StickMater = { "低碳钢实芯", "不锈钢实芯","","", "低碳钢药芯", "不锈钢药芯" };
        static String[] GAS_TYPE={"CO2","MAG，","","MIG-Ar98%-2%O2"};
        static String[] STICK_MATER={"低碳钢实芯","不锈钢实芯","低碳钢药芯","不锈钢药芯"};
        //static String STICK_DIAM[]={10：Φ1.0；12：Φ1.2，14 ：Φ1.4，16：Φ1.6}
        static String PanField = "nom,equipname,state,name,vai,vvi,va,vv,vaf,vvf,wa,wv,rpm,wp,mt,wd,wc,mp,pwtime,PieceNum,PieceTemp,GasFlux,Power,NowTime,StartTime,EndTime,weldTime,workTime,channel,channelcount";
        static String PanField_Ex1 = "nom,equipname,state,name,vai,vvi,va,vv,vaf,vvf,wa,wv,rpm,wp,mt,wd,wc,mp,pwtime,PieceNum,PieceTemp,GasFlux,Power,NowTime,StartTime,EndTime,weldTime,workTime,channel,channelcount,vv_up,vv_down,va_up,va_down,";

        static String OTCField = "MaschineId,MASCHINE_CODE,MaschineState,MASCHINE_MODEL,STA_ELEC,STA_VOLT,WORK_ELEC_CURR,WORK_VOLT_CURR,END_ELEC_CURR,END_VOLT_CURR,WeldCurrent,Voltage,StickSpeed,GAS_TYPE,STICK_MATER,STICK_DIAM,wc,mp,SPOT_TIM,PieceNum,PieceTemp,GasFlux,Power,AddTime,StartTime,EndTime,weldTime,workTime,channel,channelcount";
        //String[] BG = bgrp.Split(',');
        //String[] OTC = otc.Split(',');

        static String jsonmode_Getwpsbyid = "{\"C\": \"Request_Up\",\"A\": \"***\",\"D\": {\"AFN\": \"getWpsById\",\"DataUnit\":{\"MaschineId\": \"XXX\",}}}";
        static String jsonmode_Downwpsbyid = "{\"C\": \"Request_Up\",\"A\": \"***\",\"D\": {\"AFN\": \"SendWpsByManchineId\",\"DataUnit\":{XXX}}";
        static String jsonmode_Getcurrdata = "{\"C\": \"Request_Up\",\"A\": \"***\",\"D\": {\"AFN\": \"CurrData\",\"DataUnit\":{}}}";
       

        public OTCDevices()
        {
            Maxchannel = 10;
            INIClass ics=new INIClass();
            OTCServiceDress = ics.getOTCService();
            if (_basehttpbinding==null)
            _basehttpbinding = new System.ServiceModel.BasicHttpBinding(System.ServiceModel.BasicHttpSecurityMode.Message);

            //建立连接绑定
           
            TimeSpan timespan = new TimeSpan(0, 10, 0);
            _basehttpbinding.CloseTimeout = timespan;
            _basehttpbinding.ReceiveTimeout = timespan;
            _basehttpbinding.SendTimeout = timespan;
            _basehttpbinding.AllowCookies = false;
            _basehttpbinding.BypassProxyOnLocal = false;
            _basehttpbinding.HostNameComparisonMode = System.ServiceModel.HostNameComparisonMode.StrongWildcard;// "StrongWildcard";
            //maxBufferSize="65536" maxBufferPoolSize="524288" maxReceivedMessageSize="65536" messageEncoding="Text" textEncoding="utf-8" transferMode="Buffered" useDefaultWebProxy="true"
            _basehttpbinding.MaxBufferPoolSize = 524288;
            _basehttpbinding.MaxReceivedMessageSize = 65536;
            _basehttpbinding.MessageEncoding = System.ServiceModel.WSMessageEncoding.Text;
            _basehttpbinding.TextEncoding = Encoding.UTF8;
            _basehttpbinding.TransferMode = System.ServiceModel.TransferMode.Buffered;
            _basehttpbinding.UseDefaultWebProxy = true;
            //<security mode="None">
            //<transport clientCredentialType="None" proxyCredentialType="None" realm="" />
           // <message clientCredentialType="UserName" algorithmSuite="Default" />
          //</security>
            _basehttpbinding.Security.Mode = System.ServiceModel.BasicHttpSecurityMode.None;
            //System.ServiceModel.HttpClientCredentialType.Windows
            _basehttpbinding.Security.Transport.ClientCredentialType = System.ServiceModel.HttpClientCredentialType.None;
            _basehttpbinding.Security.Transport.ProxyCredentialType = System.ServiceModel.HttpProxyCredentialType.None;
            _basehttpbinding.Security.Transport.Realm = "";

            _basehttpbinding.Security.Message.ClientCredentialType = System.ServiceModel.BasicHttpMessageCredentialType.UserName;
            _basehttpbinding.Security.Message.AlgorithmSuite = System.ServiceModel.Security.SecurityAlgorithmSuite.Default;

             //<readerQuotas maxDepth="32" maxStringContentLength="8192" maxArrayLength="16384" maxBytesPerRead="4096" maxNameTableCharCount="16384" />
            _basehttpbinding.ReaderQuotas.MaxDepth = 32;
            _basehttpbinding.ReaderQuotas.MaxStringContentLength = 2147483647;
            _basehttpbinding.ReaderQuotas.MaxArrayLength = 16384;
            _basehttpbinding.ReaderQuotas.MaxBytesPerRead = 4096;
            _basehttpbinding.ReaderQuotas.MaxNameTableCharCount = 16384;



            System.ServiceModel.EndpointAddress rometdress = new System.ServiceModel.EndpointAddress(OTCServiceDress);

            _otcClient = new OTCweldService.SetCardPortTypeClient(_basehttpbinding, rometdress);
            _otcClient.Endpoint.Binding.CloseTimeout = timespan;
            _otcClient.Endpoint.Binding.OpenTimeout = timespan;
            _otcClient.Endpoint.Binding.ReceiveTimeout = timespan;
            _otcClient.Endpoint.Binding.Name = "SetCardHttpBinding";

            
        }



      
        
        /// <summary>
        ///下载WPS参数
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public DataTable Downloadwpsbyid(DataTable dt)
        {
            //DataTable dt = dr.Table;

            String njson = DataTable2Json(dt);

            njson = njson.Substring(3, njson.Length - 3);
            njson = "\"Wps\"" + njson;
            String jsonstr = jsonmode_Downwpsbyid.Replace("XXX", njson);

            String rs = _otcClient.SendWpsByManchineId(jsonstr);


            return JsonToDataTable(rs);
        }
        /// <summary>
        /// 获取焊机的WPS数据
        /// </summary>
        /// <param name="vid"></param>
        /// <returns></returns>
        public DataTable getWpsbyID(String vid)
        {
            String json="";
            json = jsonmode_Getwpsbyid.Replace("XXX", vid);
            String rsjson = _otcClient.getWpsById(json);
            DataTable rsdt = JsonToDataTable(rsjson);
            return rsdt;
        }
        /// <summary>
        /// 获取焊机的实时数据
        /// </summary>
        /// <returns></returns>
        public DataTable getOTCcurrdata()
        {
            String jsoncmd=jsonmode_Getcurrdata;
            String rsjson=_otcClient.CurrData(jsoncmd);
            DataTable rsdt=JsonToDataTable(rsjson);
            //字段内容转换
            String[] panFields = PanField.Split(',');
            String[] otcFields = OTCField.Split(',');
            for (int i = 0; i < otcFields.Length; i++)
            {
                if (rsdt.Columns.IndexOf(otcFields[i]) > -1)
                {
                    rsdt.Columns[otcFields[i]].ColumnName = panFields[i];

                }
            }
            rsdt.Columns.Add("vv_up", typeof(double));
            rsdt.Columns.Add("vv_down", typeof(double));
            rsdt.Columns.Add("va_up", typeof(double));
            rsdt.Columns.Add("va_down", typeof(double));
            //剔除不需要的字段
            //String[] paField_exs = PanField_Ex1.Split(',');
            for (int i = 0; i < rsdt.Columns.Count; i++)
            {
                String otcfieldname = rsdt.Columns[i].ColumnName+",";
                if (PanField_Ex1.IndexOf(otcfieldname) > -1)
                {
                }
                else
                {
                    rsdt.Columns.RemoveAt(i);
                }
            }
            rsdt.AcceptChanges();
            //修正数据
            double a1, a2;

            for (int k = 0; k < rsdt.Rows.Count; k++)
            {
                a1 = 0; a2 = 0;
                for (int kk = 0; kk < rsdt.Columns.Count; kk++)
                {
                    if (rsdt.Columns[kk].ColumnName == "va")
                    {
                        String a = rsdt.Rows[k]["va"].ToString();
                        String[] sas = a.Split('-');
                        a1 = Convert.ToDouble(sas[0]);
                        a2 = Convert.ToDouble(sas[1]);
                        rsdt.Rows[k]["va"] = (a1 + a2) / 2;
                        rsdt.Rows[k]["va_up"] = a2;
                        rsdt.Rows[k]["va_down"] = a1;
                    }
                    if (rsdt.Columns[kk].ColumnName == "vvf")
                    {
                        String a = rsdt.Rows[k]["vvf"].ToString();
                        String[] sas = a.Split('-');
                        a1 = Convert.ToDouble(sas[0]);
                        a2 = Convert.ToDouble(sas[1]);
                        rsdt.Rows[k]["vvf"] = (a1 + a2) / 2;
                        //rsdt.Rows[k]["va_up"] = a2;
                        //rsdt.Rows[k]["va_down"] = a1;
                    }
                    if (rsdt.Columns[kk].ColumnName == "vaf")
                    {
                        String a = rsdt.Rows[k]["vaf"].ToString();
                        String[] sas = a.Split('-');
                        a1 = Convert.ToDouble(sas[0]);
                        a2 = Convert.ToDouble(sas[1]);
                        rsdt.Rows[k]["vaf"] = (a1 + a2) / 2;
                        //rsdt.Rows[k]["va_up"] = a2;
                        //rsdt.Rows[k]["va_down"] = a1;
                    }
                    if (rsdt.Columns[kk].ColumnName == "vv")
                    {
                        String a = rsdt.Rows[k]["vv"].ToString();
                        String[] sas = a.Split('-');
                        a1 = Convert.ToDouble(sas[0]);
                        a2 = Convert.ToDouble(sas[1]);
                        rsdt.Rows[k]["vv"] = (a1 + a2) / 2;
                        rsdt.Rows[k]["vv_up"] = a2;
                        rsdt.Rows[k]["vv_down"] = a1;
                    }
                    //1,工作；2，待机；3，离线
                    if (rsdt.Columns[kk].ColumnName == "state")
                    {
                        String a = rsdt.Rows[k]["state"].ToString();
                        int ia = Convert.ToInt32(a);
                      
                        switch (ia)
                        {
                            case 1:


                                rsdt.Rows[k]["state"] = "焊接";
                                break;
                            case 2:
                                rsdt.Rows[k]["state"] = "待机";
                                break;
                            case 3:
                                rsdt.Rows[k]["state"] = "关闭";
                                break;
                            default:
                                break;
                        }


                    }
                }

            }
            return rsdt;
        }
       
        private DataTable JsonToDataTable(string strJson)
        {
            //转换json格式
            strJson = strJson.Replace(",\"", "*\"").Replace("\":", "\"#").ToString();
            //取出表名   
            var rg = new Regex(@"(?<={)[^:]+(?=:\[)", RegexOptions.IgnoreCase);
            string strName = rg.Match(strJson).Value;
            DataTable tb = null;
            //去除表名   
            strJson = strJson.Substring(strJson.IndexOf("[") + 1);
            strJson = strJson.Substring(0, strJson.IndexOf("]"));

            //获取数据   
            rg = new Regex(@"(?<={)[^}]+(?=})");
            MatchCollection mc = rg.Matches(strJson);
            for (int i = 0; i < mc.Count; i++)
            {
                string strRow = mc[i].Value;
                string[] strRows = strRow.Split('*');

                //创建表   
                if (tb == null)
                {
                    tb = new DataTable();
                    tb.TableName = strName;
                    foreach (string str in strRows)
                    {
                        var dc = new DataColumn();
                        string[] strCell = str.Split('#');

                        if (strCell[0].Substring(0, 1) == "\"")
                        {
                            int a = strCell[0].Length;
                            dc.ColumnName = strCell[0].Substring(1, a - 2);
                        }
                        else
                        {
                            dc.ColumnName = strCell[0];
                        }
                        tb.Columns.Add(dc);
                    }
                    tb.AcceptChanges();
                }

                //增加内容   
                DataRow dr = tb.NewRow();
                for (int r = 0; r < strRows.Length; r++)
                {
                    dr[r] = strRows[r].Split('#')[1].Trim().Replace("，", ",").Replace("：", ":").Replace("\"", "");
                }
                tb.Rows.Add(dr);
                tb.AcceptChanges();
                //for (int k = 0; k < OTC.Length; k++)
                //{
                //    if (tb.Columns.IndexOf(OTC[k]) > -1)
                //    {
                //        tb.Columns[OTC[k]].ColumnName = BG[k];
                //    }

                //}
                /*{dt.Rows[]["WorkElec"] = 修改的值;
                 {dt.Rows[]["WorkVolt"] = 修改的值;
                 {dt.Rows[]["EndElec"] = 修改的值;
                 {dt.Rows[]["EndVolt"] = 修改的值;
                 {dt.Rows[]["WorkElec_Trim"] = 修改的值;
                 {dt.Rows[]["WorkVolt_Trim"] = 修改的值;
                 {dt.Rows[]["StickMater"] = 修改的值;
                 {dt.Rows[]["StickDiam"] = 修改的值;*/
            }

            return tb;
        }
        /// <summary>  
        /// dataTable转换成Json格式  
        /// </summary>  
        /// <param name="dt"></param>  
        /// <returns></returns>  
        public static string DataTable2Json(DataTable dt)
        {
            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("{\"");
            jsonBuilder.Append(dt.TableName);
            jsonBuilder.Append("\":[");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                jsonBuilder.Append("{");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    jsonBuilder.Append("\"");
                    jsonBuilder.Append(dt.Columns[j].ColumnName);
                    jsonBuilder.Append("\":\"");
                    jsonBuilder.Append(dt.Rows[i][j].ToString());
                    jsonBuilder.Append("\",");
                }
                jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
                jsonBuilder.Append("},");
            }
            jsonBuilder.Remove(jsonBuilder.Length - 1, 1);
            jsonBuilder.Append("]");
            jsonBuilder.Append("}");
            return jsonBuilder.ToString();
        }

       





        /// <summary>
        /// 获取OTC焊机及其状态
        /// </summary>
        /// <returns></returns>
        public DataTable GetOTCDrives()
        {
            DataTable dt=new DataTable();


            dt = getOTCcurrdata();


            return dt;
        }
         /// <summary>
        /// 获取OTC焊机的通道参数配置
        /// </summary>
        /// <returns></returns>
        public DataTable GetOTCDrivesChannelInfos()
        {
            DataTable dt = new DataTable();
            DataTable drvs = GetOTCDrives();
            drvs.DefaultView.ToTable(true, "nom");
            DataTable onedrv=null;
            for (int i = 0; i < drvs.Rows.Count; i++)
            {
                String nom = drvs.Rows[i]["nom"].ToString();
                DataTable tonedrv=GetOTCDrivesChannelInfos(nom);
                if (onedrv == null)
                    onedrv = tonedrv.Clone();
                for (int k = 0; k < tonedrv.Rows.Count; k++)
                {
                    onedrv.ImportRow(tonedrv.Rows[i]);
                }
            }
            return onedrv;

        }
        /// <summary>
        /// 获取OTC焊机的通道参数配置--利用焊机ID获取
        /// </summary>
        /// <returns></returns>
        public DataTable GetOTCDrivesChannelInfos(String nom)
        {
            DataTable dt = new DataTable();
            dt = getWpsbyID(nom);
            return dt;

        }
          /// <summary>
        /// 检测焊机自身的WPS参数是否存在符合要求的，如存在则返回其通道号
        /// </summary>
        /// <param name="row"></param>
        /// <param name="WeldDevice"></param>
        /// <returns></returns>
        public int testEqumsChannelparams(DataRow row, String WeldDevice)
        {
            return 0;
        }
         /// <summary>
        /// 下载参数;
        /// </summary>
        /// <param name="row"></param>
        /// <param name="WeldDevice"></param>
        public void otcchangeset(ref  DataRow row, String WeldDevice)
        {
            //得到OTC焊机的内置WPS
            int nom = 0;
            int channelid = 0;
            nom = Convert.ToInt32(WeldDevice);// Convert.ToInt32(row["FweldDriverID"]);
            channelid = Convert.ToInt32(row["WELD_PASS"]);

            //判断当前焊机中将要使用的通道参数是否匹配

            //获取焊机信息
            DataTable otcwps_all = getWpsbyID(nom.ToString());

            if (otcwps_all == null)
            {
                Console.WriteLine(String.Format("无法获取到焊机{0}的WPS参数",nom, channelid));
                return;
            }
            //得到指定通道的WPS参数
            otcwps_all.DefaultView.RowFilter = "WpsCode=" + channelid;

            DataTable otcwps = otcwps_all.DefaultView.ToTable();

            if (otcwps.Rows.Count == 0)
            {
                Console.WriteLine(String.Format("无法获取到焊机{0}的{1}通道的WPS参数",nom, channelid));
                return;
            }
            
            //选定通道
            if (channelid + 1 > Maxchannel)
            {
                Console.WriteLine(String.Format("准备焊机{0},焊机最大通道数{1} 因此不能下载",nom, channelid));
                return;
            }

            int isexits = 0;


            double iva, ivv;
            iva = Convert.ToDouble(row["WELD_I"]);
            ivv = Convert.ToDouble(row["WELD_V"]);


            double eqva, eqvv;
            eqva = Convert.ToDouble(otcwps.Rows[0]["WorkElec"]);
            eqvv = Convert.ToDouble(otcwps.Rows[0]["WorkVolt"]);
            //if (Convert.ToDouble(System.Math.Abs((vimx - ivimx))) == 0 && Convert.ToDouble(System.Math.Abs((vimi - ivimi))) == 0 && Convert.ToDouble(System.Math.Abs((vvmx - ivvmx))) == 0 && Convert.ToDouble(System.Math.Abs((vvmi - ivvmi))) == 0)
            if (System.Math.Abs(Convert.ToDouble(iva - eqva)) < 0.5 && System.Math.Abs(Convert.ToDouble(ivv - eqvv)) < 0.5)
            {
                row["FActChannel"] = channelid;
                Console.WriteLine(String.Format("焊道{0}参数,命中通道{0},无需下载", channelid, channelid));
                return;
            }


            //}
            //没有命中，则下载WPS数据；
            row["FActChannel"] = channelid;
            if (Convert.ToInt64(row["FWELDWPSID"]) > -100)
            {
                //测试修改一个值，然后进行修改；

             

              
                //丝径

                otcwps.Rows[0]["StickDiam"] = Convert.ToDouble(row["WELD_WIRE_DIA"]);
                //材质
                for(int k=0;k<StickMater.Length;k++)
                {
                    if (StickMater[k] == row["WELD_MATERIAL"].ToString())
                        otcwps.Rows[0]["StickMater"] = k;
                }
                //焊接电流
                otcwps.Rows[0]["WorkElec"] = Convert.ToDouble(row["WELD_I"]);
                //焊接电压
                otcwps.Rows[0]["WorkVolt"] = Convert.ToDouble(row["WELD_V"]);
                //焊接电流上限  焊接电流下限  ==WorkElec_Trim
                otcwps.Rows[0]["WorkElec_Trim"] = Convert.ToInt32((Convert.ToDouble(row["WELD_I_MAX"]) - Convert.ToDouble(row["WELD_I_MIN"])) / 2);
                otcwps.Rows[0]["WorkVolt_Trim"] = Convert.ToInt32((Convert.ToDouble(row["WELD_V_MAX"]) - Convert.ToDouble(row["WELD_V_MIN"])) / 2);
                //收弧电流
                otcwps.Rows[0]["EndVolt"] = Convert.ToDouble(row["CLOSEING_V"]);
                //收弧电压  EndElec
                otcwps.Rows[0]["EndElec"] = Convert.ToDouble(row["CLOSEING_I"]);
   
                int imx = 0, imi = 0, vmx = 0, vmi = 0, ib = 0, vb = 0;
                imi = Convert.ToInt32(row["WELD_I_MIN"]);
                imx = Convert.ToInt32(row["WELD_I_MAX"]);
                vmx = Convert.ToInt32(row["WELD_V_MAX"]);
                vmi = Convert.ToInt32(row["WELD_V_MIN"]);
                ib = Convert.ToInt32(row["WELD_V"]);
                vb = Convert.ToInt32(row["WELD_V"]);
                int irang = (imx - imi) / 2;
                int vrang = (vmx - vmi) / 2;
                //
                //焊接电流微调
                otcwps.Rows[0]["WorkElec_Trim"] = irang;
                //焊接电压微调
                otcwps.Rows[0]["WorkVolt_Trim"] = vrang;

                //回写OTC接口;
                otcwps.AcceptChanges();
                DataTable Rsdt = Downloadwpsbyid(otcwps);
                Console.WriteLine(String.Format("OTC 规范 通道{0} 下载 成功", channelid));
                return;
            }
     
        }

        #region IDevices 成员


        public DataTable GetDrives()
        {
           // throw new NotImplementedException();
            return this.GetOTCDrives();
        }

        public DataTable GetDrivesChannelInfos()
        {
            return this.GetOTCDrivesChannelInfos();
            // throw new NotImplementedException();
        }

        #endregion

        #region IDevices 成员

        public void changeset(ref DataRow row, string WeldDevice)
        {
            //throw new NotImplementedException();
            this.otcchangeset(ref row, WeldDevice);
        }

        #endregion
    }
}
