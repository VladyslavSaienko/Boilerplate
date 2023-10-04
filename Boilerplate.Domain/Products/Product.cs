namespace Boilerplate.Domain.Products;

public class Product : IEntity
{
    public Guid Id { get; private set; }
    public string Name { get; }

    public Product(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}
