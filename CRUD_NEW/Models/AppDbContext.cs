using CRUD_NEW.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace CRUD_NEW.App_DbContext
{
    public class AppDbContext:DbContext
    {
        public AppDbContext() : base("MyConnectionString")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<CompanyDBContext, Configuration>());
        }
        public DbSet<Category> Categories { get; set; }
        
        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }
    }
}