using SCEES.Domain.Services;
using SCEES.Models;
using SCEES.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCEES.Services
{
    public class UserServices : IUserService
    {
        public IUserRepository userRepository;

        public UserServices(IUserRepository InsertuserRepository)
        {
            this.userRepository = InsertuserRepository;
        }
        public async Task<Usuario> createUser(Usuario usuario)
        {
            return await userRepository.addAsync(usuario);
            
        }

        public async Task<IEnumerable<Usuario>> findAllAsync()
        {
            return await userRepository.getAllAsync();
        }

        public async Task<Usuario> findByIdAsync(Guid id)
        {
            return await userRepository.FindAsync(id);
        }

        public async Task<Usuario> updateAsync(Usuario usuario)
        {
            return await userRepository.updateAsync(usuario);
        }
        public async Task<bool> deleteAsync(Guid id)
        {
            Usuario user = await userRepository.FindAsync(id);
            if (user != null)
            {
                return await userRepository.deleteAsync(user);
            }
            else
            {
                return false;
            } 
        }
    }
}
