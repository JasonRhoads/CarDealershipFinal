using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace CarData
{
    /// <summary>
    /// Gets car price ranges from the database.
    /// </summary>
    public class CarPriceRangesDB
    {
        /// <summary>
        /// Gets the price range data from the database and returns it as a dictionary.
        /// ex. { "Under $5,000" : [0, 4999.99], "$5,000 to $20,000" : [5000, 20000] }
        /// </summary>
        /// <returns>
        /// Dictionary with keys equal to the display names of the ranges
        /// and values equal to the minimum and maximum prices.
        /// </returns>
        public static Dictionary<string, List<decimal>> Get()
        {
            var result = new Dictionary<string, List<decimal>>();

            try
            {
                using (SqlConnection connection = CarDataDB.GetConnection())
                {
                    string sql = @"SELECT DisplayText, MinPrice, MaxPrice
                                   FROM CarPriceRanges
                                   ORDER BY MinPrice";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string displayText = reader["DisplayText"].ToString();
                                decimal minPrice = Convert.ToDecimal(reader["MinPrice"]);
                                decimal maxPrice = Convert.ToDecimal(reader["MaxPrice"]);

                                result.Add(displayText, new List<decimal> { minPrice, maxPrice });
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Database error while loading car price ranges: " + ex.Message);
            }

            return result;
        }

        /// <summary>
        /// Gets the range names as a list from the existing dictionary.
        /// </summary>
        /// <returns>List of human-readable price range names.</returns>
        public static List<string> GetRanges()
        {
            var result = Get();
            return result.Keys.ToList();
        }
    }
}