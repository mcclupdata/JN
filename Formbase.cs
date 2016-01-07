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
using DevExpress.XtraGrid.Views;
namespace MC
{
    public partial class Formbase : EFForm
    {
        EFButtonBar _bar;
        int _DebugFlage = 0;//独立调试模式，1 PMS模式
         protected _MyClient _wcfClient = new _MyClient();
        
         //protected DataTable _del_data = new DataTable();
        protected struct del_data_stu
        {
            public String TableName;
            public DataTable del_data;
        }
        protected List<del_data_stu> _del_data_lst=new List<del_data_stu>();

        public Formbase()
        {
            
           
            InitializeComponent();
            Control[] cos = this.Controls.Find("Fn", true);
            if (cos.Length > 0)
            {
                _bar = (EFButtonBar)cos[0];
             //   bar.SendToBack();
            //    bar.Dock = DockStyle.Bottom;

            }
        }

        private void Formbase_Load(object sender, EventArgs e)
        {
            _bar.SendToBack();
            _bar.Dock = DockStyle.Bottom;
            //_del_data.Columns.Add("FID", typeof(long));
            //注册所有F键
            this.EF_DO_F1 += new EFButtonBar.EFDoFnEventHandler(Formbase_EF_DO);
            this.EF_DO_F2 += new EFButtonBar.EFDoFnEventHandler(Formbase_EF_DO);
            this.EF_DO_F3 += new EFButtonBar.EFDoFnEventHandler(Formbase_EF_DO);
            this.EF_DO_F4 += new EFButtonBar.EFDoFnEventHandler(Formbase_EF_DO);
            this.EF_DO_F5 += new EFButtonBar.EFDoFnEventHandler(Formbase_EF_DO);
            this.EF_DO_F6 += new EFButtonBar.EFDoFnEventHandler(Formbase_EF_DO);
            this.EF_DO_F7 += new EFButtonBar.EFDoFnEventHandler(Formbase_EF_DO);
            this.EF_DO_F8 += new EFButtonBar.EFDoFnEventHandler(Formbase_EF_DO);
            this.EF_DO_F9 += new EFButtonBar.EFDoFnEventHandler(Formbase_EF_DO);

            //查找所有But，并隐藏，在非独立调试模式下
            if (_DebugFlage != 0)
            {
                for (int k = 0; k < this.Controls.Count; k++)
                {
                    Control cl = this.Controls[k];
                    //if (cl.GetType() == typeof(EF.EFButton))
                    //{
                    //    cl.Visible = false;

                    //}
                    Control cl2 = HideEFButton(cl);
                }
            }
            DevExpress.XtraGrid.Views.Grid.GridView v;
            for (int k = 0; k < this.Controls.Count; k++)
            {
                Control cl = this.Controls[k];
                Control ncl = FindGridViewandAutoWi(cl);

                if (ncl != null)
                {
                    //v = (DevExpress.XtraGrid.Views.Grid.GridView)ncl;
                    break;
                }
            }
            //将GridView行宽设为自动

          
        }
        protected Control HideEFButton(Control cl)
        {
            if (cl == null)
                return null;
            if (cl.GetType() == typeof(EF.EFButton))
            {
                //((DevExpress.XtraGrid.Views.Grid.GridView)cl).OptionsView.ColumnAutoWidth = true;
                cl.Visible = false;
                return cl;
            }
            else
            {
                if (cl.Controls.Count > 0)
                {
                    foreach (Control ncl in cl.Controls)
                    {
                        Control rtcl = HideEFButton(ncl);
                        //if (rtcl == null)
                        //{
                        //    return null;
                        //}
                        //else
                        //{
                        //    return rtcl;
                        //}
                    }

                }
                else
                {
                    return null;
                }
                return null;

            }
        }
        public Control FindGridViewandAutoWi(Control cl)
        {
            if (cl == null)
                return null;
            if (cl.GetType() == typeof(EF.EFDevGrid))
            {
                //((DevExpress.XtraGrid.Views.Grid.GridView)cl).OptionsView.ColumnAutoWidth = true;
                EF.EFDevGrid dg = (EF.EFDevGrid)cl;
                dg.DataSourceChanged += new EventHandler(dg_DataSourceChanged);
                for (int k = 0; k < dg.Views.Count; k++)
                {
                   // ((DevExpress.XtraGrid.Views.Grid.GridView)dg.Views[k]).OptionsView.ColumnAutoWidth = true;
                   // ((DevExpress.XtraGrid.Views.Grid.GridView)dg.Views[k]).OptionsView.
                }
                return cl;
            }
            else
            {
                if (cl.Controls.Count > 0)
                {
                    foreach (Control ncl in cl.Controls)
                    {
                        Control rtcl = FindGridViewandAutoWi(ncl);
                        //if (rtcl == null)
                        //{
                        //    return null;
                        //}
                        //else
                        //{
                        //    return rtcl;
                        //}
                    }
                   
                }
                else
                {
                    return null;
                }
                return null;
            }

        }

