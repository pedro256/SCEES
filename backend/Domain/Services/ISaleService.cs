using System.Threading.Tasks;
using System.Collections.Generic;
using SCEES.Domain.Models;
using System;

namespace SCEES.Domain.Services
{
    public interface ISaleService
    {
        public Task<Sale> createAsync(Sale sale);
        public Task<Sale> updateAsync(Sale sale);
        public Task<bool> deleteAsync(Guid id);
        public Task<IEnumerable<Sale>> findAllAsync();
        public Task<Sale> findById(Guid id);
        public Task<IEnumerable<Sale>> findByIdProduct(Guid id);
        public Task<IEnumerable<Sale>> findByDateCreate(DateTime dateTime);
        public Task<IEnumerable<Sale>> findByNameClient(string name);
        public Task<IEnumerable<Sale>> findByQtd(int qtd);

        

    }
}