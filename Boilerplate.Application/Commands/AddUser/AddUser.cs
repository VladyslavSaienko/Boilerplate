using Boilerplate.Domain.Users.Repositories;
using Boilerplate.Domain.Users;

namespace Boilerplate.Application.Commands.AddUser;

public sealed class AddUser : IAddUser
{
    private readonly IUsersReadOnlyRepository _usersReadOnlyRepository;
    private readonly IUsersWriteOnlyRepository _usersWriteOnlyRepository;

    public AddUser(IUsersReadOnlyRepository usersReadOnlyRepository, IUsersWriteOnlyRepository usersWriteOnlyRepository)
    {
        _usersReadOnlyRepository = usersReadOnlyRepository;
        _usersWriteOnlyRepository = usersWriteOnlyRepository;
    }

    public async Task<Guid> Execute(AddUserCommand addUserCommand)
    {
        User user = new(Guid.NewGuid(), addUserCommand.Name);

        await _usersWriteOnlyRepository.Add(user);

        return user.Id;
    }
}
