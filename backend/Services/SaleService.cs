using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SCEES.Domain.Models;
using SCEES.Domain.Services;
using SCEES.Domain.Repositories;

namespace SCEES.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository saleRepository;
        private readonly IProductService productService;

        public SaleService(ISaleRepository repositoryS,IProductService serviceP){
            this.saleRepository = repositoryS;
            this.productService = serviceP;
        }
        public async Task<Sale> createAsync(Sale sale)
        {
            var product = await productService.findAsync(sale.idProduct);
            if(product!=null){
                if(product.qtd>=sale.qtd){
                    sale.product = product;
                    product.qtd = product.qtd-sale.qtd;
                    await productService.updateAsync(product);
                    return await saleRepository.create(sale);
                }
            }
            
            return sale;
        }

        public async Task<bool> deleteAsync(Guid id)
        {
            var item = await saleRepository.findById(id);
            if(item==null) return false;
            return await saleRepository.deleteAsync(item);
        }
        public Task<Sale> updateAsync(Sale sale)
        {
            sale.updatedAt = DateTime.UtcNow;
            return saleRepository.update(sale);
        }
        
        public async Task<IEnumerable<Sale>> findAllAsync()
        {
            return await saleRepository.findAllAsync();
        }

        public async Task<IEnumerable<Sale>> findByDateCreate(DateTime dateTime)
        {
            return await saleRepository.findByDateCreation(dateTime);
        }

        public Task<Sale> findById(Guid id)
        {
            return saleRepository.findById(id);
        }

        public Task<IEnumerable<Sale>> findByIdProduct(Guid id)
        {
            return saleRepository.findByIdProduct(id);
        }

        public Task<IEnumerable<Sale>> findByNameClient(string name)
        {
            return saleRepository.findByNameClient(name);
        }

        public Task<IEnumerable<Sale>> findByQtd(int qtd)
        {
            return saleRepository.findByQtd(qtd);
        }

    }
}