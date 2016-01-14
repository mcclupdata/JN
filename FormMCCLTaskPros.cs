using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MC
{
    public partial class FormMCCLTaskPros : Form
    {
        public FormMCCLTaskPros()
        {
            InitializeComponent();
        }

        private void FormMCCLTaskPros_Load(object sender, EventArgs e)
        {
            this.timer1.Interval = 1000;
            this.progressBar1.Maximum = 6000;
            this.progressBar1.Minimum = 0;
            this.progressBar1.Value = 0;
            this.timer1.Enabled = true;
            this.timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Stop();
            if (this.progressBar1.Value < 5001)
            {
                this.progressBar1.Value += 1000;
                this.progressBar1.Refresh();
                this.timer1.Start();
            }
            else
            {
                this.Close();
            }
        }
    }
}
