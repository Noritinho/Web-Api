using Domain.Repositories.User;
using Moq;

namespace CommonTestUtilities.Repositories;

public abstract class UserReadOnlyRepositoryBuilder
{
    private static readonly Mock<IUserReadOnlyRepository> Repository = new();

    public static IUserReadOnlyRepository Build()
    {
        return Repository.Object;
    }
}