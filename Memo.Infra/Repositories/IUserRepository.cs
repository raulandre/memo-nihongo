using System.Collections;
using Memo.Domain.Models;

namespace Memo.Infra.Repositories;

public interface IUserRepository
{
    Task<User> Get(Guid id);
    Task<User> Get(string username);
    Task<User> Add(User user);
    Task<User> Update(Guid id, User user);
    Task<bool> Delete(Guid id);
    IQueryable GetWhere(Func<User, bool> condition);
}