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
using System.Data.Sql;
using System.Data.SqlClient;
namespace MC
{
    public partial class FormMCCL00033 : Formbase


    {
        private _MyClient _Client = new _MyClient();
        private clsFrmBase _frmbase = new clsFrmBase();
        DataTable _Departs;
        public FormMCCL00033()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 双击节点，将节点提交给编辑框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void efTreeViewEx1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode selNode = Departments.SelectedNode;
            if (selNode == null)
                return;
            if (selNode.Name == selNode.Text)
                return;
            String weldnom = selNode.Name;
            //构建查询参数
            DataTable dtf = new DataTable();
            DataColumn col = new DataColumn();
            col.ColumnName = "nom";
            col.DataType = typeof(String);
            col.MaxLength = 20;
            dtf.Columns.Add(col);
            DataRow row = dtf.NewRow();
            row[0] = weldnom;
            DataTable rdt = _Client.ServiceCall(clsCMD.cmd_weldEquipManage_getOneweldEquipInfo, dtf);
            //将数据填写到界面中
            this.Fleve.Text = rdt.Rows[0]["FDepartName"].ToString();
            this.FName.Text = rdt.Rows[0]["FEquipName"].ToString();
            this.FParentID.Text = rdt.Rows[0]["FweldEquipmentID"].ToString();
            this.IsWeld.Checked = Convert.ToBoolean(Convert.IsDBNull(rdt.Rows[0]["IsWeld"])? 1:rdt.Rows[0]["IsWeld"]);
            long departid = Convert.ToInt64(rdt.Rows[0]["FDepartID"]);
            //this.FDepartID.
        }

        
        /// <summary>
        /// 部门基本数据
        /// </summary>
        protected void LoadDeparetParams()
        {
            DataTable  dt_leve= new DataTable();
            DataColumn col = new DataColumn();
            col.ColumnName = "FName"; col.DataType = typeof(String); dt_leve.Columns.Add(col);
            col=new DataColumn();col.ColumnName = "Fleve"; col.DataType = typeof(int); dt_leve.Columns.Add(col);
            dt_leve.Rows.Add("作业区",1);
            dt_leve.Rows.Add("班组",2);
            this.Fleve.Properties.DisplayMember = "FName";
            this.Fleve.Properties.ValueMember = "Fleve";
            this.Fleve.Properties.DataSource = dt_leve;
            this.Fleve.ItemIndex = 0;



        }
        /// <summary>
        /// 界面数据初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMCCL00026_Load(object sender, EventArgs e)
        {
            LoadDepartments2Tree();
            //加载准备数据
            LoadDeparetParams();
            
            fullPanel.Enabled = false;
            this.IsWeld.Checked = false;
        }

        private void LoadDepartments2Tree()
        {
            Departments.Nodes.Clear();
            DataTable dt_departs = _Client.ServiceCall(clsCMD.cmd_DepartMgs_Departments, new DataTable());
            _Departs = dt_departs.Copy();
            for (int i = 0; i < 3; i++)
            {
                DataView dv = dt_departs.Copy().DefaultView;
                dv.RowFilter = "Flevel=" + i.ToString();
                DataTable dt = dv.ToTable();
                for (int k = 0; k < dt.Rows.Count; k++)
                {
                    TreeNode node = new TreeNode();
                    node.Name = dt.Rows[k]["FID"].ToString();
                    node.Text = dt.Rows[k]["FDepartName"].ToString();
                    node.ImageIndex = Convert.ToInt32(dt.Rows[0]["Flevel"]);
                    node.Tag = Convert.ToInt32(Convert.IsDBNull(dt.Rows[0]["IsWeld"]) ? 1 : dt.Rows[0]["IsWeld"]);
                    if (Convert.ToInt64(dt.Rows[k]["FParentID"]) > 0)
                    {
                        //int iIndex = Departments.NodIses.IndexOfKey(dt.Rows[k]["FParentID"].ToString());
                        TreeNode pnode =_frmbase.FindTreeNodeByKey(dt.Rows[k]["FParentID"].ToString(),Departments.Nodes[0]);
                        pnode.Nodes.Add(node);
                    }
                    else
                    {
                       
                        Departments.Nodes.Add(node);
                    }
                }
            }

        }

