using GTI.Application.Interfaces;
using GTI.Domain.Commands;
using Microsoft.AspNetCore.Mvc;

namespace GTI.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoService _enderecoService;

        public EnderecoController(IEnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(CommandResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _enderecoService.GetAllEnderecos();

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
