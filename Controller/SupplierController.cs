using Labb_1___LINQ.Modules;
using Microsoft.EntityFrameworkCore;

namespace Labb_1___LINQ.Controller;

public class SupplierController
{
    public static void Index()
    {
        using var context = new ShopContext();

        var suppliers = context.Products
            .Include(product => product.Supplier)
            .Where(product => product.StockQuantity < 10)
            .Select(product => new { product.Supplier.Name, product.StockQuantity })
            .Distinct();


        foreach (var supplier in suppliers)
        {
            Console.WriteLine($"Name: {supplier.Name} stock quantity: {supplier.StockQuantity}");
        }

        Console.ReadKey();
    }
}
