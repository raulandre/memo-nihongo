using System.Collections;
using Memo.Domain.Models;

namespace Memo.Infra.Repositories.Users;

public interface IUserRepository
{
    Task<User> Get(Guid id);
    Task<User> Get(string username);
    Task<User> Add(User user);
    Task<User> Update(User user);
    Task Delete(User user);
    IQueryable<User> GetWhere(Func<User, bool> condition);
}