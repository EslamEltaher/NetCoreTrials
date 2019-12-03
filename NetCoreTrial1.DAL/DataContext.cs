using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NetCoreTrial1.Core.Models;

namespace NetCoreTrial1.Persistence
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            //SeedData();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        private void SeedData()
        {
            //if(! await Categories.AnyAsync())
            //    Categories.Add(new Category() { Id = 1, Name = "Tech", Description = "Electronics" });

            //if(! await Products.AnyAsync())
            //{
            //    //Products.Add(new Product() { Id = 1, Name = "Product1", CategoryId = 1, Description = "This is Product1", Price = 100, ImageUrl = "" });
            //    //Products.Add(new Product() { Id = 2, Name = "Product2", CategoryId = 1, Description = "This is Product2", Price = 200, ImageUrl = "" });
            //    //Products.Add(new Product() { Id = 3, Name = "Product3", CategoryId = 1, Description = "This is Product3", Price = 300, ImageUrl = "" });
            //    //Products.Add(new Product() { Id = 4, Name = "Product4", CategoryId = 1, Description = "This is Product4", Price = 400, /*ImageUrl = ""*/ });
            //    //Products.Add(new Product()
            //    //{
            //    //    Id = 5,
            //    //    CategoryId = 1,
            //    //    Price = 87,
            //    //    Name = "AmazonBasics USB Type C to USB Type C Cable - 3 feet(0.9 Meters) - Black",
            //    //    Description = "The AmazonBasics USB Type C to USB Type C Cable provides fast transfer of data from one device to another. It transmits data at a rate of up to 480 Mbps, thereby ensuring a smooth flow without consuming much time. It features a USB Type C connector at each end, which makes transferring of data easy and fast. You can easily connect devices equipped with a Type C USB por",
            //    //    ImageUrl = "https://cf1.s3.souqcdn.com/item/2017/05/30/22/89/22/85/item_L_22892285_32101027.jpg"
            //    //});
            //    Products.Add(new Product()
            //    {
            //        Id = 5,
            //        CategoryId = 1,
            //        Name = "AmazonBasics USB Type C to Micro B 2.0 Cable - 3 feet (0.9 Meters) - Black",
            //        Description = "Connecting a computer with a type-C USB port (MacBook, Chromebook Pixel, Galaxy Note 7, etc.) to a Micro-B USB 2.0 enabled device is easy with the AmazonBasics USB Type C to Micro B 2.0 Cable - 3 ft. (0.9 m) – Black. This cable offers a good uninterrupted connection for easy charging or syncing of a tablet, smartphone or digital camera. It syncs data, photos, and music faster at speed ...",
            //        Price = 400,
            //        ImageUrl = "https://cf2.s3.souqcdn.com/item/2017/05/30/22/89/21/93/item_L_22892193_32100772.jpg"
            //    });



            //    maxId = 6;
            //}

            //SaveChanges();
        }
        private static int _maxId = 0;

        public static int MaxId
        {
            get { return ++_maxId; }
            private set { _maxId = value; }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasIndex(p => p.Id);
            base.OnModelCreating(modelBuilder);
        }
    }
}
