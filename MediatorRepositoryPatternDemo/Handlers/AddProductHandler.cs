using MediatorRepositoryPatternDemo.Commands;
using MediatorRepositoryPatternDemo.Models;
using MediatorRepositoryPatternDemo.Repositories;
using MediatR;

namespace MediatorRepositoryPatternDemo.Handlers
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, Product>
    {
        private readonly IProductRepository _produitRepository;

        public AddProductHandler(IProductRepository produitRepository)
        {
            _produitRepository = produitRepository;
        }

        public async Task<Product> Handle(AddProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product
            {   Id = command.Id,
                ProdName = command.ProdName,
                Brand = command.Brand,
                Price = command.Price,

            };
            return await _produitRepository.AddProductAsync(product);
        }
    }
}
