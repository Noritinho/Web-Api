using Contracts.Communication.Users.Requests;
using FluentValidation;

namespace Application.UseCases.Users.ChangePassword;

public class ChangePasswordValidator : AbstractValidator<RequestChangePasswordJson>
{
    public ChangePasswordValidator()
    {
        RuleFor(user => user.NewPassword).NotEmpty().WithMessage("Password cannot be empty")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long")
            .MaximumLength(50).WithMessage("Password must be at most 20 characters long")
            .Matches("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$").WithMessage(
                "Password must contain at least one uppercase letter, one lowercase letter, and one number");
    }
}