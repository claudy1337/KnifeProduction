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
using KnifeProduction.Data.Model;
using KnifeProduction.Data.Classes;

namespace KnifeProduction.Pages
{
    /// <summary>
    /// Логика взаимодействия для CreateKnife.xaml
    /// </summary>
    public partial class CreateKnife : Page
    {
        public static Backrest Backrest;
        public static Clip clip;
        public static Obuh Obuh;
        public static Falsehood Falsehood;
        public static User User;
        public static bool isCheck; 
        int countKnife = 1;
        int price;
        int? priceKnife;
        int? maxCountKnife;
        public CreateKnife(User user)
        {
            User = user;
            InitializeComponent();
            BindingData();
            
        }
        
        private void btnPlus_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
                countKnife++;
                if (txtCount.Text == "0")
                {
                    price = DataBaseRequestKnive.KniveGenerateSummCalcul(Obuh, Backrest, clip, Falsehood, countKnife);
                }
                price = DataBaseRequestKnive.KniveGenerateSummCalcul(Obuh, Backrest, clip, Falsehood, countKnife);
                txtPrice.Text = "Price: " + price.ToString();
                txtCount.Text = countKnife.ToString();
        }

        private void btnMinus_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (countKnife > 1)
            {
                countKnife--;
                price = DataBaseRequestKnive.KniveGenerateSummCalcul(Obuh, Backrest, clip, Falsehood, countKnife);
                txtCount.Text = countKnife.ToString();
                txtPrice.Text = "Price: " + price.ToString();
            }
        }

        private void btnCreateKnife_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var blades = DataBaseRequesMaterial.GetBlade(Falsehood.id, Obuh.id);
                var hadles = DataBaseRequesMaterial.GetHandle(Backrest.id, clip.id);
                MessageBox.Show($"create knive: {txtName.Text} ib count: {countKnife} add");
                DataBaseRequestKnive.AddKnive(hadles.id, blades.id, txtName.Text, countKnife, isCheck);
                NavigationService.Navigate(new CreateKnife(User));
            }
            catch(Exception)
            {
                return;
            }
            
        }
        public void BindingData()
        {
            CBMaterialObuh.ItemsSource = DbConnection.connection.Obuh.ToList();
            CBMaterialClip.ItemsSource = DbConnection.connection.Clip.ToList();
            CBMaeterialFalsehood.ItemsSource = DbConnection.connection.Falsehood.ToList();
            CBMaterialBackrest.ItemsSource = DbConnection.connection.Backrest.ToList();
            //CBMaterialClip.ItemsSource = DataBaseRequesMaterial.GetClip().ToList();
        }

        private void CBMaterialObuh_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Obuh = CBMaterialObuh.SelectedItem as Obuh;
            txtCountObuh.Text = "Count: " + Obuh.Count.ToString();
            var obuh = DataBaseRequesMaterial.GetObuh(Obuh.Name);
            this.DataContext = obuh;
        }

        private void CBMaeterialFalsehood_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Falsehood = CBMaeterialFalsehood.SelectedItem as Falsehood;
            txtCountFalsehood.Text = "Count: " + Falsehood.Count.ToString();
            var falsehood = DataBaseRequesMaterial.GetFalsehood(Falsehood.Name);
            this.DataContext = falsehood;
        }

        private void CBMaterialClip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            clip = CBMaterialClip.SelectedItem as Clip;
            txtCountClip.Text = "Count: " + clip.Count.ToString();
            var Clip = DataBaseRequesMaterial.GetClip(clip.Name);
            this.DataContext = Clip;
        }

        private void CBMaterialBackrest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Backrest = CBMaterialBackrest.SelectedItem as Backrest;
            txtCountBackrest.Text = "Count: " + Backrest.Count.ToString();
            var backrest = DataBaseRequesMaterial.GetBackrest(Backrest.Name);
            this.DataContext = backrest;
            try
            {
                price = DataBaseRequestKnive.KniveGenerateSummCalcul(Obuh, Backrest, clip, Falsehood, countKnife);
                txtPrice.Text = "Price: " + price.ToString();
            }
            catch(Exception)
            {
                MessageBox.Show("update");
                return;
            }
            
            
        }

        private void cbIsHole_Checked(object sender, RoutedEventArgs e)
        {
            if (cbIsHole.IsChecked == true)
            {
                isCheck = true;
            }
            else
                isCheck = false;
        }
    }
}
