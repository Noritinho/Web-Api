using Contracts.Communication.Users.Requests;
using Domain.Entities;

namespace Application.UseCases.Users.ChangePassword;

public interface IChangePasswordUseCase
{
    public Task Execute(RequestChangePasswordJson request, string usernameOrEmail);
}