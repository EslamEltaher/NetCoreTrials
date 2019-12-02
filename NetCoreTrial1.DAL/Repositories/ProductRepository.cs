using Microsoft.EntityFrameworkCore;
using NetCoreTrial1.Core.Models;
using NetCoreTrial1.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreTrial1.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<ICollection<Product>> GetProducts()
        {
            return await _context.Products.Include(p => p.Category).ToListAsync();
        }

        public async Task<ICollection<Product>> GetProductsByCategoryId(int categoryId)
        {
            return await _context.Products
                .Include(p => p.Category)
                .Where(p => p.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task<Product> AddProduct(Product product)
        {
            //IN MEMORY
            //product.Id = DataContext.maxId;

            await _context.Products.AddAsync(product);
            return product;
        }
        public async Task RemoveProduct(Product product)
        {
            _context.Products.Remove(product);
        }
    }
}
