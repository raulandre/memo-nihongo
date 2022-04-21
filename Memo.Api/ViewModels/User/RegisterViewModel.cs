namespace Memo.Api.ViewModels.User;

public class RegisterViewModel
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public RegisterViewModel()
    {
        Username = string.Empty;
        Email = string.Empty   ;
        Password = string.Empty;
    }

    public RegisterViewModel(string username, string email, string password)
    {
        Username = username;
        Email = email;
        Password = password; 
    }
}