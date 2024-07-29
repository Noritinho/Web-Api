using AutoMapper;
using Contracts.Communication.Users.Responses;
using Domain.Repositories.User;

namespace Application.UseCases.Users.Profiles;

public class GetUserProfileUseCase(
    IMapper mapper,
    IUserReadOnlyRepository userReadOnlyRepository) : IGetUserProfileUseCase
{
    public async Task<ResponseUserProfileJson> Execute(string usernameOrEmail)
    {
        var user = await userReadOnlyRepository.GetUserByUsernameOrEmail(usernameOrEmail);
        return mapper.Map<ResponseUserProfileJson>(user);
    }
}