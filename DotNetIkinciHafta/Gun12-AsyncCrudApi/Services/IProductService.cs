public interface IProductService
{
    Task<List<Product>> GetAllAsync();

    Task<Product?> GetByIdAsync(int id);

    Task<Product> CreateAsync(CreateProductDto dto);

    Task<Product?> UpdateAsync(int id, UpdateProductDto dto);
    
    Task<Product?> UpdatePriceAsync(int id, UpdatePriceDto dto);

    Task<bool> DeleteAsync(int id);
}