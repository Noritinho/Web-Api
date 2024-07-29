using AutoMapper;
using Contracts.Communication.Users.Responses;
using Domain.Repositories.User;

namespace Application.UseCases.Users.GetAll;

public class GetAllUserUseCase(
    IMapper mapper,
    IUserReadOnlyRepository userReadOnlyRepository) : IGetAllUserUseCase
{
    public async Task<ResponseUsersJson> Execute()
    {
        var users = await userReadOnlyRepository.GetAllUsers();

        return new ResponseUsersJson
        {
            Users = mapper.Map<List<ResponseShortUserProfile>>(users)
        };
    }
}