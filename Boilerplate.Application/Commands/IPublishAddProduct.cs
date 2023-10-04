using Boilerplate.Domain.Products;

namespace Boilerplate.Application.Commands;

public interface IPublishAddProduct
{
    Task<bool> Publish(Product product);
}
