public interface ICategoryService
{
    // Bütün kategorileri asenkron olarak getir.
    Task<List<Category>> GetAllAsync();

    // DTO'dan yeni kategori oluştur ve kaydedilen kategoriyi döndür.
    Task<Category> CreateAsync(
        CreateCategoryDto dto
    );
}