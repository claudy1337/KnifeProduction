using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Логика взаимодействия для OrderMaterial.xaml
    /// </summary>
    public partial class OrderMaterial : Page
    {
        public static User User;
        int countItem = 1;
        public OrderMaterial(User user)
        {
            User = user;
            InitializeComponent();
            Getter();
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
        public void Getter()
        {
             
            var aboba = DataBaseRequestUploadImage.GetBakres(3);
            this.DataContext = aboba;

        }

        private void CBBaseMaterial_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (CBTypeMaterial.SelectedIndex == 0 && CBBaseMaterial.SelectedIndex == 0)
                {
                    CBDetailMaterial.ItemsSource = DbConnection.connection.Obuh.ToList();
                    
                }
                else if (CBTypeMaterial.SelectedIndex == 0 && CBBaseMaterial.SelectedIndex == 1)
                {
                    CBDetailMaterial.ItemsSource = DbConnection.connection.Falsehood.ToList();
                }
                else if (CBTypeMaterial.SelectedIndex == 1 && CBBaseMaterial.SelectedIndex == 0)
                {
                    CBDetailMaterial.ItemsSource = DbConnection.connection.Backrest.ToList();
                }
                else if (CBTypeMaterial.SelectedIndex == 1 && CBBaseMaterial.SelectedIndex == 1)
                {
                    CBDetailMaterial.ItemsSource = DbConnection.connection.Clip.ToList();
                }
            }
            catch(Exception)
            {
                MessageBox.Show("dont search");
            }
        }
        
        private void CBDetailMaterial_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedObuh = CBDetailMaterial.SelectedItem as Obuh;
            var selectedClip = CBDetailMaterial.SelectedItem as Clip;
            var selectedBackrest = CBDetailMaterial.SelectedItem as Backrest;
            var selectedFalsehood = CBDetailMaterial.SelectedItem as Falsehood;
            if (selectedObuh != null)
            {
                var obuh = DataBaseRequesMaterial.GetObuh(selectedObuh.Name);
                this.DataContext = obuh;
            }
            else if (selectedClip != null)
            {
                var clip = DataBaseRequesMaterial.GetClip(selectedClip.Name);
                this.DataContext = clip;
            }
            else if (selectedBackrest != null)
            {
                var backrest = DataBaseRequesMaterial.GetBackrest(selectedBackrest.Name);
                this.DataContext = backrest;
            }
            else if (selectedFalsehood != null)
            {
                var falsehood = DataBaseRequesMaterial.GetFalsehood(selectedFalsehood.Name);
                this.DataContext = falsehood;
            }
           
        }

        private void CBTypeMaterial_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<string> HandleMaterial = new List<string>(2)
            {
                "Backrest", "Clip"
            };
            List<string> BladeMaterial = new List<string>(2)
            {
                "Obuh", "FalseHood"
            };

            try
            {
                if (CBTypeMaterial.SelectedIndex == 0)
                {
                    CBBaseMaterial.ItemsSource = BladeMaterial;
                    
                }
                else if (CBTypeMaterial.SelectedIndex == 1)
                {
                    CBBaseMaterial.ItemsSource = HandleMaterial;
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("dont search");
            }
        }
        private void SaveDataMaterial_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedFalsehood = CBDetailMaterial.SelectedItem as Falsehood;
                var selectedObuh = CBDetailMaterial.SelectedItem as Obuh;
                var selectedClip = CBDetailMaterial.SelectedItem as Clip;
                var selectedBackrest = CBDetailMaterial.SelectedItem as Backrest;
                if (selectedFalsehood != null)
                {
                    
                    DataBaseRequesMaterial.AddFalsehood(selectedFalsehood, countItem);
                }
                else if (selectedObuh != null)
                {
                    DataBaseRequesMaterial.AddObuh(selectedObuh, countItem);
                }
                else if (selectedClip != null)
                {
                    DataBaseRequesMaterial.AddClip(selectedClip, countItem);
                }
                else if (selectedBackrest != null)
                {
                    DataBaseRequesMaterial.AddBackrest(selectedBackrest, countItem);
                }

                MessageBox.Show($"add {countItem}");
            }
            catch(Exception)
            {
                MessageBox.Show("click value");
            }
            
        }
    }
}
