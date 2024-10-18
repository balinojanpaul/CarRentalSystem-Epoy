using System;
using System.Collections.Generic;
using System.Data;
// using System.Windows.Documents;
using CarRentalSystem2.Models;
using MySql.Data.MySqlClient;

namespace CarRentalSystem2.Handlers.QueryHandlers
{
    public class CarQueryHandler
    {
        private readonly string _connectionString;

        public CarQueryHandler(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        // Fetch all cars
        public List<Car> GetAllCars()
        {
            var cars = new List<Car>();

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("GetAllCars", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cars.Add(new Car
                            {
                                CarId = (int)reader["ID"],
                                Brand = reader["brand"].ToString(),
                                Model = reader["model"].ToString(),
                                PricePerDay = (decimal)reader["pricePerDay"],
                                Availability = Convert.ToBoolean(Convert.ToInt32(reader["availability"])),
                                ImagePath = reader["imagePath"].ToString()
                            });
                        }
                    }
                }
            }

            return cars;
        }
        
        
        // Fetch a car by ID
        public Car GetCarById( int carId)
        {
            Car car = null;

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("GetCarById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("p_carId", carId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            car = new Car
                            {
                                CarId = reader["ID"] != DBNull.Value ? Convert.ToInt32(reader["ID"]) : 0,
                                Brand = reader["brand"].ToString(),
                                Model = reader["model"].ToString(),
                                PricePerDay = (decimal)reader["pricePerDay"],
                                Availability = Convert.ToBoolean(Convert.ToInt32(reader["availability"])),
                                ImagePath = reader["imagePath"].ToString()
                            };
                        }
                    }
                }
            }

            return car;
        }

        public List<Car> GetAvailableCars()
        {
            var cars = new List<Car>();

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("GetAvailableCars", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cars.Add(new Car
                            {
                                CarId = reader["ID"] != DBNull.Value ? Convert.ToInt32(reader["ID"]) : 0,
                                Brand = reader["Brand"].ToString(),
                                Model = reader["Model"].ToString(),
                                PricePerDay = (decimal)reader["PricePerDay"],
                                Availability = Convert.ToBoolean(Convert.ToInt32(reader["availability"])),
                                ImagePath = reader["ImagePath"].ToString()
                            });
                        }
                    }
                }
            }

            return cars;
        }

        
        public List<Car> SearchCarsWithFilter(string column, string searchTerm)
        {
            var cars = new List<Car>();

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("SearchCarsWithFilter", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add the column and search term parameters
                    cmd.Parameters.AddWithValue("p_column", column);
                    cmd.Parameters.AddWithValue("p_searchTerm", searchTerm);

                    // Execute the query and read the results
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cars.Add(new Car
                            {
                                CarId = reader["carId"] != DBNull.Value ? Convert.ToInt32(reader["carId"]) : 0,
                                Brand = reader["brand"].ToString(),
                                Model = reader["model"].ToString(),
                                PricePerDay = reader["pricePerDay"] != DBNull.Value ? Convert.ToDecimal(reader["pricePerDay"]) : 0,
                                Availability = reader["availability"] != DBNull.Value && Convert.ToBoolean(Convert.ToInt32(reader["availability"])),
                                ImagePath = reader["imagePath"].ToString()
                            });
                        }
                    }
                }
            }

            return cars;
        }
    }
}