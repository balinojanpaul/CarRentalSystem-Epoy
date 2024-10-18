using System.ComponentModel;
using System.Data;
using CarRentalSystem2.Models;
using CarRentalSystem2.Models;
using MySql.Data.MySqlClient;

namespace CarRentalSystem2.Handlers.QueryHandlers
{
    public class AnalyticsQueryHandler
    {
        private readonly string _connectionString;

        public AnalyticsQueryHandler(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        // Daily Sales and Customer Analytics
        public Analytics GetSalesAndCustomerAnalytics(string storedProcedure)
        {
            Analytics result = new Analytics();
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(storedProcedure, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            result.TotalSales = reader.GetDecimal("totalSales");
                            result.CustomerCount = reader.GetInt32("customerCount");
                        } 
                    }
                }
            }

            return result;
        }
    }
}