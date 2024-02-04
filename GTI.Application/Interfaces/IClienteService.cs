using GTI.Domain.Commands;
using GTI.Domain.Commands.Clientes;

namespace GTI.Application.Interfaces
{
    public interface IClienteService
    {
        Task<CommandResult> CreateCliente(CreateClienteCommand command);
    }
}
