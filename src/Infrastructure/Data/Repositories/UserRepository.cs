using Domain.Entities;
using Domain.Repositories.User;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories;

public class UserRepository(FinancesDbContext dbContext) : 
    IUserWriteOnlyRepository,
    IUserReadOnlyRepository
{
    public async Task Add(User user)
    {
        await dbContext.Users.AddAsync(user);
    }

    public void Update(User user)
    {
        dbContext.Users.Update(user);
    }


    public async Task<List<User>> GetAllUsers()
    {
        return await dbContext.Users.AsNoTracking().ToListAsync();
    }

    public async Task<User?> GetUserById(long id)
    {
        return await dbContext.Users.AsNoTracking().FirstOrDefaultAsync(user => user.Id.Equals(id));
    }

    public async Task<User?> GetUserByIdentifier(string token)
    {
        return await dbContext.Users.AsNoTracking().FirstOrDefaultAsync(user => user.UserIdentifier.Equals(token));
    }

    public async Task<bool> ExistActiveUserWithUsername(string username)
    {
        return await dbContext.Users.AnyAsync(user => user.Username.Equals(username));
    }


    public async Task<bool> ExistActiveUserWithEmail(string email)
    {
        return await dbContext.Users.AnyAsync(user => user.Email.Equals(email));
    }

    public async Task<User?> GetUserByUsernameOrEmail(string usernameOrEmail)
    {
        var isUsername = await dbContext.Users.AnyAsync(user => user.Username.Equals(usernameOrEmail));
        if (isUsername) return await dbContext.Users.FirstOrDefaultAsync(user => user.Username.Equals(usernameOrEmail));
        var isEmail = await dbContext.Users.AnyAsync(user => user.Email.Equals(usernameOrEmail));
        if (isEmail) return await dbContext.Users.FirstOrDefaultAsync(user => user.Email.Equals(usernameOrEmail));
        return null;
    }
}