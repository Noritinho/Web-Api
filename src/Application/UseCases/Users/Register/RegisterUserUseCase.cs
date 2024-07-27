using AutoMapper;
using Contracts.Communication.Users.Requests;
using Contracts.Communication.Users.Responses;
using Domain.Entities;

namespace Application.UseCases.Users.Register;

public class RegisterUserUseCase() : IRegisterUserUseCase
{

    public ResponseRegisteredUserJson Execute(RequestRegisterUserJson request)
    {

        return new ResponseRegisteredUserJson();
    }
}