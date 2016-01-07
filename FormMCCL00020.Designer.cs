namespace MC
{
    partial class FormMCCL00020
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
            this.dataGrid = new EF.EFDevGrid();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CRuleTrunn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.but_Choose = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.CRuleNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CFID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CGRADE1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CGRADE2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CWELD_ATTRIB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CWELD_MATERIAL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CWELD_TYPE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CWELD_MOD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CWELD1_CODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CWELD2_CODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CTHICK1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CTHICK2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.butCancel = new EF.EFButton();
            this.butOK = new EF.EFButton();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox1)).BeginInit();
            this.efGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_Choose)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.butCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.butOK)).BeginInit();
            this.SuspendLayout();
            // 
            // efGroupBox1
            // 
            this.efGroupBox1.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.efGroupBox1.Appearance.Options.UseBackColor = true;
            this.efGroupBox1.Controls.Add(this.dataGrid);
            this.efGroupBox1.Controls.Add(this.panel1);
            this.efGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.efGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.efGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.efGroupBox1.Name = "efGroupBox1";
            this.efGroupBox1.Size = new System.Drawing.Size(1463, 972);
            this.efGroupBox1.TabIndex = 4;
            this.efGroupBox1.Text = "WPS主规程";
            // 
            // dataGrid
            // 
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.IsUseCustomPageBar = true;
            this.dataGrid.Location = new System.Drawing.Point(2, 96);
            this.dataGrid.MainView = this.gridView1;
            this.dataGrid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.but_Choose});
            this.dataGrid.Size = new System.Drawing.Size(1459, 874);
            this.dataGrid.TabIndex = 0;
            this.dataGrid.UseEmbeddedNavigator = true;
            this.dataGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.CRuleTrunn,
            this.CRuleNum,
            this.CFID,
            this.CGRADE1,
            this.CGRADE2,
            this.CWELD_ATTRIB,
            this.CWELD_MATERIAL,
            this.CWELD_TYPE,
            this.CWELD_MOD,
            this.CWELD1_CODE,
            this.CWELD2_CODE,
            this.CTHICK1,
            this.CTHICK2});
            this.gridView1.FixedLineWidth = 1;
            this.gridView1.GridControl = this.dataGrid;
            this.gridView1.IndicatorWidth = 35;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // CRuleTrunn
            // 
            this.CRuleTrunn.Caption = "选择";
            this.CRuleTrunn.ColumnEdit = this.but_Choose;
            this.CRuleTrunn.CustomizationCaption = "选择";
            this.CRuleTrunn.FieldName = "but_Choose";
            this.CRuleTrunn.Name = "CRuleTrunn";
            this.CRuleTrunn.OptionsColumn.ReadOnly = true;
            this.CRuleTrunn.Visible = true;
            this.CRuleTrunn.VisibleIndex = 0;
            // 
            // but_Choose
            // 
            this.but_Choose.AutoHeight = false;
            this.but_Choose.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.but_Choose.Name = "but_Choose";
            // 
            // CRuleNum
            // 
            this.CRuleNum.Caption = "规程编号";
            this.CRuleNum.CustomizationCaption = "规程编号";
            this.CRuleNum.FieldName = "RuleNum";
            this.CRuleNum.Name = "CRuleNum";
            this.CRuleNum.OptionsColumn.AllowEdit = false;
            this.CRuleNum.Visible = true;
            this.CRuleNum.VisibleIndex = 1;
            // 
            // CFID
            // 
            this.CFID.Caption = "FID";
            this.CFID.CustomizationCaption = "FID";
            this.CFID.FieldName = "FID";
            this.CFID.Name = "CFID";
            this.CFID.OptionsColumn.AllowEdit = false;
            this.CFID.Visible = true;
            this.CFID.VisibleIndex = 2;
            // 
            // CGRADE1
            // 
            this.CGRADE1.Caption = "适用板材1材质";
            this.CGRADE1.CustomizationCaption = "适用板材1材质";
            this.CGRADE1.FieldName = "GRADE1";
            this.CGRADE1.Name = "CGRADE1";
            this.CGRADE1.OptionsColumn.AllowEdit = false;
            this.CGRADE1.Visible = true;
            this.CGRADE1.VisibleIndex = 3;
            // 
            // CGRADE2
            // 
            this.CGRADE2.Caption = "适用板材2材质";
            this.CGRADE2.CustomizationCaption = "适用板材2材质";
            this.CGRADE2.FieldName = "GRADE2";
            this.CGRADE2.Name = "CGRADE2";
            this.CGRADE2.Visible = true;
            this.CGRADE2.VisibleIndex = 4;
            // 
            // CWELD_ATTRIB
            // 
            this.CWELD_ATTRIB.Caption = "焊接位置（姿态）";
            this.CWELD_ATTRIB.CustomizationCaption = "焊接位置（姿态）";
            this.CWELD_ATTRIB.FieldName = "WELD_ATTRIB";
            this.CWELD_ATTRIB.Name = "CWELD_ATTRIB";
            this.CWELD_ATTRIB.Visible = true;
            this.CWELD_ATTRIB.VisibleIndex = 5;
            // 
            // CWELD_MATERIAL
            // 
            this.CWELD_MATERIAL.Caption = "焊接材料";
            this.CWELD_MATERIAL.CustomizationCaption = "焊接材料";
            this.CWELD_MATERIAL.FieldName = "WELD_MATERIAL";
            this.CWELD_MATERIAL.Name = "CWELD_MATERIAL";
            this.CWELD_MATERIAL.Visible = true;
            this.CWELD_MATERIAL.VisibleIndex = 6;
            // 
            // CWELD_TYPE
            // 
            this.CWELD_TYPE.Caption = "接头形式";
            this.CWELD_TYPE.CustomizationCaption = "接头形式";
            this.CWELD_TYPE.FieldName = "WELD_TYPE";
            this.CWELD_TYPE.Name = "CWELD_TYPE";
            this.CWELD_TYPE.Visible = true;
            this.CWELD_TYPE.VisibleIndex = 7;
            // 
            // CWELD_MOD
            // 
            this.CWELD_MOD.Caption = "焊接方法";
            this.CWELD_MOD.CustomizationCaption = "焊接方法";
            this.CWELD_MOD.FieldName = "WELD_MOD";
            this.CWELD_MOD.Name = "CWELD_MOD";
            this.CWELD_MOD.Visible = true;
            this.CWELD_MOD.VisibleIndex = 8;
            // 
            // CWELD1_CODE
            // 
            this.CWELD1_CODE.Caption = "坡口形式";
            this.CWELD1_CODE.CustomizationCaption = "坡口形式";
            this.CWELD1_CODE.FieldName = "WELD1_CODE";
            this.CWELD1_CODE.Name = "CWELD1_CODE";
            this.CWELD1_CODE.Visible = true;
            this.CWELD1_CODE.VisibleIndex = 9;
            // 
            // CWELD2_CODE
            // 
            this.CWELD2_CODE.Caption = "坡口角度";
            this.CWELD2_CODE.CustomizationCaption = "坡口角度";
            this.CWELD2_CODE.FieldName = "WELD2_CODE";
            this.CWELD2_CODE.Name = "CWELD2_CODE";
            this.CWELD2_CODE.Visible = true;
            this.CWELD2_CODE.VisibleIndex = 10;
            // 
            // CTHICK1
            // 
            this.CTHICK1.Caption = "厚度上限";
            this.CTHICK1.CustomizationCaption = "厚度上限";
            this.CTHICK1.FieldName = "THICK1";
            this.CTHICK1.Name = "CTHICK1";
            this.CTHICK1.Visible = true;
            this.CTHICK1.VisibleIndex = 11;
            // 
            // CTHICK2
            // 
            this.CTHICK2.Caption = "厚度下限";
            this.CTHICK2.CustomizationCaption = "厚度下限";
            this.CTHICK2.FieldName = "THICK2";
            this.CTHICK2.Name = "CTHICK2";
            this.CTHICK2.Visible = true;
            this.CTHICK2.VisibleIndex = 12;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.butCancel);
            this.panel1.Controls.Add(this.butOK);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(2, 30);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1459, 66);
            this.panel1.TabIndex = 1;
            // 
            // butCancel
            // 
            this.butCancel.Authorizable = false;
            this.butCancel.EnabledEx = true;
            this.butCancel.FnNo = 0;
            this.butCancel.Hint = "";
            this.butCancel.Location = new System.Drawing.Point(644, 6);
            this.butCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(161, 57);
            this.butCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.butCancel.TabIndex = 1;
            this.butCancel.Text = "取消";
            this.butCancel.ViewMode = EF.ViewModeEnum.Enable;
            // 
            // butOK
            // 
            this.butOK.Authorizable = false;
            this.butOK.EnabledEx = true;
            this.butOK.FnNo = 0;
            this.butOK.Hint = "";
            this.butOK.Location = new System.Drawing.Point(276, 5);
            this.butOK.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(161, 57);
            this.butOK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.butOK.TabIndex = 0;
            this.butOK.Text = "确定";
            this.butOK.ViewMode = EF.ViewModeEnum.Enable;
            // 
            // FormMCCL00020
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1463, 1044);
            this.Controls.Add(this.efGroupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormMCCL00020";
            this.Text = "选择规程";
            this.Controls.SetChildIndex(this.efGroupBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox1)).EndInit();
            this.efGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_Choose)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.butCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.butOK)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private EF.EFGroupBox efGroupBox1;
        private EF.EFDevGrid dataGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn CRuleTrunn;
        private DevExpress.XtraGrid.Columns.GridColumn CRuleNum;
        private DevExpress.XtraGrid.Columns.GridColumn CFID;
        private DevExpress.XtraGrid.Columns.GridColumn CGRADE1;
        private DevExpress.XtraGrid.Columns.GridColumn CGRADE2;
        private DevExpress.XtraGrid.Columns.GridColumn CWELD_ATTRIB;
        private DevExpress.XtraGrid.Columns.GridColumn CWELD_MATERIAL;
        private DevExpress.XtraGrid.Columns.GridColumn CWELD_TYPE;
        private DevExpress.XtraGrid.Columns.GridColumn CWELD_MOD;
        private DevExpress.XtraGrid.Columns.GridColumn CWELD1_CODE;
        private DevExpress.XtraGrid.Columns.GridColumn CWELD2_CODE;
        private DevExpress.XtraGrid.Columns.GridColumn CTHICK1;
        private DevExpress.XtraGrid.Columns.GridColumn CTHICK2;
        private System.Windows.Forms.Panel panel1;
        private EF.EFButton butCancel;
        private EF.EFButton butOK;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit but_Choose;

    }
}