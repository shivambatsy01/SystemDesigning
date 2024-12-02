using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }


    public class ATMMachine
    {
        //focusing on withdrawl only
        public IState presentState;
        public ATMMachine()
        {
            presentState = new ReadyState(this);
            //all objects created in Ctor
        }

        public int EnteredPin;
        public double EnteredAmount;
        public double CashPresent;
        public CardReader cardReader;
        public Printer printer;
        public Keypad keypad;
        public NetworkOperations networkOperations;
        public CashDispenser cashDispenser;

        public void EnterCard()
        {
            presentState.EnterCard();
        }

        public void AbortTransaction()
        {
            presentState.AbortTransaction();
        }

        public void EnterPin()
        {
            presentState.EnterPin();
        }

        public void EnterAmount()
        {
            presentState.EnterAmount();
        }

        public void EjectCard()
        {
            presentState.EjectCard();
        }

        public void SetState(IState newState)
        {
            Console.WriteLine($"Changing state from {nameof(presentState)} to {nameof(newState)}");
            presentState = newState;
        }

    }

    public class CardReader
    {
        public void ReadCard() { }
    }

    public class Keypad
    {
        public void ReadPin()
        {

        }
        public void ReadAmount()
        {

        }
    }

    public class Printer
    {
        public void PrintReciept()
        {

        }
    }

    public class NetworkOperations
    {
        public void ValidatePin()
        {

        }

        public void ValidateBankAmount()
        {

        }

        public void GetCardDetails()
        {

        }

        public void ValidateCard()
        {

        }
    }

    public class CashDispenser // Based on chain of responsibility principal for dispensing different currency denominations
    {
        public void Dispencecash(double amount)
        {

        }
    }





    public class Card
    {

    }

    public class BankAccount
    {

    }
}
