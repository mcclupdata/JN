namespace MC
{
    partial class FormMCCL0004
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
            this.efGroupBox1 = new EF.EFGroupBox(this.components);
            this.butCancel = new EF.EFButton();
            this.butDelete = new EF.EFButton();
            this.efGroupBox2 = new EF.EFGroupBox(this.components);
            this.tabControl1 = new EF.EFTabControl(this.components);
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGrid_WPS = new EF.EFDevGrid();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CFSelected = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.CRuleNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGrid_WPSSub = new EF.EFDevGrid();
            this.dataGrid = new EF.EFDevGrid();
            this.luSHIPNO = new EF.EFDevLookUpEdit(this.components);
            this.efPanel1 = new EF.EFPanel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox1)).BeginInit();
            this.efGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.butCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.butDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox2)).BeginInit();
            this.efGroupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_WPS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_WPSSub)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luSHIPNO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efPanel1)).BeginInit();
            this.efPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // efGroupBox1
            // 
            this.efGroupBox1.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.efGroupBox1.Appearance.Options.UseBackColor = true;
            this.efGroupBox1.Controls.Add(this.butCancel);
            this.efGroupBox1.Controls.Add(this.butDelete);
            this.efGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.efGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.efGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.efGroupBox1.Name = "efGroupBox1";
            this.efGroupBox1.Size = new System.Drawing.Size(1280, 116);
            this.efGroupBox1.TabIndex = 4;
            this.efGroupBox1.Text = "WPS规程管理";
            this.efGroupBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.efGroupBox1_Paint);
            // 
            // butCancel
            // 
            this.butCancel.Authorizable = false;
            this.butCancel.EnabledEx = true;
            this.butCancel.FnNo = 0;
            this.butCancel.Hint = "";
            this.butCancel.Location = new System.Drawing.Point(770, 41);
            this.butCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(166, 75);
            this.butCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.butCancel.TabIndex = 1;
            this.butCancel.Text = "更新";
            this.butCancel.ViewMode = EF.ViewModeEnum.Enable;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butDelete
            // 
            this.butDelete.Authorizable = false;
            this.butDelete.EnabledEx = true;
            this.butDelete.FnNo = 0;
            this.butDelete.Hint = "";
            this.butDelete.Location = new System.Drawing.Point(337, 41);
            this.butDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.butDelete.Name = "butDelete";
            this.butDelete.Size = new System.Drawing.Size(166, 75);
            this.butDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.butDelete.TabIndex = 0;
            this.butDelete.Text = "删除";
            this.butDelete.ViewMode = EF.ViewModeEnum.Enable;
            // 
            // efGroupBox2
            // 
            this.efGroupBox2.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.efGroupBox2.Appearance.Options.UseBackColor = true;
            this.efGroupBox2.Controls.Add(this.tabControl1);
            this.efGroupBox2.Controls.Add(this.dataGrid);
            this.efGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.efGroupBox2.Location = new System.Drawing.Point(0, 116);
            this.efGroupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.efGroupBox2.Name = "efGroupBox2";
            this.efGroupBox2.Size = new System.Drawing.Size(1280, 815);
            this.efGroupBox2.TabIndex = 5;
            this.efGroupBox2.Text = "数据";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(2, 30);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1276, 783);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGrid_WPS);
            this.tabPage1.Controls.Add(this.efPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage1.Size = new System.Drawing.Size(1268, 748);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "WPS规程主体";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGrid_WPS
            // 
            this.dataGrid_WPS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid_WPS.IsUseCustomPageBar = true;
            this.dataGrid_WPS.Location = new System.Drawing.Point(4, 45);
            this.dataGrid_WPS.MainView = this.gridView1;
            this.dataGrid_WPS.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGrid_WPS.Name = "dataGrid_WPS";
            this.dataGrid_WPS.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.dataGrid_WPS.Size = new System.Drawing.Size(1260, 698);
            this.dataGrid_WPS.TabIndex = 0;
            this.dataGrid_WPS.UseEmbeddedNavigator = true;
            this.dataGrid_WPS.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.dataGrid_WPS.BindingContextChanged += new System.EventHandler(this.dataGrid_WPS_BindingContextChanged);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.CFSelected,
            this.CRuleNum});
            this.gridView1.FixedLineWidth = 1;
            this.gridView1.GridControl = this.dataGrid_WPS;
            this.gridView1.IndicatorWidth = 35;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // CFSelected
            // 
            this.CFSelected.Caption = "选择";
            this.CFSelected.ColumnEdit = this.repositoryItemCheckEdit1;
            this.CFSelected.FieldName = "FSelected";
            this.CFSelected.Name = "CFSelected";
            this.CFSelected.Visible = true;
            this.CFSelected.VisibleIndex = 0;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // CRuleNum
            // 
            this.CRuleNum.Caption = "规程编号";
            this.CRuleNum.FieldName = "RuleNum";
            this.CRuleNum.Name = "CRuleNum";
            this.CRuleNum.Visible = true;
            this.CRuleNum.VisibleIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGrid_WPSSub);
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Size = new System.Drawing.Size(1268, 748);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "WPS规程-焊道";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGrid_WPSSub
            // 
            this.dataGrid_WPSSub.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid_WPSSub.IsUseCustomPageBar = true;
            this.dataGrid_WPSSub.Location = new System.Drawing.Point(4, 5);
            this.dataGrid_WPSSub.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGrid_WPSSub.Name = "dataGrid_WPSSub";
            this.dataGrid_WPSSub.Size = new System.Drawing.Size(1260, 738);
            this.dataGrid_WPSSub.TabIndex = 0;
            this.dataGrid_WPSSub.UseEmbeddedNavigator = true;
            // 
            // dataGrid
            // 
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.Location = new System.Drawing.Point(2, 30);
            this.dataGrid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.Size = new System.Drawing.Size(1276, 783);
            this.dataGrid.TabIndex = 0;
            // 
            // luSHIPNO
            // 
            this.luSHIPNO.Location = new System.Drawing.Point(35, 3);
            this.luSHIPNO.Name = "luSHIPNO";
            this.luSHIPNO.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luSHIPNO.Size = new System.Drawing.Size(377, 28);
            this.luSHIPNO.TabIndex = 1;
            this.luSHIPNO.EditValueChanged += new System.EventHandler(this.luSHIPNO_EditValueChanged);
            // 
            // efPanel1
            // 
            this.efPanel1.Controls.Add(this.luSHIPNO);
            this.efPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.efPanel1.Location = new System.Drawing.Point(4, 5);
            this.efPanel1.Name = "efPanel1";
            this.efPanel1.Size = new System.Drawing.Size(1260, 40);
            this.efPanel1.TabIndex = 2;
            // 
            // FormMCCL0004
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 1003);
            this.Controls.Add(this.efGroupBox2);
            this.Controls.Add(this.efGroupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormMCCL0004";
            this.Text = "WPS规程管理";
            this.Load += new System.EventHandler(this.FormMCCL0004_Load);
            this.Controls.SetChildIndex(this.efGroupBox1, 0);
            this.Controls.SetChildIndex(this.efGroupBox2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox1)).EndInit();
            this.efGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.butCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.butDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox2)).EndInit();
            this.efGroupBox2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_WPS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_WPSSub)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luSHIPNO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efPanel1)).EndInit();
            this.efPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private EF.EFGroupBox efGroupBox1;
        private EF.EFGroupBox efGroupBox2;
        private EF.EFDevGrid dataGrid;
        private EF.EFTabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private EF.EFDevGrid dataGrid_WPS;
        private EF.EFDevGrid dataGrid_WPSSub;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn CFSelected;
        private DevExpress.XtraGrid.Columns.GridColumn CRuleNum;
        private EF.EFButton butCancel;
        private EF.EFButton butDelete;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private EF.EFPanel efPanel1;
        private EF.EFDevLookUpEdit luSHIPNO;

    }
}