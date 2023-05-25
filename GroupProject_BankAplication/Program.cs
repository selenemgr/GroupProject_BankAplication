using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace GroupProject_BankAplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nAll acounts:\n---------");
            Bank.PrintAccounts();
            Console.WriteLine("\nAll Users:\n---------");
            Bank.PrintPersons();
            Person p0, p1, p2, p3, p4, p5, p6, p7, p8, p9, p10;
            p0 = Bank.GetPerson("Narendra");
            p1 = Bank.GetPerson("Ilia");
            p2 = Bank.GetPerson("Mehrdad");
            p3 = Bank.GetPerson("Vijay");
            p4 = Bank.GetPerson("Arben");
            p5 = Bank.GetPerson("Patrick");
            p6 = Bank.GetPerson("Yin");
            p7 = Bank.GetPerson("Hao");
            p8 = Bank.GetPerson("Jake");
            p9 = Bank.GetPerson("Mayy");
            p10 = Bank.GetPerson("Nicoletta");
            p0.Login("123"); p1.Login("234");
            p2.Login("345"); p3.Login("456");
            p4.Login("567"); p5.Login("678");
            p6.Login("789"); p7.Login("890");
            p10.Login("234"); p8.Login("901"); 
            //a visa account
            VisaAccount a = Bank.GetAccount("VS-100000") as VisaAccount;
            a.Pay(1500, p0);
            a.Purchase(200, p1);
            a.Purchase(25, p2);
            a.Purchase(15, p0);
            a.Purchase(39, p1);
            a.Pay(400, p0);
            Console.WriteLine(a);
            a = Bank.GetAccount("VS-100001") as VisaAccount;
            a.Pay(500, p0);
            a.Purchase(25, p3);
            a.Purchase(20, p4);
            a.Purchase(15, p5);
            Console.WriteLine(a);
            //a saving account
            SavingAccount b = Bank.GetAccount("SV-100002") as SavingAccount;
            b.Withdraw(300, p6);
            b.Withdraw(32.90, p6);
            b.Withdraw(50, p7);
            b.Withdraw(111.11, p8);
            Console.WriteLine(b);
            b = Bank.GetAccount("SV-100003") as SavingAccount;
            b.Deposit(300, p3); //ok even though p3 is not a holder
            b.Deposit(32.90, p2);
            b.Deposit(50, p5);
            b.Withdraw(111.11, p10);
            Console.WriteLine(b);
            //a checking account
            CheckingAccount c = Bank.GetAccount("CK-100004") as CheckingAccount;
            c.Deposit(33.33, p7);
            c.Deposit(40.44, p7);
            c.Withdraw(150, p2);
            c.Withdraw(200, p4);
            c.Withdraw(645, p6);
            c.Withdraw(350, p6);
            Console.WriteLine(c);
            c = Bank.GetAccount("CK-100005") as CheckingAccount;
            c.Deposit(33.33, p8);
            c.Deposit(40.44, p7);
            c.Withdraw(450, p10);
            c.Withdraw(500, p8);
            c.Withdraw(645, p10);
            c.Withdraw(850, p10);
            Console.WriteLine(c);
            a = Bank.GetAccount("VS-100006") as VisaAccount;
            a.Pay(700, p0);
            a.Purchase(20, p3);
            a.Purchase(10, p1);
            a.Purchase(15, p1);
            Console.WriteLine(a);
            b = Bank.GetAccount("SV-100007") as SavingAccount;
            b.Deposit(300, p3); //ok even though p3 is not a holder
            b.Deposit(32.90, p2);
            b.Deposit(50, p5);
            b.Withdraw(111.11, p7);
            Console.WriteLine(b);
            
            Console.WriteLine("\n\nExceptions:\n---------");
            try
            {
                p8.Login("911"); //incorrect password
            }
            catch (AccountException e) { Console.WriteLine(e.Message); }
            try
            {
                p3.Logout();
                a.Purchase(12.5, p3); //exception user is not logged in
            }
            catch (AccountException e) { Console.WriteLine(e.Message); }
            try
            {
                a.Purchase(12.5, p0); //user is not associated with this account
            }
            catch (AccountException e) { Console.WriteLine(e.Message); }

            try
            {
                a.Purchase(5825, p4); //credit limit exceeded
            }
            catch (AccountException e) { Console.WriteLine(e.Message); }
            try
            {
                c.Withdraw(1500, p6); //no overdraft
            }
            catch (AccountException e) { Console.WriteLine(e.Message); }
            try
            {
                Bank.GetAccount("CK-100018"); //account does not exist
            }
            catch (AccountException e) { Console.WriteLine(e.Message); }
            try
            {
                Bank.GetPerson("Trudeau"); //user does not exist
            }
            catch (AccountException e) { Console.WriteLine(e.Message); }

            Console.WriteLine("\n\nAll transactions:\n---------");
            foreach (var transaction in Bank.GetAllTransactions())
                Console.WriteLine(transaction);
            foreach (var keyValuePair in Bank.ACCOUNTS)
            {
                Account account = keyValuePair.Value;
                Console.WriteLine("\nBefore PrepareMonthlyReport()");
                Console.WriteLine(account);
                Console.WriteLine("\nAfter PrepareMonthlyReport()");
                account.PrepareMonthlyReport(); //all transactions are cleared, balancechanges
                Console.WriteLine(account);
            }
            Logger.ShowLoginEvents();
            Logger.ShowTransactionEvents();
        }
    }
}
