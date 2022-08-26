using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // make id generated automaticaly
            modelBuilder.Entity<Owner>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<PortfolioItem>().Property(x => x.Id).HasDefaultValueSql("NEWID()");

            // add inital data to database
            modelBuilder.Entity<Owner>().HasData(
                new Owner()
                {
                    Id = Guid.NewGuid(),
                    FullName = "Ahmed Zidan",
                    Avatar = "image.jpg",
                    Profile = "Asp Dot Net / Dot Net Core / Python developer / C++ Developer / " +
                    "Data Analyst / Machine learning"



                }


                ) ;


        }

        public DbSet<Owner> owners { set; get; }
        public DbSet<PortfolioItem> portfolioItems { set; get; }


    }
}
