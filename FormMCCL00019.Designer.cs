namespace MC
{
    partial class FormMCCL00019
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
            this.efGroupBox3 = new EF.EFGroupBox(this.components);
            this.dataGrid = new EF.EFDevGrid();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.删除 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.工程号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.分段号 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.阶段 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.部门内码 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.上级部门 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.承接部门 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.分配焊接 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GroupBox2 = new EF.EFGroupBox(this.components);
            this.efLabelText6 = new EF.EFLabelText();
            this.efLabelText5 = new EF.EFLabelText();
            this.efLabel4 = new EF.EFLabel();
            this.efLabel3 = new EF.EFLabel();
            this.efLabelText4 = new EF.EFLabelText();
            this.efLabelText3 = new EF.EFLabelText();
            this.efLabel2 = new EF.EFLabel();
            this.efLabel1 = new EF.EFLabel();
            this.efLabelText2 = new EF.EFLabelText();
            this.efLabelText1 = new EF.EFLabelText();
            this.FProcessname = new EF.EFLabelText();
            this.Label8 = new EF.EFLabel();
            this.Label4 = new EF.EFLabel();
            this.Label5 = new EF.EFLabel();
            this.efGroupBox2 = new EF.EFGroupBox(this.components);
            this.efGroupBox1 = new EF.EFGroupBox(this.components);
            this.efCheckBox1 = new EF.EFCheckBox();
            this.butOK = new EF.EFButton();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox3)).BeginInit();
            this.efGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupBox2)).BeginInit();
            this.GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox2)).BeginInit();
            this.efGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox1)).BeginInit();
            this.efGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.butOK)).BeginInit();
            this.SuspendLayout();
            // 
            // efGroupBox3
            // 
            this.efGroupBox3.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.efGroupBox3.Appearance.Options.UseBackColor = true;
            this.efGroupBox3.Controls.Add(this.dataGrid);
            this.efGroupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.efGroupBox3.Location = new System.Drawing.Point(0, 506);
            this.efGroupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.efGroupBox3.Name = "efGroupBox3";
            this.efGroupBox3.Size = new System.Drawing.Size(1500, 499);
            this.efGroupBox3.TabIndex = 6;
            // 
            // dataGrid
            // 
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.Location = new System.Drawing.Point(2, 30);
            this.dataGrid.MainView = this.gridView2;
            this.dataGrid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.Size = new System.Drawing.Size(1496, 467);
            this.dataGrid.TabIndex = 0;
            this.dataGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2,
            this.gridView1});
            this.dataGrid.Click += new System.EventHandler(this.efDevGrid1_Click_1);
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.gridView2.FixedLineWidth = 1;
            this.gridView2.GridControl = this.dataGrid;
            this.gridView2.IndicatorWidth = 35;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView2.OptionsView.EnableAppearanceOddRow = true;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "工号";
            this.gridColumn1.CustomizationCaption = "工号";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "姓名";
            this.gridColumn2.CustomizationCaption = "姓名";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "焊接方法";
            this.gridColumn3.CustomizationCaption = "焊接方法";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "焊接等级";
            this.gridColumn4.CustomizationCaption = "焊接等级";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "归属部门";
            this.gridColumn5.CustomizationCaption = "归属部门";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.删除,
            this.工程号,
            this.分段号,
            this.阶段,
            this.部门内码,
            this.上级部门,
            this.承接部门,
            this.分配焊接});
            this.gridView1.FixedLineWidth = 1;
            this.gridView1.GridControl = this.dataGrid;
            this.gridView1.IndicatorWidth = 35;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // 删除
            // 
            this.删除.CustomizationCaption = "删除";
            this.删除.Name = "删除";
            this.删除.Visible = true;
            this.删除.VisibleIndex = 0;
            // 
            // 工程号
            // 
            this.工程号.CustomizationCaption = "工程号";
            this.工程号.Name = "工程号";
            this.工程号.Visible = true;
            this.工程号.VisibleIndex = 1;
            // 
            // 分段号
            // 
            this.分段号.CustomizationCaption = "分段号";
            this.分段号.Name = "分段号";
            this.分段号.Visible = true;
            this.分段号.VisibleIndex = 2;
            // 
            // 阶段
            // 
            this.阶段.Caption = "阶段";
            this.阶段.Name = "阶段";
            this.阶段.Visible = true;
            this.阶段.VisibleIndex = 3;
            // 
            // 部门内码
            // 
            this.部门内码.Caption = "部门内码";
            this.部门内码.Name = "部门内码";
            this.部门内码.Visible = true;
            this.部门内码.VisibleIndex = 4;
            // 
            // 上级部门
            // 
            this.上级部门.Caption = "上级部门";
            this.上级部门.Name = "上级部门";
            this.上级部门.Visible = true;
            this.上级部门.VisibleIndex = 5;
            // 
            // 承接部门
            // 
            this.承接部门.Caption = "承接部门";
            this.承接部门.Name = "承接部门";
            this.承接部门.Visible = true;
            this.承接部门.VisibleIndex = 6;
            // 
            // 分配焊接
            // 
            this.分配焊接.Caption = "分配焊接";
            this.分配焊接.Name = "分配焊接";
            this.分配焊接.Visible = true;
            this.分配焊接.VisibleIndex = 7;
            // 
            // GroupBox2
            // 
            this.GroupBox2.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.GroupBox2.Appearance.Options.UseBackColor = true;
            this.GroupBox2.Controls.Add(this.efLabelText6);
            this.GroupBox2.Controls.Add(this.efLabelText5);
            this.GroupBox2.Controls.Add(this.efLabel4);
            this.GroupBox2.Controls.Add(this.efLabel3);
            this.GroupBox2.Controls.Add(this.efLabelText4);
            this.GroupBox2.Controls.Add(this.efLabelText3);
            this.GroupBox2.Controls.Add(this.efLabel2);
            this.GroupBox2.Controls.Add(this.efLabel1);
            this.GroupBox2.Controls.Add(this.efLabelText2);
            this.GroupBox2.Controls.Add(this.efLabelText1);
            this.GroupBox2.Controls.Add(this.FProcessname);
            this.GroupBox2.Controls.Add(this.Label8);
            this.GroupBox2.Controls.Add(this.Label4);
            this.GroupBox2.Controls.Add(this.Label5);
            this.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupBox2.Location = new System.Drawing.Point(2, 162);
            this.GroupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(1496, 342);
            this.GroupBox2.TabIndex = 6;
            this.GroupBox2.Text = "焊缝信息";
            // 
            // efLabelText6
            // 
            this.efLabelText6.BackColor = System.Drawing.Color.Transparent;
            this.efLabelText6.EFArrange = EF.ArrangeMode.horizontal;
            this.efLabelText6.EFCname = "";
            this.efLabelText6.EFEname = null;
            this.efLabelText6.EFEnterText = "";
            this.efLabelText6.EFLeaveExpression = ".*";
            this.efLabelText6.EFLen = 32767;
            this.efLabelText6.EFType = EF.ValueType.EFString;
            this.efLabelText6.EFUpperCase = false;
            this.efLabelText6.Location = new System.Drawing.Point(1029, 135);
            this.efLabelText6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.efLabelText6.Name = "efLabelText6";
            this.efLabelText6.ReadOnly = false;
            this.efLabelText6.Size = new System.Drawing.Size(230, 30);
            this.efLabelText6.TabIndex = 33;
            // 
            // efLabelText5
            // 
            this.efLabelText5.BackColor = System.Drawing.Color.Transparent;
            this.efLabelText5.EFArrange = EF.ArrangeMode.horizontal;
            this.efLabelText5.EFCname = "";
            this.efLabelText5.EFEname = null;
            this.efLabelText5.EFEnterText = "";
            this.efLabelText5.EFLeaveExpression = ".*";
            this.efLabelText5.EFLen = 32767;
            this.efLabelText5.EFType = EF.ValueType.EFString;
            this.efLabelText5.EFUpperCase = false;
            this.efLabelText5.Location = new System.Drawing.Point(1029, 75);
            this.efLabelText5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.efLabelText5.Name = "efLabelText5";
            this.efLabelText5.ReadOnly = false;
            this.efLabelText5.Size = new System.Drawing.Size(230, 30);
            this.efLabelText5.TabIndex = 32;
            // 
            // efLabel4
            // 
            this.efLabel4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.efLabel4.Location = new System.Drawing.Point(944, 140);
            this.efLabel4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.efLabel4.Name = "efLabel4";
            this.efLabel4.Size = new System.Drawing.Size(107, 30);
            this.efLabel4.TabIndex = 31;
            this.efLabel4.Text = "焊接方法";
            // 
            // efLabel3
            // 
            this.efLabel3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.efLabel3.Location = new System.Drawing.Point(944, 75);
            this.efLabel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.efLabel3.Name = "efLabel3";
            this.efLabel3.Size = new System.Drawing.Size(107, 30);
            this.efLabel3.TabIndex = 30;
            this.efLabel3.Text = "分段号";
            // 
            // efLabelText4
            // 
            this.efLabelText4.BackColor = System.Drawing.Color.Transparent;
            this.efLabelText4.EFArrange = EF.ArrangeMode.horizontal;
            this.efLabelText4.EFCname = "";
            this.efLabelText4.EFEname = null;
            this.efLabelText4.EFEnterText = "";
            this.efLabelText4.EFLeaveExpression = ".*";
            this.efLabelText4.EFLen = 32767;
            this.efLabelText4.EFType = EF.ValueType.EFString;
            this.efLabelText4.EFUpperCase = false;
            this.efLabelText4.Location = new System.Drawing.Point(584, 140);
            this.efLabelText4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.efLabelText4.Name = "efLabelText4";
            this.efLabelText4.ReadOnly = false;
            this.efLabelText4.Size = new System.Drawing.Size(230, 30);
            this.efLabelText4.TabIndex = 29;
            // 
            // efLabelText3
            // 
            this.efLabelText3.BackColor = System.Drawing.Color.Transparent;
            this.efLabelText3.EFArrange = EF.ArrangeMode.horizontal;
            this.efLabelText3.EFCname = "";
            this.efLabelText3.EFEname = null;
            this.efLabelText3.EFEnterText = "";
            this.efLabelText3.EFLeaveExpression = ".*";
            this.efLabelText3.EFLen = 32767;
            this.efLabelText3.EFType = EF.ValueType.EFString;
            this.efLabelText3.EFUpperCase = false;
            this.efLabelText3.Location = new System.Drawing.Point(584, 71);
            this.efLabelText3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.efLabelText3.Name = "efLabelText3";
            this.efLabelText3.ReadOnly = false;
            this.efLabelText3.Size = new System.Drawing.Size(230, 30);
            this.efLabelText3.TabIndex = 28;
            // 
            // efLabel2
            // 
            this.efLabel2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.efLabel2.Location = new System.Drawing.Point(469, 145);
            this.efLabel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.efLabel2.Name = "efLabel2";
            this.efLabel2.Size = new System.Drawing.Size(107, 30);
            this.efLabel2.TabIndex = 27;
            this.efLabel2.Text = "焊缝位置";
            // 
            // efLabel1
            // 
            this.efLabel1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.efLabel1.Location = new System.Drawing.Point(469, 71);
            this.efLabel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.efLabel1.Name = "efLabel1";
            this.efLabel1.Size = new System.Drawing.Size(107, 30);
            this.efLabel1.TabIndex = 26;
            this.efLabel1.Text = "工程号";
            // 
            // efLabelText2
            // 
            this.efLabelText2.BackColor = System.Drawing.Color.Transparent;
            this.efLabelText2.EFArrange = EF.ArrangeMode.horizontal;
            this.efLabelText2.EFCname = "";
            this.efLabelText2.EFEname = null;
            this.efLabelText2.EFEnterText = "";
            this.efLabelText2.EFLeaveExpression = ".*";
            this.efLabelText2.EFLen = 32767;
            this.efLabelText2.EFType = EF.ValueType.EFString;
            this.efLabelText2.EFUpperCase = false;
            this.efLabelText2.Location = new System.Drawing.Point(133, 149);
            this.efLabelText2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.efLabelText2.Name = "efLabelText2";
            this.efLabelText2.ReadOnly = false;
            this.efLabelText2.Size = new System.Drawing.Size(236, 30);
            this.efLabelText2.TabIndex = 25;
            // 
            // efLabelText1
            // 
            this.efLabelText1.BackColor = System.Drawing.Color.Transparent;
            this.efLabelText1.EFArrange = EF.ArrangeMode.horizontal;
            this.efLabelText1.EFCname = "";
            this.efLabelText1.EFEname = null;
            this.efLabelText1.EFEnterText = "";
            this.efLabelText1.EFLeaveExpression = ".*";
            this.efLabelText1.EFLen = 32767;
            this.efLabelText1.EFType = EF.ValueType.EFString;
            this.efLabelText1.EFUpperCase = false;
            this.efLabelText1.Location = new System.Drawing.Point(133, 220);
            this.efLabelText1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.efLabelText1.Name = "efLabelText1";
            this.efLabelText1.ReadOnly = false;
            this.efLabelText1.Size = new System.Drawing.Size(236, 30);
            this.efLabelText1.TabIndex = 24;
            // 
            // FProcessname
            // 
            this.FProcessname.BackColor = System.Drawing.Color.Transparent;
            this.FProcessname.EFArrange = EF.ArrangeMode.horizontal;
            this.FProcessname.EFCname = "";
            this.FProcessname.EFEname = null;
            this.FProcessname.EFEnterText = "";
            this.FProcessname.EFLeaveExpression = ".*";
            this.FProcessname.EFLen = 32767;
            this.FProcessname.EFType = EF.ValueType.EFString;
            this.FProcessname.EFUpperCase = false;
            this.FProcessname.Location = new System.Drawing.Point(139, 64);
            this.FProcessname.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FProcessname.Name = "FProcessname";
            this.FProcessname.ReadOnly = false;
            this.FProcessname.Size = new System.Drawing.Size(230, 30);
            this.FProcessname.TabIndex = 20;
            // 
            // Label8
            // 
            this.Label8.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.Label8.Location = new System.Drawing.Point(23, 215);
            this.Label8.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(101, 30);
            this.Label8.TabIndex = 18;
            this.Label8.Text = "等级";
            // 
            // Label4
            // 
            this.Label4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.Label4.Location = new System.Drawing.Point(23, 145);
            this.Label4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(101, 31);
            this.Label4.TabIndex = 14;
            this.Label4.Text = "焊缝长度";
            // 
            // Label5
            // 
            this.Label5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.Label5.Location = new System.Drawing.Point(23, 63);
            this.Label5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(107, 30);
            this.Label5.TabIndex = 10;
            this.Label5.Text = "焊缝号";
            // 
            // efGroupBox2
            // 
            this.efGroupBox2.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.efGroupBox2.Appearance.Options.UseBackColor = true;
            this.efGroupBox2.Controls.Add(this.GroupBox2);
            this.efGroupBox2.Controls.Add(this.efGroupBox1);
            this.efGroupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.efGroupBox2.Location = new System.Drawing.Point(0, 0);
            this.efGroupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.efGroupBox2.Name = "efGroupBox2";
            this.efGroupBox2.Size = new System.Drawing.Size(1500, 506);
            this.efGroupBox2.TabIndex = 7;
            // 
            // efGroupBox1
            // 
            this.efGroupBox1.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.efGroupBox1.Appearance.Options.UseBackColor = true;
            this.efGroupBox1.Controls.Add(this.efCheckBox1);
            this.efGroupBox1.Controls.Add(this.butOK);
            this.efGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.efGroupBox1.Location = new System.Drawing.Point(2, 30);
            this.efGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.efGroupBox1.Name = "efGroupBox1";
            this.efGroupBox1.Size = new System.Drawing.Size(1496, 132);
            this.efGroupBox1.TabIndex = 5;
            this.efGroupBox1.Text = "选项";
            // 
            // efCheckBox1
            // 
            this.efCheckBox1.AutoSize = true;
            this.efCheckBox1.BackColor = System.Drawing.Color.Transparent;
            this.efCheckBox1.Checked = true;
            this.efCheckBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.efCheckBox1.Location = new System.Drawing.Point(50, 69);
            this.efCheckBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.efCheckBox1.Name = "efCheckBox1";
            this.efCheckBox1.Size = new System.Drawing.Size(137, 26);
            this.efCheckBox1.TabIndex = 18;
            this.efCheckBox1.Text = "开启智能辅助";
            this.efCheckBox1.UseVisualStyleBackColor = true;
            this.efCheckBox1.CheckedChanged += new System.EventHandler(this.efCheckBox1_CheckedChanged);
            // 
            // butOK
            // 
            this.butOK.Authorizable = false;
            this.butOK.EnabledEx = true;
            this.butOK.FnNo = 0;
            this.butOK.Hint = "";
            this.butOK.Location = new System.Drawing.Point(646, 69);
            this.butOK.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(210, 36);
            this.butOK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.butOK.TabIndex = 17;
            this.butOK.Text = "选定";
            this.butOK.ViewMode = EF.ViewModeEnum.Enable;
            // 
            // FormMCCL00019
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1500, 1051);
            this.Controls.Add(this.efGroupBox3);
            this.Controls.Add(this.efGroupBox2);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormMCCL00019";
            this.Text = "选择焊工";
            this.Load += new System.EventHandler(this.FormMCCL0006_Load);
            this.Controls.SetChildIndex(this.efGroupBox2, 0);
            this.Controls.SetChildIndex(this.efGroupBox3, 0);
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox3)).EndInit();
            this.efGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupBox2)).EndInit();
            this.GroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox2)).EndInit();
            this.efGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox1)).EndInit();
            this.efGroupBox1.ResumeLayout(false);
            this.efGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.butOK)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private EF.EFGroupBox efGroupBox3;
        private EF.EFDevGrid dataGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn 删除;
        private DevExpress.XtraGrid.Columns.GridColumn 工程号;
        private DevExpress.XtraGrid.Columns.GridColumn 分段号;
        private DevExpress.XtraGrid.Columns.GridColumn 阶段;
        private DevExpress.XtraGrid.Columns.GridColumn 部门内码;
        private DevExpress.XtraGrid.Columns.GridColumn 上级部门;
        private DevExpress.XtraGrid.Columns.GridColumn 承接部门;
        private DevExpress.XtraGrid.Columns.GridColumn 分配焊接;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private EF.EFGroupBox GroupBox2;
        private EF.EFLabel Label8;
        private EF.EFLabel Label4;
        private EF.EFLabel Label5;
        private EF.EFGroupBox efGroupBox2;
        private EF.EFGroupBox efGroupBox1;
        private EF.EFButton butOK;
        private EF.EFLabelText FProcessname;
        private EF.EFCheckBox efCheckBox1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private EF.EFLabelText efLabelText6;
        private EF.EFLabelText efLabelText5;
        private EF.EFLabel efLabel4;
        private EF.EFLabel efLabel3;
        private EF.EFLabelText efLabelText4;
        private EF.EFLabelText efLabelText3;
        private EF.EFLabel efLabel2;
        private EF.EFLabel efLabel1;
        private EF.EFLabelText efLabelText2;
        private EF.EFLabelText efLabelText1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;

    }
}