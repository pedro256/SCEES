using Microsoft.EntityFrameworkCore;
using SCEES.Domain.Models;
using SCEES.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCEES.Persistence.Repositories
{
    public class CategoryRepository: ICategoryRepository
    {
        protected readonly ContextDbApp context;
        public CategoryRepository(ContextDbApp contextDbApp)
        {
            this.context = contextDbApp;
        }
        
        public async Task<IEnumerable<Category>> FindAllAsync()
        {
            return await context.Category.ToListAsync();
        }

        public async Task<Category> FindAsync(Guid id)
        {
            return await context.Category.FirstOrDefaultAsync(category => category.id == id);
        }
        public async Task<IEnumerable<Category>> FindAsync(string name)
        {
            return await context.Category.Where(category => EF.Functions.Like(category.name, "%" + name + "%")).ToListAsync();
        }

        public async Task<Category> addAsync(Category category)
        {
            var result = await context.Category.AddAsync(category);
            return (await context.SaveChangesAsync() > 0) ? result.Entity : null;
        }

        public async Task<Category> updateAsync(Category category)
        {
            var result = context.Category.Update(category);
            return (await context.SaveChangesAsync() > 0) ? result.Entity : null;
        }

        public async Task<bool> deleteAsync(Category category)
        {
            context.Category.Remove(category);
            return await context.SaveChangesAsync() > 0;
        }

        
    }
}
