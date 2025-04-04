using Labb_1___LINQ.Modules;
using Microsoft.EntityFrameworkCore;

namespace Labb_1___LINQ.Controller;

public class CategoryController
{
    public static void GetCategory()
    {
        using var context = new ShopContext();

        var produkts = context.Categories
            .Include(categorie => categorie.Products)
            .Select(categorie => new { categorie.Name, categorie.Products.Count });

        foreach (var produkt in produkts)
        {
            Console.WriteLine($"{produkt.Name} har {produkt.Count}st prudukter");
        }
    }
}
