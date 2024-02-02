using GTI.Shared.Entities;

namespace GTI.Domain.Entities
{
    public class Endereco : Entity
    {
        protected Endereco() { }

        public string Cep { get; private set; }
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Uf { get; private set; }
        public Cliente Cliente { get; private set; }
    }
}
