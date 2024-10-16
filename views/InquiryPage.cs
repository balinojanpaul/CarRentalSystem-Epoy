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

namespace CarRentalSystem2.Views
{
    public partial class InquiryPage : Form
    {
        private readonly CustomerCommandHandler _customerCommandHandler;
        private readonly CustomerQueryHandler _customerQueryHandler;
        private readonly CarQueryHandler _carQueryHandler;
        private readonly InquiryCommandHandler _inquiryCommandHandler;
        private readonly InquiryQueryHandler _inquiryQueryHandler;
        private Panel _panel;
        private Customer _customer;
        private List<Inquiry> _inquiries;
        private int InquiryId;
        
        
        // TODO: Implement the Clear Grid Button
        public InquiryPage(Panel panel)
        {
            InitializeComponent();
            _panel = panel;
            _customerCommandHandler = new CustomerCommandHandler(Commons.ConnectionString);
            _customerQueryHandler = new CustomerQueryHandler(Commons.ConnectionString);
            _inquiryCommandHandler = new InquiryCommandHandler(Commons.ConnectionString);
            _carQueryHandler = new CarQueryHandler(Commons.ConnectionString);
            _inquiryQueryHandler = new InquiryQueryHandler(Commons.ConnectionString);
            _customer = new Customer();
            _inquiries = _inquiryQueryHandler.GetAllInquiries();
        }
        
        
        // ------------------------- Listener Functions ------------------------- \\
        
        private void btnInquire_Click(object sender, EventArgs e)
        {
            if (!ValidateInquiryInputs())
            {
                lblErrorMessage.Text = "All fields must be filled out.";
                lblErrorMessage.ForeColor = Color.Red;
                lblErrorMessage.Visible = true;
                return;
            }

            var customer = new Customer
            {
                FirstName = txtFirstName.Text,
                MiddleName = txtMiddleName.Text,
                LastName = txtLastName.Text,
                Gender = cmbGender.SelectedItem?.ToString(),
                ContactInfo = txtContact.Text
            };

            int carId = Convert.ToInt32(cmbCarId.SelectedValue);
            SubmitInquiry(customer, carId);
            DisplayInquiries();
        }

        private void btnRent_Click(object sender, EventArgs e)
        {
            // Validate that a customer has been selected from the inquiry list
            if (InquiryId == 0)
            {
                lblErrorMessage.Text = "No inquiry selected for rental.";
                lblErrorMessage.ForeColor = Color.Red;
                lblErrorMessage.Visible = true;
                return;
            }
            
            // Validate that all necessary input fields are filled
            if (!ValidateInquiryInputs())
            {
                lblErrorMessage.Text = "All fields must be filled out.";
                lblErrorMessage.ForeColor = Color.Red;
                lblErrorMessage.Visible = true;
                return;
            }

            var rentCarPage = new RentCarPage();
            rentCarPage.Customer = new Customer
            {
                FirstName = txtFirstName.Text,
                MiddleName = txtMiddleName.Text,
                LastName = txtLastName.Text,
                Gender = cmbGender.SelectedItem?.ToString(),
                ContactInfo = txtContact.Text,
                EmailAddress = ""
            };
            // Console.WriteLine($"Gender: {gender}");
            try
            {
                // Retrieve the car and inquiry information
                int carId = Convert.ToInt32(cmbCarId.SelectedValue);
                var car = _carQueryHandler.GetCarById(carId);
                
                // Check if the car is available before proceeding
                if (!car.Availability)
                {
                    lblErrorMessage.Text = "Car is not available for rent.";
                    lblErrorMessage.ForeColor = Color.Red;
                    lblErrorMessage.Visible = true;
                    return;
                }
                
                // Confirm the rental action with the user
                var confirmResult = MessageBox.Show(@"Are you sure you want to rent this car?", @"Confirm Rent", MessageBoxButtons.YesNo);
                if (confirmResult != DialogResult.Yes)
                {
                    return;
                }
                
                ConvertInquiryToRental(InquiryId);
                LoadForm(rentCarPage);
                rentCarPage.LoadDataFromInquiry(carId);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {
            btnRent.Visible = false;
        }

        private void bunifuPanel2_Click(object sender, EventArgs e)
        {
            btnRent.Visible = false;
        }

        private void dtgCustomerInquiry_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ClearFields();

            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dtgCustomerInquiry.Rows[e.RowIndex];

                btnRent.Visible = true;
                int carId = (int)selectedRow.Cells["CarId"].Value;
                InquiryId = (int)selectedRow.Cells["InquiryId"].Value;
                var inquiry = _inquiryQueryHandler.GetInquiryById(InquiryId);
                // Console.WriteLine($"Inquiry ID: {InquiryId}");
                var car = _carQueryHandler.GetCarById(carId);
                var customer = _customerQueryHandler.GetCustomerById(inquiry.CustomerId);
                cmbCarId.SelectedItem = carId;
                txtBrand.Text = car.Brand;
                txtModel.Text = car.Model;
                txtFirstName.Text = customer.FirstName;
                txtMiddleName.Text = customer.MiddleName;
                txtLastName.Text = customer.LastName;
                txtContact.Text = customer.ContactInfo;
                cmbGender.SelectedItem = customer.Gender;

                if (car.Availability)
                {
                    btnRent.Enabled = true;
                }
                else
                {
                    lblErrorMessage.Text = "Customer Cannot Rent,\n Car is not Available";
                    lblErrorMessage.ForeColor = Color.Red;
                    lblErrorMessage.Visible = true;
                    btnRent.Enabled = false;
                }
            }
        }

