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
            this.FID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SHIP_MOD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ItemLookUp_SHIPMOD = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
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
            this.PART2_TYPE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TIP_ANGLE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WELD_T_LEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ANGEL1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ANGEL2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ANGEL3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WELD_TURN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WELD_NOTE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WELD_POS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WELD_MOD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RuleNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ISCONTROL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FParentID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FNewName = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.efGroupBox1.Size = new System.Drawing.Size(1140, 101);
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
            this.LookUp_SM.Location = new System.Drawing.Point(89, 49);
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
            this.efLabel1.Location = new System.Drawing.Point(11, 49);
            this.efLabel1.Name = "efLabel1";
            this.efLabel1.Size = new System.Drawing.Size(44, 27);
            this.efLabel1.TabIndex = 0;
            this.efLabel1.Text = "船型";
            // 
            // efGroupBox2
            // 
            this.efGroupBox2.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.efGroupBox2.Appearance.Options.UseBackColor = true;
            this.efGroupBox2.Controls.Add(this.dataGrid);
            this.efGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.efGroupBox2.Location = new System.Drawing.Point(0, 101);
            this.efGroupBox2.Name = "efGroupBox2";
            this.efGroupBox2.Size = new System.Drawing.Size(1140, 573);
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
            this.dataGrid.Size = new System.Drawing.Size(1136, 541);
            this.dataGrid.TabIndex = 0;
            this.dataGrid.UseEmbeddedNavigator = true;
            this.dataGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.View});
            // 
            // View
            // 
            this.View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.FID,
            this.SHIP_MOD,
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
            this.PART2_TYPE,
            this.TIP_ANGLE,
            this.WELD_T_LEN,
            this.ANGEL1,
            this.ANGEL2,
            this.ANGEL3,
            this.WELD_TURN,
            this.WELD_NOTE,
            this.WELD_POS,
            this.WELD_MOD,
            this.RuleNum,
            this.ISCONTROL,
            this.FParentID,
            this.FNewName});
            this.View.FixedLineWidth = 1;
            this.View.GridControl = this.dataGrid;
            this.View.IndicatorWidth = 35;
            this.View.Name = "View";
            this.View.OptionsView.EnableAppearanceEvenRow = true;
            this.View.OptionsView.EnableAppearanceOddRow = true;
            this.View.OptionsView.ShowGroupPanel = false;
            // 
            // FID
            // 
            this.FID.Caption = "FID";
            this.FID.FieldName = "FID";
            this.FID.Name = "FID";
            this.FID.OptionsColumn.AllowEdit = false;
            this.FID.OptionsColumn.ReadOnly = true;
            this.FID.Visible = true;
            this.FID.VisibleIndex = 0;
            // 
            // SHIP_MOD
            // 
            this.SHIP_MOD.Caption = "船型";
            this.SHIP_MOD.ColumnEdit = this.ItemLookUp_SHIPMOD;
            this.SHIP_MOD.FieldName = "SHIP_MOD";
            this.SHIP_MOD.Name = "SHIP_MOD";
            this.SHIP_MOD.Visible = true;
            this.SHIP_MOD.VisibleIndex = 1;
            this.SHIP_MOD.Width = 20;
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
            // SHIP_ID
            // 
            this.SHIP_ID.Caption = "工程名";
            this.SHIP_ID.FieldName = "SHIP_ID";
            this.SHIP_ID.Name = "SHIP_ID";
            this.SHIP_ID.Visible = true;
            this.SHIP_ID.VisibleIndex = 2;
            // 
            // SHIP_NO
            // 
            this.SHIP_NO.Caption = "工程号";
            this.SHIP_NO.FieldName = "SHIP_NO";
            this.SHIP_NO.Name = "SHIP_NO";
            this.SHIP_NO.Visible = true;
            this.SHIP_NO.VisibleIndex = 3;
            // 
            // BLK_NO
            // 
            this.BLK_NO.Caption = "分段号";
            this.BLK_NO.FieldName = "BLK_NO";
            this.BLK_NO.Name = "BLK_NO";
            this.BLK_NO.Visible = true;
            this.BLK_NO.VisibleIndex = 4;
            // 
            // TREE_NAME
            // 
            this.TREE_NAME.Caption = "分段号";
            this.TREE_NAME.FieldName = "TREE_NAME";
            this.TREE_NAME.Name = "TREE_NAME";
            this.TREE_NAME.Visible = true;
            this.TREE_NAME.VisibleIndex = 5;
            // 
            // WELD_NO
            // 
            this.WELD_NO.Caption = "焊缝名";
            this.WELD_NO.FieldName = "WELD_NO";
            this.WELD_NO.Name = "WELD_NO";
            this.WELD_NO.Visible = true;
            this.WELD_NO.VisibleIndex = 6;
            // 
            // PART1_NAME2
            // 
            this.PART1_NAME2.Caption = "零件名";
            this.PART1_NAME2.FieldName = "PART1_NAME2";
            this.PART1_NAME2.Name = "PART1_NAME2";
            this.PART1_NAME2.Visible = true;
            this.PART1_NAME2.VisibleIndex = 7;
            // 
            // PART2_NAME2
            // 
            this.PART2_NAME2.Caption = "零件名";
            this.PART2_NAME2.FieldName = "PART2_NAME2";
            this.PART2_NAME2.Name = "PART2_NAME2";
            this.PART2_NAME2.Visible = true;
            this.PART2_NAME2.VisibleIndex = 8;
            // 
            // AS3
            // 
            this.AS3.Caption = "组立";
            this.AS3.FieldName = "AS3";
            this.AS3.Name = "AS3";
            this.AS3.Visible = true;
            this.AS3.VisibleIndex = 9;
            // 
            // BUFF1
            // 
            this.BUFF1.Caption = "阶段";
            this.BUFF1.FieldName = "BUFF1";
            this.BUFF1.Name = "BUFF1";
            this.BUFF1.Visible = true;
            this.BUFF1.VisibleIndex = 10;
            // 
            // THICK1
            // 
            this.THICK1.Caption = "板厚";
            this.THICK1.FieldName = "THICK1";
            this.THICK1.Name = "THICK1";
            this.THICK1.Visible = true;
            this.THICK1.VisibleIndex = 11;
            // 
            // THICK2
            // 
            this.THICK2.Caption = "板厚";
            this.THICK2.FieldName = "THICK2";
            this.THICK2.Name = "THICK2";
            this.THICK2.Visible = true;
            this.THICK2.VisibleIndex = 12;
            // 
            // WELD1_CODE
            // 
            this.WELD1_CODE.Caption = "坡口代码";
            this.WELD1_CODE.FieldName = "WELD1_CODE";
            this.WELD1_CODE.Name = "WELD1_CODE";
            this.WELD1_CODE.Visible = true;
            this.WELD1_CODE.VisibleIndex = 13;
            // 
            // WELD2_CODE
            // 
            this.WELD2_CODE.Caption = "坡口角度";
            this.WELD2_CODE.FieldName = "WELD2_CODE";
            this.WELD2_CODE.Name = "WELD2_CODE";
            this.WELD2_CODE.Visible = true;
            this.WELD2_CODE.VisibleIndex = 14;
            // 
            // GRADE1
            // 
            this.GRADE1.Caption = "材质";
            this.GRADE1.FieldName = "GRADE1";
            this.GRADE1.Name = "GRADE1";
            this.GRADE1.Visible = true;
            this.GRADE1.VisibleIndex = 15;
            // 
            // GRADE2
            // 
            this.GRADE2.Caption = "材质";
            this.GRADE2.FieldName = "GRADE2";
            this.GRADE2.Name = "GRADE2";
            this.GRADE2.Visible = true;
            this.GRADE2.VisibleIndex = 16;
            // 
            // WELD_TYPE
            // 
            this.WELD_TYPE.Caption = "接头形式";
            this.WELD_TYPE.FieldName = "WELD_TYPE";
            this.WELD_TYPE.Name = "WELD_TYPE";
            this.WELD_TYPE.Visible = true;
            this.WELD_TYPE.VisibleIndex = 17;
            // 
            // ASS1_NAME
            // 
            this.ASS1_NAME.Caption = "阻断名";
            this.ASS1_NAME.FieldName = "ASS1_NAME";
            this.ASS1_NAME.Name = "ASS1_NAME";
            this.ASS1_NAME.Visible = true;
            this.ASS1_NAME.VisibleIndex = 18;
            // 
            // WELD_ANGLE_H
            // 
            this.WELD_ANGLE_H.Caption = "焊脚高度";
            this.WELD_ANGLE_H.FieldName = "WELD_ANGLE_H";
            this.WELD_ANGLE_H.Name = "WELD_ANGLE_H";
            this.WELD_ANGLE_H.Visible = true;
            this.WELD_ANGLE_H.VisibleIndex = 19;
            // 
            // ASS2_NAME
            // 
            this.ASS2_NAME.Caption = "阻断名";
            this.ASS2_NAME.FieldName = "ASS2_NAME";
            this.ASS2_NAME.Name = "ASS2_NAME";
            this.ASS2_NAME.Visible = true;
            this.ASS2_NAME.VisibleIndex = 20;
            // 
            // WELD_COUNT
            // 
            this.WELD_COUNT.Caption = "焊缝数";
            this.WELD_COUNT.FieldName = "WELD_COUNT";
            this.WELD_COUNT.Name = "WELD_COUNT";
            this.WELD_COUNT.Visible = true;
            this.WELD_COUNT.VisibleIndex = 21;
            // 
            // PART1_TYPE
            // 
            this.PART1_TYPE.Caption = "零件号";
            this.PART1_TYPE.FieldName = "PART1_TYPE";
            this.PART1_TYPE.Name = "PART1_TYPE";
            this.PART1_TYPE.Visible = true;
            this.PART1_TYPE.VisibleIndex = 22;
            // 
            // PART2_TYPE
            // 
            this.PART2_TYPE.Caption = "零件号";
            this.PART2_TYPE.FieldName = "PART2_TYPE";
            this.PART2_TYPE.Name = "PART2_TYPE";
            this.PART2_TYPE.Visible = true;
            this.PART2_TYPE.VisibleIndex = 23;
            // 
            // TIP_ANGLE
            // 
            this.TIP_ANGLE.Caption = "倾斜角度";
            this.TIP_ANGLE.FieldName = "TIP_ANGLE";
            this.TIP_ANGLE.Name = "TIP_ANGLE";
            this.TIP_ANGLE.Visible = true;
            this.TIP_ANGLE.VisibleIndex = 24;
            // 
            // WELD_T_LEN
            // 
            this.WELD_T_LEN.Caption = "装配长度";
            this.WELD_T_LEN.FieldName = "WELD_T_LEN";
            this.WELD_T_LEN.Name = "WELD_T_LEN";
            this.WELD_T_LEN.Visible = true;
            this.WELD_T_LEN.VisibleIndex = 25;
            // 
            // ANGEL1
            // 
            this.ANGEL1.Caption = "焊角";
            this.ANGEL1.FieldName = "ANGEL1";
            this.ANGEL1.Name = "ANGEL1";
            this.ANGEL1.Visible = true;
            this.ANGEL1.VisibleIndex = 26;
            // 
            // ANGEL2
            // 
            this.ANGEL2.Caption = "焊角";
            this.ANGEL2.FieldName = "ANGEL2";
            this.ANGEL2.Name = "ANGEL2";
            this.ANGEL2.Visible = true;
            this.ANGEL2.VisibleIndex = 27;
            // 
            // ANGEL3
            // 
            this.ANGEL3.Caption = "焊角";
            this.ANGEL3.FieldName = "ANGEL3";
            this.ANGEL3.Name = "ANGEL3";
            this.ANGEL3.Visible = true;
            this.ANGEL3.VisibleIndex = 28;
            // 
            // WELD_TURN
            // 
            this.WELD_TURN.Caption = "焊道";
            this.WELD_TURN.FieldName = "WELD_TURN";
            this.WELD_TURN.Name = "WELD_TURN";
            this.WELD_TURN.Visible = true;
            this.WELD_TURN.VisibleIndex = 29;
            // 
            // WELD_NOTE
            // 
            this.WELD_NOTE.Caption = "备注";
            this.WELD_NOTE.FieldName = "WELD_NOTE";
            this.WELD_NOTE.Name = "WELD_NOTE";
            this.WELD_NOTE.Visible = true;
            this.WELD_NOTE.VisibleIndex = 30;
            // 
            // WELD_POS
            // 
            this.WELD_POS.Caption = "焊接位置";
            this.WELD_POS.FieldName = "WELD_POS";
            this.WELD_POS.Name = "WELD_POS";
            this.WELD_POS.Visible = true;
            this.WELD_POS.VisibleIndex = 31;
            // 
            // WELD_MOD
            // 
            this.WELD_MOD.Caption = "焊接方法";
            this.WELD_MOD.FieldName = "WELD_MOD";
            this.WELD_MOD.Name = "WELD_MOD";
            this.WELD_MOD.Visible = true;
            this.WELD_MOD.VisibleIndex = 32;
            // 
            // RuleNum
            // 
            this.RuleNum.Caption = "规程编号";
            this.RuleNum.FieldName = "RuleNum";
            this.RuleNum.Name = "RuleNum";
            this.RuleNum.Visible = true;
            this.RuleNum.VisibleIndex = 33;
            // 
            // ISCONTROL
            // 
            this.ISCONTROL.Caption = "是否管控";
            this.ISCONTROL.FieldName = "ISCONTROL";
            this.ISCONTROL.Name = "ISCONTROL";
            this.ISCONTROL.Visible = true;
            this.ISCONTROL.VisibleIndex = 34;
            // 
            // FParentID
            // 
            this.FParentID.Caption = "父ID";
            this.FParentID.FieldName = "FParentID";
            this.FParentID.Name = "FParentID";
            this.FParentID.Visible = true;
            this.FParentID.VisibleIndex = 35;
            // 
            // FNewName
            // 
            this.FNewName.Caption = "新焊缝名";
            this.FNewName.FieldName = "FNewName";
            this.FNewName.Name = "FNewName";
            this.FNewName.Visible = true;
            this.FNewName.VisibleIndex = 36;
            // 
            // FormMCCL00036
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.ClientSize = new System.Drawing.Size(1140, 746);
            this.Controls.Add(this.efGroupBox2);
            this.Controls.Add(this.efGroupBox1);
            this.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
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
        private DevExpress.XtraGrid.Columns.GridColumn FID;
        private DevExpress.XtraGrid.Columns.GridColumn SHIP_MOD;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ItemLookUp_SHIPMOD;
        private DevExpress.XtraGrid.Views.Grid.GridView View;
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
        private DevExpress.XtraGrid.Columns.GridColumn PART2_TYPE;
        private DevExpress.XtraGrid.Columns.GridColumn TIP_ANGLE;
        private DevExpress.XtraGrid.Columns.GridColumn WELD_T_LEN;
        private DevExpress.XtraGrid.Columns.GridColumn ANGEL1;
        private DevExpress.XtraGrid.Columns.GridColumn ANGEL2;
        private DevExpress.XtraGrid.Columns.GridColumn ANGEL3;
        private DevExpress.XtraGrid.Columns.GridColumn WELD_TURN;
        private DevExpress.XtraGrid.Columns.GridColumn WELD_NOTE;
        private DevExpress.XtraGrid.Columns.GridColumn WELD_POS;
        private DevExpress.XtraGrid.Columns.GridColumn WELD_MOD;
        private DevExpress.XtraGrid.Columns.GridColumn RuleNum;
        private DevExpress.XtraGrid.Columns.GridColumn ISCONTROL;
        private DevExpress.XtraGrid.Columns.GridColumn FParentID;
        private DevExpress.XtraGrid.Columns.GridColumn FNewName;
    }
}
