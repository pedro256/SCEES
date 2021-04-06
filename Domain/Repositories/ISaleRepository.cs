using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SCEES.Domain.Models;

namespace SCEES.Domain.Repositories
{
    public interface ISaleRepository
    {
         public Task<IEnumerable<Sale>> findAllAsync();
         public Task<Sale> findById(Guid id);
         public Task<IEnumerable<Sale>> findByIdProduct(Guid id);
         public Task<IEnumerable<Sale>> findByQtd(int qtd);
         public Task<IEnumerable<Sale>> findByNameClient(string name);
         public Task<IEnumerable<Sale>> findByDateCreation(DateTime dateTime);
         public Task<Sale> create(Sale sale);
         public Task<Sale> update(Sale sale);
         public Task<bool> deleteAsync(Sale sale);

    }
}