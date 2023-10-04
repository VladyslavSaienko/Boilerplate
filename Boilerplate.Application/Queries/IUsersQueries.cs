using Boilerplate.Application.Results;
using System.Collections.ObjectModel;

namespace Boilerplate.Application.Queries;

public interface IUsersQueries
{
    Task<UserResult> GetUser(Guid userId);
    Task<Collection<UserResult>> GetAllUsers();
}
