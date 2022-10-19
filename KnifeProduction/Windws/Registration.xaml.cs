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
using System.Windows.Shapes;
using KnifeProduction.Pages;
using KnifeProduction.Data.Classes;
using KnifeProduction.Data.Model;

namespace KnifeProduction.Windws
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public static User currentUser;
        public Registration()
        {
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
        private void txtAuth_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Auth auth = new Auth();
            auth.Show();
            this.Close();
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtLogin.Text) || string.IsNullOrWhiteSpace(txtPassword.Password) || 
                    string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtAgainPassword.Password)){

                    MessageBox.Show("заполните все поля");
                }
                else
                {
                    if (DataBaseRequestUser.IsCorrectUser(txtLogin.Text, txtPassword.Password) == false &&
                        DataBaseRequestUser.GetAdminRole(txtLogin.Text) == false)
                    {
                        if (txtPassword.Password == txtAgainPassword.Password)
                        {
                            DataBaseRequestUser.AddUser(txtLogin.Text, txtName.Text, txtPassword.Password);
                            currentUser = DataBaseRequestUser.CurrentUser;
                            MainWindow main = new MainWindow(currentUser);
                            MessageBox.Show($"Welcome: {currentUser.Name}");
                            main.Show();
                            this.Close();
                        }
                        else
                            MessageBox.Show("пароли не совпадают!!!");
                    }
                    else
                        MessageBox.Show("такой пользователь уже существует!!!");
                }
            }
            catch(Exception)
            {
                return;
            }
        }
    }
}
