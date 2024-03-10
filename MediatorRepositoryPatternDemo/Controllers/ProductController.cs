using MediatorRepositoryPatternDemo.Commands;
using MediatorRepositoryPatternDemo.Models;
using MediatorRepositoryPatternDemo.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Hangfire;
using MediatorRepositoryPatternDemo.BackgroundJobs;

namespace MediatorRepositoryPatternDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator; private readonly IBackgroundJobClient _backgroundJobClient;
       
        private readonly FireForgetJob _fireForgetJob;
        public ProductController(IMediator mediator, IBackgroundJobClient backgroundJobClient, FireForgetJob fireForgetJob)
        {
            _mediator = mediator;
            _backgroundJobClient = backgroundJobClient;
            _fireForgetJob = fireForgetJob;
        }


        [HttpGet]
        public async Task<List<Product>> GetProductsListAsync()
        {
            var products = await _mediator.Send(new GetProductsListQuery());
            return products;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductByIdAsync(int id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery() {Id = id});

            if (product == null)
            {
                return NotFound();
            }
            _backgroundJobClient.Enqueue(() => _fireForgetJob.PrintResponse(product));
            RecurringJob.AddOrUpdate(() => Console.WriteLine("Recurring Job Executed"), Cron.Minutely);

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> AddProductAsync(Product product)
        {
            var Addedproduct = await _mediator.Send(new AddProductCommand(
                product.Id,
                product.ProdName,
                product.Brand,
                product.Price
               
                ));

            return Ok(Addedproduct);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductAsync(Product product)
        {
            var updatedProduct = await _mediator.Send(new UpdateProductCommand(
                product.Id,
                product.ProdName,
                product.Brand,
                product.Price

                ));
            return Ok(updatedProduct);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductAsync(int id)
        {
           return  Ok(await _mediator.Send(new DeleteProductCommand() { Id = id}));
          
        }

    }
}
