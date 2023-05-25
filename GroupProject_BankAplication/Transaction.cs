using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject_BankAplication
{
    public struct Transaction
    {
        // Transaction Properties
        public string AccountNumber { get; }
        public double Amount { get; }
        public Person Originator { get; }
        public DayTime Time { get; }

        // Transaction Constructor
        public Transaction( string accountNumber, double amount, Person person )
        {
            AccountNumber = accountNumber;
            Amount = amount;
            Originator = person;
            Time = Utils.Time;
        }

        // Transaction Methods
        public override string ToString()
        {
            string transactionType = Amount >= 0 ? "deposited" : "withdrawn"; // Determine if it's deposit or withdraw
            return $"{AccountNumber} ${Math.Abs(Amount):F2} {transactionType} by {Originator} on {Time}";
        }
    }
}
