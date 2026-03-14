using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CarData
{
    public class CommentRepository
    {
        public List<Comment> GetCommentsByCarID(int carId)
        {
            List<Comment> comments = new List<Comment>();

            using (SqlConnection conn = CarDataDB.GetConnection())
            {
                string sql = "SELECT * FROM Comments WHERE CarID = @CarID ORDER BY DatePosted DESC";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CarID", carId);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Comment comment = new Comment
                        {
                            CommentID = (int)reader["CommentID"],
                            CarID = (int)reader["CarID"],
                            Username = reader["Username"].ToString(),
                            CommentText = reader["CommentText"].ToString(),
                            DatePosted = (DateTime)reader["DatePosted"]
                        };

                        comments.Add(comment);
                    }
                }
            }

            return comments;
        }

        public void AddComment(int carId, string username, string commentText)
        {
            using (SqlConnection conn = CarDataDB.GetConnection())
            {
                string sql = @"INSERT INTO Comments (CarID, Username, CommentText)
                               VALUES (@CarID, @Username, @CommentText)";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CarID", carId);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@CommentText", commentText);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}