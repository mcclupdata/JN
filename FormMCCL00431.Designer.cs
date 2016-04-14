namespace MC
{
    partial class FormMCCL00431
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.Head = new EF.EFDevGrid();
            this.HeadGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CFID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CFProcessname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CFProcessnum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CFSTARTTIME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CFENDTIME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CEdit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.BodyIndex = new EF.EFDevGrid();
            this.BodyIndexView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CFDepartName = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.efGroupBox1.Size = new System.Drawing.Size(841, 392);
            this.efGroupBox1.Text = "数据";
            // 
            // efGroupBox2
            // 
            this.efGroupBox2.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.efGroupBox2.Appearance.Options.UseBackColor = true;
            this.efGroupBox2.Controls.Add(this.Head);
            // 
            // efGroupBox4
            // 
            this.efGroupBox4.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.efGroupBox4.Appearance.Options.UseBackColor = true;
            this.efGroupBox4.Controls.Add(this.BodyList);
            this.efGroupBox4.Size = new System.Drawing.Size(418, 367);
            // 
            // efGroupBox3
            // 
            this.efGroupBox3.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.efGroupBox3.Appearance.Options.UseBackColor = true;
            this.efGroupBox3.Controls.Add(this.BodyIndex);
            // 
            // efGroupBoxEx1
            // 
            this.efGroupBoxEx1.Size = new System.Drawing.Size(841, 52);
            // 
            // efLabel1
            // 
            this.efLabel1.Text = "工序计划单管理";
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
            this.CFProcessname,
            this.CFProcessnum,
            this.CFSTARTTIME,
            this.CFENDTIME,
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
            // 
            // CFProcessname
            // 
            this.CFProcessname.Caption = "计划名称";
            this.CFProcessname.FieldName = "FProcessname";
            this.CFProcessname.Name = "CFProcessname";
            this.CFProcessname.Visible = true;
            this.CFProcessname.VisibleIndex = 0;
            // 
            // CFProcessnum
            // 
            this.CFProcessnum.Caption = "计划编号";
            this.CFProcessnum.FieldName = "FProcessnum";
            this.CFProcessnum.Name = "CFProcessnum";
            this.CFProcessnum.Visible = true;
            this.CFProcessnum.VisibleIndex = 1;
            // 
            // CFSTARTTIME
            // 
            this.CFSTARTTIME.Caption = "计划开始时间";
            this.CFSTARTTIME.FieldName = "FSTARTTIME";
            this.CFSTARTTIME.Name = "CFSTARTTIME";
            this.CFSTARTTIME.Visible = true;
            this.CFSTARTTIME.VisibleIndex = 2;
            // 
            // CFENDTIME
            // 
            this.CFENDTIME.Caption = "计划截止时间";
            this.CFENDTIME.FieldName = "FENDTIME";
            this.CFENDTIME.Name = "CFENDTIME";
            this.CFENDTIME.Visible = true;
            this.CFENDTIME.VisibleIndex = 3;
            // 
            // CEdit
            // 
            this.CEdit.Caption = "编辑";
            this.CEdit.ColumnEdit = this.repositoryItemButtonEdit1;
            this.CEdit.Name = "CEdit";
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
            this.gridColumn1,
            this.gridColumn2,
            this.CFDepartName,
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
            // gridColumn1
            // 
            this.gridColumn1.Caption = "gridColumn1";
            this.gridColumn1.FieldName = "FDoDepartID";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "gridColumn2";
            this.gridColumn2.FieldName = "FProjectHeadID";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // CFDepartName
            // 
            this.CFDepartName.Caption = "作业区";
            this.CFDepartName.FieldName = "FDepartName";
            this.CFDepartName.Name = "CFDepartName";
            this.CFDepartName.OptionsColumn.AllowEdit = false;
            this.CFDepartName.Visible = true;
            this.CFDepartName.VisibleIndex = 0;
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
            this.BodyList.Size = new System.Drawing.Size(414, 342);
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
            // FormMCCL00431
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(841, 490);
            this.Name = "FormMCCL00431";
            this.Load += new System.EventHandler(this.FormMCCL00431_Load);
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
        protected DevExpress.XtraGrid.Columns.GridColumn CFProcessname;
        protected DevExpress.XtraGrid.Columns.GridColumn CFProcessnum;
        protected DevExpress.XtraGrid.Columns.GridColumn CFSTARTTIME;
        protected DevExpress.XtraGrid.Columns.GridColumn CFENDTIME;
        protected DevExpress.XtraGrid.Columns.GridColumn CEdit;
        protected DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        protected EF.EFDevGrid BodyIndex;
        protected DevExpress.XtraGrid.Views.Grid.GridView BodyIndexView;
        protected DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        protected DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        protected DevExpress.XtraGrid.Columns.GridColumn CFDepartName;
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


    }
}
