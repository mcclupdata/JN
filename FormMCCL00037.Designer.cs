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
            this.FID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RULEName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RuleNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GRADE1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GRADE2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.THICK1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.THICK2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.THICK3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.THICK4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.THICK5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.THICK6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WELD_ANGLE_H_MAX = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WELD_ANGLE_H_MIN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WELD_ATTRIB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WELD1_CODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WELD2_CODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WELD_TYPE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WELD_MATERIAL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WELD_MOD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WELD_SIN_DOU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WELD_MATERIAL_ACT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FSHIP_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Fset_Default = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.efGroupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.efGroupBox1.Name = "efGroupBox1";
            this.efGroupBox1.Size = new System.Drawing.Size(747, 54);
            this.efGroupBox1.TabIndex = 4;
            // 
            // butSetDefault
            // 
            this.butSetDefault.Authorizable = false;
            this.butSetDefault.Dock = System.Windows.Forms.DockStyle.Right;
            this.butSetDefault.EnabledEx = true;
            this.butSetDefault.FnNo = 0;
            this.butSetDefault.Hint = "";
            this.butSetDefault.Location = new System.Drawing.Point(641, 23);
            this.butSetDefault.Margin = new System.Windows.Forms.Padding(2);
            this.butSetDefault.Name = "butSetDefault";
            this.butSetDefault.Size = new System.Drawing.Size(52, 29);
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
            this.butUpdate.Location = new System.Drawing.Point(693, 23);
            this.butUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.butUpdate.Name = "butUpdate";
            this.butUpdate.Size = new System.Drawing.Size(52, 29);
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
            this.efLabel1.Location = new System.Drawing.Point(8, 21);
            this.efLabel1.Margin = new System.Windows.Forms.Padding(2);
            this.efLabel1.Name = "efLabel1";
            this.efLabel1.Size = new System.Drawing.Size(202, 25);
            this.efLabel1.TabIndex = 0;
            this.efLabel1.Text = "默认WPS设置";
            // 
            // efGroupBoxEx1
            // 
            this.efGroupBoxEx1.Controls.Add(this.TabControl);
            this.efGroupBoxEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.efGroupBoxEx1.Location = new System.Drawing.Point(0, 54);
            this.efGroupBoxEx1.Margin = new System.Windows.Forms.Padding(2);
            this.efGroupBoxEx1.Name = "efGroupBoxEx1";
            this.efGroupBoxEx1.Size = new System.Drawing.Size(747, 338);
            this.efGroupBoxEx1.TabIndex = 5;
            this.efGroupBoxEx1.Text = "默认WPS集合";
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.tabWPS);
            this.TabControl.Controls.Add(this.tabSubWPS);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Location = new System.Drawing.Point(2, 23);
            this.TabControl.Margin = new System.Windows.Forms.Padding(2);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(743, 313);
            this.TabControl.TabIndex = 0;
            // 
            // tabWPS
            // 
            this.tabWPS.Controls.Add(this.wpsDataGrid);
            this.tabWPS.Location = new System.Drawing.Point(4, 23);
            this.tabWPS.Margin = new System.Windows.Forms.Padding(2);
            this.tabWPS.Name = "tabWPS";
            this.tabWPS.Padding = new System.Windows.Forms.Padding(2);
            this.tabWPS.Size = new System.Drawing.Size(735, 286);
            this.tabWPS.TabIndex = 0;
            this.tabWPS.Text = "WPS规程";
            this.tabWPS.UseVisualStyleBackColor = true;
            // 
            // wpsDataGrid
            // 
            this.wpsDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wpsDataGrid.IsUseCustomPageBar = true;
            this.wpsDataGrid.Location = new System.Drawing.Point(2, 2);
            this.wpsDataGrid.MainView = this.wpsGridView;
            this.wpsDataGrid.Margin = new System.Windows.Forms.Padding(2);
            this.wpsDataGrid.Name = "wpsDataGrid";
            this.wpsDataGrid.Size = new System.Drawing.Size(731, 282);
            this.wpsDataGrid.TabIndex = 0;
            this.wpsDataGrid.UseEmbeddedNavigator = true;
            this.wpsDataGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.wpsGridView});
            // 
            // wpsGridView
            // 
            this.wpsGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.FID,
            this.RULEName,
            this.RuleNum,
            this.GRADE1,
            this.GRADE2,
            this.THICK1,
            this.THICK2,
            this.THICK3,
            this.THICK4,
            this.THICK5,
            this.THICK6,
            this.WELD_ANGLE_H_MAX,
            this.WELD_ANGLE_H_MIN,
            this.WELD_ATTRIB,
            this.WELD1_CODE,
            this.WELD2_CODE,
            this.WELD_TYPE,
            this.WELD_MATERIAL,
            this.WELD_MOD,
            this.WELD_SIN_DOU,
            this.WELD_MATERIAL_ACT,
            this.FSHIP_NO,
            this.Fset_Default});
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
            // FID
            // 
            this.FID.Caption = "FID";
            this.FID.FieldName = "FID";
            this.FID.Name = "FID";
            this.FID.Visible = true;
            this.FID.VisibleIndex = 0;
            // 
            // RULEName
            // 
            this.RULEName.Caption = "规程编号";
            this.RULEName.FieldName = "RULEName";
            this.RULEName.Name = "RULEName";
            this.RULEName.Visible = true;
            this.RULEName.VisibleIndex = 1;
            // 
            // RuleNum
            // 
            this.RuleNum.Caption = "焊道编号";
            this.RuleNum.FieldName = "RuleNum";
            this.RuleNum.Name = "RuleNum";
            this.RuleNum.Visible = true;
            this.RuleNum.VisibleIndex = 2;
            // 
            // GRADE1
            // 
            this.GRADE1.Caption = "材质";
            this.GRADE1.FieldName = "GRADE1";
            this.GRADE1.Name = "GRADE1";
            this.GRADE1.Visible = true;
            this.GRADE1.VisibleIndex = 3;
            // 
            // GRADE2
            // 
            this.GRADE2.Caption = "材质";
            this.GRADE2.FieldName = "GRADE2";
            this.GRADE2.Name = "GRADE2";
            this.GRADE2.Visible = true;
            this.GRADE2.VisibleIndex = 4;
            // 
            // THICK1
            // 
            this.THICK1.Caption = "板厚";
            this.THICK1.FieldName = "THICK1";
            this.THICK1.Name = "THICK1";
            this.THICK1.Visible = true;
            this.THICK1.VisibleIndex = 5;
            // 
            // THICK2
            // 
            this.THICK2.Caption = "板厚";
            this.THICK2.FieldName = "THICK2";
            this.THICK2.Name = "THICK2";
            this.THICK2.Visible = true;
            this.THICK2.VisibleIndex = 6;
            // 
            // THICK3
            // 
            this.THICK3.Caption = "板厚";
            this.THICK3.FieldName = "THICK3";
            this.THICK3.Name = "THICK3";
            this.THICK3.Visible = true;
            this.THICK3.VisibleIndex = 7;
            // 
            // THICK4
            // 
            this.THICK4.Caption = "板厚";
            this.THICK4.FieldName = "THICK4";
            this.THICK4.Name = "THICK4";
            this.THICK4.Visible = true;
            this.THICK4.VisibleIndex = 8;
            // 
            // THICK5
            // 
            this.THICK5.Caption = "板厚";
            this.THICK5.FieldName = "THICK5";
            this.THICK5.Name = "THICK5";
            this.THICK5.Visible = true;
            this.THICK5.VisibleIndex = 9;
            // 
            // THICK6
            // 
            this.THICK6.Caption = "板厚";
            this.THICK6.FieldName = "THICK6";
            this.THICK6.Name = "THICK6";
            this.THICK6.Visible = true;
            this.THICK6.VisibleIndex = 10;
            // 
            // WELD_ANGLE_H_MAX
            // 
            this.WELD_ANGLE_H_MAX.Caption = "焊脚高度上限";
            this.WELD_ANGLE_H_MAX.FieldName = "WELD_ANGLE_H_MAX";
            this.WELD_ANGLE_H_MAX.Name = "WELD_ANGLE_H_MAX";
            this.WELD_ANGLE_H_MAX.Visible = true;
            this.WELD_ANGLE_H_MAX.VisibleIndex = 11;
            // 
            // WELD_ANGLE_H_MIN
            // 
            this.WELD_ANGLE_H_MIN.Caption = "焊脚高度下限";
            this.WELD_ANGLE_H_MIN.FieldName = "WELD_ANGLE_H_MIN";
            this.WELD_ANGLE_H_MIN.Name = "WELD_ANGLE_H_MIN";
            this.WELD_ANGLE_H_MIN.Visible = true;
            this.WELD_ANGLE_H_MIN.VisibleIndex = 12;
            // 
            // WELD_ATTRIB
            // 
            this.WELD_ATTRIB.Caption = "焊接属性";
            this.WELD_ATTRIB.FieldName = "WELD_ATTRIB";
            this.WELD_ATTRIB.Name = "WELD_ATTRIB";
            this.WELD_ATTRIB.Visible = true;
            this.WELD_ATTRIB.VisibleIndex = 13;
            // 
            // WELD1_CODE
            // 
            this.WELD1_CODE.Caption = "坡口代码";
            this.WELD1_CODE.FieldName = "WELD1_CODE";
            this.WELD1_CODE.Name = "WELD1_CODE";
            this.WELD1_CODE.Visible = true;
            this.WELD1_CODE.VisibleIndex = 14;
            // 
            // WELD2_CODE
            // 
            this.WELD2_CODE.Caption = "坡口角度";
            this.WELD2_CODE.FieldName = "WELD2_CODE";
            this.WELD2_CODE.Name = "WELD2_CODE";
            this.WELD2_CODE.Visible = true;
            this.WELD2_CODE.VisibleIndex = 15;
            // 
            // WELD_TYPE
            // 
            this.WELD_TYPE.Caption = "焊接形式";
            this.WELD_TYPE.FieldName = "WELD_TYPE";
            this.WELD_TYPE.Name = "WELD_TYPE";
            this.WELD_TYPE.Visible = true;
            this.WELD_TYPE.VisibleIndex = 16;
            // 
            // WELD_MATERIAL
            // 
            this.WELD_MATERIAL.Caption = "焊接材料";
            this.WELD_MATERIAL.FieldName = "WELD_MATERIAL";
            this.WELD_MATERIAL.Name = "WELD_MATERIAL";
            this.WELD_MATERIAL.Visible = true;
            this.WELD_MATERIAL.VisibleIndex = 17;
            // 
            // WELD_MOD
            // 
            this.WELD_MOD.Caption = "焊接方法";
            this.WELD_MOD.FieldName = "WELD_MOD";
            this.WELD_MOD.Name = "WELD_MOD";
            this.WELD_MOD.Visible = true;
            this.WELD_MOD.VisibleIndex = 18;
            // 
            // WELD_SIN_DOU
            // 
            this.WELD_SIN_DOU.Caption = "单面/双面";
            this.WELD_SIN_DOU.FieldName = "WELD_SIN_DOU";
            this.WELD_SIN_DOU.Name = "WELD_SIN_DOU";
            this.WELD_SIN_DOU.Visible = true;
            this.WELD_SIN_DOU.VisibleIndex = 19;
            // 
            // WELD_MATERIAL_ACT
            // 
            this.WELD_MATERIAL_ACT.Caption = "实际焊材";
            this.WELD_MATERIAL_ACT.FieldName = "WELD_MATERIAL_ACT";
            this.WELD_MATERIAL_ACT.Name = "WELD_MATERIAL_ACT";
            this.WELD_MATERIAL_ACT.Visible = true;
            this.WELD_MATERIAL_ACT.VisibleIndex = 20;
            // 
            // FSHIP_NO
            // 
            this.FSHIP_NO.Caption = "工程号";
            this.FSHIP_NO.FieldName = "FSHIP_NO";
            this.FSHIP_NO.Name = "FSHIP_NO";
            this.FSHIP_NO.Visible = true;
            this.FSHIP_NO.VisibleIndex = 21;
            // 
            // Fset_Default
            // 
            this.Fset_Default.Caption = "设置默认";
            this.Fset_Default.FieldName = "Fset_Default";
            this.Fset_Default.Name = "Fset_Default";
            this.Fset_Default.Visible = true;
            this.Fset_Default.VisibleIndex = 22;
            // 
            // tabSubWPS
            // 
            this.tabSubWPS.Controls.Add(this.SubwpsDataGrid);
            this.tabSubWPS.Location = new System.Drawing.Point(4, 23);
            this.tabSubWPS.Margin = new System.Windows.Forms.Padding(2);
            this.tabSubWPS.Name = "tabSubWPS";
            this.tabSubWPS.Padding = new System.Windows.Forms.Padding(2);
            this.tabSubWPS.Size = new System.Drawing.Size(735, 286);
            this.tabSubWPS.TabIndex = 1;
            this.tabSubWPS.Text = "WPS子规程";
            this.tabSubWPS.UseVisualStyleBackColor = true;
            // 
            // SubwpsDataGrid
            // 
            this.SubwpsDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SubwpsDataGrid.LastPageButtonEnable = false;
            this.SubwpsDataGrid.Location = new System.Drawing.Point(2, 2);
            this.SubwpsDataGrid.MainView = this.SubwpsGridVIew;
            this.SubwpsDataGrid.Margin = new System.Windows.Forms.Padding(2);
            this.SubwpsDataGrid.Name = "SubwpsDataGrid";
            this.SubwpsDataGrid.Size = new System.Drawing.Size(731, 282);
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(747, 438);
            this.Controls.Add(this.efGroupBoxEx1);
            this.Controls.Add(this.efGroupBox1);
            this.Margin = new System.Windows.Forms.Padding(1);
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
        private DevExpress.XtraGrid.Columns.GridColumn FID;
        private DevExpress.XtraGrid.Columns.GridColumn RULEName;
        private DevExpress.XtraGrid.Columns.GridColumn RuleNum;
        private DevExpress.XtraGrid.Columns.GridColumn GRADE1;
        private DevExpress.XtraGrid.Columns.GridColumn GRADE2;
        private DevExpress.XtraGrid.Columns.GridColumn THICK1;
        private DevExpress.XtraGrid.Columns.GridColumn THICK2;
        private DevExpress.XtraGrid.Columns.GridColumn THICK3;
        private DevExpress.XtraGrid.Columns.GridColumn THICK4;
        private DevExpress.XtraGrid.Columns.GridColumn THICK5;
        private DevExpress.XtraGrid.Columns.GridColumn THICK6;
        private DevExpress.XtraGrid.Columns.GridColumn WELD_ANGLE_H_MAX;
        private DevExpress.XtraGrid.Columns.GridColumn WELD_ANGLE_H_MIN;
        private DevExpress.XtraGrid.Columns.GridColumn WELD_ATTRIB;
        private DevExpress.XtraGrid.Columns.GridColumn WELD1_CODE;
        private DevExpress.XtraGrid.Columns.GridColumn WELD2_CODE;
        private DevExpress.XtraGrid.Columns.GridColumn WELD_TYPE;
        private DevExpress.XtraGrid.Columns.GridColumn WELD_MATERIAL;
        private DevExpress.XtraGrid.Columns.GridColumn WELD_MOD;
        private DevExpress.XtraGrid.Columns.GridColumn WELD_SIN_DOU;
        private DevExpress.XtraGrid.Columns.GridColumn WELD_MATERIAL_ACT;
        private DevExpress.XtraGrid.Columns.GridColumn FSHIP_NO;
        private DevExpress.XtraGrid.Columns.GridColumn Fset_Default;
    }
}
