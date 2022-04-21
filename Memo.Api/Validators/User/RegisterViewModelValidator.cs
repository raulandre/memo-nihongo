using FluentValidation;
using Memo.Api.ViewModels.User;

namespace Memo.Api.Validators.User;

public class RegisterViewModelValidator : AbstractValidator<RegisterViewModel>
{
    public RegisterViewModelValidator()
    {
        RuleFor(u => u.Username)
            .MinimumLength(3).WithMessage("Username must be at least 3 letters long!")
            .MaximumLength(20).WithMessage("Username can't exceed 20 letters!")
            .NotEmpty().WithMessage("Username can't be empty!");

        RuleFor(u => u.Email).EmailAddress();

        RuleFor(u => u.Password)
            .MinimumLength(6).WithMessage("Password must be at least 6 letters long!")
            .MaximumLength(25).WithMessage("Password can't exceed 25 letters!")
            .NotEmpty().WithMessage("Password can't be empty!");
    }
}