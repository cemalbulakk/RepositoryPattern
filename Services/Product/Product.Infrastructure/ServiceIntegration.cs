using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Product.Application.Interfaces;
using Product.Infrastructure.Repositories.EfCore;

namespace Product.Infrastructure;

public static class ServiceIntegration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ProductDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("SqlServerConnection")));

        //Add Repositories

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddTransient<IProductRepository, ProductRepository>();
        services.AddTransient<ICategoryRepository, CategoryRepository>();
        return services;
    }
}