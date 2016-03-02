namespace MC
{
    partial class FormMCCL00044
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
            this.efGroupBoxEx1 = new EF.EFGroupBoxEx(this.components);
            this.efPanel2 = new EF.EFPanel(this.components);
            this.dataGrid = new EF.EFDevGrid();
            this.View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.efPanel1 = new EF.EFPanel(this.components);
            this.but_OK = new EF.EFButton();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBoxEx1)).BeginInit();
            this.efGroupBoxEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.efPanel2)).BeginInit();
            this.efPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efPanel1)).BeginInit();
            this.efPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.but_OK)).BeginInit();
            this.SuspendLayout();
            // 
            // efGroupBoxEx1
            // 
            this.efGroupBoxEx1.Controls.Add(this.efPanel2);
            this.efGroupBoxEx1.Controls.Add(this.efPanel1);
            this.efGroupBoxEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.efGroupBoxEx1.Location = new System.Drawing.Point(0, 0);
            this.efGroupBoxEx1.Name = "efGroupBoxEx1";
            this.efGroupBoxEx1.Size = new System.Drawing.Size(1024, 696);
            this.efGroupBoxEx1.TabIndex = 4;
            this.efGroupBoxEx1.Text = "焊接位置";
            // 
            // efPanel2
            // 
            this.efPanel2.Controls.Add(this.dataGrid);
            this.efPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.efPanel2.Location = new System.Drawing.Point(2, 82);
            this.efPanel2.Name = "efPanel2";
            this.efPanel2.Size = new System.Drawing.Size(1020, 612);
            this.efPanel2.TabIndex = 2;
            // 
            // dataGrid
            // 
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.IsUseCustomPageBar = true;
            this.dataGrid.Location = new System.Drawing.Point(0, 0);
            this.dataGrid.MainView = this.View;
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ShowAddCopyRowButton = true;
            this.dataGrid.ShowAddRowButton = true;
            this.dataGrid.ShowContextMenu = true;
            this.dataGrid.ShowDeleteRowButton = true;
            this.dataGrid.Size = new System.Drawing.Size(1020, 612);
            this.dataGrid.TabIndex = 0;
            this.dataGrid.UseEmbeddedNavigator = true;
            this.dataGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.View});
            // 
            // View
            // 
            this.View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8});
            this.View.FixedLineWidth = 1;
            this.View.GridControl = this.dataGrid;
            this.View.IndicatorWidth = 35;
            this.View.Name = "View";
            this.View.OptionsView.ColumnAutoWidth = false;
            this.View.OptionsView.EnableAppearanceEvenRow = true;
            this.View.OptionsView.EnableAppearanceOddRow = true;
            this.View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "ID";
            this.gridColumn1.FieldName = "FID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "位置";
            this.gridColumn2.FieldName = "WELD_POST";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "代号";
            this.gridColumn3.FieldName = "WELD_TYPE";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "最小轴线倾斜角";
            this.gridColumn4.FieldName = "ANGEL3_MIN";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "最大轴线倾斜角";
            this.gridColumn5.FieldName = "ANGEL3_MAX";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "最小面旋转角";
            this.gridColumn6.FieldName = "ANGEL2_MIN";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            // 
            // efPanel1
            // 
            this.efPanel1.Controls.Add(this.but_OK);
            this.efPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.efPanel1.Location = new System.Drawing.Point(2, 30);
            this.efPanel1.Name = "efPanel1";
            this.efPanel1.Size = new System.Drawing.Size(1020, 52);
            this.efPanel1.TabIndex = 1;
            // 
            // but_OK
            // 
            this.but_OK.Authorizable = false;
            this.but_OK.Dock = System.Windows.Forms.DockStyle.Right;
            this.but_OK.EnabledEx = true;
            this.but_OK.FnNo = 0;
            this.but_OK.Hint = "";
            this.but_OK.Location = new System.Drawing.Point(917, 0);
            this.but_OK.Name = "but_OK";
            this.but_OK.Size = new System.Drawing.Size(103, 52);
            this.but_OK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.but_OK.TabIndex = 0;
            this.but_OK.Text = "更新";
            this.but_OK.ViewMode = EF.ViewModeEnum.Enable;
            this.but_OK.Click += new System.EventHandler(this.but_OK_Click);
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "最大面旋转角";
            this.gridColumn7.FieldName = "ANGEL2_MAX";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "连接形式";
            this.gridColumn8.FieldName = "WELD_LINK_TYPE";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            // 
            // FormMCCL00044
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.efGroupBoxEx1);
            this.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.Name = "FormMCCL00044";
            this.Text = "焊接位置基础信息维护";
            this.Load += new System.EventHandler(this.FormMCCL00035_Load);
            this.Controls.SetChildIndex(this.efGroupBoxEx1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBoxEx1)).EndInit();
            this.efGroupBoxEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.efPanel2)).EndInit();
            this.efPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efPanel1)).EndInit();
            this.efPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.but_OK)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private EF.EFGroupBoxEx efGroupBoxEx1;
        private EF.EFDevGrid dataGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private EF.EFPanel efPanel2;
        private EF.EFPanel efPanel1;
        private EF.EFButton but_OK;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
    }
}
