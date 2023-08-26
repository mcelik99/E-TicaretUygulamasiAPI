using ETicaretAPI.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly private IProductWriterRepository _writerRepository;
        readonly private IProductReadRepository _readRepository;

        public ProductController(IProductWriterRepository writerRepository, IProductReadRepository readRepository)
        {
            _writerRepository = writerRepository;
            _readRepository = readRepository;
        }
        [HttpGet]
        public async void Get()
        {
            await _writerRepository.AddRangeAsync(new()
            {
                new() {Id = Guid.NewGuid(), Name = "Product 1", Price = 100, CreateDate = DateTime.UtcNow, Stock = 10},
                new() {Id = Guid.NewGuid(), Name = "Product 2", Price = 200, CreateDate = DateTime.UtcNow, Stock = 20},
                new() {Id = Guid.NewGuid(), Name = "Product 3", Price = 300, CreateDate = DateTime.UtcNow, Stock = 30},
            });
            var count = await _writerRepository.SaveAsync();
        }
    }
}
