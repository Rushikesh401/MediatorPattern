using MediatorRepositoryPatternDemo.Models;
using MediatR;

namespace MediatorRepositoryPatternDemo.Commands
{
    public class UpdateProductCommand : IRequest<Product>
    {
        public int Id { get; set; }

        public string ProdName { get; set; }

        public string Brand { get; set; }

        public double Price { get; set; }

        public UpdateProductCommand(int id, string prodName, string brandName, double price)
        {
            Id = id;
            ProdName = prodName;
            Brand = brandName;
            Price = price;
            
        }
    }
}
