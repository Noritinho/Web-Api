using Bogus;
using CommonTestUtilities.Cryptography;
using Domain.Entities;
using Domain.Enums;

namespace CommonTestUtilities.Entities;

public class UserBuilder
{
    public static User Build()
    {
        var passwordEncrypter = new PasswordEncrypterBuilder().Build();
        var user = new Faker<User>()
            .RuleFor(user => user.Email, faker => faker.Internet.Email())
            .RuleFor(user => user.Username, faker => faker.Internet.UserNameUnicode())
            .RuleFor(user => user.Password, (_, user) => passwordEncrypter.Encrypt(user.Password))
            .RuleFor(user => user.UserRole, faker => faker.PickRandom<UserRole>());
        
        return user;
    }
}