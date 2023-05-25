using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GroupProject_BankAplication
{
    public class Person
    {
        // Person Fields
        private string password;
        public event EventHandler OnLogin;

        // Person Properties
        public string SIN { get; }
        public string Name { get; }
        public bool IsAuthenticated { get; private set; }

        // Person Constructor
        public Person(string name, string sin)
        {
            SIN = sin;
            Name = name;
            password = SIN.Substring(0, 3);
        }

        // Person Methods
        public void Login(string password)
        {
            if (this.password != password)
            {
                IsAuthenticated = false;

                OnLogin?.Invoke(this, new LoginEventArgs(Name, false));

                throw new AccountException(ExceptionType.PASSWORD_INCORRECT);
            }
            else
            {
                IsAuthenticated = true;

                OnLogin?.Invoke(this, new LoginEventArgs(Name, true));
            }
        }

        public void Logout()
            => IsAuthenticated = false;

        public override string ToString()
        {
            return $"{Name} {(IsAuthenticated ? "Logged in" : "Not logged in")}";
        }
    }
}
