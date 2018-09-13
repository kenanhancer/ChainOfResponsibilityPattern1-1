using System;
using System.Linq;
using System.Collections.Generic;

public class OrderService : IOrderService
{
    public Order GetOrderById(int Id)
    {
        Console.WriteLine($"OrderService: {nameof(GetOrderById)} method worked.");

        return new Order();
    }

    public IList<Order> GetOrders()
    {
        Console.WriteLine($"OrderService: {nameof(GetOrders)} method worked.");

        return Enumerable.Empty<Order>().ToList();
    }

    public void Save(Order order)
    {
        Console.WriteLine($"OrderService: {nameof(Save)} method worked.");
    }
}