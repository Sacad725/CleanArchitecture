using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application_Layer.commands.Product.UpdateProduct
{
    // Command för att uppdatera en produkt
    public class UpdateProductCommand : IRequest<bool>
    {
        // ID på produkten vi vill uppdatera
        public int Id { get; set; }

        // Nytt namn
        public string Name { get; set; } = string.Empty;

        // Nytt pris
        public decimal Price { get; set; }
    }
}
