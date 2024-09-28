using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook_LLD.Models
{
    public class Comment
    {
        public User Author { get; set; }
        public Post Post { get; set; }
        public DateTime Date { get; set; }

        public string Text {  get; set; }
    }
}
