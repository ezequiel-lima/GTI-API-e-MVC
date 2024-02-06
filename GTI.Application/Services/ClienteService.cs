using GTI.Application.Interfaces;
using GTI.Domain.Commands;
using GTI.Domain.Commands.Clientes;
using GTI.Domain.Entities;
using GTI.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GTI.Application.Services
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
     
        public async Task<CommandResult> GetAllClientes()
        {
            var listaClientes = await _readRepository.FindAll().ToListAsync();
            return new CommandResult(true, "Clientes consultados com sucesso", listaClientes);
        }

        public async Task<CommandResult> GetByIdCliente(Guid id)
        {
            var cliente = await _readRepository.FindByCondition(x => x.Id == id).ToListAsync();
            return new CommandResult(true, "Cliente consultado com sucesso", cliente);
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

        public async Task<CommandResult> UpdateCliente(UpdateClienteCommand command)
        {
            // TODO FAST FAIL VALIDATION

            Cliente cliente = await _readRepository.FindByCondition(x => x.Id == command.IdClienteExistente).FirstOrDefaultAsync();
            cliente.Alterar(command);

            _writeRepository.Update(cliente);
            await _unitOfWork.CommitAsync();

            return new CommandResult(true, "Cliente alterado com sucesso", cliente);
        }

        public async Task<CommandResult> DeleteCliente(Guid id)
        {
            // TODO FAST FAIL VALIDATION

            Cliente cliente = await _readRepository.FindByCondition(x => x.Id == id).FirstOrDefaultAsync();

            _writeRepository.Delete(cliente);
            await _unitOfWork.CommitAsync();

            return new CommandResult(true, "Cliente deletado com sucesso", cliente);
        }
    }
}
