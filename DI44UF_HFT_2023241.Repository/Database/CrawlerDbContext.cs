using DI44UF_HFT_2023241.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DI44UF_HFT_2023241.Repository
{
    public class CrawlerDbContext : DbContext
    {
        public DbSet<WebPage> Movies { get; set; }
        public DbSet<CrawledWebPage> Roles { get; set; }
        public DbSet<Product> Actors { get; set; }

        public CrawlerDbContext()
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
    }
}
