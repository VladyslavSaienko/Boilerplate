using Boilerplate.Domain.Users;
using Boilerplate.Domain.Users.Repositories;
using Boilerplate.Infrastructure.EntityFrameworkDataAccess;

namespace Boilerplate.Infrastructure.InMemoryDataAccess.Repositories;

public class UserRepository : IUsersReadOnlyRepository
{
    private readonly Context _context;

    public UserRepository(Context context)
    {
        _context = context;
    }
    public async Task<User> Get(Guid id)
    {
        User user = _context.Users.SingleOrDefault(e => e.Id == id);

        return await Task.FromResult<User>(user);
    }
}
