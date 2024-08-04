using Application.UseCases.Users.Register;
using CommonTestUtilities.Requests;
using Contracts.Enums;
using Exceptions.Resources;
using FluentAssertions;
using Xunit;

namespace ValidatorsTest.Users.Register;

public class RegisterUserValidatorTest
{
    [Fact]
    public void Success()
    {
        var validator = new RegisterUserValidator();
        var request = RequestRegisterUserJsonBuilder.Build();
        
        var result = validator.Validate(request);
        
        result.IsValid.Should().BeTrue();
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Error_Username_Empty(string username)
    {
        var validator = new RegisterUserValidator();
        var request = RequestRegisterUserJsonBuilder.Build();
        request.Username = username;
        
        var result = validator.Validate(request);
        
        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.ErrorMessage.Equals(UsersResourceErrorMessages.USERNAME_EMPTY));
    }
    
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Error_Email_Empty(string email)
    {
        var validator = new RegisterUserValidator();
        var request = RequestRegisterUserJsonBuilder.Build();
        request.Email = email;
        
        var result = validator.Validate(request);
        
        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.ErrorMessage.Equals(UsersResourceErrorMessages.EMAIL_EMPTY));
    }
    
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Error_Password_Empty(string password)
    {
        var validator = new RegisterUserValidator();
        var request = RequestRegisterUserJsonBuilder.Build();
        request.Password = password;
        
        var result = validator.Validate(request);
        
        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.ErrorMessage.Equals(UsersResourceErrorMessages.PASSWORD_EMPTY));
    }
    
    [Fact]
    public void Error_Username_Invalid()
    {
        var validator = new RegisterUserValidator();
        var request = RequestRegisterUserJsonBuilder.Build();
        request.Username = "marc elo";
        
        var result = validator.Validate(request);
        
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(UsersResourceErrorMessages.USERNAME_INVALID));
    }
    
    [Fact]
    public void Error_Email_Invalid()
    {
        var validator = new RegisterUserValidator();
        var request = RequestRegisterUserJsonBuilder.Build();
        request.Email = "marcelo.com.br";
        
        var result = validator.Validate(request);
        
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(UsersResourceErrorMessages.EMAIL_INVALID));
    }
    
    [Theory]
    [InlineData("jsdfghkjsdfhg384725837*&!¨!")]     // no Upper Case
    [InlineData("SJDHGKDSFHG384725837*&!¨!")]       // no Lower Case
    [InlineData("SJDHGKDsdufhksdhufSFHG*&!¨!")]     // no Number
    [InlineData("SJDHGKDsdufhksdhufSFHG39845745")]  // no Special Character
    public void Error_Password_Invalid(string password)
    {
        var validator = new RegisterUserValidator();
        var request = RequestRegisterUserJsonBuilder.Build();
        request.Password = password;
        
        var result = validator.Validate(request);
        
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(UsersResourceErrorMessages.PASSWORD_INVALID));
    }
    
    [Fact]
    public void Error_User_Role_Invalid()
    {
        var validator = new RegisterUserValidator();
        var request = RequestRegisterUserJsonBuilder.Build();
        request.UserRole = (UserRole)5;
        
        var result = validator.Validate(request);
        
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(UsersResourceErrorMessages.USER_ROLE_INVALID));
    }
    
    [Fact]
    public void Error_Username_Invalid_Lenght()
    {
        var validator = new RegisterUserValidator();
        var request = RequestRegisterUserJsonBuilder.Build();
        request.Username = "ma";
        
        var result = validator.Validate(request);
        
        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.ErrorMessage.Equals(UsersResourceErrorMessages.USERNAME_LENGHT));
    }
    
    [Fact]
    public void Error_Password_Lenght()
    {
        var validator = new RegisterUserValidator();
        var request = RequestRegisterUserJsonBuilder.Build();
        request.Password = "Aa!12";
        
        var result = validator.Validate(request);
        
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(UsersResourceErrorMessages.PASSWORD_LENGHT));
    }
}