using GTI.Domain.Contracts.Enderecos;
using GTI.Shared.Commands;

namespace GTI.Domain.Commands.Enderecos
{
    public class CreateEnderecoCommand : BaseCommand
    {
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }

        public override void Validate()
        {
            AddNotifications(new CreateEnderecoContract(this));
        }
    }
}
