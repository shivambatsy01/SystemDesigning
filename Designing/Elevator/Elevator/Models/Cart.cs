using Elevator.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator.Models
{
    public class Cart
    {
        private int maxFloor, minFloor;
        public List<IButton> Buttons { get; set; }
        private int currFloor = 0;
        private Dir cartDirection = Dir.Up;
        private CartState state = CartState.Stopped;
        List<int> nextStop = new List<int>(); //Try to use heap

        public Cart(int max, int min, IButtonCommand command)
        {
            Buttons = new List<IButton>();
            for(int floor = min; floor <= max; floor++)
            {
                Buttons.Add(new CartButton(this, floor, command));
            }
            maxFloor = max;
            minFloor = min;
        }



        public void Move()  //only system will move the cart
        {
            if(currFloor == maxFloor && cartDirection == Dir.Up)
            {
                cartDirection = Dir.Down; 
            }
            if (currFloor == minFloor && cartDirection == Dir.Down)
            {
                cartDirection = Dir.Up;
            }

            currFloor = (cartDirection == Dir.Up) ? currFloor + 1 : currFloor - 1;
            if(nextStop.Contains(currFloor))
            {
                state = CartState.Stopped;
                nextStop.Remove(currFloor);
                //or thread.sleep() if multi threading is using for carts or task
                //wait for 30 sec, or till door pressed (door functionality is not here)
            }

            state = CartState.Moving;
        }

        public void AddStop(int floorNumber) //will be invoked by button command
        {
            nextStop.Add(floorNumber);
        }
    }
}
