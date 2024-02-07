using GTI.Application.Interfaces;
using GTI.Domain.Commands;
using GTI.Domain.Entities;
using GTI.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GTI.Application.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IReadRepository<Endereco> _readRepository;

        public EnderecoService(IReadRepository<Endereco> readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<CommandResult> GetAllEnderecos()
        {
            var listaEnderecos = await _readRepository.FindAll().ToListAsync();

            if (listaEnderecos is null || listaEnderecos.Count == 0)
                return new CommandResult(false, "Falha ao consultar enderecos");

            return new CommandResult(true, "Enderecos consultados com sucesso", listaEnderecos);
        }
    }
}
