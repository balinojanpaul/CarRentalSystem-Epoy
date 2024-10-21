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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace CarRentalSystem2.Views
{
    public partial class RentCarPage : Form
    {
        private readonly CarQueryHandler _carQueryHandler;
        private readonly CarCommandHandler _carCommandHandler;
        private readonly CustomerQueryHandler _customerQueryHandler;
        private readonly CustomerCommandHandler _customerCommandHandler;
        private readonly RentalCommandHandler _rentalCommandHandler;
        private readonly PaymentCommandHandler _paymentCommandHandler;
        private List<Car> _availableCars;
        public Customer Customer { get; set; }

        public RentCarPage()
        {
            InitializeComponent();
            _carQueryHandler = new CarQueryHandler(Commons.ConnectionString);
            _carCommandHandler = new CarCommandHandler(Commons.ConnectionString);
            _customerQueryHandler = new CustomerQueryHandler(Commons.ConnectionString);
            _customerCommandHandler = new CustomerCommandHandler(Commons.ConnectionString);
            _rentalCommandHandler = new RentalCommandHandler(Commons.ConnectionString);
            _paymentCommandHandler = new PaymentCommandHandler(Commons.ConnectionString);
            _availableCars = _carQueryHandler.GetAvailableCars();
        }


        // ------------------------- Listener Functions ------------------------- \\

        private void cmbCarId_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Ensure an item is selected
            if (cmbCarId.SelectedIndex != -1)
            {
                // Get the selected car based on the Car ID
                Car selectedCar = _availableCars[cmbCarId.SelectedIndex];

                // Set the Brand and Model ComboBoxes based on the selected Car ID
                txtBrand.Text = selectedCar.Brand;
                txtModel.Text = selectedCar.Model;

                DateTime dateRented = dtpDateRented.Value;
                DateTime dateReturned = dtpDateReturned.Value;
                UpdateTotalPrice(dateRented, dateReturned);
            }
            else
            {
                // Clear the Brand and Model if no car is selected
                txtBrand.Text = string.Empty;
                txtModel.Text = string.Empty;
                lblTotal.Text = string.Empty;
            }
        }

        private void btnRent_Click(object sender, EventArgs e)
        {
            if (!ValidateFormInputs())
            {
                lblErrorMessage.Text = "All fields must be filled out.";
                lblErrorMessage.ForeColor = Color.Red;
                lblErrorMessage.Visible = true;
                return;
            }

            Customer = new Customer
            {
                FirstName = txtFirstName.Text,
                MiddleName = txtMiddleName.Text,
                LastName = txtLastName.Text,
                Gender = cmbGender.SelectedItem?.ToString(),
                ContactInfo = txtContact.Text,
                EmailAddress = txtEmail.Text
            };

            int carId = Convert.ToInt32(cmbCarId.SelectedValue);
            // Confirm Rent action
            var confirmResult = MessageBox.Show(@"Are you sure?",
                @"Confirm Rent",
                MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                SaveCustomerDataAndRental(Customer, carId);

                // Reload the DataGridView
                LoadCarDataIntoDataGrid();

                MessageBox.Show(@"Rented successfully!");
            }
        }

        private void dtpDateRented_ValueChanged(object sender, EventArgs e)
        {
            DateTime dateRented = dtpDateRented.Value;
            DateTime dateReturned = dtpDateReturned.Value;
            DateTime currentDate = DateTime.Now.Date;

            // Check if the Date Rented is earlier than today
            if (dateRented < currentDate)
            {
                // Show error message
                MessageBox.Show(@"The Date Rented cannot be earlier than today's date.", @"Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpDateRented.Value = currentDate;
            }

            UpdateTotalPrice(dateRented, dateReturned);
        }

        private void dtpDateReturned_ValueChanged(object sender, EventArgs e)
        {
            // Get the selected dates
            DateTime dateRented = dtpDateRented.Value;
            DateTime dateReturned = dtpDateReturned.Value;

            // Check if the Date Rented is greater than Date Returned
            if (dateRented > dateReturned)
            {
                // Show error message
                MessageBox.Show(@"The Date Rented cannot be later than the Date Returned.", @"Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Reset the Date Returned to the Date Rented
                dtpDateReturned.Value = dateRented;
            }
            else if (dateReturned < dateRented)
            {
                // Show an error message
                MessageBox.Show(@"The Date Returned cannot be earlier than the Date Rented.", @"Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Reset the Date Returned to the Date Rented
                dtpDateReturned.Value = dateRented;
            }
            else
            {
                // If the Date Returned is valid, update the total price
                UpdateTotalPrice(dateRented, dateReturned);
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
                lblErrorMessage.Text = "Contact number must be 10 or 11 digits long.";
                lblErrorMessage.ForeColor = Color.Red;
                lblErrorMessage.Visible = true;
            }
            else
            {
                lblErrorMessage.Visible = false; // Hide error message if valid
            }
        }


        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            // Check if the input in txtAmount is a valid decimal number
            if (decimal.TryParse(txtAmount.Text, out decimal amount))
            {
                // Parse the total amount from lblTotal as currency
                if (decimal.TryParse(lblTotal.Text, System.Globalization.NumberStyles.Currency,
                        System.Globalization.CultureInfo.CurrentCulture, out decimal total))
                {
                    // Subtract the amount entered from the total to get the remaining balance
                    decimal balance = total - amount;

                    // If the balance is greater than or equal to zero, display it
                    if (balance >= 0)
                    {
                        // Update the label with the calculated balance formatted as currency
                        lblBalance.Text = $@"{balance:C}";
                    }
                    else
                    {
                        // If overpayment, display the extra as balance
                        lblBalance.Text = $@"Overpaid: {Math.Abs(balance):C}";
                    }
                }
                else
                {
                    // If lblTotal is not a valid number, clear the balance label
                    lblBalance.Text = @"N/A";
                }
            }
            else
            {
                // If the input is not a valid number, clear the balance label
                lblBalance.Text = @"N/A";
            }
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only digits, control characters, and a single decimal point
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Allow only one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void RentCarPage_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadAvailableCarIdIntoComboBox();
            LoadCarDataIntoDataGrid();
        }


        // ------------------------- Helper Functions ------------------------- \\

        private void ProcessRental()
        {
            
        }
        
        private void SetupDataGridView()
        {
            // Set the column header style
            dtgAvailableCars.EnableHeadersVisualStyles = false;
            /*dtgAvailableCars.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dtgAvailableCars.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;*/
            dtgAvailableCars.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            dtgAvailableCars.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Optional: Set the grid's border style
           // dtgAvailableCars.BorderStyle = BorderStyle.None;
            cmbFilter.SelectedIndex = 0;

            // Set the dock style to fill
            //dtgAvailableCars.Dock = DockStyle.Fill;

            /*// Set row styling
            dtgAvailableCars.RowsDefaultCellStyle.BackColor = Color.White; // White background for rows
            dtgAvailableCars.RowsDefaultCellStyle.ForeColor = Color.Black; // Black text for rows
            dtgAvailableCars.RowsDefaultCellStyle.SelectionBackColor =
                Color.LightGray; // Row selection background color
            dtgAvailableCars.RowsDefaultCellStyle.SelectionForeColor = Color.Black; // Row selection text color

            // Set alternating row style
            dtgAvailableCars.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray; // Alternating row background*/

            dtgAvailableCars.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Example Data: Add columns and rows for demonstration purposes
            dtgAvailableCars.Columns.Add("CarID", "Car ID");
            dtgAvailableCars.Columns.Add("Brand", "Brand");
            dtgAvailableCars.Columns.Add("Model", "Model");
            dtgAvailableCars.Columns.Add("Price", "Price");
            dtgAvailableCars.Columns.Add("Status", "Status");
        }

        private void SaveCustomerDataAndRental(Customer customer, int carId)
        {
            var payment = new Payment();
            InvoicePage invoice;
            try
            {
                int customerId = _customerCommandHandler.AddCustomer(customer);
                Console.WriteLine($"Customer Id: {customerId}");
                
                try
                {
                    decimal totalsAmount = Convert.ToDecimal(txtAmount.Text);
                    // Proceed with totalAmount
                    
                    var rental = new Rental
                    {
                        CustomerId = customerId,
                        CarId = carId,
                        Status = "Rented",
                        StartDate = dtpDateRented.Value,
                        EndDate = dtpDateReturned.Value,
                    };
                    int rentalId = _rentalCommandHandler.AddRental(rental);
                    Console.WriteLine($"Rental Id: {rentalId}");
                    payment = new Payment
                    {
                        RentalId = rentalId,
                        PaymentAmount = totalsAmount,
                        PaymentDate = DateTime.Now
                    };
                    
                    // Update the availability of the car for obvious reasons
                    _carCommandHandler.UpdateCarAvailability(carId);
                    _paymentCommandHandler.AddPayment(payment);
                    MessageBox.Show(@"Customer and Rental added successfully!");
                    Hide();
                    invoice = new InvoicePage(rentalId, customerId);
                    var invoiceResult = invoice.ShowDialog();
                    MessageBox.Show("Invoice Sucessfully Generated!");
                }
                catch (FormatException)
                {
                    MessageBox.Show("Invalid amount format. Please enter a valid decimal number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (OverflowException)
                {
                    MessageBox.Show("The amount entered is too large or too small.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                // if (decimal.TryParse(txtAmount.Text, out decimal totalAmount))
                // {
                //     var rental = new Rental
                //     {
                //         CustomerId = customerId,
                //         CarId = carId,
                //         Status = "Rented",
                //         StartDate = dtpDateRented.Value,
                //         EndDate = dtpDateReturned.Value,
                //     };
                //     int rentalId = _rentalCommandHandler.AddRental(rental);
                //     Console.WriteLine($"Rental Id: {rentalId}");
                //     payment = new Payment
                //     {
                //         RentalId = rentalId,
                //         PaymentAmount = totalAmount,
                //         PaymentDate = DateTime.Now
                //     };
                // }
                // else
                // {
                //     MessageBox.Show(@"Amount should not be empty");
                // }

                // Update the availability of the car for obvious reasons
                // _carCommandHandler.UpdateCarAvailability(carId);
                // _paymentCommandHandler.AddPayment(payment);
                // MessageBox.Show(@"Customer and Rental added successfully!");
            }
            catch (Exception e)
            {
                MessageBox.Show(@"There is an error adding Customer to the database");
                Console.WriteLine(e);
            }
        }

        private void UpdateTotalPrice(DateTime dateRented, DateTime dateReturned)
        {
            if (cmbCarId.SelectedIndex != -1)
            {
                // Get the selected car based on the Car ID
                Car selectedCar = _availableCars[cmbCarId.SelectedIndex];

                // Calculate the total days and update the total label
                int totalDays = (dateReturned - dateRented).Days + 1; // Include the start day
                decimal totalPrice = selectedCar.PricePerDay * totalDays;
                lblTotal.Text = totalPrice.ToString("C"); // Format as currency
            }
            else
            {
                lblTotal.Text = string.Empty;
            }
        }

        private void LoadCarDataIntoDataGrid()
        {
            // Clear the DataGridView rows before loading new data
            dtgAvailableCars.Rows.Clear();

            List<Car> availableCars = _carQueryHandler.GetAvailableCars();

            // Add rows to the DataGridView
            if (availableCars != null)
            {
                foreach (var car in availableCars)
                {
                    string availability = car.Availability ? "Available" : "Not Available";
                    dtgAvailableCars.Rows.Add(car.CarId, car.Brand, car.Model, car.PricePerDay, availability);
                }
            }
        }

        public void LoadDataFromInquiry(int carId)
        {
            // Load the Car details
            Car car = _carQueryHandler.GetCarById(carId);
            // Ensure the ValueMember is set to the property that holds the car ID
            cmbCarId.ValueMember = "CarId";
            // Set the SelectedValue to the carId parameter
            cmbCarId.SelectedValue = carId;
            txtBrand.Text = car.Brand;
            txtModel.Text = car.Model;

            // Load the Customer details
            cmbGender.ValueMember = "Gender";
            cmbGender.SelectedItem = Customer.Gender;
            txtEmail.Text = Customer.EmailAddress;
            txtFirstName.Text = Customer.FirstName;
            txtMiddleName.Text = Customer.MiddleName;
            txtLastName.Text = Customer.LastName;
            txtContact.Text = Customer.ContactInfo;
        }

        private void LoadAvailableCarIdIntoComboBox()
        {
            // Set the ComboBox to display the CarId
            cmbCarId.DataSource = _availableCars;
            cmbCarId.DisplayMember = "CarId"; // This ensures that the CarId is shown
            cmbCarId.ValueMember = "CarId"; // Sets the actual value of the ComboBox to CarId

            // Prevent any initial selection by setting SelectedIndex to -1
            cmbCarId.SelectedIndex = -1; // No initial value is selected
        }

        private bool ValidateFormInputs()
        {
            return !string.IsNullOrWhiteSpace(txtFirstName.Text) &&
                   !string.IsNullOrWhiteSpace(txtMiddleName.Text) &&
                   !string.IsNullOrWhiteSpace(txtLastName.Text) &&
                   !string.IsNullOrWhiteSpace(txtContact.Text) &&
                   cmbGender.SelectedItem != null &&
                   !string.IsNullOrWhiteSpace(txtEmail.Text);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string selectedColumn = cmbFilter.SelectedItem.ToString();

            if (string.IsNullOrEmpty(selectedColumn))
            {
                MessageBox.Show("Please select a filter column.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (selectedColumn == "Car Id")
            {
                selectedColumn = "ID";
            }
            else if (selectedColumn == "Price")
            {
                selectedColumn = "pricePerDay";
            }
            else if (selectedColumn == "Status")
            {
                selectedColumn = "availability";
            }


            // Get the search from the search text box
            string searchTerm = txtSearch.Text;

            // Call the method and bind the result to the DataGridView

            List<Car> cars = _carQueryHandler.SearchCarsWithFilter(selectedColumn, searchTerm);

            // Clear the DataGridView rows before loading new data
            dtgAvailableCars.Rows.Clear();

            // Add rows to the DataGridView
            if (cars != null)
            {
                foreach (var car in cars)
                {
                    string availability = car.Availability ? "Available" : "Not Available";
                    dtgAvailableCars.Rows.Add(car.CarId, car.Brand, car.Model, car.PricePerDay, availability);
                }
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            //InvoicePage invoicePage = new InvoicePage();
            //invoicePage.ShowDialog();
        }
    }
}