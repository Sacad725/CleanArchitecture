using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application_Layer.commands.Product.CreateProduct
{
    // Vi använder den när vi vill skapa en produkt
    // Den innehåller bara data (ingen logik)

    public class CreateProductCommand : IRequest<int> // returnerar produktens Id
    {

        public string Name { get; set; } = string.Empty;


        public decimal Price { get; set; }

        // ID på user som skapar produkten
        public int UserId { get; set; }


    }
}
   
