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
        private readonly IReadRepository<Endereco> _readEnderecoRepository;
        private readonly IWriteRepository<Endereco> _writeEnderecoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ClienteService(IReadRepository<Cliente> readRepository, IWriteRepository<Cliente> writeRepository, IUnitOfWork unitOfWork, IWriteRepository<Endereco> writeEnderecoRepository, IReadRepository<Endereco> readEnderecoRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _unitOfWork = unitOfWork;
            _writeEnderecoRepository = writeEnderecoRepository;
            _readEnderecoRepository = readEnderecoRepository;
        }

        public async Task<CommandResult> GetAllClientes()
        {
            var listaClientes = await _readRepository.FindAll().Include(x => x.Enderecos).ToListAsync();

            if (listaClientes is null || listaClientes.Count == 0)
                return new CommandResult(false, "Falha ao consultar clientes");

            return new CommandResult(true, "Clientes consultados com sucesso", listaClientes);
        }

        public async Task<CommandResult> GetByIdCliente(Guid id)
        {
            var cliente = await _readRepository.FindByCondition(x => x.Id == id).Include(x => x.Enderecos).ToListAsync();

            if (cliente is null || cliente.Count == 0)
                return new CommandResult(false, "Falha ao consultar cliente");

            return new CommandResult(true, "Cliente consultado com sucesso", cliente);
        }

        public async Task<CommandResult> CreateCliente(CreateClienteCommand command)
        {
            command.Validate();

            if (!command.IsValid)
                return new CommandResult(false, "Falha ao registrar cliente", command.Notifications);

            Cliente cliente = new Cliente(command.Cpf, command.Nome, command.Rg, command.DataExpedicao, command.OrgaoExpedicao,
                command.Uf, command.DataDeNascimento, command.Sexo, command.EstadoCivil);

            Endereco endereco = new Endereco(command.Endereco.Cep, command.Endereco.Logradouro, command.Endereco.Numero,
                command.Endereco.Complemento, command.Endereco.Bairro, command.Endereco.Cidade, command.Endereco.Uf, cliente);

            await _writeRepository.AddAsync(cliente);
            await _writeEnderecoRepository.AddAsync(endereco);
            await _unitOfWork.CommitAsync();

            return new CommandResult(true, "Cliente registrado com sucesso", cliente);
        }

        public async Task<CommandResult> UpdateCliente(UpdateClienteCommand command)
        {
            command.Validate();

            if (!command.IsValid)
                return new CommandResult(false, "Falha ao alterar cliente", command.Notifications);

            var cliente = await _readRepository.FindByCondition(x => x.Id == command.IdClienteExistente).FirstOrDefaultAsync();
            if (cliente is null)
                return new CommandResult(false, "Falha ao recuperar cliente");

            var endereco = await _readEnderecoRepository.FindByCondition(x => x.Cliente.Id == command.IdClienteExistente).FirstOrDefaultAsync();
            if (endereco is null)
                return new CommandResult(false, "Falha ao recuperar endereco");

            cliente.Alterar(command);
            endereco.Alterar(command.Endereco);

            _writeRepository.Update(cliente);
            _writeEnderecoRepository.Update(endereco);
            await _unitOfWork.CommitAsync();

            return new CommandResult(true, "Cliente alterado com sucesso", cliente);
        }

        public async Task<CommandResult> DeleteCliente(Guid id)
        {
            var cliente = await _readRepository.FindByCondition(x => x.Id == id).FirstOrDefaultAsync();
            if (cliente is null)
                return new CommandResult(false, "Falha ao recuperar cliente");

            var endereco = await _readEnderecoRepository.FindByCondition(x => x.Cliente.Id == id).FirstOrDefaultAsync();
            if (endereco is null)
                return new CommandResult(false, "Falha ao recuperar endereco");

            _writeRepository.Delete(cliente);
            _writeEnderecoRepository.Delete(endereco);
            await _unitOfWork.CommitAsync();

            return new CommandResult(true, "Cliente deletado com sucesso", cliente);
        }
    }
}
