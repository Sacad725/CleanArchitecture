using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Application_Layer.commands.Product.DeleteProduct
{
    

    // Command för att ta bort en produkt
    // bool returnerar true om borttagning lyckades, annars false (t.ex. om produkten inte finns)
    public class DeleteProductCommand : IRequest<bool>
    {
        // ID på produkten som ska tas bort
        public int Id { get; set; }
    }
}
