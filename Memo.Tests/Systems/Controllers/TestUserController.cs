using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Memo.Api.Controllers;
using Memo.Domain.Managers.Users;
using Memo.Domain.Models;
using Memo.Infra.Utils;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Memo.Tests.Systems.Controllers;

public class TestUserController
{

    private readonly Mock<IUsersManager> userManagerMock = new();
    private readonly Mock<IMapper> mapper = new();

    public TestUserController()
    {
        PasswordUtils.CreatePasswordHash("password", out byte[] hash, out byte[] salt);
        userManagerMock.Setup(u => u.GetByUsername(It.Is<string>(s => s.Equals("raul")))).Returns(new User("raul", "", hash, salt));
        userManagerMock.Setup(u => u.Create(It.IsAny<User>())).ReturnsAsync(new User("raul", "", hash, salt));
    }

    [Fact]
    public void Login_OnSuccess_ReturnsOk()
    {
        //Arrange
        var sut = new UserController(userManagerMock.Object, mapper.Object);
        //Act
        var result = (OkObjectResult)sut.Login(new("raul", "password"));
        //Assert 
        result.StatusCode.Should().Be(200);
    }

    [Fact]
    public void Login_OnWrongPassword_ReturnsUnauthorized()
    {
        //Arrange
        var sut = new UserController(userManagerMock.Object, mapper.Object);
        //Act
        var result = (UnauthorizedObjectResult)sut.Login(new("raul", "wrong_password"));
        //Assert 
        result.StatusCode.Should().Be(401);
    }

    [Fact]
    public void Login_OnInexistentUsername_ReturnsNotFound()
    {
        //Arrange
        var sut = new UserController(userManagerMock.Object, mapper.Object);
        //Act
        var result = (NotFoundObjectResult)sut.Login(new("raulandre", "password"));
        //Assert 
        result.StatusCode.Should().Be(404);
    }

    [Fact]
    public async Task Register_OnSuccess_ReturnsOk()
    {
        //Arrange
        var sut = new UserController(userManagerMock.Object, mapper.Object);
        //Act
        var result = (OkObjectResult)await sut.Register(new("raul", "email", "password"));
        //Assert 
        result.StatusCode.Should().Be(200);
    }
}