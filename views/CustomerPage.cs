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
using CarRentalSystem2.Handlers.QueryHandlers;
using CarRentalSystem2.Models;

namespace CarRentalSystem2.Views
{
    public partial class CustomerPage : Form
    {
        private RentalQueryHandler _rentalQueryHandler;
        private InquiryQueryHandler _inquiryQueryHandler;
        private CustomerQueryHandler _customerQueryHandler;
        private List<Rental> _rentals;
        private List<Inquiry> _inquiries;

        public CustomerPage()
        {
            InitializeComponent();
            _rentalQueryHandler = new RentalQueryHandler(Commons.ConnectionString);
            _inquiryQueryHandler = new InquiryQueryHandler(Commons.ConnectionString);
            _customerQueryHandler = new CustomerQueryHandler(Commons.ConnectionString);

            _rentals = _rentalQueryHandler.GetAllRentals();
            _inquiries = _inquiryQueryHandler.GetAllInquiries();
        }

        // ------------------------- Listener Functions ------------------------- \\
        
        private void CustomerPage_Load(object sender, EventArgs e)
        {
            SetupDataGridView();
            LoadAllCustomers();
        }
        
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // Implement a search query when the user types the name
        }


        // ------------------------- Helper Functions ------------------------- \\

        // customer id, name (concat guro fullname) email, number, carId, status
        

        private void LoadAllCustomers()
        {
            // Clear the DataGridView rows before loading new data
            dtgCustomers.Rows.Clear();

            List<CustomerInquiryRental> customers = _customerQueryHandler.GetAllCustomersWithInquiryAndRental();

            // Add rows to the DataGridView
            if (customers != null)
            {
                foreach (var customer in customers)
                {
                    string inquiryStatus = customer.InquiryStatus ?? "Rented";


                    dtgCustomers.Rows.Add(
                        customer.CustomerId,
                        customer.CustomerFirstName + " " + customer.CustomerLastName,
                        customer.EmailAddress,
                        customer.ContactNumber,
                        inquiryStatus
                    );
                }
            }
        }
        
        private void SetupDataGridView()
        {
            // Set the column header style
            dtgCustomers.EnableHeadersVisualStyles = false;
           /* dtgCustomers.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dtgCustomers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;*/
            dtgCustomers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 8f, FontStyle.Bold);
            dtgCustomers.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

          /*  // Optional: Set the grid's border style
            dtgCustomers.BorderStyle = BorderStyle.None;

            // Set the dock style to fill

            // Set row styling
            dtgCustomers.RowsDefaultCellStyle.BackColor = Color.White; // White background for rows
            dtgCustomers.RowsDefaultCellStyle.ForeColor = Color.Black; // Black text for rows
            dtgCustomers.RowsDefaultCellStyle.SelectionBackColor = Color.LightGray; // Row selection background color
            dtgCustomers.RowsDefaultCellStyle.SelectionForeColor = Color.Black; // Row selection text color
*/
            // Set alternating row style
            //dtgCustomers.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray; // Alternating row background

            dtgCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Example Data: Add columns and rows for demonstration purposes
            dtgCustomers.Columns.Add("CustomerId", "Customer ID");
            dtgCustomers.Columns.Add("Name", "Name");
            dtgCustomers.Columns.Add("EmailAddress", "Email");
            dtgCustomers.Columns.Add("ContactNumber", "Contact Number");
            dtgCustomers.Columns.Add("InquiryStatus", "Inquiry Status");
        }
    }
}