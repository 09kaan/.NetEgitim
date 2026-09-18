using Gun16.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gun16.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; } = null!;

    public DbSet<Category> Categories{ get; set; } = null!;  //Category tipi Categories Dbdeki tablonun ismi
    
}