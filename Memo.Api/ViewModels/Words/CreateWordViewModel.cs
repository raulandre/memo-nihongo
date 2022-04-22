namespace Memo.Api.ViewModels.Words;

public class CreateWordViewModel
{
    public string Text { get; set; }

    public CreateWordViewModel()
    {
        Text = string.Empty;
    }
    
    public CreateWordViewModel(string text)
    {
        Text = text;   
    }
}