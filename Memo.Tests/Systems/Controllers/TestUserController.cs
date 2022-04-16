using System.Threading.Tasks;
using FluentAssertions;
using Memo.Api.Controllers;
using Memo.Domain.Models;
using Memo.Infra.Managers.Users;
using Memo.Infra.Utils;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Memo.Tests.Systems.Controllers;

public class TestUserController
{

    private readonly Mock<IUserManager> userManagerMock = new();

    public TestUserController()
    {
        PasswordUtils.CreatePasswordHash("password", out byte[] hash, out byte[] salt);
        userManagerMock.Setup(u => u.GetByUsername(It.Is<string>(s => s.Equals("raul")))).ReturnsAsync(new User("raul", "", hash, salt));
    }

    [Fact]
    public async Task Login_OnSuccess_ReturnsOk()
    {
        //Arrange
        var sut = new UserController(userManagerMock.Object);
        //Act
        var result = (OkObjectResult)await sut.Login(new("raul", "password"));
        //Assert 
        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public async Task Login_OnWrongPassword_ReturnsUnauthorized()
    {
        //Arrange
        var sut = new UserController(userManagerMock.Object);
        //Act
        var result = (UnauthorizedObjectResult)await sut.Login(new("raul", "wrong_password"));
        //Assert 
        result.StatusCode.Should().Be(401);
    }

    [Fact]
    public async Task Login_OnInexistentUsername_ReturnsBadRequest()
    {
        //Arrange
        var sut = new UserController(userManagerMock.Object);
        //Act
        var result = (NotFoundObjectResult)await sut.Login(new("raulandre", "password"));
        //Assert 
        result.StatusCode.Should().Be(404);
    }
}