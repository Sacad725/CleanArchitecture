using Application_Layer.DTO;
using Domain_layer.Entities;
using Domain_layer.Entities;
using MediatR;

namespace Application_Layer.Queries.products.GetAllProducts;

// Query = en fråga till systemet, Den används för att hämta ALLA produkter
// Den är tom eftersom vi inte behöver någon input
public class GetAllProductsQuery : IRequest<List<ProductDto>>
{
    
}