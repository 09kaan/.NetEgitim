using Gun16.Application.DTOs;
using Gun16.Application.Interfaces;
using Gun16.Domain.Entities;

namespace Gun16.Infrastructure.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    // Kategori varlık kontrolünü yapacak repository.
    private readonly ICategoryRepository _categoryRepository;

    public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<Product?> CreateAsync(CreateProductDto dto)
    {
        bool categoryExists =
            await _categoryRepository.ExistsAsync(dto.CategoryId)
            ;

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

        return await _productRepository.AddAsync(product);
    }
    public async Task<List<ProductWithCategoryDto>> GetAllWithCategoryAsync()
    {
        List<Product> products = await _productRepository.GetAllAsync();

        List<ProductWithCategoryDto> productDtos = products
            .Select(product => new ProductWithCategoryDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                CategoryId = product.CategoryId,
                CategoryName = product.Category.Name
            })
            .ToList();

        return productDtos;
    }
   public async Task<ProductWithCategoryDto?> GetByIdWithCategoryAsync(int id)
    {
        Product? product = await _productRepository.GetByIdAsync(id);

        if (product is null)
        {
            return null;
        }

        return new ProductWithCategoryDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            CategoryId = product.CategoryId,
            CategoryName = product.Category.Name
        };
    }
    public async Task<Product?> UpdateAsync(int id, UpdateProductDto dto)
    {
        // Güncellenecek ürünü repository üzerinden bul
        Product? product = await _productRepository.GetByIdAsync(id);

        if (product is null)
        {
            return null;
        }

        // Gönderilen kategori gerçekten var mı?
        bool categoryExists =
            await _categoryRepository.ExistsAsync(dto.CategoryId)
            ;

        if (!categoryExists)
        {
            return null;
        }

        // DTO'daki yeni değerleri bulunan Product'a aktar
        product.Name = dto.Name;
        product.Price = dto.Price;
        product.CategoryId = dto.CategoryId;

        // Güncellenen Product'ı repository üzerinden kaydet
        return await _productRepository.UpdateAsync(product);
    }
    public async Task<bool> DeleteAsync(int id)
    {
        // Repository üzerinden ID'ye sahip ürünü getir.
        Product? product =
            await _productRepository.GetByIdAsync(id);

        // Ürün bulunamadıysa silme başarısızdır.
        if (product is null)
        {
            return false;
        }

        // Bulunan ürünü repository üzerinden sil.
        await _productRepository.DeleteAsync(product);

        // Silme işlemi tamamlandı.
        return true;
    }
}