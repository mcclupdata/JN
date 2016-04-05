namespace MC
{
    partial class FormMCCL00432
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.Head = new EF.EFDevGrid();
            this.HeadGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CFID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CFDispatchName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CFDispatchNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CFDispatchSTARTTIME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CFDispatchENDTIME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CEdit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.BodyIndex = new EF.EFDevGrid();
            this.BodyIndexView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CFDispatchHeadID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CFOPDEPARTID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CFPARENTDEPARTNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CFOPDEPARTNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CFWeldCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BodyList = new EF.EFDevGrid();
            this.BodyListView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CFWELDID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CSHIP_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CBUFF1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CTREE_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CAS3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CFWeldName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CRuleNum = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox2)).BeginInit();
            this.efGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox4)).BeginInit();
            this.efGroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox3)).BeginInit();
            this.efGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBoxEx1)).BeginInit();
            this.efGroupBoxEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Head)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeadGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BodyIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BodyIndexView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BodyList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BodyListView)).BeginInit();
            this.SuspendLayout();
            // 
            // efGroupBox1
            // 
            this.efGroupBox1.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.efGroupBox1.Appearance.Options.UseBackColor = true;
            this.efGroupBox1.Text = "数据";
            // 
            // efGroupBox2
            // 
            this.efGroupBox2.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.efGroupBox2.Appearance.Options.UseBackColor = true;
            this.efGroupBox2.Controls.Add(this.Head);
            this.efGroupBox2.Text = "派工单头";
            // 
            // efGroupBox4
            // 
            this.efGroupBox4.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.efGroupBox4.Appearance.Options.UseBackColor = true;
            this.efGroupBox4.Controls.Add(this.BodyList);
            // 
            // efGroupBox3
            // 
            this.efGroupBox3.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.efGroupBox3.Appearance.Options.UseBackColor = true;
            this.efGroupBox3.Controls.Add(this.BodyIndex);
            this.efGroupBox3.Text = "派工单内容";
            // 
            // efLabel1
            // 
            this.efLabel1.Text = "派工单管理";
            // 
            // Head
            // 
            this.Head.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Head.Location = new System.Drawing.Point(2, 23);
            this.Head.MainView = this.HeadGridView;
            this.Head.Margin = new System.Windows.Forms.Padding(2);
            this.Head.Name = "Head";
            this.Head.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1});
            this.Head.Size = new System.Drawing.Size(415, 207);
            this.Head.TabIndex = 5;
            this.Head.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.HeadGridView});
            // 
            // HeadGridView
            // 
            this.HeadGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.CFID,
            this.CFDispatchName,
            this.CFDispatchNum,
            this.CFDispatchSTARTTIME,
            this.CFDispatchENDTIME,
            this.CEdit});
            this.HeadGridView.FixedLineWidth = 1;
            this.HeadGridView.GridControl = this.Head;
            this.HeadGridView.IndicatorWidth = 35;
            this.HeadGridView.Name = "HeadGridView";
            this.HeadGridView.OptionsView.ColumnAutoWidth = false;
            this.HeadGridView.OptionsView.EnableAppearanceEvenRow = true;
            this.HeadGridView.OptionsView.EnableAppearanceOddRow = true;
            this.HeadGridView.OptionsView.ShowGroupPanel = false;
            this.HeadGridView.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.HeadGridView_RowClick);
            // 
            // CFID
            // 
            this.CFID.Caption = "gridColumn1";
            this.CFID.FieldName = "FID";
            this.CFID.Name = "CFID";
            this.CFID.OptionsColumn.AllowEdit = false;
            // 
            // CFDispatchName
            // 
            this.CFDispatchName.Caption = "派工名称";
            this.CFDispatchName.FieldName = "FDispatchName";
            this.CFDispatchName.Name = "CFDispatchName";
            this.CFDispatchName.OptionsColumn.AllowEdit = false;
            this.CFDispatchName.Visible = true;
            this.CFDispatchName.VisibleIndex = 0;
            // 
            // CFDispatchNum
            // 
            this.CFDispatchNum.Caption = "派工编号";
            this.CFDispatchNum.FieldName = "FDispatchNum";
            this.CFDispatchNum.Name = "CFDispatchNum";
            this.CFDispatchNum.OptionsColumn.AllowEdit = false;
            this.CFDispatchNum.Visible = true;
            this.CFDispatchNum.VisibleIndex = 1;
            // 
            // CFDispatchSTARTTIME
            // 
            this.CFDispatchSTARTTIME.Caption = "计划开始时间";
            this.CFDispatchSTARTTIME.FieldName = "FDispatchSTARTTIME";
            this.CFDispatchSTARTTIME.Name = "CFDispatchSTARTTIME";
            this.CFDispatchSTARTTIME.OptionsColumn.AllowEdit = false;
            this.CFDispatchSTARTTIME.Visible = true;
            this.CFDispatchSTARTTIME.VisibleIndex = 2;
            // 
            // CFDispatchENDTIME
            // 
            this.CFDispatchENDTIME.Caption = "计划截止时间";
            this.CFDispatchENDTIME.FieldName = "FDispatchENDTIME";
            this.CFDispatchENDTIME.Name = "CFDispatchENDTIME";
            this.CFDispatchENDTIME.OptionsColumn.AllowEdit = false;
            this.CFDispatchENDTIME.Visible = true;
            this.CFDispatchENDTIME.VisibleIndex = 3;
            // 
            // CEdit
            // 
            this.CEdit.Caption = "编辑";
            this.CEdit.ColumnEdit = this.repositoryItemButtonEdit1;
            this.CEdit.Name = "CEdit";
            this.CEdit.OptionsColumn.AllowEdit = false;
            this.CEdit.Visible = true;
            this.CEdit.VisibleIndex = 4;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "编辑", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.repositoryItemButtonEdit1.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.repositoryItemButtonEdit1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryItemButtonEdit1.Click += new System.EventHandler(this.repositoryItemButtonEdit1_Click);
            // 
            // BodyIndex
            // 
            this.BodyIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BodyIndex.Location = new System.Drawing.Point(2, 23);
            this.BodyIndex.MainView = this.BodyIndexView;
            this.BodyIndex.Margin = new System.Windows.Forms.Padding(2);
            this.BodyIndex.Name = "BodyIndex";
            this.BodyIndex.Size = new System.Drawing.Size(415, 110);
            this.BodyIndex.TabIndex = 6;
            this.BodyIndex.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.BodyIndexView});
            // 
            // BodyIndexView
            // 
            this.BodyIndexView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.CFDispatchHeadID,
            this.CFOPDEPARTID,
            this.CFPARENTDEPARTNAME,
            this.CFOPDEPARTNAME,
            this.CFWeldCount});
            this.BodyIndexView.FixedLineWidth = 1;
            this.BodyIndexView.GridControl = this.BodyIndex;
            this.BodyIndexView.IndicatorWidth = 35;
            this.BodyIndexView.Name = "BodyIndexView";
            this.BodyIndexView.OptionsView.ColumnAutoWidth = false;
            this.BodyIndexView.OptionsView.EnableAppearanceEvenRow = true;
            this.BodyIndexView.OptionsView.EnableAppearanceOddRow = true;
            this.BodyIndexView.OptionsView.ShowGroupPanel = false;
            this.BodyIndexView.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.BodyIndexView_RowClick);
            // 
            // CFDispatchHeadID
            // 
            this.CFDispatchHeadID.Caption = "gridColumn1";
            this.CFDispatchHeadID.FieldName = "FDispatchHeadID";
            this.CFDispatchHeadID.Name = "CFDispatchHeadID";
            this.CFDispatchHeadID.OptionsColumn.AllowEdit = false;
            // 
            // CFOPDEPARTID
            // 
            this.CFOPDEPARTID.Caption = "gridColumn2";
            this.CFOPDEPARTID.FieldName = "FOPDEPARTID";
            this.CFOPDEPARTID.Name = "CFOPDEPARTID";
            this.CFOPDEPARTID.OptionsColumn.AllowEdit = false;
            // 
            // CFPARENTDEPARTNAME
            // 
            this.CFPARENTDEPARTNAME.Caption = "作业区";
            this.CFPARENTDEPARTNAME.FieldName = "FPARENTDEPARTNAME";
            this.CFPARENTDEPARTNAME.Name = "CFPARENTDEPARTNAME";
            this.CFPARENTDEPARTNAME.OptionsColumn.AllowEdit = false;
            this.CFPARENTDEPARTNAME.Visible = true;
            this.CFPARENTDEPARTNAME.VisibleIndex = 0;
            // 
            // CFOPDEPARTNAME
            // 
            this.CFOPDEPARTNAME.Caption = "班组";
            this.CFOPDEPARTNAME.FieldName = "FOPDEPARTNAME";
            this.CFOPDEPARTNAME.Name = "CFOPDEPARTNAME";
            this.CFOPDEPARTNAME.OptionsColumn.AllowEdit = false;
            this.CFOPDEPARTNAME.Visible = true;
            this.CFOPDEPARTNAME.VisibleIndex = 2;
            // 
            // CFWeldCount
            // 
            this.CFWeldCount.Caption = "焊缝数量";
            this.CFWeldCount.FieldName = "FWeldCount";
            this.CFWeldCount.Name = "CFWeldCount";
            this.CFWeldCount.OptionsColumn.AllowEdit = false;
            this.CFWeldCount.Visible = true;
            this.CFWeldCount.VisibleIndex = 1;
            // 
            // BodyList
            // 
            this.BodyList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BodyList.Location = new System.Drawing.Point(2, 23);
            this.BodyList.MainView = this.BodyListView;
            this.BodyList.Margin = new System.Windows.Forms.Padding(2);
            this.BodyList.Name = "BodyList";
            this.BodyList.Size = new System.Drawing.Size(290, 342);
            this.BodyList.TabIndex = 7;
            this.BodyList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.BodyListView});
            // 
            // BodyListView
            // 
            this.BodyListView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.CFWELDID,
            this.CSHIP_NO,
            this.CBUFF1,
            this.CTREE_NAME,
            this.CAS3,
            this.CFWeldName,
            this.CRuleNum});
            this.BodyListView.FixedLineWidth = 1;
            this.BodyListView.GridControl = this.BodyList;
            this.BodyListView.IndicatorWidth = 35;
            this.BodyListView.Name = "BodyListView";
            this.BodyListView.OptionsView.ColumnAutoWidth = false;
            this.BodyListView.OptionsView.EnableAppearanceEvenRow = true;
            this.BodyListView.OptionsView.EnableAppearanceOddRow = true;
            this.BodyListView.OptionsView.ShowGroupPanel = false;
            // 
            // CFWELDID
            // 
            this.CFWELDID.Caption = "内码";
            this.CFWELDID.FieldName = "FWELDID";
            this.CFWELDID.Name = "CFWELDID";
            this.CFWELDID.OptionsColumn.AllowEdit = false;
            // 
            // CSHIP_NO
            // 
            this.CSHIP_NO.Caption = "号船";
            this.CSHIP_NO.FieldName = "SHIP_NO";
            this.CSHIP_NO.Name = "CSHIP_NO";
            this.CSHIP_NO.OptionsColumn.AllowEdit = false;
            this.CSHIP_NO.Visible = true;
            this.CSHIP_NO.VisibleIndex = 0;
            // 
            // CBUFF1
            // 
            this.CBUFF1.Caption = "阶段";
            this.CBUFF1.FieldName = "BUFF1";
            this.CBUFF1.Name = "CBUFF1";
            this.CBUFF1.OptionsColumn.AllowEdit = false;
            this.CBUFF1.Visible = true;
            this.CBUFF1.VisibleIndex = 1;
            // 
            // CTREE_NAME
            // 
            this.CTREE_NAME.Caption = "组立树";
            this.CTREE_NAME.FieldName = "TREE_NAME";
            this.CTREE_NAME.Name = "CTREE_NAME";
            this.CTREE_NAME.OptionsColumn.AllowEdit = false;
            this.CTREE_NAME.Visible = true;
            this.CTREE_NAME.VisibleIndex = 2;
            // 
            // CAS3
            // 
            this.CAS3.Caption = "部件名";
            this.CAS3.FieldName = "AS3";
            this.CAS3.Name = "CAS3";
            this.CAS3.OptionsColumn.AllowEdit = false;
            this.CAS3.Visible = true;
            this.CAS3.VisibleIndex = 3;
            // 
            // CFWeldName
            // 
            this.CFWeldName.Caption = "焊缝名";
            this.CFWeldName.FieldName = "FWeldName";
            this.CFWeldName.Name = "CFWeldName";
            this.CFWeldName.OptionsColumn.AllowEdit = false;
            this.CFWeldName.Visible = true;
            this.CFWeldName.VisibleIndex = 4;
            // 
            // CRuleNum
            // 
            this.CRuleNum.Caption = "WPS编号";
            this.CRuleNum.FieldName = "RuleNum";
            this.CRuleNum.Name = "CRuleNum";
            this.CRuleNum.OptionsColumn.AllowEdit = false;
            this.CRuleNum.Visible = true;
            this.CRuleNum.VisibleIndex = 5;
            // 
            // FormMCCL00432
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 490);
            this.Name = "FormMCCL00432";
            this.Text = "派工单管理";
            this.Load += new System.EventHandler(this.FormMCCL00432_Load);
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox2)).EndInit();
            this.efGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox4)).EndInit();
            this.efGroupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox3)).EndInit();
            this.efGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBoxEx1)).EndInit();
            this.efGroupBoxEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Head)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeadGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BodyIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BodyIndexView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BodyList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BodyListView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected EF.EFDevGrid Head;
        protected DevExpress.XtraGrid.Views.Grid.GridView HeadGridView;
        protected DevExpress.XtraGrid.Columns.GridColumn CFID;
        protected DevExpress.XtraGrid.Columns.GridColumn CFDispatchName;
        protected DevExpress.XtraGrid.Columns.GridColumn CFDispatchNum;
        protected DevExpress.XtraGrid.Columns.GridColumn CFDispatchSTARTTIME;
        protected DevExpress.XtraGrid.Columns.GridColumn CFDispatchENDTIME;
        protected DevExpress.XtraGrid.Columns.GridColumn CEdit;
        protected DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        protected EF.EFDevGrid BodyIndex;
        protected DevExpress.XtraGrid.Views.Grid.GridView BodyIndexView;
        protected DevExpress.XtraGrid.Columns.GridColumn CFDispatchHeadID;
        protected DevExpress.XtraGrid.Columns.GridColumn CFOPDEPARTID;
        protected DevExpress.XtraGrid.Columns.GridColumn CFPARENTDEPARTNAME;
        protected DevExpress.XtraGrid.Columns.GridColumn CFWeldCount;
        public EF.EFDevGrid BodyList;
        public DevExpress.XtraGrid.Views.Grid.GridView BodyListView;
        public DevExpress.XtraGrid.Columns.GridColumn CFWELDID;
        public DevExpress.XtraGrid.Columns.GridColumn CSHIP_NO;
        public DevExpress.XtraGrid.Columns.GridColumn CBUFF1;
        public DevExpress.XtraGrid.Columns.GridColumn CTREE_NAME;
        public DevExpress.XtraGrid.Columns.GridColumn CAS3;
        public DevExpress.XtraGrid.Columns.GridColumn CFWeldName;
        public DevExpress.XtraGrid.Columns.GridColumn CRuleNum;
        private DevExpress.XtraGrid.Columns.GridColumn CFOPDEPARTNAME;
    }
}