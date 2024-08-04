using Bogus;
using Contracts.Communication.Users.Requests;
using Contracts.Enums;

namespace CommonTestUtilities.Requests;

public abstract class RequestRegisterUserJsonBuilder
{
    public static RequestRegisterUserJson Build()
    {
        return new Faker<RequestRegisterUserJson>()
            .RuleFor(user => user.Username, faker => faker.Internet.UserNameUnicode())
            .RuleFor(user => user.Email, faker => faker.Internet.Email())
            .RuleFor(user => user.Password, faker => faker.Internet.Password(prefix: "!Aa12", length: 8))
            .RuleFor(user => user.UserRole, faker => faker.PickRandom<UserRole>());
    }
}