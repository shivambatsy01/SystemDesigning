using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator.Models
{
    public class DispatcherSystem
    {
        List<Cart> Carts;
        List<Floor> Floors;

        private DispatcherSystem myDispatcher;

        private DispatcherSystem()
        {
            
        }
        public DispatcherSystem CreateDispatcherSystem(List<Cart> carts, List<Floor> floor)
        {
            if(myDispatcher == null)
            { 
                myDispatcher = new DispatcherSystem(); 
                myDispatcher.Carts = carts;
                myDispatcher.Floors = floor;
            }

            return myDispatcher;
        }

        public DispatcherSystem GetDispatcherSystem { get => myDispatcher; }



        public void ScheduleCartStop(int floorNumber, Dir dir)
        {
            //find nearest cart in direction dir
            //if all cart in not direction, find the one which have minimum stops
            //add floor number as stoppage in cart stop list

            //Complex algo : Think about it
        }

    }
}
