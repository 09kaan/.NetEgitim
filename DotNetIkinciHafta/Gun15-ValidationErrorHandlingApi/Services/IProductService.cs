public interface IProductService
{
    Task<Product?> CreateAsync(CreateProductDto dto);           //? Product id geçersizse null dönsün yani product oluşturulamasın diye var

    Task<List<ProductWithCategoryDto>> GetAllWithCategoryAsync();
}