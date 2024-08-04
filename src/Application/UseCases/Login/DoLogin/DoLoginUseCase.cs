using Contracts.Communication.Login.Requests;
using Contracts.Communication.Users.Responses;
using Domain.Repositories.User;
using Domain.Security.Cryptography;
using Domain.Security.Tokens;

namespace Application.UseCases.Login.DoLogin;

public class DoLoginUseCase(
    IUserReadOnlyRepository userReadOnlyRepository,
    IPasswordEncripter passwordEncripter,
    IAccessTokenGenerator accessTokenGenerator) : IDoLoginUseCase
{
    public async Task<ResponseRegisteredUserJson> Execute(RequestLoginJson request)
    {
        var user = await userReadOnlyRepository.GetUserByUsernameOrEmail(request.UsernameOrEmail);

        if (user is null)
        {
            throw new Exception("User not found");
        }
        
        var passwordMatch = passwordEncripter.Verify(request.Password, user.Password);

        if (!passwordMatch)
        {
            throw new Exception("Invalid");
        }

        return new ResponseRegisteredUserJson
        {
            Username = user.Username,
            Token = accessTokenGenerator.Generate(user)
        };
    }
}