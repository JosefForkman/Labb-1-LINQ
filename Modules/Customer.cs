using System.ComponentModel.DataAnnotations;

namespace Labb_1___LINQ.Modules;

public class Customer
{
    public int Id { get; set; }
    [EmailAddress]
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    [Phone]
    public string Phone { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;

    // Navigation property
    public ICollection<Order> Order { get; set; } = new List<Order>();
}
