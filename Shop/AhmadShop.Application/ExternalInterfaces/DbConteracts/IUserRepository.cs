using AhmadShop.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhmadShop.Application.ExternalInterfaces.DbConteracts
{
    public interface IUserRepository
    {
        Task<User> FindByIdAsync(int id);
        Task<User> FindByNameAsync(string username);
        Task<List<User>> GetAllAsync();
        Task CreateAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(User user);
        Task<bool> CheckPasswordAsync(User user, string password);
        Task AddToRoleAsync(User user, string role);
        Task<IList<string>> GetRolesAsync(User user);
    }



}
