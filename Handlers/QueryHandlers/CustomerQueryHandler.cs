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
                        if (reader.Read())
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
        
    }
}