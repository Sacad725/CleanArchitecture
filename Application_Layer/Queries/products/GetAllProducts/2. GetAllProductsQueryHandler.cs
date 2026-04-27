using Application_Layer.DTO;
using AutoMapper;
using Domain_layer.Entities;
using Domain_layer.Entities;
using Domain_layer.Interfaces;
using MediatR;

namespace Application_Layer.Queries.products.GetAllProducts;


// DENNA HANDLER:
// Hämtar produkter och mappar till DTO

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductDto>>
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    // Constructor (Dependency Injection)
    public GetAllProductsQueryHandler(IProductRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        // Hämtar produkter från DB
        var products = await _repository.GetAllAsync();

        // 🔥 Mappar till DTO
        return _mapper.Map<List<ProductDto>>(products);
    }
}
