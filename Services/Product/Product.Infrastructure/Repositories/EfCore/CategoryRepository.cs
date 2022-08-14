using Product.Application.Interfaces;
using Product.Domain.Entities;

namespace Product.Infrastructure.Repositories.EfCore;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    public CategoryRepository(ProductDbContext context) : base(context)
    {
    }
}