using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreTrial1.Core.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }


        public Category Category { get; set; }
        public int CategoryId { get; set; }

        public Product()
        {
            ImageUrl = "https://placeimg.com/640/480/tech";
        }
    }
}
