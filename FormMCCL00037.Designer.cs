namespace MC
{
    partial class FormMCCL00037
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
            this.efGroupBox1 = new EF.EFGroupBox(this.components);
            this.butSetDefault = new EF.EFButton();
            this.butUpdate = new EF.EFButton();
            this.efLabel1 = new EF.EFLabel();
            this.efGroupBoxEx1 = new EF.EFGroupBoxEx(this.components);
            this.TabControl = new EF.EFTabControl(this.components);
            this.tabWPS = new System.Windows.Forms.TabPage();
            this.wpsDataGrid = new EF.EFDevGrid();
            this.wpsGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tabSubWPS = new System.Windows.Forms.TabPage();
            this.SubwpsDataGrid = new EF.EFDevGrid();
            this.SubwpsGridVIew = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox1)).BeginInit();
            this.efGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.butSetDefault)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.butUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBoxEx1)).BeginInit();
            this.efGroupBoxEx1.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.tabWPS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wpsDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wpsGridView)).BeginInit();
            this.tabSubWPS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SubwpsDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubwpsGridVIew)).BeginInit();
            this.SuspendLayout();
            // 
            // efGroupBox1
            // 
            this.efGroupBox1.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.efGroupBox1.Appearance.Options.UseBackColor = true;
            this.efGroupBox1.Controls.Add(this.butSetDefault);
            this.efGroupBox1.Controls.Add(this.butUpdate);
            this.efGroupBox1.Controls.Add(this.efLabel1);
            this.efGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.efGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.efGroupBox1.Name = "efGroupBox1";
            this.efGroupBox1.Size = new System.Drawing.Size(1067, 85);
            this.efGroupBox1.TabIndex = 4;
            // 
            // butSetDefault
            // 
            this.butSetDefault.Authorizable = false;
            this.butSetDefault.Dock = System.Windows.Forms.DockStyle.Right;
            this.butSetDefault.EnabledEx = true;
            this.butSetDefault.FnNo = 0;
            this.butSetDefault.Hint = "";
            this.butSetDefault.Location = new System.Drawing.Point(915, 30);
            this.butSetDefault.Name = "butSetDefault";
            this.butSetDefault.Size = new System.Drawing.Size(75, 53);
            this.butSetDefault.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.butSetDefault.TabIndex = 2;
            this.butSetDefault.Text = "设定默认";
            this.butSetDefault.ViewMode = EF.ViewModeEnum.Enable;
            this.butSetDefault.Click += new System.EventHandler(this.butSetDefault_Click);
            // 
            // butUpdate
            // 
            this.butUpdate.Authorizable = false;
            this.butUpdate.Dock = System.Windows.Forms.DockStyle.Right;
            this.butUpdate.EnabledEx = true;
            this.butUpdate.FnNo = 0;
            this.butUpdate.Hint = "";
            this.butUpdate.Location = new System.Drawing.Point(990, 30);
            this.butUpdate.Name = "butUpdate";
            this.butUpdate.Size = new System.Drawing.Size(75, 53);
            this.butUpdate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.butUpdate.TabIndex = 1;
            this.butUpdate.Text = "更新";
            this.butUpdate.ViewMode = EF.ViewModeEnum.Enable;
            this.butUpdate.Click += new System.EventHandler(this.butUpdate_Click);
            // 
            // efLabel1
            // 
            this.efLabel1.Appearance.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.efLabel1.Appearance.Options.UseFont = true;
            this.efLabel1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.efLabel1.Location = new System.Drawing.Point(12, 33);
            this.efLabel1.Name = "efLabel1";
            this.efLabel1.Size = new System.Drawing.Size(288, 39);
            this.efLabel1.TabIndex = 0;
            this.efLabel1.Text = "默认WPS设置";
            // 
            // efGroupBoxEx1
            // 
            this.efGroupBoxEx1.Controls.Add(this.TabControl);
            this.efGroupBoxEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.efGroupBoxEx1.Location = new System.Drawing.Point(0, 85);
            this.efGroupBoxEx1.Name = "efGroupBoxEx1";
            this.efGroupBoxEx1.Size = new System.Drawing.Size(1067, 531);
            this.efGroupBoxEx1.TabIndex = 5;
            this.efGroupBoxEx1.Text = "默认WPS集合";
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.tabWPS);
            this.TabControl.Controls.Add(this.tabSubWPS);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Location = new System.Drawing.Point(2, 30);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(1063, 499);
            this.TabControl.TabIndex = 0;
            // 
            // tabWPS
            // 
            this.tabWPS.Controls.Add(this.wpsDataGrid);
            this.tabWPS.Location = new System.Drawing.Point(4, 31);
            this.tabWPS.Name = "tabWPS";
            this.tabWPS.Padding = new System.Windows.Forms.Padding(3);
            this.tabWPS.Size = new System.Drawing.Size(1055, 464);
            this.tabWPS.TabIndex = 0;
            this.tabWPS.Text = "WPS规程";
            this.tabWPS.UseVisualStyleBackColor = true;
            // 
            // wpsDataGrid
            // 
            this.wpsDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wpsDataGrid.IsUseCustomPageBar = true;
            this.wpsDataGrid.Location = new System.Drawing.Point(3, 3);
            this.wpsDataGrid.MainView = this.wpsGridView;
            this.wpsDataGrid.Name = "wpsDataGrid";
            this.wpsDataGrid.Size = new System.Drawing.Size(1049, 458);
            this.wpsDataGrid.TabIndex = 0;
            this.wpsDataGrid.UseEmbeddedNavigator = true;
            this.wpsDataGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.wpsGridView});
            // 
            // wpsGridView
            // 
            this.wpsGridView.FixedLineWidth = 1;
            this.wpsGridView.GridControl = this.wpsDataGrid;
            this.wpsGridView.IndicatorWidth = 35;
            this.wpsGridView.Name = "wpsGridView";
            this.wpsGridView.OptionsView.ColumnAutoWidth = false;
            this.wpsGridView.OptionsView.EnableAppearanceEvenRow = true;
            this.wpsGridView.OptionsView.EnableAppearanceOddRow = true;
            this.wpsGridView.OptionsView.ShowGroupPanel = false;
            this.wpsGridView.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.wpsGridView_RowClick);
            this.wpsGridView.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.wpsGridView_RowCellClick);
            // 
            // tabSubWPS
            // 
            this.tabSubWPS.Controls.Add(this.SubwpsDataGrid);
            this.tabSubWPS.Location = new System.Drawing.Point(4, 31);
            this.tabSubWPS.Name = "tabSubWPS";
            this.tabSubWPS.Padding = new System.Windows.Forms.Padding(3);
            this.tabSubWPS.Size = new System.Drawing.Size(1055, 464);
            this.tabSubWPS.TabIndex = 1;
            this.tabSubWPS.Text = "WPS子规程";
            this.tabSubWPS.UseVisualStyleBackColor = true;
            // 
            // SubwpsDataGrid
            // 
            this.SubwpsDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SubwpsDataGrid.LastPageButtonEnable = false;
            this.SubwpsDataGrid.Location = new System.Drawing.Point(3, 3);
            this.SubwpsDataGrid.MainView = this.SubwpsGridVIew;
            this.SubwpsDataGrid.Name = "SubwpsDataGrid";
            this.SubwpsDataGrid.Size = new System.Drawing.Size(1049, 458);
            this.SubwpsDataGrid.TabIndex = 0;
            this.SubwpsDataGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.SubwpsGridVIew});
            // 
            // SubwpsGridVIew
            // 
            this.SubwpsGridVIew.FixedLineWidth = 1;
            this.SubwpsGridVIew.GridControl = this.SubwpsDataGrid;
            this.SubwpsGridVIew.IndicatorWidth = 35;
            this.SubwpsGridVIew.Name = "SubwpsGridVIew";
            this.SubwpsGridVIew.OptionsView.ColumnAutoWidth = false;
            this.SubwpsGridVIew.OptionsView.EnableAppearanceEvenRow = true;
            this.SubwpsGridVIew.OptionsView.EnableAppearanceOddRow = true;
            this.SubwpsGridVIew.OptionsView.ShowGroupPanel = false;
            this.SubwpsGridVIew.PaintStyleName = "WindowsXP";
            // 
            // FormMCCL00037
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.ClientSize = new System.Drawing.Size(1067, 688);
            this.Controls.Add(this.efGroupBoxEx1);
            this.Controls.Add(this.efGroupBox1);
            this.Name = "FormMCCL00037";
            this.Text = "默认WPS设置管理";
            this.Load += new System.EventHandler(this.FormMCCL00037_Load);
            this.Controls.SetChildIndex(this.efGroupBox1, 0);
            this.Controls.SetChildIndex(this.efGroupBoxEx1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox1)).EndInit();
            this.efGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.butSetDefault)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.butUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBoxEx1)).EndInit();
            this.efGroupBoxEx1.ResumeLayout(false);
            this.TabControl.ResumeLayout(false);
            this.tabWPS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.wpsDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wpsGridView)).EndInit();
            this.tabSubWPS.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SubwpsDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubwpsGridVIew)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private EF.EFGroupBox efGroupBox1;
        private EF.EFLabel efLabel1;
        private EF.EFGroupBoxEx efGroupBoxEx1;
        private EF.EFTabControl TabControl;
        private System.Windows.Forms.TabPage tabWPS;
        private System.Windows.Forms.TabPage tabSubWPS;
        private EF.EFDevGrid wpsDataGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView wpsGridView;
        private EF.EFDevGrid SubwpsDataGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView SubwpsGridVIew;
        private EF.EFButton butSetDefault;
        private EF.EFButton butUpdate;
    }
}
