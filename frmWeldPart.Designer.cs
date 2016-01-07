namespace MCCL
{
    partial class frmWeldPartBatchInput
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
            this.efGroupBox1 = new EF.EFGroupBox(this.components);
            this.Label1 = new EF.EFLabel();
            this.efGroupBox3 = new EF.EFGroupBox(this.components);
            this.efGroupBox2 = new EF.EFGroupBox(this.components);
            this.efDevGrid1 = new EF.EFDevGrid();
            this.efButton1 = new EF.EFButton();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox1)).BeginInit();
            this.efGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox2)).BeginInit();
            this.efGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.efDevGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efButton1)).BeginInit();
            this.SuspendLayout();
            // 
            // efGroupBox1
            // 
            this.efGroupBox1.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.efGroupBox1.Appearance.Options.UseBackColor = true;
            this.efGroupBox1.Controls.Add(this.efButton1);
            this.efGroupBox1.Controls.Add(this.Label1);
            this.efGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.efGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.efGroupBox1.Name = "efGroupBox1";
            this.efGroupBox1.Size = new System.Drawing.Size(1024, 123);
            this.efGroupBox1.TabIndex = 4;
            this.efGroupBox1.Text = "条件";
            // 
            // Label1
            // 
            this.Label1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.Label1.Location = new System.Drawing.Point(0, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(75, 14);
            this.Label1.TabIndex = 3;
            // 
            // efGroupBox3
            // 
            this.efGroupBox3.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.efGroupBox3.Appearance.Options.UseBackColor = true;
            this.efGroupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.efGroupBox3.Location = new System.Drawing.Point(0, 685);
            this.efGroupBox3.Name = "efGroupBox3";
            this.efGroupBox3.Size = new System.Drawing.Size(1024, 15);
            this.efGroupBox3.TabIndex = 6;
            this.efGroupBox3.Text = "efGroupBox3";
            // 
            // efGroupBox2
            // 
            this.efGroupBox2.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.efGroupBox2.Appearance.Options.UseBackColor = true;
            this.efGroupBox2.Controls.Add(this.efDevGrid1);
            this.efGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.efGroupBox2.Location = new System.Drawing.Point(0, 123);
            this.efGroupBox2.Name = "efGroupBox2";
            this.efGroupBox2.Size = new System.Drawing.Size(1024, 562);
            this.efGroupBox2.TabIndex = 7;
            this.efGroupBox2.Text = "数据区";
            // 
            // efDevGrid1
            // 
            this.efDevGrid1.Location = new System.Drawing.Point(0, 0);
            this.efDevGrid1.Name = "efDevGrid1";
            this.efDevGrid1.Size = new System.Drawing.Size(400, 200);
            this.efDevGrid1.TabIndex = 0;
            // 
            // efButton1
            // 
            this.efButton1.Authorizable = false;
            this.efButton1.EnabledEx = true;
            this.efButton1.FnNo = 0;
            this.efButton1.Hint = "";
            this.efButton1.Location = new System.Drawing.Point(443, 62);
            this.efButton1.Name = "efButton1";
            this.efButton1.Size = new System.Drawing.Size(75, 23);
            this.efButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.efButton1.TabIndex = 4;
            this.efButton1.Text = "efButton1";
            this.efButton1.ViewMode = EF.ViewModeEnum.Enable;
            // 
            // frmWeldPartBatchInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 746);
            this.Controls.Add(this.efGroupBox2);
            this.Controls.Add(this.efGroupBox3);
            this.Controls.Add(this.efGroupBox1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.EFMsgInfo = "执行 F11 操作";
            this.Name = "frmWeldPartBatchInput";
            this.Text = "Form1";
            this.Controls.SetChildIndex(this.efGroupBox1, 0);
            this.Controls.SetChildIndex(this.efGroupBox3, 0);
            this.Controls.SetChildIndex(this.efGroupBox2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox1)).EndInit();
            this.efGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox2)).EndInit();
            this.efGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.efDevGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efButton1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private EF.EFGroupBox efGroupBox1;
        private EF.EFGroupBox efGroupBox3;
        private EF.EFGroupBox efGroupBox2;
        private EF.EFDevGrid efDevGrid1;
        private EF.EFLabel Label1;
        private EF.EFButton efButton1;
    }
}

