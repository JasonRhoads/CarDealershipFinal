using System.Collections.Generic;
using CarData;

namespace CarBusiness
{
    public class CommentService
    {
        private CommentRepository repo = new CommentRepository();

        public List<Comment> GetComments(int carId)
        {
            return repo.GetCommentsByCarID(carId);
        }

        public void AddComment(int carId, string username, string commentText)
        {
            repo.AddComment(carId, username, commentText);
        }
    }
}