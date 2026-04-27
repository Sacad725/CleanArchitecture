using Domain_layer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain_layer.Interfaces;

// Interface för User
public interface IUserRepository
{
    // Hämtar user via username (login)
    Task<User?> GetByUsernameAsync(string username);

    // Skapar user
    Task AddAsync(User user);

    //  NY: Hämtar user via ID (för Product relation)
    Task<User?> GetByIdAsync(int id);
}