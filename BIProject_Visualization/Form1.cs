using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BIProject_Visualization.AppCode;

namespace BIProject_Visualization
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cbbCategory.DataSource = ComboboxDAL.GetCity();
            cbbCategory.DisplayMember = "City";
  
            cbbYear.Items.Add(2017);
            cbbYear.Items.Add(2018);
      
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var objChart = chart.ChartAreas[0];
            objChart.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            //month 1 -12
            objChart.AxisX.Minimum = 0;
            objChart.AxisX.Maximum = 13;

            objChart.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            objChart.AxisY.Minimum = 0;
            objChart.AxisY.Maximum = 140000;
            //float max = 0;

            //Clear
            chart.Series.Clear();
            Random random = new Random();
            var year = int.Parse(cbbYear.SelectedItem.ToString());
            var category = cbbCategory.Text;
            var data = ReviewDAL.RevenuePerMonth(year, category);

            //-------------line3--------------------------------------
            string TotalPro = "Doanh thu bán hàng";
            Random _random = new Random();
            chart.Series.Add(TotalPro);
            chart.Series[TotalPro].Color = Color.BlueViolet;
            chart.Series[TotalPro].Legend = "Legend1";
            chart.Series[TotalPro].ChartArea = "ChartArea1";
            chart.Series[TotalPro].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chart.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = 0;
            chart.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineWidth = 0;
            //adding data
            int i = 1;
            foreach (DataRow item in data.Rows)
            {
                chart.Series[TotalPro].Points.AddXY(i, item["Revenue"]);
                i++;
            }
        }

        private void chart_Click(object sender, EventArgs e)
        {

        }
    }
}
