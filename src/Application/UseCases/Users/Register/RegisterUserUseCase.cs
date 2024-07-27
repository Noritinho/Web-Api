using AutoMapper;
using Contracts.Communication.Users.Requests;
using Contracts.Communication.Users.Responses;
using Domain.Entities;

namespace Application.UseCases.Users.Register;

public class RegisterUserUseCase(IMapper mapper) : IRegisterUserUseCase
{

    public ResponseRegisteredUserJson Execute(RequestRegisterUserJson request)
    {
        var user = mapper.Map<User>(request);
        user.UserIdentifier = Guid.NewGuid();

        return new ResponseRegisteredUserJson
        {
            Username = user.Username,
            UserRole = user.UserRole,
            Token = user.UserIdentifier.ToString()
        };
    }
}