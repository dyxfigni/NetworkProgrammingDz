﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RecipeAdviser.Domain
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RecepiesEntities : DbContext
    {
        public RecepiesEntities()
            : base("name=RecepiesEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Ingridients> Ingridients { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Recepi> Recepi { get; set; }
        public virtual DbSet<Steps> Steps { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}