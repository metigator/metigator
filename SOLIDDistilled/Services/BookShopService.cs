using SolidDistilled.Data;
using SolidDistilled.Enums;
using SolidDistilled.Models;

namespace SolidDistilled.Services;

public class BookShopService (BookRepository repository)
{ 
    private readonly List<CartItem> _cart = new();
    private OfferType _selectedOffer = OfferType.Fixed;
    private string? _promoCode;

    public IEnumerable<Book> GetBooks() => repository.ListAll();

    public IReadOnlyCollection<CartItem> GetCartItems() => _cart.AsReadOnly();

    public void AddToCart(Book book)
    {
        var existing = _cart.FirstOrDefault(x => x.BookId == book.Id);
        if (existing != null)
        {
            existing.Quantity++;
        }
        else
        {
            _cart.Add(new CartItem
            {
                BookId = book.Id,
                Book = book,
                Quantity = 1
            });
        }
    }

    public void RemoveFromCart(int bookId)
    {
        var item = _cart.FirstOrDefault(x => x.BookId == bookId);
        if (item != null)
            _cart.Remove(item);
    }

    public void IncreaseQuantity(CartItem item) => item.Quantity++;

    public void DecreaseQuantity(CartItem item)
    {
        if (item.Quantity > 1)
            item.Quantity--;
        else
            _cart.Remove(item);
    }

    public void SelectOffer(OfferType offer, string? promoCode = null)
    {
        _selectedOffer = offer;
        _promoCode = promoCode;
    }

    public decimal GetSubtotal() =>
        _cart.Sum(x => x.Book.Price * x.Quantity);

    public decimal GetDiscount()
    {
        var subtotal = GetSubtotal();

        return _selectedOffer switch
        {
            OfferType.Fixed => 5.00m,
            OfferType.Percentage => subtotal * 0.15m,
            OfferType.Bogo => ApplyBogoDiscount(),
            OfferType.FirstTime => subtotal * 0.2m,
            OfferType.Author => subtotal * 0.1m,
            OfferType.Promo when _promoCode == "SAVE20" => subtotal * 0.2m,
            _ => 0m
        };
    }

    public decimal GetTotal() => GetSubtotal() - GetDiscount();

    public string GetDiscountLabel() =>
        _selectedOffer switch
        {
            OfferType.Fixed => "Fixed Discount",
            OfferType.Percentage => "15% Discount",
            OfferType.Bogo => "Buy One Get One Free",
            OfferType.FirstTime => "First-Time Buyer",
            OfferType.Author => "Author Spotlight",
            OfferType.Promo => "Promo Code",
            _ => string.Empty
        };

    private decimal ApplyBogoDiscount()
    {
        var eligible = _cart
            .Where(x => x.Quantity >= 2)
            .OrderBy(x => x.Book.Price)
            .FirstOrDefault();

        return eligible?.Book.Price ?? 0m;
    }

    public int GetQuantity(Book book) =>
        _cart.FirstOrDefault(x => x.BookId == book.Id)?.Quantity ?? 0;
    
    public (decimal Discount, string Label) GetDiscountDetails(OfferType offerType, Book? targetBook = null, string? promoCode = null, decimal? fixedAmount = null, decimal? percentage = null, string? author = null)
    {
        var subtotal = _cart.Sum(x => x.Book.Price * x.Quantity);

        decimal discount = offerType switch
        {
            
            OfferType.Fixed => fixedAmount ?? 0m,

            OfferType.Percentage => percentage is not null
                ? subtotal * (percentage.Value / 100m)
                : 0m,

            OfferType.Promo => promoCode == "SAVE20"
                ? subtotal * 0.2m
                : 0m,

            OfferType.FirstTime => subtotal * 0.2m,

            OfferType.Author => !string.IsNullOrWhiteSpace(author)
                ? _cart
                    .Where(x => x.Book.Author.Contains(author, StringComparison.OrdinalIgnoreCase))
                    .Sum(x => x.Book.Price * x.Quantity) * 0.1m
                : 0m,

            OfferType.Bogo => targetBook is not null && _cart.Any(x => x.BookId == targetBook.Id && x.Quantity >= 2)
                ? targetBook.Price
                : 0m,

            _ => 0m
        };

        string label = offerType switch
        {
            OfferType.Fixed => $"Fixed Discount (${fixedAmount ?? 0})",
            OfferType.Percentage => $"{percentage ?? 0}% Discount",
            OfferType.Promo => "Promo Code",
            OfferType.FirstTime => "First-Time Buyer (20% off)",
            OfferType.Author => $"Author Spotlight (10% off {author})",
            OfferType.Bogo => $"Buy One Get One Free ({targetBook?.Title})",
            _ => ""
        };

        return (discount, label);
    }

}