        void dg_DataSourceChanged(object sender, EventArgs e)
        {
            EFDevGrid EFG=(EFDevGrid)sender;
            for (int i = 0; i < EFG.Views.Count; i++)
            {
                ((DevExpress.XtraGrid.Views.Grid.GridView)EFG.Views[i]).BestFitColumns();
            }
        }


        void Formbase_EF_DO(object sender, EF_Args e)
        {
           // clsFrmBase frm = new clsFrmBase();
            String butText="";
            int butnow = ((EF.EFButtonBar)sender).EFArgs.buttonNow;
            //for (int i = 0; i < 11; i++)
            //{
            if (e.b_info[butnow].Status == EF.EFButtonKeysStatus.ACTIVE)
                {
                    butText = e.b_info[butnow].Text;
                    //i = 11;
                }
            //}
            if (butText.Length == 0)
                return;
            EF.EFButton but=null;
            //this.Controls.Find("", true);
            //    for (int k = 0; k < this.Controls.Count; k++)
            //    {
            //        Control cl = this.Controls[k];
            //        foreach (Control c in cl.Controls)
            //        {
            //            if (cl.GetType() == typeof(EF.EFButton))
            //            {
            //                String sname = cl.Text;
            //                if (sname == butText)
            //                {
            //                    but = (EF.EFButton)cl;

            //                }

            //            }
            //        }
            //    }
            clsfrmData _vcls = new clsfrmData();
            for (int k=0;k<this.Controls.Count;k++)
            {
                Control cl = this.Controls[k];
                Control ncl=_vcls.foreachColtrolByName(butText, cl);
                
                if (ncl != null)
                {
                    but = (EF.EFButton)ncl;
                    break;
                }
            }
                if (but != null)
                {
                    //发送but的click事件；
                    //触发点击事件
                    but.PerformClick();
                }
           
            //throw new NotImplementedException();
        }
        /// <summary>
        /// 获取删除数据
        /// </summary>
        /// <param name="dgname"></param>
        /// <returns></returns>
        protected DataTable getDelData(String dgname)
        {
            for (int k = 0; k < _del_data_lst.Count; k++)
            {
                del_data_stu stu = _del_data_lst[k];
                if (stu.TableName == dgname)
                {
                   return stu.del_data;
                }
            }
            return null;
        }
        /// <summary>
        /// 清楚记录的删除数据
        /// </summary>
        /// <returns></returns>
        protected Boolean CleanDelData()
        {
            _del_data_lst.Clear();
            return false;
        }
        protected void dataGrid_EF_GridBar_Remove_Event(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            int i = 0;
            DevExpress.XtraGrid.GridControlNavigator na = (DevExpress.XtraGrid.GridControlNavigator)sender;
            object pa = na.Parent;
            EF.EFDevGrid dGrid = (EF.EFDevGrid)pa;
            DevExpress.XtraGrid.Views.Grid.GridView view = (DevExpress.XtraGrid.Views.Grid.GridView)dGrid.Views[0];
            int rindex = view.FocusedRowHandle;
            long vfid = Convert.ToInt64(view.GetRowCellValue(rindex, "FID"));
            String dgname=dGrid.Name;
            DataTable dt=null;
            for (int k = 0; k < _del_data_lst.Count; k++)
            {
                del_data_stu stu = _del_data_lst[k];
                if (stu.TableName == dgname)
                {
                    dt = stu.del_data;
                }
            }
            if (dt == null)
            {
                dt = new DataTable(dgname); dt.Columns.Add("FID", typeof(long));
                del_data_stu nstu = new del_data_stu();
                nstu.TableName = dgname;
                nstu.del_data = dt;
                _del_data_lst.Add(nstu);
            }
            dt.Rows.Add(vfid);

            view.DeleteSelectedRows();

        }

        private void efButton1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
