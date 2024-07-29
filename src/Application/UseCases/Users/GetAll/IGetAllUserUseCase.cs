using Contracts.Communication.Users.Responses;

namespace Application.UseCases.Users.GetAll;

public interface IGetAllUserUseCase
{
    Task<ResponseUsersJson> Execute();
}