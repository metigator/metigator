namespace SolidDistilled.Models;

public class CartItem
{
    public int BookId { get; set; }
    public Book Book { get; set; } = null!; // Navigation property
    public int Quantity { get; set; }

    public decimal Total => Book.Price * Quantity;
}