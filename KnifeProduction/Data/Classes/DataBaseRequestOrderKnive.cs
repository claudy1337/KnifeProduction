using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnifeProduction.Data.Classes;
using KnifeProduction.Data.Model;
using KnifeProduction.Pages;
using Microsoft.Win32;
using System.Collections.ObjectModel;

namespace KnifeProduction.Data.Classes
{
    internal class DataBaseRequestOrderKnive
    {
        public static ObservableCollection<OrderKnives> GetOrderKnives()
        {
            return new ObservableCollection<OrderKnives>(DbConnection.connection.OrderKnives);
        }
        public static IEnumerable<OrderKnives> GetListOrderKnive(User user)
        {
            return GetOrderKnives().Where(k=>k.idUser == user.id);
        }
        public static IEnumerable<OrderKnives> GetBladeOrderKnive(int idBlade)
        {
            return GetOrderKnives().Where(k=>k.Knives.Blade.id == idBlade).ToList();
        }
        public static IEnumerable<OrderKnives> GetHandleOrderKnive(int idHandle)
        {
            return GetOrderKnives().Where(k => k.Knives.Handle.id == idHandle).ToList();
        }
        public static IEnumerable<OrderKnives> GetClientOrder(int idClient)
        {
            return GetOrderKnives().Where(c=>c.User.id == idClient).ToList();
        }
        public static IEnumerable<OrderKnives> GetOrderKnive(int idBlade, int idHandle)
        {
            return GetOrderKnives().Where(k => k.Knives.Handle.id == idHandle && k.Knives.Blade.id == idBlade).ToList();
        }

        public static OrderKnives GetOrderKnive(Knives knives, User user)
        {
            return GetOrderKnives().FirstOrDefault(k=> k.idKnives == knives.id && k.User.id == user.id);
        }
        public static void AddOrderKnife(User user,Knives knives, int count, int price)
        {
            var getOrderKnife = GetOrderKnive(knives, user);
            var getKnive = DataBaseRequestKnive.GetKnive(knives.idHandle, knives.idBlade, knives.Name);
            if (getOrderKnife == null)
            {
                OrderKnives orderKnives = new OrderKnives
                {
                    idUser = user.id,
                    idKnives = knives.id,
                    Price = price,
                    Count = count
                };
                DbConnection.connection.OrderKnives.Add(orderKnives);
                getKnive.Count -= count;
                DbConnection.connection.SaveChanges();
            }
            else
            {
                getOrderKnife.Count += count;
                getKnive.Count -= count;
                getOrderKnife.Price += price;
                DbConnection.connection.SaveChanges();
            }
        }
    }
}
