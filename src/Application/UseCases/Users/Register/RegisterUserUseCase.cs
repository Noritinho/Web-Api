using AutoMapper;
using Contracts.Communication.Users.Requests;
using Contracts.Communication.Users.Responses;
using Domain.Entities;
using Domain.Repositories;
using Domain.Repositories.User;
using Domain.Security.Cryptography;
using Domain.Security.Tokens;
using Exceptions.ExceptionsBase;
using Exceptions.Resources;

namespace Application.UseCases.Users.Register;

public class RegisterUserUseCase (
    IMapper mapper,
    IUserWriteOnlyRepository userWriteOnlyRepository,
    IUserReadOnlyRepository userReadOnlyRepository,
    IPasswordEncripter passwordEncripter,
    IAccessTokenGenerator accessTokenGenerator,
    IUnitOfWork unitOfWork) : IRegisterUserUseCase
{

    public async Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request)
    {
        await Validate(request);
        
        var user = mapper.Map<User>(request);
        user.Password = passwordEncripter.Encrypt(request.Password);
        user.UserIdentifier = Guid.NewGuid();

        await userWriteOnlyRepository.Add(user);
        await unitOfWork.Commit();

        return new ResponseRegisteredUserJson
        {
            Username = user.Username,
            UserRole = user.UserRole,
            Token = accessTokenGenerator.Generate(user)
        };
    }

    private async Task Validate(RequestRegisterUserJson request)
    {
        var result = await new RegisterUserValidator().ValidateAsync(request);

        var usernameExist = await userReadOnlyRepository.ExistActiveUserWithUsername(request.Username);
        var emailExist = await userReadOnlyRepository.ExistActiveUserWithEmail(request.Email);
        
        if (usernameExist) result.Errors.Add(new FluentValidation.Results.ValidationFailure(nameof(request.Username), UsersResourceErrorMessages.USERNAME_ALREADY_EXISTS));
        if (emailExist) result.Errors.Add(new FluentValidation.Results.ValidationFailure(nameof(request.Email), UsersResourceErrorMessages.EMAIL_ALREADY_EXISTS));

        if (result.IsValid) return;
        var errorMessages = result.Errors.Select(failure => failure.ErrorMessage).ToList();

        throw new ErrorOnValidationException(errorMessages);
    }
}