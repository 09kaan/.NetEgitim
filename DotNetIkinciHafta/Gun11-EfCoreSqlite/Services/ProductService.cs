public class ProductService : IProductService
{   
    private readonly AppDbContext _context;

    public ProductService(AppDbContext context)
    {
        _context = context;
    }


    public List<Product> GetAll()
    {
        
         return _context
        .Products.ToList()
        /* Sonucu List<Product> hâline getir */;
        
    }

    public Product? GetById(int id)
    {
        // Id değeri eşit olan ilk ürünü bul.
        return _context.Products.FirstOrDefault(
            product => product.Id == id                 //productı biz belirliyoruz önemli değil
                                                        //Çıktı Product veya null.
        );
    }
    public Product Create(CreateProductDto dto)
    {
        Product product = new Product
        {
            Name = dto.Name,
            Price = dto.Price
        };

        // Product nesnesini Products tablosuna eklenmek üzere hazırla.
        _context.Products.Add(product);

        // Değişiklikleri SQLite veritabanına kaydet.
        _context.SaveChanges();

        return product;
    }
}