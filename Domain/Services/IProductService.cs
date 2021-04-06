using SCEES.Domain.Models;
using SCEES.Domain.Models.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCEES.Domain.Services
{
    public interface IProductService
    {
        public Task<Product> createAsync(Product product);
        public Task<Product> updateAsync(Product product);
        public Task<bool> deleteAsync(Guid id);
        public Task<IEnumerable<Product>> findAllAsync();
        public Task<Product> findAsync(Guid id);
        public Task<IEnumerable<Product>> findAsync(string name);
        public Task<IEnumerable<Product>> findByPrice(decimal price);
        public Task<IEnumerable<Product>> findByQtd(int qtd);
        public Task<IEnumerable<Product>> findByCategoryId(Guid id);
        public Task<IEnumerable<Product>> findByDateValid(DateTime date);
        ///public Task<IEnumerable<Product>> findQueryAsync(ProductQuery productQuery);
        public Task<IEnumerable<Product>> findByPriceSale(decimal price);
    }
}
