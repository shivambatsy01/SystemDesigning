using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ti_tac_toe.Models
{
    internal class Cell
    {
        public int id;
        public int i { get; set; }
        public int j { get; set; }
        public bool IsMarked { get; set; }
        public Signs Mark { get; set; }
    }
}
