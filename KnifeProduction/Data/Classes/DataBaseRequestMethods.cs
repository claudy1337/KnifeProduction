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
        public static void AddBackrest(string name)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog().GetValueOrDefault())
            {
                Model.Backrest backrest = new Backrest();
                backrest.Image = File.ReadAllBytes(openFileDialog.FileName);
                backrest.Name = name;
                Classes.DbConnection.connection.Backrest.Add(backrest);
                Classes.DbConnection.connection.SaveChanges();

            }

        }
        public static bool GetAdminRole(string login)
        {
            ObservableCollection<User> admin = new ObservableCollection<User>(DbConnection.connection.User);
            var currentAdmin = admin.Where(a=>a.Login == login && a.IdRole == 1).FirstOrDefault();
            return currentAdmin != null;
        }
        
        public static void EditUserData(User oldUserData, string name, string password)
        {
            var user = GetUser(oldUserData.Login, oldUserData.Password);
            user.Name = name;
            user.Password = password;
            DbConnection.connection.SaveChanges();
        }


        public static ObservableCollection<Backrest> GetBarests()
        {
            return new ObservableCollection<Backrest>(DbConnection.connection.Backrest);
        }
        public static Backrest GetBakres(int id)
        {
            
            return GetBarests().FirstOrDefault(x => x.id == id);
        }



        
    }
}
