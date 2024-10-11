using System.Collections.Generic;
using System.Data;
using CarRentalSystem2.Models;
using MySql.Data.MySqlClient;

namespace CarRentalSystem2.Handlers.QueryHandlers
{
    public class UserRentalQueryHandler
    {
        private readonly string _connectionString;

        public UserRentalQueryHandler(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Fetch all user rentals
        public List<UserRental> GetAllUserRentals()
        {
            var userRentals = new List<UserRental>();
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("GetAllUserRentals", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            userRentals.Add(new UserRental
                            {
                                UserRentalId = (int)reader["ID"],
                                UserId = (int)reader["userID"],
                                RentalId = (int)reader["rentalID"]
                            });
                        }
                    }
                }
            }

            return userRentals;
        }

        // Fetch a user rental by ID
        public UserRental GetUserRentalById(int userRentalId)
        {
            UserRental userRental = null;
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("GetUserRentalById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_userrental_id", userRentalId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userRental = new UserRental
                            {
                                UserRentalId = (int)reader["ID"],
                                UserId = (int)reader["userID"],
                                RentalId = (int)reader["rentalID"]
                            };
                        }
                    }
                }
            }

            return userRental;
        }
    }
}