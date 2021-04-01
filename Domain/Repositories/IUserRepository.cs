using SCEES.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SCEES.Persistence.Repositories
{
    public interface IUserRepository
    {
        public Task<IEnumerable<Usuario>> getAllAsync();

        public Task<Usuario> FindAsync(Guid id);

        public Task<Usuario> addAsync(Usuario usuario);

        public Task<Usuario> updateAsync(Usuario usuario);

        public Task<bool> deleteAsync(Usuario usuario);

    }
}
