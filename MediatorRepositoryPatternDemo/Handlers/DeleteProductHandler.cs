using MediatorRepositoryPatternDemo.Commands;
using MediatorRepositoryPatternDemo.Models;
using MediatorRepositoryPatternDemo.Repositories;
using MediatR;

namespace MediatorRepositoryPatternDemo.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, Product>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
           return await _productRepository.DeleteProductAsync(request.Id);
        }
    }
}
