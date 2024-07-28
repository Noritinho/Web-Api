namespace Domain.Repositories.User;

public interface IUserReadOnlyRepository
{
    Task<List<Domain.Entities.User>> GetAllUsers();
    Task<Entities.User?> GetUserById(long id);
    Task<Entities.User?> GetUserByIdentifier(string identifier);
    Task<bool> ExistActiveUserWithUsername(string username);
    Task<bool> ExistActiveUserWithEmail(string email);
    Task<Entities.User?> GetUserByUsernameOrEmail(string usernameOrEmail);
}