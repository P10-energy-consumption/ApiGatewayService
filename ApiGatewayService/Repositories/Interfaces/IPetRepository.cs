using ApiGatewayService.Models;

namespace ApiGatewayService.Repositories.Interfaces
{
    public interface IPetRepository
    {
        Task<int> InsertPet(Pet pet);
        Task<int> UpdatePet(Pet pet);
        Task<int> InsertPetPhoto(PetPhoto photo);
        Task<int> DeletePet(int petId);
        Task<Pet> GetPet(int petId);
        Task<List<Pet>> GetPetByStatus(PetStatus status);
    }
}
