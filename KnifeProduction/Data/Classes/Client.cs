using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnifeProduction.Data.Classes
{
    public class Client
    {
        public Client(string name)
        {
            Name = name;
        }
        public static string Name { get; set; }
    }
}
