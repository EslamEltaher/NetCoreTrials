using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreTrial1.Core.Models;
using NetCoreTrial1.Core.Repositories;

namespace NetCoreTrial1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("")]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _productRepository.GetProducts();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productRepository.GetProductById(id);

            if(product == null)
                return NotFound();

            await _productRepository.RemoveProduct(product);

            await _unitOfWork.Save();

            return Ok(product.Id);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            var addedProduct = await _productRepository.AddProduct(product);
            await _unitOfWork.Save();

            return Created("", addedProduct);
        }
    }
}