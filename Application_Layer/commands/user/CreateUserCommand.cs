using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application_Layer.commands.user
{
    // Command = data för att skapa en user
    public class CreateUserCommand : IRequest<int>
    {
        // Username
        public string Username { get; set; } = string.Empty;

        // Lösenord (sparas som hash senare)
        public string Password { get; set; } = string.Empty;
    }
}
