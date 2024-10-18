using System.Data;
using CarRentalSystem2.Models;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Generators;

namespace CarRentalSystem2.Handlers.CommandHandlers
{
    public class UserAccountCommandHandler
    {
        private readonly string _connectionString;

        public UserAccountCommandHandler(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        
        // Register a new user with a Hashed Password
        public void RegisterUser(UserAccount user)
        {
            string passwordHash = HasPassword(user.Password);
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("AddUser", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_username", user.UserName);
                    cmd.Parameters.AddWithValue("p_password", user.Password);
                    cmd.Parameters.AddWithValue("p_role", user.Role);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        
        
        // Update a user's password
        public void UpdatePassword(int userId, string newPassword)
        {
            // Hash first the password
            string newPasswordHash = null;

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("UpdateUserPassword", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_userID", userId);
                    cmd.Parameters.AddWithValue("p_password", newPassword);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        
        
        // Update user information
        public void UpdateUserDetails(UserAccount account, int userId)
        {
            // Hash first the password
            string newPasswordHash = null;
            
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("UpdateUser", conn))
                {
                    cmd.Parameters.AddWithValue("p_userId", userId);
                    cmd.Parameters.AddWithValue("p_username", account.UserName);
                    cmd.Parameters.AddWithValue("p_password", account.Password);
                    cmd.Parameters.AddWithValue("p_role", account.Role);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        
        
        // Delete a user by ID
        public void DeleteUser(int userId)
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("DeleteUser", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_userId", userId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        
        
        // TODO: Implement a hashing method for this, kapoy pa
        // Helper: Hash password using a secure method
        private string HasPassword(string password)
        {
            return "";
        }
    }
}