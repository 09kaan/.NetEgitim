namespace Gun16.Application.DTOs;

public class ProductResponseDto
{
    // Ürün ID: int
    public int Id { get; set; }

    // Ürün adı: string, başlangıç değeri boş metin
    public string Name { get; set; } = "";

    // Ürün fiyatı: decimal
    public decimal Price { get; set; }

    // Kategori ID: int
    public int CategoryId { get; set; }

    // Kategori adı: string olabilir veya boş/null olabilir
    public string? CategoryName { get; set; }
}