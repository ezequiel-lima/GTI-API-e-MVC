using Flunt.Validations;
using GTI.Domain.Commands.Clientes;

namespace GTI.Domain.Contracts.Clientes
{
    public class CreateClienteContract : Contract<CreateClienteCommand>
    {
        public CreateClienteContract(CreateClienteCommand command)
        {
            Requires()
                .IsNotNullOrEmpty(command.Cpf, "Cpf", "O CPF não pode ser nulo ou vazio.")
                .IsNotNullOrEmpty(command.Nome, "Nome", "O nome não pode ser nulo ou vazio.")
                .IsNotNullOrEmpty(command.Sexo, "Sexo", "O campo sexo é obrigatório.")
                .IsNotNullOrEmpty(command.EstadoCivil, "EstadoCivil", "O estado civil é obrigatório.")
                .AreEquals(11, command.Cpf.Length, "Cpf", "O CPF deve ter 11 caracteres.")
                .IsLowerOrEqualsThan(command.DataDeNascimento, DateTime.Now, "DataDeNascimento", "A data de nascimento não pode ser uma data futura.")
                .Matches(command.Cpf, @"^\d{11}$", "Cpf", "Cpf inválido.");
        }
    }
}
