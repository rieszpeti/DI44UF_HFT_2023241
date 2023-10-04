using DI44UF_HFT_2023241.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DI44UF_HFT_2023241.Repository
{
    public class ApiCallerDbContext : DbContext
    {
        public DbSet<WebSite> Websites { get; set; }
        public DbSet<ApiCalledWebsite> ApiCalledWebsites { get; set; }
        public DbSet<Product> Products { get; set; }

        public ApiCallerDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder
                    .UseLazyLoadingProxies()
                    .UseInMemoryDatabase("Crawler");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<WebSite>(w => w
                .HasMany(w => w.Products)
                .WithOne(p => p.Website)
                .HasForeignKey(p => p.WebsiteId));

            //modelBuilder.Entity<WebSite>()
            //    .HasMany(x => x.Products)
            //    .WithMany(x => x.Websites)
            //    .UsingEntity<Role>(
            //        x => x.HasOne(x => x.Movie)
            //            .WithMany().HasForeignKey(x => x.MovieId).OnDelete(DeleteBehavior.Cascade),
            //        x => x.HasOne(x => x.Actor)
            //            .WithMany().HasForeignKey(x => x.ActorId).OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<WebSite>(w => w
                .HasMany(w => w.ApiCalledWebsites)
                .WithOne(p => p.WebSite)
                .HasForeignKey(p => p.WebsiteId));

            modelBuilder.Entity<Product>(p => p
                .HasOne(w => w.Website)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.WebsiteId));

            modelBuilder.Entity<WebSite>().HasData(
                new WebSite[] 
                { 
                    new WebSite { }
                });

            modelBuilder.Entity<ApiCalledWebsite>().HasData(new ApiCalledWebsite[] { });

            modelBuilder.Entity<Product>().HasData(new Product[] { });
        }
    }
}
