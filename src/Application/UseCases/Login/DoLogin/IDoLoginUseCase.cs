using Contracts.Communication.Login.Requests;
using Contracts.Communication.Users.Responses;

namespace Application.UseCases.Login.DoLogin;

public interface IDoLoginUseCase
{
    public Task<ResponseRegisteredUserJson> Execute(RequestLoginJson request);
}