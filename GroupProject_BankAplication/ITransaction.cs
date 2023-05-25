using System;

namespace GroupProject_BankAplication
{
    public interface ITransaction
    {
        void Withdraw( double amount, Person person );
        void Deposit( double amount, Person person );
    }
}