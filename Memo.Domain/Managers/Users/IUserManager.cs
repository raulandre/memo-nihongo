using Memo.Domain.Models;

namespace Memo.Domain.Managers.Users;

public interface IUserManager
{
    User GetByUsername(string username);
    Task<User> Create(User user);
    Task<User> Update(User user);
    Task<bool> Delete(Guid id);
}