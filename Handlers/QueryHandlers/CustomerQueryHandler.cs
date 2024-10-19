using System;
using System.Collections.Generic;
using System.Data;
using CarRentalSystem2.Models;
using MySql.Data.MySqlClient;

namespace CarRentalSystem2.Handlers.QueryHandlers
{
    public class CustomerQueryHandler
    {
        private readonly string _connectionString;

        public CustomerQueryHandler(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        // Fetch all customers
        public List<Customer> GetAllCustomer()
        {
            var customers = new List<Customer>();
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("GetAllCustomers", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customers.Add(new Customer
                            {
                                CustomerId = (int)reader["ID"],
                                FirstName = reader["firstname"].ToString(),
                                LastName = reader["lastname"].ToString(),
                                MiddleName = reader["middlename"].ToString(),
                                Gender = reader["gender"].ToString(),
                                ContactInfo = reader["contactinfo"].ToString(),
                                EmailAddress = reader["emailaddress"].ToString()
                            });
                        }
                    }
                }
            }

            return customers;
        }
        
        
        // Fetch a customer by id
        public Customer GetCustomerById(int customerId)
        {
            Customer customer = null;
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("GetCustomerById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_customerId", customerId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customer = new Customer
                            {
                                CustomerId = (int)reader["ID"],
                                FirstName = reader["firstname"].ToString(),
                                LastName = reader["lastname"].ToString(),
                                MiddleName = reader["middlename"].ToString(),
                                Gender = reader["gender"].ToString(),
                                ContactInfo = reader["contactinfo"].ToString(),
                                EmailAddress = reader["emailaddress"].ToString()
                            };
                        }
                    }
                }
            }

            return customer;
        }


        public List<CustomerInquiryRental> GetAllCustomersWithInquiryAndRental()
        {
            var customers = new List<CustomerInquiryRental>();

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("GetAllCustomersWithInquiryAndRental", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customers.Add(new CustomerInquiryRental
                            {
                                CustomerId = reader["customerId"] != DBNull.Value ? Convert.ToInt32(reader["customerId"]) : 0,
                                CustomerFirstName = reader["customerFirstName"].ToString(),
                                CustomerLastName = reader["customerLastName"].ToString(),
                                EmailAddress = reader["emailAddress"].ToString(),
                                ContactNumber = reader["contactInfo"].ToString(),
                                InquiryId = reader["inquiryId"] != DBNull.Value ? Convert.ToInt32(reader["inquiryId"]) : (int?)null,
                                InquiryStatus = reader["inquiryStatus"] != DBNull.Value ? reader["inquiryStatus"].ToString() : null,
                                RentalId = reader["rentalId"] != DBNull.Value ? Convert.ToInt32(reader["rentalId"]) : (int?)null,
                                RentalStartDate = reader["rentalStartDate"] != DBNull.Value ? Convert.ToDateTime(reader["rentalStartDate"]) : (DateTime?)null,
                                RentalEndDate = reader["rentalEndDate"] != DBNull.Value ? Convert.ToDateTime(reader["rentalEndDate"]) : (DateTime?)null,
                                RentalStatus = reader["rentalStatus"] != DBNull.Value ? reader["rentalStatus"].ToString() : null,
                                RentalCarId = reader["rentalCarId"] != DBNull.Value ? Convert.ToInt32(reader["rentalCarId"]) : (int?)null,
                            });
                        }
                    }
                }
            }

            return customers;
        }

        // TODO: Implement a SearchCustomerWithFilter function for this
        public List<CustomerInquiryRental> SearchCustomerWithFilter(string column, string searchTerm)
        {
            var customers = new List<CustomerInquiryRental>();

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("SearchCustomersWithFilter", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_column", column);
                    cmd.Parameters.AddWithValue("p_searchTerm", searchTerm);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customers.Add(new CustomerInquiryRental
                            {
                                CustomerId = reader["customerId"] != DBNull.Value ? Convert.ToInt32(reader["customerId"]) : 0,
                                CustomerFirstName = reader["customerFirstName"].ToString(),
                                CustomerLastName = reader["customerLastName"].ToString(),
                                EmailAddress = reader["emailAddress"].ToString(),
                                ContactNumber = reader["contactInfo"].ToString(),
                                InquiryId = reader["inquiryId"] != DBNull.Value ? Convert.ToInt32(reader["inquiryId"]) : (int?)null,
                                InquiryStatus = reader["inquiryStatus"] != DBNull.Value ? reader["inquiryStatus"].ToString() : null,
                                RentalId = reader["rentalId"] != DBNull.Value ? Convert.ToInt32(reader["rentalId"]) : (int?)null,
                                RentalStartDate = reader["rentalStartDate"] != DBNull.Value ? Convert.ToDateTime(reader["rentalStartDate"]) : (DateTime?)null,
                                RentalEndDate = reader["rentalEndDate"] != DBNull.Value ? Convert.ToDateTime(reader["rentalEndDate"]) : (DateTime?)null,
                                RentalStatus = reader["rentalStatus"] != DBNull.Value ? reader["rentalStatus"].ToString() : null,
                                RentalCarId = reader["rentalCarId"] != DBNull.Value ? Convert.ToInt32(reader["rentalCarId"]) : (int?)null,
                            });
                        }
                    }
                }
            }
            return customers;
        }

    }
}