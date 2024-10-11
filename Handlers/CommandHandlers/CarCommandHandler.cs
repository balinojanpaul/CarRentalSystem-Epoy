using System.Data;
using CarRentalSystem2.Models;
using MySql.Data.MySqlClient;

namespace CarRentalSystem2.Handlers.CommandHandlers
{
    public class CarCommandHandler
    {
        private readonly string _connectionString;

        public CarCommandHandler(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        // Add a new car
        public void AddCar(Car car)
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("AddCar", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_brand", car.Brand);
                    cmd.Parameters.AddWithValue("p_model", car.Model);
                    cmd.Parameters.AddWithValue("p_pricePerDay", car.PricePerDay);
                    cmd.Parameters.AddWithValue("p_availability", car.Availability);
                    cmd.Parameters.AddWithValue("p_imagePath", car.ImagePath);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        
        
        // Update an existing car
        public void UpdateCar(Car car)
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("UpdateCar", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_carId", car.CarId);
                    cmd.Parameters.AddWithValue("p_brand", car.Brand);
                    cmd.Parameters.AddWithValue("p_model", car.Model);
                    cmd.Parameters.AddWithValue("p_pricePerDay", car.PricePerDay);
                    cmd.Parameters.AddWithValue("p_availability", car.Availability);
                    cmd.Parameters.AddWithValue("p_imagePath", car.ImagePath);
                    
                    cmd.ExecuteNonQuery();
                }
            }
        }
        
        
        // Delete a car by ID
        public void DeleteCar(int carId)
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("DeleteCar", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_carId", carId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        
        // Update a car availability after renting it out
        public void UpdateCarAvailability(int carId)
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("UpdateCarAvailability", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_carId", carId);
                    cmd.ExecuteNonQuery(); // Execute the stored procedure
                }
            }
        }
    }
}