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
        private readonly IWriteRepository<Endereco> _writeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EnderecoService(IReadRepository<Endereco> readRepository, IWriteRepository<Endereco> writeRepository, IUnitOfWork unitOfWork)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CommandResult> GetAllEnderecos()
        {
            var enderecos = await _readRepository.FindAll().ToListAsync();
            return new CommandResult(true, "Enderecos consultados com sucesso", enderecos);
        }
    }
}
