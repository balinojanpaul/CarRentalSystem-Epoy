using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using CarRentalSystem2.Common;
using CarRentalSystem2.Handlers.CommandHandlers;
using CarRentalSystem2.Handlers.QueryHandlers;
using CarRentalSystem2.Models;
using LiveCharts;
using LiveCharts.Wpf;
using Color = System.Windows.Media.Color;

namespace CarRentalSystem2.Views
{
    public partial class HomePage : Form
    {
        private AnalyticsCommandHandler _analyticsCommandHandler;
        private AnalyticsQueryHandler _analyticsQueryHandler;
        private CarQueryHandler _carQueryHandler;

        public HomePage()
        {
            InitializeComponent();
            _analyticsCommandHandler = new AnalyticsCommandHandler(Commons.ConnectionString);
            _analyticsQueryHandler = new AnalyticsQueryHandler(Commons.ConnectionString);
            _carQueryHandler = new CarQueryHandler(Commons.ConnectionString);
        }

        private void LoadStatistics()
        {
            // Get the filter from the combo box first
            string storedProcedure = "GetMonthlySalesAndCustomerAnalytics";

            Analytics analyticsList = _analyticsQueryHandler.GetSalesAndCustomerAnalytics(storedProcedure);
            //MessageBox.Show($"Date: {analyticsList.Date}, Total Sales: {analyticsList.TotalSales}, Customer Count: {analyticsList.CustomerCount}");

            var date = analyticsList.Date;

            // Check if the current date is close to the minimum allowed date.
            DateTime minDate;
            if (date > DateTime.MinValue.AddDays(7))
            {
                minDate = date.AddDays(-7); // Subtract 7 days safely
            }
            else
            {
                minDate = DateTime.MinValue; // Use DateTime.MinValue if subtracting 7 days is not possible
            }

            // Add more data points for testing (replace with actual values)
            var totalPaymentData = new ChartValues<decimal> { 20000, 50000, 70000, analyticsList.TotalSales };
            var customerCountData = new ChartValues<int> { 10, analyticsList.CustomerCount }; // Keep customer count data

            // Create the series for Total Payment (with filled area under the line)
            var totalPaymentSeries = new LineSeries
            {
                Title = "Total Payment",
                Values = totalPaymentData,
                PointGeometry = DefaultGeometries.Circle, // Use circles for data points
                StrokeThickness = 3, // Thicker line
                Fill = new SolidColorBrush(Color.FromArgb(80, 255, 0, 0)), // Semi-transparent red fill
                Stroke = new SolidColorBrush(Color.FromRgb(255, 0, 0)), // Red line
                LineSmoothness = 0.3 // Smooth the line
            };

            // Create the series for Customer Count (as scatter points only)
            var customerCountSeries = new ScatterSeries
            {
                Title = "Customer Count",
                Values = customerCountData,
                PointGeometry = DefaultGeometries.Circle, // Use circles for points
                MinPointShapeDiameter = 10, // Minimum size of points
                MaxPointShapeDiameter = 10, // Maximum size of points
                Fill = new SolidColorBrush(Color.FromRgb(0, 0, 255)) // Blue color for the points
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
                LabelsRotation = 45, // Rotate labels to avoid overlapping
                LabelFormatter = value => new DateTime((long)value).ToString("MM/dd/yyyy"),
                MinValue = minDate.Ticks,
                MaxValue = date.Ticks,
                Separator = new Separator
                {
                    Step = TimeSpan.FromDays(1).Ticks, // Step of one day between points
                    IsEnabled = true
                }
            });

            // Adjust the Y-axis for the first chart (Total Payment)
            cartesianChart1.AxisY.Clear();
            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Amount (Total Payment)",
                LabelFormatter = value => value.ToString("C2"), // Format as currency with 2 decimal places
                MinValue = 0, // Minimum value on the Y-axis
                MaxValue = 80000 // Adjust to your max data value
            });

            // Set up the X-axis for the second chart (Customer Count)
            cartesianChart2.AxisX.Clear();
            cartesianChart2.AxisX.Add(new Axis
            {
                Title = "Date",
                LabelFormatter = value => new DateTime((long)value).ToString("MM/dd/yyyy"),
                MinValue = minDate.Ticks,
                MaxValue = date.Ticks
            });

            // Adjust the Y-axis for the second chart (Customer Count)
            cartesianChart2.AxisY.Clear();
            cartesianChart2.AxisY.Add(new Axis
            {
                Title = "Customer Count",
                LabelFormatter = value => value.ToString("N0"),  // Display as integer without decimal
                MinValue = 0, // Minimum value on the Y-axis
                MaxValue = 20 // Adjust to your max data value
            });
        }

        private void LoadStatistics2()
        {
            // Example random data for testing
            var testSalesData = new ChartValues<decimal> { 10, 50, 30, 90, 70 };
            var testCustomerCountData = new ChartValues<int> { 5, 60, 20, 80, 40 };

            // Create line series for Total Payment (with filled area under the line)
            var totalPaymentSeries = new LineSeries
            {
                Title = "Total Payment",
                Values = testSalesData,  // Replace with actual data
                PointGeometry = DefaultGeometries.Circle,
                StrokeThickness = 3,  // Thicker lines for visibility
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromArgb(80, 255, 0, 0)),  // Semi-transparent red fill under the line
                LineSmoothness = 0.3,  // Controls smoothness of the line
                Stroke = new SolidColorBrush(Color.FromRgb(255, 0, 0)),  // Line color (red)
            };

            // Create line series for Customer Count (with filled area under the line)
            var customerCountSeries = new LineSeries
            {
                Title = "Customer Count",
                Values = testCustomerCountData,  // Replace with actual data
                PointGeometry = DefaultGeometries.Square,
                StrokeThickness = 3,
                Fill = new SolidColorBrush(Color.FromArgb(80, 0, 0, 255)),  // Semi-transparent blue fill
                LineSmoothness = 0.3,  // Controls smoothness of the line
                Stroke = new SolidColorBrush(Color.FromRgb(0, 0, 255)),  // Line color (blue)
            };

            // Clear existing series and add new data to the chart
            cartesianChart1.Series.Clear();
            cartesianChart1.Series.Add(totalPaymentSeries);
            cartesianChart1.Series.Add(customerCountSeries);

            // Set the X-axis labels (you can format it for dates if needed)
            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Days",
                Labels = new[] { "Day 1", "Day 2", "Day 3", "Day 4", "Day 5" }
            });

            // Set up the Y-axis (for example, the total payment values)
            cartesianChart1.AxisY.Clear();
            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Amount / Count",
                MinValue = 0,  // Adjust as needed for your data
                MaxValue = 100,  // Adjust based on expected data range
            });
        }

        private void LoadLabels()
        {
            // Get the filter from the combo box first
            string storedProcedure = "GetMonthlySalesAndCustomerAnalytics";

            Analytics analyticsList = _analyticsQueryHandler.GetSalesAndCustomerAnalytics(storedProcedure);
            List<Car> cars = _carQueryHandler.GetAvailableCars();
            lblTotalCustomer.Text = analyticsList.CustomerCount.ToString();
            lblTotalIncome.Text = analyticsList.TotalSales.ToString();
            lblCarCount.Text = cars.Count.ToString();
            //MessageBox.Show($"Date: {analyticsList.Date}, Total Sales: {analyticsList.TotalSales}, Customer Count: {analyticsList.CustomerCount}");
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            cmbDateFilter.SelectedIndex = 0;
            LoadStatistics();
            LoadLabels();
        }

        private void cmbDateFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStatistics();
        }
    }
}