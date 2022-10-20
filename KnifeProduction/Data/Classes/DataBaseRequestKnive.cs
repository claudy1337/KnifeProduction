﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Threading.Tasks;
using KnifeProduction.Data.Classes;
using KnifeProduction.Data.Model;
using KnifeProduction.Pages;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.Windows;

namespace KnifeProduction.Data.Classes
{
    internal class DataBaseRequestKnive
    {
        public static ObservableCollection<Knives> GetKnives()
        {
            return new ObservableCollection<Knives>(DbConnection.connection.Knives);
        }
        public static IEnumerable<Knives> GetKnive()
        {
            return GetKnives().Where(k => k.Count > 0);
        }
        public static IEnumerable<Knives>GetHandleKnive(int idHandle)
        {
            return GetKnives().Where(k=>k.Handle.id == idHandle && k.Count > 0).ToList();
        }
        public static IEnumerable<Knives>GetBladeKnive(int idBlade)
        {
            return GetKnives().Where(k => k.Blade.id == idBlade && k.Count > 0).ToList();
        }
        public static IEnumerable<Knives> GetKnive(int idBlade, int idHandle)
        {
            return GetKnives().Where(k => k.Blade.id == idBlade && k.Handle.id == idHandle && k.Count > 0).ToList();
        }
        public static Knives GetItemKnive(int idBlade, int idHandle)
        {
            return GetKnives().FirstOrDefault(k => k.Blade.id == idBlade && k.Handle.id == idHandle);
        }
        public static Knives GetKnive(int idHandle, int idBlade, string name)
        {
            return GetKnives().FirstOrDefault(k => k.Name == name && k.Blade.id == idBlade && k.Handle.id == idHandle);
        }

        
        public static void AddKnive(int idHandle, int idBlade, string name, int count, bool isHole)
        {
            var getKnive = GetItemKnive(idBlade, idHandle);
            if (getKnive == null)
            {
                Knives knives = new Knives
                {
                    idBlade = idBlade,
                    idHandle = idHandle,
                    Name = name,
                    Count = count,
                    isHole = isHole
                    
                    
            };
                DbConnection.connection.Knives.Add(knives);
                DbConnection.connection.SaveChanges();
            }
            else
            {
                getKnive.Count += count;
                DbConnection.connection.SaveChanges();
            }
        }
        public static int KniveSumCalcul(Knives knives, int count)
        {

                int obuh = Convert.ToInt32(knives.Blade.Obuh.Price);
                int falsehood = Convert.ToInt32(knives.Blade.Falsehood.Price);
                int clip = Convert.ToInt32(knives.Handle.Clip.Price);
                int backrest = Convert.ToInt32(knives.Handle.Backrest.Price);
                int totalAmount = obuh + falsehood + clip + backrest;
                int commissionMarket = (totalAmount * 15) / 100;
                return (totalAmount + commissionMarket) * count;

        }
        public static int KniveGenerateSummCalcul(Obuh obuh, Backrest backrest, Clip clip, Falsehood falsehood, int count)
        {

            int blade = Convert.ToInt32(falsehood.Price) + Convert.ToInt32(obuh.Price);
            int handle = Convert.ToInt32(clip.Price) + Convert.ToInt32(backrest.Price);
            int summ = blade + handle;
            int commision = (summ * 15) / 100;
            return (commision + summ) * count;
        }
    }
}
