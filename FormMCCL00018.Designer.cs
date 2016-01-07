namespace MC
{
    partial class FormMCCL00018
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
            this.Label1 = new EF.EFLabel();
            this.butEDit = new EF.EFButton();
            this.butReflash = new EF.EFButton();
            this.butDel = new EF.EFButton();
            this.efGroupBox2 = new EF.EFGroupBox(this.components);
            this.dataGrid = new EF.EFDevGrid();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CFID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CFDispactchName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CFDispatchNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CFDispatchSTARTTIME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CFDispatchENDTIME = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox1)).BeginInit();
            this.efGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.butEDit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.butReflash)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.butDel)).BeginInit();
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
            this.efGroupBox1.Controls.Add(this.Label1);
            this.efGroupBox1.Controls.Add(this.butEDit);
            this.efGroupBox1.Controls.Add(this.butReflash);
            this.efGroupBox1.Controls.Add(this.butDel);
            this.efGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.efGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.efGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.efGroupBox1.Name = "efGroupBox1";
            this.efGroupBox1.Size = new System.Drawing.Size(1463, 121);
            this.efGroupBox1.TabIndex = 4;
            // 
            // Label1
            // 
            this.Label1.Appearance.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label1.Appearance.Options.UseFont = true;
            this.Label1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.Label1.Location = new System.Drawing.Point(6, 41);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(207, 74);
            this.Label1.TabIndex = 8;
            this.Label1.Text = "派工单管理";
            // 
            // butEDit
            // 
            this.butEDit.Authorizable = false;
            this.butEDit.EnabledEx = true;
            this.butEDit.FnNo = 0;
            this.butEDit.Hint = "";
            this.butEDit.Location = new System.Drawing.Point(417, 41);
            this.butEDit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.butEDit.Name = "butEDit";
            this.butEDit.Size = new System.Drawing.Size(181, 74);
            this.butEDit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.butEDit.TabIndex = 7;
            this.butEDit.Text = "编辑";
            this.butEDit.ViewMode = EF.ViewModeEnum.Enable;
            this.butEDit.Click += new System.EventHandler(this.butEdit_Click);
            // 
            // butReflash
            // 
            this.butReflash.Authorizable = false;
            this.butReflash.EnabledEx = true;
            this.butReflash.FnNo = 0;
            this.butReflash.Hint = "";
            this.butReflash.Location = new System.Drawing.Point(232, 41);
            this.butReflash.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.butReflash.Name = "butReflash";
            this.butReflash.Size = new System.Drawing.Size(177, 74);
            this.butReflash.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.butReflash.TabIndex = 6;
            this.butReflash.Text = "刷新";
            this.butReflash.ViewMode = EF.ViewModeEnum.Enable;
            this.butReflash.Click += new System.EventHandler(this.butReflash_Click);
            // 
            // butDel
            // 
            this.butDel.Authorizable = false;
            this.butDel.EnabledEx = true;
            this.butDel.FnNo = 0;
            this.butDel.Hint = "";
            this.butDel.Location = new System.Drawing.Point(606, 41);
            this.butDel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.butDel.Name = "butDel";
            this.butDel.Size = new System.Drawing.Size(169, 74);
            this.butDel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.butDel.TabIndex = 1;
            this.butDel.Text = "删除";
            this.butDel.ViewMode = EF.ViewModeEnum.Enable;
            this.butDel.Click += new System.EventHandler(this.butDel_Click);
            // 
            // efGroupBox2
            // 
            this.efGroupBox2.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.efGroupBox2.Appearance.Options.UseBackColor = true;
            this.efGroupBox2.Controls.Add(this.dataGrid);
            this.efGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.efGroupBox2.Location = new System.Drawing.Point(0, 121);
            this.efGroupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.efGroupBox2.Name = "efGroupBox2";
            this.efGroupBox2.Size = new System.Drawing.Size(1463, 884);
            this.efGroupBox2.TabIndex = 5;
            // 
            // dataGrid
            // 
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.Location = new System.Drawing.Point(2, 30);
            this.dataGrid.MainView = this.gridView1;
            this.dataGrid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.Size = new System.Drawing.Size(1459, 852);
            this.dataGrid.TabIndex = 0;
            this.dataGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.CFID,
            this.CFDispactchName,
            this.CFDispatchNum,
            this.CFDispatchSTARTTIME,
            this.CFDispatchENDTIME});
            this.gridView1.FixedLineWidth = 1;
            this.gridView1.GridControl = this.dataGrid;
            this.gridView1.IndicatorWidth = 35;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // CFID
            // 
            this.CFID.Caption = "CFID";
            this.CFID.CustomizationCaption = "CFID";
            this.CFID.FieldName = "FID";
            this.CFID.Name = "CFID";
            // 
            // CFDispactchName
            // 
            this.CFDispactchName.Caption = "派工单名称";
            this.CFDispactchName.CustomizationCaption = "派工单名称";
            this.CFDispactchName.FieldName = "FDispactchName";
            this.CFDispactchName.Name = "CFDispactchName";
            this.CFDispactchName.Visible = true;
            this.CFDispactchName.VisibleIndex = 0;
            // 
            // CFDispatchNum
            // 
            this.CFDispatchNum.Caption = "派工单编码";
            this.CFDispatchNum.CustomizationCaption = "派工单编码";
            this.CFDispatchNum.FieldName = "FDispatchNum";
            this.CFDispatchNum.Name = "CFDispatchNum";
            this.CFDispatchNum.Visible = true;
            this.CFDispatchNum.VisibleIndex = 1;
            // 
            // CFDispatchSTARTTIME
            // 
            this.CFDispatchSTARTTIME.Caption = "开始时间";
            this.CFDispatchSTARTTIME.CustomizationCaption = "开始时间";
            this.CFDispatchSTARTTIME.FieldName = "FDispatchSTARTTIME";
            this.CFDispatchSTARTTIME.Name = "CFDispatchSTARTTIME";
            this.CFDispatchSTARTTIME.Visible = true;
            this.CFDispatchSTARTTIME.VisibleIndex = 2;
            // 
            // CFDispatchENDTIME
            // 
            this.CFDispatchENDTIME.Caption = "结束时间";
            this.CFDispatchENDTIME.CustomizationCaption = "结束时间";
            this.CFDispatchENDTIME.FieldName = "FDispatchENDTIME";
            this.CFDispatchENDTIME.Name = "CFDispatchENDTIME";
            this.CFDispatchENDTIME.Visible = true;
            this.CFDispatchENDTIME.VisibleIndex = 3;
            // 
            // FormMCCL00018
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1463, 1051);
            this.Controls.Add(this.efGroupBox2);
            this.Controls.Add(this.efGroupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormMCCL00018";
            this.Text = "派工单管理";
            this.EF_PRE_DO_F2 += new EF.EFButtonBar.EFDoFnEventHandler(this.FormMCCL00018_EF_PRE_DO_F2);
            this.EF_PRE_DO_F3 += new EF.EFButtonBar.EFDoFnEventHandler(this.FormMCCL00018_EF_PRE_DO_F3);
            this.Load += new System.EventHandler(this.frmDispatchBillMag_Load);
            this.EF_PRE_DO_F1 += new EF.EFButtonBar.EFDoFnEventHandler(this.FormMCCL00018_EF_PRE_DO_F1);
            this.Controls.SetChildIndex(this.efGroupBox1, 0);
            this.Controls.SetChildIndex(this.efGroupBox2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox1)).EndInit();
            this.efGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.butEDit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.butReflash)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.butDel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox2)).EndInit();
            this.efGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private EF.EFGroupBox efGroupBox1;
        private EF.EFGroupBox efGroupBox2;
        private EF.EFButton butDel;
        private EF.EFButton butEDit;
        private EF.EFButton butReflash;
        private EF.EFLabel Label1;
        private EF.EFDevGrid dataGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn CFID;
        private DevExpress.XtraGrid.Columns.GridColumn CFDispactchName;
        private DevExpress.XtraGrid.Columns.GridColumn CFDispatchNum;
        private DevExpress.XtraGrid.Columns.GridColumn CFDispatchSTARTTIME;
        private DevExpress.XtraGrid.Columns.GridColumn CFDispatchENDTIME;

    }
}