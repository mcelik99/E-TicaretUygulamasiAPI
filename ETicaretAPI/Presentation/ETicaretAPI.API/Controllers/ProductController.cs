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
        readonly private IOrderReadRepository _orderReadRepository;

        readonly private ICustomerWriteRepository _customerWriteRepository;

        public ProductController(IProductWriterRepository writerRepository, IProductReadRepository readRepository, IOrderWriterRepository orderRepository, ICustomerWriteRepository customerWriteRepository, IOrderReadRepository orderReadRepository)
        {
            _writerRepository = writerRepository;
            _readRepository = readRepository;
            _orderRepository = orderRepository;
            _customerWriteRepository = customerWriteRepository;
            _orderReadRepository = orderReadRepository;
        }
        [HttpGet]
        public async Task Get()
        {
            Order order = await _orderReadRepository.GetByIdAsync("4733df49-0c70-48ca-bb64-5b8f167c15b6");
            order.Adress = "İstanbul";
            await _orderRepository.SaveAsync();
        }
      
    }
}
