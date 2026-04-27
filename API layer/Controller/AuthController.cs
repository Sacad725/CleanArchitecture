using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Domain_layer.Interfaces;

// DENNA KLASS: Hanterar login och skapar JWT token
// När user loggar in → får en token

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    // Repository för att hämta user från databasen
    private readonly IUserRepository _userRepository;

    // Hämtar config (appsettings.json)
    private readonly IConfiguration _config;

    // Constructor (Dependency Injection)
    public AuthController(IUserRepository userRepository, IConfiguration config)
    {
        _userRepository = userRepository;
        _config = config;
    }

    // METOD: LOGIN Tar emot username + password
    // Returnerar JWT token om det är rätt
    [HttpPost("login")]
    public async Task<IActionResult> Login(string username, string password)
    {
        // Hämtar user från databasen
        var user = await _userRepository.GetByUsernameAsync(username);

        // Kontrollerar att user finns och lösenord stämmer
        if (user == null || user.PasswordHash != password)
            return Unauthorized(); // fel → stoppa

        // Claims = information som sparas i token
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.Username), // username
            new Claim(ClaimTypes.Role, user.Role)      // roll (User/Admin)
        };

        // Hämtar hemlig nyckel från appsettings
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

        // Skapar signering (säkerhet)
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        // Skapar själva token
        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],     // vem skapade token
            audience: _config["Jwt:Audience"], // vem får använda
            claims: claims,                    // data i token
            expires: DateTime.Now.AddHours(1), // giltighetstid
            signingCredentials: creds          // säkerhet
        );

        // Skickar tillbaka token till klienten
        return Ok(new
        {
            token = new JwtSecurityTokenHandler().WriteToken(token)
        });
    }
}