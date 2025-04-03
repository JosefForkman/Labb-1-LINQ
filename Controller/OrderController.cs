
using Labb_1___LINQ.Modules;
using Microsoft.EntityFrameworkCore;

namespace Labb_1___LINQ.Controller;

public class OrderController
{
    public static void GetTotalOrderValue()
    {
        using var context = new ShopContext();

        var currentDate = DateTime.Now;

        var orders = context.Orders
            .Where(order => order.OrderDate.Year >= currentDate.Year && order.OrderDate.Month >= currentDate.Month)
            .ToList()
            .Sum(order => order.TotalAmount);

        Console.WriteLine($"Sum: {orders}");

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
}
