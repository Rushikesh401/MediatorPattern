using MediatorRepositoryPatternDemo.Models;
using System.Xml.Serialization;

namespace MediatorRepositoryPatternDemo.BackgroundJobs
{
    public class FireForgetJob
    {
        public FireForgetJob()
        {
            
        }

        public void  PrintResponse(Product product) {
            Console.WriteLine($"Fire and Forget Job Executed {product.ProdName}");
        }
    }
}
