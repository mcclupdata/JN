namespace MC
{
    partial class EFFormBase
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
            this.mainLayoutControlGroup = new DevExpress.XtraLayout.LayoutControlGroup();
            this.queryLayout = new DevExpress.XtraLayout.LayoutControlGroup();
            this.queryLayoutControlItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.queryEfPanel = new EF.EFPanel(this.components);
            this.detailLayout = new DevExpress.XtraLayout.LayoutControlGroup();
            this.detailLayoutControlItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.detailEfPanel = new EF.EFPanel(this.components);
            this.childLayout = new DevExpress.XtraLayout.LayoutControlGroup();
            this.childLayoutControlItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.childEfPanel = new EF.EFPanel(this.components);
            this.detail_childSplitter = new DevExpress.XtraLayout.SplitterItem();
            this.mainLayoutControl = new DevExpress.XtraLayout.LayoutControl();
            ((System.ComponentModel.ISupportInitialize)(this.mainLayoutControlGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.queryLayout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.queryLayoutControlItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.queryEfPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailLayout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailLayoutControlItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailEfPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.childLayout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.childLayoutControlItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.childEfPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.detail_childSplitter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainLayoutControl)).BeginInit();
            this.mainLayoutControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainLayoutControlGroup
            // 
            this.mainLayoutControlGroup.CustomizationFormText = "mainLayoutControlGroup";
            this.mainLayoutControlGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.mainLayoutControlGroup.GroupBordersVisible = false;
            this.mainLayoutControlGroup.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.queryLayout,
            this.detailLayout,
            this.childLayout,
            this.detail_childSplitter});
            this.mainLayoutControlGroup.Location = new System.Drawing.Point(0, 0);
            this.mainLayoutControlGroup.Name = "Root";
            this.mainLayoutControlGroup.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.mainLayoutControlGroup.Size = new System.Drawing.Size(1021, 696);
            this.mainLayoutControlGroup.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.mainLayoutControlGroup.Text = "Root";
            this.mainLayoutControlGroup.TextVisible = false;
            // 
            // queryLayout
            // 
            this.queryLayout.CustomizationFormText = "queryLayout";
            this.queryLayout.ExpandButtonLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.queryLayout.ExpandButtonVisible = true;
            this.queryLayout.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.queryLayoutControlItem});
            this.queryLayout.Location = new System.Drawing.Point(0, 0);
            this.queryLayout.Name = "queryLayout";
            this.queryLayout.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.queryLayout.Size = new System.Drawing.Size(1021, 96);
            this.queryLayout.Text = "查询条件";
            // 
            // queryLayoutControlItem
            // 
            this.queryLayoutControlItem.Control = this.queryEfPanel;
            this.queryLayoutControlItem.CustomizationFormText = "queryLayoutControlItem";
            this.queryLayoutControlItem.Location = new System.Drawing.Point(0, 0);
            this.queryLayoutControlItem.Name = "queryLayoutControlItem";
            this.queryLayoutControlItem.Size = new System.Drawing.Size(1015, 69);
            this.queryLayoutControlItem.Text = "queryLayoutControlItem";
            this.queryLayoutControlItem.TextSize = new System.Drawing.Size(0, 0);
            this.queryLayoutControlItem.TextToControlDistance = 0;
            this.queryLayoutControlItem.TextVisible = false;
            // 
            // queryEfPanel
            // 
            this.queryEfPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.queryEfPanel.Location = new System.Drawing.Point(5, 26);
            this.queryEfPanel.Margin = new System.Windows.Forms.Padding(0);
            this.queryEfPanel.Name = "queryEfPanel";
            this.queryEfPanel.Size = new System.Drawing.Size(1011, 65);
            this.queryEfPanel.TabIndex = 7;
            // 
            // detailLayout
            // 
            this.detailLayout.CustomizationFormText = "detailLayout";
            this.detailLayout.ExpandButtonLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.detailLayout.ExpandButtonVisible = true;
            this.detailLayout.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.detailLayoutControlItem});
            this.detailLayout.Location = new System.Drawing.Point(0, 96);
            this.detailLayout.Name = "detailLayout";
            this.detailLayout.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.detailLayout.Size = new System.Drawing.Size(1021, 419);
            this.detailLayout.Text = "detailLayout";
            // 
            // detailLayoutControlItem
            // 
            this.detailLayoutControlItem.Control = this.detailEfPanel;
            this.detailLayoutControlItem.CustomizationFormText = "detailLayoutControlItem";
            this.detailLayoutControlItem.Location = new System.Drawing.Point(0, 0);
            this.detailLayoutControlItem.Name = "detailLayoutControlItem";
            this.detailLayoutControlItem.Size = new System.Drawing.Size(1015, 392);
            this.detailLayoutControlItem.Text = "detailLayoutControlItem";
            this.detailLayoutControlItem.TextSize = new System.Drawing.Size(0, 0);
            this.detailLayoutControlItem.TextToControlDistance = 0;
            this.detailLayoutControlItem.TextVisible = false;
            // 
            // detailEfPanel
            // 
            this.detailEfPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.detailEfPanel.Location = new System.Drawing.Point(5, 122);
            this.detailEfPanel.Margin = new System.Windows.Forms.Padding(0);
            this.detailEfPanel.Name = "detailEfPanel";
            this.detailEfPanel.Size = new System.Drawing.Size(1011, 388);
            this.detailEfPanel.TabIndex = 5;
            // 
            // childLayout
            // 
            this.childLayout.CustomizationFormText = "childLayout";
            this.childLayout.ExpandButtonLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.childLayout.ExpandButtonVisible = true;
            this.childLayout.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.childLayoutControlItem});
            this.childLayout.Location = new System.Drawing.Point(0, 521);
            this.childLayout.Name = "childLayout";
            this.childLayout.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.childLayout.Size = new System.Drawing.Size(1021, 175);
            this.childLayout.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.childLayout.Text = "childLayout";
            // 
            // childLayoutControlItem
            // 
            this.childLayoutControlItem.Control = this.childEfPanel;
            this.childLayoutControlItem.CustomizationFormText = "childLayoutControlItem";
            this.childLayoutControlItem.Location = new System.Drawing.Point(0, 0);
            this.childLayoutControlItem.Name = "childLayoutControlItem";
            this.childLayoutControlItem.Size = new System.Drawing.Size(1019, 152);
            this.childLayoutControlItem.Text = "childLayoutControlItem";
            this.childLayoutControlItem.TextSize = new System.Drawing.Size(0, 0);
            this.childLayoutControlItem.TextToControlDistance = 0;
            this.childLayoutControlItem.TextVisible = false;
            // 
            // childEfPanel
            // 
            this.childEfPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.childEfPanel.Location = new System.Drawing.Point(3, 545);
            this.childEfPanel.Margin = new System.Windows.Forms.Padding(0);
            this.childEfPanel.Name = "childEfPanel";
            this.childEfPanel.Size = new System.Drawing.Size(1015, 148);
            this.childEfPanel.TabIndex = 6;
            // 
            // detail_childSplitter
            // 
            this.detail_childSplitter.AllowHotTrack = true;
            this.detail_childSplitter.CustomizationFormText = "detail_childSplitter";
            this.detail_childSplitter.Location = new System.Drawing.Point(0, 515);
            this.detail_childSplitter.Name = "detail_childSplitter";
            this.detail_childSplitter.Size = new System.Drawing.Size(1021, 6);
            // 
            // mainLayoutControl
            // 
            this.mainLayoutControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mainLayoutControl.Controls.Add(this.queryEfPanel);
            this.mainLayoutControl.Controls.Add(this.childEfPanel);
            this.mainLayoutControl.Controls.Add(this.detailEfPanel);
            this.mainLayoutControl.Location = new System.Drawing.Point(0, 0);
            this.mainLayoutControl.Name = "mainLayoutControl";
            this.mainLayoutControl.Root = this.mainLayoutControlGroup;
            this.mainLayoutControl.Size = new System.Drawing.Size(1021, 696);
            this.mainLayoutControl.TabIndex = 4;
            this.mainLayoutControl.Text = "layoutControl1";
            // 
            // EFFormBase
            // 
            this.ClientSize = new System.Drawing.Size(1024, 745);
            this.Controls.Add(this.mainLayoutControl);
            this.Name = "EFFormBase";
            this.Controls.SetChildIndex(this.mainLayoutControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.mainLayoutControlGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.queryLayout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.queryLayoutControlItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.queryEfPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailLayout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailLayoutControlItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detailEfPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.childLayout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.childLayoutControlItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.childEfPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.detail_childSplitter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainLayoutControl)).EndInit();
            this.mainLayoutControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected EF.EFPanel queryEfPanel;
        protected DevExpress.XtraLayout.LayoutControlGroup mainLayoutControlGroup;
        protected DevExpress.XtraLayout.LayoutControlGroup queryLayout;
        protected DevExpress.XtraLayout.LayoutControlGroup detailLayout;
        protected DevExpress.XtraLayout.LayoutControlGroup childLayout;
        protected EF.EFPanel detailEfPanel;
        protected EF.EFPanel childEfPanel;
        protected DevExpress.XtraLayout.SplitterItem detail_childSplitter;
        protected DevExpress.XtraLayout.LayoutControl mainLayoutControl;
        protected DevExpress.XtraLayout.LayoutControlItem detailLayoutControlItem;
        protected DevExpress.XtraLayout.LayoutControlItem childLayoutControlItem;
        protected DevExpress.XtraLayout.LayoutControlItem queryLayoutControlItem;







    }
}