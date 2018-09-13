using System;
using System.Collections.Generic;

public interface IOrderService
{
    Order GetOrderById(int Id);
    IList<Order> GetOrders();
    void Save(Order order);
}