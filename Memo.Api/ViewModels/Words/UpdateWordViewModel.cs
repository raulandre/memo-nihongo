namespace Memo.Api.ViewModels.Words;

public class UpdateWordViewModel
{
    public UpdateWordViewModel(string text, long timesRemembered, long timesForgotten)
    {
        Text = text;
        TimesRemembered = timesRemembered;
        TimesForgotten = timesForgotten;
    }

    public string Text { get; set; }
    public long TimesRemembered { get; set; }
    public long TimesForgotten { get; set; }
}