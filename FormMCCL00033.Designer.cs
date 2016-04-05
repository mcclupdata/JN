namespace MC
{
    partial class FormMCCL00033
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMCCL00033));
            this.leftPanel = new EF.EFPanelStyleXP();
            this.Departments = new EF.EFTreeView(this.components);
            this.mainms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addms = new System.Windows.Forms.ToolStripMenuItem();
            this.Separatorms = new System.Windows.Forms.ToolStripSeparator();
            this.delms = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.modifyms = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.fullPanel = new EF.EFPanelStyleXP();
            this.IsWeld = new EF.EFCheckBox();
            this.Fleve = new EF.EFDevLookUpEdit(this.components);
            this.FParentID = new EF.EFDevLookUpEdit(this.components);
            this.butCancel = new EF.EFButton();
            this.butOK = new EF.EFButton();
            this.FID = new EF.EFTextBox();
            this.efLabel2 = new EF.EFLabel();
            this.lbl1 = new EF.EFLabel();
            this.FName = new EF.EFTextBox();
            this.efLabel1 = new EF.EFLabel();
            this.efPanelStyleXP3 = new EF.EFPanelStyleXP();
            this.leftPanel.SuspendLayout();
            this.mainms.SuspendLayout();
            this.fullPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Fleve.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FParentID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.butCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.butOK)).BeginInit();
            this.efPanelStyleXP3.SuspendLayout();
            this.SuspendLayout();
            // 
            // leftPanel
            // 
            this.leftPanel.Controls.Add(this.Departments);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftPanel.Location = new System.Drawing.Point(0, 0);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(278, 573);
            this.leftPanel.TabIndex = 4;
            // 
            // Departments
            // 
            this.Departments.ContextMenuStrip = this.mainms;
            this.Departments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Departments.ImageIndex = 0;
            this.Departments.ImageList = this.imageList1;
            this.Departments.Location = new System.Drawing.Point(0, 0);
            this.Departments.Name = "Departments";
            this.Departments.SelectedImageIndex = 0;
            this.Departments.Size = new System.Drawing.Size(278, 573);
            this.Departments.TabIndex = 0;
            // 
            // mainms
            // 
            this.mainms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addms,
            this.Separatorms,
            this.delms,
            this.toolStripSeparator1,
            this.modifyms});
            this.mainms.Name = "contextMenuStrip1";
            this.mainms.Size = new System.Drawing.Size(125, 82);
            // 
            // addms
            // 
            this.addms.Name = "addms";
            this.addms.Size = new System.Drawing.Size(124, 22);
            this.addms.Text = "增加部门";
            this.addms.Click += new System.EventHandler(this.addms_Click);
            // 
            // Separatorms
            // 
            this.Separatorms.Name = "Separatorms";
            this.Separatorms.Size = new System.Drawing.Size(121, 6);
            // 
            // delms
            // 
            this.delms.Name = "delms";
            this.delms.Size = new System.Drawing.Size(124, 22);
            this.delms.Text = "删除部门";
            this.delms.Click += new System.EventHandler(this.delms_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(121, 6);
            // 
            // modifyms
            // 
            this.modifyms.Name = "modifyms";
            this.modifyms.Size = new System.Drawing.Size(124, 22);
            this.modifyms.Text = "编辑部门";
            this.modifyms.Click += new System.EventHandler(this.modifyms_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "ooopic.ico");
            this.imageList1.Images.SetKeyName(1, "ooopic.jpg");
            this.imageList1.Images.SetKeyName(2, "dep.jpg");
            // 
            // fullPanel
            // 
            this.fullPanel.Controls.Add(this.IsWeld);
            this.fullPanel.Controls.Add(this.Fleve);
            this.fullPanel.Controls.Add(this.FParentID);
            this.fullPanel.Controls.Add(this.butCancel);
            this.fullPanel.Controls.Add(this.butOK);
            this.fullPanel.Controls.Add(this.FID);
            this.fullPanel.Controls.Add(this.efLabel2);
            this.fullPanel.Controls.Add(this.lbl1);
            this.fullPanel.Controls.Add(this.FName);
            this.fullPanel.Controls.Add(this.efLabel1);
            this.fullPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fullPanel.Location = new System.Drawing.Point(278, 0);
            this.fullPanel.Name = "fullPanel";
            this.fullPanel.Size = new System.Drawing.Size(615, 573);
            this.fullPanel.TabIndex = 5;
            // 
            // IsWeld
            // 
            this.IsWeld.AutoSize = true;
            this.IsWeld.BackColor = System.Drawing.Color.Transparent;
            this.IsWeld.Location = new System.Drawing.Point(98, 235);
            this.IsWeld.Margin = new System.Windows.Forms.Padding(2);
            this.IsWeld.Name = "IsWeld";
            this.IsWeld.Size = new System.Drawing.Size(98, 18);
            this.IsWeld.TabIndex = 25;
            this.IsWeld.Text = "是否焊接部门";
            this.IsWeld.UseVisualStyleBackColor = true;
            // 
            // Fleve
            // 
            this.Fleve.EditValue = 0;
            this.Fleve.Location = new System.Drawing.Point(98, 87);
            this.Fleve.Name = "Fleve";
            this.Fleve.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Fleve.Size = new System.Drawing.Size(297, 21);
            this.Fleve.TabIndex = 23;
            // 
            // FParentID
            // 
            this.FParentID.EditValue = 0;
            this.FParentID.Location = new System.Drawing.Point(98, 171);
            this.FParentID.Name = "FParentID";
            this.FParentID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FParentID.Properties.DisplayMember = "FDepartName";
            this.FParentID.Properties.ValueMember = "FID";
            this.FParentID.Size = new System.Drawing.Size(297, 21);
            this.FParentID.TabIndex = 22;
            // 
            // butCancel
            // 
            this.butCancel.Authorizable = false;
            this.butCancel.EnabledEx = true;
            this.butCancel.FnNo = 0;
            this.butCancel.Hint = "";
            this.butCancel.Location = new System.Drawing.Point(283, 300);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.butCancel.TabIndex = 21;
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
            this.butOK.Location = new System.Drawing.Point(98, 300);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(75, 23);
            this.butOK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.butOK.TabIndex = 13;
            this.butOK.Text = "提交";
            this.butOK.ViewMode = EF.ViewModeEnum.Enable;
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // FID
            // 
            this.FID.EFEname = null;
            this.FID.EFLeaveExpression = ".*";
            this.FID.EFLen = 32767;
            this.FID.Location = new System.Drawing.Point(17, 257);
            this.FID.Name = "FID";
            this.FID.Size = new System.Drawing.Size(33, 22);
            this.FID.TabIndex = 12;
            this.FID.Visible = false;
            // 
            // efLabel2
            // 
            this.efLabel2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.efLabel2.Location = new System.Drawing.Point(17, 174);
            this.efLabel2.Name = "efLabel2";
            this.efLabel2.Size = new System.Drawing.Size(75, 14);
            this.efLabel2.TabIndex = 4;
            this.efLabel2.Text = "上级部门";
            // 
            // lbl1
            // 
            this.lbl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl1.Location = new System.Drawing.Point(17, 90);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(75, 14);
            this.lbl1.TabIndex = 2;
            this.lbl1.Text = "部门级别";
            // 
            // FName
            // 
            this.FName.EFEname = null;
            this.FName.EFLeaveExpression = ".*";
            this.FName.EFLen = 32767;
            this.FName.Location = new System.Drawing.Point(98, 25);
            this.FName.Name = "FName";
            this.FName.Size = new System.Drawing.Size(297, 22);
            this.FName.TabIndex = 1;
            // 
            // efLabel1
            // 
            this.efLabel1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.efLabel1.Location = new System.Drawing.Point(17, 28);
            this.efLabel1.Name = "efLabel1";
            this.efLabel1.Size = new System.Drawing.Size(75, 14);
            this.efLabel1.TabIndex = 0;
            this.efLabel1.Text = "部门名称";
            // 
            // efPanelStyleXP3
            // 
            this.efPanelStyleXP3.Controls.Add(this.fullPanel);
            this.efPanelStyleXP3.Controls.Add(this.leftPanel);
            this.efPanelStyleXP3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.efPanelStyleXP3.Location = new System.Drawing.Point(0, 0);
            this.efPanelStyleXP3.Name = "efPanelStyleXP3";
            this.efPanelStyleXP3.Size = new System.Drawing.Size(893, 573);
            this.efPanelStyleXP3.TabIndex = 6;
            // 
            // FormMCCL00033
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BarSaveEnable = true;
            this.ClientSize = new System.Drawing.Size(893, 619);
            this.Controls.Add(this.efPanelStyleXP3);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.EFMsgInfo = "执行 F10 操作";
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "FormMCCL00033";
            this.Text = "部门管理";
            this.Load += new System.EventHandler(this.FormMCCL00026_Load);
            this.Controls.SetChildIndex(this.efPanelStyleXP3, 0);
            this.leftPanel.ResumeLayout(false);
            this.mainms.ResumeLayout(false);
            this.fullPanel.ResumeLayout(false);
            this.fullPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Fleve.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FParentID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.butCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.butOK)).EndInit();
            this.efPanelStyleXP3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private EF.EFPanelStyleXP leftPanel;
        private System.Windows.Forms.ImageList imageList1;
        private EF.EFPanelStyleXP fullPanel;
        private EF.EFTextBox FName;
        private EF.EFLabel efLabel1;
        private EF.EFLabel lbl1;
        private EF.EFLabel efLabel2;
        private EF.EFTextBox FID;
        private EF.EFButton butOK;
        private EF.EFTreeView Departments;
        private EF.EFButton butCancel;
        private System.Windows.Forms.ContextMenuStrip mainms;
        private System.Windows.Forms.ToolStripMenuItem addms;
        private System.Windows.Forms.ToolStripSeparator Separatorms;
        private System.Windows.Forms.ToolStripMenuItem delms;
        private EF.EFPanelStyleXP efPanelStyleXP3;
        private EF.EFDevLookUpEdit FParentID;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem modifyms;
        private EF.EFDevLookUpEdit Fleve;
        private EF.EFCheckBox IsWeld;

    }
}