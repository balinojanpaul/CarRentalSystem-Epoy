using System.Data;
using System.Security.Cryptography;
using System.Text;
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
        public void SignUp(string username, string password, string role)
        {
            string passwordHash = HashPassword(password);
            
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("AddUser", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_username", username);
                    cmd.Parameters.AddWithValue("p_password", password);
                    cmd.Parameters.AddWithValue("p_role", role);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        
        
        // User Login
        public bool Login(string username, string password)
        {
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
                            return VerifyPassword(password, storedHash);
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
            string enteredHash = HashPassword(enteredPassword);
            return enteredHash == storedHash;
        }
    }
}