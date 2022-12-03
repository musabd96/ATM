using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atmSystem
{
    internal class User
    {
        public string Name;
        public string Password;
        public int balance;

        public User(string name, string password, int balance)
        {

            this.Name = name;
            this.Password = password;
            this.balance = balance;

        }

    }
}
