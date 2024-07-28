using AutoMapper;
using Contracts.Communication.Users.Requests;
using Contracts.Communication.Users.Responses;
using Domain.Entities;
using Exceptions.ExceptionsBase;
using Microsoft.Extensions.Options;

namespace Application.UseCases.Users.Register;

public class RegisterUserUseCase(IMapper mapper) : IRegisterUserUseCase
{

    public ResponseRegisteredUserJson Execute(RequestRegisterUserJson request)
    {
        Validate(request);
        
        var user = mapper.Map<User>(request);
        user.UserIdentifier = Guid.NewGuid();

        return new ResponseRegisteredUserJson
        {
            Username = user.Username,
            UserRole = user.UserRole,
            Token = user.UserIdentifier.ToString()
        };
    }

    private void Validate(RequestRegisterUserJson request)
    {
        var result = new RegisterUserValidator().Validate(request);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(failure => failure.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}