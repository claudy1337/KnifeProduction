using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using KnifeProduction.Pages;

namespace KnifeProduction.Pages
{
    /// <summary>
    /// Логика взаимодействия для informationKnife.xaml
    /// </summary>
    public partial class informationKnife : Page
    {
        int countItem = 1;
        int price = 100;
        public static Client Client;
        public informationKnife(Client client)
        {
            Client = client;
            InitializeComponent();
        }

        private void btnMinus_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (countItem>1)
            {
                countItem--;
                price -= countItem;
            }
            
            txtCount.Text = countItem.ToString();
            txtPrice.Text = "Price: " + price.ToString();
        }

        private void btnPlus_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            countItem++;
            price += countItem;
            txtPrice.Text = "Price: " + price.ToString();
            txtCount.Text = countItem.ToString();
        }

        private void btnBack_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Market(Client));
        }

        private void btnClientOrder_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Account(Client));
        }

        private void txtCount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            try
            {
                if (!Char.IsDigit(e.Text, 0))
                {
                    e.Handled = true;
                }
                Regex regex = new Regex("[^1-9]+");
                e.Handled = regex.IsMatch(e.Text);
                countItem = Convert.ToInt32(txtCount.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show("0 is not count");
            }
        }
    }
}
