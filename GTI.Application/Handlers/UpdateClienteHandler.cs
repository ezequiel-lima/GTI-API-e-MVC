using GTI.Application.Interfaces;
using GTI.Domain.Commands.Clientes;
using GTI.Shared.Commands.Interfaces;
using GTI.Shared.Handlers;

namespace GTI.Application.Handlers
{
    public class UpdateClienteHandler : IHandler<UpdateClienteCommand>
    {
        private readonly IClienteService _clienteService;

        public UpdateClienteHandler(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public async Task<ICommandResult> Handle(UpdateClienteCommand command)
        {
            return await _clienteService.UpdateCliente(command);
        }
    }
}
