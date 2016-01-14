namespace MC
{
    partial class FormMCCL0041
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.han = new EF.EFGroupBoxEx(this.components);
            this.butOK = new EF.EFButton();
            this.luAS3 = new EF.EFDevLookUpEdit(this.components);
            this.luTREENAME = new EF.EFDevLookUpEdit(this.components);
            this.luBUFF1 = new EF.EFDevLookUpEdit(this.components);
            this.luSHIP_NO = new EF.EFDevLookUpEdit(this.components);
            this.efLabel5 = new EF.EFLabel();
            this.efLabel3 = new EF.EFLabel();
            this.efLabel2 = new EF.EFLabel();
            this.efLabel1 = new EF.EFLabel();
            this.efPanel1 = new EF.EFPanel(this.components);
            this.efGroupBox2 = new EF.EFGroupBox(this.components);
            this.weldsdataGrid = new EF.EFDevGrid();
            this.weldsGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.SHIP_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BUFF1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TREE_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BLK_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AS3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.L1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.L2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.L3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.L4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.efGroupBox1 = new EF.EFGroupBox(this.components);
            this.zgc = new ZedGraph.ZedGraphControl();
            ((System.ComponentModel.ISupportInitialize)(this.han)).BeginInit();
            this.han.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.butOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luAS3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luTREENAME.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luBUFF1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luSHIP_NO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efPanel1)).BeginInit();
            this.efPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox2)).BeginInit();
            this.efGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.weldsdataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weldsGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox1)).BeginInit();
            this.efGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // han
            // 
            this.han.Controls.Add(this.butOK);
            this.han.Controls.Add(this.luAS3);
            this.han.Controls.Add(this.luTREENAME);
            this.han.Controls.Add(this.luBUFF1);
            this.han.Controls.Add(this.luSHIP_NO);
            this.han.Controls.Add(this.efLabel5);
            this.han.Controls.Add(this.efLabel3);
            this.han.Controls.Add(this.efLabel2);
            this.han.Controls.Add(this.efLabel1);
            this.han.Dock = System.Windows.Forms.DockStyle.Top;
            this.han.Location = new System.Drawing.Point(0, 0);
            this.han.Margin = new System.Windows.Forms.Padding(2);
            this.han.Name = "han";
            this.han.Size = new System.Drawing.Size(896, 64);
            this.han.TabIndex = 4;
            this.han.Text = "焊缝集合";
            // 
            // butOK
            // 
            this.butOK.Authorizable = false;
            this.butOK.Dock = System.Windows.Forms.DockStyle.Right;
            this.butOK.EnabledEx = true;
            this.butOK.FnNo = 0;
            this.butOK.Hint = "";
            this.butOK.Location = new System.Drawing.Point(823, 23);
            this.butOK.Margin = new System.Windows.Forms.Padding(2);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(71, 39);
            this.butOK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.butOK.TabIndex = 10;
            this.butOK.Text = "确定";
            this.butOK.ViewMode = EF.ViewModeEnum.Enable;
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // luAS3
            // 
            this.luAS3.EditValue = "*";
            this.luAS3.Location = new System.Drawing.Point(700, 32);
            this.luAS3.Margin = new System.Windows.Forms.Padding(2);
            this.luAS3.Name = "luAS3";
            this.luAS3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luAS3.Size = new System.Drawing.Size(139, 21);
            this.luAS3.TabIndex = 9;
            // 
            // luTREENAME
            // 
            this.luTREENAME.EditValue = "*";
            this.luTREENAME.Location = new System.Drawing.Point(468, 32);
            this.luTREENAME.Margin = new System.Windows.Forms.Padding(2);
            this.luTREENAME.Name = "luTREENAME";
            this.luTREENAME.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luTREENAME.Size = new System.Drawing.Size(139, 21);
            this.luTREENAME.TabIndex = 7;
            this.luTREENAME.EditValueChanged += new System.EventHandler(this.luTREENAME_EditValueChanged);
            // 
            // luBUFF1
            // 
            this.luBUFF1.EditValue = "*";
            this.luBUFF1.Location = new System.Drawing.Point(251, 32);
            this.luBUFF1.Margin = new System.Windows.Forms.Padding(2);
            this.luBUFF1.Name = "luBUFF1";
            this.luBUFF1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luBUFF1.Size = new System.Drawing.Size(139, 21);
            this.luBUFF1.TabIndex = 6;
            this.luBUFF1.EditValueChanged += new System.EventHandler(this.luBUFF1_EditValueChanged);
            // 
            // luSHIP_NO
            // 
            this.luSHIP_NO.Location = new System.Drawing.Point(53, 32);
            this.luSHIP_NO.Margin = new System.Windows.Forms.Padding(2);
            this.luSHIP_NO.Name = "luSHIP_NO";
            this.luSHIP_NO.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luSHIP_NO.Size = new System.Drawing.Size(139, 21);
            this.luSHIP_NO.TabIndex = 5;
            this.luSHIP_NO.EditValueChanged += new System.EventHandler(this.luSHIP_NO_EditValueChanged);
            // 
            // efLabel5
            // 
            this.efLabel5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.efLabel5.Location = new System.Drawing.Point(647, 31);
            this.efLabel5.Margin = new System.Windows.Forms.Padding(2);
            this.efLabel5.Name = "efLabel5";
            this.efLabel5.Size = new System.Drawing.Size(41, 20);
            this.efLabel5.TabIndex = 4;
            this.efLabel5.Text = "AS3";
            // 
            // efLabel3
            // 
            this.efLabel3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.efLabel3.Location = new System.Drawing.Point(422, 31);
            this.efLabel3.Margin = new System.Windows.Forms.Padding(2);
            this.efLabel3.Name = "efLabel3";
            this.efLabel3.Size = new System.Drawing.Size(41, 20);
            this.efLabel3.TabIndex = 2;
            this.efLabel3.Text = "分段";
            // 
            // efLabel2
            // 
            this.efLabel2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.efLabel2.Location = new System.Drawing.Point(213, 31);
            this.efLabel2.Margin = new System.Windows.Forms.Padding(2);
            this.efLabel2.Name = "efLabel2";
            this.efLabel2.Size = new System.Drawing.Size(41, 20);
            this.efLabel2.TabIndex = 1;
            this.efLabel2.Text = "阶段";
            // 
            // efLabel1
            // 
            this.efLabel1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.efLabel1.Location = new System.Drawing.Point(16, 31);
            this.efLabel1.Margin = new System.Windows.Forms.Padding(2);
            this.efLabel1.Name = "efLabel1";
            this.efLabel1.Size = new System.Drawing.Size(41, 20);
            this.efLabel1.TabIndex = 0;
            this.efLabel1.Text = "号船";
            // 
            // efPanel1
            // 
            this.efPanel1.Controls.Add(this.efGroupBox2);
            this.efPanel1.Controls.Add(this.efGroupBox1);
            this.efPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.efPanel1.Location = new System.Drawing.Point(0, 64);
            this.efPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.efPanel1.Name = "efPanel1";
            this.efPanel1.Size = new System.Drawing.Size(896, 380);
            this.efPanel1.TabIndex = 5;
            // 
            // efGroupBox2
            // 
            this.efGroupBox2.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.efGroupBox2.Appearance.Options.UseBackColor = true;
            this.efGroupBox2.Controls.Add(this.weldsdataGrid);
            this.efGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.efGroupBox2.Location = new System.Drawing.Point(485, 0);
            this.efGroupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.efGroupBox2.Name = "efGroupBox2";
            this.efGroupBox2.Size = new System.Drawing.Size(411, 380);
            this.efGroupBox2.TabIndex = 1;
            this.efGroupBox2.Text = "统计列表";
            // 
            // weldsdataGrid
            // 
            this.weldsdataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.weldsdataGrid.IsUseCustomPageBar = true;
            this.weldsdataGrid.Location = new System.Drawing.Point(2, 23);
            this.weldsdataGrid.MainView = this.weldsGridView;
            this.weldsdataGrid.Margin = new System.Windows.Forms.Padding(2);
            this.weldsdataGrid.Name = "weldsdataGrid";
            this.weldsdataGrid.ShowContextMenuAddCopyNew = false;
            this.weldsdataGrid.ShowContextMenuAddNew = false;
            this.weldsdataGrid.ShowContextMenuChoose = false;
            this.weldsdataGrid.ShowContextMenuChooseAll = false;
            this.weldsdataGrid.ShowContextMenuSaveAs = false;
            this.weldsdataGrid.ShowContextMenuUnChoose = false;
            this.weldsdataGrid.ShowContextMenuUnChooseAll = false;
            this.weldsdataGrid.ShowDeleteRowButton = true;
            this.weldsdataGrid.ShowSaveLayoutButton = false;
            this.weldsdataGrid.Size = new System.Drawing.Size(407, 355);
            this.weldsdataGrid.TabIndex = 0;
            this.weldsdataGrid.UseEmbeddedNavigator = true;
            this.weldsdataGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.weldsGridView});
            // 
            // weldsGridView
            // 
            this.weldsGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.SHIP_NO,
            this.BUFF1,
            this.TREE_NAME,
            this.BLK_NO,
            this.AS3,
            this.L1,
            this.L2,
            this.L3,
            this.L4});
            this.weldsGridView.FixedLineWidth = 1;
            this.weldsGridView.GridControl = this.weldsdataGrid;
            this.weldsGridView.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "L1", this.L1, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "L2", this.L2, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "L3", this.L3, ""),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "L4", this.L4, "")});
            this.weldsGridView.IndicatorWidth = 35;
            this.weldsGridView.Name = "weldsGridView";
            this.weldsGridView.OptionsView.ColumnAutoWidth = false;
            this.weldsGridView.OptionsView.EnableAppearanceEvenRow = true;
            this.weldsGridView.OptionsView.EnableAppearanceOddRow = true;
            this.weldsGridView.OptionsView.ShowGroupPanel = false;
            this.weldsGridView.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.weldsGridView_RowClick);
            // 
            // SHIP_NO
            // 
            this.SHIP_NO.Caption = "号船";
            this.SHIP_NO.FieldName = "SHIP_NO";
            this.SHIP_NO.Name = "SHIP_NO";
            this.SHIP_NO.Visible = true;
            this.SHIP_NO.VisibleIndex = 0;
            // 
            // BUFF1
            // 
            this.BUFF1.Caption = "阶段";
            this.BUFF1.FieldName = "BUFF1";
            this.BUFF1.Name = "BUFF1";
            this.BUFF1.Visible = true;
            this.BUFF1.VisibleIndex = 1;
            // 
            // TREE_NAME
            // 
            this.TREE_NAME.Caption = "分段";
            this.TREE_NAME.FieldName = "TREE_NAME";
            this.TREE_NAME.Name = "TREE_NAME";
            this.TREE_NAME.Visible = true;
            this.TREE_NAME.VisibleIndex = 2;
            // 
            // BLK_NO
            // 
            this.BLK_NO.Caption = "块";
            this.BLK_NO.FieldName = "BLK_NO";
            this.BLK_NO.Name = "BLK_NO";
            this.BLK_NO.Visible = true;
            this.BLK_NO.VisibleIndex = 3;
            // 
            // AS3
            // 
            this.AS3.Caption = "AS3";
            this.AS3.FieldName = "AS3";
            this.AS3.Name = "AS3";
            this.AS3.Visible = true;
            this.AS3.VisibleIndex = 4;
            // 
            // L1
            // 
            this.L1.Caption = "[0-59]";
            this.L1.FieldName = "L1";
            this.L1.Name = "L1";
            this.L1.Visible = true;
            this.L1.VisibleIndex = 5;
            // 
            // L2
            // 
            this.L2.Caption = "[60-79]";
            this.L2.FieldName = "L2";
            this.L2.Name = "L2";
            this.L2.Visible = true;
            this.L2.VisibleIndex = 6;
            // 
            // L3
            // 
            this.L3.Caption = "[80-79]";
            this.L3.FieldName = "L3";
            this.L3.Name = "L3";
            this.L3.Visible = true;
            this.L3.VisibleIndex = 7;
            // 
            // L4
            // 
            this.L4.Caption = "[90-100]";
            this.L4.FieldName = "L4";
            this.L4.Name = "L4";
            this.L4.Visible = true;
            this.L4.VisibleIndex = 8;
            this.L4.Width = 132;
            // 
            // efGroupBox1
            // 
            this.efGroupBox1.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.efGroupBox1.Appearance.Options.UseBackColor = true;
            this.efGroupBox1.Controls.Add(this.zgc);
            this.efGroupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.efGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.efGroupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.efGroupBox1.Name = "efGroupBox1";
            this.efGroupBox1.Size = new System.Drawing.Size(485, 380);
            this.efGroupBox1.TabIndex = 0;
            this.efGroupBox1.Text = "统计饼图";
            // 
            // zgc
            // 
            this.zgc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zgc.EditButtons = System.Windows.Forms.MouseButtons.Left;
            this.zgc.EditModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.zgc.IsAutoScrollRange = false;
            this.zgc.IsEnableHEdit = false;
            this.zgc.IsEnableHPan = true;
            this.zgc.IsEnableHZoom = true;
            this.zgc.IsEnableVEdit = false;
            this.zgc.IsEnableVPan = true;
            this.zgc.IsEnableVZoom = true;
            this.zgc.IsPrintFillPage = true;
            this.zgc.IsPrintKeepAspectRatio = true;
            this.zgc.IsScrollY2 = false;
            this.zgc.IsShowContextMenu = true;
            this.zgc.IsShowCopyMessage = true;
            this.zgc.IsShowCursorValues = false;
            this.zgc.IsShowHScrollBar = false;
            this.zgc.IsShowPointValues = false;
            this.zgc.IsShowVScrollBar = false;
            this.zgc.IsSynchronizeXAxes = false;
            this.zgc.IsSynchronizeYAxes = false;
            this.zgc.IsZoomOnMouseCenter = false;
            this.zgc.LinkButtons = System.Windows.Forms.MouseButtons.Left;
            this.zgc.LinkModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)));
            this.zgc.Location = new System.Drawing.Point(2, 23);
            this.zgc.Margin = new System.Windows.Forms.Padding(4);
            this.zgc.Name = "zgc";
            this.zgc.PanButtons = System.Windows.Forms.MouseButtons.Left;
            this.zgc.PanButtons2 = System.Windows.Forms.MouseButtons.Middle;
            this.zgc.PanModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)));
            this.zgc.PanModifierKeys2 = System.Windows.Forms.Keys.None;
            this.zgc.PointDateFormat = "g";
            this.zgc.PointValueFormat = "G";
            this.zgc.ScrollMaxX = 0;
            this.zgc.ScrollMaxY = 0;
            this.zgc.ScrollMaxY2 = 0;
            this.zgc.ScrollMinX = 0;
            this.zgc.ScrollMinY = 0;
            this.zgc.ScrollMinY2 = 0;
            this.zgc.Size = new System.Drawing.Size(481, 355);
            this.zgc.TabIndex = 1;
            this.zgc.ZoomButtons = System.Windows.Forms.MouseButtons.Left;
            this.zgc.ZoomButtons2 = System.Windows.Forms.MouseButtons.None;
            this.zgc.ZoomModifierKeys = System.Windows.Forms.Keys.None;
            this.zgc.ZoomModifierKeys2 = System.Windows.Forms.Keys.None;
            this.zgc.ZoomStepFraction = 0.1;
            // 
            // FormMCCL0041
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(896, 490);
            this.Controls.Add(this.efPanel1);
            this.Controls.Add(this.han);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "FormMCCL0041";
            this.Text = "焊缝评估-焊缝";
            this.Load += new System.EventHandler(this.FormMCCL0041_Load);
            this.Controls.SetChildIndex(this.han, 0);
            this.Controls.SetChildIndex(this.efPanel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.han)).EndInit();
            this.han.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.butOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luAS3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luTREENAME.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luBUFF1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luSHIP_NO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efPanel1)).EndInit();
            this.efPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox2)).EndInit();
            this.efGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.weldsdataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weldsGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox1)).EndInit();
            this.efGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private EF.EFGroupBoxEx han;
        private EF.EFPanel efPanel1;
        private EF.EFGroupBox efGroupBox1;
        private EF.EFGroupBox efGroupBox2;
        private ZedGraph.ZedGraphControl zgc;
        private EF.EFDevGrid weldsdataGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView weldsGridView;
        private DevExpress.XtraGrid.Columns.GridColumn SHIP_NO;
        private DevExpress.XtraGrid.Columns.GridColumn BUFF1;
        private DevExpress.XtraGrid.Columns.GridColumn TREE_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn BLK_NO;
        private DevExpress.XtraGrid.Columns.GridColumn AS3;
        private DevExpress.XtraGrid.Columns.GridColumn L1;
        private DevExpress.XtraGrid.Columns.GridColumn L2;
        private DevExpress.XtraGrid.Columns.GridColumn L3;
        private DevExpress.XtraGrid.Columns.GridColumn L4;
        private EF.EFLabel efLabel3;
        private EF.EFLabel efLabel2;
        private EF.EFLabel efLabel1;
        private EF.EFLabel efLabel5;
        private EF.EFDevLookUpEdit luAS3;
        private EF.EFDevLookUpEdit luTREENAME;
        private EF.EFDevLookUpEdit luBUFF1;
        private EF.EFDevLookUpEdit luSHIP_NO;
        private EF.EFButton butOK;
    }
}
