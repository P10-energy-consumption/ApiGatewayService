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
            _client.BaseAddress = new Uri("http://host.docker.internal:8083/v1/");
        }

        public async Task<int> DeleteOrder(int orderId)
        {
            var response = await _client.DeleteAsync($"store/order/{orderId}");
            var data = await response.Content.ReadAsAsync<int>();
            return data;
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

        public async Task<Order> PostOrder(Order order)
        {
            var response = await _client.PostAsJsonAsync("store/order", order);
            var data = await response.Content.ReadAsAsync<Order>();
            return data;
        }
    }
}
