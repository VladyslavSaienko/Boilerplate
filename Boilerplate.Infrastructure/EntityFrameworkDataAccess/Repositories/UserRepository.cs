using Boilerplate.Application;
using Boilerplate.Domain.Users.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Boilerplate.Infrastructure.EntityFrameworkDataAccess.Repositories;

public class UserRepository : IUsersReadOnlyRepository, IUsersWriteOnlyRepository
{
    private readonly Context _context;

    public UserRepository(Context context)
    {
        _context = context;
    }

    public async Task Add(Domain.Users.User user)
    {
        Entities.User userEntity = new Entities.User()
        {
            Id = user.Id,
            Name = user.Name
        };

        await _context.Users.AddAsync(userEntity);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Domain.Users.User user)
    {
        Entities.User userEntity = new Entities.User()
        {
            Id = user.Id,
            Name = user.Name
        };

        _context.Users.Remove(userEntity);
        await _context.SaveChangesAsync();
    }

    public async Task<Domain.Users.User> Get(Guid id)
    {
        Entities.User user = _context.Users.AsNoTracking().SingleOrDefault(e => e.Id == id);

        if (user == null)
            throw new UserNotFoundException($"The user {id} does not exists");

        Domain.Users.User userDomain = new Domain.Users.User(user.Id, user.Name);

        return await Task.FromResult<Domain.Users.User>(userDomain);
    }

    public async Task Update(Domain.Users.User user)
    {
        Entities.User userEntity = new Entities.User()
        {
            Id = user.Id,
            Name = user.Name
        };

        _context.Users.Update(userEntity);
        await _context.SaveChangesAsync();
    }
}
