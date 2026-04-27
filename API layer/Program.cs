using Application_Layer;
using Application_Layer.mapping;
using Domain_layer.Interfaces;
using Infrastructure_layer.Data;
using Infrastructure_layer.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using API_Layer.Extensions;



namespace API_Layer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // SERVICES (Dependency Injection)

            // Application Layer (MediatR)
            builder.Services.AddApplication();

        

            // istället för all JWT kod 
            builder.Services.AddJwtAuthentication(builder.Configuration);



            // Lägg till controllers (API endpoints)
            builder.Services.AddControllers();

            // Scalar / OpenAPI (för att testa API)
            builder.Services.AddOpenApi();

        
            // DATABAS (DbContext)
          
            // Kopplar vår DbContext till SQL Server
            // Hämtar connection string från appsettings.json
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

           
            // REPOSITORY

            // Berättar för systemet att när någon frågar efter IProductRepository
            // så systemet använda ProductRepository
            builder.Services.AddScoped<IProductRepository, ProductRepository>();

         // Berättar för systemet att när någon frågar efter IUserRepository
            builder.Services.AddScoped<IUserRepository, UserRepository>();


            // BUILD APP

            var app = builder.Build();


            // MIDDLEWARE


            if (app.Environment.IsDevelopment())
            {
                // Skapar OpenAPI dokument (JSON)
                app.MapOpenApi();

                // Visar Scalar UI
                app.MapScalarApiReference();
            }

            app.UseHttpsRedirection(); // Tvingar HTTPS

            app.UseAuthentication(); // identifierar user
            app.UseAuthorization();  // kollar rättigheter

            app.MapControllers(); // Kopplar controllers

            app.Run(); // Startar appen
        }
    }
}