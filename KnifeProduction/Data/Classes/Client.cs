using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnifeProduction.Data.Classes
{
    public class Client
    {
        public Client(int id, string name, string login, string password, int role)
        {
            Id = id;
            Name = name;
            Login = login;
            Password = password;
            Role = role;
        }
        public static int Id { get; set; }
        public static string Name { get; set; }
        public static string Login { get; set; }
        public static string Password { get; set; }
        public static int Role { get; set; }
    }
}
