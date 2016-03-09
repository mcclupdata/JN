using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MC
{
    public partial class FormMCCL00037 : MC.Formbase
    {
        DataTable _dt_wps;
        DataTable _dt_subwps;
        clsDefaultWPS cls = new clsDefaultWPS();
        long _curWPSFID;
        public FormMCCL00037()
        {
            InitializeComponent();
        }
      
        private void wpsGridView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {

        }
        /// <summary>
        /// WPS切换至SubWPS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void wpsGridView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView dgv = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            int rindex = e.RowHandle;
            String vRulenum = Convert.ToString(dgv.GetRowCellValue(rindex, "RuleNum"));//Convert.ToString( dgv.Rows[e.].Cells["CRuleNum"].Value);
            //DataView dv = _dt_wpssub.Copy().DefaultView;
            //dv.RowFilter = "RuleNum='" + dgv.GetRowCellValue(rindex,"RuleNum").ToString()+"'";//dgv.Rows[e.RowIndex].Cells["CRuleNum"].Value.ToString() + "'";
            _dt_subwps.DefaultView.RowFilter = "RuleNum='" + dgv.GetRowCellValue(rindex, "RuleNum").ToString() + "'";

           
            this.SubwpsDataGrid.DataSource = _dt_subwps;// dv.ToTable();
            
            //wpsGridView.PopulateColumns();
            DevExpress.XtraGrid.Columns.GridColumn col=new DevExpress.XtraGrid.Columns.GridColumn();
            col.Name="bakname";
            col.FieldName="FsetDefault";
            col.Caption="默认";

            wpsGridView.Columns.Add(col);

            TabControl.SelectTab("tabSubWPS");
            
        }

        private void butUpdate_Click(object sender, EventArgs e)
        {
            DataTable wpsdt = (DataTable)this.wpsDataGrid.DataSource;
            cls.UpdateDefaultWPS(wpsdt);
            DataTable subwps = (DataTable)this.SubwpsDataGrid.DataSource;
            String rowfilter = subwps.DefaultView.RowFilter;
            subwps.DefaultView.RowFilter = "";
            cls.UpdateDefaultSubWPS(subwps);
            FormMCCL00037_Load(null, null);
        }

        private void FormMCCL00037_Load(object sender, EventArgs e)
        {
            _dt_wps = cls.getDefaultWPS();
            _dt_subwps = cls.getDefaultSubWPS();
            _curWPSFID = cls.getDefaultWPSFID();
            
            this.wpsDataGrid.DataSource = _dt_wps;
            this.SubwpsDataGrid.DataSource = null;
           // this.wpsGridView.PopulateColumns();

            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition5 =new DevExpress.XtraGrid.StyleFormatCondition();
            styleFormatCondition5.Appearance.BackColor = System.Drawing.Color.LightGreen;
            styleFormatCondition5.Appearance.Options.UseBackColor = true;
            styleFormatCondition5.ApplyToRow = true;
            int defaultwpscid=0;
            for(int i=0;i<this.wpsGridView.Columns.Count;i++)
            {
                if (this.wpsGridView.Columns[i].Name=="FID")
                {
                    defaultwpscid=i;
                }
            }
            styleFormatCondition5.Column = this.wpsGridView.Columns[defaultwpscid];
            styleFormatCondition5.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
            styleFormatCondition5.Value1 = _curWPSFID;
            this.wpsGridView.FormatConditions.Add(styleFormatCondition5);


            for (int i = 0; i < this.wpsGridView.RowCount; i++)
            {
                if (Convert.ToInt64(this.wpsGridView.GetRowCellValue(i, "FID")) == _curWPSFID)
                {

                    wpsGridView.SetRowCellValue(i, "FsetDefault", "默认");
                }
            }
        }
        /// <summary>
        /// 设定默认WPS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butSetDefault_Click(object sender, EventArgs e)
        {
            int curRowHandle = this.wpsGridView.FocusedRowHandle;
            if (curRowHandle < 0)
            {
                MessageBox.Show(this, "请选择要设定为默认的WPS", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_curWPSFID == Convert.ToInt64(this.wpsGridView.GetRowCellValue(curRowHandle, "FID")))
            {
                MessageBox.Show(this, "所选择的已经是默认WPS", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            long newwpsfid = Convert.ToInt64(this.wpsGridView.GetRowCellValue(curRowHandle, "FID"));
            cls.SetDefaultWPS(newwpsfid);
            FormMCCL00037_Load(null, null);
        }
    }
}
