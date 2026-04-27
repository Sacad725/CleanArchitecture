using Application_Layer.commands.Product;
using Application_Layer.commands.Product.CreateProduct;
using Domain_layer.Entities;
using Domain_layer.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application_Layer.Commands.Products.CreateProduct;


// DENNA KLASS: En Handler (logik)
// Den körs när vi skickar CreateProductCommand
// Här skapas produkten och sparas i databasen

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
{
    // Repository används för att prata med databasen
    private readonly IProductRepository _productRepository;

    // Constructor:
    // Dependency Injection → vi får repository automatiskt
    public CreateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }


    // DENNA METOD: Körs när vi skickar command via MediatR

    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        // Skapar en Product (entity från Domain)
        var product = new Product
        {
            Name = request.Name,
            Price = request.Price,
            UserId = request.UserId

        };

        // Sparar produkten i databasen
        await _productRepository.AddAsync(product);

        // Returnerar Id på den nya produkten
        return product.Id;
    }
}

