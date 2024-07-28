using Domain.Repositories.User;

namespace Infrastructure.Data;

internal class UnitOfWork(FinancesDbContext dbContext) : IUnitOfWork
{
    public async Task Commit() => await dbContext.SaveChangesAsync();
}