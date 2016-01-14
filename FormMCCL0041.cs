using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
namespace MC
{
    public partial class FormMCCL0041 : MC.Formbase
    {
        clsEvaWelders _cls = new clsEvaWelders();
        DataTable _alldt;
        public FormMCCL0041()
        {
            InitializeComponent();
        }

        private void FormMCCL0041_Load(object sender, EventArgs e)
        {

            _alldt = _cls.getAllWeldType();
            //SHIP_NO;
            DataView v = _alldt.Copy().DefaultView;
            DataTable shipno_dt = v.ToTable(true,"SHIP_NO");
           
            this.luSHIP_NO.Properties.DataSource = shipno_dt;
            this.luSHIP_NO.Properties.DisplayMember = "SHIP_NO";
            this.luSHIP_NO.Properties.ValueMember = "SHIP_NO";
            
        }

        private void luSHIP_NO_EditValueChanged(object sender, EventArgs e)
        {
            String ship_no = this.luSHIP_NO.EditValue.ToString();
            
            //SHIP_NO;
            DataView v = _alldt.Copy().DefaultView;
            v.RowFilter = "SHIP_NO='" + ship_no + "'";
            DataTable dt = v.ToTable(true,"BUFF1");
            dt.Rows.Add("*");
            dt.DefaultView.Sort = "BUFF1";
            this.luBUFF1.Properties.DataSource = dt;
            this.luBUFF1.Properties.DisplayMember = "BUFF1";
            this.luBUFF1.Properties.ValueMember = "BUFF1";
        }

        private void luTREENAME_EditValueChanged(object sender, EventArgs e)
        {
            String buff1 = this.luBUFF1.EditValue.ToString();
            String treename = this.luTREENAME.EditValue.ToString();
            if (treename == "*" || treename.Length==0)
                return;
            String ship_no = this.luSHIP_NO.EditValue.ToString();
            DataView v = _alldt.Copy().DefaultView;
            v.RowFilter = "SHIP_NO='" + ship_no + "' and BUFF1='" + buff1 + "' and TREE_NAME='"+treename+"'";
            DataTable dt = v.ToTable(true, "AS3");
            dt.Rows.Add("*");
            v.Sort = "AS3";
            this.luAS3.Properties.DataSource = dt;
            this.luAS3.Properties.DisplayMember = "AS3";
            this.luAS3.Properties.ValueMember = "AS3";
        }

