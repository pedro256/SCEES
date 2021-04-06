using SCEES.Domain.Models;
using SCEES.Domain.Repositories;
using SCEES.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCEES.Services
{
    public class CategoryService : ICategoryService
    {
        public ICategoryRepository categoryRepository;
        public CategoryService(ICategoryRepository IcategoryResitory)
        {
            this.categoryRepository = IcategoryResitory;
        }


        public async Task<Category> create(Category category)
        {
            return await categoryRepository.addAsync(category);
        }

        public async Task<bool> deleteAsync(Guid id)
        {
            Category category = await categoryRepository.FindAsync(id);
            if (category != null) return await categoryRepository.deleteAsync(category);
            return false;
        }

        public async Task<IEnumerable<Category>> findAllAsync()
        {
            return await categoryRepository.FindAllAsync();
        }

        public async Task<Category> findByIdAsync(Guid id)
        {
            return await categoryRepository.FindAsync(id);
        }

        public async Task<IEnumerable<Category>> findByNameAsync(string name)
        {
            return await categoryRepository.FindAsync(name);
        }

        public async Task<Category> updateAsync(Category category)
        {
            category.updatedAt = DateTime.UtcNow;
            return await categoryRepository.updateAsync(category);
        }
    }
}
