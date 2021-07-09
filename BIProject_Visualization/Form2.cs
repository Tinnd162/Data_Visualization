using BIProject_Visualization.AppCode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BIProject_Visualization
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            cbbCategory.DataSource = ComboboxDAL.GetState();
            cbbCategory.DisplayMember = "_State";

            cbbYear.Items.Add(2017);
            cbbYear.Items.Add(2018);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var objChart = chartCol.ChartAreas[0];
            objChart.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            //month 1 -12
            objChart.AxisX.Minimum = 0;
            objChart.AxisX.Maximum = 13;

            objChart.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            objChart.AxisY.Minimum = 0;
            objChart.AxisY.Maximum = 4000;
            int max = 0;

            chartCol.Series.Clear();
            Random random = new Random();
            var year = int.Parse(cbbYear.SelectedItem.ToString());
            var category = cbbCategory.Text;
            var data = ReviewDAL.TotalCustomerperMonth(year, category);

            string total = "Số lượng khách hàng";
            chartCol.Series.Add(total);
            chartCol.Series[total].Color = Color.DodgerBlue;
            chartCol.Series[total].Legend = "Legend1";
            chartCol.Series[total].ChartArea = "ChartArea1";
            chartCol.Series[total].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chartCol.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = 0;
            chartCol.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineWidth = 0;
            int i = 1;
            foreach (DataRow item in data.Rows)
            {
                chartCol.Series[total].Points.AddXY(i, item["CountCustomer"]);
                if (int.Parse(item["CountCustomer"].ToString()) > max) { max = int.Parse(item["CountCustomer"].ToString()); }
                i++;
            }
            if (max < 10)
            {
                max += 1;
            }
            else if (max < 50)
            {
                max += 5;
            }
            else if (max < 100)
            {
                max += 10;
            }
            else if (max < 250)
            {
                max += 15;
            }
            else
            {
                max += 50;
            }
            objChart.AxisY.Maximum = max;
            objChart.AxisY.Title = "Số lượng";
            objChart.AxisX.Title = "Tháng";


            //-----PIE-------------------------------------------------
            chartPie.Series.Clear();

            chartPie.Series.Add(total);
            chartPie.Series[total].Legend = "Legend1";
            chartPie.Series[total].ChartArea = "ChartArea1";
            chartPie.Series[total].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;

            foreach (DataRow item in data.Rows)
            {
                chartPie.Series[total].Points.AddXY(item["Month"], item["CountCustomer"]);
            }
            foreach (DataPoint p in chartCol.Series[total].Points)
            {
                p.Label = "#PERCENT";
            }
        }
    }
}
