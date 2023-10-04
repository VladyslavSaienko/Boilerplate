namespace Boilerplate.Domain.Users.Repositories;

public interface IUsersWriteOnlyRepository
{
    Task Add(User user);

    Task Update(User user);

    Task Delete(User user);
}
