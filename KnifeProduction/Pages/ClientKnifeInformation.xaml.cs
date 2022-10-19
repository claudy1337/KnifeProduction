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
    /// Логика взаимодействия для ClientKnifeInformation.xaml
    /// </summary>
    public partial class ClientKnifeInformation : Page
    {
        public static User User;
        public static OrderKnives OrderKnives;
        public ClientKnifeInformation(OrderKnives orderKnives, User user)
        {
            OrderKnives = orderKnives;
            User = user;
            InitializeComponent();
            BindingData();
        }

        private void btnClientOrder_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Account(User));
        }
        public void BindingData()
        {
            txtKnifeName.Text = OrderKnives.Knives.Name;
            txtCountKnife.Text = "Count: " + OrderKnives.Count;
            txtIsHole.Text = "isHole: " + OrderKnives.Knives.isHole.ToString();
            txtClip.Text = "Handle Clip: " + OrderKnives.Knives.Handle.Clip.Name;
            txtBackrest.Text = "Handle Backrest: " + OrderKnives.Knives.Handle.Backrest.Name;
            txtObuh.Text = "Blade Obuh: " + OrderKnives.Knives.Blade.Obuh.Name;
            txtFalsehood.Text = "Blade Falsehood: " + OrderKnives.Knives.Blade.Falsehood.Name;
            txtPrice.Text = "Price: " + OrderKnives.Price.ToString();
            this.DataContext = OrderKnives.Knives;
        }
    }
}
