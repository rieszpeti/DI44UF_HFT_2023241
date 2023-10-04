using DI44UF_HFT_2023241.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DI44UF_HFT_2023241.Repository
{
    public class CrawlerDbContext : DbContext
    {
        public DbSet<WebPage> WebPages { get; set; }
        public DbSet<CrawledWebPage> CrawledWebPages { get; set; }
        public DbSet<Product> Products { get; set; }

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Movie>(movie => movie
            //    .HasOne(movie => movie.Director)
            //    .WithMany(director => director.Movies)
            //    .HasForeignKey(movie => movie.DirectorId)
            //    .OnDelete(DeleteBehavior.Cascade));

            //modelBuilder.Entity<Actor>()
            //    .HasMany(x => x.Movies)
            //    .WithMany(x => x.Actors)
            //    .UsingEntity<Role>(
            //        x => x.HasOne(x => x.Movie)
            //            .WithMany().HasForeignKey(x => x.MovieId).OnDelete(DeleteBehavior.Cascade),
            //        x => x.HasOne(x => x.Actor)
            //            .WithMany().HasForeignKey(x => x.ActorId).OnDelete(DeleteBehavior.Cascade));

            //modelBuilder.Entity<Role>()
            //    .HasOne(r => r.Actor)
            //    .WithMany(actor => actor.Roles)
            //    .HasForeignKey(r => r.ActorId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Role>()
            //    .HasOne(r => r.Movie)
            //    .WithMany(movie => movie.Roles)
            //    .HasForeignKey(r => r.MovieId)
            //    .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<WebPage>().HasData(new WebPage[] { });

            modelBuilder.Entity<CrawledWebPage>().HasData(new CrawledWebPage[] { });

            modelBuilder.Entity<Product>().HasData(new Product[] { });
        }
    }
}
