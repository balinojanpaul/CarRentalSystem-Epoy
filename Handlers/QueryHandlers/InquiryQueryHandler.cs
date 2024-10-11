using System;
using System.Collections.Generic;
using System.Data;
using CarRentalSystem2.Models;
using MySql.Data.MySqlClient;

namespace CarRentalSystem2.Handlers.QueryHandlers
{
    public class InquiryQueryHandler
    {
        private readonly string _connectionString;

        public InquiryQueryHandler(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Fetch all inquiries
        public List<Inquiry> GetAllInquiries()
        {
            var inquiries = new List<Inquiry>();
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("GetAllInquiries", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            inquiries.Add(new Inquiry
                            {
                                InquiryId = (int)reader["ID"],
                                CustomerId = (int)reader["customerID"],
                                CarId = (int)reader["carID"],
                                Status = reader["status"].ToString(),
                                Date = (DateTime)reader["date"]
                            });
                        }
                    }
                }
            }

            return inquiries;
        }

        // Fetch an inquiry by ID
        public Inquiry GetInquiryById(int inquiryId)
        {
            Inquiry inquiry = null;
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("GetInquiryById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_inquiryId", inquiryId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            inquiry = new Inquiry
                            {
                                InquiryId = (int)reader["ID"],
                                CustomerId = (int)reader["customerID"],
                                CarId = (int)reader["carID"],
                                Status = reader["status"].ToString()
                            };
                        }
                    }
                }
            }

            return inquiry;
        }
    }
}