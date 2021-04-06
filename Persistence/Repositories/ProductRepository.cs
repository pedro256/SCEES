using Microsoft.EntityFrameworkCore;
using SCEES.Domain.Models;
using SCEES.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCEES.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public readonly ContextDbApp context;  
        public ProductRepository(ContextDbApp Inscontext)
        {
            this.context = Inscontext;
        }
        public async Task<Product> createAsync(Product product)
        {
            var item =  await context.Products.AddAsync(product);
            return (await context.SaveChangesAsync() > 0) ? item.Entity : null;
        }

        public async Task<bool> deleteAsync(Product product)
        {
            context.Products.Remove(product);
            return (await context.SaveChangesAsync() > 0);
        }

        public async Task<IEnumerable<Product>> FindAllAsync()
        {
            return await context.Products.ToListAsync();
        }

        public async Task<Product> FindAsync(Guid id)
        {
            return await context.Products.FirstOrDefaultAsync(
                prod => prod.id == id
                );
        }

        public async Task<IEnumerable<Product>> FindAsync(string nome)
        {
            return await context.Products.Where(
                prod => EF.Functions.Like(prod.name, "%" + nome + "%")
                ).ToListAsync();
        }

        public async Task<IEnumerable<Product>> FindAsync(int qtd)
        {
            return await context.Products.Where(prod => prod.qtd == qtd).ToListAsync();
        }

        public async Task<IEnumerable<Product>> FindAsync(decimal price)
        {
            return await context.Products.Where(prod => prod.price == price).ToListAsync();
        }

        public async Task<IEnumerable<Product>> FindByCategoryIdAsync(Guid id)
        {
            return await context.Products.Where(prod => prod.categoryId == id).ToListAsync();
        }

        public async Task<IEnumerable<Product>> FindByPriceSale(decimal price)
        {
            return await context.Products.Where(prod => prod.salePrice == price).ToListAsync();
        }

        public async Task<IEnumerable<Product>> FindByValidDateAsync(DateTime dateTime)
        {
            return await context.Products
                .Where(prod => prod.dataValid == dateTime)
                .ToListAsync();
        }

        public async Task<Product> updateAsync(Product product)
        {
            var result = context.Products.Update(product);
            return (await context.SaveChangesAsync() > 0) ? result.Entity : null;

        }

    }
}
