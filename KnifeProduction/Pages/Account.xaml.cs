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
        public Account(User user)
        {
            User = user;
            InitializeComponent();
            BindingInformationAccount();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NavigationService.Navigate(new ClientKnifeInformation(User));
        }
        public void BindingInformationAccount()
        {
            txtLogin.Text = User.Login;
            txtName.Text = User.Name;
            txtRole.Text = "Role: " + User.Role.Name;
            txtPassword.Password = User.Password;
            txtSpent.Text = "Spent: ";
            txtOrderCount.Text = "Order count:";
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            DataBaseRequestMethods.EditUserData(User, txtName.Text, txtPassword.Password);
            MessageBox.Show("даныне успешно поменялись!!!");
            BindingInformationAccount();
        }
    }
}
