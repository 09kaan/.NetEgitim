public class Product
{
    public string Name { get; }
    public string Category { get; }
    public decimal Price { get; private set; }
    public int Stock { get; private set; }

    public Product(
        string name,
        string category,
        decimal price,
        int stock)
    {
        // 1. name değerini Name property’sine ata.
        Name = name;
        Category = category;
        

        if (price <= 0){

            throw new ArgumentException(
                "Fiyat sıfırdan büyük olmalı."
            );
        }

        Price = price;

        if (stock < 0){

            throw new ArgumentException(
                "Stock 0dan fazla olmalı"
            );
        }
        Stock = stock;
        // 2. category değerini Category property’sine ata.

        // 3. price sıfır veya daha küçükse
        //    ArgumentException fırlat.     

        // 4. price değerini Price property’sine ata.

        // 5. stock negatifse
        //    ArgumentException fırlat.

        // 6. stock değerini Stock property’sine ata.
    }

    public void StockDecrease(int quantity)
{
    // quantity 0 veya daha küçükse
    // ArgumentException fırlat.
    if (quantity<=0)
    {
        throw new ArgumentException(
            "Miktar sıfırdan büyük olmalıdır."
        );
    }

    // quantity mevcut Stock değerinden büyükse
    // InvalidOperationException fırlat.
    if (quantity > Stock)
    {
        throw new InvalidOperationException(
            "Yeterli stok bulunmuyor."
        );
    }

    // Mevcut stoktan quantity değerini çıkar.
    Stock = Stock - quantity;
}




}