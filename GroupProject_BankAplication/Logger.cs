using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GroupProject_BankAplication
{
    static class Logger{
        // Logger Fields
        private static List<string> loginEvents = new List<string>();
        private static List<string> transactionEvents = new List<string>();

        // Logger Methods
        public static void LoginHandler( object sender, EventArgs args ) {
            LoginEventArgs logEvent = args as LoginEventArgs;

            string eventLog = $"{logEvent.Name} logged in {(logEvent.Success ? "successfully" : "unsuccessfully")} on {Utils.Now}";
            loginEvents.Add(eventLog); 
        }

        public static void TransactionHandler( object sender, EventArgs args ) {
            TransactionEventArgs logTransaction = args as TransactionEventArgs;

            string transactionLog = $"{logTransaction.Name} deposit {logTransaction.Amount:C2} {(logTransaction.Success ? "successfully" : "unsuccessfully")} on {Utils.Now}";
            transactionEvents.Add(transactionLog);
        }

        public static void ShowLoginEvents(){
            Console.WriteLine($"\nLogin events as of {Utils.Now}\n");
            
            int i = 1;
            foreach ( string l in loginEvents ) 
            {
                Console.WriteLine($"{i} {l}");
                i++;
            }
        }

        public static void ShowTransactionEvents(){
            Console.WriteLine($"\nTransaction events as of {Utils.Now}\n");

            int i = 1;
            foreach (string l in transactionEvents)
            {
                Console.WriteLine($"{i} {l}");
                i++;
            }
        }
    }
}
