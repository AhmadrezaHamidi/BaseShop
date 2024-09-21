using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhmadShop.Application.CQRS.Commands.User;

public sealed record LoginQuery(string username, string password) : IRequest<TokenDto?>;

public sealed class LoginQueryHandler : IRequestHandler<LoginQuery, TokenDto?>
{
    private readonly IUserService userService;

    public LoginQueryHandler(IUserService userService)
    {
        this.userService = userService;
    }

    public async Task<Result<TokenDto?>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var reslt = await userService.GetToken(request.username, request.password);
        return reslt;
    }
}
