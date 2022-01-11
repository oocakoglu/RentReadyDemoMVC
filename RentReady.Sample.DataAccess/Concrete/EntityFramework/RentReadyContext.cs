using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentReady.Sample.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentReady.Sample.DataAccess.Concrete.EntityFramework
{
    public class RentReadyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=RENTREADYDB;Trusted_Connection=True;");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

           

    }
}
