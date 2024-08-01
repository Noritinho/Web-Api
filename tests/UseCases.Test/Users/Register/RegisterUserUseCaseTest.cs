using Application.UseCases.Users.Register;
using CommonTestUtilities.Cryptography;
using CommonTestUtilities.Mapper;
using CommonTestUtilities.Repositories;
using CommonTestUtilities.Requests;
using CommonTestUtilities.Token;
using Contracts.Communication.Users.Requests;
using FluentAssertions;

namespace UseCases.Test.Users.Register;

public class RegisterUserUseCaseTest
{
    [Fact]
    public async Task Success()
    {
        var request = RequestRegisterUserJsonBuilder.Build();

        var result = await CreateUseCase().Execute(request);

        result.Should().NotBeNull();
        result.Username.Should().Be(request.Username);
        result.UserRole.Should().Be(request.UserRole);
        result.Token.Should().NotBeNullOrWhiteSpace();
    }

    private RegisterUserUseCase CreateUseCase()
    {
        var mapper = MapperBuilder.Build();
        var unitOfWork = UnitOfWorkBuilder.Build();
        var userWriteOnlyRepository = UserWriteOnlyRepositoryBuilder.Build();
        var userReadOnlyRepository = UserReadOnlyRepositoryBuilder.Build();
        var passwordEncripter = PasswordEncripterBuilder.Build();
        var jwtTokenGenerator = JwtTokenGeneratorBuilder.Build();

        return new RegisterUserUseCase(mapper, userWriteOnlyRepository, userReadOnlyRepository, passwordEncripter,
            jwtTokenGenerator, unitOfWork);
    }
}