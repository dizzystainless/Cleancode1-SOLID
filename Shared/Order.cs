namespace Shared;

public class Order
{
    public int Id { get; set; }
    public List<Product> Products { get; set; }
    public Customer Customer { get; set; }
    public DateTime ShippingDate { get; set; }
}