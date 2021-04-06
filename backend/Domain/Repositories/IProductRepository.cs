using SCEES.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCEES.Domain.Repositories
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Product>> FindAllAsync();
        public Task<Product> FindAsync(Guid id);
        public Task<IEnumerable<Product>> FindAsync(string nome);
        public Task<IEnumerable<Product>> FindAsync(int qtd);
        public Task<IEnumerable<Product>> FindAsync(decimal price);
        public Task<IEnumerable<Product>> FindByPriceSale(decimal price);
        public Task<IEnumerable<Product>> FindByCategoryIdAsync(Guid id);
        public Task<IEnumerable<Product>> FindByValidDateAsync(DateTime dateTime);
        public Task<Product> createAsync(Product product);
        public Task<Product> updateAsync(Product product);
        public Task<bool> deleteAsync(Product product);
    }
}
