using Gun16.Application.Interfaces;
using Gun16.Domain.Entities;
using Gun16.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Gun16.Infrastructure.Repositories;
// TODO 1: Gerekli namespace'leri ekle.
// Domain Entities, Application Interfaces, Infrastructure Data ve EF Core.

    public class BrandRepository : IBrandRepository
// TODO 2: BrandRepository sınıfını oluştur ve IBrandRepository'yi uygula.
{

    private readonly AppDbContext _context;
// TODO 3: AppDbContext tipinde private readonly field oluştur.
    public BrandRepository (AppDbContext context)
    {
        _context = context;
    }
// TODO 4: Constructor ile AppDbContext al ve field'a ata.
    
// TODO 5: AddAsync metodunda:
// - Brand'i Brands DbSet'ine asenkron ekle.
// - Değişiklikleri asenkron kaydet.
// - Eklenen Brand'i döndür.
    public async Task<Brand> AddAsync(Brand brand)
{
    await _context.Brands.AddAsync(brand);

    await _context.SaveChangesAsync();

    return brand;

}
// TODO 6: GetAllAsync metodunda:
// - Brands DbSet'indeki kayıtları asenkron liste olarak döndür.

    public async Task<List<Brand>> GetAllAsync()
    {
        return await _context.Brands.ToListAsync();
    }
}
