using Contracts.Communication.Users.Requests;
using FluentValidation;

namespace Application.UseCases.Users.Register;

public class RegisterUserValidator : AbstractValidator<RequestRegisterUserJson>
{
    public RegisterUserValidator()
    {
        RuleFor(user => user.UserName).NotEmpty()
    }
}