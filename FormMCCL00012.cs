using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EI;
    using EF;
namespace MC
{
    public partial class FormMCCL00012 : Formbase
    {
        clsTask _cls;
        //clsTask cls = new clsTask(1,this.MdiParent,welderid,starttime);
        public int _edit=0;
        public long _welderid=0;
        public String _starttime="";
        public FormMCCL00012()
        {
            InitializeComponent();
            
        }

        private void FormMCCL00012_Load(object sender, EventArgs e)
        {
            Formbase frm = this;
            if (_edit == 0)
                _cls = new clsTask(ref frm);
            else
                _cls = new clsTask(1, ref frm, _welderid, _starttime);
        }

        private void dataGrid_Click(object sender, EventArgs e)
        {

        }
    }
}
