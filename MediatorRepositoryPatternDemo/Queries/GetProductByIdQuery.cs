using MediatorRepositoryPatternDemo.Models;
using MediatR;

namespace MediatorRepositoryPatternDemo.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int Id {  get; set; }
    }
}
