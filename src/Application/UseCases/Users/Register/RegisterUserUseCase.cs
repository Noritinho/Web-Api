using AutoMapper;
using Contracts.Communication.Users.Requests;
using Contracts.Communication.Users.Responses;
using Domain.Entities;
using Domain.Repositories.User;
using Exceptions.ExceptionsBase;

namespace Application.UseCases.Users.Register;

public class RegisterUserUseCase (
    IMapper mapper,
    IUserWriteOnlyRepository userWriteOnlyRepository,
    IUnitOfWork unitOfWork) : IRegisterUserUseCase
{

    public async Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request)
    {
        Validate(request);
        
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

    private void Validate(RequestRegisterUserJson request)
    {
        var result = new RegisterUserValidator().Validate(request);

        if (result.IsValid) return;
        var errorMessages = result.Errors.Select(failure => failure.ErrorMessage).ToList();

        throw new ErrorOnValidationException(errorMessages);
    }
}