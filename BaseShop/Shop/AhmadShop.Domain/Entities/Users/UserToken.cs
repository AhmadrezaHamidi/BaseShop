using Microsoft.AspNetCore.Identity;

namespace AhmadShop.Domain.Entities.Users;

public class UserToken : IdentityUserToken<int>, IEntity
{
}
