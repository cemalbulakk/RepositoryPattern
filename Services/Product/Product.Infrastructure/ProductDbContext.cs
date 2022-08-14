using Microsoft.EntityFrameworkCore;
using Product.Domain.Entities;

namespace Product.Infrastructure;

public class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
    {

    }

    public DbSet<Domain.Entities.Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
}