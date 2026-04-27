using System;
using System.Collections.Generic;
using System.Text;

namespace Domain_layer.Entities
{

    // Denna klass representerar en produkt i systemet.

    
    public class Product
    {
        // Primärnyckel (ID för produkten)
        public int Id { get; set; }

        // Namn på produkten
        public string Name { get; set; } = string.Empty;

        // Pris på produkten
        public decimal Price { get; set; }

        // 🔹 Foreign Key – vilken user som äger produkten
        public int UserId { get; set; }

        // 🔹 Navigation – koppling till User
        public User User { get; set; } = null!;
    }
}
