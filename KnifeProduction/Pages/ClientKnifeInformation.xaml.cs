﻿using System;
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
    /// Логика взаимодействия для ClientKnifeInformation.xaml
    /// </summary>
    public partial class ClientKnifeInformation : Page
    {
        public static User User;
        public ClientKnifeInformation(User user)
        {
            User = user;
            InitializeComponent();
        }

        private void btnClientOrder_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Account(User));
        }
    }
}
