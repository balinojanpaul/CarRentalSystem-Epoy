using System.Data;
using System.Security.Cryptography;
using System.Text;
using CarRentalSystem2.Models;
using MySql.Data.MySqlClient;

namespace CarRentalSystem2.Common
{
    public class AuthenticationServices
    {
        private string _connectionString;
        
        public AuthenticationServices(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        // Register a user
        public void SignUp(UserAccount user)
        {
            string passwordHash = HashPassword(user.Password);
            
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("AddUser", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_username", user.UserName);
                    cmd.Parameters.AddWithValue("p_password", passwordHash);
                    cmd.Parameters.AddWithValue("p_role", user.Role);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        
        
        // User Login
        public bool Login(string username, string password)
        {
            string hashedPassword = HashPassword(password);
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("GetHashByUsername", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_username", username);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedHash = reader["password"].ToString();
                            return VerifyPassword(hashedPassword, storedHash);
                        }
                    }
                }
            }

            return false;
        }
        
        

        // ---------------------- Helper Functions ---------------------- \\
        public string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }

                return builder.ToString();
            }
        }

        public bool VerifyPassword(string enteredPassword, string storedHash)
        {
            string enteredHash = enteredPassword;
            return enteredHash == storedHash;
        }
    }
}