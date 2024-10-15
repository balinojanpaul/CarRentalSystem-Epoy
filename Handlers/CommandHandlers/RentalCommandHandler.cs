using System;
using System.Data;
using CarRentalSystem2.Models;
using MySql.Data.MySqlClient;

namespace CarRentalSystem2.Handlers.CommandHandlers
{
    public class RentalCommandHandler
{
    private readonly string _connectionString;

    public RentalCommandHandler(string connectionString)
    {
        _connectionString = connectionString;
    }

    // Add a new rental
    public int AddRental(Rental rental)
    {
        using (MySqlConnection conn = new MySqlConnection(_connectionString))
        {
            conn.Open();
            using (MySqlCommand cmd = new MySqlCommand("AddRental", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_carId", rental.CarId);
                cmd.Parameters.AddWithValue("p_customerId", rental.CustomerId);
                cmd.Parameters.AddWithValue("p_startDate", rental.StartDate);
                cmd.Parameters.AddWithValue("p_endDate", rental.EndDate);
                cmd.Parameters.AddWithValue("p_status", rental.Status);
                cmd.ExecuteNonQuery();
                
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return Convert.ToInt32(reader["RentalId"]);
                    }
                }
            }
        }

        return 0;
    }

    // Update an existing rental
    public void UpdateRental(Rental rental)
    {
        using (MySqlConnection conn = new MySqlConnection(_connectionString))
        {
            conn.Open();
            using (MySqlCommand cmd = new MySqlCommand("UpdateRental", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_rentalId", rental.RentalId);
                cmd.Parameters.AddWithValue("p_carId", rental.CarId);
                cmd.Parameters.AddWithValue("p_customerId", rental.CustomerId);
                cmd.Parameters.AddWithValue("p_startDate", rental.StartDate);
                cmd.Parameters.AddWithValue("p_endDate", rental.EndDate);
                cmd.Parameters.AddWithValue("p_status", rental.Status);
                
                cmd.ExecuteNonQuery();
            }
        }
    }

    // Delete a rental by ID
    public void DeleteRental(int rentalId)
    {
        using (MySqlConnection conn = new MySqlConnection(_connectionString))
        {
            conn.Open();
            using (MySqlCommand cmd = new MySqlCommand("DeleteRental", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_rentalId", rentalId);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
}