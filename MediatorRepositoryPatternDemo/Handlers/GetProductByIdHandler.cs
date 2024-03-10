using MediatorRepositoryPatternDemo.Models;
using MediatorRepositoryPatternDemo.Queries;
using MediatorRepositoryPatternDemo.Repositories;
using MediatR;

namespace MediatorRepositoryPatternDemo.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IProductRepository _productRepository;


        public GetProductByIdHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProductByIdAsync(request.Id);
        }
    }
}
