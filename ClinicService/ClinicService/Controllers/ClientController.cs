using ClinicService.Models;
using ClinicService.Models.Requests;
using ClinicService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicService.Controllers
{
    /// <summary>
    /// ДОМАШНЯЯ РАБОТА Добавить контроллеры PetController и ConsultationController по образу и подобию текущего контроллера.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private IClientRepository _clientRepository;
        
        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [HttpPost("create")]
        public ActionResult<int> Create([FromBody] CreateClientRequest createClientRequest)
        {
            int res = _clientRepository.Create(new Client
            {
                Document = createClientRequest.Document,
                SurName = createClientRequest.SurName,
                FirstName = createClientRequest.FirstName,
                Patronymic = createClientRequest.Patronymic,
                Birthday = createClientRequest.Birthday,
            });
            return Ok(res);
        }

        [HttpPut("update")]
        public ActionResult<int> Update([FromBody] UpdateClientRequest updateClientRequest)
        {
            int res = _clientRepository.Update(new Client
            {
                ClientId = updateClientRequest.ClientId,
                Document = updateClientRequest.Document,
                SurName = updateClientRequest.SurName,
                FirstName = updateClientRequest.FirstName,
                Patronymic = updateClientRequest.Patronymic,
                Birthday = updateClientRequest.Birthday,
            });
            return Ok(res);
        }


        [HttpDelete("delete")]
        public ActionResult<int> Delete(int clientId)
        {
            int res = _clientRepository.Delete(clientId);
            return Ok(res);
        }

        [HttpGet("get-all")]
        public ActionResult<List<Client>> GetAll()
        {
            return Ok(_clientRepository.GetAll());
        }

        [HttpGet("get-by-id")]
        public ActionResult<Client> GetById(int clientId)
        {
            return Ok(_clientRepository.GetById(clientId));
        }


    }
}
