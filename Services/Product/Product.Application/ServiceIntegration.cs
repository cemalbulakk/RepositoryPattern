using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Product.Application.Behaviours;

namespace Product.Application;

public static class ServiceIntegration
{
    public static IServiceCollection AddApplicationRegister(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
        serviceCollection.AddMediatR(Assembly.GetExecutingAssembly());
        serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        serviceCollection.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return serviceCollection;
    }
}