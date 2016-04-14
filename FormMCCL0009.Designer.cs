namespace MC
{
    partial class FormMCCL0009
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
            this.CIndexnum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CSHIP_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CSHIP_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CTREE_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CFDoDepartID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LU_Depart = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.CButWeld = new DevExpress.XtraGrid.Columns.GridColumn();
            this.but_Welds = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.CButDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.but_Del = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.删除 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.工程号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.分段号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.阶段 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.部门内码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.上级部门 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.承接部门 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.分配焊接 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GroupBox2 = new EF.EFGroupBox(this.components);
            this.butOK = new EF.EFButton();
            this.FENDTIME = new EF.EFDateTimePicker2();
            this.FDepartID = new EF.EFComboBox(this.components);
            this.FSTARTTIME = new EF.EFDateTimePicker2();
            this.FProcessname = new EF.EFLabelText();
            this.Label50 = new EF.EFLabel();
            this.Label8 = new EF.EFLabel();
            this.Label60 = new EF.EFLabel();
            this.Label7 = new EF.EFLabel();
            this.Label6 = new EF.EFLabel();
            this.Label4 = new EF.EFLabel();
            this.Label5 = new EF.EFLabel();
            this.FProcessnum = new EF.EFLabelText();
            this.FProcessState = new EF.EFComboBox(this.components);
            this.FISControl = new EF.EFComboBox(this.components);
            this.efGroupBox2 = new EF.EFGroupBox(this.components);
            this.efGroupBox1 = new EF.EFGroupBox(this.components);
            this.butAdd = new EF.EFButton();
            this.SHIP_NO = new EF.EFComboBox(this.components);
            this.TREE_NAME = new EF.EFComboBox(this.components);
            this.Label2 = new EF.EFLabel();
            this.Label1 = new EF.EFLabel();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox3)).BeginInit();
            this.efGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LU_Depart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_Welds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_Del)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupBox2)).BeginInit();
            this.GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.butOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox2)).BeginInit();
            this.efGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox1)).BeginInit();
            this.efGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.butAdd)).BeginInit();
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
            this.efGroupBox3.Size = new System.Drawing.Size(896, 270);
            this.efGroupBox3.TabIndex = 6;
            // 
            // dataGrid
            // 
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.Location = new System.Drawing.Point(2, 23);
            this.dataGrid.MainView = this.gridView2;
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.but_Del,
            this.but_Welds,
            this.LU_Depart});
            this.dataGrid.Size = new System.Drawing.Size(892, 245);
            this.dataGrid.TabIndex = 0;
            this.dataGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2,
            this.gridView1});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.CIndexnum,
            this.CSHIP_ID,
            this.CSHIP_NO,
            this.CTREE_NAME,
            this.CFDoDepartID,
            this.CButWeld,
            this.CButDelete});
            this.gridView2.FixedLineWidth = 1;
            this.gridView2.GridControl = this.dataGrid;
            this.gridView2.IndicatorWidth = 35;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView2.OptionsView.EnableAppearanceOddRow = true;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // CIndexnum
            // 
            this.CIndexnum.Caption = "序号";
            this.CIndexnum.CustomizationCaption = "序号";
            this.CIndexnum.FieldName = "Indexnum";
            this.CIndexnum.Name = "CIndexnum";
            this.CIndexnum.OptionsColumn.AllowEdit = false;
            this.CIndexnum.Visible = true;
            this.CIndexnum.VisibleIndex = 0;
            // 
            // CSHIP_ID
            // 
            this.CSHIP_ID.Caption = "船号";
            this.CSHIP_ID.CustomizationCaption = "船号";
            this.CSHIP_ID.FieldName = "SHIP_ID";
            this.CSHIP_ID.Name = "CSHIP_ID";
            this.CSHIP_ID.OptionsColumn.AllowEdit = false;
            this.CSHIP_ID.Visible = true;
            this.CSHIP_ID.VisibleIndex = 1;
            // 
            // CSHIP_NO
            // 
            this.CSHIP_NO.Caption = "工程号";
            this.CSHIP_NO.CustomizationCaption = "工程号";
            this.CSHIP_NO.FieldName = "SHIP_NO";
            this.CSHIP_NO.Name = "CSHIP_NO";
            this.CSHIP_NO.OptionsColumn.AllowEdit = false;
            this.CSHIP_NO.Visible = true;
            this.CSHIP_NO.VisibleIndex = 2;
            // 
            // CTREE_NAME
            // 
            this.CTREE_NAME.Caption = "分段号";
            this.CTREE_NAME.CustomizationCaption = "分段号";
            this.CTREE_NAME.FieldName = "TREE_NAME";
            this.CTREE_NAME.Name = "CTREE_NAME";
            this.CTREE_NAME.OptionsColumn.AllowEdit = false;
            this.CTREE_NAME.Visible = true;
            this.CTREE_NAME.VisibleIndex = 3;
            // 
            // CFDoDepartID
            // 
            this.CFDoDepartID.Caption = "承接单位";
            this.CFDoDepartID.ColumnEdit = this.LU_Depart;
            this.CFDoDepartID.CustomizationCaption = "承接单位";
            this.CFDoDepartID.FieldName = "FDoDepartID";
            this.CFDoDepartID.Name = "CFDoDepartID";
            this.CFDoDepartID.Visible = true;
            this.CFDoDepartID.VisibleIndex = 4;
            // 
            // LU_Depart
            // 
            this.LU_Depart.AutoHeight = false;
            this.LU_Depart.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LU_Depart.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.LU_Depart.Name = "LU_Depart";
            // 
            // CButWeld
            // 
            this.CButWeld.Caption = "查看焊缝";
            this.CButWeld.ColumnEdit = this.but_Welds;
            this.CButWeld.CustomizationCaption = "查看焊缝";
            this.CButWeld.FieldName = "but_Welds";
            this.CButWeld.Name = "CButWeld";
            this.CButWeld.Visible = true;
            this.CButWeld.VisibleIndex = 5;
            // 
            // but_Welds
            // 
            this.but_Welds.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.but_Welds.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.but_Welds.Name = "but_Welds";
            this.but_Welds.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // CButDelete
            // 
            this.CButDelete.Caption = "删除";
            this.CButDelete.ColumnEdit = this.but_Del;
            this.CButDelete.CustomizationCaption = "删除";
            this.CButDelete.FieldName = "but_Del";
            this.CButDelete.Name = "CButDelete";
            this.CButDelete.Visible = true;
            this.CButDelete.VisibleIndex = 6;
            // 
            // but_Del
            // 
            this.but_Del.AutoHeight = false;
            this.but_Del.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.but_Del.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.but_Del.Name = "but_Del";
            this.but_Del.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.but_Del.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.but_Del_ButtonClick);
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
            // GroupBox2
            // 
            this.GroupBox2.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.GroupBox2.Appearance.Options.UseBackColor = true;
            this.GroupBox2.Controls.Add(this.butOK);
            this.GroupBox2.Controls.Add(this.FENDTIME);
            this.GroupBox2.Controls.Add(this.FDepartID);
            this.GroupBox2.Controls.Add(this.FSTARTTIME);
            this.GroupBox2.Controls.Add(this.FProcessname);
            this.GroupBox2.Controls.Add(this.Label50);
            this.GroupBox2.Controls.Add(this.Label8);
            this.GroupBox2.Controls.Add(this.Label60);
            this.GroupBox2.Controls.Add(this.Label7);
            this.GroupBox2.Controls.Add(this.Label6);
            this.GroupBox2.Controls.Add(this.Label4);
            this.GroupBox2.Controls.Add(this.Label5);
            this.GroupBox2.Controls.Add(this.FProcessnum);
            this.GroupBox2.Controls.Add(this.FProcessState);
            this.GroupBox2.Controls.Add(this.FISControl);
            this.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupBox2.Location = new System.Drawing.Point(2, 107);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(892, 213);
            this.GroupBox2.TabIndex = 6;
            this.GroupBox2.Text = "工序计划—表头";
            // 
            // butOK
            // 
            this.butOK.Authorizable = false;
            this.butOK.EnabledEx = true;
            this.butOK.FnNo = 0;
            this.butOK.Hint = "";
            this.butOK.Location = new System.Drawing.Point(919, 60);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(75, 68);
            this.butOK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.butOK.TabIndex = 24;
            this.butOK.Text = "保存";
            this.butOK.ViewMode = EF.ViewModeEnum.Enable;
            // 
            // FENDTIME
            // 
            this.FENDTIME.ColumnName = null;
            this.FENDTIME.Location = new System.Drawing.Point(607, 87);
            this.FENDTIME.Name = "FENDTIME";
            this.FENDTIME.Size = new System.Drawing.Size(265, 22);
            this.FENDTIME.TabIndex = 23;
            // 
            // FDepartID
            // 
            this.FDepartID.ColumnName = null;
            this.FDepartID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FDepartID.EFCname = "";
            this.FDepartID.EFDropDown = false;
            this.FDepartID.FormattingEnabled = true;
            this.FDepartID.Items.AddRange(new object[] {
            "作业区"});
            this.FDepartID.Location = new System.Drawing.Point(93, 137);
            this.FDepartID.Name = "FDepartID";
            this.FDepartID.Size = new System.Drawing.Size(251, 22);
            this.FDepartID.SQL = null;
            this.FDepartID.TabIndex = 22;
            this.FDepartID.UserValue = "";
            // 
            // FSTARTTIME
            // 
            this.FSTARTTIME.ColumnName = null;
            this.FSTARTTIME.Location = new System.Drawing.Point(97, 90);
            this.FSTARTTIME.Name = "FSTARTTIME";
            this.FSTARTTIME.Size = new System.Drawing.Size(247, 22);
            this.FSTARTTIME.TabIndex = 21;
            // 
            // FProcessname
            // 
            this.FProcessname.BackColor = System.Drawing.Color.Transparent;
            this.FProcessname.EFArrange = EF.ArrangeMode.horizontal;
            this.FProcessname.EFCname = "";
            this.FProcessname.EFEname = null;
            this.FProcessname.EFEnterText = "";
            this.FProcessname.EFLeaveExpression = ".*";
            this.FProcessname.EFLen = 32767;
            this.FProcessname.EFType = EF.ValueType.EFString;
            this.FProcessname.EFUpperCase = false;
            this.FProcessname.Location = new System.Drawing.Point(97, 41);
            this.FProcessname.Name = "FProcessname";
            this.FProcessname.ReadOnly = false;
            this.FProcessname.Size = new System.Drawing.Size(247, 22);
            this.FProcessname.TabIndex = 20;
            // 
            // Label50
            // 
            this.Label50.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.Label50.Location = new System.Drawing.Point(524, 140);
            this.Label50.Name = "Label50";
            this.Label50.Size = new System.Drawing.Size(62, 19);
            this.Label50.TabIndex = 19;
            this.Label50.Text = "是否管控";
            // 
            // Label8
            // 
            this.Label8.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.Label8.Location = new System.Drawing.Point(16, 137);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(71, 19);
            this.Label8.TabIndex = 18;
            this.Label8.Text = "承接部门";
            // 
            // Label60
            // 
            this.Label60.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.Label60.Location = new System.Drawing.Point(752, 139);
            this.Label60.Name = "Label60";
            this.Label60.Size = new System.Drawing.Size(42, 22);
            this.Label60.TabIndex = 17;
            this.Label60.Text = "状态";
            // 
            // Label7
            // 
            this.Label7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.Label7.Location = new System.Drawing.Point(524, 90);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(75, 19);
            this.Label7.TabIndex = 16;
            this.Label7.Text = "计划截止时间";
            // 
            // Label6
            // 
            this.Label6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.Label6.Location = new System.Drawing.Point(524, 45);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(75, 19);
            this.Label6.TabIndex = 15;
            this.Label6.Text = "工序计划编码";
            // 
            // Label4
            // 
            this.Label4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.Label4.Location = new System.Drawing.Point(16, 92);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(71, 20);
            this.Label4.TabIndex = 14;
            this.Label4.Text = "计划开始时间";
            // 
            // Label5
            // 
            this.Label5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.Label5.Location = new System.Drawing.Point(16, 40);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(75, 19);
            this.Label5.TabIndex = 10;
            this.Label5.Text = "工序计划名称";
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
            this.FProcessnum.Location = new System.Drawing.Point(607, 45);
            this.FProcessnum.Name = "FProcessnum";
            this.FProcessnum.ReadOnly = false;
            this.FProcessnum.Size = new System.Drawing.Size(265, 22);
            this.FProcessnum.TabIndex = 9;
            // 
            // FProcessState
            // 
            this.FProcessState.ColumnName = null;
            this.FProcessState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FProcessState.EFCname = "";
            this.FProcessState.EFDropDown = false;
            this.FProcessState.FormattingEnabled = true;
            this.FProcessState.Items.AddRange(new object[] {
            "是",
            "否"});
            this.FProcessState.Location = new System.Drawing.Point(814, 140);
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
            this.FISControl.Location = new System.Drawing.Point(607, 139);
            this.FISControl.Name = "FISControl";
            this.FISControl.Size = new System.Drawing.Size(56, 22);
            this.FISControl.SQL = null;
            this.FISControl.TabIndex = 4;
            this.FISControl.UserValue = "";
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
            this.efGroupBox2.Size = new System.Drawing.Size(896, 322);
            this.efGroupBox2.TabIndex = 7;
            // 
            // efGroupBox1
            // 
            this.efGroupBox1.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.efGroupBox1.Appearance.Options.UseBackColor = true;
            this.efGroupBox1.Controls.Add(this.butAdd);
            this.efGroupBox1.Controls.Add(this.SHIP_NO);
            this.efGroupBox1.Controls.Add(this.TREE_NAME);
            this.efGroupBox1.Controls.Add(this.Label2);
            this.efGroupBox1.Controls.Add(this.Label1);
            this.efGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.efGroupBox1.Location = new System.Drawing.Point(2, 23);
            this.efGroupBox1.Name = "efGroupBox1";
            this.efGroupBox1.Size = new System.Drawing.Size(892, 84);
            this.efGroupBox1.TabIndex = 5;
            this.efGroupBox1.Text = "条件选择";
            // 
            // butAdd
            // 
            this.butAdd.Authorizable = false;
            this.butAdd.EnabledEx = true;
            this.butAdd.FnNo = 0;
            this.butAdd.Hint = "";
            this.butAdd.Location = new System.Drawing.Point(797, 41);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(75, 23);
            this.butAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.butAdd.TabIndex = 17;
            this.butAdd.Text = "添加";
            this.butAdd.ViewMode = EF.ViewModeEnum.Enable;
            this.butAdd.Click += new System.EventHandler(this.butAdd_Click);
            // 
            // SHIP_NO
            // 
            this.SHIP_NO.ColumnName = null;
            this.SHIP_NO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SHIP_NO.EFCname = "";
            this.SHIP_NO.EFDropDown = false;
            this.SHIP_NO.FormattingEnabled = true;
            this.SHIP_NO.Location = new System.Drawing.Point(80, 39);
            this.SHIP_NO.Name = "SHIP_NO";
            this.SHIP_NO.Size = new System.Drawing.Size(183, 22);
            this.SHIP_NO.SQL = null;
            this.SHIP_NO.TabIndex = 16;
            this.SHIP_NO.UserValue = "";
            // 
            // TREE_NAME
            // 
            this.TREE_NAME.ColumnName = null;
            this.TREE_NAME.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TREE_NAME.EFCname = "";
            this.TREE_NAME.EFDropDown = false;
            this.TREE_NAME.FormattingEnabled = true;
            this.TREE_NAME.Location = new System.Drawing.Point(335, 41);
            this.TREE_NAME.Name = "TREE_NAME";
            this.TREE_NAME.Size = new System.Drawing.Size(210, 22);
            this.TREE_NAME.SQL = null;
            this.TREE_NAME.TabIndex = 15;
            this.TREE_NAME.UserValue = "";
            // 
            // Label2
            // 
            this.Label2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.Label2.Location = new System.Drawing.Point(285, 39);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(59, 24);
            this.Label2.TabIndex = 9;
            this.Label2.Text = "分段号";
            // 
            // Label1
            // 
            this.Label1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.Label1.Location = new System.Drawing.Point(16, 39);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(62, 24);
            this.Label1.TabIndex = 8;
            this.Label1.Text = "工程号";
            // 
            // FormMCCL0009
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 638);
            this.Controls.Add(this.efGroupBox3);
            this.Controls.Add(this.efGroupBox2);
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "FormMCCL0009";
            this.Text = "工序计划—创建";
            this.EF_DO_F1 += new EF.EFButtonBar.EFDoFnEventHandler(this.FormMCCL0009_EF_DO_F1);
            this.Load += new System.EventHandler(this.FormMCCL0009_Load);
            this.Controls.SetChildIndex(this.efGroupBox2, 0);
            this.Controls.SetChildIndex(this.efGroupBox3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox3)).EndInit();
            this.efGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LU_Depart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_Welds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_Del)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupBox2)).EndInit();
            this.GroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.butOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox2)).EndInit();
            this.efGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox1)).EndInit();
            this.efGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.butAdd)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn CIndexnum;
        private DevExpress.XtraGrid.Columns.GridColumn CSHIP_ID;
        private DevExpress.XtraGrid.Columns.GridColumn CSHIP_NO;
        private DevExpress.XtraGrid.Columns.GridColumn CTREE_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn CFDoDepartID;
        private DevExpress.XtraGrid.Columns.GridColumn CButWeld;
        private DevExpress.XtraGrid.Columns.GridColumn CButDelete;
        private EF.EFGroupBox GroupBox2;
        private EF.EFLabel Label50;
        private EF.EFLabel Label8;
        private EF.EFLabel Label60;
        private EF.EFLabel Label7;
        private EF.EFLabel Label6;
        private EF.EFLabel Label4;
        private EF.EFLabel Label5;
        private EF.EFLabelText FProcessnum;
        private EF.EFComboBox FProcessState;
        private EF.EFComboBox FISControl;
        private EF.EFGroupBox efGroupBox2;
        private EF.EFGroupBox efGroupBox1;
        private EF.EFComboBox TREE_NAME;
        private EF.EFLabel Label2;
        private EF.EFLabel Label1;
        private EF.EFComboBox SHIP_NO;
        private EF.EFButton butAdd;
        private EF.EFLabelText FProcessname;
        private EF.EFDateTimePicker2 FSTARTTIME;
        private EF.EFComboBox FDepartID;
        private EF.EFDateTimePicker2 FENDTIME;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit but_Del;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit LU_Depart;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit but_Welds;
        private EF.EFButton butOK;

    }
}