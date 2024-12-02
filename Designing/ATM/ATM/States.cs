using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public abstract class IState
    {
        protected ATMMachine atmMachine;
        protected IState(ATMMachine machine)
        {
            this.atmMachine = machine;
        }


        public abstract void EnterCard();
        public abstract void AbortTransaction();
        public abstract void EnterPin();
        public abstract void EnterAmount();
        public abstract void EjectCard();

        public string GetStateName()
        {
            return "";
        }
    }


    public class ReadyState : IState
    {
        public ReadyState(ATMMachine machine) : base(machine)
        {
            
        }

        public override void EnterCard() //work in ready state
        {
            atmMachine.cardReader.ReadCard();
            atmMachine.networkOperations.ValidateCard();
            atmMachine.networkOperations.GetCardDetails();
            atmMachine.SetState(new PinWaitingState(atmMachine));
        }

        public override void AbortTransaction()
        {
            //Can't abort transaction as it is not started
        }

        public override void EnterPin()
        {
            Console.WriteLine("In ready state. Please enter card first");
        }

        public override void EnterAmount()
        {
            Console.WriteLine("In ready state. Please enter card first");
        }

        public override void EjectCard()
        {
            throw new NotImplementedException(); //Can;t do as card is not inserted yet
        }
    }

    public class PinWaitingState : IState
    {
        public PinWaitingState(ATMMachine machine) : base(machine)
        {

        }
        public override void EnterCard()
        {
            throw new NotImplementedException(); //wont work as card is already inserted
        }

        public override void AbortTransaction()
        {
            Console.WriteLine("Aborting transaction, take your card");
            atmMachine.SetState(new ReadyState(atmMachine));

        }

        public override void EnterPin()
        {
            //validate pin first
            atmMachine.SetState(new AmountWaitingState(atmMachine));
        }

        public override void EnterAmount()
        {
            throw new NotImplementedException();
        }

        public override void EjectCard()
        {
            throw new NotImplementedException();
        }
    }

    public class AmountWaitingState : IState
    {
        public AmountWaitingState(ATMMachine machine) : base(machine)
        {

        }
        public override void EnterCard()
        {
            throw new NotImplementedException();
        }

        public override void AbortTransaction()
        {
            throw new NotImplementedException();
        }

        public override void EnterPin()
        {
            throw new NotImplementedException();
        }

        public override void EnterAmount()
        {
            //validate bank amount
            //validate ATM amount
            atmMachine.SetState(new DispensingCashState(atmMachine));
        }

        public override void EjectCard()
        {
            Console.WriteLine("Aborting transaction due to card ejection");
            atmMachine.SetState(new ReadyState(atmMachine));
        }
    }

    public class DispensingCashState : IState
    {
        public DispensingCashState(ATMMachine machine) : base(machine)
        {
            //dispense cash and release card
            atmMachine.cashDispenser.Dispencecash(atmMachine.EnteredAmount);
        }
        public override void EnterCard()
        {
            throw new NotImplementedException();
        }

        public override void AbortTransaction()
        {
            throw new NotImplementedException();
        }

        public override void EnterPin()
        {
            throw new NotImplementedException();
        }

        public override void EnterAmount()
        {
            throw new NotImplementedException();
        }

        public override void EjectCard()
        {
            throw new NotImplementedException();
        }
    }
}
