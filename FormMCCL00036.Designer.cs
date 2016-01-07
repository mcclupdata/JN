namespace MC
{
    partial class FormMCCL00036
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
            this.but_OK = new EF.EFButton();
            this.LookUp_SM = new EF.EFDevLookUpEdit(this.components);
            this.efLabel1 = new EF.EFLabel();
            this.efGroupBox2 = new EF.EFGroupBox(this.components);
            this.dataGrid = new EF.EFDevGrid();
            this.View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUp_SHIPMOD = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox1)).BeginInit();
            this.efGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.but_OK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LookUp_SM.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox2)).BeginInit();
            this.efGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUp_SHIPMOD)).BeginInit();
            this.SuspendLayout();
            // 
            // efGroupBox1
            // 
            this.efGroupBox1.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.efGroupBox1.Appearance.Options.UseBackColor = true;
            this.efGroupBox1.Controls.Add(this.but_OK);
            this.efGroupBox1.Controls.Add(this.LookUp_SM);
            this.efGroupBox1.Controls.Add(this.efLabel1);
            this.efGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.efGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.efGroupBox1.Name = "efGroupBox1";
            this.efGroupBox1.Size = new System.Drawing.Size(1140, 100);
            this.efGroupBox1.TabIndex = 5;
            this.efGroupBox1.Text = "功能";
            // 
            // but_OK
            // 
            this.but_OK.Authorizable = false;
            this.but_OK.EnabledEx = true;
            this.but_OK.FnNo = 0;
            this.but_OK.Hint = "";
            this.but_OK.Location = new System.Drawing.Point(663, 52);
            this.but_OK.Name = "but_OK";
            this.but_OK.Size = new System.Drawing.Size(110, 27);
            this.but_OK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.but_OK.TabIndex = 4;
            this.but_OK.Text = "更新";
            this.but_OK.ViewMode = EF.ViewModeEnum.Enable;
            this.but_OK.Click += new System.EventHandler(this.but_OK_Click);
            // 
            // LookUp_SM
            // 
            this.LookUp_SM.Location = new System.Drawing.Point(88, 49);
            this.LookUp_SM.Name = "LookUp_SM";
            this.LookUp_SM.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LookUp_SM.Properties.DisplayMember = "FName";
            this.LookUp_SM.Properties.ValueMember = "FID";
            this.LookUp_SM.Size = new System.Drawing.Size(349, 28);
            this.LookUp_SM.TabIndex = 2;
            this.LookUp_SM.EditValueChanged += new System.EventHandler(this.LookUp_SM_EditValueChanged);
            // 
            // efLabel1
            // 
            this.efLabel1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.efLabel1.Location = new System.Drawing.Point(12, 49);
            this.efLabel1.Name = "efLabel1";
            this.efLabel1.Size = new System.Drawing.Size(45, 26);
            this.efLabel1.TabIndex = 0;
            this.efLabel1.Text = "船型";
            // 
            // efGroupBox2
            // 
            this.efGroupBox2.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.efGroupBox2.Appearance.Options.UseBackColor = true;
            this.efGroupBox2.Controls.Add(this.dataGrid);
            this.efGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.efGroupBox2.Location = new System.Drawing.Point(0, 100);
            this.efGroupBox2.Name = "efGroupBox2";
            this.efGroupBox2.Size = new System.Drawing.Size(1140, 622);
            this.efGroupBox2.TabIndex = 6;
            this.efGroupBox2.Text = "数据";
            // 
            // dataGrid
            // 
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.IsUseCustomPageBar = true;
            this.dataGrid.Location = new System.Drawing.Point(2, 30);
            this.dataGrid.MainView = this.View;
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ItemLookUp_SHIPMOD});
            this.dataGrid.ShowAddCopyRowButton = true;
            this.dataGrid.ShowDeleteRowButton = true;
            this.dataGrid.Size = new System.Drawing.Size(1136, 590);
            this.dataGrid.TabIndex = 0;
            this.dataGrid.UseEmbeddedNavigator = true;
            this.dataGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.View});
            // 
            // View
            // 
            this.View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.View.FixedLineWidth = 1;
            this.View.GridControl = this.dataGrid;
            this.View.IndicatorWidth = 35;
            this.View.Name = "View";
            this.View.OptionsView.EnableAppearanceEvenRow = true;
            this.View.OptionsView.EnableAppearanceOddRow = true;
            this.View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "FID";
            this.gridColumn1.FieldName = "FID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "船型";
            this.gridColumn2.ColumnEdit = this.ItemLookUp_SHIPMOD;
            this.gridColumn2.FieldName = "SHIP_MOD";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // ItemLookUp_SHIPMOD
            // 
            this.ItemLookUp_SHIPMOD.AutoHeight = false;
            this.ItemLookUp_SHIPMOD.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ItemLookUp_SHIPMOD.DisplayMember = "FName";
            this.ItemLookUp_SHIPMOD.Name = "ItemLookUp_SHIPMOD";
            this.ItemLookUp_SHIPMOD.ValueMember = "FID";
            // 
            // FormMCCL00036
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.ClientSize = new System.Drawing.Size(1140, 768);
            this.Controls.Add(this.efGroupBox2);
            this.Controls.Add(this.efGroupBox1);
            this.Name = "FormMCCL00036";
            this.Text = "焊缝数据维护";
            this.Load += new System.EventHandler(this.FormMCCL00036_Load);
            this.Controls.SetChildIndex(this.efGroupBox1, 0);
            this.Controls.SetChildIndex(this.efGroupBox2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox1)).EndInit();
            this.efGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.but_OK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LookUp_SM.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox2)).EndInit();
            this.efGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemLookUp_SHIPMOD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private EF.EFGroupBox efGroupBox1;
        private EF.EFGroupBox efGroupBox2;
        private EF.EFLabel efLabel1;
        private EF.EFDevLookUpEdit LookUp_SM;
        private EF.EFButton but_OK;
        private EF.EFDevGrid dataGrid;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUp_SHIPMOD;
        private DevExpress.XtraGrid.Views.Grid.GridView View;
    }
}
