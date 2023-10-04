namespace Boilerplate.Application;

public sealed class UserNotFoundException : ApplicationException
{
    public UserNotFoundException(string message)
        : base(message)
    { }
}
