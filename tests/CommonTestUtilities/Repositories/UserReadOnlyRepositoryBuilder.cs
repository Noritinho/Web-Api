using Domain.Repositories.User;
using Moq;

namespace CommonTestUtilities.Repositories;

public class UserReadOnlyRepositoryBuilder
{
    private readonly Mock<IUserReadOnlyRepository> _repository = new();

    public IUserReadOnlyRepository Build()
    {
        return _repository.Object;
    }
    
    public void ExistActiveUserWithEmail(string email)
    {
        _repository.Setup(userReadOnly => userReadOnly.ExistActiveUserWithEmail(email)).ReturnsAsync(true);
    }
    
    public void ExistActiveUserWithUsername(string username)
    {
        _repository.Setup(userReadOnly => userReadOnly.ExistActiveUserWithUsername(username)).ReturnsAsync(true);
    }
}