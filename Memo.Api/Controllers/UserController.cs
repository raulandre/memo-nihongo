using Memo.Api.ViewModels.User;
using Memo.Domain.Models;
using Memo.Infra;
using Memo.Infra.Repositories;
using Memo.Infra.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Memo.Api.Controllers;

[Route("auth")]
public class UserController : ControllerBase
{
    private readonly IUserRepository userRepository;

    public UserController(IUserRepository userRepository)
    {
        this.userRepository = userRepository;        
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginViewModel request)
    {
        var user = await userRepository.Get(request.username);
        if(user is null)
            return NotFound("User not found!");

        if(PasswordUtils.VerifyPasswordHash(user, request.password, user.PasswordHash, user.PasswordSalt))
        {
            return Ok(PasswordUtils.CreateToken(user));
        }

        return Unauthorized("Wrong credentials!");
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterViewModel request)
    {
        PasswordUtils.CreatePasswordHash(request.password, out byte[] hash, out byte[] salt);
        var user = new User(request.username, request.email, hash, salt);
        await userRepository.Add(user);
        return Ok(user);
    }
}