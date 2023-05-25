using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject_BankAplication
{
    public class LoginEventArgs : EventArgs
    {
        // LoginEventArgs Properties
        public string Name { get; }
        public bool Success { get; }

        // LoginEventArgs Constructor
        public LoginEventArgs( string name, bool success )
            : base()
        {
            Name = name;
            Success = success;
        }
    }
}
