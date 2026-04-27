using Domain_layer.Entities;
using Domain_layer.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application_Layer.Queries.products.GetProductById
{
    // Handler som hämtar produkt via ID 
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product?>
    {
        // Repository
        private readonly IProductRepository _repository;

        // Constructor
        public GetProductByIdQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        // Körs när vi hämtar en produkt
        public async Task<Product?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            // Hämtar produkt från databasen
            return await _repository.GetByIdAsync(request.Id);
        }
    }
}
