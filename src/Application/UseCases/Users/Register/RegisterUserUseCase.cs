using AutoMapper;
using Contracts.Communication.Users.Requests;
using Contracts.Communication.Users.Responses;
using Domain.Entities;
using Domain.Repositories;
using Domain.Repositories.User;
using Exceptions.ExceptionsBase;

namespace Application.UseCases.Users.Register;

public class RegisterUserUseCase (
    IMapper mapper,
    IUserWriteOnlyRepository userWriteOnlyRepository,
    IUserReadOnlyRepository userReadOnlyRepository,
    IUnitOfWork unitOfWork) : IRegisterUserUseCase
{

    public async Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request)
    {
        await Validate(request);
        
        var user = mapper.Map<User>(request);
        user.UserIdentifier = Guid.NewGuid();

        await userWriteOnlyRepository.Add(user);
        await unitOfWork.Commit();

        return new ResponseRegisteredUserJson
        {
            Username = user.Username,
            UserRole = user.UserRole,
            Token = user.UserIdentifier.ToString()
        };
    }

    private async Task Validate(RequestRegisterUserJson request)
    {
        var result = new RegisterUserValidator().Validate(request);

        var usernameExist = await userReadOnlyRepository.ExistActiveUserWithUsername(request.Username);
        var emailExist = await userReadOnlyRepository.ExistActiveUserWithEmail(request.Email);
        
        if (usernameExist) result.Errors.Add(new FluentValidation.Results.ValidationFailure(nameof(request.Username), "Username already exists"));
        if (emailExist) result.Errors.Add(new FluentValidation.Results.ValidationFailure(nameof(request.Email), "Email already exists"));

        if (result.IsValid) return;
        var errorMessages = result.Errors.Select(failure => failure.ErrorMessage).ToList();

        throw new ErrorOnValidationException(errorMessages);
    }
}