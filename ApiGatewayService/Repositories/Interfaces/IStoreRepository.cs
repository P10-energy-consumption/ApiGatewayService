using ApiGatewayService.Models;

namespace ApiGatewayService.Repositories.Interfaces
{
    public interface IStoreRepository
    {
        Task<List<InventoryLine>> GetInventory();
        Task<Order> GetOrders(int orderId);
        Task<Order> PostOrder(Order order);
        Task<int> DeleteOrder(int orderId);
    }
}
