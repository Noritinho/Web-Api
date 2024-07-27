using AutoMapper;
using Contracts.Communication.Users.Requests;
using Domain.Entities;

namespace Application.AutoMapper;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToEntity();
    }

    private void RequestToEntity()
    {
        CreateMap<RequestRegisterUserJson, User>();
    }
    
    private void EntityToResponse()
    {
    }
}