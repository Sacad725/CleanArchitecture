using Domain_layer.Entities;
using Infrastructure_layer.Data;
using Domain_layer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure_layer.Repositories
{
    // DENNA KLASS: Implementation av IProductRepository
    // Här skriver vi HUR vi jobbar med databasen (EF Core)
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        // CONSTRUCTOR: Vi får DbContext via Dependency Injection
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

       
        // Hämtar alla produkter + tillhörande User (relation)
        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products
                .Include(p => p.User) //  laddar kopplad user
                .ToListAsync();
        }

       
        // Hämtar en specifik produkt via ID + User
        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.User) // 🔥 laddar kopplad user
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        // Lägger till en ny produkt i databasen
        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product); // lägg till
            await _context.SaveChangesAsync();         // spara
        }

       
        // Uppdaterar en befintlig produkt
        public async Task UpdateAsync(Product product)
        {
            _context.Products.Update(product); // uppdatera
            await _context.SaveChangesAsync(); // spara
        }

        // METOD: Tar bort en produkt från databasen
        public async Task DeleteAsync(Product product)
        {
            _context.Products.Remove(product); // ta bort
            await _context.SaveChangesAsync(); // spara
        }
    }
}