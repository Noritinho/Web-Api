using Domain.Entities;
using Domain.Repositories.User;

namespace Infrastructure.Data.Repositories;

public class UserRepository(FinancesDbContext dbContext) : IUserWriteOnlyRepository
{
    public async Task Add(User user)
    {
        await dbContext.Users.AddAsync(user);
    }
}