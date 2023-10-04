namespace Boilerplate.Application.Commands.DeleteUser;

public interface IDeleteUser
{
    Task<Guid> Execute(Guid userId);
}
