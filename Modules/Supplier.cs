using System.ComponentModel.DataAnnotations;

namespace Labb_1___LINQ.Modules;

public class Supplier
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ContactPerson { get; set; } = string.Empty;
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    [Phone]
    public string Phone { get; set; } = string.Empty;

    // Navigation property
    public ICollection<Product> Products { get; set; } = new List<Product>();
}
