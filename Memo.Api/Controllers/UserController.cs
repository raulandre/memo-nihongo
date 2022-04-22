using Memo.Api.ViewModels.User;
using Memo.Domain.Models;
using Memo.Domain.Managers.Users;
using Memo.Infra.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace Memo.Api.Controllers;

[ApiController]
[AllowAnonymous]
[Route("auth")]
public class UserController : ControllerBase
{
    private readonly IUsersManager userManager;
    private readonly IMapper mapper;

    public UserController(IUsersManager userManager, IMapper mapper)
    {
        this.userManager = userManager;
        this.mapper = mapper;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginViewModel request)
    {
        var user = userManager.GetByUsername(request.Username);
        if(user is null)
            return NotFound("User not found!");

        if(PasswordUtils.VerifyPasswordHash(user, request.Password, user.PasswordHash, user.PasswordSalt))
        {
            return Ok(PasswordUtils.CreateToken(user));
        }

        return Unauthorized("Wrong credentials!");
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterViewModel request)
    {
        PasswordUtils.CreatePasswordHash(request.Password, out byte[] hash, out byte[] salt);
        var user = new User(request.Username, request.Email, hash, salt);
        var userCreated = await userManager.Create(user);
        return Ok(mapper.Map<RegisterViewModel>(userCreated));
    }
}