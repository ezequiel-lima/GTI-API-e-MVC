using GTI.Application.Interfaces;
using GTI.Domain.Commands.Clientes;
using GTI.Shared.Commands.Interfaces;
using GTI.Shared.Handlers;

namespace GTI.Application.Handlers
{
    public class ClienteHandler : IHandler<CreateClienteCommand>
    {
        private readonly IClienteService _clienteService;

        public ClienteHandler(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public async Task<ICommandResult> Handle(CreateClienteCommand command)
        {
            return await _clienteService.CreateCliente(command);
        }
    }
}
