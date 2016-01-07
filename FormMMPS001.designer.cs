namespace MM
{
    partial class FormMMPS002
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMMPS002));
            this.efGroupBox1 = new EF.EFGroupBox(this.components);
            this.efLabelText1 = new EF.EFLabelText();
            this.efComboBox1 = new EF.EFComboBox(this.components);
            this.efComboBox3 = new EF.EFComboBox(this.components);
            this.efLabel5 = new EF.EFLabel();
            this.efLabel4 = new EF.EFLabel();
            this.efLabel1 = new EF.EFLabel();
            this.efComboBox2 = new EF.EFComboBox(this.components);
            this.efGroupBox2 = new EF.EFGroupBox(this.components);
            this.efGrid2 = new EF.EFGrid(this.components);
            this.efGroupBox3 = new EF.EFGroupBox(this.components);
            this.efGrid1 = new EF.EFGrid(this.components);
            this.efLabel6 = new EF.EFLabel();
            this.efDateTimePicker3 = new EF.EFDateTimePicker();
            this.efComboBox4 = new EF.EFComboBox(this.components);
            this.efComboBox5 = new EF.EFComboBox(this.components);
            this.efComboBox6 = new EF.EFComboBox(this.components);
            this.efButton1 = new EF.EFButton();
            this.efLabel7 = new EF.EFLabel();
            this.efLabel2 = new EF.EFLabel();
            this.efLabel3 = new EF.EFLabel();
            this.efLabel8 = new EF.EFLabel();
            this.efComboBox7 = new EF.EFComboBox(this.components);
            this.efButton2 = new EF.EFButton();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox1)).BeginInit();
            this.efGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox2)).BeginInit();
            this.efGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.efGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox3)).BeginInit();
            this.efGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.efGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efButton2)).BeginInit();
            this.SuspendLayout();
            // 
            // efGroupBox1
            // 
            this.efGroupBox1.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.efGroupBox1.Appearance.Options.UseBackColor = true;
            this.efGroupBox1.Controls.Add(this.efLabelText1);
            this.efGroupBox1.Controls.Add(this.efComboBox1);
            this.efGroupBox1.Controls.Add(this.efComboBox3);
            this.efGroupBox1.Controls.Add(this.efLabel5);
            this.efGroupBox1.Controls.Add(this.efLabel4);
            this.efGroupBox1.Controls.Add(this.efLabel1);
            this.efGroupBox1.Controls.Add(this.efComboBox2);
            this.efGroupBox1.Location = new System.Drawing.Point(12, 14);
            this.efGroupBox1.Name = "efGroupBox1";
            this.efGroupBox1.Size = new System.Drawing.Size(1000, 82);
            this.efGroupBox1.TabIndex = 18;
            this.efGroupBox1.Text = "查询区域";
            // 
            // efLabelText1
            // 
            this.efLabelText1.BackColor = System.Drawing.Color.Transparent;
            this.efLabelText1.EFArrange = EF.ArrangeMode.horizontal;
            this.efLabelText1.EFCname = "员工：";
            this.efLabelText1.EFEname = null;
            this.efLabelText1.EFEnterText = "";
            this.efLabelText1.EFLeaveExpression = ".*";
            this.efLabelText1.EFLen = 32767;
            this.efLabelText1.EFType = EF.ValueType.EFString;
            this.efLabelText1.EFUpperCase = false;
            this.efLabelText1.Location = new System.Drawing.Point(33, 52);
            this.efLabelText1.Name = "efLabelText1";
            this.efLabelText1.ReadOnly = false;
            this.efLabelText1.Size = new System.Drawing.Size(177, 22);
            this.efLabelText1.TabIndex = 18;
            // 
            // efComboBox1
            // 
            this.efComboBox1.ColumnName = null;
            this.efComboBox1.EFCname = "";
            this.efComboBox1.EFDropDown = false;
            this.efComboBox1.FormattingEnabled = true;
            this.efComboBox1.Items.AddRange(new object[] {
            "制造部",
            "模块部",
            "搭载部",
            "总装部"});
            this.efComboBox1.Location = new System.Drawing.Point(78, 25);
            this.efComboBox1.Name = "efComboBox1";
            this.efComboBox1.Size = new System.Drawing.Size(132, 22);
            this.efComboBox1.SQL = null;
            this.efComboBox1.TabIndex = 12;
            this.efComboBox1.UserValue = "";
            // 
            // efComboBox3
            // 
            this.efComboBox3.ColumnName = null;
            this.efComboBox3.EFCname = "";
            this.efComboBox3.EFDropDown = false;
            this.efComboBox3.FormattingEnabled = true;
            this.efComboBox3.Location = new System.Drawing.Point(579, 25);
            this.efComboBox3.Name = "efComboBox3";
            this.efComboBox3.Size = new System.Drawing.Size(132, 22);
            this.efComboBox3.SQL = null;
            this.efComboBox3.TabIndex = 10;
            this.efComboBox3.UserValue = "";
            // 
            // efLabel5
            // 
            this.efLabel5.Location = new System.Drawing.Point(0, 0);
            this.efLabel5.Name = "efLabel5";
            this.efLabel5.Size = new System.Drawing.Size(0, 14);
            this.efLabel5.TabIndex = 19;
            // 
            // efLabel4
            // 
            this.efLabel4.Location = new System.Drawing.Point(0, 0);
            this.efLabel4.Name = "efLabel4";
            this.efLabel4.Size = new System.Drawing.Size(0, 14);
            this.efLabel4.TabIndex = 20;
            // 
            // efLabel1
            // 
            this.efLabel1.Location = new System.Drawing.Point(0, 0);
            this.efLabel1.Name = "efLabel1";
            this.efLabel1.Size = new System.Drawing.Size(0, 14);
            this.efLabel1.TabIndex = 21;
            // 
            // efComboBox2
            // 
            this.efComboBox2.ColumnName = null;
            this.efComboBox2.EFCname = "";
            this.efComboBox2.EFDropDown = false;
            this.efComboBox2.FormattingEnabled = true;
            this.efComboBox2.Location = new System.Drawing.Point(332, 25);
            this.efComboBox2.Name = "efComboBox2";
            this.efComboBox2.Size = new System.Drawing.Size(132, 22);
            this.efComboBox2.SQL = null;
            this.efComboBox2.TabIndex = 11;
            this.efComboBox2.UserValue = "";
            // 
            // efGroupBox2
            // 
            this.efGroupBox2.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.efGroupBox2.Appearance.Options.UseBackColor = true;
            this.efGroupBox2.Controls.Add(this.efGrid2);
            this.efGroupBox2.Location = new System.Drawing.Point(12, 102);
            this.efGroupBox2.Name = "efGroupBox2";
            this.efGroupBox2.Size = new System.Drawing.Size(1000, 182);
            this.efGroupBox2.TabIndex = 18;
            this.efGroupBox2.Text = "员工信息区域";
            // 
            // efGrid2
            // 
            this.efGrid2.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes;
            this.efGrid2.ColumnInfo = resources.GetString("efGrid2.ColumnInfo");
            this.efGrid2.EFAllowMenu = true;
            this.efGrid2.EFAllowMenuChoice = true;
            this.efGrid2.EFAllowMenuChoiceAll = true;
            this.efGrid2.EFAllowMenuCustomize = false;
            this.efGrid2.EFAllowMenuNew = true;
            this.efGrid2.EFAllowMenuSaveAs = true;
            this.efGrid2.EFChoiceCount = 0;
            this.efGrid2.EFCols = 11;
            this.efGrid2.EFRows = 2;
            this.efGrid2.EFUserCols = 10;
            this.efGrid2.EFUserRows = 1;
            this.efGrid2.Location = new System.Drawing.Point(0, 0);
            this.efGrid2.Name = "efGrid2";
            this.efGrid2.Rows.Count = 2;
            this.efGrid2.Rows.DefaultSize = 19;
            this.efGrid2.ShowCursor = true;
            this.efGrid2.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None;
            this.efGrid2.Size = new System.Drawing.Size(240, 150);
            this.efGrid2.StyleInfo = resources.GetString("efGrid2.StyleInfo");
            this.efGrid2.TabIndex = 0;
            // 
            // efGroupBox3
            // 
            this.efGroupBox3.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.efGroupBox3.Appearance.Options.UseBackColor = true;
            this.efGroupBox3.Controls.Add(this.efGrid1);
            this.efGroupBox3.Controls.Add(this.efLabel6);
            this.efGroupBox3.Controls.Add(this.efDateTimePicker3);
            this.efGroupBox3.Controls.Add(this.efComboBox4);
            this.efGroupBox3.Controls.Add(this.efComboBox5);
            this.efGroupBox3.Controls.Add(this.efComboBox6);
            this.efGroupBox3.Controls.Add(this.efButton1);
            this.efGroupBox3.Controls.Add(this.efLabel7);
            this.efGroupBox3.Controls.Add(this.efLabel2);
            this.efGroupBox3.Controls.Add(this.efLabel3);
            this.efGroupBox3.Controls.Add(this.efLabel8);
            this.efGroupBox3.Controls.Add(this.efComboBox7);
            this.efGroupBox3.Location = new System.Drawing.Point(12, 290);
            this.efGroupBox3.Name = "efGroupBox3";
            this.efGroupBox3.Size = new System.Drawing.Size(1000, 322);
            this.efGroupBox3.TabIndex = 19;
            this.efGroupBox3.Text = "作业人员区域";
            // 
            // efGrid1
            // 
            this.efGrid1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes;
            this.efGrid1.ColumnInfo = resources.GetString("efGrid1.ColumnInfo");
            this.efGrid1.EFAllowMenu = true;
            this.efGrid1.EFAllowMenuChoice = true;
            this.efGrid1.EFAllowMenuChoiceAll = true;
            this.efGrid1.EFAllowMenuCustomize = false;
            this.efGrid1.EFAllowMenuNew = true;
            this.efGrid1.EFAllowMenuSaveAs = true;
            this.efGrid1.EFChoiceCount = 0;
            this.efGrid1.EFCols = 21;
            this.efGrid1.EFRows = 2;
            this.efGrid1.EFUserCols = 20;
            this.efGrid1.EFUserRows = 1;
            this.efGrid1.Location = new System.Drawing.Point(0, 0);
            this.efGrid1.Name = "efGrid1";
            this.efGrid1.Rows.Count = 2;
            this.efGrid1.Rows.DefaultSize = 19;
            this.efGrid1.ShowCursor = true;
            this.efGrid1.ShowThemedHeaders = C1.Win.C1FlexGrid.ShowThemedHeadersEnum.None;
            this.efGrid1.Size = new System.Drawing.Size(240, 150);
            this.efGrid1.StyleInfo = resources.GetString("efGrid1.StyleInfo");
            this.efGrid1.TabIndex = 0;
            // 
            // efLabel6
            // 
            this.efLabel6.Location = new System.Drawing.Point(0, 0);
            this.efLabel6.Name = "efLabel6";
            this.efLabel6.Size = new System.Drawing.Size(0, 14);
            this.efLabel6.TabIndex = 1;
            // 
            // efDateTimePicker3
            // 
            this.efDateTimePicker3.Location = new System.Drawing.Point(91, 25);
            this.efDateTimePicker3.Name = "efDateTimePicker3";
            this.efDateTimePicker3.Size = new System.Drawing.Size(132, 22);
            this.efDateTimePicker3.TabIndex = 12;
            // 
            // efComboBox4
            // 
            this.efComboBox4.ColumnName = null;
            this.efComboBox4.EFCname = "";
            this.efComboBox4.EFDropDown = false;
            this.efComboBox4.FormattingEnabled = true;
            this.efComboBox4.Items.AddRange(new object[] {
            "制造部",
            "模块部",
            "搭载部",
            "总装部"});
            this.efComboBox4.Location = new System.Drawing.Point(91, 72);
            this.efComboBox4.Name = "efComboBox4";
            this.efComboBox4.Size = new System.Drawing.Size(132, 22);
            this.efComboBox4.SQL = null;
            this.efComboBox4.TabIndex = 8;
            this.efComboBox4.UserValue = "";
            // 
            // efComboBox5
            // 
            this.efComboBox5.ColumnName = null;
            this.efComboBox5.EFCname = "";
            this.efComboBox5.EFDropDown = false;
            this.efComboBox5.FormattingEnabled = true;
            this.efComboBox5.Location = new System.Drawing.Point(91, 149);
            this.efComboBox5.Name = "efComboBox5";
            this.efComboBox5.Size = new System.Drawing.Size(132, 22);
            this.efComboBox5.SQL = null;
            this.efComboBox5.TabIndex = 8;
            this.efComboBox5.UserValue = "";
            // 
            // efComboBox6
            // 
            this.efComboBox6.ColumnName = null;
            this.efComboBox6.EFCname = "";
            this.efComboBox6.EFDropDown = false;
            this.efComboBox6.FormattingEnabled = true;
            this.efComboBox6.Location = new System.Drawing.Point(91, 123);
            this.efComboBox6.Name = "efComboBox6";
            this.efComboBox6.Size = new System.Drawing.Size(132, 22);
            this.efComboBox6.SQL = null;
            this.efComboBox6.TabIndex = 8;
            this.efComboBox6.UserValue = "";
            // 
            // efButton1
            // 
            this.efButton1.Authorizable = false;
            this.efButton1.EnabledEx = true;
            this.efButton1.FnNo = 0;
            this.efButton1.Hint = "";
            this.efButton1.Location = new System.Drawing.Point(0, 0);
            this.efButton1.Name = "efButton1";
            this.efButton1.Size = new System.Drawing.Size(75, 23);
            this.efButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.efButton1.TabIndex = 13;
            this.efButton1.ViewMode = EF.ViewModeEnum.Enable;
            // 
            // efLabel7
            // 
            this.efLabel7.Location = new System.Drawing.Point(0, 0);
            this.efLabel7.Name = "efLabel7";
            this.efLabel7.Size = new System.Drawing.Size(0, 14);
            this.efLabel7.TabIndex = 14;
            // 
            // efLabel2
            // 
            this.efLabel2.Location = new System.Drawing.Point(0, 0);
            this.efLabel2.Name = "efLabel2";
            this.efLabel2.Size = new System.Drawing.Size(0, 14);
            this.efLabel2.TabIndex = 15;
            // 
            // efLabel3
            // 
            this.efLabel3.Location = new System.Drawing.Point(0, 0);
            this.efLabel3.Name = "efLabel3";
            this.efLabel3.Size = new System.Drawing.Size(0, 14);
            this.efLabel3.TabIndex = 16;
            // 
            // efLabel8
            // 
            this.efLabel8.Location = new System.Drawing.Point(0, 0);
            this.efLabel8.Name = "efLabel8";
            this.efLabel8.Size = new System.Drawing.Size(0, 14);
            this.efLabel8.TabIndex = 17;
            // 
            // efComboBox7
            // 
            this.efComboBox7.ColumnName = null;
            this.efComboBox7.EFCname = "";
            this.efComboBox7.EFDropDown = false;
            this.efComboBox7.FormattingEnabled = true;
            this.efComboBox7.Location = new System.Drawing.Point(91, 98);
            this.efComboBox7.Name = "efComboBox7";
            this.efComboBox7.Size = new System.Drawing.Size(132, 22);
            this.efComboBox7.SQL = null;
            this.efComboBox7.TabIndex = 8;
            this.efComboBox7.UserValue = "";
            // 
            // efButton2
            // 
            this.efButton2.Authorizable = false;
            this.efButton2.EnabledEx = true;
            this.efButton2.FnNo = 0;
            this.efButton2.Hint = "";
            this.efButton2.Location = new System.Drawing.Point(309, 652);
            this.efButton2.Name = "efButton2";
            this.efButton2.Size = new System.Drawing.Size(75, 23);
            this.efButton2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.efButton2.TabIndex = 20;
            this.efButton2.Text = "efButton2";
            this.efButton2.ViewMode = EF.ViewModeEnum.Enable;
            // 
            // FormMMPS002
            // 
            this.ClientSize = new System.Drawing.Size(1024, 746);
            this.Controls.Add(this.efButton2);
            this.Controls.Add(this.efGroupBox3);
            this.Controls.Add(this.efGroupBox1);
            this.Controls.Add(this.efGroupBox2);
            this.EFMsgInfo = " ";
            this.Name = "FormMMPS002";
            this.Text = "人员作业实绩报工";
            this.Controls.SetChildIndex(this.efGroupBox2, 0);
            this.Controls.SetChildIndex(this.efGroupBox1, 0);
            this.Controls.SetChildIndex(this.efGroupBox3, 0);
            this.Controls.SetChildIndex(this.efButton2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox1)).EndInit();
            this.efGroupBox1.ResumeLayout(false);
            this.efGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox2)).EndInit();
            this.efGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.efGrid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox3)).EndInit();
            this.efGroupBox3.ResumeLayout(false);
            this.efGroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.efGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efButton2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private EF.EFGroupBox efGroupBox1;
        private EF.EFLabelText efLabelText1;
        private EF.EFComboBox efComboBox1;
        private EF.EFComboBox efComboBox3;
        private EF.EFLabel efLabel5;
        private EF.EFLabel efLabel4;
        private EF.EFLabel efLabel1;
        private EF.EFComboBox efComboBox2;
        private EF.EFGroupBox efGroupBox2;
        private EF.EFGrid efGrid2;
        private EF.EFGroupBox efGroupBox3;
        private EF.EFComboBox efComboBox4;
        private EF.EFComboBox efComboBox6;
        private EF.EFButton efButton1;
        private EF.EFLabel efLabel2;
        private EF.EFLabel efLabel3;
        private EF.EFLabel efLabel8;
        private EF.EFComboBox efComboBox7;
        private EF.EFLabel efLabel6;
        private EF.EFDateTimePicker efDateTimePicker3;
        private EF.EFComboBox efComboBox5;
        private EF.EFLabel efLabel7;
        private EF.EFGrid efGrid1;
        private EF.EFButton efButton2;
    }
}
