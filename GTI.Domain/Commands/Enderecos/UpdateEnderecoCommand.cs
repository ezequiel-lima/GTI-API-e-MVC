using GTI.Shared.Commands.Interfaces;

namespace GTI.Domain.Commands.Enderecos
{
    public class UpdateEnderecoCommand : ICommand
    {
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
