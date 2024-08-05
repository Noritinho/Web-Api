using Contracts.Communication.Users.Requests;
using Domain.Entities;
using Domain.Repositories;
using Domain.Repositories.User;
using Domain.Security.Cryptography;
using Exceptions.ExceptionsBase;

namespace Application.UseCases.Users.ChangePassword;

public class ChangePasswordUseCase(
    IPasswordEncrypter passwordEncrypter,
    IUserReadOnlyRepository userReadOnlyRepository,
    IUserWriteOnlyRepository userWriteOnlyRepository,
    IUnitOfWork unitOfWork) : IChangePasswordUseCase
{
    public async Task Execute(RequestChangePasswordJson request, string usernameOrEmail)
    {
        var user = await userReadOnlyRepository.GetUserByUsernameOrEmail(request.UsernameOrEmail);
        Validate(request, user!);

        user!.Password = passwordEncrypter.Encrypt(request.NewPassword);
        userWriteOnlyRepository.Update(user);
        
        await unitOfWork.Commit();
    }

    private void Validate (RequestChangePasswordJson request, User user)
    {
        var validator = new ChangePasswordValidator();
        var result = validator.Validate(request);
        var passwordMatch = passwordEncrypter.Verify(request.Password, user.Password);
        
        if (!passwordMatch)
        {
            throw new Exception("Password match");
        }

        if (!result.IsValid)
        {
            var errors = result.Errors.Select(errors => errors.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errors);
        }
    }
}