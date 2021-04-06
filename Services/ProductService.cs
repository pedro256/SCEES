using SCEES.Domain.Models;
using SCEES.Domain.Models.Query;
using SCEES.Domain.Repositories;
using SCEES.Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCEES.Services
{
    public class ProductService : IProductService
    {
        public readonly IProductRepository productRepository;
        public ProductService(IProductRepository repository)
        {
            this.productRepository = repository;
        }
        public async Task<Product> createAsync(Product product)
        {
            return await productRepository.createAsync(product);
        }

        public async Task<bool> deleteAsync(Guid id)
        {
            Product result = await productRepository.FindAsync(id);
            if (result == null) return false;
            return await productRepository.deleteAsync(result);
        }

        public async Task<IEnumerable<Product>> findAllAsync()
        {
            return await productRepository.FindAllAsync();
        }

        public async Task<Product> findAsync(Guid id)
        {
            return await productRepository.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> findAsync(string name)
        {
            return await productRepository.FindAsync(name);
        }

        public async Task<IEnumerable<Product>> findByCategoryId(Guid id)
        {
            return await productRepository.FindByCategoryIdAsync(id);
        }

        public async Task<IEnumerable<Product>> findByDateValid(DateTime date)
        {
            return await productRepository.FindByValidDateAsync(date);
        }

        public async Task<IEnumerable<Product>> findByPrice(decimal price)
        {
            return await productRepository.FindAsync(price);
        }

        public async Task<IEnumerable<Product>> findByPriceSale(decimal price)
        {
            return await productRepository.FindByPriceSale(price);
        }

        public async Task<IEnumerable<Product>> findByQtd(int qtd)
        {
            return await productRepository.FindAsync(qtd);
        }

        public async Task<Product> updateAsync(Product product)
        {
            product.updatedAt = DateTime.UtcNow;
            return await productRepository.updateAsync(product);
        }
        

    }
}
