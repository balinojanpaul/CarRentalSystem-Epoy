using System.Data;
using CarRentalSystem2.Models;
using MySql.Data.MySqlClient;

namespace CarRentalSystem2.Handlers.QueryHandlers
{
    public class UserAccountQueryHandler
    {
        private readonly string _connectionString;

        public UserAccountQueryHandler(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        // Fetch a user by username (for login)
        public UserAccount GetUserByUsername(string username)
        {
            UserAccount user = null;

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("GetUserByUsername", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_username", username);
                    using (MySqlDataReader reader = (MySqlDataReader)cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new UserAccount
                            {
                                UserId = (int)reader["userID"],
                                UserName = reader["username"].ToString(),
                                Password = reader["password"].ToString(),
                                Role = reader["role"].ToString()
                            };
                        }
                    }
                }
            }

            return user;
        }
        
        // Verify a user's login credentials
        public bool VerifyLogin(string username, string password)
        {
            var user = GetUserByUsername(username);
            if (user != null && password == user.Password)
            {
                return true;
            }

            return false;
        }
    }
}