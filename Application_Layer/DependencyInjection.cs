using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application_Layer;

public static class DependencyInjection
{
    // Registrerar allt som tillhör Application Layer
    // Här kopplar vi MediatR och AutoMapper
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Hämtar Application_Layer assembly
        var assembly = typeof(DependencyInjection).Assembly;

        // Registrerar MediatR och hittar alla handlers
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(assembly);
        });

        // Registrerar AutoMapper och hittar alla MappingProfile i Application_Layer
        services.AddAutoMapper(cfg => cfg.AddMaps(assembly));

        // Returnerar services tillbaka till Program.cs
        return services;
    }
}