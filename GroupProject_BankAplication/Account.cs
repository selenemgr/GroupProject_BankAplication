using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace GroupProject_BankAplication
{
    public abstract class Account
    {
        // Account Fields
        private static int LastNumber = 100000;
        protected readonly List<Person> Users;
        public readonly List<Transaction> Transactions;

        // Account Properties
        public string Number { get; }
        public double Balance { get; protected set; }
        public double LowestBalance { get; protected set; }

        // Account Event
        public virtual event EventHandler<EventArgs> OnTransaction;

        // Constructor
        public Account( string type, double balance)
        {
            Number = type + LastNumber.ToString();
            LastNumber++;
            Balance = balance;
            LowestBalance = balance;
            Transactions = new List<Transaction>();
            Users = new List<Person>();
        }

        // Account Methods
        public void Deposit( double amount, Person person )
        {
            Balance += amount;
            if ( Balance < LowestBalance )
            {
                LowestBalance = Balance;
            }
            Transaction transaction = new Transaction( Number, amount, person );
            Transactions.Add( transaction );
        }

        public void AddUser( Person person ) 
        {
            Users.Add( person ); 
        }

        public bool IsUser( string name )
        {
            return Users.Any( x => x.Name == name ); 
        }

        public abstract void PrepareMonthlyReport();

        protected virtual void OnTransactionOccur( object sender,EventArgs args )
        {
            OnTransaction?.Invoke(sender, args);
        }

        public override string ToString()
        {
            string usersStr = string.Join(", ", Users.Select(user => user.Name + (user.IsAuthenticated ? " Logged in" : " Not logged in")));
            string transactionsStr = string.Format("${0:F2} - transactions ({1})", Balance, Transactions.Count);
            return $"{Number} {usersStr} {transactionsStr}";
        }
    }
}
