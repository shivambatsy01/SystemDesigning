using Elevator.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator.Models
{
    public class Floor
    {
        private int floorNumber = -1;
        private IButton UpButton;
        private IButton DownButton;

        public Floor(int floorNumber, IButtonCommand buttonCommand)
        {
            this.floorNumber = floorNumber;
            UpButton = new FloorButton(this, buttonCommand);

        }

        public int FloorNumber { get => floorNumber; set => floorNumber = value; }
    }
}
