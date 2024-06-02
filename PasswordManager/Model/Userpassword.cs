using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Model
{
    internal class Userpassword
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

        public Userpassword() { }
        public Userpassword(string name, string password, string description, string url)
        {
            Name = name;
            Password = password;
            Description = description;
            Url = url;
        }

        
    }
}
