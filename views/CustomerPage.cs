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
        private List<Rental> _rentals;
        private List<Inquiry> _inquiries;
        
        public CustomerPage()
        {
            InitializeComponent();
            _rentalQueryHandler = new RentalQueryHandler(Commons.ConnectionString);
            _inquiryQueryHandler = new InquiryQueryHandler(Commons.ConnectionString);

            _rentals = _rentalQueryHandler.GetAllRentals();
            _inquiries = _inquiryQueryHandler.GetAllInquiries();
        }
        
        // ------------------------- Listener Functions ------------------------- \\
        
        
        // ------------------------- Helper Functions ------------------------- \\
        
        // id, name (concat guro fullname) email, number, carId, status
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // Implement a search query when the user types the name
            
        }
    }
}
