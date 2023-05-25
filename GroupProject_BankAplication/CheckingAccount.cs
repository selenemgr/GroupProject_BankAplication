using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace GroupProject_BankAplication
{
    public class CheckingAccount: Account, ITransaction
    {
        // CheckingAccount Fields
        private static double Cost_Per_Transaction = 0.05;
        private static double Interest_Rate = 0.005;
        private bool HasOverdraft;

        // Constructor
        public CheckingAccount( double balance = 0, bool hasOverdraft = false )
            :base( Utils.ACCOUNT_TYPE[AccountType.Checking] + "-", balance )
        {
            HasOverdraft = hasOverdraft;
        }

        // CheckingAccount Methods
        public new void Deposit( double amount, Person person )
        {
            base.Deposit( amount, person );
            base.OnTransactionOccur(amount, new TransactionEventArgs(person.Name, amount, true));
        }

        public void Withdraw( double amount, Person person )
        {
            // Check if person name is associated with an account
            if (!Users.Contains( person ))
            {
                OnTransactionOccur(amount, new TransactionEventArgs(person.Name, amount, true));
                throw new AccountException( ExceptionType.NAME_NOT_ASSOCIATED_WITH_ACCOUNT );
            }

            // Check if person is logged in
            if (person.IsAuthenticated == false) 
            {
                OnTransactionOccur(amount, new TransactionEventArgs(person.Name, amount, true));
                throw new AccountException( ExceptionType.USER_NOT_LOGGED_IN );
            }

            // Check if withdrawal amount is greater than balance and no overdraft facility
            if ( amount > Balance && HasOverdraft )
            {
                OnTransactionOccur(amount, new TransactionEventArgs(person.Name, amount, true));
                throw new AccountException( ExceptionType.NO_OVERDRAFT );
            }

            // Perform withdrawal
            OnTransactionOccur(amount, new TransactionEventArgs(person.Name, amount, true));
            base.Deposit( -amount, person );
        }
        public override void PrepareMonthlyReport()
        {
            int transactions = 0;
            foreach ( Transaction t in Transactions)
            {
                transactions++;
            }

            double serviceCharge = transactions * Cost_Per_Transaction;
            double interest = (LowestBalance * Interest_Rate) / 12;

            Balance += interest - serviceCharge;
            
            Transactions.Clear();
        }
    }
}
