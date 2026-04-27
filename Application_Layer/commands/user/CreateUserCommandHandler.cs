using Domain_layer.Entities;
using Domain_layer.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application_Layer.commands.user
{
   // Handler = logik för att skapa user
public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _repository;

        // DI
        public CreateUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            // Skapar user
            var user = new User
            {
                Username = request.Username,
                PasswordHash = request.Password
            };

            // Sparar i databasen
            await _repository.AddAsync(user);

            // Returnerar ID
            return user.Id;
        }
    }
}
