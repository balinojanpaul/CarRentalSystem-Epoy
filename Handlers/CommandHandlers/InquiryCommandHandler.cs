using System;
using System.Data;
using CarRentalSystem2.Models;
using MySql.Data.MySqlClient;


namespace CarRentalSystem2.Handlers.CommandHandlers
{
    public class InquiryCommandHandler
{
    private readonly string _connectionString;

    public InquiryCommandHandler(string connectionString)
    {
        _connectionString = connectionString;
    }

    // Add a new inquiry
    public int AddInquiry(Inquiry inquiry)
    {
        using (MySqlConnection conn = new MySqlConnection(_connectionString))
        {
            conn.Open();
            using (MySqlCommand cmd = new MySqlCommand("AddInquiry", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_customerId", inquiry.CustomerId);
                cmd.Parameters.AddWithValue("p_carId", inquiry.CarId);
                cmd.Parameters.AddWithValue("p_status", inquiry.Status);
                cmd.Parameters.AddWithValue("p_date", inquiry.Date);
                // Execute the command and retrieve the CustomerId
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return Convert.ToInt32(reader["InquiryID"]);
                    }
                }
            }
        }

        return 0;
    }

    // Update an existing inquiry
    public void UpdateInquiry(Inquiry inquiry)
    {
        using (MySqlConnection conn = new MySqlConnection(_connectionString))
        {
            conn.Open();
            using (MySqlCommand cmd = new MySqlCommand("UpdateInquiry", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_inquiryId", inquiry.InquiryId);
                cmd.Parameters.AddWithValue("p_customerId", inquiry.CustomerId);
                cmd.Parameters.AddWithValue("p_carId", inquiry.CarId);
                cmd.Parameters.AddWithValue("p_status", inquiry.Status);
                cmd.Parameters.AddWithValue("p_date", inquiry.Date);
                cmd.ExecuteNonQuery();
            }
        }
    }

    
    public void UpdateInquiryStatus(int inquiryId, string newStatus)
    {
        using (MySqlConnection conn = new MySqlConnection(_connectionString))
        {
            conn.Open();
            using (MySqlCommand cmd = new MySqlCommand("UpdateInquiryStatus", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_inquiryId", inquiryId);
                cmd.Parameters.AddWithValue("p_newStatus", newStatus);
                cmd.ExecuteNonQuery();
            }
        }
    }

    // Delete an inquiry by ID
    public void DeleteInquiry(int inquiryId)
    {
        using (MySqlConnection conn = new MySqlConnection(_connectionString))
        {
            conn.Open();
            using (MySqlCommand cmd = new MySqlCommand("DeleteInquiry", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_inquiryId", inquiryId);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public void DeleteRentedInquiries()
    {
        using (MySqlConnection conn = new MySqlConnection(_connectionString))
        {
            conn.Open();
            using (MySqlCommand cmd = new MySqlCommand("DeleteRentedInquiry", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
        }
    }
}

}