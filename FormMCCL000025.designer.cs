namespace MC
{
    partial class FormMCCL00025
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("焊机001");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("班组一", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("焊机总成", new System.Windows.Forms.TreeNode[] {
            treeNode2});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMCCL00025));
            this.efGroupBox1 = new EF.EFGroupBox(this.components);
            this.efPanelStyleXP2 = new EF.EFPanelStyleXP();
            this.efPanelStyleXP4 = new EF.EFPanelStyleXP();
            this.dataGrid = new EF.EFDevGrid();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.efPanelStyleXP3 = new EF.EFPanelStyleXP();
            this.efPanelStyleXP6 = new EF.EFPanelStyleXP();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.efPanelStyleXP5 = new EF.EFPanelStyleXP();
            this.efGroupBox3 = new EF.EFGroupBox(this.components);
            this.mt = new EF.EFTextBox();
            this.efLabel7 = new EF.EFLabel();
            this.wp = new EF.EFTextBox();
            this.rpm = new EF.EFTextBox();
            this.efLabel5 = new EF.EFLabel();
            this.efLabel6 = new EF.EFLabel();
            this.wv = new EF.EFTextBox();
            this.wa = new EF.EFTextBox();
            this.efLabel3 = new EF.EFLabel();
            this.efLabel4 = new EF.EFLabel();
            this.efGroupBox2 = new EF.EFGroupBox(this.components);
            this.state = new EF.EFTextBox();
            this.lab = new EF.EFLabel();
            this.vv = new EF.EFTextBox();
            this.va = new EF.EFTextBox();
            this.efLabel2 = new EF.EFLabel();
            this.efLabel1 = new EF.EFLabel();
            this.efPanelStyleXP1 = new EF.EFPanelStyleXP();
            this.weldEquipList = new EF.EFTreeView(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Timer_ZED = new System.Windows.Forms.Timer(this.components);
            this.Timer_Equip = new System.Windows.Forms.Timer(this.components);
            this.Timer_Task = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox1)).BeginInit();
            this.efGroupBox1.SuspendLayout();
            this.efPanelStyleXP2.SuspendLayout();
            this.efPanelStyleXP4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.efPanelStyleXP3.SuspendLayout();
            this.efPanelStyleXP6.SuspendLayout();
            this.efPanelStyleXP5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox3)).BeginInit();
            this.efGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox2)).BeginInit();
            this.efGroupBox2.SuspendLayout();
            this.efPanelStyleXP1.SuspendLayout();
            this.SuspendLayout();
            // 
            // efGroupBox1
            // 
            this.efGroupBox1.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.efGroupBox1.Appearance.Options.UseBackColor = true;
            this.efGroupBox1.Controls.Add(this.efPanelStyleXP2);
            this.efGroupBox1.Controls.Add(this.efPanelStyleXP1);
            this.efGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.efGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.efGroupBox1.Name = "efGroupBox1";
            this.efGroupBox1.Size = new System.Drawing.Size(896, 398);
            this.efGroupBox1.TabIndex = 4;
            this.efGroupBox1.Text = "焊机监控";
            this.efGroupBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.efGroupBox1_Paint);
            // 
            // efPanelStyleXP2
            // 
            this.efPanelStyleXP2.Controls.Add(this.efPanelStyleXP4);
            this.efPanelStyleXP2.Controls.Add(this.efPanelStyleXP3);
            this.efPanelStyleXP2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.efPanelStyleXP2.Location = new System.Drawing.Point(377, 23);
            this.efPanelStyleXP2.Margin = new System.Windows.Forms.Padding(2);
            this.efPanelStyleXP2.Name = "efPanelStyleXP2";
            this.efPanelStyleXP2.Size = new System.Drawing.Size(517, 373);
            this.efPanelStyleXP2.TabIndex = 1;
            this.efPanelStyleXP2.Paint += new System.Windows.Forms.PaintEventHandler(this.efPanelStyleXP2_Paint);
            // 
            // efPanelStyleXP4
            // 
            this.efPanelStyleXP4.Controls.Add(this.dataGrid);
            this.efPanelStyleXP4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.efPanelStyleXP4.Location = new System.Drawing.Point(0, 270);
            this.efPanelStyleXP4.Margin = new System.Windows.Forms.Padding(2);
            this.efPanelStyleXP4.Name = "efPanelStyleXP4";
            this.efPanelStyleXP4.Size = new System.Drawing.Size(517, 103);
            this.efPanelStyleXP4.TabIndex = 1;
            // 
            // dataGrid
            // 
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.Location = new System.Drawing.Point(0, 0);
            this.dataGrid.MainView = this.gridView1;
            this.dataGrid.Margin = new System.Windows.Forms.Padding(2);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.Size = new System.Drawing.Size(517, 103);
            this.dataGrid.TabIndex = 0;
            this.dataGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn8,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn5});
            this.gridView1.FixedLineWidth = 1;
            this.gridView1.GridControl = this.dataGrid;
            this.gridView1.IndicatorWidth = 35;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "开始时间";
            this.gridColumn1.FieldName = "FSTARTTIME";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "结束时间";
            this.gridColumn2.FieldName = "FENDTIME";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "部门";
            this.gridColumn8.FieldName = "FDepartName";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "操作者工号";
            this.gridColumn3.FieldName = "Fnum";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "操作者";
            this.gridColumn4.FieldName = "FName";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "部件1";
            this.gridColumn6.FieldName = "PART1_NAME2";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "部件2";
            this.gridColumn7.FieldName = "PART1_NAME2";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "焊缝长度";
            this.gridColumn5.FieldName = "WELD_T_LEN";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // efPanelStyleXP3
            // 
            this.efPanelStyleXP3.Controls.Add(this.efPanelStyleXP6);
            this.efPanelStyleXP3.Controls.Add(this.efPanelStyleXP5);
            this.efPanelStyleXP3.Dock = System.Windows.Forms.DockStyle.Top;
            this.efPanelStyleXP3.Location = new System.Drawing.Point(0, 0);
            this.efPanelStyleXP3.Margin = new System.Windows.Forms.Padding(2);
            this.efPanelStyleXP3.Name = "efPanelStyleXP3";
            this.efPanelStyleXP3.Size = new System.Drawing.Size(517, 270);
            this.efPanelStyleXP3.TabIndex = 0;
            // 
            // efPanelStyleXP6
            // 
            this.efPanelStyleXP6.Controls.Add(this.zedGraphControl1);
            this.efPanelStyleXP6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.efPanelStyleXP6.Location = new System.Drawing.Point(313, 0);
            this.efPanelStyleXP6.Margin = new System.Windows.Forms.Padding(2);
            this.efPanelStyleXP6.Name = "efPanelStyleXP6";
            this.efPanelStyleXP6.Size = new System.Drawing.Size(204, 270);
            this.efPanelStyleXP6.TabIndex = 1;
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.EditButtons = System.Windows.Forms.MouseButtons.Left;
            this.zedGraphControl1.EditModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.zedGraphControl1.IsAutoScrollRange = false;
            this.zedGraphControl1.IsEnableHEdit = false;
            this.zedGraphControl1.IsEnableHPan = true;
            this.zedGraphControl1.IsEnableHZoom = true;
            this.zedGraphControl1.IsEnableVEdit = false;
            this.zedGraphControl1.IsEnableVPan = true;
            this.zedGraphControl1.IsEnableVZoom = true;
            this.zedGraphControl1.IsPrintFillPage = true;
            this.zedGraphControl1.IsPrintKeepAspectRatio = true;
            this.zedGraphControl1.IsScrollY2 = false;
            this.zedGraphControl1.IsShowContextMenu = true;
            this.zedGraphControl1.IsShowCopyMessage = true;
            this.zedGraphControl1.IsShowCursorValues = false;
            this.zedGraphControl1.IsShowHScrollBar = false;
            this.zedGraphControl1.IsShowPointValues = false;
            this.zedGraphControl1.IsShowVScrollBar = false;
            this.zedGraphControl1.IsSynchronizeXAxes = false;
            this.zedGraphControl1.IsSynchronizeYAxes = false;
            this.zedGraphControl1.IsZoomOnMouseCenter = false;
            this.zedGraphControl1.LinkButtons = System.Windows.Forms.MouseButtons.Left;
            this.zedGraphControl1.LinkModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.zedGraphControl1.Location = new System.Drawing.Point(6, 5);
            this.zedGraphControl1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.PanButtons = System.Windows.Forms.MouseButtons.Left;
            this.zedGraphControl1.PanButtons2 = System.Windows.Forms.MouseButtons.Middle;
            this.zedGraphControl1.PanModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)));
            this.zedGraphControl1.PanModifierKeys2 = System.Windows.Forms.Keys.None;
            this.zedGraphControl1.PointDateFormat = "g";
            this.zedGraphControl1.PointValueFormat = "G";
            this.zedGraphControl1.ScrollMaxX = 0;
            this.zedGraphControl1.ScrollMaxY = 0;
            this.zedGraphControl1.ScrollMaxY2 = 0;
            this.zedGraphControl1.ScrollMinX = 0;
            this.zedGraphControl1.ScrollMinY = 0;
            this.zedGraphControl1.ScrollMinY2 = 0;
            this.zedGraphControl1.Size = new System.Drawing.Size(598, 260);
            this.zedGraphControl1.TabIndex = 3;
            this.zedGraphControl1.ZoomButtons = System.Windows.Forms.MouseButtons.Left;
            this.zedGraphControl1.ZoomButtons2 = System.Windows.Forms.MouseButtons.None;
            this.zedGraphControl1.ZoomModifierKeys = System.Windows.Forms.Keys.None;
            this.zedGraphControl1.ZoomModifierKeys2 = System.Windows.Forms.Keys.None;
            this.zedGraphControl1.ZoomStepFraction = 0.1;
            // 
            // efPanelStyleXP5
            // 
            this.efPanelStyleXP5.Controls.Add(this.efGroupBox3);
            this.efPanelStyleXP5.Controls.Add(this.efGroupBox2);
            this.efPanelStyleXP5.Dock = System.Windows.Forms.DockStyle.Left;
            this.efPanelStyleXP5.Location = new System.Drawing.Point(0, 0);
            this.efPanelStyleXP5.Margin = new System.Windows.Forms.Padding(2);
            this.efPanelStyleXP5.Name = "efPanelStyleXP5";
            this.efPanelStyleXP5.Size = new System.Drawing.Size(313, 270);
            this.efPanelStyleXP5.TabIndex = 0;
            // 
            // efGroupBox3
            // 
            this.efGroupBox3.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.efGroupBox3.Appearance.Options.UseBackColor = true;
            this.efGroupBox3.Controls.Add(this.mt);
            this.efGroupBox3.Controls.Add(this.efLabel7);
            this.efGroupBox3.Controls.Add(this.wp);
            this.efGroupBox3.Controls.Add(this.rpm);
            this.efGroupBox3.Controls.Add(this.efLabel5);
            this.efGroupBox3.Controls.Add(this.efLabel6);
            this.efGroupBox3.Controls.Add(this.wv);
            this.efGroupBox3.Controls.Add(this.wa);
            this.efGroupBox3.Controls.Add(this.efLabel3);
            this.efGroupBox3.Controls.Add(this.efLabel4);
            this.efGroupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.efGroupBox3.Location = new System.Drawing.Point(0, 99);
            this.efGroupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.efGroupBox3.Name = "efGroupBox3";
            this.efGroupBox3.Size = new System.Drawing.Size(313, 171);
            this.efGroupBox3.TabIndex = 1;
            this.efGroupBox3.Text = "焊接参数";
            // 
            // mt
            // 
            this.mt.EFEname = null;
            this.mt.EFLeaveExpression = ".*";
            this.mt.EFLen = 32767;
            this.mt.Location = new System.Drawing.Point(92, 132);
            this.mt.Margin = new System.Windows.Forms.Padding(2);
            this.mt.Name = "mt";
            this.mt.ReadOnly = true;
            this.mt.Size = new System.Drawing.Size(189, 22);
            this.mt.TabIndex = 13;
            // 
            // efLabel7
            // 
            this.efLabel7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.efLabel7.Location = new System.Drawing.Point(12, 134);
            this.efLabel7.Margin = new System.Windows.Forms.Padding(2);
            this.efLabel7.Name = "efLabel7";
            this.efLabel7.Size = new System.Drawing.Size(52, 14);
            this.efLabel7.TabIndex = 12;
            this.efLabel7.Text = "材质";
            // 
            // wp
            // 
            this.wp.EFEname = null;
            this.wp.EFLeaveExpression = ".*";
            this.wp.EFLen = 32767;
            this.wp.Location = new System.Drawing.Point(92, 107);
            this.wp.Margin = new System.Windows.Forms.Padding(2);
            this.wp.Name = "wp";
            this.wp.ReadOnly = true;
            this.wp.Size = new System.Drawing.Size(189, 22);
            this.wp.TabIndex = 11;
            this.wp.TextChanged += new System.EventHandler(this.efTextBox2_TextChanged);
            // 
            // rpm
            // 
            this.rpm.EFEname = null;
            this.rpm.EFLeaveExpression = ".*";
            this.rpm.EFLen = 32767;
            this.rpm.Location = new System.Drawing.Point(92, 83);
            this.rpm.Margin = new System.Windows.Forms.Padding(2);
            this.rpm.Name = "rpm";
            this.rpm.ReadOnly = true;
            this.rpm.Size = new System.Drawing.Size(189, 22);
            this.rpm.TabIndex = 10;
            // 
            // efLabel5
            // 
            this.efLabel5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.efLabel5.Location = new System.Drawing.Point(12, 109);
            this.efLabel5.Margin = new System.Windows.Forms.Padding(2);
            this.efLabel5.Name = "efLabel5";
            this.efLabel5.Size = new System.Drawing.Size(52, 14);
            this.efLabel5.TabIndex = 9;
            this.efLabel5.Text = "气体";
            // 
            // efLabel6
            // 
            this.efLabel6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.efLabel6.Location = new System.Drawing.Point(12, 81);
            this.efLabel6.Margin = new System.Windows.Forms.Padding(2);
            this.efLabel6.Name = "efLabel6";
            this.efLabel6.Size = new System.Drawing.Size(52, 20);
            this.efLabel6.TabIndex = 8;
            this.efLabel6.Text = "送丝速度";
            // 
            // wv
            // 
            this.wv.EFEname = null;
            this.wv.EFLeaveExpression = ".*";
            this.wv.EFLen = 32767;
            this.wv.Location = new System.Drawing.Point(92, 55);
            this.wv.Margin = new System.Windows.Forms.Padding(2);
            this.wv.Name = "wv";
            this.wv.ReadOnly = true;
            this.wv.Size = new System.Drawing.Size(189, 22);
            this.wv.TabIndex = 7;
            // 
            // wa
            // 
            this.wa.EFEname = null;
            this.wa.EFLeaveExpression = ".*";
            this.wa.EFLen = 32767;
            this.wa.Location = new System.Drawing.Point(92, 31);
            this.wa.Margin = new System.Windows.Forms.Padding(2);
            this.wa.Name = "wa";
            this.wa.ReadOnly = true;
            this.wa.Size = new System.Drawing.Size(189, 22);
            this.wa.TabIndex = 6;
            // 
            // efLabel3
            // 
            this.efLabel3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.efLabel3.Location = new System.Drawing.Point(12, 57);
            this.efLabel3.Margin = new System.Windows.Forms.Padding(2);
            this.efLabel3.Name = "efLabel3";
            this.efLabel3.Size = new System.Drawing.Size(52, 14);
            this.efLabel3.TabIndex = 5;
            this.efLabel3.Text = "焊接电压";
            // 
            // efLabel4
            // 
            this.efLabel4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.efLabel4.Location = new System.Drawing.Point(12, 30);
            this.efLabel4.Margin = new System.Windows.Forms.Padding(2);
            this.efLabel4.Name = "efLabel4";
            this.efLabel4.Size = new System.Drawing.Size(52, 20);
            this.efLabel4.TabIndex = 4;
            this.efLabel4.Text = "焊接电流";
            // 
            // efGroupBox2
            // 
            this.efGroupBox2.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.efGroupBox2.Appearance.Options.UseBackColor = true;
            this.efGroupBox2.Controls.Add(this.state);
            this.efGroupBox2.Controls.Add(this.lab);
            this.efGroupBox2.Controls.Add(this.vv);
            this.efGroupBox2.Controls.Add(this.va);
            this.efGroupBox2.Controls.Add(this.efLabel2);
            this.efGroupBox2.Controls.Add(this.efLabel1);
            this.efGroupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.efGroupBox2.Location = new System.Drawing.Point(0, 0);
            this.efGroupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.efGroupBox2.Name = "efGroupBox2";
            this.efGroupBox2.Size = new System.Drawing.Size(313, 99);
            this.efGroupBox2.TabIndex = 0;
            this.efGroupBox2.Text = "预制参数";
            // 
            // state
            // 
            this.state.EFEname = null;
            this.state.EFLeaveExpression = ".*";
            this.state.EFLen = 32767;
            this.state.Location = new System.Drawing.Point(92, 80);
            this.state.Margin = new System.Windows.Forms.Padding(2);
            this.state.Name = "state";
            this.state.ReadOnly = true;
            this.state.Size = new System.Drawing.Size(189, 22);
            this.state.TabIndex = 5;
            // 
            // lab
            // 
            this.lab.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lab.Location = new System.Drawing.Point(12, 81);
            this.lab.Margin = new System.Windows.Forms.Padding(2);
            this.lab.Name = "lab";
            this.lab.Size = new System.Drawing.Size(52, 14);
            this.lab.TabIndex = 4;
            this.lab.Text = "状态";
            // 
            // vv
            // 
            this.vv.EFEname = null;
            this.vv.EFLeaveExpression = ".*";
            this.vv.EFLen = 32767;
            this.vv.Location = new System.Drawing.Point(92, 53);
            this.vv.Margin = new System.Windows.Forms.Padding(2);
            this.vv.Name = "vv";
            this.vv.ReadOnly = true;
            this.vv.Size = new System.Drawing.Size(189, 22);
            this.vv.TabIndex = 3;
            // 
            // va
            // 
            this.va.EFEname = null;
            this.va.EFLeaveExpression = ".*";
            this.va.EFLen = 32767;
            this.va.Location = new System.Drawing.Point(92, 29);
            this.va.Margin = new System.Windows.Forms.Padding(2);
            this.va.Name = "va";
            this.va.ReadOnly = true;
            this.va.Size = new System.Drawing.Size(189, 22);
            this.va.TabIndex = 2;
            // 
            // efLabel2
            // 
            this.efLabel2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.efLabel2.Location = new System.Drawing.Point(12, 55);
            this.efLabel2.Margin = new System.Windows.Forms.Padding(2);
            this.efLabel2.Name = "efLabel2";
            this.efLabel2.Size = new System.Drawing.Size(52, 14);
            this.efLabel2.TabIndex = 1;
            this.efLabel2.Text = "预置电压";
            // 
            // efLabel1
            // 
            this.efLabel1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.efLabel1.Location = new System.Drawing.Point(12, 27);
            this.efLabel1.Margin = new System.Windows.Forms.Padding(2);
            this.efLabel1.Name = "efLabel1";
            this.efLabel1.Size = new System.Drawing.Size(52, 20);
            this.efLabel1.TabIndex = 0;
            this.efLabel1.Text = "预置电流";
            // 
            // efPanelStyleXP1
            // 
            this.efPanelStyleXP1.Controls.Add(this.weldEquipList);
            this.efPanelStyleXP1.Dock = System.Windows.Forms.DockStyle.Left;
            this.efPanelStyleXP1.Location = new System.Drawing.Point(2, 23);
            this.efPanelStyleXP1.Margin = new System.Windows.Forms.Padding(2);
            this.efPanelStyleXP1.Name = "efPanelStyleXP1";
            this.efPanelStyleXP1.Size = new System.Drawing.Size(375, 373);
            this.efPanelStyleXP1.TabIndex = 0;
            // 
            // weldEquipList
            // 
            this.weldEquipList.Dock = System.Windows.Forms.DockStyle.Left;
            this.weldEquipList.ImageIndex = 0;
            this.weldEquipList.ImageList = this.imageList1;
            this.weldEquipList.Location = new System.Drawing.Point(0, 0);
            this.weldEquipList.Margin = new System.Windows.Forms.Padding(2);
            this.weldEquipList.Name = "weldEquipList";
            treeNode1.ImageIndex = 1;
            treeNode1.Name = "节点2";
            treeNode1.Text = "焊机001";
            treeNode2.Name = "节点1";
            treeNode2.Text = "班组一";
            treeNode3.Name = "root";
            treeNode3.Text = "焊机总成";
            this.weldEquipList.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3});
            this.weldEquipList.SelectedImageIndex = 0;
            this.weldEquipList.Size = new System.Drawing.Size(375, 373);
            this.weldEquipList.TabIndex = 0;
            this.weldEquipList.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.weldEquipList_NodeMouseDoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "OK.jpg");
            this.imageList1.Images.SetKeyName(1, "ER.jpg");
            // 
            // Timer_ZED
            // 
            this.Timer_ZED.Interval = 1000;
            this.Timer_ZED.Tick += new System.EventHandler(this.Timer_ZED_Tick);
            // 
            // Timer_Equip
            // 
            this.Timer_Equip.Interval = 60000;
            this.Timer_Equip.Tick += new System.EventHandler(this.Timer_Equip_Tick);
            // 
            // Timer_Task
            // 
            this.Timer_Task.Interval = 60000;
            this.Timer_Task.Tick += new System.EventHandler(this.Timer_Task_Tick);
            // 
            // FormMCCL00025
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 444);
            this.Controls.Add(this.efGroupBox1);
            this.Name = "FormMCCL00025";
            this.Text = "焊机监控";
            this.Load += new System.EventHandler(this.FormMCCL0004_Load);
            this.Controls.SetChildIndex(this.efGroupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox1)).EndInit();
            this.efGroupBox1.ResumeLayout(false);
            this.efPanelStyleXP2.ResumeLayout(false);
            this.efPanelStyleXP4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.efPanelStyleXP3.ResumeLayout(false);
            this.efPanelStyleXP6.ResumeLayout(false);
            this.efPanelStyleXP5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox3)).EndInit();
            this.efGroupBox3.ResumeLayout(false);
            this.efGroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox2)).EndInit();
            this.efGroupBox2.ResumeLayout(false);
            this.efGroupBox2.PerformLayout();
            this.efPanelStyleXP1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private EF.EFGroupBox efGroupBox1;
        private EF.EFPanelStyleXP efPanelStyleXP2;
        private EF.EFPanelStyleXP efPanelStyleXP1;
        private EF.EFPanelStyleXP efPanelStyleXP4;
        private EF.EFPanelStyleXP efPanelStyleXP3;
        private EF.EFPanelStyleXP efPanelStyleXP6;
        private EF.EFPanelStyleXP efPanelStyleXP5;
        private EF.EFGroupBox efGroupBox2;
        private EF.EFGroupBox efGroupBox3;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private EF.EFDevGrid dataGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private EF.EFTextBox vv;
        private EF.EFTextBox va;
        private EF.EFLabel efLabel2;
        private EF.EFLabel efLabel1;
        private EF.EFTextBox wp;
        private EF.EFTextBox rpm;
        private EF.EFLabel efLabel5;
        private EF.EFLabel efLabel6;
        private EF.EFTextBox wv;
        private EF.EFTextBox wa;
        private EF.EFLabel efLabel3;
        private EF.EFLabel efLabel4;
        private EF.EFTextBox state;
        private EF.EFLabel lab;
        private EF.EFTextBox mt;
        private EF.EFLabel efLabel7;
        private EF.EFTreeView weldEquipList;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Timer Timer_ZED;
        private System.Windows.Forms.Timer Timer_Equip;
        private System.Windows.Forms.Timer Timer_Task;

    }
}