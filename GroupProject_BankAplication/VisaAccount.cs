using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject_BankAplication
{
    public class VisaAccount : Account, ITransaction
    {
        // VisaAccount Fields
        private double creditLimit;
        private static double INTEREST_RATE = 0.1995;

        // VisaAccount Constructor
        public VisaAccount( double balance = 0, double creditLimit = 1200 )
            : base(Utils.ACCOUNT_TYPE[AccountType.Visa] + "-", balance)
        {
            this.creditLimit = creditLimit;
        }

        // VisaAccount Methods
        public void Pay( double amount, Person person )
        {
            Deposit( amount, person );
            OnTransactionOccur(amount, new TransactionEventArgs(person.Name, amount, true));
        }

        public void Purchase( double amount, Person person)
        {
            // Check if person name is associated with an account
            if (!Users.Contains( person ))
            {
                OnTransactionOccur(amount, new TransactionEventArgs(person.Name, amount, true));
                throw new AccountException(ExceptionType.NAME_NOT_ASSOCIATED_WITH_ACCOUNT);
            }

            // Check if person is logged in
            if (person.IsAuthenticated == false) 
            {
                OnTransactionOccur(amount, new TransactionEventArgs(person.Name, amount, true));
                throw new AccountException( ExceptionType.USER_NOT_LOGGED_IN );
            }

            // Check if purchase amount is greater than credit limit
            if ( amount > creditLimit )
            {
                OnTransactionOccur(amount, new TransactionEventArgs(person.Name, amount, true));
                throw new AccountException(ExceptionType.CREDIT_LIMIT_HAS_BEEN_EXCEEDED);
            }

            // Perform purchase
            OnTransactionOccur(amount, new TransactionEventArgs(person.Name, amount, true));
            Deposit( -amount, person );
        }

        public void Withdraw(double amount, Person person) { }

        public override void PrepareMonthlyReport()
        {
            double interest = (LowestBalance * INTEREST_RATE) / 12;

            Balance -= interest;

            Transactions.Clear();
        }
    }
}
