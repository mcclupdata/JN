namespace MC
{
    partial class FormMCCL00017
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
            this.butSeacher = new EF.EFButton();
            this.efGroupBox2 = new EF.EFGroupBox(this.components);
            this.dataGrid = new EF.EFDevGrid();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.SHIP_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Label1 = new EF.EFLabel();
            this.efTextBox1 = new EF.EFTextBox();
            this.efLabel2 = new EF.EFLabel();
            this.efDateTimePicker21 = new EF.EFDateTimePicker2();
            this.efLabel3 = new EF.EFLabel();
            this.efTextBox2 = new EF.EFTextBox();
            this.Label9 = new EF.EFLabel();
            this.Label2 = new EF.EFLabel();
            this.efLabel6 = new EF.EFLabel();
            this.efLabel7 = new EF.EFLabel();
            this.Label5 = new EF.EFLabel();
            this.Label6 = new EF.EFLabel();
            this.efTextBox4 = new EF.EFTextBox();
            this.efDateTimePicker22 = new EF.EFDateTimePicker2();
            this.efTextBox5 = new EF.EFTextBox();
            this.efComboBox1 = new EF.EFComboBox(this.components);
            this.efComboBox2 = new EF.EFComboBox(this.components);
            this.efComboBox3 = new EF.EFComboBox(this.components);
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox1)).BeginInit();
            this.efGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.butSeacher)).BeginInit();
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
            this.efGroupBox1.Controls.Add(this.efComboBox3);
            this.efGroupBox1.Controls.Add(this.efComboBox2);
            this.efGroupBox1.Controls.Add(this.efComboBox1);
            this.efGroupBox1.Controls.Add(this.efTextBox5);
            this.efGroupBox1.Controls.Add(this.efDateTimePicker22);
            this.efGroupBox1.Controls.Add(this.efTextBox4);
            this.efGroupBox1.Controls.Add(this.Label6);
            this.efGroupBox1.Controls.Add(this.Label5);
            this.efGroupBox1.Controls.Add(this.efLabel7);
            this.efGroupBox1.Controls.Add(this.efLabel6);
            this.efGroupBox1.Controls.Add(this.Label2);
            this.efGroupBox1.Controls.Add(this.Label9);
            this.efGroupBox1.Controls.Add(this.efTextBox2);
            this.efGroupBox1.Controls.Add(this.efLabel3);
            this.efGroupBox1.Controls.Add(this.efDateTimePicker21);
            this.efGroupBox1.Controls.Add(this.efLabel2);
            this.efGroupBox1.Controls.Add(this.efTextBox1);
            this.efGroupBox1.Controls.Add(this.Label1);
            this.efGroupBox1.Controls.Add(this.butSeacher);
            this.efGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.efGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.efGroupBox1.Name = "efGroupBox1";
            this.efGroupBox1.Size = new System.Drawing.Size(1024, 225);
            this.efGroupBox1.TabIndex = 4;
            this.efGroupBox1.Text = "条件";
            // 
            // butSeacher
            // 
            this.butSeacher.Authorizable = false;
            this.butSeacher.EnabledEx = true;
            this.butSeacher.FnNo = 0;
            this.butSeacher.Hint = "";
            this.butSeacher.Location = new System.Drawing.Point(877, 85);
            this.butSeacher.Name = "butSeacher";
            this.butSeacher.Size = new System.Drawing.Size(93, 64);
            this.butSeacher.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.butSeacher.TabIndex = 1;
            this.butSeacher.Text = "查询";
            this.butSeacher.ViewMode = EF.ViewModeEnum.Enable;
            // 
            // efGroupBox2
            // 
            this.efGroupBox2.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.efGroupBox2.Appearance.Options.UseBackColor = true;
            this.efGroupBox2.Controls.Add(this.dataGrid);
            this.efGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.efGroupBox2.Location = new System.Drawing.Point(0, 225);
            this.efGroupBox2.Name = "efGroupBox2";
            this.efGroupBox2.Size = new System.Drawing.Size(1024, 542);
            this.efGroupBox2.TabIndex = 5;
            this.efGroupBox2.Text = "数据";
            // 
            // dataGrid
            // 
            this.dataGrid.Location = new System.Drawing.Point(2, 23);
            this.dataGrid.MainView = this.gridView1;
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.Size = new System.Drawing.Size(1020, 561);
            this.dataGrid.TabIndex = 0;
            this.dataGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.SHIP_NO,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.gridView1.FixedLineWidth = 1;
            this.gridView1.GridControl = this.dataGrid;
            this.gridView1.IndicatorWidth = 35;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // SHIP_NO
            // 
            this.SHIP_NO.Caption = "船号";
            this.SHIP_NO.CustomizationCaption = "船号";
            this.SHIP_NO.FieldName = "SHIP_NO";
            this.SHIP_NO.Name = "SHIP_NO";
            this.SHIP_NO.Visible = true;
            this.SHIP_NO.VisibleIndex = 0;
            // 
            // Label1
            // 
            this.Label1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.Label1.Location = new System.Drawing.Point(30, 42);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(75, 14);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "工序计划名称";
            // 
            // efTextBox1
            // 
            this.efTextBox1.EFEname = null;
            this.efTextBox1.EFLeaveExpression = ".*";
            this.efTextBox1.EFLen = 32767;
            this.efTextBox1.Location = new System.Drawing.Point(135, 42);
            this.efTextBox1.Name = "efTextBox1";
            this.efTextBox1.Size = new System.Drawing.Size(200, 22);
            this.efTextBox1.TabIndex = 3;
            // 
            // efLabel2
            // 
            this.efLabel2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.efLabel2.Location = new System.Drawing.Point(30, 91);
            this.efLabel2.Name = "efLabel2";
            this.efLabel2.Size = new System.Drawing.Size(99, 14);
            this.efLabel2.TabIndex = 4;
            this.efLabel2.Text = "工序计划开始时间";
            // 
            // efDateTimePicker21
            // 
            this.efDateTimePicker21.ColumnName = null;
            this.efDateTimePicker21.Location = new System.Drawing.Point(135, 91);
            this.efDateTimePicker21.Name = "efDateTimePicker21";
            this.efDateTimePicker21.Size = new System.Drawing.Size(200, 22);
            this.efDateTimePicker21.TabIndex = 5;
            // 
            // efLabel3
            // 
            this.efLabel3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.efLabel3.Location = new System.Drawing.Point(30, 148);
            this.efLabel3.Name = "efLabel3";
            this.efLabel3.Size = new System.Drawing.Size(75, 14);
            this.efLabel3.TabIndex = 6;
            this.efLabel3.Text = "工程号";
            // 
            // efTextBox2
            // 
            this.efTextBox2.EFEname = null;
            this.efTextBox2.EFLeaveExpression = ".*";
            this.efTextBox2.EFLen = 32767;
            this.efTextBox2.Location = new System.Drawing.Point(135, 140);
            this.efTextBox2.Name = "efTextBox2";
            this.efTextBox2.Size = new System.Drawing.Size(200, 22);
            this.efTextBox2.TabIndex = 7;
            // 
            // Label9
            // 
            this.Label9.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.Label9.Location = new System.Drawing.Point(30, 187);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(75, 14);
            this.Label9.TabIndex = 9;
            this.Label9.Text = "承接单位";
            // 
            // Label2
            // 
            this.Label2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.Label2.Location = new System.Drawing.Point(512, 42);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(75, 14);
            this.Label2.TabIndex = 10;
            this.Label2.Text = "工程计划编码";
            // 
            // efLabel6
            // 
            this.efLabel6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.efLabel6.Location = new System.Drawing.Point(512, 85);
            this.efLabel6.Name = "efLabel6";
            this.efLabel6.Size = new System.Drawing.Size(97, 22);
            this.efLabel6.TabIndex = 11;
            this.efLabel6.Text = "工序计划截止时间";
            // 
            // efLabel7
            // 
            this.efLabel7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.efLabel7.Location = new System.Drawing.Point(512, 140);
            this.efLabel7.Name = "efLabel7";
            this.efLabel7.Size = new System.Drawing.Size(75, 22);
            this.efLabel7.TabIndex = 12;
            this.efLabel7.Text = "分段号";
            // 
            // Label5
            // 
            this.Label5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.Label5.Location = new System.Drawing.Point(512, 184);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(75, 17);
            this.Label5.TabIndex = 13;
            this.Label5.Text = "是否管控";
            // 
            // Label6
            // 
            this.Label6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.Label6.Location = new System.Drawing.Point(690, 184);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(43, 19);
            this.Label6.TabIndex = 14;
            this.Label6.Text = "状态";
            // 
            // efTextBox4
            // 
            this.efTextBox4.EFEname = null;
            this.efTextBox4.EFLeaveExpression = ".*";
            this.efTextBox4.EFLen = 32767;
            this.efTextBox4.Location = new System.Drawing.Point(605, 42);
            this.efTextBox4.Name = "efTextBox4";
            this.efTextBox4.Size = new System.Drawing.Size(200, 22);
            this.efTextBox4.TabIndex = 15;
            // 
            // efDateTimePicker22
            // 
            this.efDateTimePicker22.ColumnName = null;
            this.efDateTimePicker22.Location = new System.Drawing.Point(633, 85);
            this.efDateTimePicker22.Name = "efDateTimePicker22";
            this.efDateTimePicker22.Size = new System.Drawing.Size(172, 22);
            this.efDateTimePicker22.TabIndex = 16;
            // 
            // efTextBox5
            // 
            this.efTextBox5.EFEname = null;
            this.efTextBox5.EFLeaveExpression = ".*";
            this.efTextBox5.EFLen = 32767;
            this.efTextBox5.Location = new System.Drawing.Point(605, 145);
            this.efTextBox5.Name = "efTextBox5";
            this.efTextBox5.Size = new System.Drawing.Size(200, 22);
            this.efTextBox5.TabIndex = 17;
            // 
            // efComboBox1
            // 
            this.efComboBox1.CodeClass = null;
            this.efComboBox1.ColumnName = null;
            this.efComboBox1.EFCname = "";
            this.efComboBox1.EFDropDown = false;
            this.efComboBox1.FormattingEnabled = true;
            this.efComboBox1.Location = new System.Drawing.Point(135, 184);
            this.efComboBox1.Name = "efComboBox1";
            this.efComboBox1.Size = new System.Drawing.Size(200, 22);
            this.efComboBox1.SQL = null;
            this.efComboBox1.TabIndex = 19;
            this.efComboBox1.UserValue = "";
            // 
            // efComboBox2
            // 
            this.efComboBox2.AutoCompleteCustomSource.AddRange(new string[] {
            "是"});
            this.efComboBox2.ColumnName = null;
            this.efComboBox2.EFCname = "";
            this.efComboBox2.EFDropDown = false;
            this.efComboBox2.FormattingEnabled = true;
            this.efComboBox2.Location = new System.Drawing.Point(605, 184);
            this.efComboBox2.Name = "efComboBox2";
            this.efComboBox2.Size = new System.Drawing.Size(66, 22);
            this.efComboBox2.SQL = null;
            this.efComboBox2.TabIndex = 20;
            this.efComboBox2.UserValue = "";
            // 
            // efComboBox3
            // 
            this.efComboBox3.ColumnName = null;
            this.efComboBox3.EFCname = "";
            this.efComboBox3.EFDropDown = false;
            this.efComboBox3.FormattingEnabled = true;
            this.efComboBox3.Items.AddRange(new object[] {
            "是",
            "否"});
            this.efComboBox3.Location = new System.Drawing.Point(739, 184);
            this.efComboBox3.Name = "efComboBox3";
            this.efComboBox3.Size = new System.Drawing.Size(66, 22);
            this.efComboBox3.SQL = null;
            this.efComboBox3.TabIndex = 21;
            this.efComboBox3.UserValue = "";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "分段号";
            this.gridColumn1.CustomizationCaption = "分段号";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "阶段";
            this.gridColumn2.CustomizationCaption = "阶段";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "承接时间";
            this.gridColumn3.CustomizationCaption = "承接时间";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "计划开始时间";
            this.gridColumn4.CustomizationCaption = "计划开始时间";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "计划截止时间";
            this.gridColumn5.CustomizationCaption = "计划截止时间";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            // 
            // FormMCCL00017
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 813);
            this.Controls.Add(this.efGroupBox2);
            this.Controls.Add(this.efGroupBox1);
            this.Name = "FormMCCL00017";
            this.Text = "工序计划选择";
            this.Controls.SetChildIndex(this.efGroupBox1, 0);
            this.Controls.SetChildIndex(this.efGroupBox2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox1)).EndInit();
            this.efGroupBox1.ResumeLayout(false);
            this.efGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.butSeacher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox2)).EndInit();
            this.efGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private EF.EFGroupBox efGroupBox1;
        private EF.EFGroupBox efGroupBox2;
        private EF.EFDevGrid dataGrid;
        private EF.EFButton butSeacher;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn SHIP_NO;
        private EF.EFLabel Label6;
        private EF.EFLabel Label5;
        private EF.EFLabel efLabel7;
        private EF.EFLabel efLabel6;
        private EF.EFLabel Label2;
        private EF.EFLabel Label9;
        private EF.EFTextBox efTextBox2;
        private EF.EFLabel efLabel3;
        private EF.EFDateTimePicker2 efDateTimePicker21;
        private EF.EFLabel efLabel2;
        private EF.EFTextBox efTextBox1;
        private EF.EFLabel Label1;
        private EF.EFTextBox efTextBox5;
        private EF.EFDateTimePicker2 efDateTimePicker22;
        private EF.EFTextBox efTextBox4;
        private EF.EFComboBox efComboBox1;
        private EF.EFComboBox efComboBox2;
        private EF.EFComboBox efComboBox3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;

    }
}