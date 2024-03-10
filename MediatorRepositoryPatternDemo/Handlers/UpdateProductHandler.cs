using MediatorRepositoryPatternDemo.Commands;
using MediatorRepositoryPatternDemo.Models;
using MediatorRepositoryPatternDemo.Repositories;
using MediatR;

namespace MediatorRepositoryPatternDemo.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, Product>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            
        }
        public async Task<Product> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var productDetails = await _productRepository.GetProductByIdAsync(command.Id);

            if (productDetails == null)
            {
                return default;
            }
            else 
            { 
                productDetails.Brand = command.Brand;
                productDetails.ProdName = command.ProdName;
                productDetails.Price = command.Price;
            }

             return  await _productRepository.UpdateProductAsync(productDetails);

        }
    }
}
