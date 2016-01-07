namespace MC
{
    partial class FormMCCL00024
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
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox1)).BeginInit();
            this.efGroupBox1.SuspendLayout();
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
            this.efGroupBox1.Controls.Add(this.button1);
            this.efGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.efGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.efGroupBox1.Name = "efGroupBox1";
            this.efGroupBox1.Size = new System.Drawing.Size(1024, 118);
            this.efGroupBox1.TabIndex = 4;
            this.efGroupBox1.Text = "条件";
            // 
            // efGroupBox2
            // 
            this.efGroupBox2.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.efGroupBox2.Appearance.Options.UseBackColor = true;
            this.efGroupBox2.Controls.Add(this.dataGrid);
            this.efGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.efGroupBox2.Location = new System.Drawing.Point(0, 118);
            this.efGroupBox2.Name = "efGroupBox2";
            this.efGroupBox2.Size = new System.Drawing.Size(1024, 532);
            this.efGroupBox2.TabIndex = 5;
            this.efGroupBox2.Text = "数据";
            // 
            // dataGrid
            // 
            this.dataGrid.Location = new System.Drawing.Point(2, 23);
            this.dataGrid.MainView = this.gridview1;
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.Size = new System.Drawing.Size(1020, 561);
            this.dataGrid.TabIndex = 0;
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(26, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "123";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // FormMCCL00024
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 696);
            this.Controls.Add(this.efGroupBox2);
            this.Controls.Add(this.efGroupBox1);
            this.Name = "FormMCCL00024";
            this.Text = "123";
            this.Load += new System.EventHandler(this.FormMCCL00011_Load);
            this.Controls.SetChildIndex(this.efGroupBox1, 0);
            this.Controls.SetChildIndex(this.efGroupBox2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox1)).EndInit();
            this.efGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox2)).EndInit();
            this.efGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridview1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private EF.EFGroupBox efGroupBox1;
        private EF.EFGroupBox efGroupBox2;
        private EF.EFDevGrid dataGrid;
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
        private System.Windows.Forms.Button button1;

    }
}