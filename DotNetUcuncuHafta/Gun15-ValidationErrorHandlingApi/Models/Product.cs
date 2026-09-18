/*
product.Name          → Klavye
product.CategoryId    → 1
product.Category.Name → Teknoloji
CategoryId → Veritabanındaki foreign key
Category   → C# tarafındaki ilişkili nesne
*/

public class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = "";

    public decimal Price { get; set; }

    public int CategoryId { get; set; }

    public Category Category { get; set; } = null!;

}