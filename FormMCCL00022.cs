using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EI;
using EF;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
using System.Threading;
namespace MC
{
    public partial class FormMCCL00022 : Formbase
    {
        DataTable _toDayTaskLists;
        int cmd_Task_GetDepartInfo = 1025;//获取除parentid=0之外的所有部门信息;
        int cmd_Task_GetDispatchBodyInfos = 1026;//获取一个月范围内的已经分配以及未分配的
        int cmd_Task_GetTaskInfo = 1027;//按照给定的部门，时间查询得到任务列表
        int cmd_Task_GetWelders = 1028;//获取全部焊工信息；

        int cmd_WelderTask_GetTask = 1029;//提取当日的任务；

        int cmd_WeldDrivers_GetDrivers = 1030;//查询得到焊机名，编号，状态
        int cmd_WelderDrivers_GetDriversChannel = 1031;//查询得到焊机通道信息；
        int cmd_WelderTaskOp_Get2DTaskList = 1028;//得到今日适用的所有焊接任务;
        int cmd_WelderTaskOp_UpdateOP = 7004;//更新任务

        _MyClient _Client = new _MyClient();
        DataTable _driversDT;
        DataTable _curWelderTaskFID_DT;
        int _curWelderTask_eRowIndex = 0;

        int taskcount = 0;

        //AxReadCardInfo.AxReadCard ReadCard;

        //Thread readCardThread ;//= new Thread(readCardThreadpro);

        Thread showDownloadThread ;//= new Thread(showDownLoadThreadpro);
        //System.Timers.Timer RCD_Timer;

        clsReadCardThread clsrd;

        System.Threading.Timer th_Timer;

        int threadflage = 0;

        public delegate void dgt_readcard();

