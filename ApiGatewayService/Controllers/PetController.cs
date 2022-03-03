using ApiGatewayService.Models;
using ApiGatewayService.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiGatewayService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetController : ControllerBase
    {
        private readonly IPetRepository _petRepository;

        public PetController(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        [HttpPost("/v1/pet")]
        public async Task<IActionResult> CreatePet([FromBody] Pet pet)
        {
            var result = await _petRepository.InsertPet(pet);
            return Ok(result);
        }

        [HttpPut("/v1/pet")]
        public async Task<IActionResult> UpdatePet([FromBody] Pet pet)
        {
            await _petRepository.UpdatePet(pet);
            var result = await _petRepository.GetPet(pet.ID);
            return Ok(result);
        }

        [HttpPost("/v1/pet/{petId}/uploadImage")]
        public async Task<IActionResult> InsertPetPhoto([FromBody] PetPhoto photo)
        {
            var result = await _petRepository.InsertPetPhoto(photo);
            return Ok(result);
        }

        [HttpDelete("/v1/pet/{petId}")]
        public async Task<IActionResult> DeletePet(int petId)
        {
            var result = await _petRepository.DeletePet(petId);
            return Ok(result);
        }

        [HttpGet("/v1/pet/{petId}")]
        public async Task<IActionResult> GetPet(int petId)
        {
            var result = await _petRepository.GetPet(petId);
            return Ok(result);
        }

        [HttpGet("/v1/pet/findByStatus")]
        public async Task<IActionResult> GetPetsByStatus([FromQuery] PetStatus status)
        {
            var result = await _petRepository.GetPetByStatus(status);
            return Ok(result);
        }
    }
}