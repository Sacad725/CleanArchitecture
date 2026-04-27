using Domain_layer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure_layer.Data
{
    
// Detta är vår databaskoppling. DbContext:
 // kopplar vår kod till databasen
 // skapar tabeller baserat på våra Entities Varje DbSet = en tabell i databasen

    public class AppDbContext : DbContext
    {
        // Konstruktor som får inställningar från API
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Tabell för produkter
        public DbSet<Product> Products => Set<Product>();

     

        // Tabell för användare
        public DbSet<User> Users => Set<User>();
    }
}
