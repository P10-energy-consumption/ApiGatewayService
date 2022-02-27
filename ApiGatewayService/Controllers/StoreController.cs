using ApiGatewayService.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiGatewayService.Controllers
{
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreRepository _storeRepository;

        public StoreController(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        [HttpGet("/v1/store/inventory")]
        public async Task<IActionResult> GetInventory()
        {
            var result = await _storeRepository.GetInventory();
            return Ok(result);
        }

        [HttpGet("/v1/store/order/{orderId}")]
        public async Task<IActionResult> GetOrders(int orderId)
        {
            var result = await _storeRepository.GetOrders(orderId);
            return Ok(result);
        }
    }
}
