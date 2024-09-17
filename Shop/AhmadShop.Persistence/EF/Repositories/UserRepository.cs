using AhmadShop.Application.ExternalInterfaces.DbConteracts;
using AhmadShop.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace CHMS.Persistence.EF.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppUserManager _userManager;

        public UserRepository(AppUserManager userManager)
        {
            _userManager = userManager;
        }

        public async Task<User> FindByIdAsync(int id)
        {
            return await _userManager.FindByIdAsync(id.ToString());
        }

        public async Task<User> FindByNameAsync(string username)
        {
            return await _userManager.FindByNameAsync(username);
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task CreateAsync(User user)
        {
            await _userManager.CreateAsync(user);
        }

        public async Task UpdateAsync(User user)
        {
            await _userManager.UpdateAsync(user);
        }

        public async Task DeleteAsync(User user)
        {
            await _userManager.DeleteAsync(user);
        }

        public async Task<bool> CheckPasswordAsync(User user, string password)
        {
            var result = await _userManager.CheckPasswordAsync(user, password);
            return result;
        }

        public async Task AddToRoleAsync(User user, string role)
        {
            await _userManager.AddToRoleAsync(user, role);
        }

        public async Task<IList<string>> GetRolesAsync(User user)
        {
            return await _userManager.GetRolesAsync(user);
        }
    }

    //public async Task<Cheque?> ExistSayadiIdAsync(string sayadId)
    //{
    //    return await _context.Cheques.FirstOrDefaultAsync(c => c.SayadId == sayadId && !c.IsDeleted);
    //}

    //// Retrieve Cheque context with all related entities by SayadId
    //public async Task<Cheque?> GetChequeContextBySayadIdAsync(string sayadId)
    //{
    //    return await _context.Cheques
    //        .Include(c => c.Owners)
    //        .Include(c => c.Receivers)
    //        .Include(c => c.Signers)
    //        .FirstOrDefaultAsync(c => c.SayadId == sayadId && !c.IsDeleted);
    //}

    //public async Task<List<Person?>> GetPersones(List<PersonInput> input)
    //{
    //    if (input == null || !input.Any())
    //        return new List<Person?>();

    //    var idCodes = input.Select(i => i.IdCode).ToList();
    //    var idTypes = input.Select(i => Enum.TryParse(i.IdType, ignoreCase: true, out IdentificationType idType) ? idType : (IdentificationType?)null).ToList();

    //    var persons = await _context.Persons
    //        .Where(p => idCodes.Contains(p.Id) &&
    //                    (idTypes.Contains(p.Type) || !idTypes.Any(t => t.HasValue)) // Handle nullable types
    //                   )
    //        .ToListAsync();

    //    return persons;
    //}
}
}
