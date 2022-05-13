using ApiGatewayService.Database.Interfaces;
using ApiGatewayService.Models;
using ApiGatewayService.Repositories.Interfaces;
using Dapper;
using ServiceStack;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace ApiGatewayService.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly HttpClient _client;

        public StoreRepository(HttpClient httpClient)
        {
            _client = httpClient;
            _client.BaseAddress = new Uri("http://host.docker.internal:8083/v1/");
        }

        public async Task<int> DeleteOrder(int orderId)
        {
            var response = await _client.DeleteAsync($"store/order/{orderId}");
            return orderId;
        }

        public async Task<List<InventoryLine>> GetInventory()
        {
            var response = await _client.GetAsync("store/inventory");
            var data = await response.Content.ReadFromJsonAsync<List<InventoryLine>>();
            return data;
        }

        public async Task<Order> GetOrders(int orderId)
        {
            var response = await _client.GetAsync($"store/order/{orderId}");
            var data = await response.Content.ReadFromJsonAsync<Order>();
            return data;
        }

        public async Task<Order> PostOrder(Order order)
        {
            var httpContent = new StringContent(
                                    JsonSerializer.Serialize(order),
                                    Encoding.UTF8,
                                    "application/json");

            var response = await _client.PostAsync("store/order", httpContent);
            var data = await response.Content.ReadFromJsonAsync<Order>();
            return data;
        }
    }
}
