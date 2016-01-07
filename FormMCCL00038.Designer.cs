namespace MC
{
    partial class FormMCCL00038
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            this.efGroupBoxEx1 = new EF.EFGroupBoxEx(this.components);
            this.DefaultWPScbo = new EF.EFComboBox(this.components);
            this.butSet = new EF.EFButton();
            this.efLabel1 = new EF.EFLabel();
            this.efButton2 = new EF.EFButton();
            this.efGroupBoxEx2 = new EF.EFGroupBoxEx(this.components);
            this.TabControl = new EF.EFTabControl(this.components);
            this.tabUnWPS = new System.Windows.Forms.TabPage();
            this.weldwithnotwpsdataGrid = new EF.EFDevGrid();
            this.weldwithnotwpsgridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tabWPS = new System.Windows.Forms.TabPage();
            this.weldwithwpsDataGrid = new EF.EFDevGrid();
            this.weldwithwpsGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBoxEx1)).BeginInit();
            this.efGroupBoxEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.butSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBoxEx2)).BeginInit();
            this.efGroupBoxEx2.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.tabUnWPS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.weldwithnotwpsdataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weldwithnotwpsgridView)).BeginInit();
            this.tabWPS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.weldwithwpsDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weldwithwpsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // efGroupBoxEx1
            // 
            this.efGroupBoxEx1.Controls.Add(this.DefaultWPScbo);
            this.efGroupBoxEx1.Controls.Add(this.butSet);
            this.efGroupBoxEx1.Controls.Add(this.efLabel1);
            this.efGroupBoxEx1.Controls.Add(this.efButton2);
            this.efGroupBoxEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.efGroupBoxEx1.Location = new System.Drawing.Point(0, 0);
            this.efGroupBoxEx1.Margin = new System.Windows.Forms.Padding(2);
            this.efGroupBoxEx1.Name = "efGroupBoxEx1";
            this.efGroupBoxEx1.Size = new System.Drawing.Size(717, 57);
            this.efGroupBoxEx1.TabIndex = 4;
            this.efGroupBoxEx1.Text = "功能区";
            // 
            // DefaultWPScbo
            // 
            this.DefaultWPScbo.ColumnName = null;
            this.DefaultWPScbo.EFCname = "";
            this.DefaultWPScbo.EFDropDown = false;
            this.DefaultWPScbo.FormattingEnabled = true;
            this.DefaultWPScbo.Location = new System.Drawing.Point(122, 26);
            this.DefaultWPScbo.Name = "DefaultWPScbo";
            this.DefaultWPScbo.Size = new System.Drawing.Size(232, 22);
            this.DefaultWPScbo.SQL = null;
            this.DefaultWPScbo.TabIndex = 5;
            this.DefaultWPScbo.UserValue = "";
            // 
            // butSet
            // 
            this.butSet.Authorizable = false;
            this.butSet.EnabledEx = true;
            this.butSet.FnNo = 0;
            this.butSet.Hint = "";
            this.butSet.Location = new System.Drawing.Point(391, 23);
            this.butSet.Name = "butSet";
            this.butSet.Size = new System.Drawing.Size(75, 32);
            this.butSet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.butSet.TabIndex = 4;
            this.butSet.Text = "设定";
            this.butSet.ViewMode = EF.ViewModeEnum.Enable;
            this.butSet.Click += new System.EventHandler(this.butSet_Click);
            // 
            // efLabel1
            // 
            this.efLabel1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.efLabel1.Location = new System.Drawing.Point(13, 26);
            this.efLabel1.Name = "efLabel1";
            this.efLabel1.Size = new System.Drawing.Size(83, 21);
            this.efLabel1.TabIndex = 3;
            this.efLabel1.Text = "默认选定WPS";
            // 
            // efButton2
            // 
            this.efButton2.Authorizable = false;
            this.efButton2.Dock = System.Windows.Forms.DockStyle.Right;
            this.efButton2.EnabledEx = true;
            this.efButton2.FnNo = 0;
            this.efButton2.Hint = "";
            this.efButton2.Location = new System.Drawing.Point(631, 23);
            this.efButton2.Margin = new System.Windows.Forms.Padding(2);
            this.efButton2.Name = "efButton2";
            this.efButton2.Size = new System.Drawing.Size(84, 32);
            this.efButton2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.efButton2.TabIndex = 1;
            this.efButton2.Text = "保存";
            this.efButton2.ViewMode = EF.ViewModeEnum.Enable;
            this.efButton2.Click += new System.EventHandler(this.efButton2_Click);
            // 
            // efGroupBoxEx2
            // 
            this.efGroupBoxEx2.Controls.Add(this.TabControl);
            this.efGroupBoxEx2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.efGroupBoxEx2.Location = new System.Drawing.Point(0, 57);
            this.efGroupBoxEx2.Margin = new System.Windows.Forms.Padding(2);
            this.efGroupBoxEx2.Name = "efGroupBoxEx2";
            this.efGroupBoxEx2.Size = new System.Drawing.Size(717, 387);
            this.efGroupBoxEx2.TabIndex = 5;
            this.efGroupBoxEx2.Text = "焊缝数据区";
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.tabUnWPS);
            this.TabControl.Controls.Add(this.tabWPS);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Location = new System.Drawing.Point(2, 23);
            this.TabControl.Margin = new System.Windows.Forms.Padding(2);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(713, 362);
            this.TabControl.TabIndex = 1;
            // 
            // tabUnWPS
            // 
            this.tabUnWPS.Controls.Add(this.weldwithnotwpsdataGrid);
            this.tabUnWPS.Location = new System.Drawing.Point(4, 23);
            this.tabUnWPS.Margin = new System.Windows.Forms.Padding(2);
            this.tabUnWPS.Name = "tabUnWPS";
            this.tabUnWPS.Padding = new System.Windows.Forms.Padding(2);
            this.tabUnWPS.Size = new System.Drawing.Size(705, 335);
            this.tabUnWPS.TabIndex = 0;
            this.tabUnWPS.Text = "自动匹配WPS焊缝";
            this.tabUnWPS.UseVisualStyleBackColor = true;
            // 
            // weldwithnotwpsdataGrid
            // 
            this.weldwithnotwpsdataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.weldwithnotwpsdataGrid.IsUseCustomPageBar = true;
            gridLevelNode2.RelationName = "Level1";
            this.weldwithnotwpsdataGrid.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2});
            this.weldwithnotwpsdataGrid.Location = new System.Drawing.Point(2, 2);
            this.weldwithnotwpsdataGrid.MainView = this.weldwithnotwpsgridView;
            this.weldwithnotwpsdataGrid.Margin = new System.Windows.Forms.Padding(2);
            this.weldwithnotwpsdataGrid.Name = "weldwithnotwpsdataGrid";
            this.weldwithnotwpsdataGrid.Size = new System.Drawing.Size(701, 331);
            this.weldwithnotwpsdataGrid.TabIndex = 0;
            this.weldwithnotwpsdataGrid.UseEmbeddedNavigator = true;
            this.weldwithnotwpsdataGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.weldwithnotwpsgridView});
            // 
            // weldwithnotwpsgridView
            // 
            this.weldwithnotwpsgridView.FixedLineWidth = 1;
            this.weldwithnotwpsgridView.GridControl = this.weldwithnotwpsdataGrid;
            this.weldwithnotwpsgridView.IndicatorWidth = 35;
            this.weldwithnotwpsgridView.Name = "weldwithnotwpsgridView";
            this.weldwithnotwpsgridView.OptionsView.ColumnAutoWidth = false;
            this.weldwithnotwpsgridView.OptionsView.EnableAppearanceEvenRow = true;
            this.weldwithnotwpsgridView.OptionsView.EnableAppearanceOddRow = true;
            this.weldwithnotwpsgridView.OptionsView.ShowGroupPanel = false;
            // 
            // tabWPS
            // 
            this.tabWPS.Controls.Add(this.weldwithwpsDataGrid);
            this.tabWPS.Location = new System.Drawing.Point(4, 23);
            this.tabWPS.Margin = new System.Windows.Forms.Padding(2);
            this.tabWPS.Name = "tabWPS";
            this.tabWPS.Padding = new System.Windows.Forms.Padding(2);
            this.tabWPS.Size = new System.Drawing.Size(705, 335);
            this.tabWPS.TabIndex = 1;
            this.tabWPS.Text = "已匹配WPS焊缝";
            this.tabWPS.UseVisualStyleBackColor = true;
            // 
            // weldwithwpsDataGrid
            // 
            this.weldwithwpsDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.weldwithwpsDataGrid.IsUseCustomPageBar = true;
            this.weldwithwpsDataGrid.Location = new System.Drawing.Point(2, 2);
            this.weldwithwpsDataGrid.MainView = this.weldwithwpsGridView;
            this.weldwithwpsDataGrid.Margin = new System.Windows.Forms.Padding(2);
            this.weldwithwpsDataGrid.Name = "weldwithwpsDataGrid";
            this.weldwithwpsDataGrid.Size = new System.Drawing.Size(701, 331);
            this.weldwithwpsDataGrid.TabIndex = 0;
            this.weldwithwpsDataGrid.UseEmbeddedNavigator = true;
            this.weldwithwpsDataGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.weldwithwpsGridView});
            // 
            // weldwithwpsGridView
            // 
            this.weldwithwpsGridView.FixedLineWidth = 1;
            this.weldwithwpsGridView.GridControl = this.weldwithwpsDataGrid;
            this.weldwithwpsGridView.IndicatorWidth = 35;
            this.weldwithwpsGridView.Name = "weldwithwpsGridView";
            this.weldwithwpsGridView.OptionsView.ColumnAutoWidth = false;
            this.weldwithwpsGridView.OptionsView.EnableAppearanceEvenRow = true;
            this.weldwithwpsGridView.OptionsView.EnableAppearanceOddRow = true;
            this.weldwithwpsGridView.OptionsView.ShowGroupPanel = false;
            // 
            // FormMCCL00038
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(717, 490);
            this.Controls.Add(this.efGroupBoxEx2);
            this.Controls.Add(this.efGroupBoxEx1);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "FormMCCL00038";
            this.Text = "焊缝WPS自动匹配";
            this.Load += new System.EventHandler(this.FormMCCL00038_Load);
            this.Controls.SetChildIndex(this.efGroupBoxEx1, 0);
            this.Controls.SetChildIndex(this.efGroupBoxEx2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBoxEx1)).EndInit();
            this.efGroupBoxEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.butSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBoxEx2)).EndInit();
            this.efGroupBoxEx2.ResumeLayout(false);
            this.TabControl.ResumeLayout(false);
            this.tabUnWPS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.weldwithnotwpsdataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weldwithnotwpsgridView)).EndInit();
            this.tabWPS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.weldwithwpsDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weldwithwpsGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private EF.EFGroupBoxEx efGroupBoxEx1;
        private EF.EFGroupBoxEx efGroupBoxEx2;
        private EF.EFButton efButton2;
        private EF.EFDevGrid weldwithnotwpsdataGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView weldwithnotwpsgridView;
        private EF.EFTabControl TabControl;
        private System.Windows.Forms.TabPage tabUnWPS;
        private System.Windows.Forms.TabPage tabWPS;
        private EF.EFDevGrid weldwithwpsDataGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView weldwithwpsGridView;
        private EF.EFButton butSet;
        private EF.EFLabel efLabel1;
        private EF.EFComboBox DefaultWPScbo;
    }
}
