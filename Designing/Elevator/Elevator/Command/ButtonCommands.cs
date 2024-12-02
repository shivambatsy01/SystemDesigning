using Elevator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Elevator.Command
{
    public interface IButtonCommand
    {
        void ExecuteCommand((object, object) commandTuple);
    }

    /*
    //Reason to avoid: CartButtonCommands reciever is cart which we already having in button object as association
    thus it doesn't make sense to create command, howver we can create but it will be complex as reciever for button panels is different

    Basically floor and cart commands are from different invokers, different recievers and different data needs to be passed
    Thus either create two command interfaces with different execute signature or increase complexity to create object to be passed in command
    */

    //The below inheritence is not fully SOLID compaliance, as it is too complex

    public class CartButtonCommand : IButtonCommand
    {
        public CartButtonCommand()
        {

        }

        public void ExecuteCommand((object, object) commandTuple)  //<cart, floorNumber> 
        {
            int floorNumber = (int)commandTuple.Item1;
            Cart cart = (Cart)commandTuple.Item2;
          
            cart.AddStop(floorNumber);
        }
    }

    public class FloorButtonCommand : IButtonCommand
    {
        private DispatcherSystem system; //association
        public FloorButtonCommand(DispatcherSystem system)
        {
            this.system = system;
        }

        public void ExecuteCommand((object, object) commandTuple)
        {
            int floorNumber = (int)commandTuple.Item1;
            Dir dir = (Dir)commandTuple.Item2;

            system.ScheduleCartStop(floorNumber, dir);
        }
    }
}
