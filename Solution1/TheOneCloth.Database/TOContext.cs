using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheOneCloth.Entities;

namespace TheOneCloth.Database
{
  public  class TOContext : DbContext
    {
        public TOContext() : base("TheOneCon")
        {

        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Categories> Categoriess { get; set; }
        public DbSet<Sub_Category> Sub_Categorys { get; set; }
        public DbSet<Countries> Countries { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>().Property(x => x.Name)
                .IsRequired()
                .HasColumnName("Name");

            modelBuilder.Configurations.Add(new CategoryConfig());

        }
    }
}
