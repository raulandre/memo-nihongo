namespace Memo.Api.ViewModels.User;

public class LoginViewModel
{
    public string Username { get; set; }
    public string Password { get; set; }

    public LoginViewModel()
    { }

    public LoginViewModel(string username, string password)
    {
       Username = username;
       Password = password;
    }
}