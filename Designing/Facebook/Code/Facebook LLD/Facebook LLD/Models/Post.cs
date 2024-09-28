using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook_LLD.Models
{
    public class Post
    {
        public User Author { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public List<Comment> Comments { get; set; }
        public int LikesCount { get; set; } = 0;
    }
}
