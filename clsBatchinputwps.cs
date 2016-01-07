using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Data;
using System.Data.Sql;
//using JN_WELD_Service;
namespace MC
{
    class clsBatchinputwps : clsFrmBase
    {
        String _filePath;
        String _fileName;
        String _txtname = "txtFileName";
        
        String _tablename = "WELD_RULE_1";
        String _tabename1 = "WELD_RULE_2";
        String datagridname = "dataGridView1";
        String tmpField = "WelderName,IdentificationCard,WeldingProcessAb,WeldingType,WeldingClass,WelderWorkerID,WelderDepartment,WelderWorkPlace,WelderClassID,WelderLaborServiceTeam";
        String tmpFieldType="0,0,0,0,0,0,0,0,0,0";
        int inputcmdcode = 1002;
        int cmd_Inputwps_1 = 57041;//导入WPS基本规则到tmp表
        int cmd_Inputwps_2 = 57042;//导入WPS通道信息到tmp表；
        int cmd_Inputwps = 57043;//执行导入
        String col_WPS = "dataGrid_WPS";
        String col_WPSSub = "dataGrid_WPSSub";

        public clsBatchinputwps(ref Formbase frm)
        {
            
            _frm = frm;
            //构造函数，完成界面的数据处理；事件注册
            Control[] cls= frm.Controls.Find("but_ChooseFile",true);
            if (cls.Length==0)
            {
                MessageBox.Show("没有找到控件");
                return;
            }
            //注册打开文件的事件
            Control cl=cls[0];
            cl.Click+=this.but_ChooseFile_Click;
            //读取数据事件
            cl = null;
            cl = FindControl("butRead");
            if (cl != null)
            {
                cl.Click += this.butRead_Click;
            }
            //注册导入事件
            cl = null;
            cl = FindControl("butOK");
            if (cl != null)
            {
                cl.Click += this.butOK_Click;
            }
            //PopulateColumns

        }
        /// <summary>
        /// 执行数据导入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void butOK_Click(object sender, EventArgs e)
        {
            //获取DataTable，转XML，向服务器发送命令，获取返回结果；
            if (MessageBox.Show(_frm, "是否确定导入?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            Control cl = FindControl(col_WPS);

            EF.EFDevGrid dv = (EF.EFDevGrid)cl;
            DataTable dt = (DataTable)dv.DataSource;

            Control cl1 = FindControl(col_WPSSub);
            EF.EFDevGrid dv1 = (EF.EFDevGrid)cl1;
            DataTable dt1 = (DataTable)dv1.DataSource;

            DataTable rswps_dt=_Client.ServiceCall(cmd_Inputwps_1, dt);
            DataTable rswpssub_dt = _Client.ServiceCall(cmd_Inputwps_2, dt1);
            //执行数据导入
            //DataTable rs_dt = _Client.ServiceCall(cmd_Inputwps, null);

            //显示结果
            MessageBox.Show(_frm, "导入完成，请查看导入结果", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cl = FindControl(col_WPS);
            
            if (cl != null)
            {


               // ((EF.EFDevGrid)cl).AutoGenerateColumns = true;
                ((EF.EFDevGrid)cl).DataSource = rswps_dt;
                // ((DataGridView)cl).DataMember = dt.TableName.ToString();
                ((EF.EFDevGrid)cl).Refresh();
               // ((EF.EFDevGrid)cl).ReadOnly = true;

               // ((EF.EFDevGrid)cl1).AutoGenerateColumns = true;
                ((EF.EFDevGrid)cl1).DataSource = rswpssub_dt;
                // ((DataGridView)cl).DataMember = dt.TableName.ToString();
                ((EF.EFDevGrid)cl1).Refresh();
                DevExpress.XtraGrid.Views.Grid.GridView g1 = (DevExpress.XtraGrid.Views.Grid.GridView)((EF.EFDevGrid)cl).Views[0];
                DevExpress.XtraGrid.Views.Grid.GridView g2 = (DevExpress.XtraGrid.Views.Grid.GridView)((EF.EFDevGrid)cl1).Views[0];
                g1.PopulateColumns();
                g2.PopulateColumns();
               // ((EF.EFDevGrid)cl1).ReadOnly = true;

            }
        
        }
        /// <summary>
        /// 处理界面的读取数据按钮；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void butRead_Click(object sender, EventArgs e)
        {
            //读取两个工作部
            ExcelIO excelio = new ExcelIO();
            //_fileName = "D:\\code\\JNData\\标准\\WPS标准.xls";
            DataTable dt=excelio.CSV_Getds(_fileName,_tablename+"$");
            DataTable dt1 = excelio.CSV_Getds(_fileName, _tabename1 + "$");
            long le = dt.Rows.Count;
            DataRow row = dt.Rows[1];

            Control cl = FindControl(col_WPSSub);
            Control clsub = FindControl(col_WPS);
            if (cl != null)
            {
                ((EF.EFDevGrid)cl).DataSource = null;
               // ((EF.EFDevGrid)cl).AutoGenerateColumns = true;
                ((EF.EFDevGrid)cl).DataSource = dt1;
               // ((DataGridView)cl).DataMember = dt.TableName.ToString();
                ((EF.EFDevGrid)cl).Refresh();
                //((EF.EFDevGrid)cl).ReadOnly = true;

                ((EF.EFDevGrid)clsub).DataSource = null;
               // ((EF.EFDevGrid)clsub).AutoGenerateColumns = true;
                ((EF.EFDevGrid)clsub).DataSource = dt;
               // ((DataGridView)cl).DataMember = dt.TableName.ToString();
                ((EF.EFDevGrid)clsub).Refresh();
             //   ((EF.EFDevGrid)clsub).ReadOnly = true;
                DevExpress.XtraGrid.Views.Grid.GridView g1 = (DevExpress.XtraGrid.Views.Grid.GridView)((EF.EFDevGrid)cl).Views[0];
                DevExpress.XtraGrid.Views.Grid.GridView g2 = (DevExpress.XtraGrid.Views.Grid.GridView)((EF.EFDevGrid)clsub).Views[0];
                g1.PopulateColumns();
                g2.PopulateColumns();

            }
        }
        /// <summary>
        /// 处理界面的打开文件按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void but_ChooseFile_Click(object sender, EventArgs e)
        {
            //打开文件
            String filter = "excel filer(*.xls;*xlsx)|*.xls;xlsx"; ;
            _fileName= this.Openfile(_txtname, filter);

        }
      }
    }
   