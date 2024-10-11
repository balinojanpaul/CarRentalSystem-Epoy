using System.Data;
using CarRentalSystem2.Models;
using MySql.Data.MySqlClient;

namespace CarRentalSystem2.Handlers.CommandHandlers
{
    public class UserRentalCommandHandler
    {
        private readonly string _connectionString;

        public UserRentalCommandHandler(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Add a new user rental
        public void AddUserRental(UserRental userRental)
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("AddUserRental", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_userID", userRental.UserRentalId);
                    cmd.Parameters.AddWithValue("p_rentalID", userRental.RentalId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Update an existing user rental
        public void UpdateUserRental(UserRental userRental)
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("UpdateUserRental", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_UserRentalId", userRental.UserRentalId);
                    cmd.Parameters.AddWithValue("p_userID", userRental.UserId);
                    cmd.Parameters.AddWithValue("p_rentalID", userRental.RentalId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Delete a user rental by ID
        public void DeleteUserRental(int userRentalId)
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("DeleteUserRental", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_UserRentalId", userRentalId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }

}