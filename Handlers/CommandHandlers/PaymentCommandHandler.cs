using System;
using System.Data;
using CarRentalSystem2.Models;
using MySql.Data.MySqlClient;

namespace CarRentalSystem2.Handlers.CommandHandlers
{
    public class PaymentCommandHandler
    {
        private readonly string _connectionString;

        public PaymentCommandHandler(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        // Add Payment
        public void AddPayment(Payment payment)
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("AddRental", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_rentalID", payment.RentalId);
                    cmd.Parameters.AddWithValue("p_paymentAmount", payment.PaymentAmount);
                    cmd.Parameters.AddWithValue("p_paymentDate", payment.PaymentDate);
                }
            }
        }
    }
}