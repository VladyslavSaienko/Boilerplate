using Boilerplate.Application.Queries;
using Boilerplate.Application.Results;
using Boilerplate.Domain.Users;
using Boilerplate.Infrastructure.EntityFrameworkDataAccess;
using System.Collections.ObjectModel;


namespace Boilerplate.Infrastructure.InMemoryDataAccess.Queries;

public class UsersQueries : IUsersQueries
{
    private readonly Context _context;
    public UsersQueries(Context context)
    {
        _context = context;

        foreach (var user in FillUsers())
        {
            _context.Users.Add(user);
        }
    }
    public async Task<UserResult> GetUser(Guid userId)
    {
        User user = _context.Users.SingleOrDefault(u => u.Id == userId);

        if (user == null)
            throw new InvalidDataException();

        UserResult userResult = new UserResult(user.Id, user.Name);

        return await Task.FromResult<UserResult>(userResult);
    }

    public async Task<Collection<UserResult>> GetAllUsers()
    {
        Collection<User> users = _context.Users;

        if (users == null)
            throw new InvalidDataException();

        Collection<UserResult> userResults = new Collection<UserResult>();

        foreach (User user in users)
        {
            userResults.Add(new UserResult(user.Id, user.Name));
        }

        return await Task.FromResult<Collection<UserResult>>(userResults);
    }

    private List<User> FillUsers()
    {
        List<User> users = new List<User>();

        users.Add(new User(Guid.NewGuid(), "Ariel"));
        users.Add(new User(Guid.NewGuid(), "Adam"));
        users.Add(new User(Guid.NewGuid(), "Marian"));

        return users;
    }
}
