using SCEES.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCEES.Domain.Repositories
{
    public interface ICategoryRepository
    {
        public Task<IEnumerable<Category>> FindAllAsync();

        public Task<Category> FindAsync(Guid id);

        public Task<IEnumerable<Category>> FindAsync(string name);

        public Task<Category> addAsync(Category category);

        public Task<Category> updateAsync(Category category);

        public Task<bool> deleteAsync(Category category);
    }
}
