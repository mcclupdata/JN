

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
            this.dataGridMerged.DataSource = _cls.getClassMergedwelds(classid);
        }

        private void FormMCCL00121_LocationChanged(object sender, EventArgs e)
        {

        }

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
    }
}
