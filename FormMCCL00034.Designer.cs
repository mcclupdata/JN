namespace MC
{
    partial class FormMCCL00034
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.efLabel1 = new EF.EFLabel();
            this.DepartList = new EF.EFDevLookUpEdit(this.components);
            this.efGroupBoxEx1 = new EF.EFGroupBoxEx(this.components);
            this.but_OK = new EF.EFButton();
            this.efGroupBoxEx2 = new EF.EFGroupBoxEx(this.components);
            this.Tabs = new EF.EFSkinTabControl(this.components);
            this.welderPage = new DevExpress.XtraTab.XtraTabPage();
            this.dataGrid = new EF.EFDevGrid();
            this.View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FDepartLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FlibLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FStateItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.leveButton = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.FStateComboBox = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.classPage = new DevExpress.XtraTab.XtraTabPage();
            this.dataGrid2 = new EF.EFDevGrid();
            this.View2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ClassLookUpEdit = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.efPanel1 = new EF.EFPanel(this.components);
            this.but_Ret = new EF.EFButton();
            ((System.ComponentModel.ISupportInitialize)(this.DepartList.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBoxEx1)).BeginInit();
            this.efGroupBoxEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.but_OK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBoxEx2)).BeginInit();
            this.efGroupBoxEx2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Tabs)).BeginInit();
            this.Tabs.SuspendLayout();
            this.welderPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FDepartLookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlibLookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FStateItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leveButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FStateComboBox)).BeginInit();
            this.classPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.View2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClassLookUpEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efPanel1)).BeginInit();
            this.efPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.but_Ret)).BeginInit();
            this.SuspendLayout();
            // 
            // efLabel1
            // 
            this.efLabel1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.efLabel1.Location = new System.Drawing.Point(19, 50);
            this.efLabel1.Name = "efLabel1";
            this.efLabel1.Size = new System.Drawing.Size(57, 28);
            this.efLabel1.TabIndex = 0;
            this.efLabel1.Text = "部门";
            // 
            // DepartList
            // 
            this.DepartList.Location = new System.Drawing.Point(153, 47);
            this.DepartList.Name = "DepartList";
            this.DepartList.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.DepartList.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
            this.DepartList.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.DepartList.Properties.DisplayMember = "FDepartNa";
            this.DepartList.Properties.ValueMember = "FID";
            this.DepartList.Size = new System.Drawing.Size(425, 28);
            this.DepartList.TabIndex = 1;
            this.DepartList.EditValueChanged += new System.EventHandler(this.DepartList_EditValueChanged);
            // 
            // efGroupBoxEx1
            // 
            this.efGroupBoxEx1.Controls.Add(this.but_OK);
            this.efGroupBoxEx1.Controls.Add(this.efLabel1);
            this.efGroupBoxEx1.Controls.Add(this.DepartList);
            this.efGroupBoxEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.efGroupBoxEx1.Location = new System.Drawing.Point(0, 0);
            this.efGroupBoxEx1.Name = "efGroupBoxEx1";
            this.efGroupBoxEx1.Size = new System.Drawing.Size(1024, 100);
            this.efGroupBoxEx1.TabIndex = 5;
            this.efGroupBoxEx1.Text = "部门";
            // 
            // but_OK
            // 
            this.but_OK.Authorizable = false;
            this.but_OK.EnabledEx = true;
            this.but_OK.FnNo = 0;
            this.but_OK.Hint = "";
            this.but_OK.Location = new System.Drawing.Point(627, 50);
            this.but_OK.Name = "but_OK";
            this.but_OK.Size = new System.Drawing.Size(75, 23);
            this.but_OK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.but_OK.TabIndex = 2;
            this.but_OK.Text = "保存";
            this.but_OK.ViewMode = EF.ViewModeEnum.Enable;
            this.but_OK.Click += new System.EventHandler(this.efButton1_Click);
            // 
            // efGroupBoxEx2
            // 
            this.efGroupBoxEx2.Controls.Add(this.Tabs);
            this.efGroupBoxEx2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.efGroupBoxEx2.Location = new System.Drawing.Point(0, 100);
            this.efGroupBoxEx2.Name = "efGroupBoxEx2";
            this.efGroupBoxEx2.Size = new System.Drawing.Size(1024, 596);
            this.efGroupBoxEx2.TabIndex = 6;
            this.efGroupBoxEx2.Text = "数据";
            // 
            // Tabs
            // 
            this.Tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tabs.Location = new System.Drawing.Point(2, 30);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.SelectedTabPage = this.welderPage;
            this.Tabs.ShowTabHeader = DevExpress.Utils.DefaultBoolean.True;
            this.Tabs.Size = new System.Drawing.Size(1020, 564);
            this.Tabs.TabIndex = 1;
            this.Tabs.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.welderPage,
            this.classPage});
            // 
            // welderPage
            // 
            this.welderPage.Controls.Add(this.dataGrid);
            this.welderPage.Name = "welderPage";
            this.welderPage.Size = new System.Drawing.Size(1013, 526);
            this.welderPage.Text = "焊工";
            // 
            // dataGrid
            // 
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.IsUseCustomPageBar = true;
            this.dataGrid.Location = new System.Drawing.Point(0, 0);
            this.dataGrid.MainView = this.View;
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.FDepartLookUpEdit,
            this.FlibLookUpEdit,
            this.FStateComboBox,
            this.leveButton,
            this.FStateItemLookUpEdit1});
            this.dataGrid.ShowAddCopyRowButton = true;
            this.dataGrid.ShowAddRowButton = true;
            this.dataGrid.ShowContextMenuAddCopyNew = false;
            this.dataGrid.ShowDeleteRowButton = true;
            this.dataGrid.Size = new System.Drawing.Size(1013, 526);
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
            this.gridColumn1.Caption = "FID";
            this.gridColumn1.FieldName = "FID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "焊工姓名";
            this.gridColumn2.FieldName = "FName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "焊工工号";
            this.gridColumn3.FieldName = "Fnum";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "部门";
            this.gridColumn4.ColumnEdit = this.FDepartLookUpEdit;
            this.gridColumn4.FieldName = "Fdepart";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // FDepartLookUpEdit
            // 
            this.FDepartLookUpEdit.AutoHeight = false;
            this.FDepartLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FDepartLookUpEdit.DisplayMember = "FDepartNa";
            this.FDepartLookUpEdit.Name = "FDepartLookUpEdit";
            this.FDepartLookUpEdit.ValueMember = "FID";
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "工程队";
            this.gridColumn5.ColumnEdit = this.FlibLookUpEdit;
            this.gridColumn5.FieldName = "FLaborTeamID";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // FlibLookUpEdit
            // 
            this.FlibLookUpEdit.AutoHeight = false;
            this.FlibLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FlibLookUpEdit.DisplayMember = "FName";
            this.FlibLookUpEdit.Name = "FlibLookUpEdit";
            this.FlibLookUpEdit.ValueMember = "FID";
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "身份证";
            this.gridColumn6.FieldName = "FICID";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "状态";
            this.gridColumn7.ColumnEdit = this.FStateItemLookUpEdit1;
            this.gridColumn7.FieldName = "Fstate";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            // 
            // FStateItemLookUpEdit1
            // 
            this.FStateItemLookUpEdit1.AutoHeight = false;
            this.FStateItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FStateItemLookUpEdit1.DisplayMember = "FName";
            this.FStateItemLookUpEdit1.Name = "FStateItemLookUpEdit1";
            this.FStateItemLookUpEdit1.ValueMember = "FID";
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "焊工等级";
            this.gridColumn8.ColumnEdit = this.leveButton;
            this.gridColumn8.FieldName = "FID";
            this.gridColumn8.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            // 
            // leveButton
            // 
            this.leveButton.AutoHeight = false;
            this.leveButton.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "焊接等级", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.leveButton.Name = "leveButton";
            this.leveButton.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.leveButton.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.leveButton_ButtonClick);
            // 
            // FStateComboBox
            // 
            this.FStateComboBox.AutoHeight = false;
            this.FStateComboBox.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FStateComboBox.Items.AddRange(new object[] {
            "0|正常",
            "1|非正常"});
            this.FStateComboBox.Name = "FStateComboBox";
            // 
            // classPage
            // 
            this.classPage.Controls.Add(this.dataGrid2);
            this.classPage.Controls.Add(this.efPanel1);
            this.classPage.Name = "classPage";
            this.classPage.Size = new System.Drawing.Size(1013, 526);
            this.classPage.Text = "焊工等级";
            // 
            // dataGrid2
            // 
            this.dataGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid2.IsUseCustomPageBar = true;
            this.dataGrid2.Location = new System.Drawing.Point(0, 56);
            this.dataGrid2.MainView = this.View2;
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ClassLookUpEdit});
            this.dataGrid2.ShowAddCopyRowButton = true;
            this.dataGrid2.ShowAddRowButton = true;
            this.dataGrid2.ShowContextMenu = true;
            this.dataGrid2.ShowDeleteRowButton = true;
            this.dataGrid2.ShowExportButton = false;
            this.dataGrid2.ShowGroupButton = false;
            this.dataGrid2.Size = new System.Drawing.Size(1013, 470);
            this.dataGrid2.TabIndex = 1;
            this.dataGrid2.UseEmbeddedNavigator = true;
            this.dataGrid2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.View2});
            this.dataGrid2.EF_GridBar_AddRow_Event += new EF.EFDevGrid.EFGridBarClickEvent(this.dataGrid2_EF_GridBar_AddRow_Event);
            // 
            // View2
            // 
            this.View2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11});
            this.View2.FixedLineWidth = 1;
            this.View2.GridControl = this.dataGrid2;
            this.View2.IndicatorWidth = 35;
            this.View2.Name = "View2";
            this.View2.OptionsView.ColumnAutoWidth = false;
            this.View2.OptionsView.EnableAppearanceEvenRow = true;
            this.View2.OptionsView.EnableAppearanceOddRow = true;
            this.View2.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "gridColumn9";
            this.gridColumn9.FieldName = "FID";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.ReadOnly = true;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "等级";
            this.gridColumn10.ColumnEdit = this.ClassLookUpEdit;
            this.gridColumn10.FieldName = "FWELDLEVENID";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 0;
            this.gridColumn10.Width = 482;
            // 
            // ClassLookUpEdit
            // 
            this.ClassLookUpEdit.AutoHeight = false;
            this.ClassLookUpEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ClassLookUpEdit.DisplayMember = "FName";
            this.ClassLookUpEdit.Name = "ClassLookUpEdit";
            this.ClassLookUpEdit.ValueMember = "FID";
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "gridColumn11";
            this.gridColumn11.FieldName = "FWELDERID";
            this.gridColumn11.Name = "gridColumn11";
            // 
            // efPanel1
            // 
            this.efPanel1.Controls.Add(this.but_Ret);
            this.efPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.efPanel1.Location = new System.Drawing.Point(0, 0);
            this.efPanel1.Name = "efPanel1";
            this.efPanel1.Size = new System.Drawing.Size(1013, 56);
            this.efPanel1.TabIndex = 0;
            // 
            // but_Ret
            // 
            this.but_Ret.Authorizable = false;
            this.but_Ret.Dock = System.Windows.Forms.DockStyle.Right;
            this.but_Ret.EnabledEx = true;
            this.but_Ret.FnNo = 0;
            this.but_Ret.Hint = "";
            this.but_Ret.Location = new System.Drawing.Point(938, 0);
            this.but_Ret.Name = "but_Ret";
            this.but_Ret.Size = new System.Drawing.Size(75, 56);
            this.but_Ret.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.but_Ret.TabIndex = 0;
            this.but_Ret.Text = "返回";
            this.but_Ret.ViewMode = EF.ViewModeEnum.Enable;
            this.but_Ret.Click += new System.EventHandler(this.but_Ret_Click);
            // 
            // FormMCCL00034
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.efGroupBoxEx2);
            this.Controls.Add(this.efGroupBoxEx1);
            this.Name = "FormMCCL00034";
            this.Text = "焊工管理";
            this.Load += new System.EventHandler(this.FormMCCL00034_Load);
            this.Controls.SetChildIndex(this.efGroupBoxEx1, 0);
            this.Controls.SetChildIndex(this.efGroupBoxEx2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.DepartList.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBoxEx1)).EndInit();
            this.efGroupBoxEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.but_OK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBoxEx2)).EndInit();
            this.efGroupBoxEx2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Tabs)).EndInit();
            this.Tabs.ResumeLayout(false);
            this.welderPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FDepartLookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlibLookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FStateItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leveButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FStateComboBox)).EndInit();
            this.classPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.View2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClassLookUpEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efPanel1)).EndInit();
            this.efPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.but_Ret)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private EF.EFLabel efLabel1;
        private EF.EFDevLookUpEdit DepartList;
        private EF.EFGroupBoxEx efGroupBoxEx1;
        private EF.EFGroupBoxEx efGroupBoxEx2;
        private EF.EFDevGrid dataGrid;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit FDepartLookUpEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit FlibLookUpEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox FStateComboBox;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit leveButton;
        private DevExpress.XtraGrid.Views.Grid.GridView View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private EF.EFButton but_OK;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit FStateItemLookUpEdit1;
        private EF.EFSkinTabControl Tabs;
        private DevExpress.XtraTab.XtraTabPage welderPage;
        private DevExpress.XtraTab.XtraTabPage classPage;
        private EF.EFDevGrid dataGrid2;
        private EF.EFPanel efPanel1;
        private EF.EFButton but_Ret;
        private DevExpress.XtraGrid.Views.Grid.GridView View2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ClassLookUpEdit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
    }
}
