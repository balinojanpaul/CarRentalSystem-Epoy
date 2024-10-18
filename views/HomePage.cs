using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarRentalSystem2.Common;
using CarRentalSystem2.Handlers.CommandHandlers;
using CarRentalSystem2.Handlers.QueryHandlers;
using CarRentalSystem2.Models;
using LiveCharts;
using LiveCharts.Wpf;

namespace CarRentalSystem2.Views
{
    public partial class HomePage : Form
    {
        private AnalyticsCommandHandler _analyticsCommandHandler;
        private AnalyticsQueryHandler _analyticsQueryHandler;

        public HomePage()
        {
            InitializeComponent();
            _analyticsCommandHandler = new AnalyticsCommandHandler(Commons.ConnectionString);
            _analyticsQueryHandler = new AnalyticsQueryHandler(Commons.ConnectionString);
        }

        private void LoadStatistics()
        {
            // Get the filter from the combo box first
            string storedProcedure = "GetMonthlySalesAndCustomerAnalytics";

            Analytics analyticsList = _analyticsQueryHandler.GetSalesAndCustomerAnalytics(storedProcedure);

            // Prepare data for LiveCharts
            var totalPaymentSeries = new LineSeries
            {
                Title = "Total Payment",
                Values = new ChartValues<decimal> { analyticsList.TotalSales }
            };

            var customerCountSeries = new LineSeries
            {
                Title = "Customer Count",
                Values = new ChartValues<int>{analyticsList.CustomerCount}
            };
            
            // Clear existing series and add new data to the chart
            cartesianChart1.Series.Clear();
            cartesianChart1.Series.Add(totalPaymentSeries);
            cartesianChart2.Series.Clear();
            cartesianChart2.Series.Add(customerCountSeries);
            
            // Set the X-axis labels (dates)
            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Date",
                LabelFormatter = value => new DateTime((long)value).ToString("MM/dd/yyyy"),
                MinValue = analyticsList.Date.Ticks,
                MaxValue = analyticsList.Date.Ticks
                // Labels = analyticsList.TotalSales.ToString().ToArray();
            });
            
            // Set up the Y-axis for the amount and count
            cartesianChart1.AxisY.Clear();
            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Amount / Count"
            });
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            LoadStatistics();
        }
    }
}