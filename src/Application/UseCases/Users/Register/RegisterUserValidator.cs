using Contracts.Communication.Users.Requests;
using Exceptions.Resources;
using FluentValidation;

namespace Application.UseCases.Users.Register;

public class RegisterUserValidator : AbstractValidator<RequestRegisterUserJson>
{
    public RegisterUserValidator()
    {
        RuleFor(user => user.Username).NotEmpty().WithMessage(UsersResourceErrorMessages.USERNAME_EMPTY)
            .MinimumLength(3).WithMessage(UsersResourceErrorMessages.USERNAME_LENGHT)
            .MaximumLength(20).WithMessage(UsersResourceErrorMessages.USERNAME_LENGHT)
            .Matches("^[a-zA-Z0-9._@#$%&*!]+$").WithMessage(UsersResourceErrorMessages.USERNAME_INVALID);

        RuleFor(user => user.Email).NotEmpty().WithMessage(UsersResourceErrorMessages.EMAIL_EMPTY)
            .Matches("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$").WithMessage(UsersResourceErrorMessages.EMAIL_INVALID);

        RuleFor(user => user.Password)
            .NotEmpty().WithMessage(UsersResourceErrorMessages.PASSWORD_EMPTY)
            .MinimumLength(8).WithMessage(UsersResourceErrorMessages.PASSWORD_LENGHT)
            .MaximumLength(50).WithMessage(UsersResourceErrorMessages.PASSWORD_LENGHT)
            .Matches(@"^(?=.*[a-z])(?=.*[A-Z])").WithMessage(UsersResourceErrorMessages.PASSWORD_INVALID)
            .Matches(@"(?=.*\d.*\d)").WithMessage(UsersResourceErrorMessages.PASSWORD_INVALID)
            .Matches(@"(?=.*[@$!%*?&])").WithMessage(UsersResourceErrorMessages.PASSWORD_INVALID);

        RuleFor(user => user.UserRole).IsInEnum().WithMessage(UsersResourceErrorMessages.USER_ROLE_INVALID);
    }
}