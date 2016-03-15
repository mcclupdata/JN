using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using EI;
using EF;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;

namespace MC
{

    struct ControlExt_Combox
    {
        public String ID;
        public String TextID;
        public String ValueID;
        public String sql;
    }
    struct ControlExt_DataGridView
    {
        public String ID;
        public String sql;

    }
    /// <summary>
    ///
    /// </summary>
    public class clsfrmData
    {
        protected Formbase _frm;
        protected _MyClient _Client = new _MyClient();

        protected Control FindControl(String colname,Form frm)
        {
            Control[] cls = frm.Controls.Find(colname, true);
            if (cls.Length == 0)
            {
               return null;
            }
            
            //注册打开文件的事件
            Control cl = cls[0];
            return cl;

        }


        public clsfrmData()
        {

        }





        //MC.WeldServiceReference.WeldServiceClient sClient = new MC.WeldServiceReference.WeldServiceClient();
        public Control foreachColtrolByName(String  sname, Control cl)
        {
            if (cl.Controls.Count > 0)
            {
                foreach (Control ncl in cl.Controls)
                {
                    Control rtcl = foreachColtrolByName(sname, ncl);
                    if (rtcl==null)
                    {

                    }
                    else
                    {
                        return rtcl;
                    }
                }
                return null;
            }
            else
            {
              
                try
                {
                    if (cl.GetType() == typeof(EFButton))
                    {
                        if (cl.Text == sname)
                        {
                            return cl;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        return null;
                    }
                    
                }
                catch { return null; }




            }
        }

        protected void foreachColtrolFillData(DataRow dt, Control cl)
        {
            if (cl.Controls.Count > 0)
            {
                foreach (Control ncl in cl.Controls)
                {
                    foreachColtrolFillData(dt, ncl);
                }
            }
            else
            {
                DataRow row =dt;
                try
                {
                    if (cl.GetType() == typeof(TextBox) || cl.GetType() == typeof(EFTextBox))
                    {
                        if (cl.Parent.GetType() == typeof(EFLabelText))
                        {
                            EFLabelText ltxt = (EFLabelText)cl.Parent;
                            ltxt.EFEnterText = row[ltxt.Name].ToString();
                        }
                        else
                        {
                            cl.Text = row[cl.Name].ToString();
                        }
                    }
                    if (cl.GetType() == typeof(Label))
                    {
                        cl.Text = row[cl.Name].ToString();
                    }
                    if (cl.GetType() == typeof(ComboBox) || cl.GetType() == typeof(EFComboBox))
                    {
                        ((ComboBox)cl).SelectedIndex = Convert.ToInt32(row[cl.Name]);

                    }
                    if (cl.GetType() == typeof(System.Windows.Forms.DateTimePicker))
                    {
                        if (Convert.IsDBNull(row[cl.Name]))
                            ((System.Windows.Forms.DateTimePicker)cl).Value = DateTime.Now;
                        else
                            ((System.Windows.Forms.DateTimePicker)cl).Value = (DateTime)row[cl.Name];
                    }
                    if (cl.GetType() == typeof(EFDateTimePicker2))
                    {
                        if (Convert.IsDBNull(row[cl.Name]))
                            ((EFDateTimePicker2)cl).Value = DateTime.Now;
                        else
                            ((EFDateTimePicker2)cl).Value = (DateTime)row[cl.Name];
                    }
                    if (cl.GetType() == typeof(EFDateTimePicker))
                    {
                        if (Convert.IsDBNull(row[cl.Name]))
                            ((EFDateTimePicker)cl).Value = DateTime.Now;
                        else
                            ((EFDateTimePicker)cl).Value = (DateTime)row[cl.Name];
                    }
                }
                catch { }




            }
        }
        //10.30.8.20

        protected void foreachColtrolFillData( DataTable dt, Control cl)
        {
            if (cl.Controls.Count > 0)
            {
                foreach (Control ncl in cl.Controls)
                {
                    foreachColtrolFillData( dt,  ncl);
                }
            }
            else
            {
                if (dt.Rows.Count == 0)
                    return;
                DataRow row = dt.Rows[0];
                try
                {
                    if (cl.GetType() == typeof(TextBox) || cl.GetType() == typeof(EFTextBox))
                    {
                        if (cl.Parent.GetType() == typeof(EFLabelText))
                        {
                            EFLabelText ltxt = (EFLabelText)cl.Parent;
                            ltxt.EFEnterText = row[ltxt.Name].ToString();
                        }
                        else
                        {
                            cl.Text = row[cl.Name].ToString();
                        }
                    }
                    if (cl.GetType() == typeof(Label))
                    {
                        cl.Text = row[cl.Name].ToString();
                    }
                    if (cl.GetType() == typeof(ComboBox) || cl.GetType() == typeof(EFComboBox))
                    {
                        ((ComboBox)cl).SelectedIndex = Convert.ToInt32(row[cl.Name]);
                        
                    }
                    if (cl.GetType() == typeof(System.Windows.Forms.DateTimePicker))
                    {
                        if (Convert.IsDBNull(row[cl.Name]))
                            ((System.Windows.Forms.DateTimePicker)cl).Value = DateTime.Now;
                        else
                            ((System.Windows.Forms.DateTimePicker)cl).Value = (DateTime)row[cl.Name];
                    }
                    if (cl.GetType() == typeof(EFDateTimePicker2))
                    {
                        if (Convert.IsDBNull(row[cl.Name]))
                            ((EFDateTimePicker2)cl).Value = DateTime.Now;
                        else
                            ((EFDateTimePicker2)cl).Value = (DateTime)row[cl.Name];
                    }
                    if (cl.GetType() == typeof(EFDateTimePicker))
                    {
                        if (Convert.IsDBNull(row[cl.Name]))
                            ((EFDateTimePicker)cl).Value = DateTime.Now;
                        else
                            ((EFDateTimePicker)cl).Value = (DateTime)row[cl.Name];
                    }
                    if (cl.GetType() == typeof(YutouCSharpNameSpace.TNS_YutouControlLED.TC_SevenSegmentLED))
                    {
                       // YutouCSharpNameSpace.TNS_YutouControlLED.TC_SevenSegmentLED ccl=(YutouCSharpNameSpace.TNS_YutouControlLED.TC_SevenSegmentLED)cl;
                       // ccl.TP_ClockStyle=
                        if (((YutouCSharpNameSpace.TNS_YutouControlLED.TC_SevenSegmentLED)cl).TP_ClockStyle == YutouCSharpNameSpace.TNS_YutouControlLED.Enum_LEDClockStyle.NotClockShow)
                        {
                            if (Convert.IsDBNull(row[cl.Name]))
                                ((YutouCSharpNameSpace.TNS_YutouControlLED.TC_SevenSegmentLED)cl).TP_Doub_Number = 0;
                            else
                                ((YutouCSharpNameSpace.TNS_YutouControlLED.TC_SevenSegmentLED)cl).TP_Doub_Number = Convert.ToDouble(row[cl.Name]);
                        }
                        else
                        {
                            if (Convert.IsDBNull(row[cl.Name]))
                                ((YutouCSharpNameSpace.TNS_YutouControlLED.TC_SevenSegmentLED)cl).TP_DateTime = DateTime.Now;
                            else
                                ((YutouCSharpNameSpace.TNS_YutouControlLED.TC_SevenSegmentLED)cl).TP_DateTime = Convert.ToDateTime(row[cl.Name].ToString());
                            ((YutouCSharpNameSpace.TNS_YutouControlLED.TC_SevenSegmentLED)cl).Refresh();
                        }
                    }
                }
                catch { }

               

               
            }
        }
        /// <summary>
        /// 遍历界面的控件，提取数据到DataTable
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="cl"></param>
        /// <param name="noField"></param>
        protected void foreachColtrol(ref DataTable dt, Control cl, String noField)
        {
            if (cl.Controls.Count > 0)
            {
                foreach (Control ncl in cl.Controls)
                {
                    foreachColtrol(ref dt, ncl, noField);
                }
            }
            else
            {
                if (noField.IndexOf(cl.Name) < 0)
                {
                    DataColumn col = null;

                    if (cl.Controls.Count == 0)
                    {

                    
                        if (cl.GetType() == typeof(TextBox) || cl.GetType() == typeof(EFTextBox) )
                        {
                            if (cl.Parent.GetType() == typeof(EFLabelText))
                            {

                                col = new DataColumn(cl.Parent.Name, typeof(String));
                            }
                            else
                            {
                                col = new DataColumn(cl.Name, typeof(String));
                            }
                        }
                        if (cl.GetType() == typeof(DateTimePicker) || cl.GetType() == typeof(EFDateTimePicker) || cl.GetType() == typeof(EFDateTimePicker2))
                        {
                            col = new DataColumn(cl.Name, typeof(String));
                            //MessageBox.Show(col.DataType.ToString());
                        }
                        if (cl.GetType() == typeof(ComboBox) || cl.GetType() == typeof(EFComboBox))
                        {
                            col = new DataColumn(cl.Name, typeof(long));
                        }
                        if (col != null)
                        {
                            col.AllowDBNull = true;
                            // col.ColumnName = cl.Name;
                            dt.Columns.Add(col);

                        }
                    }
                }
            }
        }
        /// <summary>
        /// 从界面中提取数据并保存到DataTabel中
        /// </summary>
        /// <param name="frm">需要提取的界面</param>
        /// <param name="noField">不需要的控件名称列表</param>
        /// <returns>返回DataTable</returns>
        public void getDataFrom(System.Windows.Forms.Form frm,ref DataTable sdata)
        {
            DataTable datatable = new DataTable();
           //枚举需要提取的数据
            DataRow row;
            if (sdata.Rows.Count == 0)
            {
                row = sdata.NewRow();
            }
            else
            {
                row = sdata.Rows[0];
            }
            for (int i = 0; i < sdata.Columns.Count; i++)
            {
                Control cl = FindControl(sdata.Columns[i].ColumnName, frm);

                if (cl != null)
                {
                    if (cl.GetType() == typeof(TextBox) || cl.GetType() == typeof(EF.EFTextBox) || cl.GetType() == typeof(EF.EFLabelText))
                    {
                        row[i] = cl.Text;
                    }
                    if (cl.GetType() == typeof(EF.EFLabelText))
                    {
                        EFLabelText ltxt = (EFLabelText)cl;
                        row[i] = ltxt.EFEnterText;// cl.Text;
                    }
                    if (cl.GetType() == typeof(DateTimePicker))
                    {
                        String tim = ((DateTimePicker)cl).Value.ToShortDateString();
                        row[i] = ((DateTimePicker)cl).Value.ToShortDateString();
                    }
                    if (cl.GetType() == typeof(EF.EFDateTimePicker))
                    {
                        String tim = ((EF.EFDateTimePicker)cl).Value.ToShortDateString();
                        row[i] = ((EF.EFDateTimePicker)cl).Value.ToShortDateString();
                    }
                    if (cl.GetType() == typeof(ComboBox) || cl.GetType() == typeof(EF.EFComboBox))
                    {
                        
                        if (((ComboBox)cl).SelectedItem != null)
                        {
                            if (((EF.EFComboBox)cl).SelectedItem.GetType() == typeof(DataRowView))
                            {
                                DataRowView rv = (DataRowView)((EF.EFComboBox)cl).SelectedItem;
                                row[i] = rv[sdata.Columns[i].ColumnName];
                            }
                            else
                            {
                                row[i] = ((EF.EFComboBox)cl).SelectedIndex;
                            }
                        }


                    }
                }

            }
            if (sdata.Rows.Count == 0)
            {
                sdata.Rows.Add(row);
            }
            else
            {
                //row = sdata.Rows[0];
            }
            
            //return datatable;
        }
        /// <summary>
        /// 从界面中提取数据并保存到DataTabel中
        /// </summary>
        /// <param name="frm">需要提取的界面</param>
        /// <param name="noField">不需要的控件名称列表</param>
        /// <returns>返回DataTable</returns>
        public DataTable getDataFrom(System.Windows.Forms.Form frm, String noField)
        {
            DataTable datatable = new DataTable();
            String[] nclnames = noField.Split(',');
            //枚举需要提取的数据
            
            foreach (Control cl in frm.Controls)
            {
                foreachColtrol(ref datatable, cl, noField);
            }
            DataRow row = datatable.NewRow();
            for (int i = 0; i < datatable.Columns.Count;i++ )
            {
                Control cl = FindControl(datatable.Columns[i].ColumnName, frm);


                if (cl.GetType() == typeof(TextBox) || cl.GetType() == typeof(EF.EFTextBox) )
                    {
                        row[cl.Name] = cl.Text;
                    }
                if (cl.GetType() == typeof(EF.EFLabelText))
                {
                    EFLabelText ltxt = (EFLabelText)cl;
                    row[cl.Name] = ltxt.EFEnterText;
                }
                if (cl.GetType() == typeof(EF.EFDateTimePicker) )
                    {
                        String tim = ((EF.EFDateTimePicker)cl).Value.ToShortDateString();
                        row[cl.Name] = ((EF.EFDateTimePicker)cl).Value.ToShortDateString();
                    }
                if (cl.GetType() == typeof(EF.EFDateTimePicker2))
                {
                    String tim = ((EF.EFDateTimePicker2)cl).Value.ToShortDateString();
                    row[cl.Name] = ((EF.EFDateTimePicker2)cl).Value.ToShortDateString();
                }
                    if (cl.GetType() == typeof(EF.EFComboBox))
                    {
                        if (((EF.EFComboBox)cl).SelectedItem != null)
                        {
                            if (((EF.EFComboBox)cl).SelectedItem.GetType() == typeof(DataRowView))
                            {
                                DataRowView rv = (DataRowView)((EF.EFComboBox)cl).SelectedItem;
                                row[cl.Name] = rv[datatable.Columns[i].ColumnName];
                            }
                            else
                            {
                                row[cl.Name] = ((EF.EFComboBox)cl).SelectedIndex;
                            }
                        }
                        
                        
                    }
                
            }
            datatable.Rows.Add(row);
            return datatable;
        }
        /// <summary>
        /// 将数据填写到DataGridView中
        /// </summary>
        /// <param name="dt">数据</param>
        /// <param name="grid">需要填充的DataGridView</param>
        /// <returns>返回结果</returns>
        public Boolean FillDataGridView(DataTable dt, ref  EF.EFDevGrid grid)
        {
            grid.DataSource = dt;
            grid.Refresh();
            return false;
        }
        /// <summary>
        /// 填写数据到Combox中；利用SQL语句查询到数据并填写到Combox中。
        /// </summary>
        /// <returns></returns>
        public Boolean FillComboxData(DataTable sdata,Formbase frm)
        {
            //ComboxID==ID ， SQL，Value，text
            for (int i = 0; i < sdata.Rows.Count; i++)
            {
                DataRow row = sdata.Rows[i];
                Control[] cls=frm.Controls.Find(row["ID"].ToString(),true);
                if (cls.Length> 0)
                {
                    Control cl = cls[0];
                }
            }
            return false;
        }

        /// <summary>
        /// 利用SQL语句，将结果绑定到Combox中
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="valueID"></param>
        /// <param name="TextID"></param>
        /// <param name="cmb"></param>
        /// <returns></returns>
        public Boolean FillComboxData(DataTable data , String valueID ,String TextID,ref EF.EFComboBox cmb)
        {
           
            //数据填写到Combox中
           // cmb.Items.Clear();
            cmb.DataSource = data;
            cmb.DisplayMember = TextID;//显示名称
            cmb.ValueMember = valueID;//值域
                return false;
        }
        public Boolean FillfrmData2(DataTable data, ref Formbase frm,String noFill)
        {
            if (data.Rows.Count == 0)
                return false;
            DataRow row = data.Rows[0];
            clsFrmBase fbase = new clsFrmBase();
            String vnofill = " " + noFill + ",";
            for (int i = 0; i < data.Columns.Count;i++ )
            {
                if (vnofill.IndexOf(data.Columns[i].ColumnName) >=0)
                {

                }
                else
                {
                    Control cl = fbase.FindControl(data.Columns[i].ColumnName, ref frm);
                    if (cl == null)
                    {
                    }
                    else
                    {
                        if (cl.GetType()==typeof(YutouCSharpNameSpace.TNS_YutouControlLED.TC_SevenSegmentLED))
                        {
                            if (((YutouCSharpNameSpace.TNS_YutouControlLED.TC_SevenSegmentLED)cl).TP_ClockStyle == YutouCSharpNameSpace.TNS_YutouControlLED.Enum_LEDClockStyle.NotClockShow)
                            {
                                ((YutouCSharpNameSpace.TNS_YutouControlLED.TC_SevenSegmentLED)cl).TP_Doub_Number =Convert.ToDouble( row[i].ToString());
                            }
                            if (((YutouCSharpNameSpace.TNS_YutouControlLED.TC_SevenSegmentLED)cl).TP_ClockStyle == YutouCSharpNameSpace.TNS_YutouControlLED.Enum_LEDClockStyle.TimeOnlyShow)
                            {
                                ((YutouCSharpNameSpace.TNS_YutouControlLED.TC_SevenSegmentLED)cl).TP_DateTime = Convert.ToDateTime(row[i].ToString());
                            }
                        }

                        if (cl.GetType() == typeof(EF.EFLabelText))
                        {
                            EFLabelText ltxt=(EFLabelText)cl;
                            ltxt.EFEnterText = row[i].ToString();
                        }

                        if (cl.GetType() == typeof(TextBox) || cl.GetType() == typeof(EF.EFTextBox) )
                        {
                           
                          
                            cl.Text = row[i].ToString();
                        }
                        if (cl.GetType() == typeof(Label))
                        {
                            cl.Text = row[i].ToString();
                        }
                        if (cl.GetType() == typeof(ComboBox) || cl.GetType() == typeof(EF.EFComboBox))
                        {
                            //((EFComboBox)cl) SelectedIndex = Convert.ToInt32(row[i]);
                            ((ComboBox)cl).SelectedIndex = Convert.ToInt32(row[i]);

                        }
                        if (cl.GetType() == typeof(System.Windows.Forms.DateTimePicker) || cl.GetType() == typeof(EF.EFDateTimePicker))
                        {
                            if (cl.GetType() == typeof(System.Windows.Forms.DateTimePicker))
                            {
                            if (Convert.IsDBNull(row[i]))
                                ((System.Windows.Forms.DateTimePicker)cl).Value = DateTime.Now;
                            else
                                ((System.Windows.Forms.DateTimePicker)cl).Value = Convert.ToDateTime(row[i].ToString());
                            }
                            if (cl.GetType() == typeof(EF.EFDateTimePicker))
                            {
                                if (Convert.IsDBNull(row[i]))
                                    ((EF.EFDateTimePicker)cl).Value = DateTime.Now;
                                else
                                    ((EF.EFDateTimePicker)cl).Value = Convert.ToDateTime(row[i].ToString());
                            }

                        }
                    }
                }
                
            }

            return false;
        }
        /// <summary>
        /// 将数据填写到界面的控件，主要支持的控件textbox , label,datetimepick
        /// </summary>
        /// <param name="data">数据包</param>
        /// <param name="frm">界面</param>
        /// <returns></returns>
        public Boolean FillfrmData(DataRow data, ref Formbase frm)
        {

            for (int i = 0; i < frm.Controls.Count; i++)
            {
                Control cl = frm.Controls[i];
                foreachColtrolFillData(data, cl);
            }

            return false;
        }
        /// <summary>
        /// 遍历TreeView 得到指定的Node节点
        /// 
        /// </summary>
        /// <returns></returns>
        public TreeNode FindTreeNodeByKey(String key, TreeNode tnParent)
        {
            
            if (tnParent == null)
                return null;
            if (tnParent.Name == key)
                return tnParent;
            TreeNode tnRet = null;
            foreach (TreeNode tn in tnParent.Nodes)
            {
                tnRet = FindTreeNodeByKey(key, tn);
                if (tnRet != null)
                    break;
            }
            return tnRet;
           
        }


        public Boolean DevGridView_bingLookUp_ShowEditor(ref object sender, EventArgs e ,String filter)
        {
            DevExpress.XtraGrid.Views.Grid.GridView v = (GridView)sender;
            if (v.ActiveEditor != null && v.ActiveEditor.GetType() == typeof(DevExpress.XtraEditors.LookUpEdit))
            {
                DevExpress.XtraEditors.LookUpEdit editor = (DevExpress.XtraEditors.LookUpEdit)v.ActiveEditor;
             
                ((DataTable)editor.Properties.DataSource).DefaultView.RowFilter = filter;
            }
            return true;

        }
        public void DevGridView_bingLookUp(ref RepositoryItemLookUpEdit vedit,DataTable dt)
        {
            Common.Utility.JNBindCodeValueToRepositoryItemLookUpEdit(dt, vedit);
        }

        /// <summary>
        /// 将数据填写到界面的控件，主要支持的控件textbox , label,datetimepick
        /// </summary>
        /// <param name="data">数据包</param>
        /// <param name="frm">界面</param>
        /// <returns></returns>
        public Boolean FillfrmData(DataTable data,ref Formbase frm)
        {

            for (int i = 0; i < frm.Controls.Count; i++)
            {
                Control cl = frm.Controls[i];
                foreachColtrolFillData(data, cl);
            }

                return false;
        }

        /// <summary>
        /// 将xml转DataTable
        /// </summary>
        /// <param name="xmlData"></param>
        /// <returns></returns>
        private DataTable ConvertXMLToDataTable(string xmlData)
        {
            StringReader stream = null;
            XmlTextReader reader = null;
            try
            {
                DataSet xmlDS = new DataSet();
                stream = new StringReader(xmlData);//读取字符串中的信息
                reader = new XmlTextReader(stream);//获取stream中的数据
                xmlDS.ReadXml(reader);//DataSet获取Xmlrdr中的数据
                return xmlDS.Tables[0];
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }
        /// <summary>
        /// 将DataTable转xml
        /// </summary>
        /// <param name="xmlDT"></param>
        /// <returns></returns>
        private string ConvertDataTableToXML(DataTable xmlDT)
        {
            MemoryStream stream = null;
            XmlTextWriter writer = null;
            try
            {
                stream = new MemoryStream();
                writer = new XmlTextWriter(stream, Encoding.Default);//根据stream实例化writer
                xmlDT.TableName = "dt";
                xmlDT.WriteXml(writer);//获取DataTable中的数据
                int count = (int)stream.Length;
                byte[] arr = new byte[count];
                stream.Seek(0, SeekOrigin.Begin);
                stream.Read(arr, 0, count);
                return Encoding.GetEncoding("gb2312").GetString(arr).Trim();//解决中文乱码问题
                //UTF8Encoding utf = new UTF8Encoding();
                //return utf.GetString(arr).Trim();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }
    }
}
