using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Domain_layer.Entities
{

  //  Denna klass representerar en användare.
//Används för:
 // - login
 // - JWT authentication
 // -roller(Admin / User)
 //Vi sparar inte lösenord direkt, utan som hash.

public class User
    {
        public int Id { get; set; }

        public string Username { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public string Role { get; set; } = "User";

        // 🔹 En user kan ha flera produkter
        // 🔥 Stoppar JSON-loop
        [JsonIgnore]
        public List<Product> Products { get; set; } = new();

    }
}
