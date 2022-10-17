using KnifeProduction.Data.Classes;
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
using KnifeProduction.Data;
using KnifeProduction.Pages;
using KnifeProduction.Windws;

namespace KnifeProduction
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Client Client;
        public MainWindow(Client client)
        {
            Client = client;
            InitializeComponent();
            
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (e.ChangedButton == MouseButton.Left)
                    this.DragMove();
            }
            catch (System.InvalidOperationException)
            {
                return;
            }
        }

        private void btnClose_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void btnMinus_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnAccount_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new Account(Client));
        }

        private void btnMarket_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new Market(Client));
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new OrderMaterial(Client));
        }

        private void btnCreateKnife_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new CreateKnife(Client));
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Auth auth = new Auth();
            auth.Show();
            this.Close();
        }

        private void btnClientOrderKnife_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new ClientOrderKnife(Client));
        }
    }
}
