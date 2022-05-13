using ApiGatewayService.Models;
using ApiGatewayService.Repositories.Interfaces;
using ServiceStack;
using System.Text;
using System.Text.Json;

namespace ApiGatewayService.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly HttpClient _client;

        public UserRepository(HttpClient httpClient)
        {
            _client = httpClient;
            _client.BaseAddress = new Uri("http://host.docker.internal:8082/v1/");
        }

        public async Task<int> InsertUser(User user)
        {
            var httpContent = new StringContent(
                    JsonSerializer.Serialize(user),
                    Encoding.UTF8,
                    "application/json");

            var response = await _client.PostAsync("user", httpContent);
            var data = await response.Content.ReadFromJsonAsync<int>();

            return data;
        }

        public async Task<User> GetUser(string userName)
        {
            var response = await _client.GetAsync($"user/{userName}");
            var data = await response.Content.ReadFromJsonAsync<User>();

            return data;
        }

        public async Task<User> UpdateUser(User user)
        {
            var httpContent = new StringContent(
                                    JsonSerializer.Serialize(user),
                                    Encoding.UTF8,
                                    "application/json");

            var response = await _client.PutAsync("user", httpContent);

            return user;
        }

        public async Task<string> DeleteUser(string userName)
        {
            var response = await _client.DeleteAsync($"user/{userName}");
            return userName;
        }
    }
}
