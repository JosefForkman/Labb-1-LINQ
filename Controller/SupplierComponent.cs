using Labb_1___LINQ.Modules;
using Microsoft.EntityFrameworkCore;

namespace Labb_1___LINQ.Controller;

public class SupplierComponent
{
    public static void Index()
    {
        using var context = new ShopContext();

        var suppliers = context.Products
            .Include(product => product.Supplier)
            .Where(product => product.StockQuantity < 10)
            .Select(product => product.Supplier)
            .Distinct();


        foreach (var supplier in suppliers)
        {
            Console.WriteLine($"Name: {supplier.Name}");
        }

        Console.ReadKey();
    }
}
