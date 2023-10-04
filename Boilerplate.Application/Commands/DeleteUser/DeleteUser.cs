using Boilerplate.Domain.Users.Repositories;
using Boilerplate.Domain.Users;

namespace Boilerplate.Application.Commands.DeleteUser;

public sealed class DeleteUser : IDeleteUser
{
    private readonly IUsersReadOnlyRepository _usersReadOnlyRepository;
    private readonly IUsersWriteOnlyRepository _usersWriteOnlyRepository;

    public DeleteUser(IUsersReadOnlyRepository usersReadOnlyRepository, IUsersWriteOnlyRepository usersWriteOnlyRepository)
    {
        _usersReadOnlyRepository = usersReadOnlyRepository;
        _usersWriteOnlyRepository = usersWriteOnlyRepository;
    }

    public async Task<Guid> Execute(Guid userId)
    {
        User user = await _usersReadOnlyRepository.Get(userId);
        if (user == null)
            throw new UserNotFoundException($"The user {userId} does not exists");

        await _usersWriteOnlyRepository.Delete(user);

        return user.Id;
    }
}
