namespace MC
{
    partial class FormMCCL00016
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
            this.CSHIP_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CTREE_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CBUFF1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CFDoDepartID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CFParentDepartID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CFOPDEPARTID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CAssign = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.SHIP_NO = new EF.EFComboBox(this.components);
            this.butAdd = new EF.EFButton();
            this.FEndDepartIDclass = new EF.EFComboBox(this.components);
            this.Label2 = new EF.EFLabel();
            this.Label1 = new EF.EFLabel();
            this.GroupBox2 = new EF.EFGroupBox(this.components);
            this.Label5 = new EF.EFLabel();
            this.Label3 = new EF.EFLabel();
            this.Label6 = new EF.EFLabel();
            this.Label4 = new EF.EFLabel();
            this.Label21 = new EF.EFLabel();
            this.Label15 = new EF.EFLabel();
            this.Label9 = new EF.EFLabel();
            this.Label8 = new EF.EFLabel();
            this.Label19 = new EF.EFLabel();
            this.BUFF1 = new EF.EFLabelText();
            this.FENDTIME = new EF.EFLabelText();
            this.FProcessnum = new EF.EFLabelText();
            this.FSTARTTIME = new EF.EFLabelText();
            this.FProcessState = new EF.EFComboBox(this.components);
            this.FISControl = new EF.EFComboBox(this.components);
            this.TREE_NAME = new EF.EFComboBox(this.components);
            this.FDoDepartID = new EF.EFComboBox(this.components);
            this.FProcessname = new EF.EFComboBox(this.components);
            this.efGroupBox2 = new EF.EFGroupBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox3)).BeginInit();
            this.efGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox1)).BeginInit();
            this.efGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.butAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupBox2)).BeginInit();
            this.GroupBox2.SuspendLayout();
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
            this.efGroupBox3.Size = new System.Drawing.Size(1050, 306);
            this.efGroupBox3.TabIndex = 6;
            this.efGroupBox3.Text = "派工单- 表体- 焊缝";
            // 
            // dataGrid
            // 
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.Location = new System.Drawing.Point(2, 23);
            this.dataGrid.MainView = this.gridView2;
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.Size = new System.Drawing.Size(1046, 281);
            this.dataGrid.TabIndex = 0;
            this.dataGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2,
            this.gridView1});
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
            this.CbutDelete.CustomizationCaption = "删除";
            this.CbutDelete.Name = "CbutDelete";
            this.CbutDelete.Visible = true;
            this.CbutDelete.VisibleIndex = 0;
            // 
            // CSHIP_NO
            // 
            this.CSHIP_NO.Caption = "工程号";
            this.CSHIP_NO.CustomizationCaption = "工程号";
            this.CSHIP_NO.FieldName = "SHIP_NO";
            this.CSHIP_NO.Name = "CSHIP_NO";
            this.CSHIP_NO.Visible = true;
            this.CSHIP_NO.VisibleIndex = 1;
            // 
            // CTREE_NAME
            // 
            this.CTREE_NAME.Caption = "分段号";
            this.CTREE_NAME.CustomizationCaption = "分段号";
            this.CTREE_NAME.FieldName = "TREE_NAME";
            this.CTREE_NAME.Name = "CTREE_NAME";
            this.CTREE_NAME.Visible = true;
            this.CTREE_NAME.VisibleIndex = 2;
            // 
            // CBUFF1
            // 
            this.CBUFF1.Caption = "阶段";
            this.CBUFF1.CustomizationCaption = "阶段";
            this.CBUFF1.FieldName = "BUFF1";
            this.CBUFF1.Name = "CBUFF1";
            this.CBUFF1.Visible = true;
            this.CBUFF1.VisibleIndex = 3;
            // 
            // CFDoDepartID
            // 
            this.CFDoDepartID.Caption = "部门内码";
            this.CFDoDepartID.CustomizationCaption = "部门内码";
            this.CFDoDepartID.FieldName = "FDoDepartID";
            this.CFDoDepartID.Name = "CFDoDepartID";
            this.CFDoDepartID.Visible = true;
            this.CFDoDepartID.VisibleIndex = 4;
            // 
            // CFParentDepartID
            // 
            this.CFParentDepartID.Caption = "上级部门";
            this.CFParentDepartID.CustomizationCaption = "上级部门";
            this.CFParentDepartID.FieldName = "FParentDepartID";
            this.CFParentDepartID.Name = "CFParentDepartID";
            this.CFParentDepartID.Visible = true;
            this.CFParentDepartID.VisibleIndex = 5;
            // 
            // CFOPDEPARTID
            // 
            this.CFOPDEPARTID.Caption = "承接部门";
            this.CFOPDEPARTID.CustomizationCaption = "承接部门";
            this.CFOPDEPARTID.FieldName = "FOPDEPARTID";
            this.CFOPDEPARTID.Name = "CFOPDEPARTID";
            this.CFOPDEPARTID.Visible = true;
            this.CFOPDEPARTID.VisibleIndex = 6;
            // 
            // CAssign
            // 
            this.CAssign.Caption = "分配焊接";
            this.CAssign.CustomizationCaption = "分配焊接";
            this.CAssign.Name = "CAssign";
            this.CAssign.Visible = true;
            this.CAssign.VisibleIndex = 7;
            // 
            // CFProjectID
            // 
            this.CFProjectID.Caption = "WELDFID";
            this.CFProjectID.FieldName = "FProjectID";
            this.CFProjectID.Name = "CFProjectID";
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
            this.efGroupBox1.Controls.Add(this.SHIP_NO);
            this.efGroupBox1.Controls.Add(this.butAdd);
            this.efGroupBox1.Controls.Add(this.FEndDepartIDclass);
            this.efGroupBox1.Controls.Add(this.Label2);
            this.efGroupBox1.Controls.Add(this.Label1);
            this.efGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.efGroupBox1.Location = new System.Drawing.Point(2, 23);
            this.efGroupBox1.Name = "efGroupBox1";
            this.efGroupBox1.Size = new System.Drawing.Size(1046, 118);
            this.efGroupBox1.TabIndex = 5;
            this.efGroupBox1.Text = "条件选择";
            // 
            // SHIP_NO
            // 
            this.SHIP_NO.ColumnName = null;
            this.SHIP_NO.EFCname = "";
            this.SHIP_NO.EFDropDown = false;
            this.SHIP_NO.FormattingEnabled = true;
            this.SHIP_NO.Location = new System.Drawing.Point(63, 42);
            this.SHIP_NO.Name = "SHIP_NO";
            this.SHIP_NO.Size = new System.Drawing.Size(241, 22);
            this.SHIP_NO.SQL = null;
            this.SHIP_NO.TabIndex = 19;
            this.SHIP_NO.UserValue = "";
            // 
            // butAdd
            // 
            this.butAdd.Authorizable = false;
            this.butAdd.EnabledEx = true;
            this.butAdd.FnNo = 0;
            this.butAdd.Hint = "";
            this.butAdd.Location = new System.Drawing.Point(740, 34);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(91, 30);
            this.butAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.butAdd.TabIndex = 18;
            this.butAdd.Text = "添加";
            this.butAdd.ViewMode = EF.ViewModeEnum.Enable;
            // 
            // FEndDepartIDclass
            // 
            this.FEndDepartIDclass.ColumnName = null;
            this.FEndDepartIDclass.EFCname = "";
            this.FEndDepartIDclass.EFDropDown = false;
            this.FEndDepartIDclass.FormattingEnabled = true;
            this.FEndDepartIDclass.Location = new System.Drawing.Point(417, 44);
            this.FEndDepartIDclass.Name = "FEndDepartIDclass";
            this.FEndDepartIDclass.Size = new System.Drawing.Size(241, 22);
            this.FEndDepartIDclass.SQL = null;
            this.FEndDepartIDclass.TabIndex = 15;
            this.FEndDepartIDclass.UserValue = "";
            // 
            // Label2
            // 
            this.Label2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.Label2.Location = new System.Drawing.Point(341, 40);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(59, 24);
            this.Label2.TabIndex = 9;
            this.Label2.Text = "承接单位";
            // 
            // Label1
            // 
            this.Label1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.Label1.Location = new System.Drawing.Point(10, 38);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(45, 28);
            this.Label1.TabIndex = 8;
            this.Label1.Text = "工程号";
            // 
            // GroupBox2
            // 
            this.GroupBox2.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.GroupBox2.Appearance.Options.UseBackColor = true;
            this.GroupBox2.Controls.Add(this.Label5);
            this.GroupBox2.Controls.Add(this.Label3);
            this.GroupBox2.Controls.Add(this.Label6);
            this.GroupBox2.Controls.Add(this.Label4);
            this.GroupBox2.Controls.Add(this.Label21);
            this.GroupBox2.Controls.Add(this.Label15);
            this.GroupBox2.Controls.Add(this.Label9);
            this.GroupBox2.Controls.Add(this.Label8);
            this.GroupBox2.Controls.Add(this.Label19);
            this.GroupBox2.Controls.Add(this.BUFF1);
            this.GroupBox2.Controls.Add(this.FENDTIME);
            this.GroupBox2.Controls.Add(this.FProcessnum);
            this.GroupBox2.Controls.Add(this.FSTARTTIME);
            this.GroupBox2.Controls.Add(this.FProcessState);
            this.GroupBox2.Controls.Add(this.FISControl);
            this.GroupBox2.Controls.Add(this.TREE_NAME);
            this.GroupBox2.Controls.Add(this.FDoDepartID);
            this.GroupBox2.Controls.Add(this.FProcessname);
            this.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupBox2.Location = new System.Drawing.Point(2, 141);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(1046, 179);
            this.GroupBox2.TabIndex = 6;
            this.GroupBox2.Text = "工序计划";
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
            // Label21
            // 
            this.Label21.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.Label21.Location = new System.Drawing.Point(273, 90);
            this.Label21.Name = "Label21";
            this.Label21.Size = new System.Drawing.Size(75, 19);
            this.Label21.TabIndex = 15;
            this.Label21.Text = "工序计划编码";
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
            // Label19
            // 
            this.Label19.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.Label19.Location = new System.Drawing.Point(16, 40);
            this.Label19.Name = "Label19";
            this.Label19.Size = new System.Drawing.Size(75, 19);
            this.Label19.TabIndex = 10;
            this.Label19.Text = "工序计划名称";
            // 
            // BUFF1
            // 
            this.BUFF1.BackColor = System.Drawing.Color.Transparent;
            this.BUFF1.EFArrange = EF.ArrangeMode.horizontal;
            this.BUFF1.EFCname = "";
            this.BUFF1.EFEname = null;
            this.BUFF1.EFEnterText = "";
            this.BUFF1.EFLeaveExpression = ".*";
            this.BUFF1.EFLen = 32767;
            this.BUFF1.EFType = EF.ValueType.EFString;
            this.BUFF1.EFUpperCase = false;
            this.BUFF1.Location = new System.Drawing.Point(833, 37);
            this.BUFF1.Name = "BUFF1";
            this.BUFF1.ReadOnly = false;
            this.BUFF1.Size = new System.Drawing.Size(179, 22);
            this.BUFF1.TabIndex = 9;
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
            this.FENDTIME.ReadOnly = false;
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
            this.FProcessnum.ReadOnly = false;
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
            this.FSTARTTIME.ReadOnly = false;
            this.FSTARTTIME.Size = new System.Drawing.Size(144, 22);
            this.FSTARTTIME.TabIndex = 6;
            // 
            // FProcessState
            // 
            this.FProcessState.ColumnName = null;
            this.FProcessState.EFCname = "";
            this.FProcessState.EFDropDown = false;
            this.FProcessState.FormattingEnabled = true;
            this.FProcessState.Items.AddRange(new object[] {
            "是",
            "否"});
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
            // FDoDepartID
            // 
            this.FDoDepartID.ColumnName = null;
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
            this.efGroupBox2.Size = new System.Drawing.Size(1050, 322);
            this.efGroupBox2.TabIndex = 7;
            // 
            // FormMCCL00016
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 674);
            this.Controls.Add(this.efGroupBox3);
            this.Controls.Add(this.efGroupBox2);
            this.Name = "FormMCCL00016";
            this.Text = "工序计划—创建";
            this.Load += new System.EventHandler(this.FormMCCL00016_Load);
            this.Controls.SetChildIndex(this.efGroupBox2, 0);
            this.Controls.SetChildIndex(this.efGroupBox3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox3)).EndInit();
            this.efGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox1)).EndInit();
            this.efGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.butAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupBox2)).EndInit();
            this.GroupBox2.ResumeLayout(false);
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
        private EF.EFComboBox FEndDepartIDclass;
        private EF.EFLabel Label2;
        private EF.EFLabel Label1;
        private EF.EFGroupBox GroupBox2;
        private EF.EFLabel Label5;
        private EF.EFLabel Label3;
        private EF.EFLabel Label6;
        private EF.EFLabel Label4;
        private EF.EFLabel Label21;
        private EF.EFLabel Label15;
        private EF.EFLabel Label9;
        private EF.EFLabel Label8;
        private EF.EFLabel Label19;
        private EF.EFLabelText BUFF1;
        private EF.EFLabelText FENDTIME;
        private EF.EFLabelText FProcessnum;
        private EF.EFLabelText FSTARTTIME;
        private EF.EFComboBox FProcessState;
        private EF.EFComboBox FISControl;
        private EF.EFComboBox TREE_NAME;
        private EF.EFComboBox FDoDepartID;
        private EF.EFComboBox FProcessname;
        private EF.EFGroupBox efGroupBox2;
        private DevExpress.XtraGrid.Columns.GridColumn CFProjectID;
        private EF.EFButton butAdd;
        private EF.EFComboBox SHIP_NO;

    }
}