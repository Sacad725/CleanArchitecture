using Domain_layer.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application_Layer.Queries.products.GetProductById
{
    // Query för att hämta en produkt via ID 
    public class GetProductByIdQuery : IRequest<Product?>
    {
        // ID på produkten
        public int Id { get; set; }
    }
}
