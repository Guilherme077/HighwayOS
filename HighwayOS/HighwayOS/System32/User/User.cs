using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayOS.System32.User
{
    internal class User
    {
        public string Name {  get; private set; }
        public string Password { get; private set; } //This method is not secure
        public bool Super;

        public User(string name, string password, bool super)
        {
            Name = name;
            Password = password;
            Super = super;
        }
    }
}
