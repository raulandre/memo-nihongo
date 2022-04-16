using Memo.Domain.Models;
using Memo.Infra.Repositories.Users;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Memo.Infra.Managers.Users;

public class UserManager : IUserManager
{
    private readonly IUserRepository userRepository;

    public async Task<User> Create(User user)
    {
        if(await userRepository.GetWhere(u => u.Username.Equals(user.Username) || u.Email.Equals(user.Email)).AnyAsync())
            throw new Exception("Username or email already in use!");

        user.Email = user.Email.ToLower();
        user.Username = user.Username.ToLower();
        return await userRepository.Add(user);
    }

    public async Task<User> Update(User user)
    {
        return await userRepository.Update(user);
    }

    public Task<User> GetByUsername(string username)
    {
        return userRepository.GetWhere(u => u.Username.Equals(username)).FirstOrDefaultAsync();
    }

    public async Task<bool> Delete(Guid id)
    {
        var user = await userRepository.Get(id);

        if(user is not null)
        {
            await userRepository.Delete(user);
            return true;
        }

        return false;
    }
}