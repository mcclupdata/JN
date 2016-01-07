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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
namespace MC
{
    public partial class FormMCCL00010 : Formbase
    {
        int cmd_TaskMsg_GetTaskList = 56271;//获取焊工的任务列表集合
        int cmd_TaskMsg_GetDepart = 56272;
        DataTable _Depart_dt = new DataTable();
        _MyClient _Client = new _MyClient();
        clsfrmData _cls = new clsfrmData();

        GridView efGridView;
        public FormMCCL00010()
        {
            InitializeComponent();
            
        }
      
        //得到某班组的任务列表
        protected Boolean GetProject()
        {
            DataTable fdt = new DataTable();
            DataColumn col = new DataColumn();
            col.ColumnName = "FDepartID";
            col.DataType = typeof(long);
            fdt.Columns.Add(col);
            col = new DataColumn();
            col.ColumnName = "FSTARTTIME";
            col.DataType = typeof(String);
            fdt.Columns.Add(col);

            //提取部门代码 任务时间
           // Form vfrm = (Form)this;
            //_cls.getDataFrom(vfrm, ref fdt);
            DataRow dro = fdt.NewRow();

            DataRowView drv = (DataRowView)FDepartID.SelectedItem;
            dro["FDepartID"] = drv["FID"];
            DateTime dit = this.FSTARTTIME.Value;
            dro["FSTARTTIME"] = dit.ToString("yyyy-MM-dd");

            fdt.Rows.Add(dro);
            DataTable dt = _Client.ServiceCall(cmd_TaskMsg_GetTaskList, fdt);
            this.dataGrid.DataSource = dt;
            //this.dataGrid.AutoGenerateColumns = true;
            return false;
        }
        /// <summary>
        /// 双击进行编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void dataGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ////双击进行编辑；
            //DataGridView dgv = (DataGridView)sender;
            //long fid = 0;
            //fid = Convert.ToInt64(dgv.Rows[e.RowIndex].Cells["CFID"].Value);
            //clsProjectProcess cls = new clsProjectProcess(fid);
            
        }

        private void butReflash_Click(object sender, EventArgs e)
        {
            GetProject();
        }

        private void butEdit_Click(object sender, EventArgs e)
        {
            //GridView efGV = (GridView)this.dataGrid.Views[0];
            //if (efGV.SelectedRowsCount == 0)
            //{
            //    MessageBox.Show("请选择工序计划后点击编辑");
            //    return;
            //}
            //long fid = 0;
            //int rindex = efGV.FocusedRowHandle;
            //if (rindex < 0)
            //    return;
            //fid = Convert.ToInt64();//this.dataGrid.SelectedRows[0].Cells["CFID"].Value);
            //clsProjectProcess cls = new clsProjectProcess(fid);
        }

