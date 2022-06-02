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
    public class PetRepository : IPetRepository
    {
        private readonly HttpClient _client;

        public PetRepository(HttpClient httpClient)
        {
            _client = httpClient;
            _client.BaseAddress = new Uri("http://petstore-pet:8081/v1/");
        }

        public async Task<int> InsertPet(Pet pet)
        {
            var httpContent = new StringContent(
                        JsonSerializer.Serialize(pet),
                        Encoding.UTF8,
                        "application/json");

            var response = await _client.PostAsync("pet", httpContent);
            var data = await response.Content.ReadFromJsonAsync<int>();
            return data;
        }

        public async Task<int> InsertPetPhoto(PetPhoto photo)
        {
            var httpContent = new StringContent(
                        JsonSerializer.Serialize(photo),
                        Encoding.UTF8,
                        "application/json");

            var response = await _client.PostAsync($"pet/{photo.PetID}/uploadImage", httpContent);
            var data = await response.Content.ReadFromJsonAsync<int>();
            return data;
        }

        public async Task<int> DeletePet(int petId)
        {
            var response = await _client.DeleteAsync($"pet/{petId}");
            return petId;
        }

        public async Task<int> UpdatePet(Pet pet)
        {
            var httpContent = new StringContent(
            JsonSerializer.Serialize(pet),
            Encoding.UTF8,
            "application/json");

            var response = await _client.PutAsync($"pet", httpContent);
            var data = await response.Content.ReadFromJsonAsync<int>();

            return data;
        }

        public async Task<Pet> GetPet(int petId)
        {
            var response = await _client.GetAsync($"pet/{petId}");
            var data = await response.Content.ReadFromJsonAsync<Pet>();
            return data;
        }

        public async Task<List<Pet>> GetPetByStatus(PetStatus status)
        {
            var response = await _client.GetAsync($"pet/findbystatus?status={status}");
            var data = await response.Content.ReadFromJsonAsync<List<Pet>>();
            return data;
        }

    }
}
