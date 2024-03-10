using MediatorRepositoryPatternDemo.Models;
using MediatR;

namespace MediatorRepositoryPatternDemo.Commands
{
    public class DeleteProductCommand : IRequest<Product>
    {
        public int Id { get; set; }
    }
}
