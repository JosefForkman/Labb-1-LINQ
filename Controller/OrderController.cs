
using Labb_1___LINQ.Modules;
using Microsoft.EntityFrameworkCore;

namespace Labb_1___LINQ.Controller;

public class OrderController
{
    public static void GetTotalOrderValue()
    {
        using var context = new ShopContext();

        var currentDate = DateTime.Now;

        var ordersCounts = context.Orders
            .Where(order => (
                    order.OrderDate.Year >= currentDate.Year &&
                    order.OrderDate.Month >= currentDate.Month &&
                    order.Status == OrderStatus.Skickad
                ))
            .ToList()
            .Sum(order => order.TotalAmount);

        Console.WriteLine($"Sum: {ordersCounts}");

        Console.ReadKey();
    }

    public static void GetTopProduct(int count = 3)
    {
        using var context = new ShopContext();

        var produkts = context.OrderDetails
            .Include(order => order.Product)
            .Select(order => new { order.Product, sum = order.UnitPrice * order.Quantity })
            .OrderByDescending(order => order.sum)
            .Take(count);


        foreach (var produkt in produkts)
        {
            Console.WriteLine($"Name: {produkt.Product.Name} Pris: {produkt.Product.Price}");
        }

        Console.ReadKey();
    }
    public static void GatAllOrdersDitails()
    {
        using var context = new ShopContext();

        var orders = context.Orders
            .Include(order => order.Customer)
            .Include(order => order.OrderDetails)
                .ThenInclude(orderDetails => orderDetails.Product)
            .Where(order => order.TotalAmount >= 1000)
            .Select(order => new
            {
                order.Customer.Name,
                order.Customer.Email,
                OrderDetails = order.OrderDetails.Select(orderDitail => new { orderDitail.Quantity, orderDitail.UnitPrice, orderDitail.Product.Name }),
            });

        foreach (var order in orders)
        {
            Console.WriteLine($"Custumer name: {order.Name} with email {order.Email}");
            Console.WriteLine("==========================");

            foreach (var orderDitail in order.OrderDetails)
            {
                Console.WriteLine($"Produkt name: {orderDitail.Name} costing {orderDitail.Quantity}pcs X {orderDitail.UnitPrice}kr");
            }

            Console.WriteLine("\n\n");
        }
        Console.ReadKey();
    }
}
