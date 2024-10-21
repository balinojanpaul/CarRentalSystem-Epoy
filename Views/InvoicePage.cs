using CarRentalSystem2.Common;
using CarRentalSystem2.Handlers.QueryHandlers;
using CarRentalSystem2.Helpers;
using CarRentalSystem2.Models;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalSystem2.Views
{
    public partial class InvoicePage : Form
    {
        private Rental Rental {  get; set; }
        private Customer Customer {  get; set; }
        private Payment Payment { get; set; }
        private Car Car { get; set; }
        private CustomerQueryHandler _customerQueryHandler;
        private PaymentQueryHandler _paymentQueryHandler;
        private RentalQueryHandler _rentalQueryHandler;
        private CarQueryHandler _carQueryHandler;
        public InvoicePage(int rentalId, int customerId)
        {
            InitializeComponent();
            _customerQueryHandler = new CustomerQueryHandler(Commons.ConnectionString);
            _paymentQueryHandler = new PaymentQueryHandler(Commons.ConnectionString);
            _rentalQueryHandler = new RentalQueryHandler(Commons.ConnectionString);
            _carQueryHandler = new CarQueryHandler(Commons.ConnectionString);
            Rental = _rentalQueryHandler.GetRentalById(rentalId);
            Car = _carQueryHandler.GetCarById(Rental.CarId);
            Customer = _customerQueryHandler.GetCustomerById(customerId);
            Payment = _paymentQueryHandler.GetPaymentByRentalId(rentalId);
            SetUpCrystalReports();
        }

        private void SetUpCrystalReports()
        {
            CrystalReport1 report1 = new CrystalReport1();
            // FirstName, LastName, EmailAddress, ContactNumber,CarId, Brand, Model, Brand, TotalFee, InvoiceNo, Date
            report1.SetParameterValue(0, Customer.FirstName);
            report1.SetParameterValue(1, Customer.LastName);
            report1.SetParameterValue(2, Customer.EmailAddress);
            report1.SetParameterValue(3, Customer.ContactInfo);
            report1.SetParameterValue(4, Car.CarId);
            report1.SetParameterValue(5, Car.Brand);
            report1.SetParameterValue(6, Car.Model);
            report1.SetParameterValue(7, Payment.PaymentAmount);
            report1.SetParameterValue(8, Rental.RentalId);
            report1.SetParameterValue(9, Payment.PaymentDate.Date);
            crystalReportViewer1.ReportSource = report1;
            crystalReportViewer1.Refresh();
        }
    }
}
