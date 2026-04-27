using Application_Layer.commands.Product.DeleteProduct;
using Domain_layer.Interfaces;
using MediatR;

// Handler som tar bort produkt och den gör det när vi skickar DeleteProductCommand
// Den innehåller logiken för att ta bort en produkt från databasen 
public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
{
    // Repository
    private readonly IProductRepository _repository;

    // Constructor
    public DeleteProductCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    // Körs när vi skickar delete command
    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        // Hämtar produkten
        var product = await _repository.GetByIdAsync(request.Id);

        // Om den inte finns
        if (product == null)
            return false;

        // Tar bort produkten från databasen
        await _repository.DeleteAsync(product);

        // Returnerar true
        return true;
    }
}