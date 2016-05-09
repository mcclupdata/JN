namespace MC
{
    partial class FormMCCL00022
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMCCL00022));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("hgg", "焊机1.jpg");
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            this.efGroupBox1 = new EF.EFGroupBox(this.components);
            this.Read = new EF.EFButton();
            this.axReadCard1 = new AxReadCardInfo.AxReadCard();
            this.butCancel = new EF.EFButton();
            this.Fnum = new EF.EFTextBox();
            this.efLabel2 = new EF.EFLabel();
            this.button1 = new EF.EFButton();
            this.efLabel1 = new EF.EFLabel();
            this.FSTARTTIME = new EF.EFDateTimePicker2();
            this.FDepartName = new EF.EFLabelText();
            this.FName = new EF.EFLabelText();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.efGroupBox2 = new EF.EFGroupBox(this.components);
            this.showAllWelds = new EF.EFCheckBox();
            this.Control1 = new EF.EFTabControl(this.components);
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGrid = new EF.EFDevGrid();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CFID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CChecked = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemCheck = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.CWELD_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CPART1_NAME2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CPART2_NAME2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CWELD_PASS_ATTRIB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CWELD_MOD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CWELD_T_LEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CWELD_POS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CFSTATE_DES = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CBUTBEGIN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.but_Start = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.CPUASE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.but_End = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.CBUTEND = new DevExpress.XtraGrid.Columns.GridColumn();
            this.but_Pause = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.CFSTATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FNewName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.welderDrvs = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.ReadCardTimer = new System.Windows.Forms.Timer(this.components);
            this.efButton1 = new EF.EFButton();
            this.CBUTCHANGE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.but_Change = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox1)).BeginInit();
            this.efGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Read)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axReadCard1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.butCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.button1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox2)).BeginInit();
            this.efGroupBox2.SuspendLayout();
            this.Control1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_Start)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_End)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_Pause)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.efButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_Change)).BeginInit();
            this.SuspendLayout();
            // 
            // efGroupBox1
            // 
            this.efGroupBox1.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.efGroupBox1.Appearance.Options.UseBackColor = true;
            this.efGroupBox1.Controls.Add(this.Read);
            this.efGroupBox1.Controls.Add(this.axReadCard1);
            this.efGroupBox1.Controls.Add(this.butCancel);
            this.efGroupBox1.Controls.Add(this.Fnum);
            this.efGroupBox1.Controls.Add(this.efLabel2);
            this.efGroupBox1.Controls.Add(this.button1);
            this.efGroupBox1.Controls.Add(this.efLabel1);
            this.efGroupBox1.Controls.Add(this.FSTARTTIME);
            this.efGroupBox1.Controls.Add(this.FDepartName);
            this.efGroupBox1.Controls.Add(this.FName);
            this.efGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.efGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.efGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.efGroupBox1.Name = "efGroupBox1";
            this.efGroupBox1.Size = new System.Drawing.Size(1647, 102);
            this.efGroupBox1.TabIndex = 5;
            this.efGroupBox1.Text = "刷卡区";
            // 
            // Read
            // 
            this.Read.Authorizable = false;
            this.Read.EnabledEx = true;
            this.Read.FnNo = 0;
            this.Read.Hint = "";
            this.Read.Location = new System.Drawing.Point(1091, 47);
            this.Read.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Read.Name = "Read";
            this.Read.Size = new System.Drawing.Size(107, 39);
            this.Read.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Read.TabIndex = 10;
            this.Read.Text = "读卡";
            this.Read.ViewMode = EF.ViewModeEnum.Enable;
            this.Read.Click += new System.EventHandler(this.Read_Click);
            // 
            // axReadCard1
            // 
            this.axReadCard1.Enabled = true;
            this.axReadCard1.Location = new System.Drawing.Point(1037, 11);
            this.axReadCard1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.axReadCard1.Name = "axReadCard1";
            this.axReadCard1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axReadCard1.OcxState")));
            this.axReadCard1.Size = new System.Drawing.Size(120, 72);
            this.axReadCard1.TabIndex = 9;
            this.axReadCard1.Visible = false;
            // 
            // butCancel
            // 
            this.butCancel.Authorizable = false;
            this.butCancel.EnabledEx = true;
            this.butCancel.FnNo = 0;
            this.butCancel.Hint = "";
            this.butCancel.Location = new System.Drawing.Point(1366, 47);
            this.butCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(107, 39);
            this.butCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.butCancel.TabIndex = 8;
            this.butCancel.Text = "取消";
            this.butCancel.ViewMode = EF.ViewModeEnum.Enable;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // Fnum
            // 
            this.Fnum.EFEname = null;
            this.Fnum.EFLeaveExpression = ".*";
            this.Fnum.EFLen = 32767;
            this.Fnum.Location = new System.Drawing.Point(67, 42);
            this.Fnum.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Fnum.Name = "Fnum";
            this.Fnum.Size = new System.Drawing.Size(168, 29);
            this.Fnum.TabIndex = 7;
            this.Fnum.TextChanged += new System.EventHandler(this.Fnum_TextChanged);
            // 
            // efLabel2
            // 
            this.efLabel2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.efLabel2.Location = new System.Drawing.Point(13, 47);
            this.efLabel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.efLabel2.Name = "efLabel2";
            this.efLabel2.Size = new System.Drawing.Size(46, 28);
            this.efLabel2.TabIndex = 6;
            this.efLabel2.Text = "工号";
            // 
            // button1
            // 
            this.button1.Authorizable = false;
            this.button1.EnabledEx = true;
            this.button1.FnNo = 0;
            this.button1.Hint = "";
            this.button1.Location = new System.Drawing.Point(1233, 47);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 39);
            this.button1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.button1.TabIndex = 5;
            this.button1.Text = "刷新";
            this.button1.ViewMode = EF.ViewModeEnum.Enable;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // efLabel1
            // 
            this.efLabel1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.efLabel1.Location = new System.Drawing.Point(723, 55);
            this.efLabel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.efLabel1.Name = "efLabel1";
            this.efLabel1.Size = new System.Drawing.Size(89, 22);
            this.efLabel1.TabIndex = 4;
            this.efLabel1.Text = "当前时间";
            // 
            // FSTARTTIME
            // 
            this.FSTARTTIME.ColumnName = null;
            this.FSTARTTIME.Location = new System.Drawing.Point(820, 52);
            this.FSTARTTIME.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FSTARTTIME.Name = "FSTARTTIME";
            this.FSTARTTIME.Size = new System.Drawing.Size(224, 29);
            this.FSTARTTIME.TabIndex = 3;
            this.FSTARTTIME.ValueChanged += new System.EventHandler(this.FSTARTTIME_ValueChanged);
            // 
            // FDepartName
            // 
            this.FDepartName.BackColor = System.Drawing.Color.Transparent;
            this.FDepartName.EFArrange = EF.ArrangeMode.horizontal;
            this.FDepartName.EFCname = "部门";
            this.FDepartName.EFEname = null;
            this.FDepartName.EFEnterText = "";
            this.FDepartName.EFLeaveExpression = ".*";
            this.FDepartName.EFLen = 32767;
            this.FDepartName.EFType = EF.ValueType.EFString;
            this.FDepartName.EFUpperCase = false;
            this.FDepartName.Location = new System.Drawing.Point(484, 47);
            this.FDepartName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FDepartName.Name = "FDepartName";
            this.FDepartName.ReadOnly = true;
            this.FDepartName.Size = new System.Drawing.Size(230, 30);
            this.FDepartName.TabIndex = 2;
            // 
            // FName
            // 
            this.FName.BackColor = System.Drawing.Color.Transparent;
            this.FName.EFArrange = EF.ArrangeMode.horizontal;
            this.FName.EFCname = "姓名";
            this.FName.EFEname = null;
            this.FName.EFEnterText = "";
            this.FName.EFLeaveExpression = ".*";
            this.FName.EFLen = 32767;
            this.FName.EFType = EF.ValueType.EFString;
            this.FName.EFUpperCase = false;
            this.FName.Location = new System.Drawing.Point(259, 47);
            this.FName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FName.Name = "FName";
            this.FName.ReadOnly = true;
            this.FName.Size = new System.Drawing.Size(217, 30);
            this.FName.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "焊机1.jpg");
            this.imageList1.Images.SetKeyName(1, "焊机2.jpg");
            // 
            // efGroupBox2
            // 
            this.efGroupBox2.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.efGroupBox2.Appearance.Options.UseBackColor = true;
            this.efGroupBox2.Controls.Add(this.showAllWelds);
            this.efGroupBox2.Controls.Add(this.Control1);
            this.efGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.efGroupBox2.Location = new System.Drawing.Point(0, 102);
            this.efGroupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.efGroupBox2.Name = "efGroupBox2";
            this.efGroupBox2.Size = new System.Drawing.Size(1647, 824);
            this.efGroupBox2.TabIndex = 6;
            this.efGroupBox2.Text = "任务区";
            // 
            // showAllWelds
            // 
            this.showAllWelds.AutoSize = true;
            this.showAllWelds.BackColor = System.Drawing.Color.Transparent;
            this.showAllWelds.Location = new System.Drawing.Point(1490, 35);
            this.showAllWelds.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.showAllWelds.Name = "showAllWelds";
            this.showAllWelds.Size = new System.Drawing.Size(144, 26);
            this.showAllWelds.TabIndex = 2;
            this.showAllWelds.Text = "显示全部焊机";
            this.showAllWelds.UseVisualStyleBackColor = true;
            this.showAllWelds.CheckedChanged += new System.EventHandler(this.showAllWelds_CheckedChanged);
            // 
            // Control1
            // 
            this.Control1.Controls.Add(this.tabPage1);
            this.Control1.Controls.Add(this.tabPage2);
            this.Control1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Control1.Location = new System.Drawing.Point(2, 30);
            this.Control1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Control1.Name = "Control1";
            this.Control1.SelectedIndex = 0;
            this.Control1.Size = new System.Drawing.Size(1643, 792);
            this.Control1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGrid);
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Size = new System.Drawing.Size(1635, 757);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "选择任务";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGrid
            // 
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.Location = new System.Drawing.Point(4, 5);
            this.dataGrid.MainView = this.gridView1;
            this.dataGrid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.but_Start,
            this.but_Pause,
            this.but_End,
            this.ItemCheck,
            this.but_Change});
            this.dataGrid.Size = new System.Drawing.Size(1627, 747);
            this.dataGrid.TabIndex = 1;
            this.dataGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.CFID,
            this.CChecked,
            this.CWELD_NO,
            this.CPART1_NAME2,
            this.CPART2_NAME2,
            this.CWELD_PASS_ATTRIB,
            this.CWELD_MOD,
            this.CWELD_T_LEN,
            this.CWELD_POS,
            this.CFSTATE_DES,
            this.CBUTBEGIN,
            this.CPUASE,
            this.CBUTCHANGE,
            this.CBUTEND,
            this.CFSTATE,
            this.FNewName});
            this.gridView1.FixedLineWidth = 1;
            this.gridView1.GridControl = this.dataGrid;
            this.gridView1.IndicatorWidth = 35;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // CFID
            // 
            this.CFID.Caption = "CFID";
            this.CFID.FieldName = "CFID";
            this.CFID.Name = "CFID";
            this.CFID.OptionsColumn.AllowEdit = false;
            // 
            // CChecked
            // 
            this.CChecked.Caption = "选择";
            this.CChecked.ColumnEdit = this.ItemCheck;
            this.CChecked.FieldName = "FChecked";
            this.CChecked.Name = "CChecked";
            this.CChecked.Visible = true;
            this.CChecked.VisibleIndex = 0;
            // 
            // ItemCheck
            // 
            this.ItemCheck.AutoHeight = false;
            this.ItemCheck.DisplayValueChecked = "已选";
            this.ItemCheck.DisplayValueUnchecked = "未选";
            this.ItemCheck.Name = "ItemCheck";
            this.ItemCheck.ValueChecked = 1;
            this.ItemCheck.ValueUnchecked = 0;
            this.ItemCheck.EditValueChanged += new System.EventHandler(this.ItemCheck_EditValueChanged);
            // 
            // CWELD_NO
            // 
            this.CWELD_NO.Caption = "焊缝编号";
            this.CWELD_NO.FieldName = "WELD_NO";
            this.CWELD_NO.Name = "CWELD_NO";
            this.CWELD_NO.OptionsColumn.AllowEdit = false;
            this.CWELD_NO.Visible = true;
            this.CWELD_NO.VisibleIndex = 2;
            this.CWELD_NO.Width = 174;
            // 
            // CPART1_NAME2
            // 
            this.CPART1_NAME2.Caption = "零件名1";
            this.CPART1_NAME2.FieldName = "PART1_NAME2";
            this.CPART1_NAME2.Name = "CPART1_NAME2";
            this.CPART1_NAME2.OptionsColumn.AllowEdit = false;
            this.CPART1_NAME2.Visible = true;
            this.CPART1_NAME2.VisibleIndex = 3;
            this.CPART1_NAME2.Width = 160;
            // 
            // CPART2_NAME2
            // 
            this.CPART2_NAME2.Caption = "零件名2";
            this.CPART2_NAME2.FieldName = "PART2_NAME2";
            this.CPART2_NAME2.Name = "CPART2_NAME2";
            this.CPART2_NAME2.OptionsColumn.AllowEdit = false;
            this.CPART2_NAME2.Visible = true;
            this.CPART2_NAME2.VisibleIndex = 4;
            this.CPART2_NAME2.Width = 142;
            // 
            // CWELD_PASS_ATTRIB
            // 
            this.CWELD_PASS_ATTRIB.Caption = "焊道属性";
            this.CWELD_PASS_ATTRIB.FieldName = "WELD_PASS_ATTRIB";
            this.CWELD_PASS_ATTRIB.Name = "CWELD_PASS_ATTRIB";
            this.CWELD_PASS_ATTRIB.OptionsColumn.AllowEdit = false;
            this.CWELD_PASS_ATTRIB.Visible = true;
            this.CWELD_PASS_ATTRIB.VisibleIndex = 5;
            this.CWELD_PASS_ATTRIB.Width = 181;
            // 
            // CWELD_MOD
            // 
            this.CWELD_MOD.Caption = "焊接方法";
            this.CWELD_MOD.Name = "CWELD_MOD";
            this.CWELD_MOD.OptionsColumn.AllowEdit = false;
            this.CWELD_MOD.Visible = true;
            this.CWELD_MOD.VisibleIndex = 7;
            // 
            // CWELD_T_LEN
            // 
            this.CWELD_T_LEN.Caption = "长度";
            this.CWELD_T_LEN.FieldName = "WELD_T_LEN";
            this.CWELD_T_LEN.Name = "CWELD_T_LEN";
            this.CWELD_T_LEN.OptionsColumn.AllowEdit = false;
            this.CWELD_T_LEN.Visible = true;
            this.CWELD_T_LEN.VisibleIndex = 6;
            this.CWELD_T_LEN.Width = 186;
            // 
            // CWELD_POS
            // 
            this.CWELD_POS.Caption = "焊接位置";
            this.CWELD_POS.FieldName = "WELD_POS";
            this.CWELD_POS.Name = "CWELD_POS";
            this.CWELD_POS.OptionsColumn.AllowEdit = false;
            this.CWELD_POS.Visible = true;
            this.CWELD_POS.VisibleIndex = 9;
            // 
            // CFSTATE_DES
            // 
            this.CFSTATE_DES.Caption = "状态";
            this.CFSTATE_DES.FieldName = "FSTATE_DES";
            this.CFSTATE_DES.Name = "CFSTATE_DES";
            this.CFSTATE_DES.OptionsColumn.AllowEdit = false;
            this.CFSTATE_DES.Visible = true;
            this.CFSTATE_DES.VisibleIndex = 8;
            // 
            // CBUTBEGIN
            // 
            this.CBUTBEGIN.Caption = "开始";
            this.CBUTBEGIN.ColumnEdit = this.but_Start;
            this.CBUTBEGIN.CustomizationCaption = "开始";
            this.CBUTBEGIN.FieldName = "CBUTBEGIN";
            this.CBUTBEGIN.Name = "CBUTBEGIN";
            this.CBUTBEGIN.Visible = true;
            this.CBUTBEGIN.VisibleIndex = 10;
            // 
            // but_Start
            // 
            this.but_Start.AutoHeight = false;
            this.but_Start.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "开始", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.but_Start.Name = "but_Start";
            this.but_Start.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.but_Start.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.dataGrid_CellContentClick);
            // 
            // CPUASE
            // 
            this.CPUASE.Caption = "挂起";
            this.CPUASE.ColumnEdit = this.but_End;
            this.CPUASE.CustomizationCaption = "挂起";
            this.CPUASE.FieldName = "CPUASE";
            this.CPUASE.Name = "CPUASE";
            this.CPUASE.Visible = true;
            this.CPUASE.VisibleIndex = 11;
            // 
            // but_End
            // 
            this.but_End.AutoHeight = false;
            this.but_End.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "完成", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.but_End.Name = "but_End";
            this.but_End.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.but_End.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.dataGrid_CellContentClick);
            // 
            // CBUTEND
            // 
            this.CBUTEND.Caption = "完成";
            this.CBUTEND.ColumnEdit = this.but_Pause;
            this.CBUTEND.FieldName = "CBUTEND";
            this.CBUTEND.Name = "CBUTEND";
            this.CBUTEND.Visible = true;
            this.CBUTEND.VisibleIndex = 13;
            // 
            // but_Pause
            // 
            this.but_Pause.AutoHeight = false;
            this.but_Pause.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "挂起", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "", null, null, true)});
            this.but_Pause.Name = "but_Pause";
            this.but_Pause.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.but_Pause.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.dataGrid_CellContentClick);
            // 
            // CFSTATE
            // 
            this.CFSTATE.Caption = "CFSTATE";
            this.CFSTATE.FieldName = "FSTATE";
            this.CFSTATE.Name = "CFSTATE";
            this.CFSTATE.OptionsColumn.AllowEdit = false;
            // 
            // FNewName
            // 
            this.FNewName.Caption = "合并焊缝名称";
            this.FNewName.FieldName = "FNewName";
            this.FNewName.Name = "FNewName";
            this.FNewName.Visible = true;
            this.FNewName.VisibleIndex = 1;
            this.FNewName.Width = 166;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.welderDrvs);
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Size = new System.Drawing.Size(1633, 738);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "选择焊机";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // welderDrvs
            // 
            this.welderDrvs.BackColor = System.Drawing.SystemColors.Info;
            this.welderDrvs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.welderDrvs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.welderDrvs.GridLines = true;
            listViewGroup1.Header = "ListViewGroup";
            listViewGroup1.Name = "listViewGroup1";
            this.welderDrvs.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
            listViewItem1.Group = listViewGroup1;
            listViewItem1.StateImageIndex = 0;
            this.welderDrvs.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.welderDrvs.LargeImageList = this.imageList1;
            this.welderDrvs.Location = new System.Drawing.Point(4, 5);
            this.welderDrvs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.welderDrvs.Name = "welderDrvs";
            this.welderDrvs.Size = new System.Drawing.Size(1625, 728);
            this.welderDrvs.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.welderDrvs.TabIndex = 0;
            this.welderDrvs.UseCompatibleStateImageBehavior = false;
            this.welderDrvs.Click += new System.EventHandler(this.welderDrvs_Click);
            // 
            // ReadCardTimer
            // 
            this.ReadCardTimer.Tick += new System.EventHandler(this.ReadCardTimer_Tick);
            // 
            // efButton1
            // 
            this.efButton1.Authorizable = false;
            this.efButton1.EnabledEx = true;
            this.efButton1.FnNo = 0;
            this.efButton1.Hint = "";
            this.efButton1.Location = new System.Drawing.Point(943, 30);
            this.efButton1.Name = "efButton1";
            this.efButton1.Size = new System.Drawing.Size(75, 43);
            this.efButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.efButton1.TabIndex = 9;
            this.efButton1.Text = "自动读卡";
            this.efButton1.ViewMode = EF.ViewModeEnum.Enable;
            this.efButton1.Click += new System.EventHandler(this.efButton1_Click);
            // 
            // CBUTCHANGE
            // 
            this.CBUTCHANGE.Caption = "切换焊机";
            this.CBUTCHANGE.ColumnEdit = this.but_Change;
            this.CBUTCHANGE.FieldName = "CBUTCHANGE";
            this.CBUTCHANGE.Name = "CBUTCHANGE";
            this.CBUTCHANGE.Visible = true;
            this.CBUTCHANGE.VisibleIndex = 12;
            // 
            // but_Change
            // 
            this.but_Change.AutoHeight = false;
            this.but_Change.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "切换焊机", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "", null, null, true)});
            this.but_Change.Name = "but_Change";
            this.but_Change.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // FormMCCL00022
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1647, 998);
            this.Controls.Add(this.efGroupBox2);
            this.Controls.Add(this.efGroupBox1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.EFMsgInfo = "执行 F1 操作";
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormMCCL00022";
            this.Text = "焊工领取任务端";
            this.EF_DO_F1 += new EF.EFButtonBar.EFDoFnEventHandler(this.FormMCCL00022_EF_DO_F1);
            this.Load += new System.EventHandler(this.frmWelderClient_Load);
            this.Controls.SetChildIndex(this.efGroupBox1, 0);
            this.Controls.SetChildIndex(this.efGroupBox2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox1)).EndInit();
            this.efGroupBox1.ResumeLayout(false);
            this.efGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Read)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axReadCard1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.butCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.button1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox2)).EndInit();
            this.efGroupBox2.ResumeLayout(false);
            this.efGroupBox2.PerformLayout();
            this.Control1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_Start)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_End)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_Pause)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.efButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_Change)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private EF.EFGroupBox efGroupBox1;
        private EF.EFLabelText FName;
        private EF.EFButton button1;
        private EF.EFLabel efLabel1;
        private EF.EFDateTimePicker2 FSTARTTIME;
        private EF.EFLabelText FDepartName;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ImageList imageList1;
        private EF.EFGroupBox efGroupBox2;
        private EF.EFTabControl Control1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private EF.EFDevGrid dataGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn CFID;
        private System.Windows.Forms.ListView welderDrvs;
        private DevExpress.XtraGrid.Columns.GridColumn CWELD_NO;
        private DevExpress.XtraGrid.Columns.GridColumn CPART1_NAME2;
        private DevExpress.XtraGrid.Columns.GridColumn CPART2_NAME2;
        private DevExpress.XtraGrid.Columns.GridColumn CWELD_PASS_ATTRIB;
        private DevExpress.XtraGrid.Columns.GridColumn CWELD_T_LEN;
        private DevExpress.XtraGrid.Columns.GridColumn CFSTATE_DES;
        private DevExpress.XtraGrid.Columns.GridColumn CBUTBEGIN;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit but_Start;
        private DevExpress.XtraGrid.Columns.GridColumn CPUASE;
        private DevExpress.XtraGrid.Columns.GridColumn CBUTEND;
        private DevExpress.XtraGrid.Columns.GridColumn CWELD_MOD;
        private DevExpress.XtraGrid.Columns.GridColumn CWELD_POS;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit but_End;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit but_Pause;
        private DevExpress.XtraGrid.Columns.GridColumn CFSTATE;
        private EF.EFTextBox Fnum;
        private EF.EFLabel efLabel2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;

        private System.Windows.Forms.Timer ReadCardTimer;
        private EF.EFButton efButton1;
        private DevExpress.XtraGrid.Columns.GridColumn CChecked;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ItemCheck;
        private DevExpress.XtraGrid.Columns.GridColumn FNewName;
        private EF.EFButton butCancel;
        private AxReadCardInfo.AxReadCard axReadCard1;
        private EF.EFButton Read;
        private EF.EFCheckBox showAllWelds;
        private DevExpress.XtraGrid.Columns.GridColumn CBUTCHANGE;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit but_Change;


    }
}