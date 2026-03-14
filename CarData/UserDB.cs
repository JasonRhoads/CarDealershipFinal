using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CarData
{
    public class UserDB
    {
        /// <summary>
        /// Gets list of users with username as key
        /// and password/role as values.
        /// </summary>
        public static Dictionary<string, string[]> Get()
        {
            Dictionary<string, string[]> output = new Dictionary<string, string[]>();

            try
            {
                using (SqlConnection connection = CarDataDB.GetConnection())
                {
                    string sql = "SELECT UserID, Username, PasswordHash, Role FROM Users";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string userID = reader["UserID"].ToString();
                                string username = reader["Username"].ToString();
                                string password = reader["PasswordHash"].ToString();
                                string role = reader["Role"].ToString();

                                string[] val = new string[3];
                                val[0] = password;
                                val[1] = role;
                                val[2] = userID;

                                output.Add(username, val);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Database error while loading users: " + ex.Message);
            }

            return output;
        }

        /// <summary>
        /// Adds a user to the Users table.
        /// </summary>
        public static void Add(string username, string passwordHash, string role)
        {
            try
            {
                using (SqlConnection connection = CarDataDB.GetConnection())
                {
                    string sql = @"INSERT INTO Users (Username, PasswordHash, Role)
                                   VALUES (@Username, @PasswordHash, @Role)";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@PasswordHash", passwordHash);
                        command.Parameters.AddWithValue("@Role", role);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Database error while adding user: " + ex.Message);
            }
        }

        /// <summary>
        /// Removes a user by username.
        /// </summary>
        public static void Remove(string username)
        {
            try
            {
                using (SqlConnection connection = CarDataDB.GetConnection())
                {
                    string sql = "DELETE FROM Users WHERE Username = @Username";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Database error while removing user: " + ex.Message);
            }
        }
    }
}