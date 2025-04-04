
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
            .Where(order => order.TotalAmount >= 1000);

        foreach (var order in orders)
        {
            Console.WriteLine($"Custumer name: {order.Customer.Name} with email {order.Customer.Email}");
            Console.WriteLine("==========================");

            foreach (var orderDitail in order.OrderDetails)
            {
                Console.WriteLine($"Custumer name: {orderDitail} with email {order.Customer.Email}");
            }
        }
    }
}
