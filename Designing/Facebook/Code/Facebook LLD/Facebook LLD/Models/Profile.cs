using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook_LLD.Models
{
    public class Profile
    {
        public Account Account { get; set; }  //composition
        public string Name {  get; set; }
        public string Address { get; set; }
        public string ProfilePhoto { get; set; }
        public DateTime Dob { get; set; }
    }
}
