using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections;
using EI;
using EF;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;
//using JN_WELD_Service;
namespace MC
{
    /// <summary>
    /// 焊缝数据导入
    /// </summary>
    class clsBatchInputweldinfos:clsFrmBase
    {
        String _colbutRead = "butRead";
        String _colButInut = "butOK";
        String _colFileBut = "but_ChooseFile";
        String _colexcelGrid = "dataGrid";
        String _colrstGrid = "dataGrid";
        String _colfilename = "txtFileName";

        String _bookName = "WELD_DATA";
        String _filename = "";
        int inputcmdcode = 1003;

        public clsBatchInputweldinfos(ref Formbase frm)
        {
            _frm = frm;
            //构造函数，完成界面的数据处理；事件注册
            Control[] cls = frm.Controls.Find(_colFileBut, true);
            if (cls.Length == 0)
            {
                MessageBox.Show("没有找到控件");
                return;
            }
            //注册打开文件的事件
            Control cl = cls[0];
            cl.Click += this.but_ChooseFile_Click;
           
            //读取数据事件
            cl = null;
            cl = FindControl(_colbutRead);
            if (cl != null)
            {
                cl.Click += this.butRead_Click;
            }
            //注册导入事件
            cl = null;
            cl = FindControl(_colButInut);
            if (cl != null)
            {
                cl.Click += this.butOK_Click;
            }
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
            Control cl = FindControl(_colexcelGrid);
            EF.EFDevGrid dv = (EF.EFDevGrid)cl;
            DataTable dt = (DataTable)dv.DataSource;
            //String xml = clsConvertXMLDataTable.ConvertDataTableToXML(dt);
            //WeldServiceReference.CompositeType sdata = new WeldServiceReference.CompositeType();
            //sdata.CmdCode = inputcmdcode;
            //sdata.weldDataTable = xml;
            //long xmll = sdata.weldDataTable.Length;

            //DataTable sdt = clsConvertXMLDataTable.ConvertXMLToDataTable(xml);

            //WeldServiceReference.CompositeType rst = _Client.ServiceCall(sdata);
            //dt = ConvertXMLToDataTable(rst.weldDataTable);
           ;// dt=_MyClient
           dt = _Client.ServiceCall(inputcmdcode, dt);

          
            //显示结果
            MessageBox.Show(_frm, "导入完成，请查看导入结果", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //cl = FindControl(_colexcelGrid);
            if (cl != null)
            {


                //((DataGridView)cl).AutoGenerateColumns = true;
                dv.DataSource = dt;

                // ((DataGridView)cl).DataMember = dt.TableName.ToString();
                dv.Refresh();
               // ((DataGridView)cl).ReadOnly = true;
                GridView efGridView = (GridView)dv.Views[0];
                //efGridView.PopulateColumns();
            }

        }
        /// <summary>
        /// 处理界面的读取数据按钮；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void butRead_Click(object sender, EventArgs e)
        {
            ExcelIO excelio = new ExcelIO();
           //_filename = "D:\\焊缝数据测试-出错.xlsx";
            DataTable dt = excelio.CSV_Getds(_filename, _bookName + "$");
            long le = dt.Rows.Count;
            DataRow row = dt.Rows[1];

            Control cl = FindControl(_colexcelGrid);
            EF.EFDevGrid cl_dg = (EF.EFDevGrid)cl;
            if (cl != null)
            {
                cl_dg.DataSource = null;
                //((DataGridView)cl).AutoGenerateColumns = false;
                cl_dg.DataSource = dt;
                // ((DataGridView)cl).DataMember = dt.TableName.ToString();
                cl_dg.Refresh();
                //((DataGridView)cl).ReadOnly = true;
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
            String filter = "excel filer(*.xls;*xlsx)|*.xls;*xlsx"; ;
            this._filename=this.Openfile(_colfilename, filter);
            //this._filename = "D:\\焊缝数据测试-出错.xlsx";
        }
    }
}
