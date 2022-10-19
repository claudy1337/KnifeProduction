using KnifeProduction.Data.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnifeProduction.Data.Classes
{
    internal class DataBaseRequestUploadImage
    {
        public static void AddClip(string name)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog().GetValueOrDefault())
            {
                Model.Falsehood falsehood = new Falsehood();
                falsehood.Image = File.ReadAllBytes(openFileDialog.FileName);
                falsehood.Name = name;
                Classes.DbConnection.connection.Falsehood.Add(falsehood);
                Classes.DbConnection.connection.SaveChanges();
            }
        }
        public static ObservableCollection<Falsehood> GetClips()
        {
            return new ObservableCollection<Falsehood>(DbConnection.connection.Falsehood);
        }
        public static Falsehood GetBakres(int id)
        {

            return GetClips().FirstOrDefault(x => x.id == id);
        }
    }
}
