using Contracts.Communication.Users.Requests;
using Contracts.Communication.Users.Responses;

namespace Application.UseCases.Users.Register;

public interface IRegisterUserUseCase
{
    public Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request);
}