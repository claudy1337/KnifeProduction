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
using KnifeProduction.Data.Model;
using KnifeProduction.Data.Classes;

namespace KnifeProduction.Pages
{
    /// <summary>
    /// Логика взаимодействия для CreateKnife.xaml
    /// </summary>
    public partial class CreateKnife : Page
    {
        public static User User;
        public CreateKnife(User user)
        {
            User = user;
            InitializeComponent();
        }

        private void btnPlus_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnMinus_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnCreateKnife_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
