using AhmadShop.Application.CQRS.Commands.User;
using AhmadShop.Application.Models.InputDtos.User;
using Asp.Versioning;
using CHMS.Api.Controllers.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;

namespace AhmadShop.Api.Controllers;

[ApiController]
[ApiVersion(ApiVersions.V1)]
[Route("api/v{version:apiVersion}/User")]
public class UserController : ControllerBase
{
    private readonly ISender _sender;
    public UserController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost("[action]")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginInput login)
    {
        try
        {
            var query = new LoginQuery(login.username, login.password);
            Result<hoshmand.cardisposal.Application.Dtos.Auth.TokenDto?> result = await _sender.Send(query);
            return Ok(result.Value);
        }
        catch (Exception e2)
        {
            var errors = new List<ValidationError>();
            errors.Add(new ValidationError("401", e2.Message));
            throw new ValidationException(errors);
        }
    }


}
