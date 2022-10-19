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
        public static Handle handle;
        public static Blade blade;
        public Market(User user)
        {
            User = user;
            InitializeComponent();
            BindingData();
            lstvKnife.ItemsSource = DataBaseRequestKnive.GetKnive();
            
        }

        private void lstvKnife_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedKnive = lstvKnife.SelectedItem as Knives;
            NavigationService.Navigate(new informationKnife(User, selectedKnive));
        }
        public void BindingData()
        {
            CBBlades.ItemsSource = DbConnection.connection.Blade.ToList();
            CBHandles.ItemsSource = DbConnection.connection.Handle.ToList();
        }

        private void CBHandles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                handle = CBHandles.SelectedItem as Handle;
                if (CBBlades.SelectedIndex == -1)
                {
                    lstvKnife.ItemsSource = DataBaseRequestKnive.GetHandleKnive(handle.id);
                }
                else
                {
                    lstvKnife.ItemsSource = DataBaseRequestKnive.GetKnive(blade.id, handle.id);
                }
            }
            catch(Exception)
            {
                MessageBox.Show("dont search");
            }

        }

        private void CBBlades_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                blade = CBBlades.SelectedItem as Blade;
                if (CBHandles.SelectedIndex == -1)
                {
                    lstvKnife.ItemsSource = DataBaseRequestKnive.GetBladeKnive(blade.id);
                }
                else
                {
                    lstvKnife.ItemsSource = DataBaseRequestKnive.GetKnive(blade.id, handle.id);
                }
            }
            catch(Exception)
            {
                MessageBox.Show("dont search");
            }
            
            
        }

        private void txtClear_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Market(User));
        }

        private void btnAccount_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Account(User));
        }
    }
}
