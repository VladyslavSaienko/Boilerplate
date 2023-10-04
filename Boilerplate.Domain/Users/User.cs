namespace Boilerplate.Domain.Users;

public sealed class User : IEntity
{
    public Guid Id { get; private set; }
    public string Name { get; }

    public User(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}
