using SCEES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCEES.Domain.Services
{
    public interface IUserService
    {
        public Task<Usuario> createUser(Usuario usuario);

        public Task<IEnumerable<Usuario>> findAllAsync();

        public Task<Usuario> findByIdAsync(Guid id);

        public Task<Usuario> updateAsync(Usuario usuario);

        public Task<bool> deleteAsync(Guid id);

    }
}
