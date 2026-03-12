using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CarData
{
    public class CarMakesDB
    {
        public static List<string> Get()
        {
            List<string> makes = new List<string>();

            try
            {
                using (SqlConnection connection = CarDataDB.GetConnection())
                {
                    string sql = "SELECT Make FROM CarMakes ORDER BY Make";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                makes.Add(reader["Make"].ToString());
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Database error while loading car makes: " + ex.Message);
            }

            return makes;
        }
    }
}