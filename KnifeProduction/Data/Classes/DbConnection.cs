using KnifeProduction.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnifeProduction.Data.Classes;
using KnifeProduction.Pages;

namespace KnifeProduction.Data.Classes
{
    internal class DbConnection
    {
        public static knifeProdactionEntities connection = new knifeProdactionEntities();
    }
}
