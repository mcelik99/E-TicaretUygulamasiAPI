using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
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
        public async Task Get()
        {
            //await _writerRepository.AddRangeAsync(new()
            //{
            //    new() {Id = Guid.NewGuid(), Name = "Product 1", Price = 100, CreateDate = DateTime.UtcNow, Stock = 10},
            //    new() {Id = Guid.NewGuid(), Name = "Product 2", Price = 200, CreateDate = DateTime.UtcNow, Stock = 20},
            //    new() {Id = Guid.NewGuid(), Name = "Product 3", Price = 300, CreateDate = DateTime.UtcNow, Stock = 30},
            //});
            //var count = await _writerRepository.SaveAsync();
            Product p = await _readRepository.GetByIdAsync("d32dad5e-b916-4694-86aa-cb97882e412a",false);
            p.Name = "Mehmet";
            await _writerRepository.SaveAsync();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Product product = await _readRepository.GetByIdAsync(id);
            return Ok(product);
        }
    }
}
