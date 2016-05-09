

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MC
{
    public partial class FormMCCL00121:Formbase

    {
        clsClassMargwelds _cls;
        int isModify = 0;
        public FormMCCL00121()
        {
            InitializeComponent();
        }

        private void FormMCCL00121_Load(object sender, EventArgs e)
        {
            //注册自定义按钮事件
            this.dataGrid.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(EmbeddedNavigator_ButtonClick);
            Formbase frm = this;

            _cls = new clsClassMargwelds(ref frm);

            this.ClassGroup.SelectedIndexChanged+=new EventHandler(ClassGroup_SelectedIndexChanged);
        }

        void EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            if (e.Button.Tag == "Merge")
            {
                
                //执行合并动作
            }
           // throw new NotImplementedException();
        }
        /// <summary>
        /// 班组选定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClassGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isModify == 1)
            {
                if (MessageBox.Show(this, "已做修改是否放弃?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                }
                else
                {
                    return;
                }
            }
            //加载班组的数据
            long classid = 0;
            DataRowView workdrw = (DataRowView)this.ClassGroup.SelectedItem;
            classid = Convert.ToInt64(workdrw["FID"]);

            this.dataGrid.DataSource = _cls.getClassWeldsForMerge(classid);
            this.gridView1.OptionsView.ColumnAutoWidth = true;
            this.dataGridMerged.DataSource = _cls.getClassMergedwelds(classid);
            tabControl_SelectedIndexChanged(tabControl, null);
            this.inBagWeldsdataGrid.DataSource = null;
        }

        private void FormMCCL00121_LocationChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 合并焊缝
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butMerge_Click(object sender, EventArgs e)
        {
            if (this.gridView1.RowCount == 0)
                return;
            this.gridView1.FocusedRowHandle = 0;
            this.dataGrid.Update();
            DataTable dt = (DataTable)this.dataGrid.DataSource;
            DataView dv = dt.Copy().DefaultView;
            dv.RowFilter = "FChecked=1";
            DataTable selDT = dv.ToTable();
            selDT.Columns.Add("FNewName", typeof(String));
            
            if (selDT.Rows.Count>1)
            {
                if (MessageBox.Show(this,"是否确定进行打包合并?","消息",MessageBoxButtons.YesNo,MessageBoxIcon.Asterisk)==DialogResult.Yes)
                {
                   

                   frmInputMergeName f = new frmInputMergeName();
                   
                   String bakname = f.txtMergeBackName.Text;


                   if (f.ShowDialog(this) == DialogResult.OK)
                   {
                       bakname = f.txtMergeBackName.Text;
                       if (bakname.Length == 0)
                       {
                           MessageBox.Show(this, "合并焊缝备注名称必输输入，请重试", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                           return;
                       }
                   }
                   else
                   {
                       MessageBox.Show(this, "合并焊缝备注名称必输输入，请重试", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                       return;
                   }

                   for (int i = 0; i < selDT.Rows.Count; i++)
                   {
                       selDT.Rows[i]["FNewName"] = bakname;
                   }
                   DataTable rsdt = _cls.MergeWelds(selDT);
                   if (rsdt == null)
                   {
                       MessageBox.Show(this, "合并失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                       return;
                   }
                   else
                   {
                       long classid = 0;
                       DataRowView workdrw = (DataRowView)this.ClassGroup.SelectedItem;
                       classid = Convert.ToInt64(workdrw["FID"]);
                       this.dataGrid.DataSource = _cls.getClassWeldsForMerge(classid);
                       this.dataGridMerged.DataSource = _cls.getClassMergedwelds(classid);
                   }
                }
                else
                {
                    return ;
                }
            }
        }
        /// <summary>
        /// 全选或反选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butSelectALL_Click(object sender, EventArgs e)
        {
            gridView1.SelectAll();
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                Byte bi = Convert.ToByte(gridView1.GetRowCellValue(i, "FChecked"));// (this.dataGrid.Rows[i].Cells["CFChecked"].Value);
                //this.dataGrid.Rows[i].Cells["CFChecked"].Value = 1;
                bi ^= 1;
                gridView1.SetRowCellValue(i, "FChecked", Convert.ToInt32(bi));
                gridView1.FocusedRowHandle = i;

            }
            gridView1.SetFocusedRowModified();
        }
        /// <summary>
        /// 点击选择规程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChooseWPSButtonEdit_Click(object sender, EventArgs e)
        {
            DataRow row = this.gridView3.GetFocusedDataRow();
           
            if (row == null)
                return;
            clsProjectChooseWeldRule clsfrm = new clsProjectChooseWeldRule(row, this);
            if (clsfrm._choosedRuleFID > -100)
            {
                this.gridView3.SetFocusedRowCellValue("FWELDWPSID", clsfrm._choosedRuleFID);
                this.gridView3.SetFocusedRowCellValue("RuleNum", clsfrm._choosedRuleNum);
                //dgv.SetRowCellValue(this.gridView3.SetFocusedRowCellValue, "RuleFID", clsfrm._choosedRuleFID);//_grid_RuleFID].Value = clsfrm._choosedRuleFID;
                //dgv.SetRowCellValue(rindex, "RuleNum", clsfrm._choosedRuleNum);//row.Cells[_grid_RuleNum].Value = clsfrm._choosedRuleNum;
            }
        }
        /// <summary>
        /// 提交数据进行保存;
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void efButton1_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)this.dataGridMerged.DataSource;
            if (dt == null)
                return;
            if (MessageBox.Show(this, "是否确定进行更新?", "消息", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                dt = _cls.UpdateMargedWeldWPS(dt);
            }
            long classid = 0;
            DataRowView workdrw = (DataRowView)this.ClassGroup.SelectedItem;
            classid = Convert.ToInt64(workdrw["FID"]);
            this.dataGridMerged.DataSource = _cls.getClassMergedwelds(classid) ;
        }
        /// <summary>
        /// 取消焊缝合并
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DataTable dt = (DataTable)this.dataGridMerged.DataSource;
            //获取当前数据
            int curIndex = this.gridView3.FocusedRowHandle;
            DataTable data = dt.Clone();
            DataRow row = dt.Rows[curIndex];
            data.ImportRow(row);

            if (dt == null)
                return;
            if (MessageBox.Show(this, "是否确定解除打包?", "消息", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                bool rs = _cls.clsClassCancelMargwelds(data);
                //dt = _cls.UpdateMargedWeldWPS(dt);
                long classid = 0;
                DataRowView workdrw = (DataRowView)this.ClassGroup.SelectedItem;
                classid = Convert.ToInt64(workdrw["FID"]);
                this.dataGridMerged.DataSource = _cls.getClassMergedwelds(classid);
                this.dataGrid.DataSource = _cls.getClassWeldsForMerge(classid);
            }
           



        
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tabControl.SelectedIndex == 2)
            {
                this.BagdataGrid.DataSource = ((DataTable)this.dataGridMerged.DataSource).Copy();
                this.OutBagWelddataGrid.DataSource = ((DataTable)this.dataGrid.DataSource).Copy() ;
            }
        }
        /// <summary>
        /// 添加焊缝；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butIN_Click(object sender, EventArgs e)
        {
            int[] selindex = this.OutBagWeldView.GetSelectedRows();
            
            for (int i = 0; i < selindex.Length; i++)
            {
                DataTable vdt=(DataTable)this.OutBagWelddataGrid.DataSource;
                DataRow nr = this.OutBagWeldView.GetDataRow(selindex[i]);
                DataTable sdt = (DataTable)this.inBagWeldsdataGrid.DataSource;
                if (sdt == null)
                    return;
                sdt.ImportRow(nr);
               
                
                
                
            }
            this.OutBagWeldView.DeleteSelectedRows();
            //((DataTable)this.inBagWeldsdataGrid.DataSource).ImportRow(selDT.Rows[0]);
        }

        private void BagView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            //加载保内的焊缝；
            long vFID = Convert.ToInt64(this.BagView.GetRowCellValue(e.RowHandle, "FID"));
            this.inBagWeldsdataGrid.DataSource = _cls.GetBagWelds(vFID);
            this.OutBagWelddataGrid.DataSource = ((DataTable)this.dataGrid.DataSource).Copy();
        }

        private void butOut_Click(object sender, EventArgs e)
        {
            int[] selindex = this.InBagWeldsView.GetSelectedRows();
            for (int i = 0; i < selindex.Length; i++)
            {
                DataTable vdt = (DataTable)this.inBagWeldsdataGrid.DataSource;
                DataRow nr =this.InBagWeldsView.GetDataRow(selindex[i]);
                DataTable sdt = (DataTable)this.OutBagWelddataGrid.DataSource;
                if (sdt == null)
                    return;
                sdt.ImportRow(nr);
                //this.InBagWeldsView.DeleteRow(selindex[i]);
            }
            InBagWeldsView.DeleteSelectedRows();
        }

        private void butSaveEdit_Click(object sender, EventArgs e)
        {
            this.inBagWeldsdataGrid.Update();
            String name = "";
            int curRowhandel = this.BagView.FocusedRowHandle;
            if (curRowhandel < 0)
                return;
            DataTable idata = ((DataTable)this.BagdataGrid.DataSource).Clone();
            idata.ImportRow(this.BagView.GetDataRow(curRowhandel));


            name = this.BagView.GetRowCellValue(curRowhandel, "FNewName").ToString();
            DataTable inBagwelds_dt = (DataTable)this.inBagWeldsdataGrid.DataSource;
            if (inBagwelds_dt.GetChanges(DataRowState.Added).Rows.Count > 0 || inBagwelds_dt.GetChanges(DataRowState.Deleted).Rows.Count > 0)
            {
                if (MessageBox.Show(this, "是否确定包编辑并提交?", "消息", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    DataTable data = (DataTable)this.inBagWeldsdataGrid.DataSource;
                    data = _cls.Editupdate(idata, data, name);

                    long classid = 0;
                    DataRowView workdrw = (DataRowView)this.ClassGroup.SelectedItem;
                    classid = Convert.ToInt64(workdrw["FID"]);
                    this.dataGrid.DataSource = _cls.getClassWeldsForMerge(classid);
                    this.dataGridMerged.DataSource = _cls.getClassMergedwelds(classid);
                    tabControl_SelectedIndexChanged(tabControl, null);
                    this.inBagWeldsdataGrid.DataSource = null;
                }
            }
            else
            {
                return;
            }

        }
    }
}
