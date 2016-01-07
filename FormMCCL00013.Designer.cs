namespace MC
{
    partial class FormMCCL00013
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
            this.butOk = new EF.EFButton();
            this.butRead = new EF.EFButton();
            this.but_ChooseFile = new EF.EFButton();
            this.txtFileName = new EF.EFLabelText();
            this.efGroupBox2 = new EF.EFGroupBox(this.components);
            this.dataGrid = new EF.EFDevGrid();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.SHIP_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SHIP_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BLK_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TREE_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WELD_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PART1_NAME2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PART2_NAME2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AS3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BUFF1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.THICK1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.THICK2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WELD1_CODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WELD2_CODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GRADE1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GRADE2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WELD_TYPE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ASS1_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WELD_ANGLE_H = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ASS2_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WELD_COUNT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PART1_TYPE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PART２_TYPE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TIP_ANGLE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WELD_T_LEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WELD_NOTE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WELD_POS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WELD_MOD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RuleNum = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox1)).BeginInit();
            this.efGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.butOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.butRead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_ChooseFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox2)).BeginInit();
            this.efGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // efGroupBox1
            // 
            this.efGroupBox1.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.efGroupBox1.Appearance.Options.UseBackColor = true;
            this.efGroupBox1.Controls.Add(this.butOk);
            this.efGroupBox1.Controls.Add(this.butRead);
            this.efGroupBox1.Controls.Add(this.but_ChooseFile);
            this.efGroupBox1.Controls.Add(this.txtFileName);
            this.efGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.efGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.efGroupBox1.Name = "efGroupBox1";
            this.efGroupBox1.Size = new System.Drawing.Size(893, 47);
            this.efGroupBox1.TabIndex = 4;
            // 
            // butOk
            // 
            this.butOk.Authorizable = false;
            this.butOk.EnabledEx = true;
            this.butOk.FnNo = 0;
            this.butOk.Hint = "";
            this.butOk.Location = new System.Drawing.Point(714, 22);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(97, 23);
            this.butOk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.butOk.TabIndex = 3;
            this.butOk.Text = "确认导入";
            this.butOk.ViewMode = EF.ViewModeEnum.Enable;
            // 
            // butRead
            // 
            this.butRead.Authorizable = false;
            this.butRead.EnabledEx = true;
            this.butRead.FnNo = 0;
            this.butRead.Hint = "";
            this.butRead.Location = new System.Drawing.Point(602, 22);
            this.butRead.Name = "butRead";
            this.butRead.Size = new System.Drawing.Size(93, 23);
            this.butRead.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.butRead.TabIndex = 2;
            this.butRead.Text = "读取数据";
            this.butRead.ViewMode = EF.ViewModeEnum.Enable;
            this.butRead.Click += new System.EventHandler(this.butRead_Click);
            // 
            // but_ChooseFile
            // 
            this.but_ChooseFile.Authorizable = false;
            this.but_ChooseFile.EnabledEx = true;
            this.but_ChooseFile.FnNo = 0;
            this.but_ChooseFile.Hint = "";
            this.but_ChooseFile.Location = new System.Drawing.Point(497, 22);
            this.but_ChooseFile.Name = "but_ChooseFile";
            this.but_ChooseFile.Size = new System.Drawing.Size(93, 23);
            this.but_ChooseFile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.but_ChooseFile.TabIndex = 1;
            this.but_ChooseFile.Text = "选择文件";
            this.but_ChooseFile.ViewMode = EF.ViewModeEnum.Enable;
            this.but_ChooseFile.Click += new System.EventHandler(this.but_ChooseFile_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.BackColor = System.Drawing.Color.Transparent;
            this.txtFileName.EFArrange = EF.ArrangeMode.horizontal;
            this.txtFileName.EFCname = "Ecxel文件地址";
            this.txtFileName.EFEname = null;
            this.txtFileName.EFEnterText = "";
            this.txtFileName.EFLeaveExpression = ".*";
            this.txtFileName.EFLen = 32767;
            this.txtFileName.EFType = EF.ValueType.EFString;
            this.txtFileName.EFUpperCase = false;
            this.txtFileName.Location = new System.Drawing.Point(9, 22);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.ReadOnly = false;
            this.txtFileName.Size = new System.Drawing.Size(465, 22);
            this.txtFileName.TabIndex = 0;
            // 
            // efGroupBox2
            // 
            this.efGroupBox2.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.efGroupBox2.Appearance.Options.UseBackColor = true;
            this.efGroupBox2.Controls.Add(this.dataGrid);
            this.efGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.efGroupBox2.Location = new System.Drawing.Point(0, 47);
            this.efGroupBox2.Name = "efGroupBox2";
            this.efGroupBox2.Size = new System.Drawing.Size(893, 542);
            this.efGroupBox2.TabIndex = 5;
            this.efGroupBox2.Text = "数据";
            // 
            // dataGrid
            // 
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.IsUseCustomPageBar = true;
            this.dataGrid.Location = new System.Drawing.Point(2, 23);
            this.dataGrid.MainView = this.gridView1;
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.Size = new System.Drawing.Size(889, 517);
            this.dataGrid.TabIndex = 0;
            this.dataGrid.UseEmbeddedNavigator = true;
            this.dataGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.SHIP_ID,
            this.SHIP_NO,
            this.BLK_NO,
            this.TREE_NAME,
            this.WELD_NO,
            this.PART1_NAME2,
            this.PART2_NAME2,
            this.AS3,
            this.BUFF1,
            this.THICK1,
            this.THICK2,
            this.WELD1_CODE,
            this.WELD2_CODE,
            this.GRADE1,
            this.GRADE2,
            this.WELD_TYPE,
            this.ASS1_NAME,
            this.WELD_ANGLE_H,
            this.ASS2_NAME,
            this.WELD_COUNT,
            this.PART1_TYPE,
            this.PART２_TYPE,
            this.TIP_ANGLE,
            this.WELD_T_LEN,
            this.WELD_NOTE,
            this.WELD_POS,
            this.WELD_MOD,
            this.RuleNum});
            this.gridView1.FixedLineWidth = 1;
            this.gridView1.GridControl = this.dataGrid;
            this.gridView1.IndicatorWidth = 35;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // SHIP_ID
            // 
            this.SHIP_ID.Caption = "SHIP_ID";
            this.SHIP_ID.CustomizationCaption = "SHIP_ID";
            this.SHIP_ID.FieldName = "SHIP_ID";
            this.SHIP_ID.Name = "SHIP_ID";
            this.SHIP_ID.Visible = true;
            this.SHIP_ID.VisibleIndex = 0;
            // 
            // SHIP_NO
            // 
            this.SHIP_NO.Caption = "SHIP_NO";
            this.SHIP_NO.CustomizationCaption = "SHIP_NO";
            this.SHIP_NO.FieldName = "SHIP_NO";
            this.SHIP_NO.Name = "SHIP_NO";
            this.SHIP_NO.Visible = true;
            this.SHIP_NO.VisibleIndex = 1;
            // 
            // BLK_NO
            // 
            this.BLK_NO.Caption = "BLK_NO";
            this.BLK_NO.CustomizationCaption = "BLK_NO";
            this.BLK_NO.FieldName = "BLK_NO";
            this.BLK_NO.Name = "BLK_NO";
            this.BLK_NO.Visible = true;
            this.BLK_NO.VisibleIndex = 2;
            // 
            // TREE_NAME
            // 
            this.TREE_NAME.Caption = "TREE_NAME";
            this.TREE_NAME.CustomizationCaption = "TREE_NAME";
            this.TREE_NAME.FieldName = "TREE_NAME";
            this.TREE_NAME.Name = "TREE_NAME";
            this.TREE_NAME.Visible = true;
            this.TREE_NAME.VisibleIndex = 3;
            // 
            // WELD_NO
            // 
            this.WELD_NO.Caption = "WELD_NO";
            this.WELD_NO.CustomizationCaption = "WELD_NO";
            this.WELD_NO.FieldName = "WELD_NO";
            this.WELD_NO.Name = "WELD_NO";
            this.WELD_NO.Visible = true;
            this.WELD_NO.VisibleIndex = 4;
            // 
            // PART1_NAME2
            // 
            this.PART1_NAME2.Caption = "PART1_NAME2";
            this.PART1_NAME2.CustomizationCaption = "PART1_NAME2";
            this.PART1_NAME2.FieldName = "PART1_NAME2";
            this.PART1_NAME2.Name = "PART1_NAME2";
            this.PART1_NAME2.Visible = true;
            this.PART1_NAME2.VisibleIndex = 5;
            // 
            // PART2_NAME2
            // 
            this.PART2_NAME2.Caption = "PART2_NAME2";
            this.PART2_NAME2.CustomizationCaption = "PART2_NAME2";
            this.PART2_NAME2.FieldName = "PART2_NAME2";
            this.PART2_NAME2.Name = "PART2_NAME2";
            this.PART2_NAME2.Visible = true;
            this.PART2_NAME2.VisibleIndex = 6;
            // 
            // AS3
            // 
            this.AS3.Caption = "AS3";
            this.AS3.CustomizationCaption = "AS3";
            this.AS3.FieldName = "AS3";
            this.AS3.Name = "AS3";
            this.AS3.Visible = true;
            this.AS3.VisibleIndex = 7;
            // 
            // BUFF1
            // 
            this.BUFF1.Caption = "BUFF1";
            this.BUFF1.CustomizationCaption = "BUFF1";
            this.BUFF1.FieldName = "BUFF1";
            this.BUFF1.Name = "BUFF1";
            this.BUFF1.Visible = true;
            this.BUFF1.VisibleIndex = 8;
            // 
            // THICK1
            // 
            this.THICK1.Caption = "THICK1";
            this.THICK1.CustomizationCaption = "THICK1";
            this.THICK1.FieldName = "THICK1";
            this.THICK1.Name = "THICK1";
            this.THICK1.Visible = true;
            this.THICK1.VisibleIndex = 9;
            // 
            // THICK2
            // 
            this.THICK2.Caption = "THICK2";
            this.THICK2.CustomizationCaption = "THICK2";
            this.THICK2.FieldName = "THICK2";
            this.THICK2.Name = "THICK2";
            this.THICK2.Visible = true;
            this.THICK2.VisibleIndex = 10;
            // 
            // WELD1_CODE
            // 
            this.WELD1_CODE.Caption = "WELD1_CODE";
            this.WELD1_CODE.CustomizationCaption = "WELD1_CODE";
            this.WELD1_CODE.FieldName = "WELD1_CODE";
            this.WELD1_CODE.Name = "WELD1_CODE";
            this.WELD1_CODE.Visible = true;
            this.WELD1_CODE.VisibleIndex = 11;
            // 
            // WELD2_CODE
            // 
            this.WELD2_CODE.Caption = "WELD2_CODE";
            this.WELD2_CODE.CustomizationCaption = "WELD2_CODE";
            this.WELD2_CODE.FieldName = "WELD2_CODE";
            this.WELD2_CODE.Name = "WELD2_CODE";
            this.WELD2_CODE.Visible = true;
            this.WELD2_CODE.VisibleIndex = 12;
            // 
            // GRADE1
            // 
            this.GRADE1.Caption = "GRADE1";
            this.GRADE1.CustomizationCaption = "GRADE1";
            this.GRADE1.FieldName = "GRADE1";
            this.GRADE1.Name = "GRADE1";
            this.GRADE1.Visible = true;
            this.GRADE1.VisibleIndex = 13;
            // 
            // GRADE2
            // 
            this.GRADE2.Caption = "GRADE2";
            this.GRADE2.CustomizationCaption = "GRADE2";
            this.GRADE2.FieldName = "GRADE2";
            this.GRADE2.Name = "GRADE2";
            this.GRADE2.Visible = true;
            this.GRADE2.VisibleIndex = 14;
            // 
            // WELD_TYPE
            // 
            this.WELD_TYPE.Caption = "WELD_TYPE";
            this.WELD_TYPE.CustomizationCaption = "WELD_TYPE";
            this.WELD_TYPE.FieldName = "WELD_TYPE";
            this.WELD_TYPE.Name = "WELD_TYPE";
            this.WELD_TYPE.Visible = true;
            this.WELD_TYPE.VisibleIndex = 15;
            // 
            // ASS1_NAME
            // 
            this.ASS1_NAME.Caption = "ASS1_NAME";
            this.ASS1_NAME.CustomizationCaption = "ASS1_NAME";
            this.ASS1_NAME.FieldName = "ASS1_NAME";
            this.ASS1_NAME.Name = "ASS1_NAME";
            this.ASS1_NAME.Visible = true;
            this.ASS1_NAME.VisibleIndex = 16;
            // 
            // WELD_ANGLE_H
            // 
            this.WELD_ANGLE_H.Caption = "WELD_ANGLE_H";
            this.WELD_ANGLE_H.CustomizationCaption = "WELD_ANGLE_H";
            this.WELD_ANGLE_H.FieldName = "WELD_ANGLE_H";
            this.WELD_ANGLE_H.Name = "WELD_ANGLE_H";
            this.WELD_ANGLE_H.Visible = true;
            this.WELD_ANGLE_H.VisibleIndex = 17;
            // 
            // ASS2_NAME
            // 
            this.ASS2_NAME.Caption = "ASS2_NAME";
            this.ASS2_NAME.CustomizationCaption = "ASS2_NAME";
            this.ASS2_NAME.FieldName = "ASS2_NAME";
            this.ASS2_NAME.Name = "ASS2_NAME";
            this.ASS2_NAME.Visible = true;
            this.ASS2_NAME.VisibleIndex = 18;
            // 
            // WELD_COUNT
            // 
            this.WELD_COUNT.Caption = "WELD_COUNT";
            this.WELD_COUNT.CustomizationCaption = "WELD_COUNT";
            this.WELD_COUNT.FieldName = "WELD_COUNT";
            this.WELD_COUNT.Name = "WELD_COUNT";
            this.WELD_COUNT.Visible = true;
            this.WELD_COUNT.VisibleIndex = 19;
            // 
            // PART1_TYPE
            // 
            this.PART1_TYPE.Caption = "PART1_TYPE";
            this.PART1_TYPE.CustomizationCaption = "PART1_TYPE";
            this.PART1_TYPE.FieldName = "PART1_TYPE";
            this.PART1_TYPE.Name = "PART1_TYPE";
            this.PART1_TYPE.Visible = true;
            this.PART1_TYPE.VisibleIndex = 20;
            // 
            // PART２_TYPE
            // 
            this.PART２_TYPE.Caption = "PART２_TYPE";
            this.PART２_TYPE.CustomizationCaption = "PART２_TYPE";
            this.PART２_TYPE.FieldName = "PART２_TYPE";
            this.PART２_TYPE.Name = "PART２_TYPE";
            this.PART２_TYPE.Visible = true;
            this.PART２_TYPE.VisibleIndex = 21;
            // 
            // TIP_ANGLE
            // 
            this.TIP_ANGLE.Caption = "TIP_ANGLE";
            this.TIP_ANGLE.CustomizationCaption = "TIP_ANGLE";
            this.TIP_ANGLE.FieldName = "TIP_ANGLE";
            this.TIP_ANGLE.Name = "TIP_ANGLE";
            this.TIP_ANGLE.Visible = true;
            this.TIP_ANGLE.VisibleIndex = 22;
            // 
            // WELD_T_LEN
            // 
            this.WELD_T_LEN.Caption = "WELD_T_LEN";
            this.WELD_T_LEN.CustomizationCaption = "WELD_T_LEN";
            this.WELD_T_LEN.FieldName = "WELD_T_LEN";
            this.WELD_T_LEN.Name = "WELD_T_LEN";
            this.WELD_T_LEN.Visible = true;
            this.WELD_T_LEN.VisibleIndex = 23;
            // 
            // WELD_NOTE
            // 
            this.WELD_NOTE.Caption = "WELD_NOTE";
            this.WELD_NOTE.CustomizationCaption = "WELD_NOTE";
            this.WELD_NOTE.FieldName = "WELD_NOTE";
            this.WELD_NOTE.Name = "WELD_NOTE";
            this.WELD_NOTE.Visible = true;
            this.WELD_NOTE.VisibleIndex = 24;
            // 
            // WELD_POS
            // 
            this.WELD_POS.Caption = "WELD_POS";
            this.WELD_POS.CustomizationCaption = "WELD_POS";
            this.WELD_POS.FieldName = "WELD_POS";
            this.WELD_POS.Name = "WELD_POS";
            this.WELD_POS.Visible = true;
            this.WELD_POS.VisibleIndex = 25;
            // 
            // WELD_MOD
            // 
            this.WELD_MOD.Caption = "WELD_MOD";
            this.WELD_MOD.CustomizationCaption = "WELD_MOD";
            this.WELD_MOD.FieldName = "WELD_MOD";
            this.WELD_MOD.Name = "WELD_MOD";
            this.WELD_MOD.Visible = true;
            this.WELD_MOD.VisibleIndex = 26;
            // 
            // RuleNum
            // 
            this.RuleNum.Caption = "RuleNum";
            this.RuleNum.CustomizationCaption = "RuleNum";
            this.RuleNum.FieldName = "RuleNum";
            this.RuleNum.Name = "RuleNum";
            this.RuleNum.Visible = true;
            this.RuleNum.VisibleIndex = 27;
            // 
            // FormMCCL00013
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 635);
            this.Controls.Add(this.efGroupBox2);
            this.Controls.Add(this.efGroupBox1);
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "FormMCCL00013";
            this.Text = "焊缝数据批量导入";
            this.Load += new System.EventHandler(this.FormMCCL00013_Load);
            this.Controls.SetChildIndex(this.efGroupBox1, 0);
            this.Controls.SetChildIndex(this.efGroupBox2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox1)).EndInit();
            this.efGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.butOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.butRead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_ChooseFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox2)).EndInit();
            this.efGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private EF.EFGroupBox efGroupBox1;
        private EF.EFLabelText txtFileName;
        private EF.EFGroupBox efGroupBox2;
        private EF.EFDevGrid dataGrid;
        private EF.EFButton but_ChooseFile;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private EF.EFButton butOk;
        private EF.EFButton butRead;
        private DevExpress.XtraGrid.Columns.GridColumn SHIP_ID;
        private DevExpress.XtraGrid.Columns.GridColumn SHIP_NO;
        private DevExpress.XtraGrid.Columns.GridColumn BLK_NO;
        private DevExpress.XtraGrid.Columns.GridColumn TREE_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn WELD_NO;
        private DevExpress.XtraGrid.Columns.GridColumn PART1_NAME2;
        private DevExpress.XtraGrid.Columns.GridColumn PART2_NAME2;
        private DevExpress.XtraGrid.Columns.GridColumn AS3;
        private DevExpress.XtraGrid.Columns.GridColumn BUFF1;
        private DevExpress.XtraGrid.Columns.GridColumn THICK1;
        private DevExpress.XtraGrid.Columns.GridColumn THICK2;
        private DevExpress.XtraGrid.Columns.GridColumn WELD1_CODE;
        private DevExpress.XtraGrid.Columns.GridColumn WELD2_CODE;
        private DevExpress.XtraGrid.Columns.GridColumn GRADE1;
        private DevExpress.XtraGrid.Columns.GridColumn GRADE2;
        private DevExpress.XtraGrid.Columns.GridColumn WELD_TYPE;
        private DevExpress.XtraGrid.Columns.GridColumn ASS1_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn WELD_ANGLE_H;
        private DevExpress.XtraGrid.Columns.GridColumn ASS2_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn WELD_COUNT;
        private DevExpress.XtraGrid.Columns.GridColumn PART1_TYPE;
        private DevExpress.XtraGrid.Columns.GridColumn PART２_TYPE;
        private DevExpress.XtraGrid.Columns.GridColumn TIP_ANGLE;
        private DevExpress.XtraGrid.Columns.GridColumn WELD_T_LEN;
        private DevExpress.XtraGrid.Columns.GridColumn WELD_NOTE;
        private DevExpress.XtraGrid.Columns.GridColumn WELD_POS;
        private DevExpress.XtraGrid.Columns.GridColumn WELD_MOD;
        private DevExpress.XtraGrid.Columns.GridColumn RuleNum;

    }
}