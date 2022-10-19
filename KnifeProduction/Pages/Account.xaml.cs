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
using KnifeProduction.Pages;
using KnifeProduction.Data.Model;

namespace KnifeProduction.Pages
{
    /// <summary>
    /// Логика взаимодействия для Account.xaml
    /// </summary>
    public partial class Account : Page
    {
        public static User User;
        public static OrderKnives OrderKnives;
        public Account(User user)
        {
            User = user;
            InitializeComponent();
            BindingInformationAccount();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var knife = lstvKnife.SelectedItem as OrderKnives;
            OrderKnives = knife;
            NavigationService.Navigate(new ClientKnifeInformation(OrderKnives, User));
        }
        public void BindingInformationAccount()
        {
            var clientKnife = DataBaseRequestOrderKnive.GetListOrderKnive(User);
            lstvKnife.ItemsSource = clientKnife;
            txtLogin.Text = User.Login;
            txtName.Text = User.Name;
            txtRole.Text = "Role: " + User.Role.Name;
            txtPassword.Password = User.Password;
            txtOrderCount.Text = "Order count:" + clientKnife.ToList().Count().ToString();
            this.DataContext = clientKnife;
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            DataBaseRequestUser.EditUserData(User, txtName.Text, txtPassword.Password);
            MessageBox.Show("даныне успешно поменялись!!!");
            BindingInformationAccount();
        }
    }
}
