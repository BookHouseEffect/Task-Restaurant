using Restaurant.DataAccess.Entities;
using Restaurant.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Domain.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository= productRepository;
        }

        public async Task<List<Product>> GetProductList()
        {
            return await _productRepository.GetAllAsync();
        } 

        public async Task AddNewProduct(Product product)
        {
            await _productRepository.InsertAsync(product);
        }
    }
}
