using System.Collections;
using Memo.Domain.Models;
using Memo.Domain.Repositories;
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
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return user;
    }

    public async Task Delete(User user)
    {
        context.Remove(user);
        await context.SaveChangesAsync();
    }

    public async Task<User> Get(Guid id)
    {
        return await context.Users.FirstOrDefaultAsync(u => u.Id.Equals(id)); 
    }

    public async Task<User> Get(string username)
    {
        return await context.Users.FirstOrDefaultAsync(u => u.Username.Equals(username));
    }

    public IQueryable<User> GetWhere(Func<User, bool> condition)
    {
        return context.Users.Where(condition).AsQueryable();
    }

    public async Task<User> Update(User user)
    {
        context.Update(user);
        await context.SaveChangesAsync();
        return user;
    }
}