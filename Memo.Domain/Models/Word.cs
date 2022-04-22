using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Memo.Domain.Models;

public class Word
{   
    public Guid Id { get; set; }
    public string Text { get; set; }
    public DateTime Created { get; set; }
    public DateTime? LastReviewed { get; set; }
    public long TimesRemembered { get; set; }
    public long TimesForgotten { get; set; }

    [Required]
    [ForeignKey("UserId")]
    public User User { get; set; }
    public Guid UserId { get; set; }

    public Word(string text)
    {
        Id = Guid.NewGuid();
        Text = text;
        Created = DateTime.UtcNow;
        LastReviewed = null;
        TimesForgotten = 0;
        TimesRemembered = 0;
    }
    
    public Word(string text, Guid userId)
    {
        Id = Guid.NewGuid();
        Text = text;
        LastReviewed = DateTime.UtcNow;
        TimesForgotten = 0;
        TimesRemembered = 0;
        UserId = userId;
    }
}