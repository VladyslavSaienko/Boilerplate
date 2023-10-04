namespace Boilerplate.Domain.Orders;

public class Order
{
    public Order(int orderId)
    {
        OrderId = orderId;
    }

    public int OrderId { get; set; }
}
