/*
product.Name          → Klavye
product.CategoryId    → 1
product.Category.Name → Teknoloji
CategoryId → Veritabanındaki foreign key
Category   → C# tarafındaki ilişkili nesne
*/

namespace Gun16.Domain.Entities;

public class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = "";

    public decimal Price { get; set; }

    public int CategoryId { get; set; }

    public Category Category { get; set; } = null!;

    public void ChangePrice(decimal newPrice)
    {
        // Yeni fiyat 0 veya daha küçükse iş kuralı ihlal edilmiştir.
        if (newPrice <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(newPrice),
                "Ürün fiyatı 0'dan büyük olmalıdır."
            );
        }

        // Kontrolden geçen yeni fiyatı Product'ın Price property’sine aktar.
        Price = newPrice;
    }
}