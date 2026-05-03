using Domain_layer.Interfaces;
using Infrastructure_layer.Data;
using Infrastructure_layer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure_layer;

// Denna klass registrerar allt som tillhör Infrastructure Layer
public static class DependencyInjection
{
    // Denna metod kopplar databas och repositories
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // Registrerar DbContext och SQL Server
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        // Registrerar ProductRepository
        services.AddScoped<IProductRepository, ProductRepository>();

        // Registrerar UserRepository
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}