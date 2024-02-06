using GTI.Domain.Commands;

namespace GTI.Application.Interfaces
{
    public interface IEnderecoService
    {
        Task<CommandResult> GetAllEnderecos();
    }
}
