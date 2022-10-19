using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using KnifeProduction.Data.Classes;
using KnifeProduction.Data.Model;
using KnifeProduction.Pages;
using Microsoft.Win32;

namespace KnifeProduction.Data.Classes
{
    public class DataBaseRequestMethods
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

        public static ObservableCollection<OrderKnives> GetOrderKnives()
        {
            return new ObservableCollection<OrderKnives>(DbConnection.connection.OrderKnives);
        }
       
        public static IEnumerable<OrderKnives> GetOrderKnive(string login)
        {
            return GetOrderKnives().Where(x => x.User.Login == login);
        }
        //public static IEnumerable<OrderKnives> GetRepeatOrderKnife(string login, )
        //{
        //    if (getKnive == null)
        //    {
        //        Knives knives = new Knives()
        //        {
        //            idBlade = idBlade,
        //            idHandle = idHandle,
        //            isHole = isHole,
        //            Name = name,
        //            Count = count,
        //            OrderStatus = orderStatus
        //        };
        //        DbConnection.connection.Knives.Add(knives);
        //        DbConnection.connection.SaveChanges();
        //    }
        //    else
        //    {
        //        var knive = GetKnive(idHandle, idBlade, name);
        //        knive.Count = count;
        //        knive.OrderStatus = orderStatus;
        //        DbConnection.connection.SaveChanges();
        //    }
        //}

        

       
      


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
