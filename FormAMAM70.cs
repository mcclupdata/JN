using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Common;
using System.IO;

namespace AM
{
    public partial class FormAMAM70 : EF.EFForm
    {
        public FormAMAM70()
        {
            InitializeComponent();
        }

        private bool savFlag = false;

        private string returnFlag = "";
        #region 初始化
        private void FormAMAM70_Load(object sender, EventArgs e)
        {
            this.tAM50BindingSource.AllowNew = true;
            this.tAM50BindingSource.AddNew();
            this.tAM50BindingSource.EndEdit();

            ////小代码
            //交接单状态
            this.tAM50EFGrid.Cols["STATUS"].DataMap = Common.Utility.QueryCodeHashTable("APPLY_STATUS_N");
            //接收部门
            Hashtable DeptNoHT = Common.Utility.QueryCodeHashTable("DEPT_NO");
            tAM50EFGrid.Cols["DEPT_NO"].DataMap = DeptNoHT;
            this.efGridNRM.Cols["DEPT_NO_A"].DataMap = DeptNoHT;
            this.efGridNRM.Cols["WORKING_AREA"].DataMap = Common.Utility.QueryCodeHashTable("WORKING_AREA");
            this.efGridNRM.Cols["WORKING_GROUP"].DataMap = Common.Utility.QueryCodeHashTable("WORKING_GROUP");
            //发出部门
            tAM50EFGrid.Cols["DEPT_NO_R"].DataMap = Common.Utility.QueryCodeHashTable("DEPT_NO");
            tAM50EFGrid.Cols["OUT_MODE"].DataMap = Common.Utility.QueryCodeHashTable("OUT_MODE");

            //tAM51EFGrid.Cols["SHIP_NO"].DataMap = Common.Utility.QueryHashTable("SELECT TEMPLATE_NO,TEMPLATE_NO AS TEMPLATE_NAME FROM TPSOF50 WHERE IS_MODEL <> '1'");

            //页面加载获取仓库信息到仓库下拉框
            Hashtable stockNoHT = Common.Utility.QueryHashTable("select DEPOT_CODE,DEPOT_NAME from TAMAM009");
            this.tAM50EFGrid.Cols["STOCK_NO"].DataMap = stockNoHT;
            this.efGridNRM.Cols["STOCK_NO_A"].DataMap = stockNoHT;

            //签收人
            tAM50EFGrid.Cols["STAFF_NO_COM"].DataMap = Common.Utility.QueryHashTable("select ename,cname from TESUSERINFO");
            tAM50EFGrid.Cols["STAFF_NO_SIGN"].DataMap = Common.Utility.QueryHashTable("select ename,cname from TESUSERINFO");


            this.rEC_CREATE_TIMEJNDateTimePicker.UserValue = "";
            this.oPERATE_TIMEJNDateTimePicker.UserValue = "";

            this.bEG_TIMEJNDateTimePicker.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            this.eND_TIMEJNDateTimePicker.Value = DateTime.Now;

            // 获取登录人信息
            UserInfo userInfo = this.GetCurrentUserInfo();
            if (userInfo.EXIST_FLAG)
            {
                this.tAM.TAM50.Rows[0]["DEPT_NO"] = userInfo.DEPT_NO;
                deptnoJNComboBox.UserValue = userInfo.DEPT_NO;
                deptnoJNComboBox.Enabled = false;
                this.dEPT_NOJNComboBox.Enabled = false;
            }
            else
            {
                this.dEPT_NOJNComboBox.Enabled = true;
                this.deptnoJNComboBox.Enabled = true;
            }
            //获取仓库代码
            if (this.GetCurrentUserInfo().DEPT_NO != null)
            {
                string staff_no = this.GetCurrentUserInfo().STAFF_NO.Trim();
                EI.EIInfo inBlock = Common.Utility.ExecQuery("select DEPOT_CODE from TAMAM011 where STAFF_NO=dbo.nvl(" + "'" + staff_no + "'" + ",staff_no)");
                if (inBlock.Tables[0].Rows.Count > 0)
                {
                    sTOCK_NOJNComboBox.SelectedValue = inBlock.Tables[0].Rows[0][0].ToString();
                    stocknoJNComboBox.SelectedValue = inBlock.Tables[0].Rows[0][0].ToString();
                    this.tAM50BindingSource.EndEdit();
                }
                else
                {
                    this.sTOCK_NOJNComboBox.Enabled = true;
                    this.stocknoJNComboBox.Enabled = true;
                }
            }
            else
            {
                this.sTOCK_NOJNComboBox.Enabled = true;
            }
            this.tAM.TAM50.Rows[0]["OUT_MODE"] = "50";
            outmodeJNComboBox.UserValue = "50";

            //归还标记
            //Hashtable tb = new Hashtable();
            //tb.Add("1", "是");
            //tb.Add("0", "否");
            //tb.Add("2", "长借");
            this.tAM51EFGrid.Cols["RETURN_FLAG"].DataMap = Common.Utility.QueryCodeHashTable("RETURN_FLAG");
            this.efGridNRM.Cols["RETURN_FLAG"].DataMap = Common.Utility.QueryCodeHashTable("RETURN_FLAG_TYPE");
            this.efGrid1.Cols["RETURN_FLAG"].DataMap = Common.Utility.QueryCodeHashTable("RETURN_FLAG");

            // 设置库存树状结构
            this.SetStoreTree(this.dEPT_NOJNComboBox.UserValue, this.sTOCK_NOJNComboBox.UserValue, this.sTOCK_NOJNComboBox.Text);
        }
        #endregion

