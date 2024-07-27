using Contracts.Communication.Users.Requests;
using Contracts.Communication.Users.Responses;

namespace Application.UseCases.Users.Register;

public interface IRegisterUserUseCase
{
    public ResponseRegisteredUserJson Execute(RequestRegisterUserJson request);
}