        private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only digits and control characters (like Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void txtContact_TextChanged(object sender, EventArgs e)
        {
            // Remove any non-digit characters from the pasted text
            txtContact.Text = new string(txtContact.Text.Where(char.IsDigit).ToArray());

            // Set the cursor position to the end of the text
            txtContact.SelectionStart = txtContact.Text.Length;

            // Check for valid length
            int length = txtContact.Text.Length;

            if (length < 10 || length > 11)
            {
                lblErrorMessage.Text = "Contact number must be 10 or 11 \n digits long.";
                lblErrorMessage.ForeColor = Color.Red;
                lblErrorMessage.Visible = true;
            }
            else
            {
                lblErrorMessage.Visible = false; // Hide error message if valid
            }
            
        }

        private void cmbCarId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCarId.SelectedValue != null)
            {
                int carId = Convert.ToInt32(cmbCarId.SelectedValue);
                var car = _carQueryHandler.GetCarById(carId);

                if (car != null)
                {
                    txtBrand.Text = car.Brand;
                    txtModel.Text = car.Model;
                }
            }
        }

        private void InquiryPage_Load(object sender, EventArgs e)
        {
            // CleanInquiryDataGrid();
            SetupDataGridView();
            SetupCarIdIntoCombobox();
            SetupErrorMessageLabel();
            DisplayInquiries();
        }
        
        
        // ------------------------- Helper Functions ------------------------- \\
        
        private void SubmitInquiry(Customer customer, int carId)
        {
            // Add customer or retrieve customer ID
            int customerId = _customerCommandHandler.AddCustomer(customer);
            var inquiry = new Inquiry
            {
                CustomerId = customerId,
                CarId = carId,
                Status = "Inquired",
                Date = DateTime.Now
            };

            // Add inquiry for the customer
            _inquiryCommandHandler.AddInquiry(inquiry);

            MessageBox.Show(@"Inquiry successfully submitted!");
        }

        private void ConvertInquiryToRental(int inquiryId)
        {
            // Update the inquiry status to 'Converted to Rental'
            _inquiryCommandHandler.UpdateInquiryStatus(inquiryId, "Rented");
            // MessageBox.Show(@"Inquiry has been converted to a rental.");
        }

