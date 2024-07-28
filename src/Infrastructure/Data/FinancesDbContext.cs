using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class FinancesDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
}