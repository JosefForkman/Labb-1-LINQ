namespace Labb_1___LINQ.Modules;

public class Order
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public int CustomerId { get; set; }
    public int TotalAmount { get; set; }
    public OrderStatus Status { get; set; } = OrderStatus.Behandlas;

    // Navigation properties
    public Customer Customer { get; set; } = null!;

    public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

}

public enum OrderStatus
{
    Levererad,
    Behandlas,
    Skickad,
}