        private void actreadcard()
        {
            
            string empNO = ""; string empName = "";
            int cardId = 0;
            ReadCardTimer.Enabled = false;
            ReadCardTimer.Stop();
            //RCD_Timer.Enabled = false;
            //RCD_Timer.Stop();
            //while (1 == 1)
            //{
            int retValue = this.axReadCard1.ReadCard(ref empNO, ref empName, ref cardId);

            if (retValue == -1)
            {
                MessageBox.Show("打开串口错误，未能识别读卡器！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //else if (retValue == -2)
            //{
            //    MessageBox.Show("卡片信息有误，未能识别卡片信息！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            if (retValue == 0)
            {
                if (empNO.Length == 13)// && Fnum.Text != empNO.Substring(0, 8))
                {

                    Fnum.Text = empNO.Substring(0, 8); FName.EFEnterText = empName;
                    ReadCardTimer.Stop();
                    ReadCardTimer.Enabled = false;
                    return;
                }
            }
            else
            {
                //MessageBox.Show("打开串口错误，未能识别读卡器！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //ReadCardTimer.Stop();
                //return;

            }
                //Thread.Sleep(3000);
            //}
           // this.readCardThread.Abort();

            ReadCardTimer.Enabled = true;
            ReadCardTimer.Start();
               // RCD_Timer.Start();
            //RCD_Timer.Enabled=true;
                threadflage = 1;
        }
        private void showDownLoadThreadpro()
        {
            FormMCCLTaskPros vf = new FormMCCLTaskPros();
            vf.ShowDialog();

        }


        private void readCardThreadpro()
        {
            //RCD_Timer.Stop();
       
            //this.ReadCardTimer.Enabled = true;
            //dgt_readcard rd = new dgt_readcard(actreadcard);
            //BeginInvoke(rd);
            //RCD_Timer.Start();
            
            //this.readCardThread.Abort();
        }

        public FormMCCL00022()
        {
            InitializeComponent();
            
        }
        private void frmWelderClient_Load(object sender, EventArgs e)
        {
            this.FSTARTTIME.Value = DateTime.Now;
            AxReadCardInfo.AxReadCard ReadCard = new AxReadCardInfo.AxReadCard();

            ReadCardTimer.Interval = 1000;
            ReadCardTimer.Enabled = false;
            this.tabPage1.Parent = this.Control1;
            this.tabPage2.Parent = null;

            // ReadCardTimer.Start();
            //this.dataGrid.AutoGenerateColumns = false;
            // this.welderDrvs.Visible = false;
            //  readCardThread = new Thread(readCardThreadpro);
            showDownloadThread = new Thread(showDownLoadThreadpro);
            //ReadCardTimer.Start();
            //    RCD_Timer = new System.Timers.Timer(3000);

            //    RCD_Timer.Elapsed += new System.Timers.ElapsedEventHandler(RCD_Timer_Elapsed);

            //    RCD_Timer.Start();
            //}
            
            //clsrd = new clsReadCardThread(ref Fnum,ref FName);
            //clsrd.start();

           // th_Timer = new System.Threading.Timer(new System.Threading.TimerCallback(actreadcard), this, 5000, 5000);
    
        }
        void RCD_Timer_Elapsed(object sende)
        {
            //throw new NotImplementedException();
            try
            {
                //dgt_readcard rd = new dgt_readcard(actreadcard);
                //BeginInvoke(rd);
                //ThreadState ss = readCardThread.ThreadState;
                //if (ss==ThreadState.Unstarted)
                //    readCardThread.Start();
               // RCD_Timer.Stop();
                //readCardThread = new Thread(new ThreadStart(readCardThreadpro));
                //readCardThread.ApartmentState=ApartmentState.MTA;
                //readCardThread.Start();
                //while (threadflage==0)
                //{
                    
                //}
                //threadflage = 0;

                //actreadcard();
                //dgt_readcard rd = new dgt_readcard(actreadcard);
                //BeginInvoke(rd);
                //RCD_Timer.Start();
                
                //if (readCardThread.IsAlive)
                //{

                //}
                //else
                //{
                //    readCardThread.Start();
                //}
            }
            catch (Exception ex) { String exss = ex.Message.ToString(); }
        }

        private void Fnum_TextChanged(object sender, EventArgs e)
        {
            //焊工发生变化
            bool ss = this.ReadCardTimer.Enabled;
          
            String weldernum = this.Fnum.Text;
            if (weldernum.Length != 8)
                return;
            
            FSTARTTIME_ValueChanged(null, null);//加载素具
            //获取班组未分配任务;
            DataTable fdt = new DataTable();
            fdt.Columns.Add("Fnum",typeof(string));fdt.Rows.Add(weldernum);
            
            DataTable unDispList=_Client.ServiceCall(102901,fdt);
            unDispList.Columns.Add("FChecked", typeof(int));
            String stime = this.FSTARTTIME.Value.ToString("yyyy-MM-dd");

            //合并未分配
            //for (int i = 0; i < unDispList.Rows.Count; i++)
            //{
            //    DataRow nr = unDispList.Rows[i];
            //    _toDayTaskLists.ImportRow(nr);
            //}


            DataView dv = _toDayTaskLists.DefaultView;

            String rowfilter = "Fnum='{0}' and (FSTATE<>2) ";//and FSTARTTIME=#{1}#";
            //如果存在正在进行的任务，则不显示其他任务
            dv.RowFilter = String.Format(rowfilter, weldernum, stime);
            DataTable dt = dv.ToTable();
            if (dt.Rows.Count > 0)
            {

            }
            else
            {

                dv.RowFilter = "";
                rowfilter = "Fnum='{0}' and FSTATE<>1 and FSTARTTIME=#{1}#";
                dv.RowFilter = String.Format(rowfilter, weldernum, stime);
                dt = dv.ToTable();
                for (int i = 0; i < unDispList.Rows.Count; i++)
                {
                    DataRow r = unDispList.Rows[i];
                    dt.ImportRow(r);
                }
            }

            //将未分配任务加入到列表中

            //if (dt.Rows.Count > 0)
            //{//存在正在进行的焊接，则不能显示其他焊接任务
            //   // MessageBox.Show(this, "您正在进行一项任务不能选取新任务", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
             ;
            //    dv.RowFilter = String.Format(rowfilter, weldernum, stime);
            //    dt = dv.ToTable();
            //    //for (int i = 0; i < unDispList.Rows.Count; i++)
            //    //{
            //    //    DataRow r = unDispList.Rows[i];
            //    //    dt.ImportRow(r);
            //    //}
            //}
            
            //开启焊工等级与焊缝焊接等级要求匹配模式
            clsTaskWeldDetail cls = new clsTaskWeldDetail();
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("工号=‘" + Fnum.Text + "’ 不存在焊接任务");
                return;
            }
            dt= cls.checkWeldWeldingClassAD(dt, dt.Rows[0]["FName"].ToString());
            if (dt.Rows.Count > 0)
            {
                FName.Text = dt.Rows[0]["FName"].ToString();
                FDepartName.Text = dt.Rows[0]["FDepartName"].ToString();

            }
            else
            {
                MessageBox.Show("工号=‘" + Fnum.Text + "’ 不存在焊接任务");
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["FChecked"] = 0;
            }
            this.dataGrid.DataSource = dt;
            this.dataGrid.Refresh();
            this.dataGrid.Enabled = true;
            this.tabPage1.Parent = Control1;
            this.tabPage2.Parent = null;
            this.Control1.SelectTab(tabPage1);
            this.gridView1.BestFitColumns();
        }

        private void FSTARTTIME_ValueChanged(object sender, EventArgs e)
        {
            //时间发生变化后更新任务表
            DataTable fd = new DataTable();
            DataColumn col = new DataColumn();
            col.ColumnName = "FSTARTTIME";
            col.DataType = typeof(String);
            fd.Columns.Add(col);
            DataRow row = fd.NewRow();
            row[0] = this.FSTARTTIME.Value.ToString("yyyy-MM-dd");
            fd.Rows.Add(row);
            clsFrmBase cls = new clsFrmBase();

            _toDayTaskLists = _Client.ServiceCall(1029, fd);
            
            _toDayTaskLists.Columns.Add("FChecked", typeof(int));
            //DataView dv = _toDayTaskLists.DefaultView;
            //this.dataGrid.DataSource = _toDayTaskLists;
        }

        private void dataGrid_CellContentClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int rindex = this.gridView1.FocusedRowHandle; ;
            String bName = this.gridView1.FocusedColumn.Name;
            String vFIDstr="";
            long vfid=0; int vstate=0;

            //检测所选择的焊缝状态是否一致;
            for (int k = 0; k < this.gridView1.RowCount; k++)
            {
                if (Convert.ToInt32(this.gridView1.GetRowCellValue(k, "FChecked")) == 1)
                {
                    vFIDstr += this.gridView1.GetRowCellValue(k, "FWELDID").ToString() + ",";
                }
            }
           


            if (vFIDstr.Length > 1)
            {
                //多条焊缝合并进行;
                if (MessageBox.Show(this, "您选择了多条焊缝，是否合并为焊缝组进行任务?", "消息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                vFIDstr = vFIDstr.Substring(0, vFIDstr.Length - 1);
            }
            else
            {
                vfid = Convert.ToInt64(this.gridView1.GetRowCellValue(rindex, "FWELDID"));//dataGrid.Rows[e.RowIndex].Cells["CFID"].Value);
                //检测任务状态
                vstate = Convert.ToInt32(this.gridView1.GetRowCellValue(rindex, "FSTATE"));//(rindex, "FSTATE"));//dataGrid.Rows[e.RowIndex].Cells["CFSTATE"].Value);

                vFIDstr = vfid.ToString();
            }
    
            if (bName == "CBUTBEGIN")
            {

                if (vstate == 2 || vstate == 1)
                {
                    MessageBox.Show(this, "任务已经开始或已完成", "警告", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }


                DataView tmpDv = ((DataTable)dataGrid.DataSource).DefaultView;
                String rowfilter = "FWELDID in ({0})";
                tmpDv.RowFilter = String.Format(rowfilter, vFIDstr);
                _curWelderTaskFID_DT = tmpDv.ToTable();
                //frmWelderTask frm = new frmWelderTask(tmpDt);
                //frm.ShowDialog(this);
                DataTable curData = tmpDv.ToTable();
                // this.dataGrid.DataSource = _curWelderTaskFID_DT;
                if (vstate == 4)
                {
                    //从挂起继续；
                    _curWelderTaskFID_DT.Rows[0]["FSTATE"] = 5;
                    welder_Task_Do(5, rindex, 0, _curWelderTaskFID_DT, "FSTATE_DES");
                    return;
                }
                //tabControl1.Enabled = true;
                //tabDrivers.Parent = tabControl1;
                //tabChannels.Parent = null;
                //加载焊机信息
                loadTab();
                welderDrvs.Enabled = true;
                tabPage2.Parent = this.Control1;
                this.Control1.SelectTab(this.tabPage2);
                this.tabPage1.Parent = null;
                _curWelderTask_eRowIndex = rindex;
                //this.dataGrid.Enabled = false;
            }

            if (bName == "CBUTCHANGE")
            {
                //切换焊机
                if (vstate != 1)
                {
                    MessageBox.Show(this, "任务未开始或挂起或完成，不能切换", "警告", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }

                DataView tmpDv = ((DataTable)dataGrid.DataSource).DefaultView;
                String rowfilter = "FWELDID in ({0})";
                tmpDv.RowFilter = String.Format(rowfilter, vFIDstr);
                _curWelderTaskFID_DT = tmpDv.ToTable();
                //frmWelderTask frm = new frmWelderTask(tmpDt);
                //frm.ShowDialog(this);
                DataTable curData = tmpDv.ToTable();
                // this.dataGrid.DataSource = _curWelderTaskFID_DT;
                //if (vstate == 4)
                //{
                    //切换焊机动作；
                    _curWelderTaskFID_DT.Rows[0]["FSTATE"] = 6;
                    welder_Task_Do(6, rindex, 0, _curWelderTaskFID_DT, "FSTATE_DES");
                   //继续进行焊接动作
                    _curWelderTaskFID_DT.Rows[0]["FSTATE"] = 1;
                    welder_Task_Do(1, rindex, 0, _curWelderTaskFID_DT, "FSTATE_DES");
                    return;
                //}
            }
            if (bName == "CPUASE")
            {
                //挂起操作
                if (vstate != 1)
                {
                    MessageBox.Show(this, "任务还未开始或已完成", "警告", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                DataView tmpDv = ((DataTable)dataGrid.DataSource).Copy().DefaultView;
                String rowfilter = "FWELDID in ({0})";
                tmpDv.RowFilter = String.Format(rowfilter, vFIDstr);
                _curWelderTaskFID_DT = tmpDv.ToTable();
                _curWelderTaskFID_DT.Rows[0]["FState"] = 4;//挂起任务；
                _curWelderTaskFID_DT.Rows[0]["FActOpSTARTTime"] = DateTime.Now;
                //焊工确认--回写数据库
                //frmWelderTaskInfos frm = new frmWelderTaskInfos(_curWelderTaskFID_DT);
                //if (frm.ShowDialog(this) == DialogResult.Yes)
                //{
                //确认操作
                welder_Task_Do(4,rindex, 0, _curWelderTaskFID_DT, "CFSTATE_DES");
                //}
                Fnum_TextChanged(this.Fnum, null);
                //this.tabPage1.Parent = this.Control1;
                //this.Control1.SelectTab(tabPage1);
                //this.tabPage2.Parent = null;

            }

            if (bName == "CBUTEND")
            {
                //完成焊接任务；

                if (vstate != 1 || vstate == 4)
                {
                    MessageBox.Show(this, "任务还未开始或被挂起，不能完成", "警告", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                DataView tmpDv = ((DataTable)dataGrid.DataSource).DefaultView;
                String rowfilter = "FWELDID in ({0})";
                tmpDv.RowFilter = String.Format(rowfilter, vFIDstr);
                _curWelderTaskFID_DT = tmpDv.ToTable();
                //frmWelderTask frm = new frmWelderTask(tmpDt);
                //frm.ShowDialog(this);
                _curWelderTaskFID_DT.Rows[0]["FState"] = 2;//完成任务；
                _curWelderTaskFID_DT.Rows[0]["FActOpEndTime"] = DateTime.Now;
                //回写数据库
                //_Client.ServiceCall(7004, _curWelderTaskFID_DT);
                welder_Task_Do(2, rindex, 0, _curWelderTaskFID_DT, "CFSTATE_DES");
                this.dataGrid.Enabled = true;
                //重新加载该焊工的数据
                Fnum_TextChanged(Fnum, null);


                //tabControl1.Enabled = false;
                //tabDrivers.Parent = tabControl1;
                //tabChannels.Parent = null;

                loadTab();

                _curWelderTask_eRowIndex = rindex;
                //this.welderChannel.Items.Clear();
                this.welderDrvs.Items.Clear();


                

            }

        }

        protected Boolean loadTab()
        {
            //modify by junlin filter welder by group

            long welder_departid = 0;
            DataTable welder_dt = _Client.ServiceCall(5101502, null);
            if (this.Fnum.Text.Length == 8)
            {
                welder_dt.DefaultView.RowFilter = "Fnum='" + this.Fnum.Text + "'";
                welder_dt = welder_dt.DefaultView.ToTable();
                if (welder_dt.Rows.Count == 0)
                {
                    return false;
                }
                else
                {
                    welder_departid = Convert.ToInt64(welder_dt.Rows[0]["Fdepart"]);
                }
            }
            else
            {
                return false;
            }
            

            //
            DataTable panasoicWelderDT = new DataTable();
            panasoicWelderDT = _Client.ServiceCall(cmd_WeldDrivers_GetDrivers, null);
            // { "焊机序号", "设备编号", "工作状态", "机型", "初期电流", "初期电压", "预置电流", "预置电压", "收弧电流", "收弧电压", "焊接电流", "焊接电压", "送丝速度", "气体", "材质", "丝径", "焊接控制", "脉冲有无", "点焊时间", "操作者", "故障类型", "任务编号", "工件温度", "气体流量", "瞬时功率", "上传时间", "开机时间", "关机时间", "焊接时间", "工作时间", "当前通道", "通道数量" };
            // { "nom", "equipname", "state", "name", "vai", "vvi", "va", "vv", "vaf", "vvf", "wa", "wv", "rpm", "wp", "mt", "wd", "wc", "mp", "pwtime", "emplon", "errnom", "PieceNum", "PieceTemp", "GasFlux", "Power", "NowTime", "StartTime", "EndTime", "weldTime", "workTime", "channel", "channelcount" };
            this.welderDrvs.BeginUpdate();
            this.welderDrvs.Groups.Clear();
            this.welderDrvs.Items.Clear();
            
            //按照版主进行分类处理

            DataTable weldEquipments_dt = _Client.ServiceCall(clsCMD.cmd_weldEquipment_get, null);
            //进行分组；
            DataView weldeqdv = weldEquipments_dt.Copy().DefaultView;
            DataTable groups_dt=weldeqdv.ToTable(true,"FDepartID","FTODepartName");

            for (int goupc = 0; goupc < groups_dt.Rows.Count; goupc++)
            {
                ListViewGroup lvg = new ListViewGroup(groups_dt.Rows[goupc]["FDepartID"].ToString(), groups_dt.Rows[goupc]["FTODepartName"].ToString());
                this.welderDrvs.Groups.Add(lvg);

            }
            //panasoicWelderDT.DefaultView.RowFilter = "nom=822";
            //panasoicWelderDT = panasoicWelderDT.DefaultView.ToTable();
                for (int i = 0; i < panasoicWelderDT.Rows.Count; i++)
                {
                   

                    DataRow row = panasoicWelderDT.Rows[i];

                    DataView fweldedv = weldEquipments_dt.Copy().DefaultView;
                    fweldedv.RowFilter = "FweldEquipmentID="+row["nom"].ToString();
                    DataTable fweldedt = fweldedv.ToTable();

                    if (fweldedt.Rows.Count == 1)
                    {
                        if (this.showAllWelds.Checked == true || (Convert.ToInt64(fweldedt.Rows[0]["FDepartID"]) == welder_departid))
                        {
                            ListViewItem vitem = new ListViewItem();
                            vitem.Text = "焊机名称：" + Convert.ToString(fweldedt.Rows[0]["FEquipName"]);//row["equipname"]);//"焊机名称：" + Convert.ToString(row["equipname"]) + '\n';// +"焊接电压:" + Convert.ToString(row["wa"]) + "V 焊接电流:" + Convert.ToString(row["wa"]);
                            vitem.ToolTipText = Convert.ToString(row["nom"]);

                            String vstate = Convert.ToString(row["state"]);
                            if (vstate == "待机")
                            {
                                vitem.ImageIndex = 0;

                            }
                            else
                            {
                                vitem.ImageIndex = 1;

                            }

                            for (int g = 0; g < this.welderDrvs.Groups.Count; g++)
                            {
                                ListViewGroup vg = this.welderDrvs.Groups[g];
                                if (fweldedt.Rows[0]["FDepartID"].ToString() == vg.Name)
                                {
                                    vitem.Group = vg;
                                }
                            }
                            this.welderDrvs.Items.Add(vitem);
                        }
                    }

                }
            int c = this.welderDrvs.Items.Count;
            this.welderDrvs.Visible = true;
            //this.welderDrvs.Groups.
            this.welderDrvs.EndUpdate();
            return true;

        }
        /// <summary>
        /// 定时查询松下焊机状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            //查询焊机状态

        }

        private void welderDrvs_Click(object sender, EventArgs e)
        {
            //选择焊机
            int nom = 0;
            if (welderDrvs.SelectedItems.Count == 0)
                return;
            ListViewItem vpitem = welderDrvs.SelectedItems[0];
            nom = Convert.ToInt32(vpitem.ToolTipText);
            //welderDrvs.Visible = false;


            //调试需要暂时关闭
            //if (vpitem.ImageIndex == 1)
            //{
            //    welderDrvs.SelectedItems[0].Selected = false;
            //    return;
            //}

            //2015-06-29 取消焊机通道选择，修改为选择焊机后，直接开始工作，焊道为1-5焊道，5-10位保留焊道：即要求WPS必须在5个通道内
            /*
            welderChannel.Items.Clear();
            //与服务器交互获取通道信息
            DataTable channelDT = _Client.ServiceCall(cmd_WelderDrivers_GetDriversChannel, null);
            DataView channelDV = channelDT.DefaultView;
            String rowfilter = "nom={0}";
            channelDV.RowFilter = String.Format(rowfilter, nom);
            DataTable nomchannelsDT = channelDV.ToTable();
            for (int i = 0; i < nomchannelsDT.Rows.Count; i++)
            {
                DataRow row=nomchannelsDT.Rows[i];
                ListViewItem vitem = new ListViewItem();

                vitem.ImageIndex = 2;
                vitem.Text = "通道：" + Convert.ToInt32(Convert.ToInt32(row["channel"])+1) + '\n' + "焊接电流：" + (Convert.ToDouble(row["va_up"]) + Convert.ToDouble(row["va_down"])) / 2+"A";
                vitem.Text += '\n' + (Convert.ToDouble(row["vv_up"]) + Convert.ToDouble(row["vv_down"])) / 2 - Convert.ToDouble(row["vv_down"]);
                vitem.ToolTipText = Convert.ToString(Convert.ToInt32(row["channel"])+1);
                welderChannel.Items.Add(vitem);
            }
            //this.tabDrivers.CanFocus = false;
            //this.tabDrivers.CanSelect = false;
            this.tabDrivers.Parent = null;//隐藏焊机；
            this.tabChannels.Parent = this.tabControl1;
            this.tabChannels.Select();
            */
            //2015-06-29 取消焊机通道选择，修改弹出信息框，提示焊缝数据+涉及的焊道信息
            DataTable vdt = (DataTable)this.dataGrid.DataSource;
            welder_Task_Do(1, _curWelderTask_eRowIndex, 0, _curWelderTaskFID_DT, "CBUTBEGIN");
        }
        /// <summary>
        /// 再次检测焊机是否可用
        /// </summary>
        /// <param name="nom"></param>
        /// <returns></returns>
        protected Boolean CheckWelderCanused(int nom)
        {
            DataTable panasoicWelderDT = new DataTable();
            panasoicWelderDT = _Client.ServiceCall(cmd_WeldDrivers_GetDrivers, null);
            for (int i = 0; i < panasoicWelderDT.Rows.Count; i++)
            {
                DataRow row = panasoicWelderDT.Rows[i];
                if (Convert.ToInt32(row["nom"]) == nom)
                {
                    if (Convert.ToString(row["state"]) != "待机")
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        /// <summary>
        /// 挂起工作
        /// </summary>
        /// <returns></returns>
        private Boolean welder_Task_Pause()
        {
            ListViewItem vitem = welderDrvs.SelectedItems[0];
            int nom = Convert.ToInt32(vitem.ToolTipText);
            if (CheckWelderCanused(nom) == false)
            {
                //焊机状态不是待机状态，不能使用；
                MessageBox.Show("焊机被使用中或报警中不能分配任务");
            }
            else
            {
                DialogResult drs = MessageBox.Show(this, "请确认使用该焊机进行焊接", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
                //将焊机和通道加入到Databale中，发送给服务器进行处理
                switch (drs)
                {
                    case DialogResult.Yes:
                        {
                            //挂起;

                            break;
                        }
                    case DialogResult.No:
                        {
                            break;

                        }
                    case DialogResult.Cancel:
                        {
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }

            }
            return false;
        }
        /// <summary>
        /// 焊工选择焊机后进行下一步工作
        /// </summary>
        /// <param name="vstate">工作状态0 未开始 1 开始 2 完成 3 取消 4 挂起 5 继续 6 切换焊机</param>
        /// <returns></returns>
        private Boolean welder_Task_Do(int vstate, int cur_Rowindex, int cur_ColIndex, DataTable data, String curCellName)
        {
            int nom = 0;
            ListViewItem vitem;
            DialogResult drs = DialogResult.Yes;
            String[] Statedesc = { "正在进行..", "焊接完成", "" };
            if (_curWelderTaskFID_DT.Rows[0]["FweldDriverID"] == null)
                nom = 0;
            else
            {
                String strnom = Convert.ToString(_curWelderTaskFID_DT.Rows[0]["FweldDriverID"]);
                if (strnom.Length == 0)
                    nom = 0;
                else
                    nom = Convert.ToInt32(strnom);
            }
            switch (vstate)
            {
                case 1:case 6://开始
                    {
                        vitem = welderDrvs.SelectedItems[0];
                        nom = Convert.ToInt32(vitem.ToolTipText);
                        if (CheckWelderCanused(nom) == false)
                        {
                            //焊机状态不是待机状态，不能使用；
                            MessageBox.Show("焊机被使用中或报警中不能分配任务");
                            Fnum_TextChanged(Fnum, null);
                            return true;
                        }
                        drs = MessageBox.Show(this, "请确认使用该焊机进行焊接", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                        //检测焊机状态 
                       
                        break;
                    }
                    
                case 2://完成
                    {
                        drs = MessageBox.Show(this, "请确认完成焊接", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);

                        break;
                    }
                case 3://取消
                    {
                        drs = MessageBox.Show(this, "请确认完成焊接", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);

                        break;
                    }
                case 4://挂起
                    {
                        drs = MessageBox.Show(this, "请确认挂起焊接任务", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);

                        break;
                    }
                case 5://继续
                    {
                        nom = Convert.ToInt32(_curWelderTaskFID_DT.Rows[0]["FweldDriverID"]);
                        drs = MessageBox.Show(this, "请确认继续进行焊接", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                        //检测焊机状态
                        if (CheckWelderCanused(nom) == false)
                        {
                            //焊机状态不是待机状态，不能使用；
                            MessageBox.Show("焊机被使用中或报警中不能分配任务");
                            Fnum_TextChanged(Fnum, null);
                            return true;

                        }

                        break;
                    }
                default:
                    {
                        return false;
                        break;
                    }
            }





            //将焊机和通道加入到Databale中，发送给服务器进行处理
            switch (drs)
            {
                case DialogResult.Yes:
                    {
                        _curWelderTaskFID_DT.Rows[0]["FweldDriverID"] = nom;
                        //_curWelderTaskFID_DT.Rows[0]["FweldDriverTRUNID"] = channel;
                        _curWelderTaskFID_DT.Rows[0]["FSTATE"] = vstate;//开始；
                        //弹出焊缝的任务明细；
                        DataTable fdt = new DataTable();
                        DataColumn col = new DataColumn("FWELDID", typeof(long));
                        fdt.Columns.Add(col);
                        DataRow ndr = fdt.NewRow();
                        ndr[0] = _curWelderTaskFID_DT.Rows[0]["FWELDID"];
                        fdt.Rows.Add(ndr);
                        //获取焊缝最新数据
                        DataTable showdt;
                        if (Convert.ToInt32(_curWelderTaskFID_DT.Rows[0]["FID"]) == 0)
                        {
                            showdt = _Client.ServiceCall(562911, fdt);
                        }
                        else
                        {
                            showdt = _Client.ServiceCall(56291, fdt);
                        }
                        //显示匹配的焊机，以及焊机的通道设定信息，包含WPS信息等；


                        //showdt = _Client.ServiceCall(clsCMD.cmd_WeldTask_CheckWPSAndPreChannel, _curWelderTaskFID_DT);

                        if (showdt.Rows.Count == 0)
                        {
                            MessageBox.Show(this, "无任务焊缝", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dataGrid.Enabled = true;
                            this.welderDrvs.Items.Clear();
                            //this.welderChannel.Items.Clear();
                            this.dataGrid.Enabled = true;
                            this.dataGrid.Focus();
                            return false;
                        }
                        else
                        {
                            showdt.Columns.Add(new DataColumn("nom", typeof(String)));
                            for (int k = 0; k < showdt.Rows.Count; k++)
                            {
                                showdt.Rows[k]["nom"] = nom;
                            }
                            FormMCCL00023 vfrm = new FormMCCL00023(showdt);
                            if (vfrm.ShowDialog(this) == DialogResult.Yes)
                            {
                                showDownloadThread = new Thread(showDownLoadThreadpro);
                                showDownloadThread.Start();
                                DataTable rsdt = _Client.ServiceCall(7004, _curWelderTaskFID_DT);
                                
                                // this.dataGrid.DataSource = _curWelderTaskFID_DT;
                                this.dataGrid.Refresh();
                                //更新界面；
                                DataGridViewButtonCell but;
                                int rindex = this.gridView1.FocusedRowHandle;

                                switch (vstate)
                                {
                                    case 1:case 6://开始
                                        {
                                            if (this.gridView1.RowCount == 1)
                                                cur_Rowindex = 0;
                                            //but = (DataGridViewButtonCell)dataGrid.Rows[cur_Rowindex].Cells[curCellName];
                                            //but.Value = "正在进行...";
                                            //dataGrid.Enabled = true;
                                            this.gridView1.SetRowCellValue(rindex,"FSTATE",1);// dataGrid.Rows[cur_Rowindex].Cells["CFSTATE"].Value = 1;
                                            this.gridView1.SetRowCellValue(rindex,"FSTATE_DES","进行中..");//dataGrid.Rows[cur_Rowindex].Cells["CFSTATE_DES"].Value = "进行中..";
                                            break;
                                        }
                                    case 2://完成
                                        {
                                            this.gridView1.SetRowCellValue(rindex,"FSTATE",2);//dataGrid.Rows[cur_Rowindex].Cells["CFSTATE"].Value = 2;
                                            this.gridView1.SetRowCellValue(rindex,"FSTATE_DES","完成");//dataGrid.Rows[cur_Rowindex].Cells["CFSTATE_DES"].Value = "完成";
                                            break;
                                        }
                                    case 3://取消
                                        {
                                            this.gridView1.SetRowCellValue(rindex,"FSTATE",0);//dataGrid.Rows[cur_Rowindex].Cells["CFSTATE"].Value = 0;
                                            this.gridView1.SetRowCellValue(rindex,"FSTATE_DES","未开始");//dataGrid.Rows[cur_Rowindex].Cells["CFSTATE_DES"].Value = "未开始";
                                            break;
                                        }
                                    case 4://挂起
                                        {
                                            this.gridView1.SetRowCellValue(rindex,"FSTATE",4);//dataGrid.Rows[cur_Rowindex].Cells["CFSTATE"].Value = 4;
                                            this.gridView1.SetRowCellValue(rindex,"FSTATE_DES","挂起");//dataGrid.Rows[cur_Rowindex].Cells["CFSTATE_DES"].Value = "挂起";
                                            break;
                                        }
                                    case 5://继续
                                        {
                                            // but = (DataGridViewButtonCell)dataGrid.Rows[cur_Rowindex].Cells[curCellName];
                                            //but.Value = "正在进行...";
                                            //dataGrid.Enabled = true;
                                            //修改状态值为1
                                            if (this.gridView1.RowCount == 1)
                                                cur_Rowindex = 0;
                                           this.gridView1.SetRowCellValue(rindex,"FSTATE",1); //dataGrid.Rows[cur_Rowindex].Cells["CFSTATE"].Value = 1;
                                           this.gridView1.SetRowCellValue(rindex, "FSTATE_DES", "进行中..");//dataGrid.Rows[cur_Rowindex].Cells["CFSTATE_DES"].Value = "进行中..";
                                            break;
                                        }
                                    default:
                                        {
                                            break;
                                        }
                                }
                                //dataGrid.Rows[cur_Rowindex].Cells["CFSTATE"].Value = vstate;

                            }
                            else
                            {
                                //this.tabChannels.Parent = this.tabControl1;
                                //this.tabDrivers.Parent = this.tabControl1;
                                //this.tabControl1.Enabled = false;
                                Fnum_TextChanged(Fnum, null);
                            }
                        }
                        break;
                    }
                case DialogResult.No:
                    {
                        //this.tabChannels.Parent = this.tabControl1;
                        //this.tabDrivers.Parent = this.tabControl1;
                        //this.tabControl1.Enabled = false;
                        Fnum_TextChanged(Fnum, null);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
           
            welderDrvs.Enabled = false;
            Fnum_TextChanged(Fnum, null);
            return false;
        }
        /// <summary>
        /// 焊工选择到了焊道
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void welderChannel_Click(object sender, EventArgs e)
        {
            //点击选择焊道信息
            //if (welderChannel.SelectedItems.Count > 0)
            //{
            //    //得到焊机通道数;
            //    ListViewItem vitem = welderChannel.SelectedItems[0];
            //    int channel = Convert.ToInt32(vitem.ToolTipText);
            //    //提示焊工即将开始使用该焊机的该通道进行焊接
            //    vitem = welderDrvs.SelectedItems[0];
            //    int nom = Convert.ToInt32(vitem.ToolTipText);
            //    if (CheckWelderCanused(nom) == false)
            //    {
            //        //焊机状态不是待机状态，不能使用；
            //        MessageBox.Show("焊机被使用中或报警中不能分配任务");
            //        welderChannel.Items.Clear();
            //        tabChannels.Parent = null;
            //        tabDrivers.Parent = this.tabControl1;
            //        //welderDrvs.SelectedItems.Clear();
            //        loadTab();
            //    }
            //    else
            //    {
            //        DialogResult drs = MessageBox.Show(this, "请确认使用该焊机的该通道进行焊接", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
            //        //将焊机和通道加入到Databale中，发送给服务器进行处理
            //        switch (drs)
            //        {
            //            case DialogResult.Yes:
            //                {
            //                    _curWelderTaskFID_DT.Rows[0]["FweldDriverID"] = nom;
            //                    _curWelderTaskFID_DT.Rows[0]["FweldDriverTRUNID"] = channel;
            //                    _curWelderTaskFID_DT.Rows[0]["FSTATE"] = 1;//开始；
            //                    //向服务器发送请求进行操作；
            //                    DataTable rsdt = _Client.ServiceCall(7004, _curWelderTaskFID_DT);

            //                    this.dataGrid.DataSource = _curWelderTaskFID_DT;
            //                    this.dataGrid.Refresh();
            //                    //更新界面；
            //                    DataGridViewButtonCell butBegin = (DataGridViewButtonCell)dataGrid.Rows[_curWelderTask_eRowIndex].Cells["CBUTBEGIN"];

            //                    butBegin.Value = "正在进行...";
            //                    dataGrid.Enabled = true;
            //                    dataGrid.Rows[_curWelderTask_eRowIndex].Cells["CFSTATE_DES"].Value = "进行中..";
            //                    break;
            //                }
            //            case DialogResult.No:
            //                {
            //                    this.tabChannels.Parent = this.tabControl1;
            //                    this.tabDrivers.Parent = this.tabControl1;
            //                    this.tabControl1.Enabled = false;
            //                    break;
            //                }
            //            case DialogResult.Cancel:
            //                {
            //                    this.welderDrvs.Items.Clear();
            //                    this.welderChannel.Items.Clear();
            //                    this.dataGrid.Enabled = true;
            //                    this.dataGrid.Focus();
            //                    break;
            //                }
            //            default:
            //                {
            //                    break;
            //                }
            //        }



            //    }
            //}
            //else
            //{
            //    MessageBox.Show("请选择焊道");
            //}
        }

        private void welderDrvs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void FormMCCL00022_EF_PRE_DO_F1(object sender, EF_Args e)
        {
            button1_Click(null, null);
        }

        private void FormMCCL00022_EF_DO_F1(object sender, EF_Args e)
        {
            if (this.Control1.SelectedTab == this.tabPage2)
            {
                if (MessageBox.Show(this, "是否取消?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    this.welderDrvs.Items.Clear();
                    this.tabPage2.Parent = null;
                    this.tabPage1.Parent = this.Control1;
                    this.Control1.SelectedTab = this.tabPage1;
                }
                this.Fnum_TextChanged(this.Fnum, null);
            }
        }

        private void ReadCardTimer_Tick(object sender, EventArgs e)
        {
            //string empNO = "";string empName = "";
            //int cardId = 0;
            //int retValue = this.ReadCard.ReadCard(ref empNO, ref empName, ref cardId);

            //if (retValue == -1)
            //{
            //    MessageBox.Show("打开串口错误，未能识别读卡器！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //else if (retValue == -2)
            //{
            //    MessageBox.Show("卡片信息有误，未能识别卡片信息！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //if (empNO.Length == 0)
            //    return;
            //if (empNO == Fnum.Text)
            //    return;
            //if (empNO.Length != 8)
            //    return;
            //Fnum.Text = empNO; FName.EFEnterText = empName;
            //ReadCardTimer.Enabled = false;

         

            try
            {
                dgt_readcard rd = new dgt_readcard(actreadcard);
                BeginInvoke(rd);
                //ThreadState ss = readCardThread.ThreadState;
                //if (ss==ThreadState.Unstarted)
                //    readCardThread.Start();
                //readCardThread = new Thread(new ThreadStart(readCardThreadpro));
                //readCardThread.Start();
                //if (readCardThread.IsAlive)
                //{

                //}
                //else
                //{
                //    readCardThread.Start();
                //}
            }
            catch (Exception ex) { String exss = ex.Message.ToString(); }
            
            //ReadCardTimer.Enabled = true;
        }

        private void efButton1_Click(object sender, EventArgs e)
        {
            ReadCardTimer.Enabled = true;
            ReadCardTimer.Start();
        }
        /// <summary>
        /// 多项选择发生时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemCheck_CheckedChanged(object sender, EventArgs e)
        {
            //String v = this.gridView1.getC(this.gridView1.FocusedRowHandle, "FChecked").ToString();
            int cke =Convert.ToInt32(((DevExpress.XtraEditors.CheckEdit)sender).EditValue);// Convert.ToInt32(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "FChecked") == null ? 0 : this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "FChecked"));
            //this.gridView1.GetRowCellDisplayText(
            if (cke == 1)
            {
                taskcount++;
            }
            else
            {
                taskcount--;
            }

        }

        private void ItemCheck_EditValueChanged(object sender, EventArgs e)
        {
            int cke = Convert.ToInt32(((DevExpress.XtraEditors.CheckEdit)sender).EditValue);// Convert.ToInt32(this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "FChecked") == null ? 0 : this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, "FChecked"));
            //this.gridView1.GetRowCellDisplayText(
            if (cke == 1)
            {
                taskcount++;
            }
            else
            {
                taskcount--;
            }

        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Fnum_TextChanged(null, null);
        }

        private void Read_Click(object sender, EventArgs e)
        {
            ReadCardTimer.Enabled = true;
            ReadCardTimer.Start();
        }

        private void showAllWelds_CheckedChanged(object sender, EventArgs e)
        {
            loadTab();
        }
    }
}
