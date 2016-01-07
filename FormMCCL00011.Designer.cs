namespace MC
{
    partial class FormMCCL00011
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
            this.gridview1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.WelderName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IdentificationCard = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WeldingProcessAb = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WeldingType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WeldingClass = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WelderWorkerID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WelderDepartment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WelderWorkPlace = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WelderWorkClass = new DevExpress.XtraGrid.Columns.GridColumn();
            this.WelderLaborServiceTeam = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox1)).BeginInit();
            this.efGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.butOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.butRead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.but_ChooseFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox2)).BeginInit();
            this.efGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridview1)).BeginInit();
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
            this.efGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.efGroupBox1.Name = "efGroupBox1";
            this.efGroupBox1.Size = new System.Drawing.Size(1463, 185);
            this.efGroupBox1.TabIndex = 4;
            this.efGroupBox1.Text = "条件";
            // 
            // butOk
            // 
            this.butOk.Authorizable = false;
            this.butOk.EnabledEx = true;
            this.butOk.FnNo = 0;
            this.butOk.Hint = "";
            this.butOk.Location = new System.Drawing.Point(357, 112);
            this.butOk.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(219, 58);
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
            this.butRead.Location = new System.Drawing.Point(43, 112);
            this.butRead.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.butRead.Name = "butRead";
            this.butRead.Size = new System.Drawing.Size(201, 57);
            this.butRead.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.butRead.TabIndex = 2;
            this.butRead.Text = "读取数据";
            this.butRead.ViewMode = EF.ViewModeEnum.Enable;
            // 
            // but_ChooseFile
            // 
            this.but_ChooseFile.Authorizable = false;
            this.but_ChooseFile.EnabledEx = true;
            this.but_ChooseFile.FnNo = 0;
            this.but_ChooseFile.Hint = "";
            this.but_ChooseFile.Location = new System.Drawing.Point(734, 66);
            this.but_ChooseFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.but_ChooseFile.Name = "but_ChooseFile";
            this.but_ChooseFile.Size = new System.Drawing.Size(133, 36);
            this.but_ChooseFile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.but_ChooseFile.TabIndex = 1;
            this.but_ChooseFile.Text = "选择文件";
            this.but_ChooseFile.ViewMode = EF.ViewModeEnum.Enable;
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
            this.txtFileName.Location = new System.Drawing.Point(43, 68);
            this.txtFileName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.ReadOnly = false;
            this.txtFileName.Size = new System.Drawing.Size(664, 30);
            this.txtFileName.TabIndex = 0;
            // 
            // efGroupBox2
            // 
            this.efGroupBox2.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.efGroupBox2.Appearance.Options.UseBackColor = true;
            this.efGroupBox2.Controls.Add(this.dataGrid);
            this.efGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.efGroupBox2.Location = new System.Drawing.Point(0, 185);
            this.efGroupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.efGroupBox2.Name = "efGroupBox2";
            this.efGroupBox2.Size = new System.Drawing.Size(1463, 787);
            this.efGroupBox2.TabIndex = 5;
            this.efGroupBox2.Text = "数据";
            // 
            // dataGrid
            // 
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.IsUseCustomPageBar = true;
            this.dataGrid.Location = new System.Drawing.Point(2, 30);
            this.dataGrid.MainView = this.gridview1;
            this.dataGrid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ShowContextMenuAddCopyNew = false;
            this.dataGrid.ShowContextMenuAddNew = false;
            this.dataGrid.ShowContextMenuChoose = false;
            this.dataGrid.ShowContextMenuChooseAll = false;
            this.dataGrid.ShowContextMenuSaveAs = false;
            this.dataGrid.ShowContextMenuUnChoose = false;
            this.dataGrid.ShowContextMenuUnChooseAll = false;
            this.dataGrid.ShowExportButton = false;
            this.dataGrid.ShowGroupButton = false;
            this.dataGrid.ShowPageToButton = true;
            this.dataGrid.ShowRecordCountMessage = true;
            this.dataGrid.ShowSaveLayoutButton = false;
            this.dataGrid.Size = new System.Drawing.Size(1459, 755);
            this.dataGrid.TabIndex = 0;
            this.dataGrid.UseEmbeddedNavigator = true;
            this.dataGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridview1});
            this.dataGrid.Click += new System.EventHandler(this.dataGrid_Click);
            // 
            // gridview1
            // 
            this.gridview1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.WelderName,
            this.IdentificationCard,
            this.WeldingProcessAb,
            this.WeldingType,
            this.WeldingClass,
            this.WelderWorkerID,
            this.WelderDepartment,
            this.WelderWorkPlace,
            this.WelderWorkClass,
            this.WelderLaborServiceTeam});
            this.gridview1.FixedLineWidth = 1;
            this.gridview1.GridControl = this.dataGrid;
            this.gridview1.IndicatorWidth = 35;
            this.gridview1.Name = "gridview1";
            this.gridview1.OptionsView.ColumnAutoWidth = false;
            this.gridview1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridview1.OptionsView.EnableAppearanceOddRow = true;
            this.gridview1.OptionsView.ShowGroupPanel = false;
            // 
            // WelderName
            // 
            this.WelderName.Caption = "姓名";
            this.WelderName.CustomizationCaption = "姓名";
            this.WelderName.FieldName = "WelderName";
            this.WelderName.Name = "WelderName";
            this.WelderName.Visible = true;
            this.WelderName.VisibleIndex = 0;
            // 
            // IdentificationCard
            // 
            this.IdentificationCard.Caption = "身份证";
            this.IdentificationCard.CustomizationCaption = "身份证";
            this.IdentificationCard.FieldName = "IdentificationCard";
            this.IdentificationCard.Name = "IdentificationCard";
            this.IdentificationCard.Visible = true;
            this.IdentificationCard.VisibleIndex = 1;
            // 
            // WeldingProcessAb
            // 
            this.WeldingProcessAb.Caption = "焊接方法";
            this.WeldingProcessAb.CustomizationCaption = "焊接方法";
            this.WeldingProcessAb.FieldName = "WeldingProcessAb";
            this.WeldingProcessAb.Name = "WeldingProcessAb";
            this.WeldingProcessAb.Visible = true;
            this.WeldingProcessAb.VisibleIndex = 2;
            // 
            // WeldingType
            // 
            this.WeldingType.Caption = "对/角接";
            this.WeldingType.CustomizationCaption = "对/角接";
            this.WeldingType.FieldName = "WeldingType";
            this.WeldingType.Name = "WeldingType";
            this.WeldingType.Visible = true;
            this.WeldingType.VisibleIndex = 3;
            // 
            // WeldingClass
            // 
            this.WeldingClass.Caption = "等级";
            this.WeldingClass.CustomizationCaption = "等级";
            this.WeldingClass.FieldName = "WeldingClass";
            this.WeldingClass.Name = "WeldingClass";
            this.WeldingClass.Visible = true;
            this.WeldingClass.VisibleIndex = 4;
            // 
            // WelderWorkerID
            // 
            this.WelderWorkerID.Caption = "工号";
            this.WelderWorkerID.CustomizationCaption = "工号";
            this.WelderWorkerID.FieldName = "WelderWorkerID";
            this.WelderWorkerID.Name = "WelderWorkerID";
            this.WelderWorkerID.Visible = true;
            this.WelderWorkerID.VisibleIndex = 5;
            // 
            // WelderDepartment
            // 
            this.WelderDepartment.Caption = "部门";
            this.WelderDepartment.CustomizationCaption = "部门";
            this.WelderDepartment.FieldName = "WelderDepartment";
            this.WelderDepartment.Name = "WelderDepartment";
            this.WelderDepartment.Visible = true;
            this.WelderDepartment.VisibleIndex = 6;
            // 
            // WelderWorkPlace
            // 
            this.WelderWorkPlace.Caption = "作业区";
            this.WelderWorkPlace.CustomizationCaption = "作业区";
            this.WelderWorkPlace.FieldName = "WelderWorkPlace";
            this.WelderWorkPlace.Name = "WelderWorkPlace";
            this.WelderWorkPlace.Visible = true;
            this.WelderWorkPlace.VisibleIndex = 7;
            // 
            // WelderWorkClass
            // 
            this.WelderWorkClass.Caption = "班组";
            this.WelderWorkClass.CustomizationCaption = "班组";
            this.WelderWorkClass.FieldName = "WelderWorkClass";
            this.WelderWorkClass.Name = "WelderWorkClass";
            this.WelderWorkClass.Visible = true;
            this.WelderWorkClass.VisibleIndex = 8;
            // 
            // WelderLaborServiceTeam
            // 
            this.WelderLaborServiceTeam.Caption = "劳务队";
            this.WelderLaborServiceTeam.CustomizationCaption = "劳务队";
            this.WelderLaborServiceTeam.FieldName = "WelderLaborServiceTeam";
            this.WelderLaborServiceTeam.Name = "WelderLaborServiceTeam";
            this.WelderLaborServiceTeam.Visible = true;
            this.WelderLaborServiceTeam.VisibleIndex = 9;
            // 
            // FormMCCL00011
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1463, 1044);
            this.Controls.Add(this.efGroupBox2);
            this.Controls.Add(this.efGroupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormMCCL00011";
            this.Text = "焊工数据批量导入";
            this.Load += new System.EventHandler(this.FormMCCL00011_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.gridview1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private EF.EFGroupBox efGroupBox1;
        private EF.EFLabelText txtFileName;
        private EF.EFGroupBox efGroupBox2;
        private EF.EFDevGrid dataGrid;
        private EF.EFButton but_ChooseFile;
        private DevExpress.XtraGrid.Views.Grid.GridView gridview1;
        private DevExpress.XtraGrid.Columns.GridColumn WelderName;
        private DevExpress.XtraGrid.Columns.GridColumn IdentificationCard;
        private DevExpress.XtraGrid.Columns.GridColumn WeldingProcessAb;
        private DevExpress.XtraGrid.Columns.GridColumn WeldingType;
        private DevExpress.XtraGrid.Columns.GridColumn WeldingClass;
        private DevExpress.XtraGrid.Columns.GridColumn WelderWorkerID;
        private DevExpress.XtraGrid.Columns.GridColumn WelderDepartment;
        private DevExpress.XtraGrid.Columns.GridColumn WelderWorkPlace;
        private DevExpress.XtraGrid.Columns.GridColumn WelderWorkClass;
        private DevExpress.XtraGrid.Columns.GridColumn WelderLaborServiceTeam;
        private EF.EFButton butOk;
        private EF.EFButton butRead;

    }
}