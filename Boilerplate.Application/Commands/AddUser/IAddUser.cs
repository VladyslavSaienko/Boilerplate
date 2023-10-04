namespace Boilerplate.Application.Commands.AddUser;

public interface IAddUser
{
    Task<Guid> Execute(AddUserCommand userName);

}