        #region 保存按钮
        private void FormAMAM70_EF_DO_F4(object sender, EF.EF_Args e)
        {
            this.savFlag = false;
            if (this.tAM51EFGrid.EFChoiceCount < 1)
            {
                MessageBox.Show("没有选择明细信息不能保存！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(this.dEPT_NOJNComboBox.UserValue.Trim()))
            {
                MessageBox.Show("请选择出库部门！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrEmpty(this.dEPT_NO_RJNComboBox.UserValue.Trim()) || string.IsNullOrEmpty(this.sTAFF_NO_SIGNEFTextBox.Text.Trim()))
            {
                MessageBox.Show("请选择领料部门和领料人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            EI.EIInfo inblock = new EI.EIInfo();

            // 设置入库单主信息
            this.tAM50BindingSource.EndEdit();
            this.tAM.TAM50.Rows[0]["REC_CREATE_TIME"] = this.rEC_CREATE_TIMEJNDateTimePicker.UserValue;
            this.tAM.TAM50.Rows[0]["OPERATE_TIME"] = this.oPERATE_TIMEJNDateTimePicker.UserValue;
            inblock.DataSet.Tables[0].Merge(this.tAM.TAM50);

            // 设置入库单明细信息
            inblock.AddNewBlock();
            inblock.blk_now = 1;
            inblock.SetBlockVal(this.tAM51EFGrid);

            if (this.efTextBoxAllowBy.Text.Trim().Length > 0)
            {
                foreach (DataRow dr in inblock.Tables[1].Rows)
                {
                    dr["ALLOW_BY"] = this.efTextBoxAllowBy.Text.Trim();
                }
            }

            // 检查必输项
            for (int i = 0; i < inblock.DataSet.Tables[1].Rows.Count; i++)
            {
                if (inblock.DataSet.Tables[1].Rows[i]["QUANTITY"] == DBNull.Value || Convert.ToDecimal(inblock.DataSet.Tables[1].Rows[i]["QUANTITY"]) <= 0)
                {
                    MessageBox.Show("选择的物料明细中必须输入出库数量！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (inblock.DataSet.Tables[1].Rows[i]["RETURN_FLAG"] == DBNull.Value || string.IsNullOrEmpty(inblock.DataSet.Tables[1].Rows[i]["RETURN_FLAG"].ToString()))
                {
                    MessageBox.Show("是否需归还？", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            // 保存处理
            EI.EIInfo outblock = EI.EITuxedo.CallService("amam_70_save", inblock);

            //出错处理
            if ((outblock.sys_info.sqlcode != 0) || (outblock.sys_info.flag != 0))
            {
                this.EFMsgInfo = outblock.sys_info.msg;
                MessageBox.Show(this.EFMsgInfo, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.RetrieveData(outblock.Tables[0].Rows[0]["HANDOVER_NO"].ToString());
            MessageBox.Show("操作成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.savFlag = true;
        }
        #endregion

        #region 根据出库单号查询信息设置画面
        private void RetrieveData(string handoverNo)
        {
            // 组织查询条件并调用后台service查询信息
            EI.EIInfo inblock = new EI.EIInfo();
            inblock.DataSet.Tables[0].Columns.Add("HANDOVER_NO");
            inblock.SetColVal(1, "HANDOVER_NO", handoverNo);
            EI.EIInfo outblock = EI.EITuxedo.CallService("amam_50_retrieve", inblock);

            if (outblock.DataSet.Tables[0].Rows.Count == 0)
            {
                FormAMAM70_EF_DO_F7(null, null);
                return;
            }
            // 设置主项信息 
            // 从block中Merge到画面
            this.tAM.TAM50.Clear();
            this.tAM.TAM50.AcceptChanges();
            this.tAM.TAM50.Merge(outblock.DataSet.Tables[0]);
            this.rEC_CREATE_TIMEJNDateTimePicker.UserValue = outblock.DataSet.Tables[0].Rows[0]["REC_CREATE_TIME"].ToString();
            this.oPERATE_TIMEJNDateTimePicker.UserValue = outblock.DataSet.Tables[0].Rows[0]["OPERATE_TIME"].ToString();

            // 设置入库单明细信息
            outblock.blk_now = 1;
            outblock.GetBlockVal(this.tAM51EFGrid);

            // 设置画面是否可编辑
            if (outblock.DataSet.Tables[0].Rows[0]["STATUS"].ToString() == "1")
            {
                this.dEPT_NOJNComboBox.Enabled = true;
                this.tAM51EFGrid.AllowEditing = true;
                this.oUT_MODEJNComboBox.Enabled = true;
                this.aPPLY_NOEFTextBox.Enabled = true;
                this.sTOCK_NOJNComboBox.Enabled = true;
                this.txtEmpNo.Enabled = true;
                // 获取登录人信息
                UserInfo userInfo = this.GetCurrentUserInfo();
                if (userInfo.EXIST_FLAG)
                {
                    this.dEPT_NOJNComboBox.UserValue = userInfo.DEPT_NO;
                    this.dEPT_NOJNComboBox.Enabled = false;
                }
                else
                {
                    this.dEPT_NOJNComboBox.Enabled = true;
                }
                //获取仓库代码
                if (this.GetCurrentUserInfo().DEPT_NO != null)
                {
                    string staff_no = this.GetCurrentUserInfo().STAFF_NO.Trim();
                    EI.EIInfo inBlock = Common.Utility.ExecQuery("select DEPOT_CODE from TAMAM011 where STAFF_NO=dbo.nvl(" + "'" + staff_no + "'" + ",staff_no)");
                    if (inBlock.Tables[0].Rows.Count > 0)
                    {
                        sTOCK_NOJNComboBox.SelectedValue = inBlock.Tables[0].Rows[0][0].ToString();
                        this.tAM50BindingSource.EndEdit();
                    }
                    else
                    {
                        this.sTOCK_NOJNComboBox.Enabled = true;
                    }
                }
                else
                {
                    this.sTOCK_NOJNComboBox.Enabled = true;
                }
            }
            else
            {
                this.dEPT_NOJNComboBox.Enabled = false;
                this.oUT_MODEJNComboBox.Enabled = false;
                this.aPPLY_NOEFTextBox.Enabled = false;
                this.tAM51EFGrid.AllowEditing = false;
                this.sTOCK_NOJNComboBox.Enabled = false;
                this.sTAFF_NO_SIGNEFTextBox.Enabled = false;
                this.txtEmpNo.Enabled = false;
            }

        }
        #endregion

        #region 新增按钮
        private void FormAMAM70_EF_DO_F2(object sender, EF.EF_Args e)
        {
            //if (this.efTabControl1.SelectedIndex == 1) return;
            //int typeCount = 0;
            //if (this.efTree1.Nodes == null)
            //    return;
            //int index = this.efTree1.SelectedNode.Level;
            //string as_place = "";

            //if (index == 0)
            //{
            //    as_place = "";
            //}
            //else if (index == 1)
            //{
            //    as_place = this.efTree1.SelectedNode.Name;
            //}
            if (this.efTabControl1.SelectedIndex != 0)
                return;
            if (string.IsNullOrEmpty(this.dEPT_NOJNComboBox.UserValue.Trim()))
            {
                MessageBox.Show("请选择出库部门！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.efGrid1.EFUserRows < 1 || this.efGrid1.EFChoiceCount < 1)
                return;
            // 申请单为空时，从库存中增加信息
            if (string.IsNullOrEmpty(this.aPPLY_NOEFTextBox.Text))
            {

                string sql = string.Format(@"SELECT distinct 
                            isnull((SELECT TAMAM090.TYPE_DESC  
                            FROM TAMAM090 WHERE TAMAM090.ROWGUID = 
                                (SELECT TAMAM091.FK_TAMAM090_ROWGUID 
                                    FROM TAMAM091 WHERE TAMAM091.MAT_CODE=a2.MAT_NO)),'') AS ABC_TYPE 
                            ,a2.MAT_NO
                            FROM TAM50 a1,TAM51 a2,vlmbi01 a3 WHERE a1.staff_no_sign *= a3.staff_no and a2.HANDOVER_NO = a1.HANDOVER_NO AND 
                            a1.DEPT_NO = '{0}' AND
                            a2.OUT_MODE = '50' and  
                            a1.STOCK_NO = '{1}' AND 
                            a1.STAFF_NO_SIGN = '{2}' AND 
                            a2.RETURN_FLAG ='1' AND a2.QUANTITY - a2.RETURN_NUM>0 "
                       , this.dEPT_NOJNComboBox.UserValue
                       , this.sTOCK_NOJNComboBox.UserValue
                       , this.txtEmpNo.Text.Trim().ToString()
                       );

                EI.EIInfo typeInfo = Common.Utility.ExecQuery(sql);
                if (this.isUsedABCType())
                {

                    int typeA = 0;
                    int typeB = 0;
                    int typeC = 0;
                    for (int k = 0; k < typeInfo.Tables[0].Rows.Count; k++)
                    {
                        if (typeInfo.Tables[0].Rows[k]["ABC_TYPE"].ToString().Trim() == "B")
                        {
                            typeB++;
                        }
                        if (typeInfo.Tables[0].Rows[k]["ABC_TYPE"].ToString().Trim() == "C")
                        {
                            typeC++;
                        }
                    }

                    if (true)
                    {
                        bool checkOption = false;
                        string abcType = string.Empty;
                        string returnFlag = string.Empty;
                        for (int j = 1; j <= this.efGrid1.EFUserRows; j++)
                        {
                            if (this.efGrid1[j, "check_option"] != null)
                                checkOption = (bool)this.efGrid1[j, "check_option"];
                            if (this.efGrid1[j, "ABC_TYPE"] != null)
                                abcType = this.efGrid1[j, "ABC_TYPE"].ToString().Trim();
                            if (this.efGrid1[j, "RETURN_FLAG"] != null)
                                returnFlag = this.efGrid1[j, "RETURN_FLAG"].ToString().Trim();
                            if (checkOption == true && abcType == "B" && returnFlag.CompareTo("1") == 0)
                            {
                                if (typeInfo.Tables[0].Select("MAT_NO='" + this.efGrid1[j, "MAT_CODE"].ToString() + "'").Length == 0)
                                    typeB++;
                            }
                            if (checkOption == true && abcType == "C" && returnFlag.CompareTo("1") == 0)
                            {
                                if (typeInfo.Tables[0].Select("MAT_NO='" + this.efGrid1[j, "MAT_CODE"].ToString() + "'").Length == 0)
                                    typeC++;
                            }
                        }
                    }
                    if (this.efTextBoxABCType.Text.Trim().ToString() != "A")
                    {
                        if (this.efTextBoxABCType.Text.Trim().ToString() == "B")
                        {
                            for (int n = 1; n <= this.efGridABC.EFUserRows; n++)
                            {
                                if (this.efGridABC.Rows[n]["TYPE_DESC"].ToString().Trim() == "B" && typeB > Convert.ToInt32(this.efGridABC.Rows[n]["QUANTITY_ABLE"]))
                                {
                                    MessageBox.Show("B类型超过可领用数量！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                //int a = Convert.ToInt32(this.efGridABC.Rows[n]["QUANTITY_ABLE"]);
                                if (this.efGridABC.Rows[n]["TYPE_DESC"].ToString().Trim() == "C" && typeC > Convert.ToInt32(this.efGridABC.Rows[n]["QUANTITY_ABLE"]))
                                {
                                    MessageBox.Show("C类型超过可领用数量！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                        }
                        if (this.efTextBoxABCType.Text.Trim().ToString() == "C")
                        {
                            if (this.efGridABC.Rows.Count != 1)
                            {
                                if (typeC > Convert.ToInt32(this.efGridABC.Rows[1]["QUANTITY_ABLE"]))
                                {
                                    MessageBox.Show("C类型超过可领用数量！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                        }
                    }
                }

                // 去除重复项 efTextBoxABCType
                for (int i = 1; i <= this.efGrid1.EFUserRows; i++)
                {
                    if (this.efGrid1[i, "check_option"] == null || (bool)this.efGrid1[i, "check_option"] == false)
                        continue;

                    if (efGrid1.Rows[i]["QUANTITY_LY"] == null || string.IsNullOrEmpty(efGrid1.Rows[i]["QUANTITY_LY"].ToString()))
                    {
                        MessageBox.Show("第" + i.ToString() + "行必须输入领用数量！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (this.isUsedABCType())
                    {
                        if (efGrid1.Rows[i]["RETURN_FLAG"] == null || string.IsNullOrEmpty(efGrid1.Rows[i]["RETURN_FLAG"].ToString()))
                        {
                            MessageBox.Show("第" + i.ToString() + "行必须输入是否归还！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (this.efTextBoxABCType.Text.Trim().ToString() == "C")
                        {
                            if (this.efGrid1[i, "ABC_TYPE"] != null && this.efGrid1[i, "ABC_TYPE"].ToString().Trim() != "C")
                            {
                                MessageBox.Show("第" + i.ToString() + "行不是【C】类物料，当前人员无权领用", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        if (this.efTextBoxABCType.Text.Trim().ToString() == "B")
                        {
                            if (this.efGrid1[i, "ABC_TYPE"] != null && this.efGrid1[i, "ABC_TYPE"].ToString().Trim() != "B"
                                && this.efGrid1[i, "ABC_TYPE"].ToString().Trim() != "C")
                            {
                                MessageBox.Show("第" + i.ToString() + "行不是【B或者C】类物料，当前人员无权领用", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        if (this.efTextBoxABCType.Text.Trim().ToString() != "A")
                        {
                            if (efGrid1.Rows[i]["RETURN_FLAG"] != null && efGrid1.Rows[i]["RETURN_FLAG"].ToString().CompareTo("1") == 0)
                            {
                                Decimal TYPE_QUANTITY = 0;
                                if (efGrid1.Rows[i]["TYPE_QUANTITY"] != null)
                                    TYPE_QUANTITY = (Decimal)efGrid1.Rows[i]["TYPE_QUANTITY"];
                                Decimal QUANTITY_HAD = 0;
                                if (efGrid1.Rows[i]["QUANTITY_HAD"] != null)
                                {
                                    QUANTITY_HAD = (Decimal)efGrid1.Rows[i]["QUANTITY_HAD"];
                                }
                                //Decimal b = (Decimal)efGrid1.Rows[i]["QUANTITY_HAD"];
                                if (efGrid1.Rows[i]["ABC_TYPE"] != null && efGrid1.Rows[i]["ABC_TYPE"].ToString().Trim().Length > 0)
                                {
                                    if ((Decimal)efGrid1.Rows[i]["QUANTITY_LY"] > TYPE_QUANTITY - QUANTITY_HAD)
                                    {
                                        MessageBox.Show("第" + i.ToString() + "行领用数量大于当前[领用上限]！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        efGrid1.Rows[i]["QUANTITY_LY"] = (TYPE_QUANTITY - QUANTITY_HAD) < 0 ? 0 : (TYPE_QUANTITY - QUANTITY_HAD);
                                        //return;
                                    }
                                }
                            }
                        }
                    }

                    if ((Decimal)efGrid1.Rows[i]["QUANTITY_LY"] > (Decimal)efGrid1.Rows[i]["QUANTITY"])
                    {
                        MessageBox.Show("第" + i.ToString() + "行领用数量大于当前[库存数量]！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        efGrid1.Rows[i]["QUANTITY_LY"] = efGrid1.Rows[i]["QUANTITY"];
                        //return;
                    }

                    int findRowIndex = this.tAM51EFGrid.FindRow(efGrid1.Rows[i]["MAT_CODE"].ToString(), 0, this.tAM51EFGrid.Cols["MAT_NO"].Index, true, true, false);
                    if (findRowIndex > 0)
                    {
                        this.tAM51EFGrid[findRowIndex, "QUANTITY"] = efGrid1.Rows[i]["QUANTITY_LY"];
                        this.tAM51EFGrid[findRowIndex, "RETURN_FLAG"] = efGrid1.Rows[i]["RETURN_FLAG"];
                        //continue;
                    }
                    else
                    {
                        // 赋值
                        this.tAM51EFGrid.EFUserRows++;
                        this.tAM51EFGrid[this.tAM51EFGrid.EFUserRows, "MAT_NO"] = efGrid1.Rows[i]["MAT_CODE"];
                        this.tAM51EFGrid[this.tAM51EFGrid.EFUserRows, "MAT_NAME"] = efGrid1.Rows[i]["MAT_NAME"];
                        this.tAM51EFGrid[this.tAM51EFGrid.EFUserRows, "MAT_TYPE"] = efGrid1.Rows[i]["MAT_CODE_A"];
                        this.tAM51EFGrid[this.tAM51EFGrid.EFUserRows, "SPEC"] = efGrid1.Rows[i]["SPEC"];
                        this.tAM51EFGrid[this.tAM51EFGrid.EFUserRows, "MAT_MODEL"] = efGrid1.Rows[i]["MAT_MODEL"];
                        this.tAM51EFGrid[this.tAM51EFGrid.EFUserRows, "MATERIAL"] = efGrid1.Rows[i]["MATERIAL"];
                        this.tAM51EFGrid[this.tAM51EFGrid.EFUserRows, "MEASURE_UNIT"] = efGrid1.Rows[i]["MEASURE_UNIT_DESC"];
                        this.tAM51EFGrid[this.tAM51EFGrid.EFUserRows, "MEASURE_UNIT_A"] = efGrid1.Rows[i]["MEASURE_UNIT_A_DESC"];
                        this.tAM51EFGrid[this.tAM51EFGrid.EFUserRows, "STD_NO"] = efGrid1.Rows[i]["STD_NO"];
                        this.tAM51EFGrid[this.tAM51EFGrid.EFUserRows, "AS_PLACE"] = efGrid1.Rows[i]["AS_PLACE"];
                        this.tAM51EFGrid[this.tAM51EFGrid.EFUserRows, "AS_PRICE"] = efGrid1.Rows[i]["AS_PRICE"];
                        this.tAM51EFGrid[this.tAM51EFGrid.EFUserRows, "QUANTITY"] = efGrid1.Rows[i]["QUANTITY_LY"];
                        this.tAM51EFGrid[this.tAM51EFGrid.EFUserRows, "RETURN_FLAG"] = efGrid1.Rows[i]["RETURN_FLAG"];
                        this.tAM51EFGrid[this.tAM51EFGrid.EFUserRows, "check_option"] = true;
                    }
                }
            }
        }
        #endregion

        #region 删除单据
        private void FormAMAM70_EF_DO_F3(object sender, EF.EF_Args e)
        {
            if (string.IsNullOrEmpty(this.hANDOVER_NOEFTextBox.Text.Trim()))
                return;
            // 组织查询条件并调用后台service查询信息
            EI.EIInfo inblock = new EI.EIInfo();
            inblock.DataSet.Tables[0].Columns.Add("HANDOVER_NO");
            inblock.SetColVal(1, "HANDOVER_NO", this.hANDOVER_NOEFTextBox.Text.Trim());
            EI.EIInfo outblock = EI.EITuxedo.CallService("amam_50_del", inblock);
            //出错处理
            if ((outblock.sys_info.sqlcode != 0) || (outblock.sys_info.flag != 0))
            {
                this.EFMsgInfo = outblock.sys_info.msg;
                MessageBox.Show(this.EFMsgInfo, "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // 调用重置画面按钮事件
            this.FormAMAM70_EF_DO_F7(sender, e);
            MessageBox.Show("操作成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region 出库操作
        private void FormAMAM70_EF_DO_F5(object sender, EF.EF_Args e)
        {
            #region 出库
            //if (this.hANDOVER_NOEFTextBox.Text == null || hANDOVER_NOEFTextBox.Text == "")
            //{
            //    MessageBox.Show("请先保存该出库单！");
            //    return;
            //}
            //EI.EIInfo inBlock = new EI.EIInfo();

            //inBlock.DataSet.Tables[0].Columns.Add("HANDOVER_NO");//交接单号

            //inBlock.SetColVal(1, 1, "HANDOVER_NO", this.hANDOVER_NOEFTextBox.Text.ToString());

            //EI.EIInfo outblock = EI.EITuxedo.CallService("amam_70_submit", inBlock);

            ////出错处理
            //if ((outblock.sys_info.sqlcode != 0) || (outblock.sys_info.flag != 0))
            //{
            //    this.EFMsgInfo = outblock.sys_info.msg;
            //    MessageBox.Show(this.EFMsgInfo, "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //this.RetrieveData(this.hANDOVER_NOEFTextBox.Text.Trim());
            //MessageBox.Show("操作成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ////重置画面
            //this.FormAMAM70_EF_DO_F7(sender, e);
            #endregion

            #region 保存出库
            if (this.tAM51EFGrid.EFChoiceCount < 1)
            {
                MessageBox.Show("没有选择明细信息不能保存！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(this.dEPT_NOJNComboBox.UserValue.Trim()))
            {
                MessageBox.Show("请选择出库部门！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrEmpty(this.dEPT_NO_RJNComboBox.UserValue.Trim()) || string.IsNullOrEmpty(this.sTAFF_NO_SIGNEFTextBox.Text.Trim()))
            {
                MessageBox.Show("请选择领料部门和领料人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            EI.EIInfo inblock = new EI.EIInfo();

            // 设置入库单主信息
            this.tAM50BindingSource.EndEdit();
            this.tAM.TAM50.Rows[0]["REC_CREATE_TIME"] = this.rEC_CREATE_TIMEJNDateTimePicker.UserValue;
            this.tAM.TAM50.Rows[0]["OPERATE_TIME"] = this.oPERATE_TIMEJNDateTimePicker.UserValue;
            inblock.DataSet.Tables[0].Merge(this.tAM.TAM50);

            // 设置入库单明细信息
            inblock.AddNewBlock();
            inblock.blk_now = 1;
            inblock.SetBlockVal(this.tAM51EFGrid);

            // 检查必输项
            for (int i = 0; i < inblock.DataSet.Tables[1].Rows.Count; i++)
            {
                if (inblock.DataSet.Tables[1].Rows[i]["QUANTITY"] == DBNull.Value || Convert.ToDecimal(inblock.DataSet.Tables[1].Rows[i]["QUANTITY"]) <= 0)
                {
                    MessageBox.Show("选择的物料明细中必须输入出库数量！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (inblock.DataSet.Tables[1].Rows[i]["RETURN_FLAG"] == DBNull.Value || string.IsNullOrEmpty(inblock.DataSet.Tables[1].Rows[i]["RETURN_FLAG"].ToString()))
                {
                    MessageBox.Show("是否需归还？", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            EI.EIInfo outblock = EI.EITuxedo.CallService("amam_70_submitnew", inblock);

            //出错处理
            if ((outblock.sys_info.sqlcode != 0) || (outblock.sys_info.flag != 0))
            {
                this.EFMsgInfo = outblock.sys_info.msg;
                MessageBox.Show(this.EFMsgInfo, "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //this.RetrieveData(this.hANDOVER_NOEFTextBox.Text.Trim());
            MessageBox.Show("操作成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //重置画面
            this.FormAMAM70_EF_DO_F7(sender, e);

            //查询待入库信息
            GetRefoByStaffNo(this.txtEmpNo.Text.Trim());
            txtEmpNo.Text = "";
            #endregion
        }
        #endregion

        #region 撤销出库
        private void FormAMAM70_EF_DO_F6(object sender, EF.EF_Args e)
        {
            if (this.hANDOVER_NOEFTextBox.Text == null || hANDOVER_NOEFTextBox.Text == "")
            {
                MessageBox.Show("无出库单，不能撤销操作！");
                return;
            }
            EI.EIInfo inBlock = new EI.EIInfo();

            inBlock.DataSet.Tables[0].Columns.Add("HANDOVER_NO");//交接单号

            inBlock.SetColVal(1, 1, "HANDOVER_NO", this.hANDOVER_NOEFTextBox.Text.ToString());

            EI.EIInfo outblock = EI.EITuxedo.CallService("amam_70_return", inBlock);

            //出错处理
            if ((outblock.sys_info.sqlcode != 0) || (outblock.sys_info.flag != 0))
            {
                this.EFMsgInfo = outblock.sys_info.msg;
                MessageBox.Show(this.EFMsgInfo, "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.RetrieveData(this.hANDOVER_NOEFTextBox.Text.Trim());
            MessageBox.Show("操作成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region 重置
        private void FormAMAM70_EF_DO_F7(object sender, EF.EF_Args e)
        {
            //this.tAM.TAM50.Clear();
            //this.tAM.TAM50.AcceptChanges();

            //this.tAM50BindingSource.AllowNew = true;
            //this.tAM50BindingSource.AddNew();

            this.hANDOVER_NOEFTextBox.Text = "";
            this.aPPLY_NOEFTextBox.Text = "";
            this.oUT_MODEJNComboBox.UserValue = "";
            this.sTAFF_NO_COMJNComboBox.UserValue = "";
            this.sTATUSJNComboBox.UserValue = "";
            this.rEC_CREATE_TIMEJNDateTimePicker.UserValue = "";
            this.oPERATE_TIMEJNDateTimePicker.UserValue = "";

            // 获取登录人信息
            UserInfo userInfo = this.GetCurrentUserInfo();
            if (userInfo.EXIST_FLAG)
            {
                this.dEPT_NOJNComboBox.UserValue = userInfo.DEPT_NO;
                this.dEPT_NOJNComboBox.Enabled = false;
            }
            else
            {
                this.dEPT_NOJNComboBox.Enabled = true;
            }
            //获取仓库代码
            if (this.GetCurrentUserInfo().DEPT_NO != null)
            {
                string staff_no = this.GetCurrentUserInfo().STAFF_NO.Trim();
                EI.EIInfo inBlock = Common.Utility.ExecQuery("select DEPOT_CODE from TAMAM011 where STAFF_NO=dbo.nvl(" + "'" + staff_no + "'" + ",staff_no)");
                if (inBlock.Tables[0].Rows.Count > 0)
                {
                    sTOCK_NOJNComboBox.SelectedValue = inBlock.Tables[0].Rows[0][0].ToString();
                    this.tAM50BindingSource.EndEdit();
                }
                else
                {
                    this.sTOCK_NOJNComboBox.Enabled = true;
                }
            }
            else
            {
                this.sTOCK_NOJNComboBox.Enabled = true;
            }
            oUT_MODEJNComboBox.SelectedValue = "50";

            this.tAM51EFGrid.EFUserRows = 0;

            this.tAM51EFGrid.AllowEditing = true;
            this.oUT_MODEJNComboBox.Enabled = false;
            this.sTOCK_NOJNComboBox.Enabled = true;
            this.txtEmpNo.Enabled = true;
            //txtEmpNo.Text = "";
            txtCardID.Text = "";
            txtEmpName.Text = "";
            pictureBox1.ImageLocation = string.Empty;

            this.wORKING_AREA.Text = "";
            this.efLabelWorkingGroup.Text = "";
            this.efGridNRM.EFUserRows = 0;
            this.efGrid1.EFUserRows = 0;

            this.dEPT_NO_RJNComboBox.UserValue = "";
            this.sTAFF_NO_SIGNEFTextBox.Text = "";
            this.uSER_NAMEEFTextBox.Text = "";
        }
        #endregion

        #region 删除明细
        private void FormAMAM70_EF_DO_F8(object sender, EF.EF_Args e)
        {
            if (this.efTabControl1.SelectedTab == this.tabPage1)
            {
                if (hANDOVER_NOEFTextBox.Text.Trim().Equals(""))
                {
                    MessageBox.Show("无交接单信息！");
                    return;
                }
                EI.EIInfo inBlock = new EI.EIInfo();
                inBlock.DataSet.Tables[0].Columns.Add("HANDOVER_NO");
                inBlock.SetColVal(1, "HANDOVER_NO", this.hANDOVER_NOEFTextBox.Text.Trim());

                // 设置入库单明细信息
                inBlock.AddNewBlock();
                inBlock.blk_now = 1;
                inBlock.SetBlockVal(this.tAM51EFGrid);

                EI.EIInfo outBlock = EI.EITuxedo.CallService("amam_50detail_del", inBlock);

                if ((outBlock.sys_info.sqlcode != 0) || (outBlock.sys_info.flag != 0))
                {
                    this.EFMsgInfo = "删除出错，原因：" + outBlock.sys_info.msg;
                    MessageBox.Show(this.EFMsgInfo, "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    this.EFMsgInfo = "删除成功";
                    MessageBox.Show("操作成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.RetrieveData(this.hANDOVER_NOEFTextBox.Text.Trim());
                }
            }


        }
        #endregion

        #region 查询按钮
        private void FormAMAM70_EF_DO_F1(object sender, EF.EF_Args e)
        {
            if (this.efTabControl1.SelectedIndex == 0)
            {
                if (string.IsNullOrEmpty(this.dEPT_NOJNComboBox.UserValue.Trim()) || string.IsNullOrEmpty(this.sTOCK_NOJNComboBox.UserValue.Trim()))
                {
                    MessageBox.Show("请选择出库部门和仓库代码进行查询！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (string.IsNullOrEmpty(mAT_NAMEEFTextBox.Text.Trim()) && string.IsNullOrEmpty(efTextBox2.Text.Trim())
                    && string.IsNullOrEmpty(efTextBox3.Text.Trim()) && string.IsNullOrEmpty(MATERIALEFTextBox.Text.Trim()))
                {
                    MessageBox.Show("请输入库存查询条件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                EI.EIInfo outblock = new EI.EIInfo();
                string sql = string.Format(@"select tam55.REC_CREATOR, tam55.REC_CREATE_TIME, tam55.REC_REVISOR, tam55.REC_REVISE_TIME, tam55.REC_DELETOR, tam55.REC_DELETE_TIME, tam55.ARCHIVE_FLAG, tam55.DELETE_FLAG, 
                      tam55.REMARK, tam55.DEPT_NO, tam55.SHIP_NO, tam55.MAT_CODE, tbmmm01.MAT_CODE_A,tbmmm01.MAT_NAME, tbmmm01.MATERIAL, tbmmm01.SPEC, tbmmm01.MAT_MODEL, tam55.QUANTITY, tbmmm01.MEASURE_UNIT_DESC, 
                      tbmmm01.MEASURE_UNIT_A_DESC, tam55.QUANTITY_A, tbmmm01.STD_NO, tam55.AS_PRICE, tam55.STOCK_NO, tam55.STOCK_PLACE_NO, tam55.AS_PLACE, tam55.ROWNO, tam55.COLUMN_NO, tam55.LAYERNO, tam55.HALL_NO ,
                        (SELECT TAMAM090.TYPE_DESC  FROM TAMAM090 
WHERE TAMAM090.ROWGUID = (SELECT TAMAM091.FK_TAMAM090_ROWGUID FROM TAMAM091 WHERE TAMAM091.MAT_CODE=tam55.MAT_CODE)) AS ABC_TYPE ,
                       (SELECT TAMAM091.QUANTITY  FROM TAMAM091 
WHERE TAMAM091.MAT_CODE=tam55.MAT_CODE) AS TYPE_QUANTITY ,
                        "
                    //+"(SELECT sum(TAM51.QUANTITY-TAM51.RETURN_NUM) FROM TAM51,TAM50 WHERE TAM51.MAT_NO=tam55.MAT_CODE AND TAM50.HANDOVER_NO = TAM51.HANDOVER_NO AND TAM50.STAFF_NO_SIGN='{3}'and tam51.OUT_MODE = '50' and tam51.RETURN_FLAG in ('1','2')) AS QUANTITY_HAD "
                    + @" (SELECT sum(TAM51.QUANTITY-TAM51.RETURN_NUM) FROM TAM51,TAM50 
                WHERE TAM51.MAT_NO=tam55.MAT_CODE AND TAM50.HANDOVER_NO = TAM51.HANDOVER_NO 
AND TAM50.STAFF_NO_SIGN='{6}'and tam51.OUT_MODE = '50' and tam51.RETURN_FLAG ='1') AS QUANTITY_HAD ,TAMAM009.RETURN_TYPE as RETURN_FLAG"
                    + @" 
                    from tam55,tbmmm01,tamam009
                    where TAM55.MAT_CODE = TBMMM01.MAT_CODE and tam55.stock_no = TAMAM009.DEPOT_CODE
                        {0}
                        {1}
                        {2}
                        {3}
                    and tam55.dept_no = '{4}'
                    and tam55.STOCK_NO = '{5}'
                    and tam55.QUANTITY > 0  order by tbmmm01.MAT_NAME,tbmmm01.SPEC,tbmmm01.MAT_MODEL,tbmmm01.MATERIAL"
                    , this.mAT_NAMEEFTextBox.Text.Trim().Length > 0
                    ? "and tbmmm01.MAT_NAME like '%" + this.mAT_NAMEEFTextBox.Text.Trim() + "%'" : ""
                    , this.efTextBox2.Text.Trim().Length > 0
                    ? " and tbmmm01.SPEC like '%" + this.efTextBox2.Text.Trim() + "%'" : ""
                    , this.efTextBox3.Text.Trim().Length > 0
                    ? " and tbmmm01.MAT_MODEL like '%" + this.efTextBox3.Text.Trim() + "%'" : ""
                    , this.MATERIALEFTextBox.Text.Trim().Length > 0
                    ? " and tbmmm01.MATERIAL like '%" + this.MATERIALEFTextBox.Text.Trim() + "%'" : ""
                    , this.dEPT_NOJNComboBox.UserValue.Trim()
                    , this.sTOCK_NOJNComboBox.UserValue.Trim()
                    , this.sTAFF_NO_SIGNEFTextBox.Text.Trim());

                outblock = Utility.ExecQuery(sql);
                //出错处理
                if ((outblock.sys_info.sqlcode != 0) || (outblock.sys_info.flag != 0))
                {
                    this.EFMsgInfo = outblock.sys_info.msg;
                    MessageBox.Show(this.EFMsgInfo, "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                outblock.GetBlockVal(this.efGrid1);
            }
            else
            {
                string begTime = this.bEG_TIMEJNDateTimePicker.UserValue == "" ? "19000101" : this.bEG_TIMEJNDateTimePicker.UserValue.Substring(0, 8);
                string endTime = this.eND_TIMEJNDateTimePicker.UserValue == "" ? "21000101" : this.eND_TIMEJNDateTimePicker.UserValue.Substring(0, 8);

                EI.EIInfo outblock = new EI.EIInfo();
                string sql = string.Format(@"select * from tam50 
                                                            where substring(handover_no,1,2) = 'AC' 
                                                            and handover_no like dbo.nvl('{0}',handover_no)+'%'
                                                            and dept_no = dbo.nvl('{1}',dept_no)
                                                            and dept_no_r = dbo.nvl('{2}',dept_no_r)
                                                            and out_mode = dbo.nvl('{3}',out_mode)
                                                            and stock_no = dbo.nvl('{4}',stock_no)
                                                            and status = dbo.nvl('{5}',status)
                                                            and substring(rec_create_time,1,8) >= '{6}'
                                                            and substring(rec_create_time,1,8) <= '{7}'
                                                            order by REC_CREATE_TIME desc"
                                                        , this.handoverNoEFTextBox.Text.Trim()
                                                        , this.deptnoJNComboBox.UserValue
                                                        , this.deptno_rJNComboBox.UserValue
                                                        , this.outmodeJNComboBox.UserValue
                                                        , this.stocknoJNComboBox.UserValue
                                                        , this.status_qComboBox.UserValue
                                                        , begTime
                                                        , endTime);

                outblock = Utility.ExecQuery(sql);
                //出错处理
                if ((outblock.sys_info.sqlcode != 0) || (outblock.sys_info.flag != 0))
                {
                    this.EFMsgInfo = outblock.sys_info.msg;
                    MessageBox.Show(this.EFMsgInfo, "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                outblock.GetBlockVal(this.tAM50EFGrid);
            }
        }
        #endregion

        #region 转到主画面
        private void tAM50EFGrid_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            C1.Win.C1FlexGrid.HitTestInfo ht = this.tAM50EFGrid.HitTest(e.X, e.Y);
            if (ht.Row < 1) return;
            string handover_no = this.tAM50EFGrid[ht.Row, "HANDOVER_NO"].ToString();
            this.RetrieveData(handover_no);
            this.efTabControl1.SelectedTab = this.tabPage1;
        }
        #endregion

        #region 卡片读取方法
        private void btnReadCard_Click(object sender, EventArgs e)
        {
            string empNo = string.Empty;
            string empName = string.Empty;
            int cardId = 0;

            //判断是否选择了仓库
            if (string.IsNullOrEmpty(this.sTOCK_NOJNComboBox.UserValue.Trim()))
            {
                MessageBox.Show("请先选择仓库！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.pictureBox1.ImageLocation = string.Empty;
            this.txtCardID.Text = string.Empty;
            this.txtEmpName.Text = string.Empty;
            this.txtEmpNo.Text = string.Empty;
            int retValue = 0;
            //读卡信息
            bool DebugFlag = false;//调试标记，true：调试状态（程序不经过读卡设备），false：非调试状态
            if (DebugFlag)
            {
                empNo = "CG01170\0";
                empName = "CG01170";
                cardId = 10003733;
            }
            else
            {
                
                retValue = this.axReadCard1.ReadCard(ref empNo, ref empName, ref cardId);

                if (retValue == -1)
                {
                    MessageBox.Show("打开串口错误，未能识别读卡器！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (retValue == -2)
                {
                    MessageBox.Show("卡片信息有误，未能识别卡片信息！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (retValue == 0)
            {
                this.txtCardID.Text = cardId.ToString();
                this.txtEmpName.Text = empName;
                this.txtEmpNo.Text = empNo;

                //由于工号信息中包含\0,故截取字符串
                UserInfo user = LoginUtil.GetUserInfoByStaffNo(empNo.Substring(0, empNo.IndexOf("\0")));

                if (user.EXIST_FLAG)
                {
                    this.dEPT_NO_RJNComboBox.UserValue = user.DEPT_NO;

                    if (user.WORKING_AREA != "")
                    {
                        string sql = string.Format(@"SELECT dbo.GET_CHINESE_BY_CODE('WORKING_AREA','{0}') AS WORKING_AREA", user.WORKING_AREA);
                        EI.EIInfo outblock = Utility.ExecQuery(sql);

                        this.wORKING_AREA.Text = "[" + outblock.DataSet.Tables[0].Rows[0]["WORKING_AREA"].ToString() + "]";
                    }
                    if (user.WORKING_GROUP != "")
                    {
                        string sql = string.Format(@"SELECT dbo.GET_CHINESE_BY_CODE('WORKING_GROUP','{0}') AS WORKING_GROUP", user.WORKING_GROUP);
                        EI.EIInfo outblock = Utility.ExecQuery(sql);

                        this.efLabelWorkingGroup.Text = "[" + outblock.DataSet.Tables[0].Rows[0]["WORKING_GROUP"].ToString() + "]";
                    }
                    this.dEPT_NO_RJNComboBox.Enabled = false;
                    if (!string.IsNullOrEmpty(user.PHOTO_PATH.Trim()))
                    {
                        this.DownloadPic(user.PHOTO_PATH.Substring(user.PHOTO_PATH.LastIndexOf("/")));
                    }
                }
                else
                {
                    if (MessageBox.Show("该用户未在本系统内注册，是否继续?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                        return;
                    this.dEPT_NO_RJNComboBox.Enabled = true;
                    this.dEPT_NO_RJNComboBox.UserValue = this.dEPT_NOJNComboBox.UserValue;
                }

                //if (!LoginUtil.GetStoreAuthority(empNo, this.sTOCK_NOJNComboBox.UserValue))
                //{
                //    MessageBox.Show("该卡片持有人无该仓库的申领权限！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    this.sTAFF_NO_SIGNEFTextBox.Text = "";
                //    this.uSER_NAMEEFTextBox.Text = "";
                //    return;
                //}

                this.sTAFF_NO_SIGNEFTextBox.Text = this.txtEmpNo.Text.Trim();
                this.uSER_NAMEEFTextBox.Text = this.txtEmpName.Text;
                EI.EIInfo outInfo = new EI.EIInfo();
                if (user.EXIST_FLAG)
                {
                    //查询该领用人所有申请单明细
                    GetApplyInfoByStaffNo(user.STAFF_NO);
                    //查询待入库信息
                    GetRefoByStaffNo(user.STAFF_NO);
                }

                this.sTOCK_NOJNComboBox.Enabled = false;
            }
            //总装部ABC分类
            this.getStaffABCTypeInfo();

            this.SetStoreTree(this.dEPT_NOJNComboBox.UserValue, this.sTOCK_NOJNComboBox.UserValue, this.sTOCK_NOJNComboBox.Text);
        }
        #endregion

        #region 获取申请明细信息
        private void GetApplyInfoByStaffNo(string _staffNo)
        {
            string sql = string.Format(@"
select * from(
SELECT TAM71.APPLY_NO,TAM71.SHIP_NO,TAM71.MAT_CODE_A as MAT_TYPE,TAM71.MAT_CODE as MAT_NO,TAM71.MAT_NAME,TAM71.MATERIAL,TAM71.SPEC,TAM71.MAT_MODEL,TAM71.STD_NO,
                                        (TAM71.ACCEPT_NUM - TAM71.RECEIVE_NUM - isnull((select  sum(tam51.quantity ) from tam51 join tam50 on tam51.handover_no = tam50.handover_no 
where tam50.STAFF_NO_sign = '{0}' and tam51.mat_no=tam71.MAT_CODE),0)) AS QUANTITY, TAM71.MEASURE_UNIT,TAM71.QUANTITY_A,TAM71.MEASURE_UNIT_A,TAM55.AS_PLACE,TAM71.RETURN_FLAG
,tam55.as_price
FROM TAM70,TAM71,TAM55 WHERE TAM70.APPLY_NO = TAM71.APPLY_NO AND TAM71.MAT_CODE=TAM55.MAT_CODE AND 
                                        TAM70.STATUS = '2' AND TAM71.RECEIVE_NUM < TAM71.QUANTITY AND 
                                        (TAM71.STAFF_NO_A = '{0}') AND TAM71.APPROVE_STATUS='1') as temp
where temp.quantity>0", _staffNo);

            EI.EIInfo outblock = Common.Utility.ExecQuery(sql);
            //出错处理
            if ((outblock.sys_info.sqlcode != 0) || (outblock.sys_info.flag != 0))
            {
                this.EFMsgInfo = outblock.sys_info.msg;
                MessageBox.Show(this.EFMsgInfo, "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            outblock.GetBlockVal(this.tAM51EFGrid);
        }
        #endregion

        #region 下载照片
        /// <summary>
        /// 下载照片
        /// </summary>
        /// <param name="ftpServerFileName"></param>
        private void DownloadPic(string ftpServerFileName)
        {
            try
            {
                //获取当前程序运行的绝对目录,创建PIC子目录
                string localFileFolder = Application.StartupPath + "\\PIC";
                if (!Directory.Exists(localFileFolder))
                {
                    Directory.CreateDirectory(localFileFolder);
                }
                FTP ftp = new FTP("UserPhotoFTP");
                //下载照片至子目录
                ftp.Download(localFileFolder, ftpServerFileName);
                //显示照片
                this.pictureBox1.ImageLocation = localFileFolder + "\\" + ftpServerFileName;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 货架编码选择
        private void tAM51EFGrid_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            C1.Win.C1FlexGrid.HitTestInfo ht = this.tAM51EFGrid.HitTest(e.X, e.Y);
            if (ht.Row <= 0)
                return;
            BaseCode baseCode = new BaseCode();

            if (this.tAM51EFGrid.Cols[ht.Column].Name == "SHIP_NO")
            {
                //baseCode = Utility.QueryBaseCode(String.Format("SELECT TEMPLATE_NO AS CHINESE,TEMPLATE_NO AS CODE FROM TPSOF50 WHERE IS_MODEL = '0' "));
                ////                baseCode = Utility.QueryBaseCode(String.Format(@"SELECT ship_id AS CODE ,ship_name AS  CHINESE
                ////                        FROM tbship 
                ////                        WHERE is_deleted = '0' 
                ////                        order by code "));
                //if (baseCode == null) return;
                Common.BusinessUtility.ShipDescQuery shipDQ = new Common.BusinessUtility.ShipDescQuery(true);
                shipDQ.ShowDialog();
                if (String.IsNullOrEmpty(shipDQ.SHIP_ID_STR)) return;
                int i = ht.Row;
                do
                {
                    //this.tAM51EFGrid[i, "SHIP_NO"] = baseCode.Code;
                    this.tAM51EFGrid[i, "SHIP_NO"] = shipDQ.SHIP_ID_STR;
                    i++;
                    if (i > this.tAM51EFGrid.EFUserRows)
                        break;
                }
                while ((this.tAM51EFGrid[ht.Row, "check_option"] == null ? false : (bool)this.tAM51EFGrid[i, "check_option"]));
            }
            //            // 仓库代码
            //            if (this.tAM51EFGrid.Cols[ht.Column].Name == "STOCK_NO")
            //            {
            //                baseCode = Utility.QueryBaseCode(string.Format(@"SELECT DISTINCT DEPOT_NAME AS CHINESE, DEPOT_CODE AS CODE FROM TAMAM009
            //                                             WHERE DEPT_NO = DBO.NVL('{0}',DEPT_NO)"
            //                                            , dEPT_NOJNComboBox.UserValue));
            //                if (baseCode == null) return;
            //                int i = ht.Row;

            //                do
            //                {
            //                    this.tAM51EFGrid[i, "STOCK_NO"] = baseCode.Code;
            //                    i++;
            //                    if (i > this.tAM51EFGrid.EFUserRows)
            //                        break;
            //                }
            //                while ((this.tAM51EFGrid[ht.Row, "check_option"] == null ? false : (bool)this.tAM51EFGrid[i, "check_option"]));
            //            }

            //            // 货架编码
            //            else if (this.tAM51EFGrid.Cols[ht.Column].Name == "AS_PLACE")
            //            {
            //                if (this.tAM51EFGrid[ht.Row, "STOCK_NO"] == null
            //                    || this.tAM51EFGrid[ht.Row, "STOCK_NO"].ToString().Trim() == "")
            //                    return;

            //                baseCode = Utility.QueryBaseCode(string.Format(@"SELECT AS_PLACE_NAME as CHINESE, AS_PLACE as CODE from TAMAM010 
            //                                                   WHERE DEPOT_CODE = DBO.NVL('{0}',DEPOT_CODE)"
            //                                                   , sTOCK_NOJNComboBox.UserValue));
            //                if (baseCode == null) return;

            //                for (int i = ht.Row; i <= this.tAM51EFGrid.EFUserRows; i++)
            //                {
            //                    if (this.tAM51EFGrid[ht.Row, "STOCK_NO"].ToString() == this.tAM51EFGrid[i, "STOCK_NO"].ToString())
            //                    {
            //                        do
            //                        {
            //                            this.tAM51EFGrid[i, "AS_PLACE"] = baseCode.Code;
            //                            this.tAM51EFGrid[i, "check_option"] = true;
            //                            i++;
            //                            if (i > this.tAM51EFGrid.EFUserRows)
            //                                break;
            //                        }
            //                        while ((this.tAM51EFGrid[i, "check_option"] == null ? false : (bool)this.tAM51EFGrid[i, "check_option"]));
            //                    }
            //                    else
            //                        break;
            //                }
            //            }
        }
        #endregion

        #region 部门选择下拉事件
        private void dEPT_NOJNComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.sTOCK_NOJNComboBox.QuerySQL = string.Format(@"SELECT DISTINCT DEPOT_NAME AS CHINESE, DEPOT_CODE AS CODE FROM tamam009 WHERE 
                                                    DEPT_NO = '{0}'", this.dEPT_NOJNComboBox.UserValue.Trim());
            // 设置库存树状结构
            //this.SetStoreTree(this.dEPT_NOJNComboBox.UserValue, this.sTOCK_NOJNComboBox.UserValue, this.sTOCK_NOJNComboBox.Text);


        }
        #endregion

        #region 领料人选择按钮
        private void efButton1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.dEPT_NO_RJNComboBox.UserValue))
                return;

            BaseCode baseCode = new BaseCode();

            baseCode = Utility.QueryBaseCode(string.Format(@"SELECT STAFF_NO AS CODE,[USER_NAME] + '['+STAFF_NO+']' AS CHINESE ,CONTRACT_TEL AS REMARK1 
                                                                        FROM DBO.VLMBI01
                                                                        WHERE DEPT_NO = '{0}' 
                                                                        ORDER BY USER_NAME"
                                                                    , this.dEPT_NO_RJNComboBox.UserValue));
            if (baseCode == null) return;
            this.sTAFF_NO_SIGNEFTextBox.Text = baseCode.Code;
        }
        #endregion

        #region 申请单选择按钮
        private void efButton2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.hANDOVER_NOEFTextBox.Text.Trim()))
                return;

            if (string.IsNullOrEmpty(this.txtEmpNo.Text.Trim()))
            {
                MessageBox.Show("请刷卡，获取领料人信息！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            UserInfo user = LoginUtil.GetUserInfoByStaffNo(this.txtEmpNo.Text.Trim());
            FormAMAM60_QUERY_APPLY formamam60_query_apply = new FormAMAM60_QUERY_APPLY();
            formamam60_query_apply.staff_no_a = user.USER_LOGIN_ID;
            formamam60_query_apply.ShowDialog();

            if (string.IsNullOrEmpty(formamam60_query_apply.ApplyNo))
                return;
            this.aPPLY_NOEFTextBox.Text = formamam60_query_apply.ApplyNo;
            this.dEPT_NOJNComboBox.UserValue = formamam60_query_apply.DetpNo_C;
            this.sTOCK_NOJNComboBox.UserValue = formamam60_query_apply.Stock_No;

            //            string sql = string.Format(@"SELECT APPLY_NO,SHIP_NO,MAT_CODE_A as MAT_TYPE,MAT_CODE as MAT_NO,MAT_NAME,
            //                                            MATERIAL,SPEC,MAT_MODEL,STD_NO,ACCEPT_NUM - RECEIVE_NUM AS QUANTITY,MEASURE_UNIT,QUANTITY_A,MEASURE_UNIT_A 
            //                                            FROM TAM71 WHERE APPLY_NO = '{0}' AND APPROVE_STATUS='1' AND ACCEPT_NUM>0", formamam60_query_apply.ApplyNo);
            string sql = string.Format(@"SELECT TAM71.APPLY_NO, TAM71.SHIP_NO, TAM71.MAT_CODE_A AS MAT_TYPE, TAM71.MAT_CODE AS MAT_NO
, TAM71.MAT_NAME, TAM71.MATERIAL, TAM71.SPEC
, TAM71.MAT_MODEL, TAM71.STD_NO, TAM71.ACCEPT_NUM - TAM71.RECEIVE_NUM AS QUANTITY, TAM71.MEASURE_UNIT, TAM71.QUANTITY_A
, TAM71.MEASURE_UNIT_A, TAM55.STOCK_NO, TAM55.AS_PLACE
FROM TAM71 INNER JOIN TAM55 ON TAM71.MAT_CODE = TAM55.MAT_CODE
WHERE (TAM71.APPLY_NO = '{0}') AND(TAM71.APPROVE_STATUS = '1') AND (TAM71.ACCEPT_NUM > 0)", formamam60_query_apply.ApplyNo);


            EI.EIInfo outblock = Utility.ExecQuery(sql);
            if (outblock.sys_info.flag != 0 || outblock.sys_info.sqlcode != 0)
            {
                MessageBox.Show(outblock.sys_info.msg, "警告");
                return;
            }

            //更新
            this.tAM51EFGrid.Rows.Count = this.tAM51EFGrid.Rows.Fixed;
            outblock.GetBlockVal(this.tAM51EFGrid);
            for (int i = 1; i < tAM51EFGrid.Rows.Count; i++)
            {
                this.tAM51EFGrid[i, "check_option"] = true;
            }
        }
        #endregion

        #region 接收部门下拉框事件
        private void dEPT_NO_RJNComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.sTAFF_NO_SIGNEFTextBox.Text = "";
        }
        #endregion

        #region 根据部门和库号设置库存信息树
        private void SetStoreTree(string deptNo, string stockNo, string stockName)
        {
            // 清空画面相关信息
            this.efTree1.Nodes.Clear();
            this.efGrid1.EFUserRows = 0;
            this.tAM51EFGrid.EFUserRows = 0;

            // 设置树信息
            if (string.IsNullOrEmpty(deptNo) || string.IsNullOrEmpty(stockNo))
                return;
            this.efTree1.Nodes.Add(stockNo, stockName);
            EI.EIInfo dtShelfNo = Utility.ExecQuery(string.Format("SELECT DISTINCT AS_PLACE AS CODE, AS_PLACE AS CHINESE FROM TAM55 " +
                                                "WHERE AS_PLACE <> '' AND DEPT_NO = '{0}' AND STOCK_NO = '{1}' AND QUANTITY >0 ORDER BY AS_PLACE ", deptNo, stockNo));
            for (int i = 0; i < dtShelfNo.DataSet.Tables[0].Rows.Count; i++)
            {
                this.efTree1.Nodes[stockNo].Nodes.Add(dtShelfNo.DataSet.Tables[0].Rows[i]["CODE"].ToString(), dtShelfNo.DataSet.Tables[0].Rows[i]["CHINESE"].ToString());
            }
        }
        #endregion

        #region 树形NodeMouseDoubleClick事件
        private void efTree1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (this.efTree1.Nodes == null)
                return;
            int index = this.efTree1.SelectedNode.Level;
            string as_place = "";

            if (index == 0)
            {
                as_place = "";
            }
            else if (index == 1)
            {
                as_place = this.efTree1.SelectedNode.Name;
            }
            String sql = string.Format(@"select tam55.REC_CREATOR, tam55.REC_CREATE_TIME, tam55.REC_REVISOR, tam55.REC_REVISE_TIME, tam55.REC_DELETOR, tam55.REC_DELETE_TIME, tam55.ARCHIVE_FLAG, tam55.DELETE_FLAG, 
                      tam55.REMARK, tam55.DEPT_NO, tam55.SHIP_NO, tam55.MAT_CODE, tbmmm01.MAT_CODE_A,tbmmm01.MAT_NAME, tbmmm01.MATERIAL, tbmmm01.SPEC, tbmmm01.MAT_MODEL, tam55.QUANTITY, tbmmm01.MEASURE_UNIT_DESC, 
                      (SELECT TAMAM090.TYPE_DESC  FROM TAMAM090 WHERE TAMAM090.ROWGUID = (SELECT TAMAM091.FK_TAMAM090_ROWGUID FROM TAMAM091 WHERE TAMAM091.MAT_CODE=tam55.MAT_CODE)) AS ABC_TYPE ,
                       (SELECT TAMAM091.QUANTITY  FROM TAMAM091 WHERE TAMAM091.MAT_CODE=tam55.MAT_CODE) AS TYPE_QUANTITY ,
                        (SELECT sum(TAM51.QUANTITY-TAM51.RETURN_NUM) FROM TAM51,TAM50 WHERE TAM51.MAT_NO=tam55.MAT_CODE AND TAM50.HANDOVER_NO = TAM51.HANDOVER_NO AND TAM50.STAFF_NO_SIGN='{3}' and tam51.OUT_MODE = '50' "
                        //and tam51.RETURN_FLAG in ('1','2')) AS QUANTITY_HAD ,
                    + @" and tam51.RETURN_FLAG = '1') AS QUANTITY_HAD , 
                    tbmmm01.MEASURE_UNIT_A_DESC, tam55.QUANTITY_A, tbmmm01.STD_NO, tam55.AS_PRICE, tam55.STOCK_NO, tam55.STOCK_PLACE_NO, tam55.AS_PLACE, tam55.ROWNO, tam55.COLUMN_NO, tam55.LAYERNO, tam55.HALL_NO 
                    ,TAMAM009.RETURN_TYPE as RETURN_FLAG
                    from tam55,tbmmm01,tamam009
                    where TAM55.MAT_CODE = TBMMM01.MAT_CODE  and tam55.stock_no = TAMAM009.DEPOT_CODE
                    AND QUANTITY>0 and TAM55.STOCK_NO = '{0}' AND TAM55.DEPT_NO = '{1}' 
                                        AND TAM55.AS_PLACE = DBO.NVL('{2}',TAM55.AS_PLACE)", this.sTOCK_NOJNComboBox.UserValue, this.dEPT_NOJNComboBox.UserValue, as_place, this.txtEmpNo.Text.Trim().ToString(), this.txtEmpNo.Text.Trim().ToString());

            EI.EIInfo detBlock = Common.Utility.ExecQuery(sql);

            detBlock.GetBlockVal(this.efGrid1);
        }
        #endregion

        private void jnComboBox1_DropDown(object sender, EventArgs e)
        {
            string dept_no = this.deptnoJNComboBox.UserValue;
            if (dept_no.Equals(""))
            {
                MessageBox.Show("请先选择出库部门！");
                return;
            }
            else
            {
                this.stocknoJNComboBox.QuerySQL = ("select DEPOT_NAME,DEPOT_CODE from TAMAM009 where dept_no='" + dept_no + "'");
            }
        }

        #region 读工号
        private void efButton3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtEmpNo.Text.Trim()))
                return;

            //判断是否选择了仓库
            if (string.IsNullOrEmpty(this.sTOCK_NOJNComboBox.UserValue.Trim()))
            {
                MessageBox.Show("请先选择仓库！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            UserInfo user = LoginUtil.GetUserInfoByStaffNo(this.txtEmpNo.Text.Trim());

            if (user.EXIST_FLAG)
            {
                this.dEPT_NO_RJNComboBox.SelectedValue = user.DEPT_NO;
                //if (user.WORKING_AREA != "")
                //{
                //    string sql = string.Format(@"SELECT dbo.GET_CHINESE_BY_CODE('WORKING_AREA','{0}') AS WORKING_AREA", user.WORKING_AREA);
                //    EI.EIInfo outblock = Utility.ExecQuery(sql);

                //    this.wORKING_AREA.Text = "[" + outblock.DataSet.Tables[0].Rows[0]["WORKING_AREA"].ToString() + "]";
                //}
                //if (user.WORKING_GROUP != "")
                //{
                //    string sql = string.Format(@"SELECT dbo.GET_CHINESE_BY_CODE('WORKING_GROUP','{0}') AS WORKING_GROUP", user.WORKING_GROUP);
                //    EI.EIInfo outblock = Utility.ExecQuery(sql);

                //    this.efLabelWorkingGroup.Text = "[" + outblock.DataSet.Tables[0].Rows[0]["WORKING_GROUP"].ToString() + "]";
                //}

                this.wORKING_AREA.Text = user.WORKING_AREA_NAME;
                this.efLabelWorkingGroup.Text = user.WORKING_GROUP_NAME;
                this.txtEmpName.Text = user.USER_NAME;

                if (!string.IsNullOrEmpty(user.PHOTO_PATH.Trim()))
                {
                    this.DownloadPic(user.PHOTO_PATH.Substring(user.PHOTO_PATH.LastIndexOf("/")));
                }
            }
            else
            {
                MessageBox.Show("该用户未在本系统内注册！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //if (!LoginUtil.GetStoreAuthority(this.txtEmpNo.Text.Trim(), this.sTOCK_NOJNComboBox.UserValue))
            //{
            //    MessageBox.Show("该工号无该仓库的申领权限！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    this.sTAFF_NO_SIGNEFTextBox.Text = "";
            //    this.uSER_NAMEEFTextBox.Text = "";
            //    return;
            //}

            this.sTAFF_NO_SIGNEFTextBox.Text = this.txtEmpNo.Text.Trim();
            this.uSER_NAMEEFTextBox.Text = this.txtEmpName.Text;
            EI.EIInfo outInfo = new EI.EIInfo();
            if (user.EXIST_FLAG)
            {
                //查询该领用人所有申请单明细
                GetApplyInfoByStaffNo(user.STAFF_NO);
                //查询待入库信息
                GetRefoByStaffNo(user.STAFF_NO);
            }
            this.sTOCK_NOJNComboBox.Enabled = false;

            //总装部ABC分类
            // if (this.sTOCK_NOJNComboBox.UserValue.CompareTo("JN33") == 0)
            this.getStaffABCTypeInfo();

            this.SetStoreTree(this.dEPT_NOJNComboBox.UserValue, this.sTOCK_NOJNComboBox.UserValue, this.sTOCK_NOJNComboBox.Text);

        }
        #endregion

        private void txtEmpNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.efButton3_Click(sender, e);
        }

        private void tAM51EFGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.tAM51EFGrid.MouseRow > 0 && (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back))
            {
                if (this.tAM51EFGrid.Cols.IndexOf("SHIP_NO") == this.tAM51EFGrid.MouseCol)
                {
                    this.tAM51EFGrid[this.tAM51EFGrid.MouseRow, this.tAM51EFGrid.MouseCol] = null;
                }
            }
        }

        #region 获取领用明细信息（待入库）
        public void GetRefoByStaffNo(string user_id)
        {
            if (string.IsNullOrEmpty(this.dEPT_NOJNComboBox.UserValue.Trim()) || string.IsNullOrEmpty(this.sTOCK_NOJNComboBox.UserValue.Trim()))
            {
                MessageBox.Show("请选择入库部门和仓库代码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(user_id.Trim()))
            {
                MessageBox.Show("请录入领料人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            EI.EIInfo outblock = new EI.EIInfo();
            string sql = string.Format(@"SELECT a2.*,a2.QUANTITY - a2.RETURN_NUM as RETURN_NUM_A,a1.OPERATE_TIME as OPERATE_TIME_A
                            ,a1.DEPT_NO as DEPT_NO_A,a1.STAFF_NO_SIGN,a1.USER_NAME,a1.STOCK_NO as STOCK_NO_A
                            ,a3.working_area,a3.working_group,a2.allow_by
                            ,(SELECT TAMAM090.TYPE_DESC  FROM TAMAM090 WHERE TAMAM090.ROWGUID = (SELECT TAMAM091.FK_TAMAM090_ROWGUID FROM TAMAM091 WHERE TAMAM091.MAT_CODE=a2.MAT_NO)) AS ABC_TYPE 
                            FROM TAM50 a1,TAM51 a2,vlmbi01 a3 WHERE a1.staff_no_sign *= a3.staff_no and a2.HANDOVER_NO = a1.HANDOVER_NO AND 
                            a1.DEPT_NO = '{0}' AND
                            a2.OUT_MODE = '50' and  
                            a1.STOCK_NO = '{1}' AND 
                            a1.STAFF_NO_SIGN = '{2}' AND 
                            a2.RETURN_FLAG in ('1','2') AND a2.QUANTITY - a2.RETURN_NUM>0  order by a2.RETURN_FLAG,a1.OPERATE_TIME"
                            , this.dEPT_NOJNComboBox.UserValue
                            , this.sTOCK_NOJNComboBox.UserValue
                            , user_id
                            );
            outblock = Utility.ExecQuery(sql);
            //出错处理
            if ((outblock.sys_info.sqlcode != 0) || (outblock.sys_info.flag != 0))
            {
                this.EFMsgInfo = outblock.sys_info.msg;
                MessageBox.Show(this.EFMsgInfo, "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (outblock.blk_info[0].row > 0)
            {
                outblock.GetBlockVal(this.efGridNRM);
            }
            else
            {
                this.efGridNRM.EFUserRows = 0;
            }
        }
        #endregion

        #region F9功能按钮：保存并出库
        private void FormAMAM70_EF_DO_F9(object sender, EF.EF_Args e)
        {
            if (this.tAM51EFGrid.EFChoiceCount < 1)
            {
                MessageBox.Show("没有选择明细信息不能保存！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(this.dEPT_NOJNComboBox.UserValue.Trim()))
            {
                MessageBox.Show("请选择出库部门！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrEmpty(this.dEPT_NO_RJNComboBox.UserValue.Trim()) || string.IsNullOrEmpty(this.sTAFF_NO_SIGNEFTextBox.Text.Trim()))
            {
                MessageBox.Show("请选择领料部门和领料人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            EI.EIInfo inblock = new EI.EIInfo();

            // 设置入库单主信息
            this.tAM50BindingSource.EndEdit();
            this.tAM.TAM50.Rows[0]["REC_CREATE_TIME"] = this.rEC_CREATE_TIMEJNDateTimePicker.UserValue;
            this.tAM.TAM50.Rows[0]["OPERATE_TIME"] = this.oPERATE_TIMEJNDateTimePicker.UserValue;
            inblock.DataSet.Tables[0].Merge(this.tAM.TAM50);

            // 设置入库单明细信息
            inblock.AddNewBlock();
            inblock.blk_now = 1;
            inblock.SetBlockVal(this.tAM51EFGrid);

            // 检查必输项
            for (int i = 0; i < inblock.DataSet.Tables[1].Rows.Count; i++)
            {
                if (inblock.DataSet.Tables[1].Rows[i]["QUANTITY"] == DBNull.Value || Convert.ToDecimal(inblock.DataSet.Tables[1].Rows[i]["QUANTITY"]) <= 0)
                {
                    MessageBox.Show("选择的物料明细中必须输入出库数量！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (inblock.DataSet.Tables[1].Rows[i]["RETURN_FLAG"] == DBNull.Value || string.IsNullOrEmpty(inblock.DataSet.Tables[1].Rows[i]["RETURN_FLAG"].ToString()))
                {
                    MessageBox.Show("是否需归还？", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            EI.EIInfo outblock = EI.EITuxedo.CallService("amam_70_submitnew", inblock);

            //出错处理
            if ((outblock.sys_info.sqlcode != 0) || (outblock.sys_info.flag != 0))
            {
                this.EFMsgInfo = outblock.sys_info.msg;
                MessageBox.Show(this.EFMsgInfo, "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //this.RetrieveData(this.hANDOVER_NOEFTextBox.Text.Trim());
            //MessageBox.Show("操作成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //重置画面
            //this.FormAMAM70_EF_DO_F7(sender, e);
            if (true)
            {
                this.hANDOVER_NOEFTextBox.Text = "";
                this.aPPLY_NOEFTextBox.Text = "";
                this.oUT_MODEJNComboBox.UserValue = "";
                this.sTAFF_NO_COMJNComboBox.UserValue = "";
                this.sTATUSJNComboBox.UserValue = "";
                this.rEC_CREATE_TIMEJNDateTimePicker.UserValue = "";
                this.oPERATE_TIMEJNDateTimePicker.UserValue = "";

                oUT_MODEJNComboBox.SelectedValue = "50";

                this.tAM51EFGrid.EFUserRows = 0;

                this.tAM51EFGrid.AllowEditing = true;
                this.oUT_MODEJNComboBox.Enabled = false;
                this.sTOCK_NOJNComboBox.Enabled = true;
                //this.txtEmpNo.Enabled = true;
                //txtEmpNo.Text = "";
                //txtCardID.Text = "";
                //txtEmpName.Text = "";
                //pictureBox1.ImageLocation = string.Empty;
                

                this.wORKING_AREA.Text = "";
                this.efLabelWorkingGroup.Text = "";
                this.efGridNRM.EFUserRows = 0;
                this.efGrid1.EFUserRows = 0;
            }

            //查询待入库信息
            GetRefoByStaffNo(this.sTAFF_NO_SIGNEFTextBox.Text.Trim());
            //总装部ABC分类
            // if (this.sTOCK_NOJNComboBox.UserValue.CompareTo("JN33") == 0)
            this.getStaffABCTypeInfo();
            this.dEPT_NO_RJNComboBox.UserValue = "";
            this.sTAFF_NO_SIGNEFTextBox.Text = "";
            this.uSER_NAMEEFTextBox.Text = "";
            this.txtCardID.Text = "";
            this.txtEmpName.Text = "";
            this.txtEmpNo.Text = "";

        }

        #endregion

        private void efGridNRM_Click(object sender, EventArgs e)
        {

        }

        private void setABCTypeControlVisiable()
        {
            //总装部ABC分类
            //if (this.dEPT_NOJNComboBox.UserValue.CompareTo("JN33") == 0)
            if (this.isUsedABCType())
            {
                this.efLabel7.Visible = true;
                this.efTextBoxABCType.Visible = true;
                this.efGroupBoxABCUsedInfo.Visible = true;
                this.efGridNRM.Cols["ABC_TYPE"].Visible = true;
                this.efGrid1.Cols["ABC_TYPE"].Visible = true;
                this.efGrid1.Cols["TYPE_QUANTITY"].Visible = true;
                this.efGrid1.Cols["RETURN_FLAG"].Visible = true;
                this.efGrid1.Cols["RETURN_FLAG"].Visible = true;
                this.tAM51EFGrid.Cols["RETURN_FLAG"].AllowEditing = false;
                this.tAM51EFGrid.Cols["QUANTITY"].AllowEditing = false;

            }
            else
            {
                this.efLabel7.Visible = false;
                this.efTextBoxABCType.Visible = false;
                this.efGroupBoxABCUsedInfo.Visible = false;
                this.efGridNRM.Cols["ABC_TYPE"].Visible = false;
                this.efGrid1.Cols["ABC_TYPE"].Visible = false;
                this.efGrid1.Cols["TYPE_QUANTITY"].Visible = false;
                this.efGrid1.Cols["RETURN_FLAG"].Visible = false;
                this.tAM51EFGrid.Cols["RETURN_FLAG"].AllowEditing = true;
                this.tAM51EFGrid.Cols["QUANTITY"].AllowEditing = true;
            }
        }

        private void getStaffABCTypeInfo()
        {
            if (this.isUsedABCType())
            {
                EI.EIInfo inInfo = new EI.EIInfo();
                inInfo.AddColName("QUERY_FLAG");
                inInfo.SetColVal(1, "QUERY_FLAG", "F2");

                inInfo.AddColName("STAFF_NO");
                inInfo.SetColVal(1, "STAFF_NO", this.txtEmpNo.Text.Trim());
                inInfo.AddColName("STOCK_NO");
                inInfo.SetColVal(1, "STOCK_NO", this.sTOCK_NOJNComboBox.UserValue);
                inInfo.AddColName("DEPT_NO");
                inInfo.SetColVal(1, "DEPT_NO", this.dEPT_NOJNComboBox.UserValue);
                EI.EIInfo outInfo = EI.EITuxedo.CallService("amam_70_inq", inInfo);

                if (outInfo.sys_info.flag != 0)
                {
                    MessageBox.Show(outInfo.sys_info.msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (outInfo.Tables[0].Rows.Count == 0)
                {
                    this.efTextBoxABCType.Text = "C";
                }
                else
                {
                    this.efTextBoxABCType.Text = outInfo.Tables[0].Rows[0]["TYPE_DESC"] as string;
                }
                outInfo.blk_now = 1;
                outInfo.GetBlockVal(this.efGridABC);
            }
        }

        private bool isUsedABCType()
        {
            EI.EIInfo inInfo = new EI.EIInfo();
            inInfo.Tables[0].Columns.Add("PRO_TYPE");
            inInfo.Tables[0].Columns.Add("STOCK_NO");
            DataRow dr = inInfo.Tables[0].NewRow();
            dr["PRO_TYPE"] = "isUsedABC";
            dr["STOCK_NO"] = this.sTOCK_NOJNComboBox.UserValue;
            inInfo.Tables[0].Rows.Add(dr);
            EI.EIInfo outBlock = EI.EITuxedo.CallService("amam_090_inq", inInfo);

            if (outBlock.sys_info.flag != 0)
            {
                this.EFMsgInfo = outBlock.sys_info.msg;
                return false;
            }
            else
            { 
                if(outBlock.Tables[0].Rows.Count>0)
                {
                    //int isUsedABC = Convert.ToInt32(outBlock.Tables[0].Rows[0]["IS_USED_ABC"]);
                    String isUsedABC = outBlock.Tables[0].Rows[0]["IS_USED_ABC"].ToString();
                    if (isUsedABC.Trim() == "1")
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            //if (this.sTOCK_NOJNComboBox.UserValue.CompareTo("JN3302") == 0
            //    || this.sTOCK_NOJNComboBox.UserValue.CompareTo("CH4502") == 0)
            //{
            //    return true;
            //}
            //else
            //    return false;
        }

        private void sTOCK_NOJNComboBox_TextChanged(object sender, EventArgs e)
        {
            this.SetStoreTree(this.dEPT_NOJNComboBox.UserValue, this.sTOCK_NOJNComboBox.UserValue, this.sTOCK_NOJNComboBox.Text);
            this.setABCTypeControlVisiable();
        }
    }
}