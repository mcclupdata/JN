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
namespace MC
{
    class weldWorkerbase:_MyClient
    {
        clsFrmBase _frmbase = new clsFrmBase();
        /// <summary>
        /// 加载焊机位置，并填写到Treenode中，前提是，TreeNode为空
        /// </summary>
        public void LoadwelderTree(ref EFTreeView vtree)
        {
            //vtree.Nodes.Clear();
            //DataTable dt_point;
            //dt_point = ServiceCall(clsCMD.cmd_welderedit_getwelders, null);
            //TreeNode wnode = new TreeNode();
            //wnode.Text = "焊工";
            //wnode.Name = "welder";
            //vtree.Nodes.Add(wnode);
            //TreeNode pnode = null;
            //pnode = _frmbase.FindTreeNodeByKey("焊工", vtree.Nodes[0]);
            //for (int i = 0; i < dt_point.Rows.Count; i++)
            //{
            //    TreeNode tnode = new TreeNode();
            //    tnode.Text = dt_point.Rows[i]["FName"].ToString();
            //    tnode.Name = dt_point.Rows[i]["Fnum"].ToString();
            //    pnode.Nodes.Add(tnode);
            //}
            //清除
            vtree.Nodes.Clear();
            //加载位置点
            DataTable dt_point;
            dt_point = ServiceCall(clsCMD.cmd_weldEquipment_welderPoint, null);
            DataTable dt_equippoint = ServiceCall(clsCMD.cmd_weldEquipment_weldPoint, null);
            for (int i = 0; i < dt_equippoint.Rows.Count; i++)
            {
                //weldEquipList.Nodes.Add(
                TreeNode tnode = new TreeNode();
                tnode.Text = dt_equippoint.Rows[i]["FDepartName"].ToString();
                tnode.Name = dt_equippoint.Rows[i]["FDepartName"].ToString();
                //tnode.Text = dt_point.Rows[i]["FDepartID"].ToString();
                //tnode.Name = dt_point.Rows[i]["FDepartID"].ToString();
                vtree.Nodes.Add(tnode);
            }
            //依据位置加载焊工；
            DataTable dt_welders = ServiceCall(clsCMD.cmd_welderedit_getwelders, null);
            DataTable dt_equipment = ServiceCall(clsCMD.cmd_weldEquipment_get, null);
            for (int j = 0; j < dt_point.Rows.Count; j++)
            {

                dt_welders.DefaultView.RowFilter = "Fdepart=" + dt_point.Rows[j]["FDepartID"].ToString();
                DataTable vdt = dt_welders.DefaultView.ToTable();
                TreeNode pnode = null;
                for (int k = 0; k < vtree.Nodes.Count; k++)
                {
                    pnode = _frmbase.FindTreeNodeByKey(dt_point.Rows[j]["FDepartName"].ToString(), vtree.Nodes[k]);//vtree.Nodes[dt_point.Rows[j]["FDepartName"].ToString()];
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
                    tnode.Text = vdt.Rows[i]["FName"].ToString();
                    tnode.Name = vdt.Rows[i]["Fnum"].ToString();
                    pnode.Nodes.Add(tnode);

                }



            }
            vtree.SelectedNode = vtree.Nodes[0];
        }
    }
}
