using Product.Application.Interfaces;

namespace Product.Infrastructure.Repositories.EfCore;

public class ProductRepository : GenericRepository<Domain.Entities.Product>, IProductRepository
{
    public ProductRepository(ProductDbContext context) : base(context)
    {
    }
}