        private void luBUFF1_EditValueChanged(object sender, EventArgs e)
        {
            String buff1 = this.luBUFF1.EditValue.ToString();
            if (buff1 == "*" || buff1.Length==0)
                return;
            String ship_no = this.luSHIP_NO.EditValue.ToString();
            DataView v = _alldt.Copy().DefaultView;
            v.RowFilter = "SHIP_NO='" + ship_no + "' and BUFF1='" + buff1 + "'";
            DataTable dt = v.ToTable(true, "TREE_NAME");
            dt.Rows.Add("*");
            v.Sort = "TREE_NAME";
            this.luTREENAME.Properties.DataSource = dt;
            this.luTREENAME.Properties.DisplayMember = "TREE_NAME";
            this.luTREENAME.Properties.ValueMember = "TREE_NAME";
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            String shipno, buff1, treename, as3;
            shipno = luSHIP_NO.EditValue.ToString();
            buff1 = luBUFF1.EditValue.ToString();
            treename = luTREENAME.EditValue.ToString();
            as3 = luAS3.EditValue.ToString();
            if (shipno == "*" || shipno=="")
                shipno = "%%";
            if (buff1 == "*" || buff1 =="")
                buff1 = "%%";
            if (treename == "*" || treename == "")
                treename = "%%";
            if (as3 == "*" || as3 =="")
                as3 = "%%";
            DataTable dt = _cls.getEvaluationrpt_Welds(shipno, buff1, as3, treename);
            this.weldsdataGrid.DataSource = dt;
            if (dt.Rows.Count>0)
            {
                int[] dataint=new int[4];
                dataint[0]=Convert.ToInt32(this.weldsGridView.GetRowCellValue(0,"L1"));
                dataint[1]=Convert.ToInt32(this.weldsGridView.GetRowCellValue(0,"L2"));
                dataint[2]=Convert.ToInt32(this.weldsGridView.GetRowCellValue(0,"L3"));
                dataint[3]=Convert.ToInt32(this.weldsGridView.GetRowCellValue(0,"L4"));
                InitZed(dataint);
            }
        }
        private void InitZed(int[] data)
        {
            GraphPane myPane = zgc.GraphPane;
            myPane.GraphObjList.Clear();
            myPane.CurveList.Clear();
            zgc.AxisChange();
            // Set the GraphPane title
            myPane.Title.Text = "分值比例";
            myPane.Title.FontSpec.IsItalic = true;
            myPane.Title.FontSpec.Size = 24f;
            myPane.Title.FontSpec.Family = "Times New Roman";

            // Fill the pane background with a color gradient
            myPane.Fill = new Fill(Color.White, Color.Goldenrod, 45.0f);
            // No fill for the chart background
            myPane.Chart.Fill.Type = FillType.None;

            // Set the legend to an arbitrary location
            myPane.Legend.Position = LegendPos.Float;
            myPane.Legend.Location = new Location(0.98f, 0.15f, CoordType.PaneFraction, AlignH.Right, AlignV.Top);
            myPane.Legend.FontSpec.Size = 10f;
            myPane.Legend.IsHStack = false;
            Random rand = new Random();

            // Add some pie slices
            PieItem segment1 = myPane.AddPieSlice(Convert.ToInt32(data[0]), Color.Navy, Color.White, -135f, 0, "[0-59]");
            PieItem segment3 = myPane.AddPieSlice(Convert.ToInt32(data[2]), Color.Purple, Color.White, -135f, 0, "[80-89]");
            PieItem segment4 = myPane.AddPieSlice(Convert.ToInt32(data[3]), Color.LimeGreen, Color.White, -135f, 0, "90-100");
            PieItem segment2 = myPane.AddPieSlice(Convert.ToInt32(data[1]), Color.SandyBrown, Color.White, -135f, 0, "[60-79]");
            ;

            segment2.LabelDetail.FontSpec.FontColor = Color.Red;

            // Sum up the pie values                                                               
            CurveList curves = myPane.CurveList;
            double total = 0;
            for (int x = 0; x < curves.Count; x++)
                total += ((PieItem)curves[x]).Value;

            // Make a text label to highlight the total value
            //TextObj text = new TextObj("Total \n" + "$" + total.ToString() + "M", 0.13F, 0.20F, CoordType.PaneFraction);
            //text.Location.AlignH = AlignH.Center;
            //text.Location.AlignV = AlignV.Bottom;
            //text.FontSpec.Border.IsVisible = false;
            //text.FontSpec.Fill = new Fill(Color.White, Color.FromArgb(255, 100, 100), 45F);
            //text.FontSpec.StringAlignment = StringAlignment.Center;
            //myPane.GraphObjList.Add(text);

            //// Create a drop shadow for the total value text item
            //TextObj text2 = new TextObj(text);
            //text2.FontSpec.Fill = new Fill(Color.Black);
            //text2.Location.X += 0.008f;
            //text2.Location.Y += 0.01f;
            //myPane.GraphObjList.Add(text2);

            // Calculate the Axis Scale Ranges
            zgc.AxisChange();
            zgc.Refresh();

        }

        private void weldsGridView_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
              int[] dataint=new int[4];
                dataint[0]=Convert.ToInt32(this.weldsGridView.GetRowCellValue(e.RowHandle,"L1"));
                dataint[1]=Convert.ToInt32(this.weldsGridView.GetRowCellValue(e.RowHandle,"L2"));
                dataint[2]=Convert.ToInt32(this.weldsGridView.GetRowCellValue(e.RowHandle,"L3"));
                dataint[3]=Convert.ToInt32(this.weldsGridView.GetRowCellValue(e.RowHandle,"L4"));
                InitZed(dataint);
        }
    }
}
