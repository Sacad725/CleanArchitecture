using System;
using System.Collections.Generic;
using System.Text;

namespace Application_Layer.DTO
{
    
    // Denna klass används för att skicka data till klienten (API response)
    // Vi skickar inte hela Product entity (t.ex. User.PasswordHash)

    public class ProductDto
    {
        
        public int Id { get; set; }

        
        public string Name { get; set; } = string.Empty;

        
        public decimal Price { get; set; }

     
        public int UserId { get; set; }

        // 🔥 Vi skickar username istället för hela User
        public string Username { get; set; } = string.Empty;
    }
}
