using MediatorRepositoryPatternDemo.Models;
using MediatR;

namespace MediatorRepositoryPatternDemo.Queries
{
    public class GetProductsListQuery : IRequest<List<Product>>
    {
    }
}
