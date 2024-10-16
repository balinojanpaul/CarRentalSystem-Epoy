using System;
using System.Data;
using CarRentalSystem2.Models;
using MySql.Data.MySqlClient;

namespace CarRentalSystem2.Handlers.CommandHandlers
{
    public class CustomerCommandHandler
    {
        private readonly string _connnectionString;

        public CustomerCommandHandler(string connnectionString)
        {
            _connnectionString = connnectionString;
        }
        
        // Add a new customer
        public int AddCustomer(Customer customer)
        {
            using (MySqlConnection conn = new MySqlConnection(_connnectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("AddCustomer", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_firstName", customer.FirstName);
                    cmd.Parameters.AddWithValue("p_lastName", customer.LastName);
                    cmd.Parameters.AddWithValue("p_middleName", customer.MiddleName);
                    cmd.Parameters.AddWithValue("p_gender", customer.Gender);
                    cmd.Parameters.AddWithValue("p_contactInfo", customer.ContactInfo);
                    cmd.Parameters.AddWithValue("p_emailAddress", customer.EmailAddress);
                    // Execute the command and retrieve the CustomerId
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return Convert.ToInt32(reader["CustomerId"]);
                        }
                    }
                }
            }

            return 0;
        }
        
        
        // Update an existing customer
        public void UpdateCustomer(Customer customer)
        {
            using (MySqlConnection conn = new MySqlConnection(_connnectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("UpdateCustomer", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_firstName", customer.FirstName);
                    cmd.Parameters.AddWithValue("p_lastName", customer.LastName);
                    cmd.Parameters.AddWithValue("p_middleName", customer.MiddleName);
                    cmd.Parameters.AddWithValue("p_gender", customer.Gender);
                    cmd.Parameters.AddWithValue("p_contactInfo", customer.ContactInfo);
                    cmd.Parameters.AddWithValue("p_emailAddress", customer.EmailAddress);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        
        
        // Delete a customer by ID
        public void DeleteCustomer(int customerId)
        {
            using (MySqlConnection conn = new MySqlConnection(_connnectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("DeleteCustomer", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_customerId", customerId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}