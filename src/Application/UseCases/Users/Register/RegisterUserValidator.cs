using Contracts.Communication.Users.Requests;
using FluentValidation;

namespace Application.UseCases.Users.Register;

public class RegisterUserValidator : AbstractValidator<RequestRegisterUserJson>
{
    public RegisterUserValidator()
    {
        RuleFor(user => user.Username).NotEmpty().WithMessage("Username cannot be empty");
        RuleFor(user => user.Email).NotEmpty().WithMessage("Email cannot be empty");
        RuleFor(user => user.Password).NotEmpty().WithMessage("Password cannot be empty");
        RuleFor(user => user.UserRole).NotEmpty().WithMessage("UserRole cannot be empty");
        
    }
}