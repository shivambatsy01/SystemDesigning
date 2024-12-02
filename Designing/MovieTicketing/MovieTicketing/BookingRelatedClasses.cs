using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketing
{
    //objects:
    /* 
     * Reservation : can have multiple seats book
     * Booking : can have multiple tickets
     * Tickets : One ticket per seat
     * 
     * System
     * */

    class Reservations
    {
        public List<Seat> Seats;
        DateTime ReservationTime;
        User MadeBy; //only checking
        public bool HasBooked = false;
    }

    class Booking
    {
        public Reservations Reservations;
        public List<Ticket> Tickets;
        public DateTime BookingTime;
        public Customer bookedBy;
    }

    class Ticket
    {
        public int id;
        public Seat seat;
        public DateTime time;
        public User bookedBy;
    }
}
