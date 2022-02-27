using ApiGatewayService.Models;

namespace ApiGatewayService.Repositories.Interfaces
{
    public interface IStoreRepository
    {
        Task<List<InventoryLine>> GetInventory();
        Task<Order> GetOrders(int orderId);
    }
}
