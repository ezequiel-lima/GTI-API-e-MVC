using GTI.Domain.Commands.Clientes;
using GTI.Domain.Commands.Enderecos;
using GTI.Shared.Entities;
using System.Text.Json.Serialization;

namespace GTI.Domain.Entities
{
    public class Endereco : Entity
    {
        public Endereco(string cep, string logradouro, string numero, string complemento, string bairro, string cidade, string uf, Cliente cliente)
        {
            Cep = cep;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Uf = uf;
            Cliente = cliente;
        }

        protected Endereco() { }

        public string Cep { get; private set; }
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Uf { get; private set; }

        [JsonIgnore]
        public Cliente Cliente { get; private set; }

        public void Alterar(UpdateEnderecoCommand command)
        {
            Cep = command.Cep;
            Logradouro = command.Logradouro;
            Numero = command.Numero;
            Complemento = command.Complemento;
            Bairro = command.Bairro;
            Cidade = command.Cidade;
            Uf = command.Uf;
        }
    }
}
