using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthWind.Entities.POCOEntities;

namespace NorthWind.Repositories.EFCore.DataContext
{
    public class NorthWindContext : DbContext
    {
        public NorthWindContext(DbContextOptions<NorthWindContext> options) : base(options) { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrdenDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Customer>()
     .Property(c => c.Id)
     .HasMaxLength(5)
     .IsFixedLength();
            modelBuilder.Entity<Customer>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(40);

            modelBuilder.Entity<Product>()
            .Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(40);

            modelBuilder.Entity<Order>()
            .Property(o => o.CustomerId)
            .IsRequired()
            .HasMaxLength(5)
            .IsFixedLength();
            modelBuilder.Entity<Order>()
                .Property(o => o.ShipAddress)
                .IsRequired()
                .HasMaxLength(60);
            modelBuilder.Entity<Order>()
                .Property(o => o.ShipCity)
                .HasMaxLength(15);
            modelBuilder.Entity<Order>()
                .Property(o => o.ShipCountry)
                .HasMaxLength(15);
            modelBuilder.Entity<Order>()
                .Property(o => o.ShipPostalCode)
                .HasMaxLength(10);


            modelBuilder.Entity<OrderDetail>()
              .HasKey(od => new { od.OrderId, od.ProductID, });
            modelBuilder.Entity<Order>()
              .HasOne<Customer>()
              .WithMany()
              .HasForeignKey(o => o.CustomerId);

            modelBuilder.Entity<OrderDetail>()
             .HasOne<Product>()
             .WithMany()
             .HasForeignKey(od => od.ProductID);

            modelBuilder.Entity<Product>()
                .HasData(
                new Product { ID = 1, Name = "Chai" },
                new Product { ID = 2, Name = "Chang" },
                new Product { ID = 3, Name = "Anissed Syrup" }

                );
            modelBuilder.Entity<Customer>()
               .HasData(
               new Customer { Id = "ALFKI", Name = "ALFRED.F" },
               new Customer { Id = "ANATR", Name = "ANA TRUJILLO" },
               new Customer { Id = "ANTON", Name = "ANTONIO MORENO" }

               );

        }
    }
}
