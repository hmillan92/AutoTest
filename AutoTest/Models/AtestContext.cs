using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace AutoTest.Models
{
    public class AtestContext : DbContext
    {

        public AtestContext() : base("DefaultConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }


        public DbSet<BusinessEntity> BusinessEntities { get; set; }

        public DbSet<SubCategory> SubCategories { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<TestHeader> TestHeaders { get; set; }

        public DbSet<Lista> Listas { get; set; }

        public DbSet<Prueba> Pruebas { get; set; }

        public DbSet<State> States { get; set; }

        public DbSet<TestDetail> TestDetails { get; set; }

        public DbSet<TestDetailTmp> TestDetailTmps { get; set; }

        public DbSet<Persona> Personas { get; set; }


    }
}