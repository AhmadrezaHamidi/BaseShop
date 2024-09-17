using AhmadShop.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;

namespace AhmadShop.Domain.Entities.Users;
public class User : IdentityUser<int>, IEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string RefreshToken { get; set; } = "";

}
