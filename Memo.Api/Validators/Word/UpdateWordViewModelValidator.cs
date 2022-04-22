using FluentValidation;
using Memo.Api.ViewModels.Words;

namespace Memo.Api.Validators.Word;

public class UpdateWordViewModelValidator : AbstractValidator<UpdateWordViewModel>
{
    public UpdateWordViewModelValidator()
    {
        RuleFor(w => w.Text)
            .NotEmpty().WithMessage("Please inform a word!")
            .MaximumLength(25).WithMessage("Words must not exceed 25 letters!");
        
        RuleFor(w => w.TimesForgotten)
            .NotNull().WithMessage("Times forgotten is required!")
            .GreaterThanOrEqualTo(0).WithMessage("Times forgotten must be a positive value!");

        RuleFor(w => w.TimesRemembered)
            .NotNull().WithMessage("Times forgotten is required!")
            .GreaterThanOrEqualTo(0).WithMessage("Times forgotten must be a positive value!");
    }
}