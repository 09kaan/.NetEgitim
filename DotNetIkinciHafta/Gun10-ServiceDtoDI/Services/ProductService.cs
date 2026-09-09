public class ProductService : IProductService
{
    private readonly List<Product> _products = new()
    {
        new Product
        {
            Id = 1,
            Name = "Klavye",
            Price = 850
        },
        new Product
        {
            Id = 2,
            Name = "Mouse",
            Price = 450
        }
    };

    public List<Product> GetAll()
    {
        // Ürün listesini döndür.
        return _products;
    }

    public Product? GetById(int id)
    {
        // Id değeri eşit olan ilk ürünü bul.
        return _products.FirstOrDefault(
            product => product.Id == id
        );
    }
    public Product Create(CreateProductDto dto)
    {
        int newId = _products.Count + 1;

        Product product = new Product
        {
            Id = newId,

            // DTO'dan gelen adı Product'a aktar.
            Name = dto.Name,

            // DTO'dan gelen fiyatı Product'a aktar.
            Price = dto.Price

        };
        _products.Add(product);
        return product;

    }
}