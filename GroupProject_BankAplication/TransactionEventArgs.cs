using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject_BankAplication
{
    public class TransactionEventArgs : LoginEventArgs
    {
        // TransactionEventArgs Property
        public double Amount { get; }

        // TransactionEventArgs Constructor
        public TransactionEventArgs( string name, double amount, bool success ) 
            : base( name, success )
        {
            Amount = amount;
        }
    }
}
