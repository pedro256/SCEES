using SCEES.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCEES.Domain.Services
{
    public interface ICategoryService
    {
        public Task<Category> create(Category category);
        public Task<IEnumerable<Category>> findAllAsync();
        public Task<Category> findByIdAsync(Guid id);
        public Task<IEnumerable<Category>> findByNameAsync(string name);
        public Task<Category> updateAsync(Category category);
        public Task<bool> deleteAsync(Guid id);

    }
}
