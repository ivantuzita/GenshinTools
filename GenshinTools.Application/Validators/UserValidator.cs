using FluentValidation;
using GenshinTools.Application.DTOs;

namespace GenshinTools.Application.Validators; 
public class UserValidator : AbstractValidator<UserDTO> {
    public UserValidator()
    {
        RuleFor(p => p.Username)
            .NotEmpty().WithMessage("{Username} is required!")
            .NotNull()
            .MaximumLength(35).WithMessage("Number of characters on {Name} cannot be bigger than 35!");
        RuleFor(p => p.Password)
            .NotEmpty().WithMessage("Your password cannot be empty")
            .MinimumLength(8).WithMessage("Your password length must be at least 8.")
            .MaximumLength(16).WithMessage("Your password length must not exceed 16.")
            .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
            .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
            .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.")
            .Matches(@"[\!\?\*\.]+").WithMessage("Your password must contain at least one (!? *.).");
    }
}
