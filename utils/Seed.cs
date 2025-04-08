using System.Text.RegularExpressions;
using System.Text.RegularExpressions;
using Labb_1___LINQ.Modules;
using Microsoft.EntityFrameworkCore;

namespace Labb_1___LINQ.utils;

public class Seed
{
    private string _path = "/workspaces/LabbOneLINQ/seed.csv";
    public static void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Electronics", Description = "Elektronik och tekniska produkter" },
            new Category { Id = 2, Name = "Home & Kitchen", Description = "Produkter för hemmet och köket" },
            new Category { Id = 3, Name = "Clothing", Description = "Kläder och accessoarer" },
            new Category { Id = 4, Name = "Sports", Description = "Sportutrustning och träningsprodukter" },
            new Category { Id = 5, Name = "Books", Description = "Böcker och litteratur" }
        );

        modelBuilder.Entity<Supplier>().HasData(
             new Supplier { Id = 1, Name = "TechVision AB", ContactPerson = "Anna Lindberg", Email = "anna@techvision.se", Phone = "070-123-4567" },
            new Supplier { Id = 2, Name = "HomeStyle", ContactPerson = "Johan Bergman", Email = "johan@homestyle.se", Phone = "073-234-5678" },
            new Supplier { Id = 3, Name = "Fashion First", ContactPerson = "Maria Ek", Email = "maria@fashionfirst.se", Phone = "076-345-6789" },
            new Supplier { Id = 4, Name = "SportMax", ContactPerson = "Erik Strand", Email = "erik@sportmax.se", Phone = "072-456-7890" },
            new Supplier { Id = 5, Name = "Nordic Electronics", ContactPerson = "Karl Holm", Email = "karl@nordicelec.se", Phone = "070-567-8901" },
            new Supplier { Id = 6, Name = "Global Gadgets", ContactPerson = "Lisa Björk", Email = "lisa@globalgadgets.se", Phone = "073-678-9012" }
        );

        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "iPhone 13 Pro", Description = "Smartphone med 128GB lagring", Price = 11999, StockQuantity = 15, CategoryId = 1, SupplierId = 1 },
            new Product { Id = 2, Name = "Samsung TV 55", Description = "4K Smart TV med HDR", Price = 8999, StockQuantity = 8, CategoryId = 1, SupplierId = 5 },
            new Product { Id = 3, Name = "Sony WH-1000XM4", Description = "Trådlösa hörlurar med brusreducering", Price = 3499, StockQuantity = 7, CategoryId = 1, SupplierId = 5 },
            new Product { Id = 4, Name = "MacBook Air", Description = "Laptop med M1-chip och 8GB RAM", Price = 12499, StockQuantity = 12, CategoryId = 1, SupplierId = 1 },
            new Product { Id = 5, Name = "Espressomaskin", Description = "Automatisk espressomaskin", Price = 4995, StockQuantity = 6, CategoryId = 2, SupplierId = 2 },
            new Product { Id = 6, Name = "Matberedare", Description = "Multifunktionell köksmaskin", Price = 1299, StockQuantity = 20, CategoryId = 2, SupplierId = 2 },
            new Product { Id = 7, Name = "Vinterjacka", Description = "Varm jacka för vinterbruk", Price = 1999, StockQuantity = 25, CategoryId = 3, SupplierId = 3 },
            new Product { Id = 8, Name = "Löparskor", Description = "Skor för långdistanslöpning", Price = 1499, StockQuantity = 18, CategoryId = 4, SupplierId = 4 },
            new Product { Id = 9, Name = "Yogamatta", Description = "Halkfri yogamatta", Price = 349, StockQuantity = 30, CategoryId = 4, SupplierId = 4 },
            new Product { Id = 10, Name = "Bestsellerroman", Description = "Populär skönlitterär roman", Price = 249, StockQuantity = 40, CategoryId = 5, SupplierId = 2 },
            new Product { Id = 11, Name = "Gaming PC", Description = "Högpresterande dator för gaming", Price = 18999, StockQuantity = 5, CategoryId = 1, SupplierId = 6 },
            new Product { Id = 12, Name = "Tablet", Description = "10\" surfplatta med WiFi", Price = 4299, StockQuantity = 9, CategoryId = 1, SupplierId = 5 },
            new Product { Id = 13, Name = "Bluetooth-högtalare", Description = "Portabel högtalare med 20h batteritid", Price = 899, StockQuantity = 22, CategoryId = 1, SupplierId = 6 },
            new Product { Id = 14, Name = "Kaffebryggare", Description = "Programmerbar kaffebryggare", Price = 799, StockQuantity = 14, CategoryId = 2, SupplierId = 2 },
            new Product { Id = 15, Name = "Träningströja", Description = "Funktionströja för träning", Price = 499, StockQuantity = 35, CategoryId = 3, SupplierId = 3 }
        );

        modelBuilder.Entity<Customer>().HasData(
            new Customer { Id = 1, Name = "Anders Svensson", Email = "anders@example.com", Phone = "070-111-2233", Address = "Storgatan 1, Stockholm" },
            new Customer { Id = 2, Name = "Emma Johansson", Email = "emma@example.com", Phone = "073-222-3344", Address = "Kungsgatan 15, Göteborg" },
            new Customer { Id = 3, Name = "Lars Nilsson", Email = "lars@example.com", Phone = "076-333-4455", Address = "Drottninggatan 8, Malmö" },
            new Customer { Id = 4, Name = "Sofia Lindgren", Email = "sofia@example.com", Phone = "072-444-5566", Address = "Sveavägen 22, Uppsala" },
            new Customer { Id = 5, Name = "Peter Karlsson", Email = "peter@example.com", Phone = "070-555-6677", Address = "Järntorget 5, Göteborg" }
        );

        modelBuilder.Entity<Order>().HasData(
            new Order { Id = 1, OrderDate = new DateTime(2025, 3, 1), CustomerId = 1, TotalAmount = 11999, Status = OrderStatus.Levererad },
            new Order { Id = 2, OrderDate = new DateTime(2025, 3, 5), CustomerId = 2, TotalAmount = 9798, Status = OrderStatus.Levererad },
            new Order { Id = 3, OrderDate = new DateTime(2025, 3, 10), CustomerId = 3, TotalAmount = 18999, Status = OrderStatus.Behandlas },
            new Order { Id = 4, OrderDate = new DateTime(2025, 3, 12), CustomerId = 4, TotalAmount = 3499, Status = OrderStatus.Levererad },
            new Order { Id = 5, OrderDate = new DateTime(2025, 3, 15), CustomerId = 5, TotalAmount = 16994, Status = OrderStatus.Skickad },
            new Order { Id = 6, OrderDate = new DateTime(2025, 2, 20), CustomerId = 1, TotalAmount = 899, Status = OrderStatus.Levererad },
            new Order { Id = 7, OrderDate = new DateTime(2025, 2, 25), CustomerId = 3, TotalAmount = 2498, Status = OrderStatus.Levererad },
            new Order { Id = 8, OrderDate = new DateTime(2025, 3, 18), CustomerId = 2, TotalAmount = 1598, Status = OrderStatus.Skickad },
            new Order { Id = 9, OrderDate = new DateTime(2025, 3, 20), CustomerId = 4, TotalAmount = 5794, Status = OrderStatus.Behandlas },
            new Order { Id = 10, OrderDate = new DateTime(2025, 3, 22), CustomerId = 5, TotalAmount = 1299, Status = OrderStatus.Behandlas }
        );

        modelBuilder.Entity<OrderDetail>().HasData(
            new OrderDetail { Id = 1, OrderId = 1, ProductId = 1, Quantity = 1, UnitPrice = 11999 },
            new OrderDetail { Id = 2, OrderId = 2, ProductId = 3, Quantity = 2, UnitPrice = 3499 },
            new OrderDetail { Id = 3, OrderId = 2, ProductId = 13, Quantity = 3, UnitPrice = 899 },
            new OrderDetail { Id = 4, OrderId = 3, ProductId = 11, Quantity = 1, UnitPrice = 18999 },
            new OrderDetail { Id = 5, OrderId = 4, ProductId = 3, Quantity = 1, UnitPrice = 3499 },
            new OrderDetail { Id = 6, OrderId = 5, ProductId = 4, Quantity = 1, UnitPrice = 12499 },
            new OrderDetail { Id = 7, OrderId = 5, ProductId = 5, Quantity = 1, UnitPrice = 4495 },
            new OrderDetail { Id = 8, OrderId = 6, ProductId = 13, Quantity = 1, UnitPrice = 899 },
            new OrderDetail { Id = 9, OrderId = 7, ProductId = 8, Quantity = 1, UnitPrice = 1499 },
            new OrderDetail { Id = 10, OrderId = 7, ProductId = 9, Quantity = 3, UnitPrice = 349 },
            new OrderDetail { Id = 11, OrderId = 8, ProductId = 7, Quantity = 1, UnitPrice = 1999 },
            new OrderDetail { Id = 12, OrderId = 8, ProductId = 15, Quantity = 3, UnitPrice = 499 },
            new OrderDetail { Id = 13, OrderId = 9, ProductId = 2, Quantity = 1, UnitPrice = 8999 },
            new OrderDetail { Id = 14, OrderId = 9, ProductId = 6, Quantity = 1, UnitPrice = 1299 },
            new OrderDetail { Id = 15, OrderId = 9, ProductId = 14, Quantity = 2, UnitPrice = 799 },
            new OrderDetail { Id = 16, OrderId = 10, ProductId = 6, Quantity = 1, UnitPrice = 1299 }
        );
    }

    public void SeedDataV2()
    {
        var csv = File.ReadAllLines(_path);
        string modelName;

        if (csv is null)
        {
            return;
        }

        Regex regExCell = new Regex(@"(?<=\|)([^|]*)(?=\|)");
        Regex regExHedderDivider = new Regex(@"^[\|-]+$");

        var formatCSV = csv.Where((csv) => csv != "");

        foreach (var row in formatCSV)
        {
            var cellMatches = regExCell.Matches(row);
            // Check if row is equeal to a hedder
            if (row.Contains("##"))
            {
                modelName = row.Split("##", StringSplitOptions.TrimEntries)[1];
            }

            // Check if row look like a (|----|------|-------------|)
            if (regExHedderDivider.IsMatch(row))
            {
                continue;
            }

            if (cellMatches.Count == 0)
            {
                continue;
            }


            foreach (var cell in cellMatches)
            {
                Console.WriteLine(cell);
            }
        }
    }

    public void SeedDataV2()
    {
        using StreamReader reader = new StreamReader(_path);
        string? line;

        while ((line = reader.ReadLine()) != null)
        {
            Regex CSVParcer = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");

            string[] x = CSVParcer.Split(line);
        }
    }
    public void SeedDataV3()
    {
        try
        {
            // Läs hela innehållet från CSV-filen
            string csvData = File.ReadAllText(_path);

            // Dela upp CSV-datan i rader
            string[] rows = csvData.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            if (rows.Length <= 2) // Kontrollera att det finns minst en datarad efter heder och separator
            {
                Console.WriteLine("Ingen data hittades efter hederraden i filen.");
                return;
            }

            // Hoppa över de två första raderna (heder och separator)
            foreach (string row in rows.Skip(2))
            {
                // Regex för att matcha celler i en rad
                string pattern = @"[^|]*[a-zA-Z0-9åäöÅÄÖ]+[^|]*"; // Matchar text mellan två | (kan vara tomt)
                var matches = Regex.Matches(row, pattern);

            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Filen hittades inte på sökvägen: {_path}");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Ett fel uppstod vid läsning av filen: {ex.Message}");
        }
    }
}
