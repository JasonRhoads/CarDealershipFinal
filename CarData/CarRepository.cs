using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CarData
{
    public class CarRepository
    {
        public List<CarRecord> GetAllCars()
        {
            List<CarRecord> cars = new List<CarRecord>();

            using (SqlConnection conn = CarDataDB.GetConnection())
            {
                string sql = "SELECT * FROM Cars";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        CarRecord car = new CarRecord
                        {
                            CarID = (int)reader["CarID"],
                            Make = reader["Make"].ToString(),
                            Model = reader["Model"].ToString(),
                            Color = reader["Color"].ToString(),
                            AgeYears = (int)reader["AgeYears"],
                            Price = (decimal)reader["Price"],
                            ExtraInfo = reader["ExtraInfo"].ToString(),
                            DateListed = (DateTime)reader["DateListed"],
                            SellerID = (int)reader["SellerID"]
                        };

                        cars.Add(car);
                    }
                }
            }

            return cars;
        }

        public List<CarRecord> GetCarsBySeller(int sellerId)
        {
            List<CarRecord> cars = new List<CarRecord>();

            using (SqlConnection conn = CarDataDB.GetConnection())
            {
                string sql = "SELECT * FROM Cars WHERE SellerID = @SellerID ORDER BY DateListed DESC";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@SellerID", sellerId);

                    conn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        CarRecord car = new CarRecord
                        {
                            CarID = (int)reader["CarID"],
                            Make = reader["Make"].ToString(),
                            Model = reader["Model"].ToString(),
                            Color = reader["Color"].ToString(),
                            AgeYears = (int)reader["AgeYears"],
                            Price = (decimal)reader["Price"],
                            ExtraInfo = reader["ExtraInfo"].ToString(),
                            DateListed = (DateTime)reader["DateListed"],
                            SellerID = (int)reader["SellerID"]
                        };

                        cars.Add(car);
                    }
                }
            }

            return cars;
        }

        public void DeleteCar(int carId)
        {
            using (SqlConnection conn = CarDataDB.GetConnection())
            {
                conn.Open();

                // Delete comments first
                string deleteCommentsSql = "DELETE FROM Comments WHERE CarID = @CarID";
                using (SqlCommand commentsCmd = new SqlCommand(deleteCommentsSql, conn))
                {
                    commentsCmd.Parameters.AddWithValue("@CarID", carId);
                    commentsCmd.ExecuteNonQuery();
                }

                // Then delete the car
                string deleteCarSql = "DELETE FROM Cars WHERE CarID = @CarID";
                using (SqlCommand carCmd = new SqlCommand(deleteCarSql, conn))
                {
                    carCmd.Parameters.AddWithValue("@CarID", carId);
                    carCmd.ExecuteNonQuery();
                }
            }
        }

        public void SaveCar(CarRecord car)
        {
            using (SqlConnection conn = CarDataDB.GetConnection())
            {
                string sql = @"INSERT INTO Cars
                       (Make, Model, Color, AgeYears, Price, ExtraInfo, DateListed, SellerID)
                       VALUES
                       (@Make, @Model, @Color, @AgeYears, @Price, @ExtraInfo, @DateListed, @SellerID)";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Make", car.Make);
                    cmd.Parameters.AddWithValue("@Model", car.Model);
                    cmd.Parameters.AddWithValue("@Color", car.Color);
                    cmd.Parameters.AddWithValue("@AgeYears", car.AgeYears);
                    cmd.Parameters.AddWithValue("@Price", car.Price);
                    cmd.Parameters.AddWithValue("@ExtraInfo", car.ExtraInfo);
                    cmd.Parameters.AddWithValue("@DateListed", car.DateListed);
                    cmd.Parameters.AddWithValue("@SellerID", car.SellerID);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}