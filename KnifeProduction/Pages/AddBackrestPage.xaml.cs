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
using KnifeProduction.Data.Model;

namespace KnifeProduction.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddBackrestPage.xaml
    /// </summary>
    public partial class AddBackrestPage : Page
    {
        public AddBackrestPage()
        {
            InitializeComponent();
            
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            DataBaseRequestUploadImage.AddClip(txtName.Text);
        }
        int count = 0;
        private void btnGett_Click(object sender, RoutedEventArgs e)
        {
            count++;
            var aboba = DataBaseRequestUploadImage.GetBakres(count);
            this.DataContext = aboba;
        }
    }
}
