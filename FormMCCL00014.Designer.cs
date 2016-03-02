namespace MC
{
    partial class FormMCCL00014
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ItemCheck = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.ItemButton = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.efGroupBox1 = new EF.EFGroupBox(this.components);
            this.butCancel = new EF.EFButton();
            this.butOK = new EF.EFButton();
            this.txtValue = new EF.EFTextBox();
            this.butSeachin = new EF.EFButton();
            this.butSelectAll = new EF.EFButton();
            this.cbbCondition = new EF.EFComboBox(this.components);
            this.cbbField = new EF.EFComboBox(this.components);
            this.butreturn = new EF.EFButton();
            this.efGroupBox2 = new EF.EFGroupBox(this.components);
            this.dataGrid = new EF.EFDevGrid();
            this.view = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CFChecked = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CCRuleNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CRuleNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CRuleFID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CPART1_NAME2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CPART2_NAME2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CTHICK1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CTHICK2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CGRADE1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CGRADE2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CWELD_T_LEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CWELD_MOD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CWELD_POS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CWELD1_CODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CWELD2_CODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CWELD_TYPE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CFID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox1)).BeginInit();
            this.efGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.butCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.butOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.butSeachin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.butSelectAll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.butreturn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox2)).BeginInit();
            this.efGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.view)).BeginInit();
            this.SuspendLayout();
            // 
            // ItemCheck
            // 
            this.ItemCheck.AutoHeight = false;
            this.ItemCheck.Caption = "选择";
            this.ItemCheck.Name = "ItemCheck";
            this.ItemCheck.ValueChecked = 1;
            this.ItemCheck.ValueUnchecked = 0;
            // 
            // ItemButton
            // 
            this.ItemButton.AutoHeight = false;
            this.ItemButton.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.ItemButton.Name = "ItemButton";
            // 
            // efGroupBox1
            // 
            this.efGroupBox1.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.efGroupBox1.Appearance.Options.UseBackColor = true;
            this.efGroupBox1.Controls.Add(this.butCancel);
            this.efGroupBox1.Controls.Add(this.butOK);
            this.efGroupBox1.Controls.Add(this.txtValue);
            this.efGroupBox1.Controls.Add(this.butSeachin);
            this.efGroupBox1.Controls.Add(this.butSelectAll);
            this.efGroupBox1.Controls.Add(this.cbbCondition);
            this.efGroupBox1.Controls.Add(this.cbbField);
            this.efGroupBox1.Controls.Add(this.butreturn);
            this.efGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.efGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.efGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.efGroupBox1.Name = "efGroupBox1";
            this.efGroupBox1.Size = new System.Drawing.Size(1276, 80);
            this.efGroupBox1.TabIndex = 4;
            // 
            // butCancel
            // 
            this.butCancel.Authorizable = false;
            this.butCancel.EnabledEx = true;
            this.butCancel.FnNo = 0;
            this.butCancel.Hint = "";
            this.butCancel.Location = new System.Drawing.Point(1317, 46);
            this.butCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(107, 83);
            this.butCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.butCancel.TabIndex = 12;
            this.butCancel.Text = "取消";
            this.butCancel.ViewMode = EF.ViewModeEnum.Enable;
            // 
            // butOK
            // 
            this.butOK.Authorizable = false;
            this.butOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.butOK.EnabledEx = true;
            this.butOK.FnNo = 0;
            this.butOK.Hint = "";
            this.butOK.Location = new System.Drawing.Point(979, 28);
            this.butOK.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(107, 36);
            this.butOK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.butOK.TabIndex = 11;
            this.butOK.Text = "确定";
            this.butOK.ViewMode = EF.ViewModeEnum.Enable;
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // txtValue
            // 
            this.txtValue.EFEname = null;
            this.txtValue.EFLeaveExpression = ".*";
            this.txtValue.EFLen = 32767;
            this.txtValue.Location = new System.Drawing.Point(419, 35);
            this.txtValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(321, 29);
            this.txtValue.TabIndex = 9;
            this.txtValue.Visible = false;
            // 
            // butSeachin
            // 
            this.butSeachin.Authorizable = false;
            this.butSeachin.EnabledEx = true;
            this.butSeachin.FnNo = 0;
            this.butSeachin.Hint = "";
            this.butSeachin.Location = new System.Drawing.Point(749, 28);
            this.butSeachin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.butSeachin.Name = "butSeachin";
            this.butSeachin.Size = new System.Drawing.Size(109, 36);
            this.butSeachin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.butSeachin.TabIndex = 8;
            this.butSeachin.Text = "结果内搜索F1";
            this.butSeachin.ViewMode = EF.ViewModeEnum.Enable;
            this.butSeachin.Visible = false;
            this.butSeachin.Click += new System.EventHandler(this.butSeachin_Click);
            // 
            // butSelectAll
            // 
            this.butSelectAll.Authorizable = false;
            this.butSelectAll.EnabledEx = true;
            this.butSelectAll.FnNo = 0;
            this.butSelectAll.Hint = "";
            this.butSelectAll.Location = new System.Drawing.Point(864, 28);
            this.butSelectAll.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.butSelectAll.Name = "butSelectAll";
            this.butSelectAll.Size = new System.Drawing.Size(106, 36);
            this.butSelectAll.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.butSelectAll.TabIndex = 7;
            this.butSelectAll.Text = "全选";
            this.butSelectAll.ViewMode = EF.ViewModeEnum.Enable;
            this.butSelectAll.Click += new System.EventHandler(this.efButton1_Click);
            // 
            // cbbCondition
            // 
            this.cbbCondition.ColumnName = null;
            this.cbbCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCondition.EFCname = "";
            this.cbbCondition.EFDropDown = false;
            this.cbbCondition.FormattingEnabled = true;
            this.cbbCondition.Location = new System.Drawing.Point(321, 35);
            this.cbbCondition.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbbCondition.Name = "cbbCondition";
            this.cbbCondition.Size = new System.Drawing.Size(90, 30);
            this.cbbCondition.SQL = null;
            this.cbbCondition.TabIndex = 6;
            this.cbbCondition.UserValue = "";
            this.cbbCondition.Visible = false;
            // 
            // cbbField
            // 
            this.cbbField.ColumnName = null;
            this.cbbField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbField.EFCname = "";
            this.cbbField.EFDropDown = false;
            this.cbbField.FormattingEnabled = true;
            this.cbbField.Location = new System.Drawing.Point(6, 35);
            this.cbbField.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbbField.Name = "cbbField";
            this.cbbField.Size = new System.Drawing.Size(307, 30);
            this.cbbField.SQL = null;
            this.cbbField.TabIndex = 5;
            this.cbbField.UserValue = "";
            this.cbbField.Visible = false;
            // 
            // butreturn
            // 
            this.butreturn.Authorizable = false;
            this.butreturn.EnabledEx = true;
            this.butreturn.FnNo = 0;
            this.butreturn.Hint = "";
            this.butreturn.Location = new System.Drawing.Point(574, 28);
            this.butreturn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.butreturn.Name = "butreturn";
            this.butreturn.Size = new System.Drawing.Size(106, 36);
            this.butreturn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.butreturn.TabIndex = 1;
            this.butreturn.Text = "还原F2";
            this.butreturn.ViewMode = EF.ViewModeEnum.Enable;
            this.butreturn.Visible = false;
            this.butreturn.Click += new System.EventHandler(this.butreturn_Click);
            // 
            // efGroupBox2
            // 
            this.efGroupBox2.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.efGroupBox2.Appearance.Options.UseBackColor = true;
            this.efGroupBox2.Controls.Add(this.dataGrid);
            this.efGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.efGroupBox2.Location = new System.Drawing.Point(0, 80);
            this.efGroupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.efGroupBox2.Name = "efGroupBox2";
            this.efGroupBox2.Size = new System.Drawing.Size(1276, 846);
            this.efGroupBox2.TabIndex = 5;
            this.efGroupBox2.Text = "数据";
            // 
            // dataGrid
            // 
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.IsUseCustomPageBar = true;
            this.dataGrid.Location = new System.Drawing.Point(2, 30);
            this.dataGrid.MainView = this.view;
            this.dataGrid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ShowContextMenuAddCopyNew = false;
            this.dataGrid.ShowContextMenuAddNew = false;
            this.dataGrid.ShowContextMenuChoose = false;
            this.dataGrid.ShowContextMenuSaveAs = false;
            this.dataGrid.ShowContextMenuUnChoose = false;
            this.dataGrid.ShowContextMenuUnChooseAll = false;
            this.dataGrid.ShowExportButton = false;
            this.dataGrid.ShowGroupButton = false;
            this.dataGrid.ShowPageButton = false;
            this.dataGrid.ShowRefreshButton = false;
            this.dataGrid.ShowRowIndicator = false;
            this.dataGrid.ShowSaveLayoutButton = false;
            this.dataGrid.Size = new System.Drawing.Size(1272, 814);
            this.dataGrid.TabIndex = 0;
            this.dataGrid.UseEmbeddedNavigator = true;
            this.dataGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.view});
            this.dataGrid.Click += new System.EventHandler(this.dataGrid_Click);
            // 
            // view
            // 
            this.view.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.CFChecked,
            this.CCRuleNum,
            this.CRuleNum,
            this.CRuleFID,
            this.CPART1_NAME2,
            this.CPART2_NAME2,
            this.CTHICK1,
            this.CTHICK2,
            this.CGRADE1,
            this.CGRADE2,
            this.CWELD_T_LEN,
            this.CWELD_MOD,
            this.CWELD_POS,
            this.CWELD1_CODE,
            this.CWELD2_CODE,
            this.CWELD_TYPE,
            this.CFID,
            this.gridColumn1});
            this.view.FixedLineWidth = 1;
            this.view.GridControl = this.dataGrid;
            this.view.IndicatorWidth = 35;
            this.view.Name = "view";
            this.view.OptionsView.ColumnAutoWidth = false;
            this.view.OptionsView.EnableAppearanceEvenRow = true;
            this.view.OptionsView.EnableAppearanceOddRow = true;
            this.view.OptionsView.ShowGroupPanel = false;
            this.view.ColumnFilterChanged += new System.EventHandler(this.view_ColumnFilterChanged);
            // 
            // CFChecked
            // 
            this.CFChecked.Caption = "选择";
            this.CFChecked.ColumnEdit = this.ItemCheck;
            this.CFChecked.CustomizationCaption = "选择";
            this.CFChecked.FieldName = "FChecked";
            this.CFChecked.Name = "CFChecked";
            this.CFChecked.Visible = true;
            this.CFChecked.VisibleIndex = 0;
            // 
            // CCRuleNum
            // 
            this.CCRuleNum.Caption = "选择WPS规程";
            this.CCRuleNum.ColumnEdit = this.ItemButton;
            this.CCRuleNum.CustomizationCaption = "选择WPS规程";
            this.CCRuleNum.FieldName = "CCRuleNum";
            this.CCRuleNum.Name = "CCRuleNum";
            this.CCRuleNum.Visible = true;
            this.CCRuleNum.VisibleIndex = 1;
            // 
            // CRuleNum
            // 
            this.CRuleNum.Caption = "规程编号";
            this.CRuleNum.CustomizationCaption = "规程编号";
            this.CRuleNum.FieldName = "RuleNum";
            this.CRuleNum.Name = "CRuleNum";
            this.CRuleNum.OptionsColumn.AllowEdit = false;
            this.CRuleNum.Visible = true;
            this.CRuleNum.VisibleIndex = 2;
            // 
            // CRuleFID
            // 
            this.CRuleFID.Caption = "规FID";
            this.CRuleFID.CustomizationCaption = "规FID";
            this.CRuleFID.FieldName = "RuleFID";
            this.CRuleFID.Name = "CRuleFID";
            this.CRuleFID.OptionsColumn.AllowEdit = false;
            this.CRuleFID.Visible = true;
            this.CRuleFID.VisibleIndex = 3;
            // 
            // CPART1_NAME2
            // 
            this.CPART1_NAME2.Caption = "零件名1";
            this.CPART1_NAME2.CustomizationCaption = "零件名1";
            this.CPART1_NAME2.FieldName = "PART1_NAME2";
            this.CPART1_NAME2.Name = "CPART1_NAME2";
            this.CPART1_NAME2.OptionsColumn.AllowEdit = false;
            this.CPART1_NAME2.Visible = true;
            this.CPART1_NAME2.VisibleIndex = 4;
            // 
            // CPART2_NAME2
            // 
            this.CPART2_NAME2.Caption = "零件名2";
            this.CPART2_NAME2.CustomizationCaption = "零件名2";
            this.CPART2_NAME2.FieldName = "PART2_NAME2";
            this.CPART2_NAME2.Name = "CPART2_NAME2";
            this.CPART2_NAME2.OptionsColumn.AllowEdit = false;
            this.CPART2_NAME2.Visible = true;
            this.CPART2_NAME2.VisibleIndex = 5;
            // 
            // CTHICK1
            // 
            this.CTHICK1.Caption = "板厚1";
            this.CTHICK1.CustomizationCaption = "板厚1";
            this.CTHICK1.FieldName = "THICK1";
            this.CTHICK1.Name = "CTHICK1";
            this.CTHICK1.OptionsColumn.AllowEdit = false;
            this.CTHICK1.Visible = true;
            this.CTHICK1.VisibleIndex = 6;
            // 
            // CTHICK2
            // 
            this.CTHICK2.Caption = "板厚2";
            this.CTHICK2.CustomizationCaption = "板厚2";
            this.CTHICK2.FieldName = "THICK2";
            this.CTHICK2.Name = "CTHICK2";
            this.CTHICK2.OptionsColumn.AllowEdit = false;
            this.CTHICK2.Visible = true;
            this.CTHICK2.VisibleIndex = 7;
            // 
            // CGRADE1
            // 
            this.CGRADE1.Caption = "材质1";
            this.CGRADE1.CustomizationCaption = "材质1";
            this.CGRADE1.FieldName = "GRADE1";
            this.CGRADE1.Name = "CGRADE1";
            this.CGRADE1.OptionsColumn.AllowEdit = false;
            this.CGRADE1.Visible = true;
            this.CGRADE1.VisibleIndex = 8;
            // 
            // CGRADE2
            // 
            this.CGRADE2.Caption = "材质2";
            this.CGRADE2.CustomizationCaption = "材质2";
            this.CGRADE2.FieldName = "GRADE2";
            this.CGRADE2.Name = "CGRADE2";
            this.CGRADE2.OptionsColumn.AllowEdit = false;
            this.CGRADE2.Visible = true;
            this.CGRADE2.VisibleIndex = 9;
            // 
            // CWELD_T_LEN
            // 
            this.CWELD_T_LEN.Caption = "装配长度";
            this.CWELD_T_LEN.CustomizationCaption = "装配长度";
            this.CWELD_T_LEN.FieldName = "WELD_T_LEN";
            this.CWELD_T_LEN.Name = "CWELD_T_LEN";
            this.CWELD_T_LEN.OptionsColumn.AllowEdit = false;
            this.CWELD_T_LEN.Visible = true;
            this.CWELD_T_LEN.VisibleIndex = 10;
            // 
            // CWELD_MOD
            // 
            this.CWELD_MOD.Caption = "焊接方法";
            this.CWELD_MOD.CustomizationCaption = "焊接方法";
            this.CWELD_MOD.FieldName = "WELD_MOD";
            this.CWELD_MOD.Name = "CWELD_MOD";
            this.CWELD_MOD.OptionsColumn.AllowEdit = false;
            this.CWELD_MOD.Visible = true;
            this.CWELD_MOD.VisibleIndex = 11;
            // 
            // CWELD_POS
            // 
            this.CWELD_POS.Caption = "焊接等级要求";
            this.CWELD_POS.CustomizationCaption = "焊接等级要求";
            this.CWELD_POS.FieldName = "WELD_POS";
            this.CWELD_POS.Name = "CWELD_POS";
            this.CWELD_POS.OptionsColumn.AllowEdit = false;
            this.CWELD_POS.Visible = true;
            this.CWELD_POS.VisibleIndex = 12;
            // 
            // CWELD1_CODE
            // 
            this.CWELD1_CODE.Caption = "坡口代码";
            this.CWELD1_CODE.CustomizationCaption = "坡口代码";
            this.CWELD1_CODE.FieldName = "WELD1_CODE";
            this.CWELD1_CODE.Name = "CWELD1_CODE";
            this.CWELD1_CODE.OptionsColumn.AllowEdit = false;
            this.CWELD1_CODE.Visible = true;
            this.CWELD1_CODE.VisibleIndex = 13;
            // 
            // CWELD2_CODE
            // 
            this.CWELD2_CODE.Caption = "坡口角度";
            this.CWELD2_CODE.CustomizationCaption = "坡口角度";
            this.CWELD2_CODE.FieldName = "WELD2_CODE";
            this.CWELD2_CODE.Name = "CWELD2_CODE";
            this.CWELD2_CODE.OptionsColumn.AllowEdit = false;
            this.CWELD2_CODE.Visible = true;
            this.CWELD2_CODE.VisibleIndex = 14;
            // 
            // CWELD_TYPE
            // 
            this.CWELD_TYPE.Caption = "焊接形式";
            this.CWELD_TYPE.CustomizationCaption = "焊接形式";
            this.CWELD_TYPE.FieldName = "WELD_TYPE";
            this.CWELD_TYPE.Name = "CWELD_TYPE";
            this.CWELD_TYPE.OptionsColumn.AllowEdit = false;
            this.CWELD_TYPE.Visible = true;
            this.CWELD_TYPE.VisibleIndex = 15;
            // 
            // CFID
            // 
            this.CFID.Caption = "gridColumn17";
            this.CFID.FieldName = "FID";
            this.CFID.Name = "CFID";
            this.CFID.Visible = true;
            this.CFID.VisibleIndex = 16;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "CBUFF1";
            this.gridColumn1.FieldName = "BUFF1";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 17;
            // 
            // FormMCCL00014
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 998);
            this.Controls.Add(this.efGroupBox2);
            this.Controls.Add(this.efGroupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormMCCL00014";
            this.Text = "焊缝-WPS配置";
            this.EF_DO_F1 += new EF.EFButtonBar.EFDoFnEventHandler(this.FormMCCL00014_EF_DO_F1);
            this.EF_DO_F3 += new EF.EFButtonBar.EFDoFnEventHandler(this.FormMCCL00014_EF_DO_F3);
            this.EF_DO_F2 += new EF.EFButtonBar.EFDoFnEventHandler(this.FormMCCL00014_EF_DO_F2);
            this.Controls.SetChildIndex(this.efGroupBox1, 0);
            this.Controls.SetChildIndex(this.efGroupBox2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox1)).EndInit();
            this.efGroupBox1.ResumeLayout(false);
            this.efGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.butCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.butOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.butSeachin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.butSelectAll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.butreturn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox2)).EndInit();
            this.efGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.view)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private EF.EFGroupBox efGroupBox1;
        private EF.EFGroupBox efGroupBox2;
        private EF.EFDevGrid dataGrid;
        private EF.EFButton butreturn;
        private DevExpress.XtraGrid.Views.Grid.GridView view;
        private EF.EFComboBox cbbField;
        private EF.EFButton butSeachin;
        private EF.EFButton butSelectAll;
        private EF.EFComboBox cbbCondition;
        private DevExpress.XtraGrid.Columns.GridColumn CFChecked;
        private DevExpress.XtraGrid.Columns.GridColumn CCRuleNum;
        private DevExpress.XtraGrid.Columns.GridColumn CRuleNum;
        private DevExpress.XtraGrid.Columns.GridColumn CRuleFID;
        private DevExpress.XtraGrid.Columns.GridColumn CPART1_NAME2;
        private DevExpress.XtraGrid.Columns.GridColumn CPART2_NAME2;
        private DevExpress.XtraGrid.Columns.GridColumn CTHICK1;
        private DevExpress.XtraGrid.Columns.GridColumn CTHICK2;
        private DevExpress.XtraGrid.Columns.GridColumn CGRADE1;
        private DevExpress.XtraGrid.Columns.GridColumn CGRADE2;
        private DevExpress.XtraGrid.Columns.GridColumn CWELD_T_LEN;
        private DevExpress.XtraGrid.Columns.GridColumn CWELD_MOD;
        private DevExpress.XtraGrid.Columns.GridColumn CWELD_POS;
        private DevExpress.XtraGrid.Columns.GridColumn CWELD1_CODE;
        private DevExpress.XtraGrid.Columns.GridColumn CWELD2_CODE;
        private DevExpress.XtraGrid.Columns.GridColumn CWELD_TYPE;
        private EF.EFTextBox txtValue;
        private EF.EFButton butCancel;
        private EF.EFButton butOK;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ItemCheck;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ItemButton;
        private DevExpress.XtraGrid.Columns.GridColumn CFID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;

    }
}