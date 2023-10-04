using Microsoft.EntityFrameworkCore;

namespace Boilerplate.Infrastructure.EntityFrameworkDataAccess;

public class Context : DbContext
{
    public DbSet<Entities.User> Users { get; set; }

    public Context(DbContextOptions<Context> dbContextOptions) : base(dbContextOptions)
    {

    }
}
