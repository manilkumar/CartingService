using Application.ServiceInterfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ILogger<CartController> logger;
        private readonly IServiceManager _serviceManager;

        public CartController(IServiceManager serviceManager, ILogger<CartController> logger)
        {
            _serviceManager = serviceManager;
            this.logger = logger;
        }

        // GET: api/<CartController>
        [HttpGet]
        [Route("GetCartItems/{cartId}")]
        public async Task<IActionResult> GetItems(Guid? cartId)
        {
            var result = await _serviceManager.CartService.GetAllItems(cartId);
            return Ok(result.entities);
        }

        // POST api/<CartController>
        [HttpPost]
        [Route("AddItem")]
        public async Task<IActionResult> AddItem([FromBody] Cart entity)
        {
            var result = await _serviceManager.CartService.AddItem(entity);
            return Ok(result);
        }

        // DELETE api/<CartController>/5
        [HttpDelete("DeleteItem/{itemId}")]
        public async Task<IActionResult> DeleteItem(int? itemId)
        {
            var result = await _serviceManager.CartService.RemoveItem(itemId);
            return Ok(result);
        }
    }
}