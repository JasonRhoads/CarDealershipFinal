using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace CarData
{
    /// <summary>
    /// Gets car age ranges from the database.
    /// </summary>
    public class CarAgeRangesDB
    {
        /// <summary>
        /// Gets the age range data from the database and returns it as a dictionary.
        /// ex. { "Under 5 years" : [0, 4], "5 to 10 years" : [5, 10] }
        /// </summary>
        /// <returns>
        /// Dictionary with keys equal to the display names of the ranges
        /// and values equal to the minimum and maximum ages.
        /// </returns>
        public static Dictionary<string, List<int>> Get()
        {
            var result = new Dictionary<string, List<int>>();

            try
            {
                using (SqlConnection connection = CarDataDB.GetConnection())
                {
                    string sql = @"SELECT DisplayText, MinAge, MaxAge
                                   FROM CarAgeRanges
                                   ORDER BY MinAge";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string displayText = reader["DisplayText"].ToString();
                                int minAge = Convert.ToInt32(reader["MinAge"]);
                                int maxAge = Convert.ToInt32(reader["MaxAge"]);

                                result.Add(displayText, new List<int> { minAge, maxAge });
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Database error while loading car age ranges: " + ex.Message);
            }

            return result;
        }

        /// <summary>
        /// Gets the range names as a list from the existing dictionary.
        /// </summary>
        /// <returns>List of human-readable age range names.</returns>
        public static List<string> GetRanges()
        {
            var result = Get();
            return result.Keys.ToList();
        }
    }
}