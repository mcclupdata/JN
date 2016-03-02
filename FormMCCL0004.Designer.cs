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
            this.CFSelected = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.CRuleNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.efPanel1 = new EF.EFPanel(this.components);
            this.luSHIPNO = new EF.EFDevLookUpEdit(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGrid_WPSSub = new EF.EFDevGrid();
            this.dataGrid = new EF.EFDevGrid();
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
            ((System.ComponentModel.ISupportInitialize)(this.efPanel1)).BeginInit();
            this.efPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.luSHIPNO.Properties)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_WPSSub)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
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
            this.efGroupBox2.Size = new System.Drawing.Size(1280, 558);
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
            this.tabControl1.Size = new System.Drawing.Size(1276, 526);
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
            this.tabPage1.Size = new System.Drawing.Size(1268, 491);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "WPS规程主体";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGrid_WPS
            // 
            this.dataGrid_WPS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid_WPS.IsUseCustomPageBar = true;
            this.dataGrid_WPS.Location = new System.Drawing.Point(4, 44);
            this.dataGrid_WPS.MainView = this.gridView1;
            this.dataGrid_WPS.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGrid_WPS.Name = "dataGrid_WPS";
            this.dataGrid_WPS.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.dataGrid_WPS.Size = new System.Drawing.Size(1260, 442);
            this.dataGrid_WPS.TabIndex = 0;
            this.dataGrid_WPS.UseEmbeddedNavigator = true;
            this.dataGrid_WPS.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.dataGrid_WPS.BindingContextChanged += new System.EventHandler(this.dataGrid_WPS_BindingContextChanged);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
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
            this.RULEName.Caption = "规程名称";
            this.RULEName.FieldName = "RULEName";
            this.RULEName.Name = "RULEName";
            this.RULEName.Visible = true;
            this.RULEName.VisibleIndex = 3;
            // 
            // RuleNum
            // 
            this.RuleNum.Caption = "规程编号";
            this.RuleNum.FieldName = "RuleNum";
            this.RuleNum.Name = "RuleNum";
            this.RuleNum.Visible = true;
            this.RuleNum.VisibleIndex = 4;
            // 
            // GRADE1
            // 
            this.GRADE1.Caption = "材质";
            this.GRADE1.FieldName = "GRADE1";
            this.GRADE1.Name = "GRADE1";
            this.GRADE1.Visible = true;
            this.GRADE1.VisibleIndex = 5;
            // 
            // GRADE2
            // 
            this.GRADE2.Caption = "材质";
            this.GRADE2.FieldName = "GRADE2";
            this.GRADE2.Name = "GRADE2";
            this.GRADE2.Visible = true;
            this.GRADE2.VisibleIndex = 6;
            // 
            // THICK1
            // 
            this.THICK1.Caption = "板厚";
            this.THICK1.FieldName = "THICK1";
            this.THICK1.Name = "THICK1";
            this.THICK1.Visible = true;
            this.THICK1.VisibleIndex = 7;
            // 
            // THICK2
            // 
            this.THICK2.Caption = "板厚";
            this.THICK2.FieldName = "THICK2";
            this.THICK2.Name = "THICK2";
            this.THICK2.Visible = true;
            this.THICK2.VisibleIndex = 8;
            // 
            // THICK3
            // 
            this.THICK3.Caption = "板厚";
            this.THICK3.FieldName = "THICK3";
            this.THICK3.Name = "THICK3";
            this.THICK3.Visible = true;
            this.THICK3.VisibleIndex = 9;
            // 
            // THICK4
            // 
            this.THICK4.Caption = "板厚";
            this.THICK4.FieldName = "THICK4";
            this.THICK4.Name = "THICK4";
            this.THICK4.Visible = true;
            this.THICK4.VisibleIndex = 10;
            // 
            // THICK5
            // 
            this.THICK5.Caption = "板厚";
            this.THICK5.FieldName = "THICK5";
            this.THICK5.Name = "THICK5";
            this.THICK5.Visible = true;
            this.THICK5.VisibleIndex = 11;
            // 
            // THICK6
            // 
            this.THICK6.Caption = "板厚";
            this.THICK6.FieldName = "THICK6";
            this.THICK6.Name = "THICK6";
            this.THICK6.Visible = true;
            this.THICK6.VisibleIndex = 12;
            // 
            // WELD_ANGLE_H_MAX
            // 
            this.WELD_ANGLE_H_MAX.Caption = "焊脚高度上限";
            this.WELD_ANGLE_H_MAX.FieldName = "WELD_ANGLE_H_MAX";
            this.WELD_ANGLE_H_MAX.Name = "WELD_ANGLE_H_MAX";
            this.WELD_ANGLE_H_MAX.Visible = true;
            this.WELD_ANGLE_H_MAX.VisibleIndex = 13;
            // 
            // WELD_ANGLE_H_MIN
            // 
            this.WELD_ANGLE_H_MIN.Caption = "焊脚高度下限";
            this.WELD_ANGLE_H_MIN.FieldName = "WELD_ANGLE_H_MIN";
            this.WELD_ANGLE_H_MIN.Name = "WELD_ANGLE_H_MIN";
            this.WELD_ANGLE_H_MIN.Visible = true;
            this.WELD_ANGLE_H_MIN.VisibleIndex = 14;
            // 
            // WELD_ATTRIB
            // 
            this.WELD_ATTRIB.Caption = "gridColumn1";
            this.WELD_ATTRIB.FieldName = "WELD_ATTRIB";
            this.WELD_ATTRIB.Name = "WELD_ATTRIB";
            this.WELD_ATTRIB.Visible = true;
            this.WELD_ATTRIB.VisibleIndex = 15;
            // 
            // WELD1_CODE
            // 
            this.WELD1_CODE.Caption = "坡口形式";
            this.WELD1_CODE.FieldName = "WELD1_CODE";
            this.WELD1_CODE.Name = "WELD1_CODE";
            this.WELD1_CODE.Visible = true;
            this.WELD1_CODE.VisibleIndex = 16;
            // 
            // WELD2_CODE
            // 
            this.WELD2_CODE.Caption = "坡口角度";
            this.WELD2_CODE.FieldName = "WELD2_CODE";
            this.WELD2_CODE.Name = "WELD2_CODE";
            this.WELD2_CODE.Visible = true;
            this.WELD2_CODE.VisibleIndex = 17;
            // 
            // WELD_TYPE
            // 
            this.WELD_TYPE.Caption = "接头形式";
            this.WELD_TYPE.FieldName = "WELD_TYPE";
            this.WELD_TYPE.Name = "WELD_TYPE";
            this.WELD_TYPE.Visible = true;
            this.WELD_TYPE.VisibleIndex = 18;
            // 
            // WELD_MATERIAL
            // 
            this.WELD_MATERIAL.Caption = "焊接材料";
            this.WELD_MATERIAL.FieldName = "WELD_MATERIAL";
            this.WELD_MATERIAL.Name = "WELD_MATERIAL";
            this.WELD_MATERIAL.Visible = true;
            this.WELD_MATERIAL.VisibleIndex = 19;
            // 
            // WELD_MOD
            // 
            this.WELD_MOD.Caption = "焊接方法";
            this.WELD_MOD.FieldName = "WELD_MOD";
            this.WELD_MOD.Name = "WELD_MOD";
            this.WELD_MOD.Visible = true;
            this.WELD_MOD.VisibleIndex = 20;
            // 
            // WELD_SIN_DOU
            // 
            this.WELD_SIN_DOU.Caption = "单面/双面";
            this.WELD_SIN_DOU.FieldName = "WELD_SIN_DOU";
            this.WELD_SIN_DOU.Name = "WELD_SIN_DOU";
            this.WELD_SIN_DOU.Visible = true;
            this.WELD_SIN_DOU.VisibleIndex = 21;
            // 
            // WELD_MATERIAL_ACT
            // 
            this.WELD_MATERIAL_ACT.Caption = "实际焊材";
            this.WELD_MATERIAL_ACT.FieldName = "WELD_MATERIAL_ACT";
            this.WELD_MATERIAL_ACT.Name = "WELD_MATERIAL_ACT";
            this.WELD_MATERIAL_ACT.Visible = true;
            this.WELD_MATERIAL_ACT.VisibleIndex = 22;
            // 
            // FSHIP_NO
            // 
            this.FSHIP_NO.Caption = "工程号";
            this.FSHIP_NO.FieldName = "FSHIP_NO";
            this.FSHIP_NO.Name = "FSHIP_NO";
            this.FSHIP_NO.Visible = true;
            this.FSHIP_NO.VisibleIndex = 23;
            // 
            // CFSelected
            // 
            this.CFSelected.Caption = "选择";
            this.CFSelected.ColumnEdit = this.repositoryItemCheckEdit1;
            this.CFSelected.FieldName = "FSelected";
            this.CFSelected.Name = "CFSelected";
            this.CFSelected.Visible = true;
            this.CFSelected.VisibleIndex = 1;
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
            this.CRuleNum.VisibleIndex = 2;
            // 
            // efPanel1
            // 
            this.efPanel1.Controls.Add(this.luSHIPNO);
            this.efPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.efPanel1.Location = new System.Drawing.Point(4, 5);
            this.efPanel1.Name = "efPanel1";
            this.efPanel1.Size = new System.Drawing.Size(1260, 39);
            this.efPanel1.TabIndex = 2;
            // 
            // luSHIPNO
            // 
            this.luSHIPNO.Location = new System.Drawing.Point(34, 3);
            this.luSHIPNO.Name = "luSHIPNO";
            this.luSHIPNO.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luSHIPNO.Size = new System.Drawing.Size(377, 28);
            this.luSHIPNO.TabIndex = 1;
            this.luSHIPNO.EditValueChanged += new System.EventHandler(this.luSHIPNO_EditValueChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGrid_WPSSub);
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabPage2.Size = new System.Drawing.Size(1268, 491);
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
            this.dataGrid_WPSSub.Size = new System.Drawing.Size(1260, 481);
            this.dataGrid_WPSSub.TabIndex = 0;
            this.dataGrid_WPSSub.UseEmbeddedNavigator = true;
            // 
            // dataGrid
            // 
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.Location = new System.Drawing.Point(2, 30);
            this.dataGrid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.Size = new System.Drawing.Size(1276, 526);
            this.dataGrid.TabIndex = 0;
            // 
            // FormMCCL0004
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 746);
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
            ((System.ComponentModel.ISupportInitialize)(this.efPanel1)).EndInit();
            this.efPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.luSHIPNO.Properties)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_WPSSub)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn FID;

    }
}