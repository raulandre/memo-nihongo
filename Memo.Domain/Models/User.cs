using System.ComponentModel.DataAnnotations;

namespace Memo.Domain.Models;

public class User
{
    [Key]
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }

    public User()
    { }

    public User(string username, string email, byte[] hash, byte[] salt)
    {
        Username = username;
        Email = email;
        PasswordHash = hash;
        PasswordSalt = salt;
    }
}