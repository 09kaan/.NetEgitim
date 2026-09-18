using Microsoft.EntityFrameworkCore;

public class ProductService : IProductService
{
    private readonly AppDbContext _context;

    public ProductService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Product?> CreateAsync(CreateProductDto dto)
    {
        bool categoryExists =
            await _context.Categories.AnyAsync(
                category => category.Id == dto.CategoryId
            );

        if (!categoryExists)
        {
            return null;
        }

        Product product = new Product
        {
            Name = dto.Name,
            Price = dto.Price,
            CategoryId = dto.CategoryId
        };

        _context.Products.Add(product);

        await _context.SaveChangesAsync();

        return product;
    }
    public async Task<List<ProductWithCategoryDto>> GetAllWithCategoryAsync()
    {
        List<ProductWithCategoryDto> products =
            await _context.Products
                .Select(product => new ProductWithCategoryDto
                {
                    Id = product.Id,

                    Name = product.Name,

                    Price = product.Price,

                    CategoryId = product.CategoryId,

                    CategoryName = product.Category.Name
                })
                .ToListAsync();

        return products;
    }
}