using System.Collections;
using Memo.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Memo.Infra.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DataContext context;

    public UserRepository(DataContext context)
    {
        this.context = context;   
    }

    public async Task<User> Add(User user)
    {
        if(context.Users.Any(u => u.Username.Equals(user.Username) || u.Email.Equals(user.Email)))
            throw new Exception("Username or email already in use!");

        user.Email = user.Email.ToLower();
        user.Username = user.Username.ToLower();

        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return user;
    }

    public async Task<bool> Delete(Guid id)
    {
        var user = Get(id);

        if(user is not null)
        {
            context.Remove(user);
            await context.SaveChangesAsync();
            return true;
        }

        return false;
    }

    public async Task<User> Get(Guid id)
    {
        return await context.Users.FirstOrDefaultAsync(u => u.Id.Equals(id)); 
    }

    public async Task<User> Get(string username)
    {
        return await context.Users.FirstOrDefaultAsync(u => u.Username.Equals(username));
    }

    public IQueryable GetWhere(Func<User, bool> condition)
    {
        return context.Users.Where(condition).AsQueryable();
    }

    public async Task<User> Update(Guid id, User user)
    {
        user.Id = id;
        context.Update(user);
        await context.SaveChangesAsync();
        return user;
    }
}