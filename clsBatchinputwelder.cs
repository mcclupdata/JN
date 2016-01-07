using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Data;
using System.Data.Sql;
using EI;
using EF;

//using JN_WELD_Service;
namespace MC
{
    class clsBatchinputwelder : clsFrmBase
    {
        String _filePath;
        String _fileName;
        String _txtname = "txtFileName";
        
        String _tablename = "WelderIssueStudentQCRegistratio";
        String datagridname = "dataGridView1";
        String tmpField = "WelderName,IdentificationCard,WeldingProcessAb,WeldingType,WeldingClass,WelderWorkerID,WelderDepartment,WelderWorkPlace,WelderClassID,WelderLaborServiceTeam";
        String tmpFieldType="0,0,0,0,0,0,0,0,0,0";
        int inputcmdcode = 1002;
        MC.FormMCCL00011 frm_1;
        public clsBatchinputwelder(ref Formbase frm)
        {
            _frm = frm;
            frm_1 = (MC.FormMCCL00011)frm;
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
            _frm.EF_DO_F1 += new EFButtonBar.EFDoFnEventHandler(_frm_EF_DO_F1);
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

        }

        void _frm_EF_DO_F1(object sender, EF_Args e)
        {
            butOK_Click(null, null);
            //throw new NotImplementedException();
        }
        /// <summary>
        /// 执行数据导入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butOK_Click(object sender, EventArgs e)
        {
            //获取DataTable，转XML，向服务器发送命令，获取返回结果；
            if (MessageBox.Show(_frm, "是否确定导入?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            // DevExpress.XtraGrid.Views.Grid.GridView dv = FindControl("dataGrid",datagridname);

            EFDevGrid dv = (EFDevGrid)FindControl("dataGrid");
            DataTable dt = (DataTable)dv.DataSource;

           
            //String xml = clsConvertXMLDataTable.ConvertDataTableToXML(dt);
            //WeldServiceReference.CompositeType sdata = new WeldServiceReference.CompositeType();
            //sdata.CmdCode = inputcmdcode;
            //sdata.weldDataTable = xml;
            
            //WeldServiceReference.CompositeType rst= _Client.ServiceCall(sdata);

            DataTable dt2 = _Client.ServiceCall(inputcmdcode, dt);// ConvertXMLToDataTable(rst.weldDataTable);


            
            //显示结果
            MessageBox.Show(_frm, "导入完成，请查看导入结果", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            EF.EFDevGrid EFDG_1 = (EF.EFDevGrid)FindControl("dataGrid");
            if (EFDG_1 != null)
            {

               
                //dv1.AutoGenerateColumns = true;

                EFDG_1.DataSource = (object)dt2;
                // ((DataGridView)cl).DataMember = dt.TableName.ToString();
                EFDG_1.Refresh();
                //EFDG_1.ReadOnly = true;

                DevExpress.XtraGrid.Views.Grid.GridView efGridView = (DevExpress.XtraGrid.Views.Grid.GridView)EFDG_1.Views[0];
                efGridView.PopulateColumns();
            }
        
        }
        /// <summary>
        /// 处理界面的读取数据按钮；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butRead_Click(object sender, EventArgs e)
        {
            ExcelIO excelio = new ExcelIO();
            DataTable dt=excelio.CSV_Getds(_fileName,_tablename+"$");
            long le = dt.Rows.Count;
            DataRow row = dt.Rows[1];

            Control cl = FindControl("dataGrid");
            if (cl != null)
            {
                ((EF.EFDevGrid)cl).DataSource = null;
                //((EF.EFDevGrid)cl).AutoGenerateColumns = false;
                ((EF.EFDevGrid)cl).DataSource = dt;
               // ((DataGridView)cl).DataMember = dt.TableName.ToString();
                ((EF.EFDevGrid)cl).Refresh();
                //((EF.EFDevGrid)cl).ReadOnly = true;
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
            String filter = "excel filer(*.xls;*.xlsx)|*.xls;*.xlsx"; ;
            _fileName= this.Openfile(_txtname, filter);

        }
      }
    }
   