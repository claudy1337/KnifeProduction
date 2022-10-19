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
using KnifeProduction.Windws;
using KnifeProduction.Data.Classes;
using KnifeProduction.Data.Model;

namespace KnifeProduction.Windws
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
        public User User;
        public Auth()
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

        private void txtReg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Close();
        }

        private void btnAuth_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtLogin.Text) || string.IsNullOrWhiteSpace(txtPassword.Password))
                {
                    MessageBox.Show("введите логин или пароль");
                    return;
                }
                else
                {
                    if (DataBaseRequestUser.IsCorrectUser(txtLogin.Text, txtPassword.Password))
                    {
                        User = DataBaseRequestUser.GetUser(txtLogin.Text, txtPassword.Password);
                        MainWindow main = new MainWindow(User);
                        MessageBox.Show($"Welcome: {User.Name}");
                        main.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("неверный логин или пароль");
                    }
                }
            }
            catch(Exception)
            {
                return;
            }

            
        }
    }
}
