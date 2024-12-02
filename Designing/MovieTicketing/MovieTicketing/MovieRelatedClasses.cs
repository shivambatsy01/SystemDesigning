using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketing
{
    //objects:
    /*
     * Seats
     * Show
     * Theater
     * Movie
     * City
     * */

    public enum SeatStatus
    {
        Available,
        Reserved,
        Booked
    }

    public class Seat
    {
        public int id;
        public SeatStatus status;
        public Show Show;
        int price;
        string category;

        public void SetSeatCategory(string categoryName)
        {
            category = categoryName;
        }
        public void SetPrice(int price)
        {
            this.price = price;
        }
        public int GetPrice { get => price; }
    }

    //seat categorisation:
    //either use enum in seat, or use inheritence, or it's just determined by UI based on price
    public class SilverSeat : Seat
    {

    }
    public class GoldSeat : Seat
    {

    }
    public class DiamondSeat : Seat
    {

    }

    public class Movie
    {
        public string Name;
        public string Description;
        public int Id;
        public List<string> Tags;
        public List<string> Actors;
        public List<Show> Shows; //all shows of movie
        public List<Theater> Theaters; //all theaters in which it is runnning
    }

    public class Show
    {
        public int id;
        public List<Seat> seats;
        public Movie movie;
        public Theater Theater;
        public DateTime Time;

        public void ShowAvailableSeats()
        {

        }
        
    }
   
    public class Theater
    {
        public int id;
        public City city; //association
        public List<Movie> movies; //all movies in theater
    }

    public class City
    {
        public string name;
        public int PinCode;
        public List<Theater> theaters;
    }
}
