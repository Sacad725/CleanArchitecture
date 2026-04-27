using Domain_layer.Entities;
using Domain_layer.Interfaces;
using Infrastructure_layer.Data;
using Microsoft.EntityFrameworkCore;

// DENNA KLASS: Implementation av IUserRepository
// Här skriver vi HUR vi jobbar med databasen (EF Core)

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    // Constructor: Vi får DbContext via Dependency Injection
    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    // DENNA METOD: Skapar en ny user i databasen
    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user); // Lägg till
        await _context.SaveChangesAsync();   // Spara
    }

    // DENNA METOD:Hämtar user via användarnamn (används för login)
    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Username == username);
    }

    // DENNA METOD: Hämtar user via ID (VIKTIG för Product relation)
    public async Task<User?> GetByIdAsync(int id)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Id == id);
    }
}