using Boilerplate.Application.Queries;
using Boilerplate.Application.Results;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace Boilerplate.Infrastructure.EntityFrameworkDataAccess.Queries;

public class UsersQueries : IUsersQueries
{
    private readonly Context _context;

    public UsersQueries(Context context)
    {
        _context = context;

        _context.SaveChanges();
    }

    public async Task<Collection<UserResult>> GetAllUsers()
    {
        List<Entities.User> users = await _context.Users.ToListAsync();

        if (users == null)
            throw new InvalidDataException();

        Collection<UserResult> userResults = new Collection<UserResult>();

        foreach (Entities.User user in users)
        {
            userResults.Add(new UserResult(user.Id, user.Name));
        }

        return await Task.FromResult<Collection<UserResult>>(userResults);
    }

    public async Task<UserResult> GetUser(Guid userId)
    {
        Entities.User user = await _context
            .Users
            .FindAsync(userId);

        UserResult userResult = new UserResult(user.Id, user.Name);

        return await Task.FromResult<UserResult>(userResult);
    }
}
