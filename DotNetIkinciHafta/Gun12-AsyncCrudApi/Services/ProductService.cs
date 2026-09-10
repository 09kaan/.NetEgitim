//Taski doğrudan return ediyorsak async await kullanmamıza gerek yok
//ama çıkan sonucu kullanıyorsak aynı Task içinde async await lazım
//Deletede ve getlerde veri göndermediğimiz için dtoya gerek yokmuş
//Post, Put ,Patchte veri gönderdiğimiz için dto lazım
using Microsoft.EntityFrameworkCore;

public class ProductService : IProductService
{   
    private readonly AppDbContext _context;

    public ProductService(AppDbContext context)
    {
        _context = context;
    }


    public Task<List<Product>> GetAllAsync()
    {
        
         return _context
        .Products.ToListAsync()
        /* Sonucu List<Product> hâline getir */;
        
    }

    public /*async*/ Task<Product?> GetByIdAsync(int id)
    {
        // Id değeri eşit olan ilk ürünü bul.
        return /*await*/ _context.Products.FirstOrDefaultAsync(             //Taski doğrudan return ediyorsak async await kullanmamıza gerek yok
                                                                        //ama çıkan sonucu kullanıyorsak aynı Task içinde async await lazım
            product => product.Id == id                 //productı biz belirliyoruz önemli değil
                                                        //Çıktı Product veya null.
        );
    }
    public async Task<Product> CreateAsync(CreateProductDto dto)
    {
        Product product = new Product
        {
            Name = dto.Name,
            Price = dto.Price
        };

        // Product nesnesini Products tablosuna eklenmek üzere hazırla.
        _context.Products.Add(product);

        // Değişiklikleri SQLite veritabanına kaydet.
        await _context.SaveChangesAsync();

        return product;
    }
    public async Task<Product?> UpdateAsync(int id, UpdateProductDto dto)
    {
        Product? product =
            await _context.Products.FirstOrDefaultAsync(
                item => item.Id == id
            );

        if (product is null)
        {
            return null;
        }

        // DTO'daki adı bulunan ürüne aktar.
        product.Name = dto.Name;

        // DTO'daki fiyatı bulunan ürüne aktar.
        product.Price = dto.Price;

        await _context.SaveChangesAsync();

        return product;
    }

    public async Task<Product?> UpdatePriceAsync(int id, UpdatePriceDto dto)
    {
        Product? product =
            await _context.Products.FirstOrDefaultAsync(
                item => item.Id == id
            );

        if (product is null)
        {
            return null;
        }

        // Yalnızca fiyatı DTO'daki değerle değiştir.
        product.Price = dto.Price;

        await _context.SaveChangesAsync();

        return product;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        // Veritabanında ID değerine göre ürünü bul.
        Product? product =
            await _context.Products.FirstOrDefaultAsync(
                item => item.Id == id
            );

        // Ürün bulunamadıysa false döndür.
        if (product is null)
        {
            return false;
        }

        // Bulunan ürünü silinmek üzere işaretle.
        _context.Products.Remove(product);

        // Silme işlemini SQLite'a uygula.
        await _context.SaveChangesAsync();

        return true;
    }
}
