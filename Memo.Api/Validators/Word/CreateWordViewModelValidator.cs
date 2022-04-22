using FluentValidation;
using Memo.Api.ViewModels.Words;

namespace Memo.Api.Validators.Word;

public class CreateWordViewModelValidator : AbstractValidator<CreateWordViewModel>
{
    public CreateWordViewModelValidator()
    {
        RuleFor(w => w.Text)
            .NotEmpty().WithMessage("Please inform a word!")
            .MaximumLength(25).WithMessage("Words must not exceed 25 letters!");
    }
}