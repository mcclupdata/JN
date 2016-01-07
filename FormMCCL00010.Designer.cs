namespace MC
{
    partial class FormMCCL00010
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
            this.FSTARTTIME = new EF.EFDateTimePicker2();
            this.Label2 = new EF.EFLabel();
            this.Label1 = new EF.EFLabel();
            this.butEDit = new EF.EFButton();
            this.butReflash = new EF.EFButton();
            this.FDepartID = new EF.EFComboBox(this.components);
            this.cobDepart = new EF.EFComboBox(this.components);
            this.Label6 = new EF.EFLabel();
            this.Label7 = new EF.EFLabel();
            this.efGroupBox2 = new EF.EFGroupBox(this.components);
            this.dataGrid = new EF.EFDevGrid();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CFWelderName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CFWelderID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CFSTARTTIME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CFALLCOUNT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CUndo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CDoing = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CFFinished = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CEDIT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.but_Edit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.CDELETE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.but_Del = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox1)).BeginInit();
            this.efGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.butEDit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.butReflash)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox2)).BeginInit();
            this.efGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_Edit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_Del)).BeginInit();
            this.SuspendLayout();
            // 
            // efGroupBox1
            // 
            this.efGroupBox1.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.efGroupBox1.Appearance.Options.UseBackColor = true;
            this.efGroupBox1.Controls.Add(this.FSTARTTIME);
            this.efGroupBox1.Controls.Add(this.Label2);
            this.efGroupBox1.Controls.Add(this.Label1);
            this.efGroupBox1.Controls.Add(this.butEDit);
            this.efGroupBox1.Controls.Add(this.butReflash);
            this.efGroupBox1.Controls.Add(this.FDepartID);
            this.efGroupBox1.Controls.Add(this.cobDepart);
            this.efGroupBox1.Controls.Add(this.Label6);
            this.efGroupBox1.Controls.Add(this.Label7);
            this.efGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.efGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.efGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.efGroupBox1.Name = "efGroupBox1";
            this.efGroupBox1.Size = new System.Drawing.Size(1463, 248);
            this.efGroupBox1.TabIndex = 4;
            // 
            // FSTARTTIME
            // 
            this.FSTARTTIME.ColumnName = null;
            this.FSTARTTIME.Location = new System.Drawing.Point(94, 187);
            this.FSTARTTIME.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FSTARTTIME.Name = "FSTARTTIME";
            this.FSTARTTIME.Size = new System.Drawing.Size(351, 29);
            this.FSTARTTIME.TabIndex = 12;
            // 
            // Label2
            // 
            this.Label2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.Label2.Location = new System.Drawing.Point(17, 187);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(86, 28);
            this.Label2.TabIndex = 11;
            this.Label2.Text = "任务时间";
            // 
            // Label1
            // 
            this.Label1.Appearance.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label1.Appearance.Options.UseFont = true;
            this.Label1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.Label1.Location = new System.Drawing.Point(17, 41);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(424, 74);
            this.Label1.TabIndex = 8;
            this.Label1.Text = "焊工任务管理";
            // 
            // butEDit
            // 
            this.butEDit.Authorizable = false;
            this.butEDit.EnabledEx = true;
            this.butEDit.FnNo = 0;
            this.butEDit.Hint = "";
            this.butEDit.Location = new System.Drawing.Point(734, 185);
            this.butEDit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.butEDit.Name = "butEDit";
            this.butEDit.Size = new System.Drawing.Size(133, 36);
            this.butEDit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.butEDit.TabIndex = 7;
            this.butEDit.Text = "编辑";
            this.butEDit.ViewMode = EF.ViewModeEnum.Enable;
            // 
            // butReflash
            // 
            this.butReflash.Authorizable = false;
            this.butReflash.EnabledEx = true;
            this.butReflash.FnNo = 0;
            this.butReflash.Hint = "";
            this.butReflash.Location = new System.Drawing.Point(487, 185);
            this.butReflash.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.butReflash.Name = "butReflash";
            this.butReflash.Size = new System.Drawing.Size(133, 36);
            this.butReflash.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.butReflash.TabIndex = 6;
            this.butReflash.Text = "刷新";
            this.butReflash.ViewMode = EF.ViewModeEnum.Enable;
            this.butReflash.Click += new System.EventHandler(this.butReflash_Click);
            // 
            // FDepartID
            // 
            this.FDepartID.ColumnName = null;
            this.FDepartID.EFCname = "";
            this.FDepartID.EFDropDown = false;
            this.FDepartID.FormattingEnabled = true;
            this.FDepartID.Location = new System.Drawing.Point(517, 124);
            this.FDepartID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FDepartID.Name = "FDepartID";
            this.FDepartID.Size = new System.Drawing.Size(348, 30);
            this.FDepartID.SQL = null;
            this.FDepartID.TabIndex = 3;
            this.FDepartID.UserValue = "";
            // 
            // cobDepart
            // 
            this.cobDepart.ColumnName = null;
            this.cobDepart.EFCname = "";
            this.cobDepart.EFDropDown = false;
            this.cobDepart.FormattingEnabled = true;
            this.cobDepart.Location = new System.Drawing.Point(94, 124);
            this.cobDepart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cobDepart.Name = "cobDepart";
            this.cobDepart.Size = new System.Drawing.Size(345, 30);
            this.cobDepart.SQL = null;
            this.cobDepart.TabIndex = 2;
            this.cobDepart.UserValue = "";
            // 
            // Label6
            // 
            this.Label6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.Label6.Location = new System.Drawing.Point(17, 124);
            this.Label6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(107, 22);
            this.Label6.TabIndex = 9;
            this.Label6.Text = "作业区";
            // 
            // Label7
            // 
            this.Label7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.Label7.Location = new System.Drawing.Point(470, 124);
            this.Label7.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(64, 22);
            this.Label7.TabIndex = 10;
            this.Label7.Text = "班组";
            // 
            // efGroupBox2
            // 
            this.efGroupBox2.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.efGroupBox2.Appearance.Options.UseBackColor = true;
            this.efGroupBox2.Controls.Add(this.dataGrid);
            this.efGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.efGroupBox2.Location = new System.Drawing.Point(0, 248);
            this.efGroupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.efGroupBox2.Name = "efGroupBox2";
            this.efGroupBox2.Size = new System.Drawing.Size(1463, 762);
            this.efGroupBox2.TabIndex = 5;
            // 
            // dataGrid
            // 
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.Location = new System.Drawing.Point(2, 30);
            this.dataGrid.MainView = this.gridView1;
            this.dataGrid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.but_Edit,
            this.but_Del});
            this.dataGrid.Size = new System.Drawing.Size(1459, 730);
            this.dataGrid.TabIndex = 0;
            this.dataGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.CFWelderName,
            this.CFWelderID,
            this.CFSTARTTIME,
            this.CFALLCOUNT,
            this.CUndo,
            this.CDoing,
            this.CFFinished,
            this.CEDIT,
            this.CDELETE});
            this.gridView1.FixedLineWidth = 1;
            this.gridView1.GridControl = this.dataGrid;
            this.gridView1.IndicatorWidth = 35;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // CFWelderName
            // 
            this.CFWelderName.Caption = "焊工名";
            this.CFWelderName.FieldName = "FName";
            this.CFWelderName.Name = "CFWelderName";
            this.CFWelderName.Visible = true;
            this.CFWelderName.VisibleIndex = 0;
            // 
            // CFWelderID
            // 
            this.CFWelderID.Caption = "FWelderID";
            this.CFWelderID.FieldName = "FWelderID";
            this.CFWelderID.Name = "CFWelderID";
            this.CFWelderID.Width = 20;
            // 
            // CFSTARTTIME
            // 
            this.CFSTARTTIME.Caption = "任务时间";
            this.CFSTARTTIME.FieldName = "FSTARTTIME";
            this.CFSTARTTIME.Name = "CFSTARTTIME";
            this.CFSTARTTIME.Visible = true;
            this.CFSTARTTIME.VisibleIndex = 1;
            // 
            // CFALLCOUNT
            // 
            this.CFALLCOUNT.Caption = "任务总数";
            this.CFALLCOUNT.FieldName = "AllCount";
            this.CFALLCOUNT.Name = "CFALLCOUNT";
            this.CFALLCOUNT.Visible = true;
            this.CFALLCOUNT.VisibleIndex = 2;
            // 
            // CUndo
            // 
            this.CUndo.Caption = "未开工数";
            this.CUndo.FieldName = "FUndo";
            this.CUndo.Name = "CUndo";
            this.CUndo.Visible = true;
            this.CUndo.VisibleIndex = 3;
            // 
            // CDoing
            // 
            this.CDoing.Caption = "开工数";
            this.CDoing.FieldName = "FDoing";
            this.CDoing.Name = "CDoing";
            this.CDoing.Visible = true;
            this.CDoing.VisibleIndex = 4;
            // 
            // CFFinished
            // 
            this.CFFinished.Caption = "完成数";
            this.CFFinished.FieldName = "FFinished";
            this.CFFinished.Name = "CFFinished";
            this.CFFinished.Visible = true;
            this.CFFinished.VisibleIndex = 5;
            // 
            // CEDIT
            // 
            this.CEDIT.Caption = "编辑";
            this.CEDIT.ColumnEdit = this.but_Edit;
            this.CEDIT.FieldName = "but_Edit";
            this.CEDIT.Name = "CEDIT";
            this.CEDIT.Visible = true;
            this.CEDIT.VisibleIndex = 6;
            // 
            // but_Edit
            // 
            this.but_Edit.AutoHeight = false;
            this.but_Edit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.but_Edit.Name = "but_Edit";
            // 
            // CDELETE
            // 
            this.CDELETE.Caption = "删除";
            this.CDELETE.ColumnEdit = this.but_Del;
            this.CDELETE.FieldName = "but_Del";
            this.CDELETE.Name = "CDELETE";
            this.CDELETE.Visible = true;
            this.CDELETE.VisibleIndex = 7;
            // 
            // but_Del
            // 
            this.but_Del.AutoHeight = false;
            this.but_Del.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.but_Del.Name = "but_Del";
            // 
            // FormMCCL00010
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1463, 1056);
            this.Controls.Add(this.efGroupBox2);
            this.Controls.Add(this.efGroupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormMCCL00010";
            this.Text = "焊工任务管理";
            this.Load += new System.EventHandler(this.frmProjectMag_Load);
            this.Controls.SetChildIndex(this.efGroupBox1, 0);
            this.Controls.SetChildIndex(this.efGroupBox2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox1)).EndInit();
            this.efGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.butEDit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.butReflash)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox2)).EndInit();
            this.efGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_Edit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_Del)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private EF.EFGroupBox efGroupBox1;
        private EF.EFGroupBox efGroupBox2;
        private EF.EFComboBox FDepartID;
        private EF.EFComboBox cobDepart;
        private EF.EFButton butEDit;
        private EF.EFButton butReflash;
        private EF.EFLabel Label1;
        private EF.EFLabel Label6;
        private EF.EFLabel Label7;
        private EF.EFLabel Label2;
        private EF.EFDateTimePicker2 FSTARTTIME;
        private EF.EFDevGrid dataGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn CFWelderName;
        private DevExpress.XtraGrid.Columns.GridColumn CFWelderID;
        private DevExpress.XtraGrid.Columns.GridColumn CFSTARTTIME;
        private DevExpress.XtraGrid.Columns.GridColumn CFALLCOUNT;
        private DevExpress.XtraGrid.Columns.GridColumn CUndo;
        private DevExpress.XtraGrid.Columns.GridColumn CDoing;
        private DevExpress.XtraGrid.Columns.GridColumn CFFinished;
        private DevExpress.XtraGrid.Columns.GridColumn CEDIT;
        private DevExpress.XtraGrid.Columns.GridColumn CDELETE;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit but_Edit;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit but_Del;
        

    }
}