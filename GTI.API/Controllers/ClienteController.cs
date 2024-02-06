using GTI.Application.Interfaces;
using GTI.Domain.Commands;
using GTI.Domain.Commands.Clientes;
using GTI.Shared.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace GTI.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly IHandler<CreateClienteCommand> _createClienteHandler;
        private readonly IHandler<UpdateClienteCommand> _updateClienteHandler;

        public ClienteController(IClienteService clienteService, IHandler<CreateClienteCommand> createClienteHandler, IHandler<UpdateClienteCommand> updateClienteHandler)
        {
            _clienteService = clienteService;
            _createClienteHandler = createClienteHandler;
            _updateClienteHandler = updateClienteHandler;
        }

        [HttpGet]
        [ProducesResponseType(typeof(CommandResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _clienteService.GetAllClientes();
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CommandResult), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var result = await _clienteService.GetByIdCliente(id);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CommandResult), StatusCodes.Status201Created)]
        public async Task<IActionResult> PostAsync(CreateClienteCommand command)
        {
            var result = await _createClienteHandler.Handle(command);
            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(CommandResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CommandResult), StatusCodes.Status204NoContent)]
        public async Task<IActionResult> PutAsync(Guid id, UpdateClienteCommand command)
        {
            command.InserirIdClienteExistenteNoCommand(id);
            var result = await _updateClienteHandler.Handle(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(CommandResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CommandResult), StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await _clienteService.DeleteCliente(id);
            return Ok(result);
        }
    }
}
