using Microsoft.EntityFrameworkCore;
using SCEES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCEES.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        protected readonly ContextDbApp contextDbApp;

        public UserRepository(ContextDbApp contextDb)
        {
            this.contextDbApp = contextDb;
        }
        public async Task<Usuario> FindAsync(Guid id)
        {
            return await contextDbApp.User.FirstOrDefaultAsync(user => user.id == id);
        }

        public async Task<IEnumerable<Usuario>> getAllAsync()
        {
            return await contextDbApp.User.ToListAsync();
        }
        public async Task<Usuario> addAsync(Usuario usuario)
        {
            var result = await contextDbApp.User.AddAsync(usuario);
            return (await contextDbApp.SaveChangesAsync() > 0) ? result.Entity : null;
        }
        public async Task<Usuario> updateAsync(Usuario usuario)
        {
            var data = contextDbApp.User.Update(usuario);
            return (await contextDbApp.SaveChangesAsync() > 0) ? data.Entity : null;
        }

        public async Task<bool> deleteAsync(Usuario usuario)
        {
            contextDbApp.User.Remove(usuario);
            return await contextDbApp.SaveChangesAsync() > 0;
        }

        
    }
}
