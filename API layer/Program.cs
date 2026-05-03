using Application_Layer;
using Application_Layer.mapping;
using Domain_layer.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using API_Layer.Extensions;
using Infrastructure_layer;




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

            // 🔹 Kopplar Infrastructure Layer (databas + repository)
            builder.Services.AddInfrastructure(builder.Configuration);



            // istället för all JWT kod 
            builder.Services.AddJwtAuthentication(builder.Configuration);



            // Lägg till controllers (API endpoints)
            builder.Services.AddControllers();

            // Scalar / OpenAPI (för att testa API)
            builder.Services.AddOpenApi();

        
            


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