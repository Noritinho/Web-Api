using AutoMapper;
using Contracts.Communication.Users.Requests;
using Contracts.Communication.Users.Responses;
using Domain.Entities;

namespace Application.AutoMapper;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToEntity();
        EntityToResponse();
    }

    private void RequestToEntity()
    {
        CreateMap<RequestRegisterUserJson, User>()
            .ForMember(user => user.Password, config => config.Ignore());
    }
    
    private void EntityToResponse()
    {
        CreateMap<User, ResponseUserProfileJson>();
        CreateMap<User, ResponseShortUserProfile>();
    }
}