        private void DisplayInquiries()
        {
            // Clear the DataGridView rows before loading new data
            dtgCustomerInquiry.Rows.Clear();

            // Add rows to the DataGridView
            foreach (var inquiry in _inquiries)
            {
                var customer = _customerQueryHandler.GetCustomerById(inquiry.CustomerId);
                var car = _carQueryHandler.GetCarById(inquiry.CarId);
                dtgCustomerInquiry.Rows.Add(
                    inquiry.InquiryId,
                    inquiry.CarId,
                    car.Brand,
                    car.Model,
                    $"{customer.FirstName} {customer.LastName}",
                    customer.ContactInfo,
                    inquiry.Status,
                    car.Availability ? "Available" : "Not Available");
            }
        }


        private void LoadForm(object form)
        {
            if (_panel.Controls.Count > 0)
                _panel.Controls.RemoveAt(0);

            Form f = form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            _panel.Controls.Add(f);
            _panel.Tag = f;
            f.Show();
        }

        private void ClearFields()
        {
            // Clear text fields
            txtFirstName.Text = string.Empty;
            txtBrand.Text = string.Empty;
            txtModel.Text = string.Empty;
            txtMiddleName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtContact.Text = string.Empty;

            // Reset combo box selection
            cmbGender.SelectedIndex = -1;
            cmbCarId.SelectedIndex = -1;

            // Re-enable the text fields and combo box
            cmbGender.Enabled = true;
        }

        private void SetupDataGridView()
        {
            // Set the column header style
            dtgCustomerInquiry.EnableHeadersVisualStyles = false;
            dtgCustomerInquiry.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dtgCustomerInquiry.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dtgCustomerInquiry.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            dtgCustomerInquiry.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Optional: Set the grid's border style
            dtgCustomerInquiry.BorderStyle = BorderStyle.None;


            // Set row styling
            dtgCustomerInquiry.RowsDefaultCellStyle.BackColor = Color.White; // White background for rows
            dtgCustomerInquiry.RowsDefaultCellStyle.ForeColor = Color.Black; // Black text for rows
            dtgCustomerInquiry.RowsDefaultCellStyle.SelectionBackColor =
                Color.LightGray; // Row selection background color
            dtgCustomerInquiry.RowsDefaultCellStyle.SelectionForeColor = Color.Black; // Row selection text color

            // Set alternating row style
            dtgCustomerInquiry.AlternatingRowsDefaultCellStyle.BackColor =
                Color.LightGray; // Alternating row background

            dtgCustomerInquiry.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Example Data: Add columns and rows for demonstration purposes
            dtgCustomerInquiry.Columns.Add("InquiryId", "Inquiry ID");
            dtgCustomerInquiry.Columns.Add("CarID", "Car ID");
            dtgCustomerInquiry.Columns.Add("Brand", "Brand");
            dtgCustomerInquiry.Columns.Add("Model", "Model");
            dtgCustomerInquiry.Columns.Add("FirstName", "Name");
            dtgCustomerInquiry.Columns.Add("Contact", "Contact");
            dtgCustomerInquiry.Columns.Add("Status", "Status");
            dtgCustomerInquiry.Columns.Add("CarStatus", "Car Status");
        }

        private void SetupCarIdIntoCombobox()
        {
            // Get all cars
            List<Car> cars = _carQueryHandler.GetAllCars();

            // Extract the car ID's
            List<int> carIds = cars.Select(car => car.CarId).ToList();

            // Populate the combo boc with car ID's
            cmbCarId.DataSource = carIds;
        }

        private void SetupErrorMessageLabel()
        {
            lblErrorMessage.AutoSize = false;
            lblErrorMessage.MaximumSize = new Size(300, 0); // Set the maximum width to 300 pixels
            lblErrorMessage.AutoSize = true;
        }

        private void CleanInquiryDataGrid()
        {
            _inquiryCommandHandler.DeleteRentedInquiries();
        }

        private bool ValidateInquiryInputs()
        {
            return !string.IsNullOrWhiteSpace(txtFirstName.Text) &&
                   !string.IsNullOrWhiteSpace(txtMiddleName.Text) &&
                   !string.IsNullOrWhiteSpace(txtLastName.Text) &&
                   !string.IsNullOrWhiteSpace(txtContact.Text) &&
                   cmbGender.SelectedItem != null;
        }

        
    }
}