        private void frmProjectMag_Load(object sender, EventArgs e)
        {
            //GetProject();
            this.cobDepart.SelectedValueChanged += cobDepart_SelectedValueChanged;
            GetDepart();
            efGridView = (GridView)this.dataGrid.Views[0];
            RepositoryItemButtonEdit but_edit = (RepositoryItemButtonEdit)efGridView.Columns["but_Edit"].ColumnEdit;
            but_edit.ButtonClick += dataGrid_CellContentClick;
            RepositoryItemButtonEdit but_del = (RepositoryItemButtonEdit)efGridView.Columns["but_Del"].ColumnEdit;
            but_del.ButtonClick += dataGrid_CellContentClick;
        }
        protected Boolean GetDepart()
        {
            _Depart_dt = _Client.ServiceCall(cmd_TaskMsg_GetDepart, null);
            //绑定到控件cobDepart
            DataView depart_work_dv = _Depart_dt.Copy().DefaultView;
            depart_work_dv.RowFilter="Flevel=1";
            DataTable depart_work_dt = depart_work_dv.ToTable();
            this.cobDepart.DisplayMember = "FDepartName";
            this.cobDepart.ValueMember = "FID";
            this.cobDepart.DataSource = depart_work_dt;
            
            this.cobDepart.SelectedIndex = 0;
            cobDepart_SelectedValueChanged(null, null);
            return true;
        }
        /// <summary>
        /// 作业区选择变更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void cobDepart_SelectedValueChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            long workid = 0;
            if (cobDepart.SelectedItem == null)
                return;
            DataRowView drv = (DataRowView)cobDepart.SelectedItem;
            workid = Convert.ToInt64(drv["FID"]);
            //DateTime ds = this.FSTARTTIME.Value;
            //String vstarttime = ds.ToString("yyyy-MM-dd");
            DataView class_dv = _Depart_dt.Copy().DefaultView;
            class_dv.RowFilter="Flevel=2 and FParentid="+workid;
            DataTable class_dt = class_dv.ToTable();
            FDepartID.DisplayMember = "FDepartName";
            FDepartID.ValueMember = "FID";
            FDepartID.DataSource = class_dt;
            if (class_dt.Rows.Count>0)
            FDepartID.SelectedIndex = 0;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGrid_CellContentClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //编辑按钮
            int rindex = efGridView.FocusedRowHandle;
             String butName = efGridView.FocusedColumn.Name;
            int undo = Convert.ToInt32(efGridView.GetRowCellValue(rindex, "FUndo"));//this.dataGrid.Rows[e.RowIndex].Cells["CUndo"].Value);
            int doing = Convert.ToInt32(efGridView.GetRowCellValue(rindex, "FDoing"));//this.dataGrid.Rows[e.RowIndex].Cells["CDoing"].Value);
            int finished = Convert.ToInt32(efGridView.GetRowCellValue(rindex, "FFinished"));//this.dataGrid.Rows[e.RowIndex].Cells["CFFinished"].Value);
            if (butName == "CEDIT")
            {
                //如果已经开始则不能进行编辑
                long welderid = 0;
                String starttime = "";

                if (doing > 0 || finished > 0)
                {
                    MessageBox.Show(this, "任务已经开始不能编辑!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                welderid = Convert.ToInt32(efGridView.GetRowCellValue(rindex, "FWelderID"));//this.dataGrid.Rows[e.RowIndex].Cells["CFWelderID"].Value);
                starttime = Convert.ToString(efGridView.GetRowCellValue(rindex, "FSTARTTIME"));//this.dataGrid.Rows[e.RowIndex].Cells["CFSTARTTIME"].Value);
               // Formbase frm=this;
                //clsTask cls = new clsTask(1,ref frm,welderid,starttime);
                FormMCCL00012 frm = new FormMCCL00012();
                frm._edit = 1;
                frm._welderid = welderid;
                frm._starttime = starttime;
                Formbase vfrm = frm;
                frm.ShowDialog(this);
                GetProject();
                
            }
            if (butName == "CDELETE")
            {
                //删除按钮
                //如果已经开始则不能进行删除
                long welderid = 0;
                String starttime = "";

                if (doing > 0 || finished > 0)
                {
                    MessageBox.Show(this, "任务已经开始不能编辑!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (MessageBox.Show(this, "是否确定删除该焊工的所有任务!", "ASKING", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    welderid = Convert.ToInt32(efGridView.GetRowCellValue(rindex, "FWelderID"));//this.dataGrid.Rows[e.RowIndex].Cells["CFWelderID"].Value);
                    starttime = Convert.ToString(efGridView.GetRowCellValue(rindex, "FSTARTTIME"));//this.dataGrid.Rows[e.RowIndex].Cells["CFSTARTTIME"].Value);
                    //构造参数
                    clsTask cls = new clsTask();
                    cls.DeleteTask(welderid, starttime);
                    MessageBox.Show(this, "删除成功!", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetProject();
                   
                }
            }
        }

        private void butDel_Click(object sender, EventArgs e)
        {

        }

    }
}
