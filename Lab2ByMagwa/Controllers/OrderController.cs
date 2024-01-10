using Microsoft.AspNetCore.Mvc;
using Lab2.CommonModules.Interface;
using Lab2.CommonModules.Entity;
using System.Threading.Tasks;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrder _orderService;

        public OrderController(IOrder orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody] Order order)
        {
            var result = await _orderService.Add(order);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetOrder([FromBody] Order order)
        {
            var result = await _orderService.Get(order);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder([FromBody] Order order)
        {
            var result = await _orderService.Update(order);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrder([FromBody] Order order)
        {
            var result = await _orderService.Delete(order);
            return Ok(result);
        }
    }
}
