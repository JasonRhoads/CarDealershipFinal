using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarData
{
    public class Comment
    {
        public int CommentID { get; set; }
        public int CarID { get; set; }
        public string Username { get; set; }
        public string CommentText { get; set; }
        public DateTime DatePosted { get; set; }
    }
}
