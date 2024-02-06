using GTI.Domain.Commands.Enderecos;
using GTI.Domain.Contracts.Clientes;
using GTI.Shared.Commands;

namespace GTI.Domain.Commands.Clientes
{
    public class CreateClienteCommand : BaseCommand
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Rg { get; set; }
        public DateTime DataExpedicao { get; set; }
        public string OrgaoExpedicao { get; set; }
        public string Uf { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string Sexo { get; set; }
        public string EstadoCivil { get; set; }
        public CreateEnderecoCommand Endereco { get; set; }

        public override void Validate()
        {
            AddNotifications(new CreateClienteContract(this));
        }
    }
}
