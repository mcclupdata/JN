using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EF;
using EI;
namespace MC
{
    public partial class frmMain : Formbase
    {
        public frmMain()
        {
            
            InitializeComponent();
         
        }

        private void efButton1_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    this.openFileDialog1.ShowDialog();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(this, ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            FormMCCL0002 frm = new FormMCCL0002();
            frm.Show();
        }

        private void efButton2_Click(object sender, EventArgs e)
        {
            FormMCCL00013 frm = new FormMCCL00013();
            frm.Show();
        }

        private void efButton3_Click(object sender, EventArgs e)
        {
            FormMCCL00011 frm = new FormMCCL00011();
            frm.Show();
        }

        private void efButton4_Click(object sender, EventArgs e)
        {
            FormMCCL0004 frm = new FormMCCL0004();
            frm.Show();
        }

        private void efButton8_Click(object sender, EventArgs e)
        {
            FormMCCL0009 frm = new FormMCCL0009();
            frm.Show();
        }

        private void efButton7_Click(object sender, EventArgs e)
        {
            FormMCCL00015 frm = new FormMCCL00015();
            frm.Show();
        }

        private void efButton6_Click(object sender, EventArgs e)
        {
            FormMCCL0006 frm = new FormMCCL0006();
            frm.Show();
        }

        private void efButton5_Click(object sender, EventArgs e)
        {
            FormMCCL00018 frm = new FormMCCL00018();
            frm.Show();
        }

        private void efButton12_Click(object sender, EventArgs e)
        {
            FormMCCL00012 frm = new FormMCCL00012();
            frm.Show();

        }

        private void efButton14_Click(object sender, EventArgs e)
        {
            FormMCCL00025 frm = new FormMCCL00025();
            frm.ShowDialog(this);
        }

        private void efButton9_Click(object sender, EventArgs e)
        {

        }

        private void efButton15_Click(object sender, EventArgs e)
        {
            FormMCCL00026 frm = new FormMCCL00026();
            frm.ShowDialog();
        }

        private void efButton16_Click(object sender, EventArgs e)
        {
            FormMCCL000251 frm = new FormMCCL000251();
            frm.ShowDialog(this);

        }

        private void efButton17_Click(object sender, EventArgs e)
        {
            FormMCCL000252 frm = new FormMCCL000252();
            frm.ShowDialog(this);

        }

        private void efButton18_Click(object sender, EventArgs e)
        {
            FormMCCL00033 frm = new FormMCCL00033();
            frm.ShowDialog(this);
        }

        private void efButton19_Click(object sender, EventArgs e)
        {
            FormMCCL00030 frm = new FormMCCL00030();
            frm.ShowDialog(this);
        }

        private void efButton20_Click(object sender, EventArgs e)
        {
            FormMCCL00031 frm = new FormMCCL00031();
            frm.ShowDialog(this);

        }

        private void efButton21_Click(object sender, EventArgs e)
        {
            FormMCCL00032 frm = new FormMCCL00032();
            frm.ShowDialog(this);
        }

        private void efButton22_Click(object sender, EventArgs e)
        {
            FormMCCL000321 frm = new FormMCCL000321();
            frm.ShowDialog(this);
        }

        private void efButton23_Click(object sender, EventArgs e)
        {
            FormMCCL000322 frm = new FormMCCL000322();
            frm.ShowDialog(this);
        }

        private void efButton10_Click(object sender, EventArgs e)
        {
            FormMCCL00022 frm = new FormMCCL00022();
            frm.ShowDialog(this);
        }

        private void efButton11_Click(object sender, EventArgs e)
        {
            FormMCCL00010 frm = new FormMCCL00010();
            frm.ShowDialog(this);
        }

        private void efButton24_Click(object sender, EventArgs e)
        {
            FormMCCL00034 frm = new FormMCCL00034();
            frm.ShowDialog(this);
        }

        private void efButton25_Click(object sender, EventArgs e)
        {
            FormMCCL00035 frm = new FormMCCL00035();
            frm.ShowDialog(this);
        }

        private void efButton26_Click(object sender, EventArgs e)
        {
            FormMCCL00036 frm = new FormMCCL00036();
            frm.ShowDialog(this);
        }

        private void efButton27_Click(object sender, EventArgs e)
        {
            FormMCCL00037 frm = new FormMCCL00037();
            frm.ShowDialog(this);
        }

        private void efButton28_Click(object sender, EventArgs e)
        {
            FormMCCL00038 frm = new FormMCCL00038();
            frm.ShowDialog(this);
        }

        private void efButton29_Click(object sender, EventArgs e)
        {
            FormMCCL00121 frm = new FormMCCL00121();
            frm.ShowDialog(this);
        }

        private void efButton30_Click(object sender, EventArgs e)
        {
            FormMCCL00039 frm = new FormMCCL00039();
            frm.ShowDialog(this);
        }

        private void efButton31_Click(object sender, EventArgs e)
        {
            FormMCCL0040CS frm = new FormMCCL0040CS();
            frm.ShowDialog(this);
        }

        private void efButton32_Click(object sender, EventArgs e)
        {
            FormMCCL0041 frm = new FormMCCL0041();
            frm.ShowDialog(this);
        }

        private void efButton33_Click(object sender, EventArgs e)
        {

            FormMCCL0042 frm = new FormMCCL0042();
            frm.ShowDialog(this);
        }

        private void efButton34_Click(object sender, EventArgs e)
        {
            FormMCCL00431 frm = new FormMCCL00431();
            frm.ShowDialog(this);
        }
    }
}
