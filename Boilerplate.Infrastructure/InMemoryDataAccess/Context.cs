using Boilerplate.Domain.Users;
using System.Collections.ObjectModel;

namespace Boilerplate.Infrastructure.InMemoryDataAccess;

public class Context
{
    public Collection<User> Users { get; set; }

    public Context()
    {
        Users = new Collection<User>();
    }
}
