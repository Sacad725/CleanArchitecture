using Application_Layer.commands.Product;
using Application_Layer.commands.Product.CreateProduct;
using Application_Layer.Queries.products.GetAllProducts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace API_Layer.Controllers;

// Controller för produkter
// Tar emot HTTP requests (GET, POST)
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    // Constructor (Dependency Injection)
    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    
    // DENNA METOD: Hämtar alla produkter som GET: api/products
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllProductsQuery());
        return Ok(result);
    }

    
    // DENNA METOD: Skapar en ny produkt  POST: api/products
    
    [HttpPost]
    public async Task<IActionResult> Create(CreateProductCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}