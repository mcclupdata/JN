namespace MC
{
    partial class FormMCCL00026
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMCCL00026));
            this.leftPanel = new EF.EFPanelStyleXP();
            this.weldEquipments = new EF.EFTreeView(this.components);
            this.mainms = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addms = new System.Windows.Forms.ToolStripMenuItem();
            this.Separatorms = new System.Windows.Forms.ToolStripSeparator();
            this.delms = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.fullPanel = new EF.EFPanelStyleXP();
            this.FweldEquipmentID = new EF.EFDevLookUpEdit(this.components);
            this.butCancel = new EF.EFButton();
            this.FDepartID = new EF.EFDevLookUpEdit(this.components);
            this.FweldManufacturerID = new EF.EFDevLookUpEdit(this.components);
            this.FState = new EF.EFDevComboBoxEdit(this.components);
            this.FDepartName = new EF.EFDevComboBoxEdit(this.components);
            this.butOK = new EF.EFButton();
            this.FID = new EF.EFTextBox();
            this.efLabel5 = new EF.EFLabel();
            this.efLabel4 = new EF.EFLabel();
            this.efLabel3 = new EF.EFLabel();
            this.efLabel2 = new EF.EFLabel();
            this.lbl1 = new EF.EFLabel();
            this.FEquipName = new EF.EFTextBox();
            this.efLabel1 = new EF.EFLabel();
            this.efPanelStyleXP3 = new EF.EFPanelStyleXP();
            this.leftPanel.SuspendLayout();
            this.mainms.SuspendLayout();
            this.fullPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FweldEquipmentID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.butCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FDepartID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FweldManufacturerID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FState.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FDepartName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.butOK)).BeginInit();
            this.efPanelStyleXP3.SuspendLayout();
            this.SuspendLayout();
            // 
            // leftPanel
            // 
            this.leftPanel.Controls.Add(this.weldEquipments);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftPanel.Location = new System.Drawing.Point(0, 0);
            this.leftPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(397, 900);
            this.leftPanel.TabIndex = 4;
            // 
            // weldEquipments
            // 
            this.weldEquipments.ContextMenuStrip = this.mainms;
            this.weldEquipments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.weldEquipments.ImageIndex = 0;
            this.weldEquipments.ImageList = this.imageList1;
            this.weldEquipments.Location = new System.Drawing.Point(0, 0);
            this.weldEquipments.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.weldEquipments.Name = "weldEquipments";
            this.weldEquipments.SelectedImageIndex = 0;
            this.weldEquipments.Size = new System.Drawing.Size(397, 900);
            this.weldEquipments.TabIndex = 0;
            this.weldEquipments.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.weldEquipments_MouseDoubleClick);
            // 
            // mainms
            // 
            this.mainms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addms,
            this.Separatorms,
            this.delms});
            this.mainms.Name = "contextMenuStrip1";
            this.mainms.Size = new System.Drawing.Size(153, 66);
            // 
            // addms
            // 
            this.addms.Name = "addms";
            this.addms.Size = new System.Drawing.Size(152, 28);
            this.addms.Text = "增加焊机";
            this.addms.Click += new System.EventHandler(this.addms_Click);
            // 
            // Separatorms
            // 
            this.Separatorms.Name = "Separatorms";
            this.Separatorms.Size = new System.Drawing.Size(149, 6);
            // 
            // delms
            // 
            this.delms.Name = "delms";
            this.delms.Size = new System.Drawing.Size(152, 28);
            this.delms.Text = "删除焊机";
            this.delms.Click += new System.EventHandler(this.delms_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "OK.jpg");
            this.imageList1.Images.SetKeyName(1, "ER.jpg");
            // 
            // fullPanel
            // 
            this.fullPanel.BackColor = System.Drawing.SystemColors.Window;
            this.fullPanel.Controls.Add(this.FweldEquipmentID);
            this.fullPanel.Controls.Add(this.butCancel);
            this.fullPanel.Controls.Add(this.FDepartID);
            this.fullPanel.Controls.Add(this.FweldManufacturerID);
            this.fullPanel.Controls.Add(this.FState);
            this.fullPanel.Controls.Add(this.FDepartName);
            this.fullPanel.Controls.Add(this.butOK);
            this.fullPanel.Controls.Add(this.FID);
            this.fullPanel.Controls.Add(this.efLabel5);
            this.fullPanel.Controls.Add(this.efLabel4);
            this.fullPanel.Controls.Add(this.efLabel3);
            this.fullPanel.Controls.Add(this.efLabel2);
            this.fullPanel.Controls.Add(this.lbl1);
            this.fullPanel.Controls.Add(this.FEquipName);
            this.fullPanel.Controls.Add(this.efLabel1);
            this.fullPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fullPanel.Location = new System.Drawing.Point(397, 0);
            this.fullPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fullPanel.Name = "fullPanel";
            this.fullPanel.Size = new System.Drawing.Size(1066, 900);
            this.fullPanel.TabIndex = 5;
            // 
            // FweldEquipmentID
            // 
            this.FweldEquipmentID.EditValue = 0;
            this.FweldEquipmentID.Location = new System.Drawing.Point(140, 234);
            this.FweldEquipmentID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FweldEquipmentID.Name = "FweldEquipmentID";
            this.FweldEquipmentID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FweldEquipmentID.Size = new System.Drawing.Size(424, 28);
            this.FweldEquipmentID.TabIndex = 22;
            // 
            // butCancel
            // 
            this.butCancel.Authorizable = false;
            this.butCancel.EnabledEx = true;
            this.butCancel.FnNo = 0;
            this.butCancel.Hint = "";
            this.butCancel.Location = new System.Drawing.Point(456, 677);
            this.butCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(107, 36);
            this.butCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.butCancel.TabIndex = 21;
            this.butCancel.Text = "取消";
            this.butCancel.ViewMode = EF.ViewModeEnum.Enable;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // FDepartID
            // 
            this.FDepartID.EditValue = 0;
            this.FDepartID.Location = new System.Drawing.Point(140, 341);
            this.FDepartID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FDepartID.Name = "FDepartID";
            this.FDepartID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FDepartID.Size = new System.Drawing.Size(424, 28);
            this.FDepartID.TabIndex = 20;
            this.FDepartID.EditValueChanged += new System.EventHandler(this.FDepartID_EditValueChanged);
            // 
            // FweldManufacturerID
            // 
            this.FweldManufacturerID.EditValue = 0;
            this.FweldManufacturerID.Location = new System.Drawing.Point(140, 547);
            this.FweldManufacturerID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FweldManufacturerID.Name = "FweldManufacturerID";
            this.FweldManufacturerID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FweldManufacturerID.Size = new System.Drawing.Size(424, 28);
            this.FweldManufacturerID.TabIndex = 19;
            // 
            // FState
            // 
            this.FState.EditValue = 0;
            this.FState.EnterMoveNextControl = true;
            this.FState.Location = new System.Drawing.Point(141, 435);
            this.FState.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FState.Name = "FState";
            this.FState.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.FState.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FState.Properties.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.DisplayText;
            this.FState.Properties.Items.AddRange(new object[] {
            "正常",
            "停用"});
            this.FState.Size = new System.Drawing.Size(423, 28);
            this.FState.TabIndex = 17;
            // 
            // FDepartName
            // 
            this.FDepartName.Enabled = false;
            this.FDepartName.Location = new System.Drawing.Point(140, 141);
            this.FDepartName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FDepartName.Name = "FDepartName";
            this.FDepartName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.FDepartName.Properties.Sorted = true;
            this.FDepartName.Size = new System.Drawing.Size(424, 28);
            this.FDepartName.TabIndex = 14;
            // 
            // butOK
            // 
            this.butOK.Authorizable = false;
            this.butOK.EnabledEx = true;
            this.butOK.FnNo = 0;
            this.butOK.Hint = "";
            this.butOK.Location = new System.Drawing.Point(125, 677);
            this.butOK.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(109, 36);
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
            this.FID.Location = new System.Drawing.Point(24, 633);
            this.FID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FID.Name = "FID";
            this.FID.Size = new System.Drawing.Size(45, 29);
            this.FID.TabIndex = 12;
            this.FID.Visible = false;
            // 
            // efLabel5
            // 
            this.efLabel5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.efLabel5.Location = new System.Drawing.Point(24, 552);
            this.efLabel5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.efLabel5.Name = "efLabel5";
            this.efLabel5.Size = new System.Drawing.Size(107, 22);
            this.efLabel5.TabIndex = 10;
            this.efLabel5.Text = "焊机厂商";
            // 
            // efLabel4
            // 
            this.efLabel4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.efLabel4.Location = new System.Drawing.Point(24, 446);
            this.efLabel4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.efLabel4.Name = "efLabel4";
            this.efLabel4.Size = new System.Drawing.Size(107, 22);
            this.efLabel4.TabIndex = 8;
            this.efLabel4.Text = "焊机状态";
            // 
            // efLabel3
            // 
            this.efLabel3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.efLabel3.Location = new System.Drawing.Point(24, 346);
            this.efLabel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.efLabel3.Name = "efLabel3";
            this.efLabel3.Size = new System.Drawing.Size(107, 22);
            this.efLabel3.TabIndex = 6;
            this.efLabel3.Text = "焊机归属";
            // 
            // efLabel2
            // 
            this.efLabel2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.efLabel2.Location = new System.Drawing.Point(24, 239);
            this.efLabel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.efLabel2.Name = "efLabel2";
            this.efLabel2.Size = new System.Drawing.Size(107, 22);
            this.efLabel2.TabIndex = 4;
            this.efLabel2.Text = "焊机编号";
            // 
            // lbl1
            // 
            this.lbl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lbl1.Location = new System.Drawing.Point(24, 141);
            this.lbl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(107, 22);
            this.lbl1.TabIndex = 2;
            this.lbl1.Text = "焊机位置";
            // 
            // FEquipName
            // 
            this.FEquipName.EFEname = null;
            this.FEquipName.EFLeaveExpression = ".*";
            this.FEquipName.EFLen = 32767;
            this.FEquipName.Location = new System.Drawing.Point(140, 39);
            this.FEquipName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FEquipName.Name = "FEquipName";
            this.FEquipName.Size = new System.Drawing.Size(423, 29);
            this.FEquipName.TabIndex = 1;
            // 
            // efLabel1
            // 
            this.efLabel1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.efLabel1.Location = new System.Drawing.Point(24, 44);
            this.efLabel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.efLabel1.Name = "efLabel1";
            this.efLabel1.Size = new System.Drawing.Size(107, 22);
            this.efLabel1.TabIndex = 0;
            this.efLabel1.Text = "焊机名称";
            // 
            // efPanelStyleXP3
            // 
            this.efPanelStyleXP3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.efPanelStyleXP3.Controls.Add(this.fullPanel);
            this.efPanelStyleXP3.Controls.Add(this.leftPanel);
            this.efPanelStyleXP3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.efPanelStyleXP3.Location = new System.Drawing.Point(0, 0);
            this.efPanelStyleXP3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.efPanelStyleXP3.Name = "efPanelStyleXP3";
            this.efPanelStyleXP3.Size = new System.Drawing.Size(1463, 900);
            this.efPanelStyleXP3.TabIndex = 6;
            // 
            // FormMCCL00026
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1463, 972);
            this.Controls.Add(this.efPanelStyleXP3);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormMCCL00026";
            this.Text = "焊机管理";
            this.Load += new System.EventHandler(this.FormMCCL00026_Load);
            this.Controls.SetChildIndex(this.efPanelStyleXP3, 0);
            this.leftPanel.ResumeLayout(false);
            this.mainms.ResumeLayout(false);
            this.fullPanel.ResumeLayout(false);
            this.fullPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FweldEquipmentID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.butCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FDepartID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FweldManufacturerID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FState.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FDepartName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.butOK)).EndInit();
            this.efPanelStyleXP3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private EF.EFPanelStyleXP leftPanel;
        private System.Windows.Forms.ImageList imageList1;
        private EF.EFPanelStyleXP fullPanel;
        private EF.EFTextBox FEquipName;
        private EF.EFLabel efLabel1;
        private EF.EFLabel lbl1;
        private EF.EFLabel efLabel2;
        private EF.EFLabel efLabel3;
        private EF.EFTextBox FID;
        private EF.EFLabel efLabel5;
        private EF.EFLabel efLabel4;
        private EF.EFButton butOK;
        private EF.EFDevComboBoxEdit FState;
        private EF.EFDevComboBoxEdit FDepartName;
        private EF.EFTreeView weldEquipments;
        private EF.EFDevLookUpEdit FweldManufacturerID;
        private EF.EFDevLookUpEdit FDepartID;
        private EF.EFButton butCancel;
        private System.Windows.Forms.ContextMenuStrip mainms;
        private System.Windows.Forms.ToolStripMenuItem addms;
        private System.Windows.Forms.ToolStripSeparator Separatorms;
        private System.Windows.Forms.ToolStripMenuItem delms;
        private EF.EFPanelStyleXP efPanelStyleXP3;
        private EF.EFDevLookUpEdit FweldEquipmentID;

    }
}