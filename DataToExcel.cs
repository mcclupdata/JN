using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using Microsoft.Office.Interop.Excel;
using System.Reflection;


using System.Windows.Forms;namespace MC
{
    class DataToExcel
    {
        public string toexcel(System.Data.DataTable dt, int titleRowCount,string title,string sheetname,int a)
        {
            string s = Assembly.GetExecutingAssembly().CodeBase;
            string[] ss = s.Split('/');
            string n = "";
            for (int i = 3; i < ss.Length - 1; i++)
            {
                n += ss[i] + '/'; 
            }
            String fileName =  n + "Book.xlsm";
            string saveFileName = "";
            //bool fileSaved = false;
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = "xls";
            saveDialog.Filter = "Excel文件|*.xls";
            saveDialog.FileName = "";
            saveDialog.ShowDialog();
            saveFileName = saveDialog.FileName;
            if (saveFileName.IndexOf(":") < 0) return null; //被点了取消 
            Microsoft.Office.Interop.Excel.Application xlApp = null;
            try
            {
                xlApp = new Microsoft.Office.Interop.Excel.Application();


            }
            catch (Exception)
            {
                MessageBox.Show("无法创建Excel对象，可能您的机子未安装Excel");
                return null;
            }
            finally
            {
            }
            Object oMissing = System.Reflection.Missing.Value;
            //打开Excel文件
            Microsoft.Office.Interop.Excel.Workbook workbook = xlApp.Application.Workbooks.Open(fileName, 2, false, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing);
            ;
            //Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[a];//取得sheet1
            worksheet.Name = sheetname;
            //写Title
            if (titleRowCount != 0)
                MergeCells(worksheet, 1, 1, titleRowCount, dt.Columns.Count, title);

            //写入列标题
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                worksheet.Cells[2, i + 1] = dt.Columns[i].ColumnName;

            }
            //写入数值
            for (int r = 0; r < dt.Rows.Count; r++)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    worksheet.Cells[r + 3, i + 1] = dt.Rows[r][i].ToString();
                }
                System.Windows.Forms.Application.DoEvents();
            }
            //worksheet.Cells[10, 6] = "测试数据";
            worksheet.Columns.EntireColumn.AutoFit();//列宽自适应
            //if (Microsoft.Office.Interop.cmbxType.Text != "Notification")
            //{
            //    Excel.Range rg = worksheet.get_Range(worksheet.Cells[2, 2], worksheet.Cells[ds.Tables[0].Rows.Count + 1, 2]);
            //    rg.NumberFormat = "00000000";
            //}

            if (saveFileName != "")
            {
                try
                {
                    workbook.Saved = true;
                    workbook.SaveCopyAs(saveFileName);
                    //fileSaved = true;
                }
                catch (Exception ex)
                {
                    //fileSaved = false;
                    MessageBox.Show("导出文件时出错,文件可能正被打开！n" + ex.Message);
                    return null;
                }

            }
            //else
            //{
            //    fileSaved = false;
            //}
            xlApp.Quit();
            GC.Collect();//强行销毁 
            // if (fileSaved && System.IO.File.Exists(saveFileName)) System.Diagnostics.Process.Start(saveFileName); //打开EXCEL
            MessageBox.Show(saveFileName + "导出到Excel成功", "提示", MessageBoxButtons.OK);
            return saveFileName;
        }

        public void MergeCells(Microsoft.Office.Interop.Excel.Worksheet workSheet, int beginRowIndex, int beginColumnIndex, int endRowIndex, int endColumnIndex, string text)
        {
            Microsoft.Office.Interop.Excel.Range range = workSheet.get_Range(workSheet.Cells[beginRowIndex, beginColumnIndex], workSheet.Cells[endRowIndex, endColumnIndex]);

            range.ClearContents();  //先把Range内容清除，合并才不会出错   
            range.MergeCells = true;
            range.Value2 = text;
            range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
        } 
          /// <summary>
         /// 执行Excel中的宏
         /// </summary>
         /// <param name="excelFilePath">Excel文件路径</param>
         /// <param name="macroName">宏名称</param>
         /// <param name="parameters">宏参数组</param>
         /// <param name="rtnValue">宏返回值</param>
         /// <param name="isShowExcel">执行时是否显示Excel</param>
         public void RunExcelMacro(
                                             string excelFilePath,
                                             string macroName,
                                             object[] parameters,
                                             out object rtnValue,
                                             bool isShowExcel
                                         )
         {
             try
             {
                 #region 检查入参
 
                 // 检查文件是否存在
                 if (!File.Exists(excelFilePath))
                 {
                     throw new System.Exception(excelFilePath + " 文件不存在");
                 }
 
                 // 检查是否输入宏名称
                 if (string.IsNullOrEmpty(macroName))
                 {
                     throw new System.Exception("请输入宏的名称");
                 }
 
                 #endregion
 
                 #region 调用宏处理
 
                 // 准备打开Excel文件时的缺省参数对象
                 object oMissing = System.Reflection.Missing.Value;
 
                 // 根据参数组是否为空，准备参数组对象
                 object[] paraObjects;
 
                 if (parameters == null)
                 {
                     paraObjects = new object[] { macroName };
                 }
                 else
                 {
                     // 宏参数组长度
                     int paraLength = parameters.Length;
 
                     paraObjects = new object[paraLength + 1];
 
                     paraObjects[0] = macroName;
                     for (int i = 0; i < paraLength; i++)
                     {
                         paraObjects[i + 1] = parameters[i];
                     }
                 }
 
                 // 创建Excel对象示例
                 ApplicationClass oExcel = new ApplicationClass();
 
                 // 判断是否要求执行时Excel可见
                 if (isShowExcel)
                 {
                     // 使创建的对象可见
                     oExcel.Visible = true;
                 }
 
                 // 创建Workbooks对象
                 Workbooks oBooks = oExcel.Workbooks;
 
                 // 创建Workbook对象
                 _Workbook oBook = null;
 
                 // 打开指定的Excel文件
                 oBook = oBooks.Open(
                                         excelFilePath,
                                         oMissing,
                                         oMissing,
                                         oMissing,
                                         oMissing,
                                         oMissing,
                                         oMissing,
                                         oMissing,
                                         oMissing,
                                         oMissing,
                                         oMissing,
                                         oMissing,
                                         oMissing,
                                         oMissing,
                                         oMissing
                                    );
 
                 // 执行Excel中的宏
                 rtnValue = this.RunMacro(oExcel, paraObjects);
 
                 // 保存更改
                 oBook.Save();
 
                 // 退出Workbook
                 oBook.Close(false, oMissing, oMissing);
 
                 #endregion
 
                 #region 释放对象
 
                 // 释放Workbook对象
                 System.Runtime.InteropServices.Marshal.ReleaseComObject(oBook);
                 oBook = null;
 
                 // 释放Workbooks对象
                 System.Runtime.InteropServices.Marshal.ReleaseComObject(oBooks);
                 oBooks = null;
 
                 // 关闭Excel
                 oExcel.Quit();
 
                 // 释放Excel对象
                 System.Runtime.InteropServices.Marshal.ReleaseComObject(oExcel);
                 oExcel = null;
 
                 // 调用垃圾回收
                 GC.Collect();
 
                 #endregion
             }
             catch (Exception ex)
             {
                 throw ex;
             }
         }
 
         /// <summary>
         /// 执行宏
         /// </summary>
         /// <param name="oApp">Excel对象</param>
         /// <param name="oRunArgs">参数（第一个参数为指定宏名称，后面为指定宏的参数值）</param>
         /// <returns>宏返回值</returns>
         private object RunMacro(object oApp, object[] oRunArgs)
         {
             try
             {
                 // 声明一个返回对象
                 object objRtn;
                 
                 // 反射方式执行宏
                 objRtn = oApp.GetType().InvokeMember(
                                                         "Run",
                                                         System.Reflection.BindingFlags.Default |
                                                         System.Reflection.BindingFlags.InvokeMethod,
                                                         null,
                                                         oApp,
                                                         oRunArgs
                                                      );
 
                 // 返回值
                 return objRtn;
 
             }
             catch (Exception ex)
             {
                 // 如果有底层异常，抛出底层异常
                 if (ex.InnerException.Message.ToString().Length > 0)
                 {
                     throw ex.InnerException;
                 }
                 else
                 {
                     throw ex;
                 }
             }
         }

        
    }
}
