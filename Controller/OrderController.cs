
using Labb_1___LINQ.Modules;

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
}
