using ApiGatewayService.Database.Interfaces;
using ApiGatewayService.Models;
using ApiGatewayService.Repositories.Interfaces;
using Dapper;
using ServiceStack;
using System.Linq;

namespace ApiGatewayService.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly HttpClient _client = new HttpClient();

        public PetRepository()
        {
            _client.BaseAddress = new Uri("https://localhost:44373/v1/");
        }

        public async Task<int> InsertPet(Pet pet)
        {
            var response = await _client.PostAsJsonAsync("pet", pet);
            var data = await response.Content.ReadAsAsync<int>();
            return data;
        }

        public async Task<int> InsertPetPhoto(PetPhoto photo)
        {
            var response = await _client.PostAsJsonAsync($"pet/{photo.PetID}/uploadImage", photo);
            var data = await response.Content.ReadAsAsync<int>();
            return data;
        }

        public async Task<int> DeletePet(int petId)
        {
            var response = await _client.DeleteAsync($"pet/{petId}");
            var data = await response.Content.ReadAsAsync<int>();
            return data;
        }

        public async Task<int> UpdatePet(Pet pet)
        {
            var response = await _client.PutAsJsonAsync($"pet/{pet.ID}/uploadImage", pet);
            var data = await response.Content.ReadAsAsync<int>();
            return data;
        }

        public async Task<Pet> GetPet(int petId)
        {
            var response = await _client.GetFromJsonAsync<Pet>($"pet/{petId}");
            return response;
        }

        public async Task<List<Pet>> GetPetByStatus(PetStatus status)
        {
            var response = await _client.GetFromJsonAsync<List<Pet>>($"pet/findbystatus?status={status}");
            return response;
        }

    }
}
