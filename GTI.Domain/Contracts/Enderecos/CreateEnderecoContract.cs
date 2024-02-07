using Flunt.Validations;
using GTI.Domain.Commands.Enderecos;

namespace GTI.Domain.Contracts.Enderecos
{
    public class CreateEnderecoContract : Contract<CreateEnderecoCommand>
    {
        public CreateEnderecoContract(CreateEnderecoCommand command)
        {
            Requires()
                .IsNotNullOrEmpty(command.Cep, "Cep", "O Cep é obrigatório.")
                .IsNotNullOrEmpty(command.Logradouro, "Logradouro", "O logradouro é obrigatório.")
                .IsNotNullOrEmpty(command.Numero, "Numero", "O campo número é obrigatório.")
                .IsNotNullOrEmpty(command.Bairro, "Bairro", "O bairro é obrigatório.")
                .IsNotNullOrEmpty(command.Cidade, "Cidade", "A cidade é obrigatório.")
                .IsNotNullOrEmpty(command.Uf, "Uf", "O campo Uf é obrigatório.")
                .AreEquals(8, command.Cep.Length, "Cep", "O Cep deve ter 8 caracteres.")
                .Matches(command.Cep, @"^\d{8}$", "Cep", "Cep inválido.");           
        }
    }
}
