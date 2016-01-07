using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EI;
using EF;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Data;
using System.Drawing;
namespace MC
{
 
    /// <summary>
    /// 焊机管理基础类
    /// </summary>
    class weldEquipmentbase:_MyClient
    {

        clsFrmBase _frmbase = new clsFrmBase();
        /// <summary>
        /// 加载焊机位置，并填写到Treenode中，前提是，TreeNode为空
        /// </summary>
        public void LoadweldEquipment2Tree(ref EFTreeView vtree)
        {
            //清除
            vtree.Nodes.Clear();
            //加载位置点
            DataTable dt_point;
            dt_point=ServiceCall(clsCMD.cmd_weldEquipment_weldPoint, null);
            for (int i = 0; i < dt_point.Rows.Count; i++)
            {
                //weldEquipList.Nodes.Add(
                TreeNode tnode = new TreeNode();
                tnode.Text = dt_point.Rows[i]["FDepartName"].ToString();
                tnode.Name = dt_point.Rows[i]["FDepartName"].ToString();
                vtree.Nodes.Add(tnode);
            }
            //依据位置加载焊机；
            DataTable dt_Equipments=ServiceCall(clsCMD.cmd_weldEquipment_get,null);

            for (int j = 0; j < dt_point.Rows.Count; j++)
            {

                dt_Equipments.DefaultView.RowFilter = "FDepartName='" + dt_point.Rows[j]["FDepartName"].ToString()+"'";
                DataTable vdt = dt_Equipments.DefaultView.ToTable();
                TreeNode pnode=null;
                for (int k=0;k<vtree.Nodes.Count;k++)
                {
                    pnode = _frmbase.FindTreeNodeByKey(dt_point.Rows[j]["FDepartName"].ToString(), vtree.Nodes[k]) ;//vtree.Nodes[dt_point.Rows[j]["FDepartName"].ToString()];
                    if (pnode != null)
                    {
                        k = vtree.Nodes.Count;
                    }
                }
                if (pnode == null)
                {
                    MessageBox.Show("未找到上级部门", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                  for (int i = 0; i < vdt.Rows.Count; i++)
                    {
                        TreeNode tnode = new TreeNode();
                        tnode.Text = vdt.Rows[i]["FEquipName"].ToString();
                        tnode.Name = vdt.Rows[i]["FweldEquipmentID"].ToString();
                        int st = Convert.ToInt32(vdt.Rows[i]["FStateID"]);
                        tnode.ImageIndex = Convert.ToInt32(vdt.Rows[i]["FStateID"]);
                        
                        pnode.Nodes.Add(tnode);

                    }
                
                    

            }
            vtree.SelectedNode = vtree.Nodes[0];
            DataTable welddt = ServiceCall(1030, null);






            for (int j = 0; j < welddt.Rows.Count; j++)
            {
                for (int k = 0; k < vtree.Nodes.Count; k++)
                {
                    TreeNode pnode = _frmbase.FindTreeNodeByKey(welddt.Rows[j]["nom"].ToString(), vtree.Nodes[k]);//vtree.Nodes[dt_point.Rows[j]["FDepartName"].ToString()];
                    if (pnode != null)
                    {
                        if (welddt.Rows[j]["state"].ToString() == "关闭")
                        {
                            pnode.ForeColor = Color.Gray;
                        }
                        if (welddt.Rows[j]["state"].ToString() == "焊接")
                        {
                            pnode.ForeColor = Color.Blue;
                        }
                        if (welddt.Rows[j]["state"].ToString() == "报警")
                        {
                            pnode.ForeColor = Color.Red;
                        }
                        if (welddt.Rows[j]["state"].ToString() == "待机")
                        {
                            pnode.ForeColor = Color.Green;
                        }
                        k = vtree.Nodes.Count;
                    }
                    else
                    {

                    }
                }
            }

        }
    }
}
