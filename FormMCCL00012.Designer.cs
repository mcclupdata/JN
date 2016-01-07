namespace MC
{
    partial class FormMCCL00012
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
            this.WelderGroup = new EF.EFComboBox(this.components);
            this.Label3 = new EF.EFLabel();
            this.FSTARTTIME = new EF.EFDateTimePicker2();
            this.Label00 = new EF.EFLabel();
            this.Label7 = new EF.EFLabel();
            this.Label1 = new EF.EFLabel();
            this.butOK = new EF.EFButton();
            this.butAdd = new EF.EFButton();
            this.ClassGroup = new EF.EFComboBox(this.components);
            this.WorkGroup = new EF.EFComboBox(this.components);
            this.efGroupBox2 = new EF.EFGroupBox(this.components);
            this.dataGrid = new EF.EFDevGrid();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CBUTDELETE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.but_Del = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.CFWelderName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CFWelderID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CFDepartName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CFDepart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CFSTARTTIME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CWeldCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CCWELD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.but_AddWelds = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox1)).BeginInit();
            this.efGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.butOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.butAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox2)).BeginInit();
            this.efGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_Del)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_AddWelds)).BeginInit();
            this.SuspendLayout();
            // 
            // efGroupBox1
            // 
            this.efGroupBox1.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.efGroupBox1.Appearance.Options.UseBackColor = true;
            this.efGroupBox1.Controls.Add(this.WelderGroup);
            this.efGroupBox1.Controls.Add(this.Label3);
            this.efGroupBox1.Controls.Add(this.FSTARTTIME);
            this.efGroupBox1.Controls.Add(this.Label00);
            this.efGroupBox1.Controls.Add(this.Label7);
            this.efGroupBox1.Controls.Add(this.Label1);
            this.efGroupBox1.Controls.Add(this.butOK);
            this.efGroupBox1.Controls.Add(this.butAdd);
            this.efGroupBox1.Controls.Add(this.ClassGroup);
            this.efGroupBox1.Controls.Add(this.WorkGroup);
            this.efGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.efGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.efGroupBox1.Name = "efGroupBox1";
            this.efGroupBox1.Size = new System.Drawing.Size(896, 133);
            this.efGroupBox1.TabIndex = 4;
            // 
            // WelderGroup
            // 
            this.WelderGroup.ColumnName = null;
            this.WelderGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WelderGroup.EFCname = "";
            this.WelderGroup.EFDropDown = false;
            this.WelderGroup.FormattingEnabled = true;
            this.WelderGroup.Location = new System.Drawing.Point(719, 47);
            this.WelderGroup.Name = "WelderGroup";
            this.WelderGroup.Size = new System.Drawing.Size(221, 22);
            this.WelderGroup.SQL = null;
            this.WelderGroup.TabIndex = 14;
            this.WelderGroup.UserValue = "";
            // 
            // Label3
            // 
            this.Label3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.Label3.Location = new System.Drawing.Point(685, 45);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(40, 24);
            this.Label3.TabIndex = 13;
            this.Label3.Text = "焊工";
            // 
            // FSTARTTIME
            // 
            this.FSTARTTIME.ColumnName = null;
            this.FSTARTTIME.Location = new System.Drawing.Point(97, 83);
            this.FSTARTTIME.Name = "FSTARTTIME";
            this.FSTARTTIME.Size = new System.Drawing.Size(220, 22);
            this.FSTARTTIME.TabIndex = 12;
            // 
            // Label00
            // 
            this.Label00.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.Label00.Location = new System.Drawing.Point(22, 85);
            this.Label00.Name = "Label00";
            this.Label00.Size = new System.Drawing.Size(57, 20);
            this.Label00.TabIndex = 11;
            this.Label00.Text = "任务时间";
            // 
            // Label7
            // 
            this.Label7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.Label7.Location = new System.Drawing.Point(362, 42);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(33, 25);
            this.Label7.TabIndex = 10;
            this.Label7.Text = "班组";
            // 
            // Label1
            // 
            this.Label1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.Label1.Location = new System.Drawing.Point(22, 45);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(75, 14);
            this.Label1.TabIndex = 9;
            this.Label1.Text = "作业区";
            // 
            // butOK
            // 
            this.butOK.Authorizable = false;
            this.butOK.EnabledEx = true;
            this.butOK.FnNo = 0;
            this.butOK.Hint = "";
            this.butOK.Location = new System.Drawing.Point(600, 83);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(93, 23);
            this.butOK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.butOK.TabIndex = 7;
            this.butOK.Text = "保存";
            this.butOK.ViewMode = EF.ViewModeEnum.Enable;
            // 
            // butAdd
            // 
            this.butAdd.Authorizable = false;
            this.butAdd.EnabledEx = true;
            this.butAdd.FnNo = 0;
            this.butAdd.Hint = "";
            this.butAdd.Location = new System.Drawing.Point(362, 83);
            this.butAdd.Name = "butAdd";
            this.butAdd.Size = new System.Drawing.Size(93, 23);
            this.butAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.butAdd.TabIndex = 6;
            this.butAdd.Text = "添加";
            this.butAdd.ViewMode = EF.ViewModeEnum.Enable;
            // 
            // ClassGroup
            // 
            this.ClassGroup.ColumnName = null;
            this.ClassGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ClassGroup.EFCname = "";
            this.ClassGroup.EFDropDown = false;
            this.ClassGroup.FormattingEnabled = true;
            this.ClassGroup.Location = new System.Drawing.Point(401, 44);
            this.ClassGroup.Name = "ClassGroup";
            this.ClassGroup.Size = new System.Drawing.Size(221, 22);
            this.ClassGroup.SQL = null;
            this.ClassGroup.TabIndex = 3;
            this.ClassGroup.UserValue = "";
            // 
            // WorkGroup
            // 
            this.WorkGroup.ColumnName = null;
            this.WorkGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WorkGroup.EFCname = "";
            this.WorkGroup.EFDropDown = false;
            this.WorkGroup.FormattingEnabled = true;
            this.WorkGroup.Location = new System.Drawing.Point(97, 42);
            this.WorkGroup.Name = "WorkGroup";
            this.WorkGroup.Size = new System.Drawing.Size(220, 22);
            this.WorkGroup.SQL = null;
            this.WorkGroup.TabIndex = 2;
            this.WorkGroup.UserValue = "";
            // 
            // efGroupBox2
            // 
            this.efGroupBox2.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.efGroupBox2.Appearance.Options.UseBackColor = true;
            this.efGroupBox2.Controls.Add(this.dataGrid);
            this.efGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.efGroupBox2.Location = new System.Drawing.Point(0, 133);
            this.efGroupBox2.Name = "efGroupBox2";
            this.efGroupBox2.Size = new System.Drawing.Size(896, 459);
            this.efGroupBox2.TabIndex = 5;
            // 
            // dataGrid
            // 
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.Location = new System.Drawing.Point(2, 23);
            this.dataGrid.MainView = this.gridView1;
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.but_Del,
            this.but_AddWelds});
            this.dataGrid.Size = new System.Drawing.Size(892, 434);
            this.dataGrid.TabIndex = 0;
            this.dataGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.dataGrid.Click += new System.EventHandler(this.dataGrid_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.CBUTDELETE,
            this.CFWelderName,
            this.CFWelderID,
            this.CFDepartName,
            this.CFDepart,
            this.CFSTARTTIME,
            this.CWeldCount,
            this.CCWELD});
            this.gridView1.FixedLineWidth = 1;
            this.gridView1.GridControl = this.dataGrid;
            this.gridView1.IndicatorWidth = 35;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // CBUTDELETE
            // 
            this.CBUTDELETE.Caption = "删除";
            this.CBUTDELETE.ColumnEdit = this.but_Del;
            this.CBUTDELETE.CustomizationCaption = "删除";
            this.CBUTDELETE.FieldName = "CBUTDELETE";
            this.CBUTDELETE.Name = "CBUTDELETE";
            this.CBUTDELETE.Visible = true;
            this.CBUTDELETE.VisibleIndex = 0;
            // 
            // but_Del
            // 
            this.but_Del.AutoHeight = false;
            this.but_Del.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.but_Del.Name = "but_Del";
            // 
            // CFWelderName
            // 
            this.CFWelderName.Caption = "焊工";
            this.CFWelderName.CustomizationCaption = "焊工";
            this.CFWelderName.FieldName = "Fweldername";
            this.CFWelderName.Name = "CFWelderName";
            this.CFWelderName.Visible = true;
            this.CFWelderName.VisibleIndex = 1;
            // 
            // CFWelderID
            // 
            this.CFWelderID.Caption = "CFWelderID";
            this.CFWelderID.FieldName = "FWelderID";
            this.CFWelderID.Name = "CFWelderID";
            // 
            // CFDepartName
            // 
            this.CFDepartName.Caption = "部门";
            this.CFDepartName.CustomizationCaption = "部门";
            this.CFDepartName.FieldName = "FDepartName";
            this.CFDepartName.Name = "CFDepartName";
            this.CFDepartName.Visible = true;
            this.CFDepartName.VisibleIndex = 2;
            // 
            // CFDepart
            // 
            this.CFDepart.Caption = "CFDepart";
            this.CFDepart.CustomizationCaption = "CFDepart";
            this.CFDepart.FieldName = "FOPDEPARTID";
            this.CFDepart.Name = "CFDepart";
            this.CFDepart.Visible = true;
            this.CFDepart.VisibleIndex = 3;
            // 
            // CFSTARTTIME
            // 
            this.CFSTARTTIME.Caption = "日期";
            this.CFSTARTTIME.CustomizationCaption = "日期";
            this.CFSTARTTIME.FieldName = "FDispatchSTARTTIME";
            this.CFSTARTTIME.Name = "CFSTARTTIME";
            this.CFSTARTTIME.Visible = true;
            this.CFSTARTTIME.VisibleIndex = 4;
            // 
            // CWeldCount
            // 
            this.CWeldCount.Caption = "已分配数";
            this.CWeldCount.CustomizationCaption = "已分配数";
            this.CWeldCount.FieldName = "WeldCount";
            this.CWeldCount.Name = "CWeldCount";
            this.CWeldCount.Visible = true;
            this.CWeldCount.VisibleIndex = 5;
            // 
            // CCWELD
            // 
            this.CCWELD.Caption = "分配焊缝";
            this.CCWELD.ColumnEdit = this.but_AddWelds;
            this.CCWELD.CustomizationCaption = "分配焊缝";
            this.CCWELD.FieldName = "CCWELD";
            this.CCWELD.Name = "CCWELD";
            this.CCWELD.Visible = true;
            this.CCWELD.VisibleIndex = 6;
            // 
            // but_AddWelds
            // 
            this.but_AddWelds.AutoHeight = false;
            this.but_AddWelds.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.but_AddWelds.Name = "but_AddWelds";
            // 
            // FormMCCL00012
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 638);
            this.Controls.Add(this.efGroupBox2);
            this.Controls.Add(this.efGroupBox1);
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "FormMCCL00012";
            this.Text = "任务单--创建";
            this.Load += new System.EventHandler(this.FormMCCL00012_Load);
            this.Controls.SetChildIndex(this.efGroupBox1, 0);
            this.Controls.SetChildIndex(this.efGroupBox2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox1)).EndInit();
            this.efGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.butOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.butAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox2)).EndInit();
            this.efGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_Del)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_AddWelds)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private EF.EFComboBox ClassGroup;
        private EF.EFComboBox WorkGroup;
        private EF.EFLabel Label1;
        private EF.EFLabel Label7;
        public EF.EFButton butOK;
        public EF.EFButton butAdd;
        public EF.EFLabel Label00;
        public EF.EFDateTimePicker2 FSTARTTIME;
        public EF.EFComboBox WelderGroup;
        public EF.EFLabel Label3;
        public EF.EFGroupBox efGroupBox2;
        public EF.EFGroupBox efGroupBox1;
        public EF.EFDevGrid dataGrid;
        public DevExpress.XtraGrid.Columns.GridColumn CBUTDELETE;
        public DevExpress.XtraGrid.Columns.GridColumn CFWelderName;
        public DevExpress.XtraGrid.Columns.GridColumn CFDepartName;
        public DevExpress.XtraGrid.Columns.GridColumn CFDepart;
        public DevExpress.XtraGrid.Columns.GridColumn CFSTARTTIME;
        public DevExpress.XtraGrid.Columns.GridColumn CWeldCount;
        public DevExpress.XtraGrid.Columns.GridColumn CCWELD;
        public DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit but_Del;
        public DevExpress.XtraGrid.Columns.GridColumn CFWelderID;
        public DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit but_AddWelds;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView1;

    }
}