using Contracts.Communication.Users.Responses;

namespace Application.UseCases.Users.Profiles;

public interface IGetUserProfileUseCase
{
    Task<ResponseUserProfileJson> Execute(string usernameOrEmail);
}