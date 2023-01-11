using ClinicService.Models;
using ClinicService.Models.Requests;
using ClinicService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private IPetRepository _petRepository;
        public PetController(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        [HttpPost("create")]
        public ActionResult<int> Create([FromBody] CreatePetRequest createPetRequest)
        {
            int res = _petRepository.Create(new Pet
            {
                ClientId = createPetRequest.ClientId,
                Name = createPetRequest.Name,
                Birthday = createPetRequest.Birthday,
            });
            return Ok(res);
        }

        [HttpPut("update")]
        public ActionResult<int> Update([FromBody] UpdatePetRequest updatePetRequest)
        {
            int res = _petRepository.Update(new Pet
            {
                PetId = updatePetRequest.PetId,
                ClientId = updatePetRequest.ClientId,
                Name = updatePetRequest.Name,
                Birthday = updatePetRequest.Birthday,
            });
            return Ok(res);
        }

        [HttpDelete("delete")]
        public ActionResult<int> Delete(int petId)
        {
            int res = _petRepository.Delete(petId);
            return Ok(res);
        }

        [HttpGet("get-all")]
        public ActionResult<List<Pet>> GetAll()
        {
            return Ok(_petRepository.GetAll());
        }

        [HttpGet("get-by-id")]
        public ActionResult<Pet> GetById(int petId)
        {
            return Ok(_petRepository.GetById(petId));
        }
    }
}