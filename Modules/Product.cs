namespace Labb_1___LINQ.Modules;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public int CategoryId { get; set; }
    public int SupplierId { get; set; }

    // Navigation properties
    public Category Category { get; set; } = null!;
    public Supplier Supplier { get; set; } = null!;

    public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

}
