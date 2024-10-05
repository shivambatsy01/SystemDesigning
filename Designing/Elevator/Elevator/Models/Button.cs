using Elevator.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator.Models
{
    public abstract class IButton
    {
        protected IButtonCommand _command;
        ButtonState ButtonState { get; set; }
        public abstract void Press();
    }

    internal class FloorButton : IButton
    {
        private Floor floor;
        private Dir dir;
        private ButtonState buttonState;
        
        
        public FloorButton(Floor floor, IButtonCommand buttonCommand)
        {
            buttonState = ButtonState.Unpressed;
            _command = buttonCommand;
        }

        public ButtonState ButtonState
        {
            get => buttonState;
            set => buttonState = value;
        }

        public override void Press()
        {
            if(ButtonState == ButtonState.Unpressed)
            {
                ButtonState = ButtonState.Pressed;
                _command.ExecuteCommand((floor.FloorNumber as Object, dir as object));

            }
        }
    }

    internal class CartButton : IButton
    {
        private Cart cart;
        int floorNumber;
        private ButtonState buttonState;
        public CartButton(Cart cart, int num, IButtonCommand command)
        {
            this.cart = cart;
            this.floorNumber = num;
            buttonState = ButtonState.Unpressed;
            _command = command;
        }

        public ButtonState ButtonState
        {
            get => buttonState;
            set => buttonState = value;
        }

        public override void Press()
        {
            if (ButtonState == ButtonState.Unpressed)   
            {
                ButtonState = ButtonState.Pressed;
                _command.ExecuteCommand((floorNumber as Object, cart as object));
            }
        }
    }
}
