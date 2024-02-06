using GTI.Domain.Commands;
using GTI.Domain.Commands.Clientes;

namespace GTI.Application.Interfaces
{
    public interface IClienteService
    {
        Task<CommandResult> GetAllClientes();
        Task<CommandResult> GetByIdCliente(Guid id);
        Task<CommandResult> CreateCliente(CreateClienteCommand command);
        Task<CommandResult> UpdateCliente(UpdateClienteCommand command);
        Task<CommandResult> DeleteCliente(Guid id);
    }
}
