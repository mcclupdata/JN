using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MC
{
    public partial class FormMCCL00038 : MC.Formbase
    {
        clsAutoMatchWPS cls = new clsAutoMatchWPS();
        public FormMCCL00038()
        {
            InitializeComponent();
        }

        private void FormMCCL00038_Load(object sender, EventArgs e)
        {
            DataTable weldundt = cls.loadUnmatchwpswelds();
            DataTable weldwps = cls.loadWeldswithWPS();
            this.weldwithwpsDataGrid.DataSource = weldwps;
            //this.weldwithwpsGridView.PopulateColumns();
            for (int i = 0; i < this.weldwithwpsGridView.Columns.Count; i++)
            {
                this.weldwithwpsGridView.Columns[i].OptionsColumn.AllowEdit = false;
            }
            this.weldwithnotwpsdataGrid.DataSource = weldundt;
          //  this.weldwithnotwpsgridView.PopulateColumns();
            for (int i = 0; i < this.weldwithnotwpsgridView.Columns.Count; i++)
            {
                this.weldwithnotwpsgridView.Columns[i].OptionsColumn.AllowEdit = false;
            }
            DataTable defaultwps_dt = cls.LoadDefaultWPS();

            this.DefaultWPScbo.DataSource = defaultwps_dt;
            this.DefaultWPScbo.DisplayMember = "RuleNum";
            this.DefaultWPScbo.ValueMember = "RuleNum";
        }

        private void efButton2_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)this.weldwithnotwpsdataGrid.DataSource;
            dt = cls.UpdateAutpmatchWPS(dt);
            FormMCCL00038_Load(null, null);
        }

        private void butSet_Click(object sender, EventArgs e)
        {
            DataRowView r = (DataRowView)this.DefaultWPScbo.SelectedItem;
            if (r==null)
                return;
            for (int i = 0; i < this.weldwithnotwpsgridView.RowCount; i++)
            {
                String rulenum = this.weldwithnotwpsgridView.GetRowCellValue(i, "RuleNum").ToString();
                if (rulenum.Length == 0)
                {
                    rulenum = r["RuleNum"].ToString();
                    this.weldwithnotwpsgridView.SetRowCellValue(i, "RuleNum",rulenum);
                }
            }
        }
    }
}
