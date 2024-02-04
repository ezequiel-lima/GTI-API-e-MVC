using GTI.Domain.Commands.Clientes;
using GTI.Shared.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace GTI.API.Controllers
{
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IHandler<CreateClienteCommand> _clienteHandler;

        public ClienteController(IHandler<CreateClienteCommand> clienteHandler)
        {
            _clienteHandler = clienteHandler;
        }

        [HttpPost("clientes")]
        public async Task<IActionResult> PostAsync(CreateClienteCommand command)
        {
            var result = await _clienteHandler.Handle(command);
            return Ok(result);
        }
    }
}
