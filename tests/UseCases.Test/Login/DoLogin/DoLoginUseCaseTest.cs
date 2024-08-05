using Application.UseCases.Login.DoLogin;
using CommonTestUtilities.Cryptography;
using CommonTestUtilities.Entities;
using CommonTestUtilities.Repositories;
using CommonTestUtilities.Requests;
using CommonTestUtilities.Token;
using Domain.Entities;
using FluentAssertions;

namespace UseCases.Test.Login.DoLogin;

public class DoLoginUseCaseTest
{
    [Fact]
    public async Task Success()
    {
        var user = UserBuilder.Build();
        var request = RequestLoginJsonBuilder.Build();
        request.UsernameOrEmail = user.Username;
        var useCase = CreateUseCase(user, request.Password);

        var result = await useCase.Execute(request);

        result.Should().NotBeNull();
        result.Username.Should().Be(user.Username);
        result.Token.Should().NotBeNullOrWhiteSpace();
    }

    private DoLoginUseCase CreateUseCase(User user, string password)
    {
        var passwordEncripter = new PasswordEncrypterBuilder().Verify(password).Build();
        var tokenGenerator = JwtTokenGeneratorBuilder.Build();
        var readOnlyRepository = new UserReadOnlyRepositoryBuilder().GetUserByUsernameOrEmail(user).Build();

        return new DoLoginUseCase(readOnlyRepository, passwordEncripter, tokenGenerator);
    }
}