using System;
using Microsoft.EntityFrameworkCore;
using DI44UF_HFT_2023241.Models;
using System.Collections.Generic;

namespace DI44UF_HFT_2023241.Repository
{
    public class OrderDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public OrderDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder
                    .UseLazyLoadingProxies()
                    .UseInMemoryDatabase("db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                 .HasOne(c => c.Address)
                 .WithMany(a => a.Customers)
                 .HasForeignKey(c => c.AddressId);

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Orders)
                .WithOne(o => o.Customer)
                .HasForeignKey(o => o.CustomerId);

            modelBuilder.Entity<Customer>()
                .HasIndex(o => o.UserName)
                .IsUnique();

            modelBuilder.Entity<Order>()
                .HasMany(x => x.Products)
                .WithMany(x => x.Orders)
                .UsingEntity<OrderDetail>(
                    x => x.HasOne(x => x.Product)
                        .WithMany().HasForeignKey(x => x.ProductId),
                    x => x.HasOne(x => x.Order)
                    .WithMany().HasForeignKey(x => x.OrderId));

            modelBuilder.Entity<Customer>().HasData(new Customer[]
            {
                new Customer
                {
                    CustomerId = 1,
                    AddressId = 1,
                    UserName = "Jozsi",
                },

                new Customer
                {
                    CustomerId = 2,
                    AddressId = 1,
                    UserName = "Bela",
                }
            });

            modelBuilder.Entity<Address>().HasData(new Address[]
            {
                new Address
                {
                    AddressId = 1,
                    PostalCode = "2023",
                    Country = "HU",
                    City = "Bp",
                    Region = "Bp",
                    Street = "Nap"
                }
            });

            List<Product> products = new List<Product>()
            {
                 new Product
                {
                    OrderItemId = 1,
                    Description = "Test",
                    Id = 1,
                    Name = "Test",
                    Size = "Test"
                }
            };

            modelBuilder.Entity<Product>().HasData(products);

            modelBuilder.Entity<Order>().HasData(new Order[]
            {
                new Order
                {
                    CustomerId = 1,
                    OrderId = 1,
                    OrderDate = DateTime.Now,
                }
            });

            modelBuilder.Entity<OrderDetail>().HasData(new OrderDetail[]
            {
                new OrderDetail
                {
                    OrderItemId = 1,
                    OrderId = 1,
                    ProductId = 1,
                    Quantity = 1
                }
            });
        }
    }
}
