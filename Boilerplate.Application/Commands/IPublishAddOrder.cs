using Boilerplate.Domain.Orders;

namespace Boilerplate.Application.Commands;

public interface IPublishAddOrder
{
    Task<bool> Publish(Order product);
}
