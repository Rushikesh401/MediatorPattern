using MediatorRepositoryPatternDemo.Models;
using MediatorRepositoryPatternDemo.Queries;
using MediatorRepositoryPatternDemo.Repositories;
using MediatR;

namespace MediatorRepositoryPatternDemo.Handlers
{
    public class GetProductsListHandler : IRequestHandler<GetProductsListQuery, List<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductsListHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            
        }
        public async Task<List<Product>> Handle(GetProductsListQuery request, CancellationToken cancellationToken)
        {
           return await _productRepository.GetProductsListAsync();
        }
    }
}
