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

        readonly private IOrderWriterRepository _orderRepository;

        readonly private ICustomerWriteRepository _customerWriteRepository;

        public ProductController(IProductWriterRepository writerRepository, IProductReadRepository readRepository, IOrderWriterRepository orderRepository, ICustomerWriteRepository customerWriteRepository)
        {
            _writerRepository = writerRepository;
            _readRepository = readRepository;
            _orderRepository = orderRepository;
            _customerWriteRepository = customerWriteRepository;
        }
        [HttpGet]
        public async Task Get()
        {
            var customerId = Guid.NewGuid();
            await _customerWriteRepository.AddAsync(new() { Id = customerId,Name="Murtaza" });

            await _orderRepository.AddAsync(new() { Description = "bla bla bla", Adress = "Gaziantep,Karakuyu", CustomerId = customerId });
            await _orderRepository.AddAsync(new() { Description = "bla bla bla2", Adress = "Gaziantep,Karakuyu", CustomerId = customerId });
            await _customerWriteRepository.SaveAsync();
        }
      
    }
}
