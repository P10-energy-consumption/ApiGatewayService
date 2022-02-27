using ApiGatewayService.Database.Interfaces;
using ApiGatewayService.Models;
using ApiGatewayService.Repositories.Interfaces;
using Dapper;
using ServiceStack;
using System.Linq;

namespace ApiGatewayService.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly HttpClient _client = new HttpClient();

        public StoreRepository()
        {
            _client.BaseAddress = new Uri("https://localhost:49161/v1/");
        }

        public async Task<List<InventoryLine>> GetInventory()
        {
            var response = await _client.GetFromJsonAsync<List<InventoryLine>>("store/inventory");
            return response;
        }

        public async Task<Order> GetOrders(int orderId)
        {
            var response = await _client.GetFromJsonAsync<Order>($"store/order/{orderId}");
            return response;
        }

    }
}
