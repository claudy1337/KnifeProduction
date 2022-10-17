using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using KnifeProduction.Data.Classes;

namespace KnifeProduction.Pages
{
    /// <summary>
    /// Логика взаимодействия для CreateKnife.xaml
    /// </summary>
    public partial class CreateKnife : Page
    {
        public static Client Client;
        public CreateKnife(Client client)
        {
            Client = client;
            InitializeComponent();
        }
    }
}
