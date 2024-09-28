using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook_LLD.Models
{
    enum RequestStatus
    {
        pending, accepted, discarded
    }
    public class Request
    {
        RequestStatus status;
        public User Sender { get; set; }
        public User Receiver { get; set; }
        public DateTime Date { get; set; }
    }
}
