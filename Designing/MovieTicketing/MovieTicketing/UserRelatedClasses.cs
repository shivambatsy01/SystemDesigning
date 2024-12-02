using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketing
{
    //objects:
    /*
     * User
     * Customer
     * Ticketing agent
     * Admin/Operator
     * 
     * */

    class User
    {
        public int Id { get; set; }
        public string name;

        public void MakeReservation(User user, List<Seat> seats)
        {

        }
    }

    class Customer : User
    {
        public string username; public string password;
        public bool HasLoggedIn = false;

        public void LogIn(string username, string password)
        {

        }

        public List<Ticket> MakeBooking(Reservations reservation)
        {
            List<Ticket> ticketList = new List<Ticket>();   
            return ticketList;
        }
    }

    class TicketingAgent
    {

    }

    class Operator : User
    {
        public void AddMovie(Movie movie) { }
        public void RemoveMovie(Movie movie) { }

        public void AddShow(Show show, Theater theater) { }
        public void RemoveShow(Show show, Theater theater) { }
    }
}
