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
    public partial class FormMCCL00026 :Formbase


    {
        private _MyClient _Client = new _MyClient();
        DataTable weldEquipments_dt;
        public FormMCCL00026()
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
            TreeNode selNode = weldEquipments.SelectedNode;
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
            this.FDepartName.Text = rdt.Rows[0]["FDepartName"].ToString();
            this.FEquipName.Text = rdt.Rows[0]["FEquipName"].ToString();
            this.FweldEquipmentID.Text = rdt.Rows[0]["FweldEquipmentID"].ToString();
            long departid = Convert.ToInt64(rdt.Rows[0]["FDepartID"]);
            //this.FDepartID.
        }

        
        /// <summary>
        /// 加载焊机基本参数
        /// </summary>
        protected void LoadweldEquipParams()
        {
            DataTable fdt = new DataTable();
            DataColumn col = new DataColumn();
            col.ColumnName = "params";
            col.DataType = typeof(int);
            fdt.Columns.Add(col);
            DataRow row = fdt.NewRow();
            row[0] = 0;
            fdt.Rows.Add(row);
            //加载焊机厂家
            DataTable manu_rst=_Client.ServiceCall(clsCMD.cmd_weldEquipManage_getParams, fdt);
            //绑定

            FweldManufacturerID.Properties.DataSource = manu_rst;
            
            FweldManufacturerID.Properties.DisplayMember = "FName";
            FweldManufacturerID.Properties.ValueMember = "FID";
            if (manu_rst.Rows.Count > 0)
                FweldManufacturerID.ItemIndex = 0;
            //加载焊机归属
            fdt.Rows[0][0] = 1;
            DataTable departid_dt = _Client.ServiceCall(clsCMD.cmd_weldEquipManage_getParams, fdt);
            departid_dt.DefaultView.RowFilter = "IsWeld=1 ";
            departid_dt = departid_dt.DefaultView.ToTable(true,"FID", "FDepartName");
            FDepartID.Properties.DataSource = departid_dt;
            FDepartID.Properties.DisplayMember = "FDepartName";
            FDepartID.Properties.ValueMember = "FID";
            if (departid_dt.Rows.Count>0)
                FDepartID.ItemIndex = 0;
            //加载位置
            DataTable point_dt = _Client.ServiceCall(clsCMD.cmd_weldEquipment_weldPoint, null);
            FDepartName.Properties.Items.Clear();
            for (int i = 0; i < point_dt.Rows.Count; i++)
            {
                FDepartName.Properties.Items.Add(point_dt.Rows[i][0].ToString());
            }
            
            if (point_dt.Rows.Count > 0)
                FDepartName.SelectedIndex = 0;
            FState.SelectedIndex = 0;
            //加载松下/OTC焊机
            DataTable welds_dt = _Client.ServiceCall(clsCMD.cmd_weldEquipment_getBase_Bynom, null);
            DataView welds_dv = welds_dt.DefaultView;
            DataTable nwelds_dt = welds_dv.ToTable(true, "nom", "equipname");
            FweldEquipmentID.Properties.DataSource = nwelds_dt;
            FweldEquipmentID.Properties.DisplayMember = "equipname";
            FweldEquipmentID.Properties.ValueMember = "nom";
            if (welds_dt.Rows.Count > 0)
                FweldEquipmentID.ItemIndex = 0;
        }
        /// <summary>
        /// 界面数据初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMCCL00026_Load(object sender, EventArgs e)
        {
            weldEquipmentbase webase = new weldEquipmentbase();
            webase.LoadweldEquipment2Tree(ref this.weldEquipments);
            //加载准备数据
            LoadweldEquipParams();
            weldEquipments_dt = _Client.ServiceCall(clsCMD.cmd_weldEquipment_get, null);
            fullPanel.Enabled = false;
           
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
            TreeNode selNode = weldEquipments.SelectedNode;
            if (selNode == null)
                return;
            if (selNode.Name == selNode.Text)
                return;
            fullPanel.Enabled = true;
            DataView dv = weldEquipments_dt.Copy().DefaultView;
            dv.RowFilter = "FweldEquipmentID='" + selNode.Name + "'";
            DataTable dt = dv.ToTable();
            //将数据填写到右侧编辑区内
            String vFDepartID = dt.Rows[0]["FDepartID"].ToString();
            FDepartID.EditValue = Convert.ToInt64(vFDepartID);
            //FDepartID.SelectedText = dt.Rows[0]["FEquipName"].ToString(); ;//dt.Rows[0]["FDepartID"].ToString();
            FDepartName.Text = dt.Rows[0]["FDepartName"].ToString();
            FState.SelectedIndex = Convert.ToInt32(dt.Rows[0]["FStateID"].ToString());
            FEquipName.Text = dt.Rows[0]["FEquipName"].ToString();
            FweldManufacturerID.EditValue = Convert.ToInt64(dt.Rows[0]["FweldManufacturerID"]);

            FweldEquipmentID.EditValue = dt.Rows[0]["FweldEquipmentID"].ToString();

            FDepartName.Text = FDepartID.Text;
            
            FID.Text = dt.Rows[0]["FID"].ToString();
            
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
            DataView dv = weldEquipments_dt.Copy().DefaultView;
            dv.RowFilter = "FID=" + vFID;
            DataTable dt = dv.ToTable();
            if (dt.Rows.Count == 0)
                dt.Rows.Add(dt.NewRow());
            dt.Rows[0]["FDepartID"] = Convert.ToInt64(FDepartID.EditValue);
            dt.Rows[0]["FDepartName"] = FDepartName.Text;//Convert.ToInt64(FDepartID.EditValue);
            dt.Rows[0]["FStateID"] = FState.SelectedIndex;//.SelectedText;
            dt.Rows[0]["FEquipName"] = FEquipName.Text;//.SelectedText;
            dt.Rows[0]["FweldManufacturerID"] =Convert.ToInt64( FweldManufacturerID.EditValue);//.Text;//.SelectedText;
            dt.Rows[0]["FweldEquipmentID"] = Convert.ToInt64(FweldEquipmentID.EditValue);
            dt.Rows[0]["FDepartName"] = FDepartID.Text;
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
                DataTable rdt = _Client.ServiceCall(clsCMD.cmd_weldEquipManage_getUpdate, dt);
                //刷新Tree
                FormMCCL00026_Load(null, null);
                FID.Text = "-1";
                fullPanel.Enabled = false;
            }
        }

        private void addms_Click(object sender, EventArgs e)
        {
            if (weldEquipments.SelectedNode == null)
                return;
            
            if (FID.Text != "-1")
            {
                if (MessageBox.Show(this, "还有未保存的数据，是否放弃？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    fullPanel.Enabled = true;
                    this.FEquipName.Text = "";
                    this.FDepartName.SelectedText = "";
                    FID.Text = "0";
                    TreeNode selNode = weldEquipments.SelectedNode;
                    if (selNode.Name == selNode.Text)
                    {
                        FDepartName.Text = selNode.Name;
                    }
                    else
                    {
                        TreeNode paNode = selNode.Parent;
                        FDepartName.Text = paNode.Name;

                    }
                    
                }
                else
                {
                    return;
                }
            }
        }

        private void delms_Click(object sender, EventArgs e)
        {
            if (weldEquipments.SelectedNode == null)
                return;
            TreeNode selNode = weldEquipments.SelectedNode;
            if (selNode.Name == selNode.Text)
                return;
            String weldid = selNode.Name;
            if (MessageBox.Show(this, "是否确定删除焊机：" + selNode.Text, "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataView dv=weldEquipments_dt.Copy().DefaultView;
                dv.RowFilter = "FweldEquipmentID='" + weldid + "'";
                DataTable dt = dv.ToTable();
                DataColumn col = new DataColumn();
                col.DataType = typeof(int);
                col.ColumnName = "FDEL";
                dt.Columns.Add(col);
                dt.Rows[0]["FDEL"] = 1;
                DataTable rst = _Client.ServiceCall(clsCMD.cmd_weldEquipManage_getUpdate, dt);
                FormMCCL00026_Load(null, null);
            }

        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.FID.Text = "-1";
            FDepartName.Text = "";
            fullPanel.Enabled = false;
        }

        private void FDepartID_EditValueChanged(object sender, EventArgs e)
        {
            this.FDepartName.Text = this.FDepartID.Text;
        }
    }
}
