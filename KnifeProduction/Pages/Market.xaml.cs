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
using KnifeProduction.Data.Model;

namespace KnifeProduction.Pages
{
    /// <summary>
    /// Логика взаимодействия для Market.xaml
    /// </summary>
    public partial class Market : Page
    {
        public static User User;
        public Market(User user)
        {
            User = user;
            InitializeComponent();
            lstvKnife.ItemsSource = DataBaseRequestMethods.GetKnive(false);
        }

        private void lstvKnife_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedKnive = lstvKnife.SelectedItem as Knives;
            NavigationService.Navigate(new informationKnife(User, selectedKnive));
        }
    }
}
