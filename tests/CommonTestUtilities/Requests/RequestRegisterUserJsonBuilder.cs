using Bogus;
using Contracts.Communication.Users.Requests;

namespace CommonTestUtilities.Requests;

public class RequestRegisterUserJsonBuilder
{
    public static RequestRegisterUserJson Build()
    {
        return new Faker<RequestRegisterUserJson>()
            .RuleFor(user => user.Username, faker => faker.Internet.UserNameUnicode())
            .RuleFor(user => user.Email, faker => faker.Internet.Email())
            .RuleFor(user => user.Password, faker => faker.Internet.Password(prefix:"!Aa1"))
            .RuleFor(user => user.UserRole, faker => faker.PickRandom("admin", "user")).Generate();
    }
}