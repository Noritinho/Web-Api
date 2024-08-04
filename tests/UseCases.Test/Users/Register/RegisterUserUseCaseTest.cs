using Application.UseCases.Users.Register;
using CommonTestUtilities.Cryptography;
using CommonTestUtilities.Mapper;
using CommonTestUtilities.Repositories;
using CommonTestUtilities.Requests;
using CommonTestUtilities.Token;
using Contracts.Enums;
using Exceptions.ExceptionsBase;
using Exceptions.Resources;
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

    [Fact]
    public async Task Error_Username_Empty()
    {
        var request = RequestRegisterUserJsonBuilder.Build();
        request.Username = string.Empty;
        
        var useCase = CreateUseCase();
        var act = async () => await useCase.Execute(request);
        var result = await act.Should().ThrowAsync<ErrorOnValidationException>();

        result.Where(
            exception =>  exception.GetErrors().Contains(UsersResourceErrorMessages.USERNAME_EMPTY));
    }
    
    [Fact]
    public async Task Error_Email_Empty()
    {
        var request = RequestRegisterUserJsonBuilder.Build();
        request.Email = string.Empty;
        
        var useCase = CreateUseCase();
        var act = async () => await useCase.Execute(request);
        var result = await act.Should().ThrowAsync<ErrorOnValidationException>();

        result.Where(
            exception =>  exception.GetErrors().Contains(UsersResourceErrorMessages.EMAIL_EMPTY));
    }
    
    [Fact]
    public async Task Error_Password_Empty()
    {
        var request = RequestRegisterUserJsonBuilder.Build();
        request.Password = string.Empty;
        
        var useCase = CreateUseCase();
        var act = async () => await useCase.Execute(request);
        var result = await act.Should().ThrowAsync<ErrorOnValidationException>();

        result.Where(
            exception =>  exception.GetErrors().Contains(UsersResourceErrorMessages.PASSWORD_EMPTY));
    }
    
    [Fact]
    public async Task Error_Username_Invalid()
    {
        var request = RequestRegisterUserJsonBuilder.Build();
        request.Username = "marc elo";
        
        var useCase = CreateUseCase();
        var act = async () => await useCase.Execute(request);
        var result = await act.Should().ThrowAsync<ErrorOnValidationException>();

        result.Where(
            exception =>  exception.GetErrors().Contains(UsersResourceErrorMessages.USERNAME_INVALID));
    }
    
    [Fact]
    public async Task Error_Email_Invalid()
    {
        var request = RequestRegisterUserJsonBuilder.Build();
        request.Email = "marcelo.com.br";
        
        var useCase = CreateUseCase();
        var act = async () => await useCase.Execute(request);
        var result = await act.Should().ThrowAsync<ErrorOnValidationException>();

        result.Where(
            exception =>  exception.GetErrors().Contains(UsersResourceErrorMessages.EMAIL_INVALID));
    }
    
    [Theory]
    [InlineData("jsdfghkjsdfhg384725837*&!¨!")]     // no Upper Case
    [InlineData("SJDHGKDSFHG384725837*&!¨!")]       // no Lower Case
    [InlineData("SJDHGKDsdufhksdhufSFHG*&!¨!")]     // no Number
    [InlineData("SJDHGKDsdufhksdhufSFHG39845745")]  // no Special Character
    public async void Error_Password_Invalid(string password)
    {
        var request = RequestRegisterUserJsonBuilder.Build();
        request.Password = password;
        
        var useCase = CreateUseCase();
        var act = async () => await useCase.Execute(request);
        var result = await act.Should().ThrowAsync<ErrorOnValidationException>();
        
        result.Where(
            exception =>  exception.GetErrors().Contains(UsersResourceErrorMessages.PASSWORD_INVALID));
    }
    
    [Fact]
    public async Task Error_User_Role_Invalid()
    {
        var request = RequestRegisterUserJsonBuilder.Build();
        request.UserRole = (UserRole)3;
        
        var useCase = CreateUseCase();
        var act = async () => await useCase.Execute(request);
        var result = await act.Should().ThrowAsync<ErrorOnValidationException>();

        result.Where(
            exception =>  exception.GetErrors().Contains(UsersResourceErrorMessages.USER_ROLE_INVALID));
    }
    
    [Fact]
    public async Task Error_Username_Invalid_Lenght()
    {
        var request = RequestRegisterUserJsonBuilder.Build();
        request.Username = "ma";
        
        var useCase = CreateUseCase();
        var act = async () => await useCase.Execute(request);
        var result = await act.Should().ThrowAsync<ErrorOnValidationException>();

        result.Where(
            exception =>  exception.GetErrors().Contains(UsersResourceErrorMessages.USERNAME_LENGHT));
    }
    
    [Fact]
    public async Task Error_Username_Password_Lenght()
    {
        var request = RequestRegisterUserJsonBuilder.Build();
        request.Password = "Aa!12";
        
        var useCase = CreateUseCase();
        var act = async () => await useCase.Execute(request);
        var result = await act.Should().ThrowAsync<ErrorOnValidationException>();

        result.Where(
            exception =>  exception.GetErrors().Contains(UsersResourceErrorMessages.PASSWORD_LENGHT));
    }
    
    [Fact]
    public async Task Error_Username_Already_Exist()
    {
        var request = RequestRegisterUserJsonBuilder.Build();
        var useCase = CreateUseCase(null, request.Username);
        var act = async () => await useCase.Execute(request);
        var result = await act.Should().ThrowAsync<ErrorOnValidationException>();

        result.Where(exception => exception.GetErrors().Contains(UsersResourceErrorMessages.USERNAME_ALREADY_EXISTS));
    }
    
    [Fact]
    public async Task Error_Email_Already_Exist()
    {
        var request = RequestRegisterUserJsonBuilder.Build();
        var useCase = CreateUseCase(request.Email, null);
        var act = async () => await useCase.Execute(request);
        var result = await act.Should().ThrowAsync<ErrorOnValidationException>();

        result.Where(exception => exception.GetErrors().Contains(UsersResourceErrorMessages.EMAIL_ALREADY_EXISTS));
    }
    

    private RegisterUserUseCase CreateUseCase(string? email = null, string? username = null)
    {
        var mapper = MapperBuilder.Build();
        var unitOfWork = UnitOfWorkBuilder.Build();
        var userWriteOnlyRepository = UserWriteOnlyRepositoryBuilder.Build();
        var userReadOnlyRepository = new UserReadOnlyRepositoryBuilder();
        var passwordEncripter = PasswordEncripterBuilder.Build();
        var jwtTokenGenerator = JwtTokenGeneratorBuilder.Build();

        if (string.IsNullOrWhiteSpace((email)) == false)
        {
            userReadOnlyRepository.ExistActiveUserWithEmail(email);
        }
        
        if (string.IsNullOrWhiteSpace((username)) == false)
        {
            userReadOnlyRepository.ExistActiveUserWithUsername(username);
        }
        
        return new RegisterUserUseCase(mapper, userWriteOnlyRepository, userReadOnlyRepository.Build(), passwordEncripter,
            jwtTokenGenerator, unitOfWork);
    }
}