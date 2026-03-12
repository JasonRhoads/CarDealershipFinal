using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CarData
{
    public class CarColorsDB
    {
        public static List<string> Get()
        {
            List<string> colors = new List<string>();

            try
            {
                using (SqlConnection connection = CarDataDB.GetConnection())
                {
                    string sql = "SELECT Color FROM CarColors ORDER BY Color";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                colors.Add(reader["Color"].ToString());
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Database error while loading car colors: " + ex.Message);
            }

            return colors;
        }
    }
}