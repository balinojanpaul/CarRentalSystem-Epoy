using System;
using System.Collections.Generic;
using System.Data;
using CarRentalSystem2.Models;
using MySql.Data.MySqlClient;

namespace CarRentalSystem2.Handlers.QueryHandlers
{
    public class RentalQueryHandler
    {
        private readonly string _connectionString;

        public RentalQueryHandler(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        
        // Fetch all rentals
        public List<Rental> GetAllRentals()
        {
            var rentals = new List<Rental>();
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("GetAllRentals", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            rentals.Add(new Rental
                            {
                                RentalId = (int)reader["ID"],
                                CarId = (int)reader["carID"],
                                CustomerId = (int)reader["customerID"],
                                StartDate = (DateTime)reader["startDate"],
                                EndDate = (DateTime)reader["endDate"],
                                Status = reader["status"].ToString(),
                                TotalAmount = (decimal)reader["totalAmount"]
                            });
                        }
                    }
                }
            }

            return rentals;
        }
        
        // Fetch a rental by ID
        public Rental GetRentalById(int rentalId)
        {
            Rental rental = null;
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("GetRentalById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_rentalId", rentalId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            rental = new Rental
                            {
                                RentalId = (int)reader["ID"],
                                CarId = (int)reader["carID"],
                                CustomerId = (int)reader["customerID"],
                                StartDate = (DateTime)reader["startDate"],
                                EndDate = (DateTime)reader["endDate"],
                                Status = reader["status"].ToString(),
                                TotalAmount = (decimal)reader["totalAmount"]
                            };
                        }
                    }
                }
            }
            return rental;
        }
    }
}