using System;

namespace ChainOfResponsibilityPattern1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            IOrderService orderService = new OrderService();

            IOrderService orderServiceProxy = new OrderServiceProxy(orderService);

            Order order = orderServiceProxy.GetOrderById(3);

            if (order != null)
            {
                Console.WriteLine($"Order is found.");
            }
        }
    }
}