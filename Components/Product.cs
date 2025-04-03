using Labb_1___LINQ.Modules;
using Microsoft.EntityFrameworkCore;

namespace Labb_1___LINQ.Components;

public class Product
{
    public static void Index(string Category)
    {
        using var context = new ShopContext();

        var produkts = context.Products
            .Include(produkt => produkt.Category)
            .Where(produkt => produkt.Category.Name == Category)
            .OrderBy(produkt => produkt.Price);

        foreach (var produkt in produkts)
        {
            Console.WriteLine($"Name: {produkt.Name}");
        }

        Console.ReadKey();
    }
}
