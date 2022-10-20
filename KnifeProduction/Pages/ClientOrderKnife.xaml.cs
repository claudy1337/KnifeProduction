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
using KnifeProduction.Pages;
using KnifeProduction.Data.Classes;
using KnifeProduction.Data.Model;

namespace KnifeProduction.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientOrderKnife.xaml
    /// </summary>
    public partial class ClientOrderKnife : Page
    {
        public static User User;
        public static OrderKnives orderKnives;
        public static Handle handle;
        public static Blade blade;
        public ClientOrderKnife(User user)
        {
            User = user;
            InitializeComponent();
            BindingData();
            lstvKnife.ItemsSource = DataBaseRequestOrderKnive.GetOrderKnives();
        }
        public void BindingData()
        {
            CBBlades.ItemsSource = DbConnection.connection.Blade.ToList();
            CBHandles.ItemsSource = DbConnection.connection.Handle.ToList();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            orderKnives = lstvKnife.SelectedItem as OrderKnives;
            NavigationService.Navigate(new ClientKnifeInformation(orderKnives, User));

        }

        private void btnAccount_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Account(User));
        }

        private void txtClear_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new ClientOrderKnife(User));
        }

        private void CBBlades_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                blade = CBBlades.SelectedItem as Blade;
                if (CBHandles.SelectedIndex == -1)
                {
                    lstvKnife.ItemsSource = DataBaseRequestOrderKnive.GetHandleOrderKnive(blade.id);
                }
                else
                {
                    lstvKnife.ItemsSource = DataBaseRequestOrderKnive.GetOrderKnive(blade.id, handle.id);
                }
            }
            catch(Exception)
            {
                MessageBox.Show("dont search");
                return;
            }
        }

        private void CBHandles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                handle = CBHandles.SelectedItem as Handle;
                if (CBBlades.SelectedIndex == -1)
                {
                    lstvKnife.ItemsSource = DataBaseRequestOrderKnive.GetHandleOrderKnive(handle.id);
                }
                else
                {
                    lstvKnife.ItemsSource = DataBaseRequestOrderKnive.GetOrderKnive(blade.id, handle.id);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("dont search");
                return;
            }
        }
    }
}
