using Microsoft.AspNetCore.Mvc;
using ProTask.Application.DTOs;
using ProTask.Application.Interfaces;

namespace ProTask.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly ILogger<ClientsController> _logger;

        public readonly IClientService _clientService;

        public ClientsController(ILogger<ClientsController> logger, IClientService clientService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _clientService = clientService ?? throw new ArgumentNullException(nameof(clientService));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var clients = await _clientService.Get();
                if (clients == null) return NoContent();
                return Ok(clients);
            } catch (Exception e)
            {
                _logger.LogError(e.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post(NewClientDTO dto)
        {
            try
            {
                var newDTO = await _clientService.Create(dto);
                return Ok(newDTO);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, dto);
                return this.StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ClientDTO dto)
        {
            try
            {
                if (dto == null) return Conflict("Please send a client to modify");
                if (id != dto.Id) return Conflict("The client you trying to update is diferent");
                var updatedClient = await _clientService.Update(dto);
                if(updatedClient == null) return Conflict("The client you trying to update does't exists");
                return Ok(updatedClient);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, dto);
                return this.StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok();
        }
    }
}