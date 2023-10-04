namespace Boilerplate.Application.Results;

public sealed class UserResult
{
    public Guid Id { get; }
    public string Name { get; }

    public UserResult(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}
