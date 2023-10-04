namespace Boilerplate.Domain.Users.Repositories;

public interface IUsersReadOnlyRepository
{
    Task<User> Get(Guid id);
}
