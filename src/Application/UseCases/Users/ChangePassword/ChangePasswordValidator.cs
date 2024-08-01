using Contracts.Communication.Users.Requests;
using Exceptions.Resources;
using FluentValidation;

namespace Application.UseCases.Users.ChangePassword;

public class ChangePasswordValidator : AbstractValidator<RequestChangePasswordJson>
{
    public ChangePasswordValidator()
    {
        RuleFor(user => user.NewPassword)
            .NotEmpty().WithMessage(UsersResourceErrorMessages.PASSWORD_EMPTY)
            .MinimumLength(8).WithMessage(UsersResourceErrorMessages.PASSWORD_LENGHT)
            .MaximumLength(50).WithMessage(UsersResourceErrorMessages.PASSWORD_LENGHT)
            .Matches(@"^(?=.*[a-z])(?=.*[A-Z])").WithMessage(UsersResourceErrorMessages.PASSWORD_INVALID)
            .Matches(@"(?=.*\d.*\d)").WithMessage(UsersResourceErrorMessages.PASSWORD_INVALID)
            .Matches(@"(?=.*[@$!%*?&])").WithMessage(UsersResourceErrorMessages.PASSWORD_INVALID);
    }
}