public class OrderDetails
{
    public int OrderId { get; set; } // Foreign key to Order
    public int ProductId { get; set; } // Foreign key to Product
    public Order Order { get; set; } // Navigation property
    public Product Product { get; set; } // Navigation property
}
