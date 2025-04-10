
using System.Linq;
using Labb_1___LINQ.Modules;
using Microsoft.EntityFrameworkCore;

namespace Labb_1___LINQ.Controller;

public class OrderController
{
    public static void GetTotalOrderValue()
    {
        using var context = new ShopContext();

        var currentDate = DateTime.Now.AddMonths(-1);

        var ordersCounts = context.Orders
            .Where(order => order.OrderDate >= currentDate)
            .Sum(order => order.TotalAmount);

        Console.WriteLine($"Sum: {ordersCounts}");

        Console.ReadKey();
    }

    public static void GetTopProduct(int count = 3)
    {
        using var context = new ShopContext();

        var produkts = context.OrderDetails
                .GroupBy(p => new { p.ProductId, p.Product.Name, p.Product.Price })
                .Select(g => new
                {
                    g.Key.Name,
                    g.Key.Price,
                    ProductCount = g.Count()
                })
                .OrderByDescending(r => r.ProductCount)
                .Take(count);


        foreach (var produkt in produkts)
        {
            Console.WriteLine($"Name: {produkt.Name} Quantity: {produkt.ProductCount} Pris: {produkt.Price}");
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
