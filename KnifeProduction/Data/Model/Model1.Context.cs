﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KnifeProduction.Data.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class knifeProdactionEntities : DbContext
    {
        public knifeProdactionEntities()
            : base("name=knifeProdactionEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Backrest> Backrest { get; set; }
        public virtual DbSet<Blade> Blade { get; set; }
        public virtual DbSet<Clip> Clip { get; set; }
        public virtual DbSet<Falsehood> Falsehood { get; set; }
        public virtual DbSet<Handle> Handle { get; set; }
        public virtual DbSet<Knives> Knives { get; set; }
        public virtual DbSet<Obuh> Obuh { get; set; }
        public virtual DbSet<OrderKnives> OrderKnives { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}
