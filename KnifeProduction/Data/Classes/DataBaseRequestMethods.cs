using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using KnifeProduction.Data.Classes;
using KnifeProduction.Data.Model;
using KnifeProduction.Pages;
using Microsoft.Win32;

namespace KnifeProduction.Data.Classes
{
    public class DataBaseRequestMethods
    {
        public static User CurrentUser;
        public static bool IsCorrectUser(string login, string password)
        {
            ObservableCollection<User> user = new ObservableCollection<User>(DbConnection.connection.User);
            var currentUser = user.Where(u => u.Login == login && u.Password == password).FirstOrDefault();
            return currentUser != null;
        }
        public static ObservableCollection<User> GetUsers()
        {
            return new ObservableCollection<User>(DbConnection.connection.User);
        }
        public static User GetUser(string login, string password)
        {
            return GetUsers().FirstOrDefault(x => x.Login == login && x.Password == password);
        }

        public static void AddUser(string login, string name, string password, int role = 2)
        {
            var getUser = GetUser(login, password);
            if (getUser == null)
            {
                User user = new User
                {
                    IdRole = role,
                    Login = login,
                    Password = password,
                    Name = name
                };
                CurrentUser = user;
                DbConnection.connection.User.Add(user);
                DbConnection.connection.SaveChanges();
            }
            else
            {
                MessageBox.Show("такой пользователь уже существует!!!");
                return;
            }

        }
        public static void EditUserData(User oldUserData, string name, string password)
        {
            var user = GetUser(oldUserData.Login, oldUserData.Password);
            user.Name = name;
            user.Password = password;
            DbConnection.connection.SaveChanges();
        }

        public static bool GetAdminRole(string login)
        {
            ObservableCollection<User> admin = new ObservableCollection<User>(DbConnection.connection.User);
            var currentAdmin = admin.Where(a=>a.Login == login && a.IdRole == 1).FirstOrDefault();
            return currentAdmin != null;
        }
        
        
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

        public static ObservableCollection<Knives> GetKnives()
        {
            return new ObservableCollection<Knives>(DbConnection.connection.Knives);
        }
        public static IEnumerable<Knives> GetKnive(bool status)
        {
            return GetKnives().Where(k=>k.OrderStatus == status);
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
