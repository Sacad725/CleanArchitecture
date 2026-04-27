using Domain_layer.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application_Layer.commands.Product.UpdateProduct
{
    // Handler som uppdaterar produkt i databasen när vi skickar UpdateProductCommand
    // Den innehåller logiken för att uppdatera en produkt 
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        // Repository för databasen
        private readonly IProductRepository _repository;

        // Constructor
        public UpdateProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        // Körs när vi skickar update command
        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            // Hämtar produkten från databasen
            var product = await _repository.GetByIdAsync(request.Id);

            // Om produkten inte finns
            if (product == null)
                return false;

            // Uppdaterar värden
            product.Name = request.Name;
            product.Price = request.Price;

            // Sparar ändringar i databasen
            await _repository.UpdateAsync(product);

            // Returnerar true om lyckad
            return true;
        }
    }
}
