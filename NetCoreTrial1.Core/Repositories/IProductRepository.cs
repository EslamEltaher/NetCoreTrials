using NetCoreTrial1.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreTrial1.Core.Repositories
{
    public interface IProductRepository
    {
        Task<ICollection<Product>> GetProducts();
        Task<ICollection<Product>> GetProductsByCategoryId(int categoryId);
        Task<Product> GetProductById(int id);
        Task<Product> AddProduct(Product product);
        Task RemoveProduct(Product product);
    }
}
