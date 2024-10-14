using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarRentalSystem2.Common;
using CarRentalSystem2.Handlers.CommandHandlers;
using CarRentalSystem2.Handlers.QueryHandlers;
using CarRentalSystem2.Models;

namespace CarRentalSystem2.Views
{
    public partial class AvailableCarsPage : Form
    {
        private readonly CarQueryHandler _carQueryHandler;
        private readonly CarCommandHandler _carCommandHandler;
        private Car _car;
        private DataGridViewRow _selectedRow;


        public AvailableCarsPage()
        {
            InitializeComponent();
            _carQueryHandler = new CarQueryHandler(Commons.ConnectionString);
            _carCommandHandler = new CarCommandHandler(Commons.ConnectionString);
            _car = new Car();
            SetupDataGridView();
            LoadCarDataIntoDataGrid();
        }

        // ------------------------- Listener Functions ------------------------- \\
        private void dtgCarList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Clear the fields first
            ClearFields();

             // Disable first the Car ID text box and the price
            //txtPrice.Enabled = false;
            //txtPrice.ReadOnly = true;
            // cmbStatus.Enabled = false;

            // Check if a valid row is selected (not the header)
            if (e.RowIndex >= 0)
            {
                _selectedRow = dtgCarList.Rows[e.RowIndex];

                // Set the text of the textboxes based on the selected row's cell
                int carId = (int)_selectedRow.Cells["CarID"].Value;

                var car = _carQueryHandler.GetCarById(carId);
                txtCarId.Text = car.CarId.ToString();
                txtBrand.Text = car.Brand;
                txtModel.Text = car.Model;
                txtPrice.Text = car.PricePerDay.ToString(CultureInfo.InvariantCulture);
                string availability = car.Availability ? "Available" : "Not Available";
                cmbStatus.SelectedItem = availability;
                //MessageBox.Show($"Image Path: {car.ImagePath}");

                if (car.ImagePath != null || string.IsNullOrWhiteSpace(car.ImagePath) || car.ImagePath == "")
                {
                    //pbSelectedImage.Image = Image.FromFile(car.ImagePath);
                }
                
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Get values from the text boxes
            string brand = txtBrand.Text.Trim();
            string model = txtModel.Text.Trim();
            decimal price = Convert.ToDecimal(txtPrice.Text.Trim());
            string selectedStatus = cmbStatus.SelectedItem?.ToString();
            bool availability = selectedStatus == "Available";

            if (_selectedRow == null)
            {
                MessageBox.Show(@"Please select a car to update.");
                return;
            }

            // Update the Car object
            _car.CarId = Convert.ToInt32(txtCarId.Text.Trim());
            _car.Brand = brand;
            _car.Model = model;
            _car.PricePerDay = price;
            _car.Availability = availability;
            _car.ImagePath = _car.ImagePath; // Assuming the image path is unchanged

            // Call the UpdateCar method from the command handler
            _carCommandHandler.UpdateCar(_car);

            // Reload the DataGridView
            LoadCarDataIntoDataGrid();

            MessageBox.Show(@"Car updated successfully!");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Get values from the text boxes
            string carId = txtCarId.Text.Trim();
            string brand = txtBrand.Text.Trim();
            string model = txtModel.Text.Trim();
            decimal price = Convert.ToDecimal(txtPrice.Text.Trim());
            string selectedStatus = cmbStatus.SelectedItem?.ToString();

            // Check if the car already exists in the DataGridView
            foreach (DataGridViewRow row in dtgCarList.Rows)
            {
                if (row.Cells["CarID"].Value != null && row.Cells["CarID"].Value.ToString() == carId)
                {
                    MessageBox.Show(@"The selected car already exists in the list!");
                    return;
                }
            }

            if (!txtPrice.Enabled)
            {
                MessageBox.Show(@"Cannot add selected car. Option is redundant!");
                return;
            }

            if (pbSelectedImage.Image == null)
            {
                MessageBox.Show(@"Please select an image for the car!");
                return;
            }

            _car.Brand = brand;
            _car.Model = model;
            _car.PricePerDay = price;
            _car.Availability = selectedStatus == "Available";
            _carCommandHandler.AddCar(_car);

            LoadCarDataIntoDataGrid();
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }


        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            txtPrice.Text = new string(txtPrice.Text.Where(char.IsDigit).ToArray());

