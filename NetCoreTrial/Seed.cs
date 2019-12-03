using NetCoreTrial1.Core.Models;
using NetCoreTrial1.Core.Repositories;
using NetCoreTrial1.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreTrial1
{
    public class Seed
    {
        private readonly DataContext _context;

        public Seed(DataContext context)
        {
            _context = context;
        }

        public void SeedProducts()
        {
            if (!_context.Categories.Any())
                _context.Categories.Add(new Category() { Id = 0, Name = "Tech", Description = "Electronics" });

            //if (! _context.Products.Any())
            //{
                //_context.Products.Add(new Product() { Id = getId(), Name = "Product1", CategoryId = 1, Description = "This is Product1", Price = 100, ImageUrl = "" });
                //_context.Products.Add(new Product() { Id = getId(), Name = "Product2", CategoryId = 1, Description = "This is Product2", Price = 200, ImageUrl = "" });
                //_context.Products.Add(new Product() { Id = getId(), Name = "Product3", CategoryId = 1, Description = "This is Product3", Price = 300, ImageUrl = "" });
                _context.Products.Add(new Product() { Id = getId(), Name = "Product4", CategoryId = 1, Description = "This is Product4", Price = 400, /*ImageUrl = ""*/ });
                _context.Products.Add(new Product()
                {
                    Id = getId(),
                    CategoryId = 1,
                    Price = 87,
                    Name = "AmazonBasics USB Type C to USB Type C Cable - 3 feet(0.9 Meters) - Black",
                    Description = "The AmazonBasics USB Type C to USB Type C Cable provides fast transfer of data from one device to another. It transmits data at a rate of up to 480 Mbps, thereby ensuring a smooth flow without consuming much time. It features a USB Type C connector at each end, which makes transferring of data easy and fast. You can easily connect devices equipped with a Type C USB por",
                    ImageUrl = "https://cf1.s3.souqcdn.com/item/2017/05/30/22/89/22/85/item_L_22892285_32101027.jpg"
                });
                _context.Products.Add(new Product()
                {
                    Id = getId(),
                    CategoryId = 1,
                    Name = "AmazonBasics USB Type C to Micro B 2.0 Cable - 3 feet (0.9 Meters) - Black",
                    Description = "Connecting a computer with a type-C USB port (MacBook, Chromebook Pixel, Galaxy Note 7, etc.) to a Micro-B USB 2.0 enabled device is easy with the AmazonBasics USB Type C to Micro B 2.0 Cable - 3 ft. (0.9 m) – Black. This cable offers a good uninterrupted connection for easy charging or syncing of a tablet, smartphone or digital camera. It syncs data, photos, and music faster at speed ...",
                    Price = 400,
                    ImageUrl = "https://cf2.s3.souqcdn.com/item/2017/05/30/22/89/21/93/item_L_22892193_32100772.jpg"
                });
                _context.Products.Add(new Product()
                {
                    Id = getId(),
                    CategoryId = 1,
                    Name = "AmazonBasics High-Speed HDMI 2.0 Cable - 3 Feet(2 - Pack)",
                    Description = "Be it your smartphone or home theatre; you can connect the AmazonBasics High Speed HDMI 2.0 Cable with the utmost ease. Get ready to enjoy superior sound quality with amazing clarity like never before. The 2.0 HDMI cable supports up to 32 audio channels and also promotes dual audio and video streaming. It is specially designed to expand bandwidths up to 18 Gbps to support a mammoth 4K ...",
                    Price = 64,
                    ImageUrl = "https://cf1.s3.souqcdn.com/item/2017/05/30/22/89/23/81/item_L_22892381_32101108.jpg"
                });
                
            //}
            _context.SaveChanges();
        }
        private int getId()
        {
            //return DataContext.MaxId;
            return 0;
        }
    }
}
