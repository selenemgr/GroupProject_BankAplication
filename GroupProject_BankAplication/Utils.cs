using GroupProject_BankAplication;
using System;
using System.Collections.Generic; using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject_BankAplication
{
    public static class Utils
    {
        // Utils Fields
        private static DayTime _time = new DayTime( 1_048_000_000 );
        private static Random random = new Random();
        
        // Utils Dictionary
        public readonly static Dictionary<AccountType, string> ACCOUNT_TYPE =
        new Dictionary<AccountType, string>
        {
            { AccountType.Checking , "CK" },
            { AccountType.Saving , "SV" },
            { AccountType.Visa , "VS" }
        };

        // Utils Properties
        public static DayTime Time
        {
            get => _time += random.Next( 1000 );
        }
        public static DayTime Now
        {
            get => _time += 0;
        }
        
    }
}