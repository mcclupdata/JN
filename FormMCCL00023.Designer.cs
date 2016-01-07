namespace MC
{
    partial class FormMCCL00023
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
            this.nom = new EF.EFLabelText();
            this.FName = new EF.EFLabelText();
            this.efGroupBox2 = new EF.EFGroupBox(this.components);
            this.butCancel = new EF.EFButton();
            this.butOK = new EF.EFButton();
            this.dataGrid = new EF.EFDevGrid();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CPART1_NAME2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CPART2_NAME2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CWELD_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CRULNUM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CWELD_PASS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CWELD_MOD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CWELD_MATERIAL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CWELD_I_MAX = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CWELD_I_MIN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CWELD_V_MAX = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CWELD_V_MIN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox1)).BeginInit();
            this.efGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox2)).BeginInit();
            this.efGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.butCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.butOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // efGroupBox1
            // 
            this.efGroupBox1.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.efGroupBox1.Appearance.Options.UseBackColor = true;
            this.efGroupBox1.Controls.Add(this.nom);
            this.efGroupBox1.Controls.Add(this.FName);
            this.efGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.efGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.efGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.efGroupBox1.Name = "efGroupBox1";
            this.efGroupBox1.Size = new System.Drawing.Size(1328, 101);
            this.efGroupBox1.TabIndex = 4;
            this.efGroupBox1.Text = "任务概要";
            // 
            // nom
            // 
            this.nom.BackColor = System.Drawing.Color.Transparent;
            this.nom.EFArrange = EF.ArrangeMode.horizontal;
            this.nom.EFCname = "焊机";
            this.nom.EFEname = null;
            this.nom.EFEnterText = "";
            this.nom.EFLeaveExpression = ".*";
            this.nom.EFLen = 32767;
            this.nom.EFType = EF.ValueType.EFString;
            this.nom.EFUpperCase = false;
            this.nom.Location = new System.Drawing.Point(310, 42);
            this.nom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nom.Name = "nom";
            this.nom.ReadOnly = true;
            this.nom.Size = new System.Drawing.Size(257, 29);
            this.nom.TabIndex = 1;
            // 
            // FName
            // 
            this.FName.BackColor = System.Drawing.Color.Transparent;
            this.FName.EFArrange = EF.ArrangeMode.horizontal;
            this.FName.EFCname = "焊工";
            this.FName.EFEname = null;
            this.FName.EFEnterText = "";
            this.FName.EFLeaveExpression = ".*";
            this.FName.EFLen = 32767;
            this.FName.EFType = EF.ValueType.EFString;
            this.FName.EFUpperCase = false;
            this.FName.Location = new System.Drawing.Point(19, 42);
            this.FName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FName.Name = "FName";
            this.FName.ReadOnly = true;
            this.FName.Size = new System.Drawing.Size(266, 29);
            this.FName.TabIndex = 0;
            // 
            // efGroupBox2
            // 
            this.efGroupBox2.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.efGroupBox2.Appearance.Options.UseBackColor = true;
            this.efGroupBox2.Controls.Add(this.butCancel);
            this.efGroupBox2.Controls.Add(this.butOK);
            this.efGroupBox2.Controls.Add(this.dataGrid);
            this.efGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.efGroupBox2.Location = new System.Drawing.Point(0, 101);
            this.efGroupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.efGroupBox2.Name = "efGroupBox2";
            this.efGroupBox2.Size = new System.Drawing.Size(1328, 470);
            this.efGroupBox2.TabIndex = 5;
            this.efGroupBox2.Text = "明细";
            // 
            // butCancel
            // 
            this.butCancel.Authorizable = false;
            this.butCancel.EnabledEx = true;
            this.butCancel.FnNo = 0;
            this.butCancel.Hint = "";
            this.butCancel.Location = new System.Drawing.Point(591, 390);
            this.butCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(147, 69);
            this.butCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.butCancel.TabIndex = 2;
            this.butCancel.Text = "取消";
            this.butCancel.ViewMode = EF.ViewModeEnum.Enable;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butOK
            // 
            this.butOK.Authorizable = false;
            this.butOK.EnabledEx = true;
            this.butOK.FnNo = 0;
            this.butOK.Hint = "";
            this.butOK.Location = new System.Drawing.Point(290, 390);
            this.butOK.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(147, 69);
            this.butOK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.butOK.TabIndex = 1;
            this.butOK.Text = "确定";
            this.butOK.ViewMode = EF.ViewModeEnum.Enable;
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // dataGrid
            // 
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.Location = new System.Drawing.Point(2, 30);
            this.dataGrid.MainView = this.gridView1;
            this.dataGrid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.Size = new System.Drawing.Size(1324, 438);
            this.dataGrid.TabIndex = 0;
            this.dataGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.CPART1_NAME2,
            this.CPART2_NAME2,
            this.CWELD_NO,
            this.CRULNUM,
            this.CWELD_PASS,
            this.gridColumn1,
            this.CWELD_MOD,
            this.CWELD_MATERIAL,
            this.CWELD_I_MAX,
            this.CWELD_I_MIN,
            this.CWELD_V_MAX,
            this.CWELD_V_MIN});
            this.gridView1.FixedLineWidth = 1;
            this.gridView1.GridControl = this.dataGrid;
            this.gridView1.IndicatorWidth = 35;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // CPART1_NAME2
            // 
            this.CPART1_NAME2.Caption = "焊缝名称1";
            this.CPART1_NAME2.FieldName = "PART1_NAME2";
            this.CPART1_NAME2.Name = "CPART1_NAME2";
            this.CPART1_NAME2.Visible = true;
            this.CPART1_NAME2.VisibleIndex = 1;
            this.CPART1_NAME2.Width = 108;
            // 
            // CPART2_NAME2
            // 
            this.CPART2_NAME2.Caption = "焊缝名称2";
            this.CPART2_NAME2.FieldName = "PART2_NAME2";
            this.CPART2_NAME2.Name = "CPART2_NAME2";
            this.CPART2_NAME2.Visible = true;
            this.CPART2_NAME2.VisibleIndex = 2;
            this.CPART2_NAME2.Width = 121;
            // 
            // CWELD_NO
            // 
            this.CWELD_NO.Caption = "焊缝编号";
            this.CWELD_NO.FieldName = "WELD_NO";
            this.CWELD_NO.Name = "CWELD_NO";
            this.CWELD_NO.Visible = true;
            this.CWELD_NO.VisibleIndex = 3;
            this.CWELD_NO.Width = 122;
            // 
            // CRULNUM
            // 
            this.CRULNUM.Caption = "WPS规程编号";
            this.CRULNUM.FieldName = "RuleNum";
            this.CRULNUM.Name = "CRULNUM";
            this.CRULNUM.Visible = true;
            this.CRULNUM.VisibleIndex = 4;
            this.CRULNUM.Width = 132;
            // 
            // CWELD_PASS
            // 
            this.CWELD_PASS.Caption = "焊道";
            this.CWELD_PASS.FieldName = "WELD_PASS";
            this.CWELD_PASS.Name = "CWELD_PASS";
            this.CWELD_PASS.Visible = true;
            this.CWELD_PASS.VisibleIndex = 5;
            this.CWELD_PASS.Width = 129;
            // 
            // CWELD_MOD
            // 
            this.CWELD_MOD.Caption = "焊接方法";
            this.CWELD_MOD.FieldName = "WELD_MOD";
            this.CWELD_MOD.Name = "CWELD_MOD";
            this.CWELD_MOD.Visible = true;
            this.CWELD_MOD.VisibleIndex = 6;
            this.CWELD_MOD.Width = 108;
            // 
            // CWELD_MATERIAL
            // 
            this.CWELD_MATERIAL.Caption = "焊接材料";
            this.CWELD_MATERIAL.FieldName = "WELD_MATERIAL";
            this.CWELD_MATERIAL.Name = "CWELD_MATERIAL";
            this.CWELD_MATERIAL.Visible = true;
            this.CWELD_MATERIAL.VisibleIndex = 7;
            this.CWELD_MATERIAL.Width = 118;
            // 
            // CWELD_I_MAX
            // 
            this.CWELD_I_MAX.Caption = "最大电流";
            this.CWELD_I_MAX.FieldName = "WELD_I_MAX";
            this.CWELD_I_MAX.Name = "CWELD_I_MAX";
            this.CWELD_I_MAX.Visible = true;
            this.CWELD_I_MAX.VisibleIndex = 8;
            this.CWELD_I_MAX.Width = 112;
            // 
            // CWELD_I_MIN
            // 
            this.CWELD_I_MIN.Caption = "最小电流";
            this.CWELD_I_MIN.FieldName = "WELD_I_MIN";
            this.CWELD_I_MIN.Name = "CWELD_I_MIN";
            this.CWELD_I_MIN.Visible = true;
            this.CWELD_I_MIN.VisibleIndex = 9;
            this.CWELD_I_MIN.Width = 87;
            // 
            // CWELD_V_MAX
            // 
            this.CWELD_V_MAX.Caption = "最大电压";
            this.CWELD_V_MAX.FieldName = "WELD_V_MAX";
            this.CWELD_V_MAX.Name = "CWELD_V_MAX";
            this.CWELD_V_MAX.Visible = true;
            this.CWELD_V_MAX.VisibleIndex = 10;
            // 
            // CWELD_V_MIN
            // 
            this.CWELD_V_MIN.Caption = "最小电压";
            this.CWELD_V_MIN.FieldName = "WELD_V_MIN";
            this.CWELD_V_MIN.Name = "CWELD_V_MIN";
            this.CWELD_V_MIN.Visible = true;
            this.CWELD_V_MIN.VisibleIndex = 11;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "焊机通道";
            this.gridColumn1.FieldName = "FActChannel";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 110;
            // 
            // FormMCCL00023
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1328, 643);
            this.Controls.Add(this.efGroupBox2);
            this.Controls.Add(this.efGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormMCCL00023";
            this.Text = "任务明细";
            this.Controls.SetChildIndex(this.efGroupBox1, 0);
            this.Controls.SetChildIndex(this.efGroupBox2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox1)).EndInit();
            this.efGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox2)).EndInit();
            this.efGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.butCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.butOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private EF.EFGroupBox efGroupBox1;
        private EF.EFLabelText FName;
        private EF.EFGroupBox efGroupBox2;
        private EF.EFLabelText nom;
        private EF.EFDevGrid dataGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn CPART1_NAME2;
        private DevExpress.XtraGrid.Columns.GridColumn CPART2_NAME2;
        private DevExpress.XtraGrid.Columns.GridColumn CWELD_NO;
        private DevExpress.XtraGrid.Columns.GridColumn CRULNUM;
        private DevExpress.XtraGrid.Columns.GridColumn CWELD_PASS;
        private DevExpress.XtraGrid.Columns.GridColumn CWELD_MOD;
        private DevExpress.XtraGrid.Columns.GridColumn CWELD_MATERIAL;
        private DevExpress.XtraGrid.Columns.GridColumn CWELD_I_MAX;
        private DevExpress.XtraGrid.Columns.GridColumn CWELD_I_MIN;
        private DevExpress.XtraGrid.Columns.GridColumn CWELD_V_MAX;
        private DevExpress.XtraGrid.Columns.GridColumn CWELD_V_MIN;
        private EF.EFButton butCancel;
        private EF.EFButton butOK;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}