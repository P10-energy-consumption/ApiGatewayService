using ApiGatewayService.Models;

namespace ApiGatewayService.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<int> InsertUser(User user);
        Task<User> GetUser(string userName);
        Task<User> UpdateUser(User user);
        Task<string> DeleteUser(string userName);

    }
}
