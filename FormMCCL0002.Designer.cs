namespace MC
{
    partial class FormMCCL0002
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.efGroupBox1 = new EF.EFGroupBox(this.components);
            this.butOK = new EF.EFButton();
            this.butRead = new EF.EFButton();
            this.But_ChooseFile = new EF.EFButton();
            this.txtFileName = new EF.EFLabelText();
            this.efGroupBox2 = new EF.EFGroupBox(this.components);
            this.tabControl1 = new EF.EFTabControl(this.components);
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGrid_WPS = new EF.EFDevGrid();
            this.view = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGrid_WPSSub = new EF.EFDevGrid();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox1)).BeginInit();
            this.efGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.butOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.butRead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.But_ChooseFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox2)).BeginInit();
            this.efGroupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_WPS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.view)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_WPSSub)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // efGroupBox1
            // 
            this.efGroupBox1.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.efGroupBox1.Appearance.Options.UseBackColor = true;
            this.efGroupBox1.Controls.Add(this.butOK);
            this.efGroupBox1.Controls.Add(this.butRead);
            this.efGroupBox1.Controls.Add(this.But_ChooseFile);
            this.efGroupBox1.Controls.Add(this.txtFileName);
            this.efGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.efGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.efGroupBox1.Name = "efGroupBox1";
            this.efGroupBox1.Size = new System.Drawing.Size(959, 114);
            this.efGroupBox1.TabIndex = 4;
            this.efGroupBox1.Text = " ";
            // 
            // butOK
            // 
            this.butOK.Authorizable = false;
            this.butOK.EnabledEx = true;
            this.butOK.FnNo = 0;
            this.butOK.Hint = "";
            this.butOK.Location = new System.Drawing.Point(372, 72);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(75, 36);
            this.butOK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.butOK.TabIndex = 3;
            this.butOK.Text = "导入";
            this.butOK.ViewMode = EF.ViewModeEnum.Enable;
            // 
            // butRead
            // 
            this.butRead.Authorizable = false;
            this.butRead.EnabledEx = true;
            this.butRead.FnNo = 0;
            this.butRead.Hint = "";
            this.butRead.Location = new System.Drawing.Point(116, 72);
            this.butRead.Name = "butRead";
            this.butRead.Size = new System.Drawing.Size(89, 36);
            this.butRead.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.butRead.TabIndex = 2;
            this.butRead.Text = "读取数据";
            this.butRead.ViewMode = EF.ViewModeEnum.Enable;
            // 
            // But_ChooseFile
            // 
            this.But_ChooseFile.Authorizable = false;
            this.But_ChooseFile.EnabledEx = true;
            this.But_ChooseFile.FnNo = 0;
            this.But_ChooseFile.Hint = "";
            this.But_ChooseFile.Location = new System.Drawing.Point(514, 42);
            this.But_ChooseFile.Name = "But_ChooseFile";
            this.But_ChooseFile.Size = new System.Drawing.Size(93, 23);
            this.But_ChooseFile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.But_ChooseFile.TabIndex = 1;
            this.But_ChooseFile.Text = "选择文件";
            this.But_ChooseFile.ViewMode = EF.ViewModeEnum.Enable;
            this.But_ChooseFile.Click += new System.EventHandler(this.But_ChooseFile_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.BackColor = System.Drawing.Color.Transparent;
            this.txtFileName.EFArrange = EF.ArrangeMode.horizontal;
            this.txtFileName.EFCname = "Ecxel文件";
            this.txtFileName.EFEname = null;
            this.txtFileName.EFEnterText = "D:\\code\\JNData\\标准\\WPS标准.xls";
            this.txtFileName.EFLeaveExpression = ".*";
            this.txtFileName.EFLen = 32767;
            this.txtFileName.EFType = EF.ValueType.EFString;
            this.txtFileName.EFUpperCase = false;
            this.txtFileName.Location = new System.Drawing.Point(30, 43);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.ReadOnly = false;
            this.txtFileName.Size = new System.Drawing.Size(465, 23);
            this.txtFileName.TabIndex = 0;
            // 
            // efGroupBox2
            // 
            this.efGroupBox2.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.efGroupBox2.Appearance.Options.UseBackColor = true;
            this.efGroupBox2.Controls.Add(this.tabControl1);
            this.efGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.efGroupBox2.Location = new System.Drawing.Point(0, 114);
            this.efGroupBox2.Name = "efGroupBox2";
            this.efGroupBox2.Size = new System.Drawing.Size(959, 317);
            this.efGroupBox2.TabIndex = 5;
            this.efGroupBox2.Text = "数据";
            this.efGroupBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.efGroupBox2_Paint);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(2, 23);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(955, 292);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGrid_WPS);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage1.Size = new System.Drawing.Size(947, 265);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "WPS规程主体";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // dataGrid_WPS
            // 
            this.dataGrid_WPS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid_WPS.IsUseCustomPageBar = true;
            this.dataGrid_WPS.Location = new System.Drawing.Point(3, 3);
            this.dataGrid_WPS.MainView = this.view;
            this.dataGrid_WPS.Name = "dataGrid_WPS";
            this.dataGrid_WPS.Size = new System.Drawing.Size(941, 259);
            this.dataGrid_WPS.TabIndex = 0;
            this.dataGrid_WPS.UseEmbeddedNavigator = true;
            this.dataGrid_WPS.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.view});
            // 
            // view
            // 
            this.view.FixedLineWidth = 1;
            this.view.GridControl = this.dataGrid_WPS;
            this.view.IndicatorWidth = 35;
            this.view.Name = "view";
            this.view.OptionsView.ColumnAutoWidth = false;
            this.view.OptionsView.EnableAppearanceEvenRow = true;
            this.view.OptionsView.EnableAppearanceOddRow = true;
            this.view.OptionsView.ShowGroupPanel = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGrid_WPSSub);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage2.Size = new System.Drawing.Size(947, 265);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "wps规程-焊道";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.dataGrid_WPSSub_Click);
            // 
            // dataGrid_WPSSub
            // 
            this.dataGrid_WPSSub.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.RelationName = "Level1";
            this.dataGrid_WPSSub.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.dataGrid_WPSSub.Location = new System.Drawing.Point(3, 3);
            this.dataGrid_WPSSub.MainView = this.gridView1;
            this.dataGrid_WPSSub.Name = "dataGrid_WPSSub";
            this.dataGrid_WPSSub.Size = new System.Drawing.Size(941, 259);
            this.dataGrid_WPSSub.TabIndex = 0;
            this.dataGrid_WPSSub.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.dataGrid_WPSSub.Click += new System.EventHandler(this.efDevGrid2_Click);
            // 
            // gridView1
            // 
            this.gridView1.FixedLineWidth = 1;
            this.gridView1.GridControl = this.dataGrid_WPSSub;
            this.gridView1.IndicatorWidth = 35;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // FormMCCL0002
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 477);
            this.Controls.Add(this.efGroupBox2);
            this.Controls.Add(this.efGroupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.Name = "FormMCCL0002";
            this.Text = "WPS规程批量导入";
            this.Load += new System.EventHandler(this.FormMCCL0002_Load);
            this.Controls.SetChildIndex(this.efGroupBox1, 0);
            this.Controls.SetChildIndex(this.efGroupBox2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox1)).EndInit();
            this.efGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.butOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.butRead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.But_ChooseFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox2)).EndInit();
            this.efGroupBox2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_WPS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.view)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid_WPSSub)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private EF.EFGroupBox efGroupBox1;
        private EF.EFLabelText txtFileName;
        private EF.EFGroupBox efGroupBox2;
        private EF.EFButton But_ChooseFile;
        private EF.EFTabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private EF.EFDevGrid dataGrid_WPSSub;
        private EF.EFDevGrid dataGrid_WPS;
        private DevExpress.XtraGrid.Views.Grid.GridView view;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private EF.EFButton butOK;
        private EF.EFButton butRead;

    }
}