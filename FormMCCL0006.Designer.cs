namespace MC
{
    partial class FormMCCL0006
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
            this.efGroupBox3 = new EF.EFGroupBox(this.components);
            this.dataGrid = new EF.EFDevGrid();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CbutDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemButton_del = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.CSHIP_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CTREE_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CBUFF1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CFDoDepartID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CFParentDepartID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CFOPDEPARTID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.CAssign = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemButton_AddWeld = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.CFProjectID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.删除 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.工程号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.分段号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.阶段 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.部门内码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.上级部门 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.承接部门 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.分配焊接 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.efGroupBox1 = new EF.EFGroupBox(this.components);
            this.ButCancel = new EF.EFButton();
            this.ButOk = new EF.EFButton();
            this.FEndDepartIDclass = new EF.EFComboBox(this.components);
            this.FDispatchENDTIME = new EF.EFDateTimePicker();
            this.FDispatchSTARTTIME = new EF.EFDateTimePicker();
            this.Label14 = new EF.EFLabel();
            this.Label13 = new EF.EFLabel();
            this.Label12 = new EF.EFLabel();
            this.Label11 = new EF.EFLabel();
            this.Label10 = new EF.EFLabel();
            this.FDispatchName = new EF.EFLabelText();
            this.FDispatchNum = new EF.EFLabelText();
            this.GroupBox2 = new EF.EFGroupBox(this.components);
            this.BUFF1 = new EF.EFComboBox(this.components);
            this.butAdd = new EF.EFButton();
            this.Label5 = new EF.EFLabel();
            this.Label3 = new EF.EFLabel();
            this.Label6 = new EF.EFLabel();
            this.Label4 = new EF.EFLabel();
            this.Label2 = new EF.EFLabel();
            this.Label15 = new EF.EFLabel();
            this.Label9 = new EF.EFLabel();
            this.Label8 = new EF.EFLabel();
            this.Label7 = new EF.EFLabel();
            this.Label1 = new EF.EFLabel();
            this.FENDTIME = new EF.EFLabelText();
            this.FProcessnum = new EF.EFLabelText();
            this.FSTARTTIME = new EF.EFLabelText();
            this.FProcessState = new EF.EFComboBox(this.components);
            this.FISControl = new EF.EFComboBox(this.components);
            this.TREE_NAME = new EF.EFComboBox(this.components);
            this.SHIP_NO = new EF.EFComboBox(this.components);
            this.FDoDepartID = new EF.EFComboBox(this.components);
            this.FProcessname = new EF.EFComboBox(this.components);
            this.efGroupBox2 = new EF.EFGroupBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox3)).BeginInit();
            this.efGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemButton_del)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemButton_AddWeld)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox1)).BeginInit();
            this.efGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ButCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupBox2)).BeginInit();
            this.GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.butAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox2)).BeginInit();
            this.efGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // efGroupBox3
            // 
            this.efGroupBox3.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.efGroupBox3.Appearance.Options.UseBackColor = true;
            this.efGroupBox3.Controls.Add(this.dataGrid);
            this.efGroupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.efGroupBox3.Location = new System.Drawing.Point(0, 322);
            this.efGroupBox3.Name = "efGroupBox3";
            this.efGroupBox3.Size = new System.Drawing.Size(1010, 270);
            this.efGroupBox3.TabIndex = 6;
            this.efGroupBox3.Text = "派工单- 表体- 焊缝";
            // 
            // dataGrid
            // 
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.Location = new System.Drawing.Point(2, 23);
            this.dataGrid.MainView = this.gridView2;
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemButton_del,
            this.ItemButton_AddWeld,
            this.LookUpEdit});
            this.dataGrid.Size = new System.Drawing.Size(1006, 245);
            this.dataGrid.TabIndex = 0;
            this.dataGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2,
            this.gridView1});
            this.dataGrid.Click += new System.EventHandler(this.efDevGrid1_Click_1);
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.CbutDelete,
            this.CSHIP_NO,
            this.CTREE_NAME,
            this.CBUFF1,
            this.CFDoDepartID,
            this.CFParentDepartID,
            this.CFOPDEPARTID,
            this.CAssign,
            this.CFProjectID});
            this.gridView2.FixedLineWidth = 1;
            this.gridView2.GridControl = this.dataGrid;
            this.gridView2.IndicatorWidth = 35;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView2.OptionsView.EnableAppearanceOddRow = true;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // CbutDelete
            // 
            this.CbutDelete.Caption = "删除";
            this.CbutDelete.ColumnEdit = this.ItemButton_del;
            this.CbutDelete.CustomizationCaption = "删除";
            this.CbutDelete.FieldName = "CbutDelete";
            this.CbutDelete.Name = "CbutDelete";
            this.CbutDelete.Visible = true;
            this.CbutDelete.VisibleIndex = 0;
            // 
            // ItemButton_del
            // 
            this.ItemButton_del.AutoHeight = false;
            this.ItemButton_del.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.ItemButton_del.Name = "ItemButton_del";
            this.ItemButton_del.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.ItemButton_del.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ItemButton_del_ButtonClick);
            // 
            // CSHIP_NO
            // 
            this.CSHIP_NO.Caption = "工程号";
            this.CSHIP_NO.CustomizationCaption = "工程号";
            this.CSHIP_NO.FieldName = "SHIP_NO";
            this.CSHIP_NO.Name = "CSHIP_NO";
            this.CSHIP_NO.OptionsColumn.AllowEdit = false;
            this.CSHIP_NO.Visible = true;
            this.CSHIP_NO.VisibleIndex = 1;
            // 
            // CTREE_NAME
            // 
            this.CTREE_NAME.Caption = "分段号";
            this.CTREE_NAME.CustomizationCaption = "分段号";
            this.CTREE_NAME.FieldName = "TREE_NAME";
            this.CTREE_NAME.Name = "CTREE_NAME";
            this.CTREE_NAME.OptionsColumn.AllowEdit = false;
            this.CTREE_NAME.Visible = true;
            this.CTREE_NAME.VisibleIndex = 2;
            // 
            // CBUFF1
            // 
            this.CBUFF1.Caption = "阶段";
            this.CBUFF1.CustomizationCaption = "阶段";
            this.CBUFF1.FieldName = "BUFF1";
            this.CBUFF1.Name = "CBUFF1";
            this.CBUFF1.OptionsColumn.AllowEdit = false;
            this.CBUFF1.Visible = true;
            this.CBUFF1.VisibleIndex = 3;
            // 
            // CFDoDepartID
            // 
            this.CFDoDepartID.Caption = "部门内码";
            this.CFDoDepartID.CustomizationCaption = "部门内码";
            this.CFDoDepartID.FieldName = "FDoDepartID";
            this.CFDoDepartID.Name = "CFDoDepartID";
            this.CFDoDepartID.OptionsColumn.AllowEdit = false;
            // 
            // CFParentDepartID
            // 
            this.CFParentDepartID.Caption = "上级部门";
            this.CFParentDepartID.CustomizationCaption = "上级部门";
            this.CFParentDepartID.FieldName = "FParentDepartID";
            this.CFParentDepartID.Name = "CFParentDepartID";
            this.CFParentDepartID.OptionsColumn.AllowEdit = false;
            // 
            // CFOPDEPARTID
            // 
            this.CFOPDEPARTID.Caption = "承接部门";
            this.CFOPDEPARTID.ColumnEdit = this.LookUpEdit;
            this.CFOPDEPARTID.CustomizationCaption = "承接部门";
            this.CFOPDEPARTID.FieldName = "FOPDEPARTID";
            this.CFOPDEPARTID.Name = "CFOPDEPARTID";
            this.CFOPDEPARTID.Visible = true;
            this.CFOPDEPARTID.VisibleIndex = 4;
            // 
            // LookUpEdit
            // 
            this.LookUpEdit.AutoHeight = false;
            this.LookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LookUpEdit.Name = "LookUpEdit";
            // 
            // CAssign
            // 
            this.CAssign.Caption = "分配焊接";
            this.CAssign.ColumnEdit = this.ItemButton_AddWeld;
            this.CAssign.CustomizationCaption = "分配焊接";
            this.CAssign.FieldName = "CAssign";
            this.CAssign.Name = "CAssign";
            this.CAssign.Visible = true;
            this.CAssign.VisibleIndex = 5;
            // 
            // ItemButton_AddWeld
            // 
            this.ItemButton_AddWeld.AutoHeight = false;
            this.ItemButton_AddWeld.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.ItemButton_AddWeld.Name = "ItemButton_AddWeld";
            this.ItemButton_AddWeld.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // CFProjectID
            // 
            this.CFProjectID.Caption = "WELDFID";
            this.CFProjectID.FieldName = "FProjectID";
            this.CFProjectID.Name = "CFProjectID";
            this.CFProjectID.OptionsColumn.AllowEdit = false;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.删除,
            this.工程号,
            this.分段号,
            this.阶段,
            this.部门内码,
            this.上级部门,
            this.承接部门,
            this.分配焊接});
            this.gridView1.FixedLineWidth = 1;
            this.gridView1.GridControl = this.dataGrid;
            this.gridView1.IndicatorWidth = 35;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // 删除
            // 
            this.删除.CustomizationCaption = "删除";
            this.删除.Name = "删除";
            this.删除.Visible = true;
            this.删除.VisibleIndex = 0;
            // 
            // 工程号
            // 
            this.工程号.CustomizationCaption = "工程号";
            this.工程号.Name = "工程号";
            this.工程号.Visible = true;
            this.工程号.VisibleIndex = 1;
            // 
            // 分段号
            // 
            this.分段号.CustomizationCaption = "分段号";
            this.分段号.Name = "分段号";
            this.分段号.Visible = true;
            this.分段号.VisibleIndex = 2;
            // 
            // 阶段
            // 
            this.阶段.Caption = "阶段";
            this.阶段.Name = "阶段";
            this.阶段.Visible = true;
            this.阶段.VisibleIndex = 3;
            // 
            // 部门内码
            // 
            this.部门内码.Caption = "部门内码";
            this.部门内码.Name = "部门内码";
            this.部门内码.Visible = true;
            this.部门内码.VisibleIndex = 4;
            // 
            // 上级部门
            // 
            this.上级部门.Caption = "上级部门";
            this.上级部门.Name = "上级部门";
            this.上级部门.Visible = true;
            this.上级部门.VisibleIndex = 5;
            // 
            // 承接部门
            // 
            this.承接部门.Caption = "承接部门";
            this.承接部门.Name = "承接部门";
            this.承接部门.Visible = true;
            this.承接部门.VisibleIndex = 6;
            // 
            // 分配焊接
            // 
            this.分配焊接.Caption = "分配焊接";
            this.分配焊接.Name = "分配焊接";
            this.分配焊接.Visible = true;
            this.分配焊接.VisibleIndex = 7;
            // 
            // efGroupBox1
            // 
            this.efGroupBox1.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.efGroupBox1.Appearance.Options.UseBackColor = true;
            this.efGroupBox1.Controls.Add(this.ButCancel);
            this.efGroupBox1.Controls.Add(this.ButOk);
            this.efGroupBox1.Controls.Add(this.FEndDepartIDclass);
            this.efGroupBox1.Controls.Add(this.FDispatchENDTIME);
            this.efGroupBox1.Controls.Add(this.FDispatchSTARTTIME);
            this.efGroupBox1.Controls.Add(this.Label14);
            this.efGroupBox1.Controls.Add(this.Label13);
            this.efGroupBox1.Controls.Add(this.Label12);
            this.efGroupBox1.Controls.Add(this.Label11);
            this.efGroupBox1.Controls.Add(this.Label10);
            this.efGroupBox1.Controls.Add(this.FDispatchName);
            this.efGroupBox1.Controls.Add(this.FDispatchNum);
            this.efGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.efGroupBox1.Location = new System.Drawing.Point(2, 23);
            this.efGroupBox1.Name = "efGroupBox1";
            this.efGroupBox1.Size = new System.Drawing.Size(1006, 118);
            this.efGroupBox1.TabIndex = 5;
            this.efGroupBox1.Text = "派工单- 表头";
            // 
            // ButCancel
            // 
            this.ButCancel.Authorizable = false;
            this.ButCancel.EnabledEx = true;
            this.ButCancel.FnNo = 0;
            this.ButCancel.Hint = "";
            this.ButCancel.Location = new System.Drawing.Point(937, 84);
            this.ButCancel.Name = "ButCancel";
            this.ButCancel.Size = new System.Drawing.Size(75, 23);
            this.ButCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ButCancel.TabIndex = 17;
            this.ButCancel.Text = "取消";
            this.ButCancel.ViewMode = EF.ViewModeEnum.Enable;
            // 
            // ButOk
            // 
            this.ButOk.Authorizable = false;
            this.ButOk.EnabledEx = true;
            this.ButOk.FnNo = 0;
            this.ButOk.Hint = "";
            this.ButOk.Location = new System.Drawing.Point(937, 39);
            this.ButOk.Name = "ButOk";
            this.ButOk.Size = new System.Drawing.Size(75, 23);
            this.ButOk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ButOk.TabIndex = 16;
            this.ButOk.Text = "保存";
            this.ButOk.ViewMode = EF.ViewModeEnum.Enable;
            // 
            // FEndDepartIDclass
            // 
            this.FEndDepartIDclass.ColumnName = null;
            this.FEndDepartIDclass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FEndDepartIDclass.EFCname = "";
            this.FEndDepartIDclass.EFDropDown = false;
            this.FEndDepartIDclass.FormattingEnabled = true;
            this.FEndDepartIDclass.Items.AddRange(new object[] {
            "班组"});
            this.FEndDepartIDclass.Location = new System.Drawing.Point(351, 42);
            this.FEndDepartIDclass.Name = "FEndDepartIDclass";
            this.FEndDepartIDclass.Size = new System.Drawing.Size(241, 22);
            this.FEndDepartIDclass.SQL = null;
            this.FEndDepartIDclass.TabIndex = 15;
            this.FEndDepartIDclass.UserValue = "";
            // 
            // FDispatchENDTIME
            // 
            this.FDispatchENDTIME.Location = new System.Drawing.Point(698, 83);
            this.FDispatchENDTIME.Name = "FDispatchENDTIME";
            this.FDispatchENDTIME.Size = new System.Drawing.Size(200, 22);
            this.FDispatchENDTIME.TabIndex = 14;
            // 
            // FDispatchSTARTTIME
            // 
            this.FDispatchSTARTTIME.Location = new System.Drawing.Point(698, 41);
            this.FDispatchSTARTTIME.Name = "FDispatchSTARTTIME";
            this.FDispatchSTARTTIME.Size = new System.Drawing.Size(200, 22);
            this.FDispatchSTARTTIME.TabIndex = 13;
            // 
            // Label14
            // 
            this.Label14.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.Label14.Location = new System.Drawing.Point(598, 85);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(62, 24);
            this.Label14.TabIndex = 12;
            this.Label14.Text = "截止时间";
            // 
            // Label13
            // 
            this.Label13.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.Label13.Location = new System.Drawing.Point(598, 36);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(62, 24);
            this.Label13.TabIndex = 11;
            this.Label13.Text = "开始时间";
            // 
            // Label12
            // 
            this.Label12.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.Label12.Location = new System.Drawing.Point(12, 84);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(62, 24);
            this.Label12.TabIndex = 10;
            this.Label12.Text = "派工单名称";
            // 
            // Label11
            // 
            this.Label11.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.Label11.Location = new System.Drawing.Point(285, 39);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(59, 24);
            this.Label11.TabIndex = 9;
            this.Label11.Text = "承接单位";
            // 
            // Label10
            // 
            this.Label10.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.Label10.Location = new System.Drawing.Point(12, 38);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(62, 24);
            this.Label10.TabIndex = 8;
            this.Label10.Text = "派工单编码";
            // 
            // FDispatchName
            // 
            this.FDispatchName.BackColor = System.Drawing.Color.Transparent;
            this.FDispatchName.EFArrange = EF.ArrangeMode.horizontal;
            this.FDispatchName.EFCname = "";
            this.FDispatchName.EFEname = null;
            this.FDispatchName.EFEnterText = "";
            this.FDispatchName.EFLeaveExpression = ".*";
            this.FDispatchName.EFLen = 32767;
            this.FDispatchName.EFType = EF.ValueType.EFString;
            this.FDispatchName.EFUpperCase = false;
            this.FDispatchName.Location = new System.Drawing.Point(80, 86);
            this.FDispatchName.Name = "FDispatchName";
            this.FDispatchName.ReadOnly = false;
            this.FDispatchName.Size = new System.Drawing.Size(183, 22);
            this.FDispatchName.TabIndex = 1;
            // 
            // FDispatchNum
            // 
            this.FDispatchNum.BackColor = System.Drawing.Color.Transparent;
            this.FDispatchNum.EFArrange = EF.ArrangeMode.horizontal;
            this.FDispatchNum.EFCname = "";
            this.FDispatchNum.EFEname = null;
            this.FDispatchNum.EFEnterText = "";
            this.FDispatchNum.EFLeaveExpression = ".*";
            this.FDispatchNum.EFLen = 32767;
            this.FDispatchNum.EFType = EF.ValueType.EFString;
            this.FDispatchNum.EFUpperCase = false;
            this.FDispatchNum.Location = new System.Drawing.Point(80, 38);
            this.FDispatchNum.Name = "FDispatchNum";
            this.FDispatchNum.ReadOnly = true;
            this.FDispatchNum.Size = new System.Drawing.Size(183, 22);
            this.FDispatchNum.TabIndex = 0;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.GroupBox2.Appearance.Options.UseBackColor = true;
            this.GroupBox2.Controls.Add(this.BUFF1);
            this.GroupBox2.Controls.Add(this.butAdd);
            this.GroupBox2.Controls.Add(this.Label5);
            this.GroupBox2.Controls.Add(this.Label3);
            this.GroupBox2.Controls.Add(this.Label6);
            this.GroupBox2.Controls.Add(this.Label4);
            this.GroupBox2.Controls.Add(this.Label2);
            this.GroupBox2.Controls.Add(this.Label15);
            this.GroupBox2.Controls.Add(this.Label9);
            this.GroupBox2.Controls.Add(this.Label8);
            this.GroupBox2.Controls.Add(this.Label7);
            this.GroupBox2.Controls.Add(this.Label1);
            this.GroupBox2.Controls.Add(this.FENDTIME);
            this.GroupBox2.Controls.Add(this.FProcessnum);
            this.GroupBox2.Controls.Add(this.FSTARTTIME);
            this.GroupBox2.Controls.Add(this.FProcessState);
            this.GroupBox2.Controls.Add(this.FISControl);
            this.GroupBox2.Controls.Add(this.TREE_NAME);
            this.GroupBox2.Controls.Add(this.SHIP_NO);
            this.GroupBox2.Controls.Add(this.FDoDepartID);
            this.GroupBox2.Controls.Add(this.FProcessname);
            this.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupBox2.Location = new System.Drawing.Point(2, 141);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(1006, 179);
            this.GroupBox2.TabIndex = 6;
            this.GroupBox2.Text = "工序计划";
            // 
            // BUFF1
            // 
            this.BUFF1.ColumnName = null;
            this.BUFF1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BUFF1.EFCname = "";
            this.BUFF1.EFDropDown = false;
            this.BUFF1.FormattingEnabled = true;
            this.BUFF1.Location = new System.Drawing.Point(838, 40);
            this.BUFF1.Name = "BUFF1";
            this.BUFF1.Size = new System.Drawing.Size(161, 22);
            this.BUFF1.SQL = null;
            this.BUFF1.TabIndex = 21;
            this.BUFF1.UserValue = "";
            // 
            // butAdd
            // 
            this.butAdd.Authorizable = false;
            this.butAdd.EnabledEx = true;
            this.butAdd.FnNo = 0;
            this.butAdd.Hint = "";
            this.butAdd.Location = new System.Drawing.Point(906, 92);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(75, 23);
            this.butAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.butAdd.TabIndex = 20;
            this.butAdd.Text = "选择";
            this.butAdd.ViewMode = EF.ViewModeEnum.Enable;
            this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
            // 
            // Label5
            // 
            this.Label5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.Label5.Location = new System.Drawing.Point(551, 90);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(62, 19);
            this.Label5.TabIndex = 19;
            this.Label5.Text = "是否管控";
            // 
            // Label3
            // 
            this.Label3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.Label3.Location = new System.Drawing.Point(16, 137);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(97, 19);
            this.Label3.TabIndex = 18;
            this.Label3.Text = "工序计划开始时间";
            // 
            // Label6
            // 
            this.Label6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.Label6.Location = new System.Drawing.Point(725, 91);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(42, 22);
            this.Label6.TabIndex = 17;
            this.Label6.Text = "状态";
            // 
            // Label4
            // 
            this.Label4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.Label4.Location = new System.Drawing.Point(273, 137);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(75, 19);
            this.Label4.TabIndex = 16;
            this.Label4.Text = "工序截止时间";
            // 
            // Label2
            // 
            this.Label2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.Label2.Location = new System.Drawing.Point(273, 90);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(75, 19);
            this.Label2.TabIndex = 15;
            this.Label2.Text = "工序计划编码";
            // 
            // Label15
            // 
            this.Label15.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.Label15.Location = new System.Drawing.Point(35, 92);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(52, 20);
            this.Label15.TabIndex = 14;
            this.Label15.Text = "承接单位";
            // 
            // Label9
            // 
            this.Label9.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.Label9.Location = new System.Drawing.Point(797, 37);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(34, 25);
            this.Label9.TabIndex = 13;
            this.Label9.Text = "阶段";
            // 
            // Label8
            // 
            this.Label8.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.Label8.Location = new System.Drawing.Point(551, 41);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(49, 19);
            this.Label8.TabIndex = 12;
            this.Label8.Text = "分段号";
            // 
            // Label7
            // 
            this.Label7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.Label7.Location = new System.Drawing.Point(285, 40);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(56, 19);
            this.Label7.TabIndex = 11;
            this.Label7.Text = "号船";
            // 
            // Label1
            // 
            this.Label1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.Label1.Location = new System.Drawing.Point(16, 40);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(75, 19);
            this.Label1.TabIndex = 10;
            this.Label1.Text = "工序计划名称";
            // 
            // FENDTIME
            // 
            this.FENDTIME.BackColor = System.Drawing.Color.Transparent;
            this.FENDTIME.EFArrange = EF.ArrangeMode.horizontal;
            this.FENDTIME.EFCname = "";
            this.FENDTIME.EFEname = null;
            this.FENDTIME.EFEnterText = "";
            this.FENDTIME.EFLeaveExpression = ".*";
            this.FENDTIME.EFLen = 32767;
            this.FENDTIME.EFType = EF.ValueType.EFString;
            this.FENDTIME.EFUpperCase = false;
            this.FENDTIME.Location = new System.Drawing.Point(351, 133);
            this.FENDTIME.Name = "FENDTIME";
            this.FENDTIME.ReadOnly = true;
            this.FENDTIME.Size = new System.Drawing.Size(194, 22);
            this.FENDTIME.TabIndex = 8;
            // 
            // FProcessnum
            // 
            this.FProcessnum.BackColor = System.Drawing.Color.Transparent;
            this.FProcessnum.EFArrange = EF.ArrangeMode.horizontal;
            this.FProcessnum.EFCname = "";
            this.FProcessnum.EFEname = null;
            this.FProcessnum.EFEnterText = "";
            this.FProcessnum.EFLeaveExpression = ".*";
            this.FProcessnum.EFLen = 32767;
            this.FProcessnum.EFType = EF.ValueType.EFString;
            this.FProcessnum.EFUpperCase = false;
            this.FProcessnum.Location = new System.Drawing.Point(351, 91);
            this.FProcessnum.Name = "FProcessnum";
            this.FProcessnum.ReadOnly = true;
            this.FProcessnum.Size = new System.Drawing.Size(194, 22);
            this.FProcessnum.TabIndex = 7;
            // 
            // FSTARTTIME
            // 
            this.FSTARTTIME.BackColor = System.Drawing.Color.Transparent;
            this.FSTARTTIME.EFArrange = EF.ArrangeMode.horizontal;
            this.FSTARTTIME.EFCname = "";
            this.FSTARTTIME.EFEname = null;
            this.FSTARTTIME.EFEnterText = "";
            this.FSTARTTIME.EFLeaveExpression = ".*";
            this.FSTARTTIME.EFLen = 32767;
            this.FSTARTTIME.EFType = EF.ValueType.EFString;
            this.FSTARTTIME.EFUpperCase = false;
            this.FSTARTTIME.Location = new System.Drawing.Point(119, 133);
            this.FSTARTTIME.Name = "FSTARTTIME";
            this.FSTARTTIME.ReadOnly = true;
            this.FSTARTTIME.Size = new System.Drawing.Size(144, 22);
            this.FSTARTTIME.TabIndex = 6;
            // 
            // FProcessState
            // 
            this.FProcessState.ColumnName = null;
            this.FProcessState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FProcessState.EFCname = "";
            this.FProcessState.EFDropDown = false;
            this.FProcessState.FormattingEnabled = true;
            this.FProcessState.Items.AddRange(new object[] {
            "0|正常",
            "1|挂起",
            "2|取消"});
            this.FProcessState.Location = new System.Drawing.Point(773, 92);
            this.FProcessState.Name = "FProcessState";
            this.FProcessState.Size = new System.Drawing.Size(58, 22);
            this.FProcessState.SQL = null;
            this.FProcessState.TabIndex = 5;
            this.FProcessState.UserValue = "";
            // 
            // FISControl
            // 
            this.FISControl.ColumnName = null;
            this.FISControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FISControl.EFCname = "";
            this.FISControl.EFDropDown = false;
            this.FISControl.FormattingEnabled = true;
            this.FISControl.Items.AddRange(new object[] {
            "是",
            "否"});
            this.FISControl.Location = new System.Drawing.Point(619, 91);
            this.FISControl.Name = "FISControl";
            this.FISControl.Size = new System.Drawing.Size(56, 22);
            this.FISControl.SQL = null;
            this.FISControl.TabIndex = 4;
            this.FISControl.UserValue = "";
            // 
            // TREE_NAME
            // 
            this.TREE_NAME.ColumnName = null;
            this.TREE_NAME.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TREE_NAME.EFCname = "";
            this.TREE_NAME.EFDropDown = false;
            this.TREE_NAME.FormattingEnabled = true;
            this.TREE_NAME.Location = new System.Drawing.Point(595, 37);
            this.TREE_NAME.Name = "TREE_NAME";
            this.TREE_NAME.Size = new System.Drawing.Size(196, 22);
            this.TREE_NAME.SQL = null;
            this.TREE_NAME.TabIndex = 3;
            this.TREE_NAME.UserValue = "";
            // 
            // SHIP_NO
            // 
            this.SHIP_NO.ColumnName = null;
            this.SHIP_NO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SHIP_NO.EFCname = "";
            this.SHIP_NO.EFDropDown = false;
            this.SHIP_NO.FormattingEnabled = true;
            this.SHIP_NO.Location = new System.Drawing.Point(351, 37);
            this.SHIP_NO.Name = "SHIP_NO";
            this.SHIP_NO.Size = new System.Drawing.Size(194, 22);
            this.SHIP_NO.SQL = null;
            this.SHIP_NO.TabIndex = 2;
            this.SHIP_NO.UserValue = "";
            // 
            // FDoDepartID
            // 
            this.FDoDepartID.ColumnName = null;
            this.FDoDepartID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FDoDepartID.EFCname = "";
            this.FDoDepartID.EFDropDown = false;
            this.FDoDepartID.FormattingEnabled = true;
            this.FDoDepartID.Location = new System.Drawing.Point(97, 90);
            this.FDoDepartID.Name = "FDoDepartID";
            this.FDoDepartID.Size = new System.Drawing.Size(166, 22);
            this.FDoDepartID.SQL = null;
            this.FDoDepartID.TabIndex = 1;
            this.FDoDepartID.UserValue = "";
            // 
            // FProcessname
            // 
            this.FProcessname.ColumnName = null;
            this.FProcessname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FProcessname.EFCname = "";
            this.FProcessname.EFDropDown = false;
            this.FProcessname.FormattingEnabled = true;
            this.FProcessname.Location = new System.Drawing.Point(97, 37);
            this.FProcessname.Name = "FProcessname";
            this.FProcessname.Size = new System.Drawing.Size(166, 22);
            this.FProcessname.SQL = null;
            this.FProcessname.TabIndex = 0;
            this.FProcessname.UserValue = "";
            // 
            // efGroupBox2
            // 
            this.efGroupBox2.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.efGroupBox2.Appearance.Options.UseBackColor = true;
            this.efGroupBox2.Controls.Add(this.GroupBox2);
            this.efGroupBox2.Controls.Add(this.efGroupBox1);
            this.efGroupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.efGroupBox2.Location = new System.Drawing.Point(0, 0);
            this.efGroupBox2.Name = "efGroupBox2";
            this.efGroupBox2.Size = new System.Drawing.Size(1010, 322);
            this.efGroupBox2.TabIndex = 7;
            // 
            // FormMCCL0006
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 638);
            this.Controls.Add(this.efGroupBox3);
            this.Controls.Add(this.efGroupBox2);
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "FormMCCL0006";
            this.Text = "工序计划派工单";
            this.Load += new System.EventHandler(this.FormMCCL0006_Load);
            this.Controls.SetChildIndex(this.efGroupBox2, 0);
            this.Controls.SetChildIndex(this.efGroupBox3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox3)).EndInit();
            this.efGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemButton_del)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemButton_AddWeld)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox1)).EndInit();
            this.efGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ButCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupBox2)).EndInit();
            this.GroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.butAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox2)).EndInit();
            this.efGroupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private EF.EFGroupBox efGroupBox3;
        private EF.EFDevGrid dataGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn 删除;
        private DevExpress.XtraGrid.Columns.GridColumn 工程号;
        private DevExpress.XtraGrid.Columns.GridColumn 分段号;
        private DevExpress.XtraGrid.Columns.GridColumn 阶段;
        private DevExpress.XtraGrid.Columns.GridColumn 部门内码;
        private DevExpress.XtraGrid.Columns.GridColumn 上级部门;
        private DevExpress.XtraGrid.Columns.GridColumn 承接部门;
        private DevExpress.XtraGrid.Columns.GridColumn 分配焊接;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn CbutDelete;
        private DevExpress.XtraGrid.Columns.GridColumn CSHIP_NO;
        private DevExpress.XtraGrid.Columns.GridColumn CTREE_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn CBUFF1;
        private DevExpress.XtraGrid.Columns.GridColumn CFDoDepartID;
        private DevExpress.XtraGrid.Columns.GridColumn CFParentDepartID;
        private DevExpress.XtraGrid.Columns.GridColumn CFOPDEPARTID;
        private DevExpress.XtraGrid.Columns.GridColumn CAssign;
        private EF.EFGroupBox efGroupBox1;
        private EF.EFButton ButCancel;
        private EF.EFButton ButOk;
        private EF.EFComboBox FEndDepartIDclass;
        private EF.EFDateTimePicker FDispatchENDTIME;
        private EF.EFDateTimePicker FDispatchSTARTTIME;
        private EF.EFLabel Label14;
        private EF.EFLabel Label13;
        private EF.EFLabel Label12;
        private EF.EFLabel Label11;
        private EF.EFLabel Label10;
        private EF.EFLabelText FDispatchName;
        private EF.EFLabelText FDispatchNum;
        private EF.EFGroupBox GroupBox2;
        private EF.EFButton butAdd;
        private EF.EFLabel Label5;
        private EF.EFLabel Label3;
        private EF.EFLabel Label6;
        private EF.EFLabel Label4;
        private EF.EFLabel Label2;
        private EF.EFLabel Label15;
        private EF.EFLabel Label9;
        private EF.EFLabel Label8;
        private EF.EFLabel Label7;
        private EF.EFLabel Label1;
        private EF.EFLabelText FENDTIME;
        private EF.EFLabelText FProcessnum;
        private EF.EFLabelText FSTARTTIME;
        private EF.EFComboBox FProcessState;
        private EF.EFComboBox FISControl;
        private EF.EFComboBox TREE_NAME;
        private EF.EFComboBox SHIP_NO;
        private EF.EFComboBox FDoDepartID;
        private EF.EFComboBox FProcessname;
        private EF.EFGroupBox efGroupBox2;
        private DevExpress.XtraGrid.Columns.GridColumn CFProjectID;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ItemButton_del;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ItemButton_AddWeld;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit LookUpEdit;
        private EF.EFComboBox BUFF1;

    }
}