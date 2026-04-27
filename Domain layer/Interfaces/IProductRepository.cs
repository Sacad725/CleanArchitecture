using Domain_layer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain_layer.Interfaces;

// DENNA INTERFACE: Beskriver vad vi kan göra med produkter
// (utan att veta hur databasen fungerar)

public interface IProductRepository
{
    // Hämtar alla produkter från databasen
    Task<List<Product>> GetAllAsync();

    
    Task<Product?> GetByIdAsync(int id);

    Task AddAsync(Product product);

    Task UpdateAsync(Product product);

    Task DeleteAsync(Product product);
}