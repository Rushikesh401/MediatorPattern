using MediatorRepositoryPatternDemo.Models;
using MediatR;

namespace MediatorRepositoryPatternDemo.Commands
{
    public class AddProductCommand : IRequest<Product>
    {
        public int Id { get; set; }
        public string ProdName { get; set; }

        public string Brand { get; set; }

        public double Price { get; set; }

        public AddProductCommand(int id, string prodname, string brandName, double price)
        {
            Id = id;
            ProdName = prodname;
            Brand = brandName;
            Price = price;
            
        }
    }
}
