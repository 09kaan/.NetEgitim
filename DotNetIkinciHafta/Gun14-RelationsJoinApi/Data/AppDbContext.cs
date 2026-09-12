using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(
        DbContextOptions<AppDbContext> options
    ) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; } = null!;

    public DbSet<Category> Categories{ get; set; } = null!;  //Category tipi Categories Dbdeki tablonun ismi
}