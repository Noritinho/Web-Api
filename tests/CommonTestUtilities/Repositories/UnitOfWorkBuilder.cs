using Domain.Repositories;
using Moq;

namespace CommonTestUtilities.Repositories;

public abstract class UnitOfWorkBuilder
{
    public static IUnitOfWork Build()
    {
        var mock = new Mock<IUnitOfWork>();
        return mock.Object;
    }
}