using System.Collections.Generic;
using System.Threading.Tasks;
using SCEES.Domain.Models;
using SCEES.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace SCEES.Persistence.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        protected readonly ContextDbApp context;
        public SaleRepository(ContextDbApp _context){
            this.context = _context;
        }

        
        //FINDERS
        public async Task<IEnumerable<Sale>> findAllAsync()
        {
            return await context.Sales.ToListAsync();

        }
        public async Task<IEnumerable<Sale>> findByDateCreation(DateTime dateTime)
        {
            return await context.Sales.Where(sale => sale.createdAt == dateTime).ToListAsync();
        }

        public async Task<Sale> findById(Guid id)
        {
            return await context.Sales.FirstOrDefaultAsync(sale => sale.id == id);
        }

        public async Task<IEnumerable<Sale>> findByIdProduct(Guid id)
        {
            return await context.Sales.Where(sale => sale.idProduct == id).ToListAsync();

        }

        public async Task<IEnumerable<Sale>> findByNameClient(string name)
        {
            return await context.Sales.Where(
                sale => EF.Functions.Like(sale.nameClient,"%"+name+"%")
                ).ToListAsync();
        }

        public async Task<IEnumerable<Sale>> findByQtd(int qtd)
        {
            return await context.Sales.Where(sale => sale.qtd == qtd).ToListAsync();
        }
        
        //OTHERS
        public async Task<Sale> create(Sale sale)
        {
            var item = await context.AddAsync(sale);
            return (await context.SaveChangesAsync() > 0) ? item.Entity : null;
        }

        public async Task<bool> deleteAsync(Sale sale)
        {
            context.Sales.Remove(sale);
            return (await context.SaveChangesAsync()>0);
        }
        public async Task<Sale> update(Sale sale)
        {
            var item = context.Update(sale);
            return (await context.SaveChangesAsync() > 0) ? item.Entity : null;
        }
    }
}