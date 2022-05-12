using ApiGatewayService.Models;
using ApiGatewayService.Repositories.Interfaces;

namespace ApiGatewayService.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly HttpClient _client = new HttpClient();

        public UserRepository()
        {
            _client.BaseAddress = new Uri("http://host.docker.internal:8082/v1/");
        }

        public async Task<int> InsertUser(User user)
        {
            var response = await _client.PostAsJsonAsync("user", user);
            var data = await response.Content.ReadAsAsync<int>();
            return data;
        }

        public async Task<User> GetUser(string userName)
        {
            var response = await _client.GetFromJsonAsync<User>($"user/{userName}");
            return response;
        }

        public async Task<User> UpdateUser(User user)
        {
            var response = await _client.PutAsJsonAsync("user", user);
            return user;
        }

        public async Task<string> DeleteUser(string userName)
        {
            var response = await _client.DeleteAsync($"user/{userName}");
            return userName;
        }
    }
}