        private void FweldManufacturerID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 进行焊机编辑；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void weldEquipments_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
        /// <summary>
        /// 从界面中提取数据
        /// </summary>
        /// <returns></returns>
        protected DataTable LoadInfofrmForm()
        {
            long vFID=0;
            if (FID.Text.Length > 0)
            {
                vFID = Convert.ToInt64(FID.Text);
            }
            DataView dv = _Departs.Copy().DefaultView;
            dv.RowFilter = "FID=" + vFID;
            DataTable dt = dv.ToTable();
            if (dt.Rows.Count == 0)
                dt.Rows.Add(dt.NewRow());
            dt.Rows[0]["FParentID"] = Convert.ToInt64(FParentID.EditValue);
            dt.Rows[0]["FDepartName"] = FName.Text;//Convert.ToInt64(FDepartID.EditValue);
            dt.Rows[0]["Flevel"] = Fleve.EditValue;//.SelectedText;
           dt.Rows[0]["IsWeld"]=Convert.ToInt32(this.IsWeld.Checked);
            return dt;
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            DataTable dt = LoadInfofrmForm();
            if (MessageBox.Show(this, "是否提交数据?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //DataColumn col = new DataColumn("FDEL", typeof(int));
                //dt.Columns.Add(col);
                //dt.Rows[0]["FDEL"] = 0;
                DataTable rdt = _Client.ServiceCall(clsCMD.cmd_DepartMgs_upDateDepartments, dt);
                //刷新Tree
                FormMCCL00026_Load(null, null);
                FID.Text = "-1";
                fullPanel.Enabled = false;
            }
        }

        private void addms_Click(object sender, EventArgs e)
        {
            if (Departments.SelectedNode == null)
                return;

            if (Departments.SelectedNode.ImageIndex == 2)
                return;
            
            if (FID.Text != "-1")
            {

               
                if (MessageBox.Show(this, "还有未保存的数据，是否放弃？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {


                    return;
                  
                    
                }
             
            }
            if (Departments.SelectedNode.ImageIndex == 0)
            {
                //增加作业区
                Fleve.EditValue = 1;
                Fleve.Enabled = false;

                DataView dv = _Departs.Copy().DefaultView;
                dv.RowFilter = "Flevel=0";
                DataTable dt = dv.ToTable(true, "FID", "FDepartName");
                FParentID.Properties.DataSource = dt;

                FParentID.ItemIndex = 0;
            }
            if (Departments.SelectedNode.ImageIndex == 1)
            {
                //增加班组
                Fleve.EditValue = 2;
                Fleve.Enabled = false;
                DataView dv = _Departs.Copy().DefaultView;
                dv.RowFilter = "Flevel=1";
                DataTable dt = dv.ToTable(true, "FID", "FDepartName");
                FParentID.Properties.DataSource = dt;

                FParentID.EditValue = Convert.ToInt64(Departments.SelectedNode.Name);
                Fleve.Enabled = false;
            }

            fullPanel.Enabled = true;
            this.FName.Text = "";

            FID.Text = "0";
        }

        private void delms_Click(object sender, EventArgs e)
        {
            if (Departments.SelectedNode == null)
                return;
            TreeNode selNode = Departments.SelectedNode;
            if (selNode.ImageIndex==0)
                return;
            String departid = selNode.Name;
            if (MessageBox.Show(this, "是否确定删除该部门：" + selNode.Text, "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataView dv=_Departs.Copy().DefaultView;
                dv.RowFilter = "FID=" + departid ;
                DataTable dt = dv.ToTable();
                DataColumn col = new DataColumn();
                col.DataType = typeof(int);
                col.ColumnName = "FDEL";
                dt.Columns.Add(col);
                dt.Rows[0]["FDel"] = 1;
                DataTable rst = _Client.ServiceCall(clsCMD.cmd_DepartMgs_upDateDepartments, dt);
                FormMCCL00026_Load(null, null);
            }

        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.FID.Text = "-1";
            Fleve.Text = "";
            fullPanel.Enabled = false;
        }

        private void modifyms_Click(object sender, EventArgs e)
        {
            if (Departments.SelectedNode == null)
                return;
            TreeNode sNode = Departments.SelectedNode;
            if (sNode.ImageIndex == 0)
                return;
            if (sNode.ImageIndex == 1)
            {
                //作业区
                Fleve.EditValue = 1;
                Fleve.Enabled = false;

                DataView dv = _Departs.Copy().DefaultView;
                dv.RowFilter = "Flevel=0";
                DataTable dt = dv.ToTable(true,"FID","FDepartName");
                FParentID.Properties.DataSource = dt;

                FParentID.EditValue = Convert.ToInt64(1);
                FParentID.Enabled =true;
            }
            if (sNode.ImageIndex == 2)
            {
                //班组
                DataView dv = _Departs.Copy().DefaultView;
                dv.RowFilter = "Flevel=1";
                DataTable dt = dv.ToTable(true, "FID", "FDepartName","IsWeld");
                FParentID.Properties.DataSource = dt;
                //this.IsWeld.Checked = this.IsWeld.Checked = Convert.ToBoolean(Convert.IsDBNull(rdt.Rows[0]["IsWeld"]) ? 1 : rdt.Rows[0]["IsWeld"]);
                FParentID.EditValue =Convert.ToInt64(sNode.Parent.Name);
                Fleve.EditValue = 2;
                Fleve.Enabled = false;
            }
            FName.Text = sNode.Text;
            FID.Text = sNode.Name;
            this.IsWeld.Checked = Convert.ToBoolean(sNode.Tag==null?1:sNode.Tag);
            fullPanel.Enabled = true;

        }
    }
}
