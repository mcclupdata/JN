namespace MC
{
    partial class frmReadCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReadCard));
            this.axReadCard1 = new AxReadCardInfo.AxReadCard();
            ((System.ComponentModel.ISupportInitialize)(this.axReadCard1)).BeginInit();
            this.SuspendLayout();
            // 
            // axReadCard1
            // 
            this.axReadCard1.Enabled = true;
            this.axReadCard1.Location = new System.Drawing.Point(71, 27);
            this.axReadCard1.Name = "axReadCard1";
            this.axReadCard1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axReadCard1.OcxState")));
            this.axReadCard1.Size = new System.Drawing.Size(80, 48);
            this.axReadCard1.TabIndex = 0;
            // 
            // frmReadCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(205, 107);
            this.Controls.Add(this.axReadCard1);
            this.Name = "frmReadCard";
            this.Text = "frmReadCard";
            ((System.ComponentModel.ISupportInitialize)(this.axReadCard1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public AxReadCardInfo.AxReadCard axReadCard1;

    }
}