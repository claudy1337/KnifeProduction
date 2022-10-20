using KnifeProduction.Data.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnifeProduction.Data.Classes
{
    internal class DataBaseRequesMaterial
    {
        
        public static ObservableCollection<Falsehood> GetFalsehoods()
        {
            return new ObservableCollection<Falsehood>(DbConnection.connection.Falsehood);
        }

        public static IEnumerable<Falsehood> GetFalsehood(string name)
        {
            return GetFalsehoods().Where(f=>f.Name == name).ToList();
        }
        public static void AddFalsehood(Falsehood Oldfalsehood, int count)
        {
            var getFalsehood = GetFalsehood(Oldfalsehood.Name);
            if (getFalsehood != null)
            {
                Oldfalsehood.Count += count;
                DbConnection.connection.SaveChanges();
            }

        }


        public static ObservableCollection<Obuh> GetObuhs()
        {
            return new ObservableCollection<Obuh>(DbConnection.connection.Obuh);
        }
        public static IEnumerable<Obuh> GetObuh(string name)
        {
            return GetObuhs().Where(o=>o.Name == name).ToList();
        }
        public static void AddObuh(Obuh OldObuh, int count)
        {
            var getObuh = GetObuh(OldObuh.Name);
            if (getObuh != null)
            {
                OldObuh.Count += count;
                DbConnection.connection.SaveChanges();
            }

        }


        public static ObservableCollection<Clip> GetClips()
        {
            return new ObservableCollection<Clip>(DbConnection.connection.Clip);
        }
        public static IEnumerable<Clip> GetClip(string name)
        {
            return GetClips().Where(c=>c.Name == name).ToList();
        }
        public static void AddClip(Clip OldClip, int count)
        {
            var getClip = GetClip(OldClip.Name);
            if (getClip != null)
            {
                OldClip.Count += count;
                DbConnection.connection.SaveChanges();
            }

        }


        public static ObservableCollection<Backrest> GetBackrests()
        {
            return new ObservableCollection<Backrest>(DbConnection.connection.Backrest);
        }
        public static IEnumerable<Backrest> GetBackrest(string name)
        {
            return GetBackrests().Where(b=>b.Name == name).ToList();
        }
        public static void AddBackrest(Backrest OldBackrest, int count)
        {
            var getBackrest = GetBackrest(OldBackrest.Name);
            if (getBackrest != null)
            {
                OldBackrest.Count += count;
                DbConnection.connection.SaveChanges();
            }

        }


        public static ObservableCollection<Handle> GetHandles()
        {
            return new ObservableCollection<Handle>(DbConnection.connection.Handle);
        }
        public static Handle GetHandle(int Idbackrest, int Idclip)
        {
            return GetHandles().FirstOrDefault(h => h.idBackrest == Idbackrest && h.idClip == Idclip);

        }

        public static ObservableCollection<Blade> GetBlades()
        {
            return new ObservableCollection<Blade>(DbConnection.connection.Blade);
        }
        public static Blade GetBlade(int Idfalshehood, int Idobuh)
        {
            return GetBlades().FirstOrDefault(h => h.idFalsehood == Idfalshehood && h.idObuh == Idobuh);

        }
    }
}
