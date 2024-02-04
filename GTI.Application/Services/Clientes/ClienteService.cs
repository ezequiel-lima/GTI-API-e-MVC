using GTI.Application.Interfaces;
using GTI.Domain.Commands;
using GTI.Domain.Commands.Clientes;
using GTI.Domain.Entities;
using GTI.Infra.Data.Interfaces;

namespace GTI.Application.Services.Clientes
{
    public class ClienteService : IClienteService
    {
        private readonly IReadRepository<Cliente> _readRepository;
        private readonly IWriteRepository<Cliente> _writeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ClienteService(IReadRepository<Cliente> readRepository, IWriteRepository<Cliente> writeRepository, IUnitOfWork unitOfWork)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CommandResult> CreateCliente(CreateClienteCommand command)
        {
            // TODO FAST FAIL VALIDATION

            Cliente cliente = new Cliente(command.Cpf, command.Nome, command.Rg, command.DataExpedicao, command.OrgaoExpedicao, 
                command.Uf, command.DataDeNascimento, command.Sexo, command.EstadoCivil);

            await _writeRepository.AddAsync(cliente);
            await _unitOfWork.CommitAsync();

            return new CommandResult(true, "Cliente registrado com sucesso", cliente);
        }
    }
}
