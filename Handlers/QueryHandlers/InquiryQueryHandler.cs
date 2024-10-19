using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
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

        public List<Inquiry> SearchInquiriesWithFilter(string column, string searchTerm)
        {
            var inquiries = new List<Inquiry>();

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand("SearchInquiriesWithFilter", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_column", column);
                    cmd.Parameters.AddWithValue("p_searchTerm", searchTerm);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //MessageBox.Show($"Inquiry Id: {reader["inquiryId"]}");
                            inquiries.Add(new Inquiry
                            {
                                InquiryId = reader["inquiryId"] != DBNull.Value ? Convert.ToInt32(reader["inquiryId"]) : 0,
                                CustomerId = reader["CustomerId"] != DBNull.Value ? Convert.ToInt32(reader["CustomerId"]) : 0,
                                CarId = reader["CarId"] != DBNull.Value ? Convert.ToInt32(reader["CarId"]) : 0,
                                Status = reader["Status"].ToString(),
                                Date = reader["Date"] != DBNull.Value ? Convert.ToDateTime(reader["Date"]) : DateTime.MinValue
                            });
                        }
                        
                    }
                }
            }

            return inquiries;
        }
    }
}