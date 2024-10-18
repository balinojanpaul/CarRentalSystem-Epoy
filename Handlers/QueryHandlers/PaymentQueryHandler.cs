using System;
using System.Collections.Generic;
using System.Data;
using CarRentalSystem2.Models;
using MySql.Data.MySqlClient;

namespace CarRentalSystem2.Handlers.QueryHandlers
{
    public class PaymentQueryHandler
    {
        private readonly string _connectionString;

        public PaymentQueryHandler(string connectionString)
        {
            _connectionString = connectionString;
        }


        public List<Payment> GetAllPayments()
        {
            var payments = new List<Payment>();
            
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("GetAllPayments", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            payments.Add(new Payment
                            {
                                PaymentId = (int)reader["ID"],
                                RentalId = (int)reader["rentalId"],
                                PaymentAmount = (decimal)reader["paymentAmount"],
                                PaymentDate = (DateTime)reader["paymentDate"]
                            });
                        }
                    }
                }
            }

            return payments;
        }

        
        public Payment GetPaymentById(int paymentId)
        {
            var payment = new Payment();
            
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("GetPaymentById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_paymentId", paymentId);
                    
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            payment = new Payment
                            {
                                PaymentId = (int)reader["ID"],
                                RentalId = (int)reader["rentalId"],
                                PaymentAmount = (decimal)reader["paymentAmount"],
                                PaymentDate = (DateTime)reader["paymentDate"]
                            };
                        }
                    }
                }
            }

            return payment;
        }
    }
}