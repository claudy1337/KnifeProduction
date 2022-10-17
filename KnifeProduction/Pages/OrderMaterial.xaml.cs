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
using KnifeProduction.Data.Classes;

namespace KnifeProduction.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrderMaterial.xaml
    /// </summary>
    public partial class OrderMaterial : Page
    {
        public static Client Client;
        int countItem = 1;
        public OrderMaterial(Client client)
        {
            Client = client;
            InitializeComponent();
        }

        private void btnPlus_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            countItem++;
            txtCount.Text = countItem.ToString();
        }

        private void btnMinus_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        { 
            if (countItem > 1)
                countItem--;

            txtCount.Text = countItem.ToString();

        }
    }
}