            txtPrice.SelectionStart = txtPrice.Text.Length;
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only digits and control characters
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            // Create a new instance of OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Set the properties of OpenFile of OpenFileDialog (optional)
            openFileDialog.Filter = @"Image Files|*.jpg;*.jpeg;*.png|All Files|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the path of the selected file
                string selectedFilePath = openFileDialog.FileName;
                pbSelectedImage.Image = Image.FromFile(selectedFilePath);
                _car.ImagePath = selectedFilePath;
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedRow == null)
            {
                MessageBox.Show(@"Please select a car to delete.");
                return;
            }

            // Get the Car ID from the selected row
            int carId = Convert.ToInt32(txtCarId.Text.Trim());

            // Confirm delete action
            var confirmResult = MessageBox.Show(@"Are you sure you want to delete this car?",
                @"Confirm Delete",
                MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                // Call the DeleteCar method from the command handler
                _carCommandHandler.DeleteCar(carId);

                // Reload the DataGridView
                LoadCarDataIntoDataGrid();

                MessageBox.Show(@"Car deleted successfully!");
            }
        }


        // ------------------------- Listener Functions ------------------------- \\

        private void SetupDataGridView()
        {
            // Set the column header style
            dtgCarList.EnableHeadersVisualStyles = false;
            dtgCarList.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dtgCarList.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dtgCarList.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            dtgCarList.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Optional: Set the grid's border style
            dtgCarList.BorderStyle = BorderStyle.None;

            // Set the dock style to fill
            dtgCarList.Dock = DockStyle.Fill;

            // Set row styling
            dtgCarList.RowsDefaultCellStyle.BackColor = Color.White; // White background for rows
            dtgCarList.RowsDefaultCellStyle.ForeColor = Color.Black; // Black text for rows
            dtgCarList.RowsDefaultCellStyle.SelectionBackColor = Color.LightGray; // Row selection background color
            dtgCarList.RowsDefaultCellStyle.SelectionForeColor = Color.Black; // Row selection text color

            // Set alternating row style
            dtgCarList.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray; // Alternating row background

            dtgCarList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Example Data: Add columns and rows for demonstration purposes
            dtgCarList.Columns.Add("CarID", "Car ID");
            dtgCarList.Columns.Add("Brand", "Brand");
            dtgCarList.Columns.Add("Model", "Model");
            dtgCarList.Columns.Add("Price", "Price");
            dtgCarList.Columns.Add("Status", "Status");
        }


        private void LoadCarDataIntoDataGrid()
        {
            // Clear the DataGridView rows before loading new data
            dtgCarList.Rows.Clear();

            List<Car> cars = _carQueryHandler.GetAllCars();

            // Add rows to the DataGridView
            if (cars != null)
            {
                foreach (var car in cars)
                {
                    string availability = car.Availability ? "Available" : "Not Available";
                    dtgCarList.Rows.Add(car.CarId, car.Brand, car.Model, car.PricePerDay, availability);
                }
            }
        }


        private void ClearFields()
        {
            // Clear text fields
            txtCarId.Text = string.Empty;
            txtBrand.Text = string.Empty;
            txtModel.Text = string.Empty;
            txtPrice.Text = string.Empty;

            // Reset image
            pbSelectedImage.Image = null;

            // Reset combo box selection
            cmbStatus.SelectedIndex = -1;

            // Re-enable the text fields and combo box
            txtPrice.Enabled = true;
            txtPrice.ReadOnly = false;
            cmbStatus.Enabled = true;
        }
    }
}