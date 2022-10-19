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
using KnifeProduction.Data.Model;

namespace KnifeProduction.Pages
{
    /// <summary>
    /// Логика взаимодействия для informationKnife.xaml
    /// </summary>
    public partial class informationKnife : Page
    {
        int countKnife = 1;
        int price;
        public static User User;
        public static Knives Knives;
        int? priceKnife;
        int? maxCountKnife;
        public informationKnife(User user, Knives knives)
        {
            User = user;
            Knives = knives;
            InitializeComponent();
            BindingData();
            maxCountKnife = Knives.Count;
        }

        private void btnMinus_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (countKnife > 1)
            {
                countKnife--;
                price = DataBaseRequestKnive.KniveSumCalcul(Knives, countKnife);
                txtCount.Text = countKnife.ToString();
                txtPrice.Text = "Price: " + price.ToString();
            }
            
            
        }

        private void btnPlus_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (countKnife < maxCountKnife)
            {
                countKnife++;
                if (txtCount.Text == "0")
                {
                    price = DataBaseRequestKnive.KniveSumCalcul(Knives, countKnife);
                }
                price = DataBaseRequestKnive.KniveSumCalcul(Knives, countKnife);
                txtPrice.Text = "Price: " + price.ToString();
                txtCount.Text = countKnife.ToString();
            }
            
        }

        private void btnBack_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Market(User));
        }

        private void btnClientOrder_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Account(User));
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
                countKnife = Convert.ToInt32(txtCount.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show("0 is not count");
            }
        }
        public void BindingData()
        {
            txtKnifeName.Text = Knives.Name;
            txtCountKnife.Text ="Count: " + Knives.Count.ToString();
            txtClip.Text = "Handle Clip: " + Knives.Handle.Clip.Name;
            txtBackrest.Text = "Handle Backrest: " + Knives.Handle.Backrest.Name;
            txtObuh.Text = "Blade Obuh: " + Knives.Blade.Obuh.Name;
            txtFalsehood.Text = "Blade Falsehood: " + Knives.Blade.Falsehood.Name;
            txtIsHole.Text = "isHole: " + Knives.isHole;
            txtPrice.Text = "Price: " + DataBaseRequestKnive.KniveSumCalcul(Knives, countKnife);
            
            this.DataContext = Knives.Blade.Falsehood.Image;
        }

        private void btnBuyKnive_Click(object sender, RoutedEventArgs e)
        {
            priceKnife = DataBaseRequestKnive.KniveSumCalcul(Knives, countKnife);
            DataBaseRequestOrderKnive.AddOrderKnife(User, Knives, countKnife,Convert.ToInt32(priceKnife));
            MessageBox.Show($"buying {Knives.Name} in {countKnife}");
            NavigationService.Navigate(new Market(User));
        }
    }
}
