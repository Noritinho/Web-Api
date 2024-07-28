using Contracts.Communication.Users.Requests;
using FluentValidation;

namespace Application.UseCases.Users.Register;

public class RegisterUserValidator : AbstractValidator<RequestRegisterUserJson>
{
    public RegisterUserValidator()
    {
        RuleFor(user => user.Username).NotEmpty().WithMessage("Username cannot be empty")
            .MinimumLength(3).WithMessage("Username must be at least 3 characters long")
            .MaximumLength(20).WithMessage("Username must be at most 20 characters long")
            .Matches("^[a-zA-Z0-9]+$").WithMessage("Username can only contain letters and numbers");

        RuleFor(user => user.Email).NotEmpty().WithMessage("Email cannot be empty")
            .Matches("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$").WithMessage("Email must be a valid email address");

        RuleFor(user => user.Password).NotEmpty().WithMessage("Password cannot be empty")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long")
            .MaximumLength(50).WithMessage("Password must be at most 20 characters long")
            .Matches("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$").WithMessage(
                "Password must contain at least one uppercase letter, one lowercase letter, and one number");
        
        RuleFor(user => user.UserRole).NotEmpty().WithMessage("UserRole cannot be empty")
            .Matches("^(admin|user)$").WithMessage("UserRole must be 'admin' or 'user'");
        
    }
}