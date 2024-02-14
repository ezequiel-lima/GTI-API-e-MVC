using System.ComponentModel.DataAnnotations;

namespace GTI.MVC.Models
{
    public class ClienteViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O CPF não pode ser nulo ou vazio.")]
        [MinLength(11, ErrorMessage = "O CPF deve ter 11 caracteres.")]
        [MaxLength(11, ErrorMessage = "O CPF deve ter 11 caracteres.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "O CPF deve conter apenas números.")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O nome não pode ser nulo ou vazio.")]
        public string Nome { get; set; }

        [MinLength(9, ErrorMessage = "O RG deve ter 9 caracteres.")]
        [MaxLength(9, ErrorMessage = "O RG deve ter 9 caracteres.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "O RG deve conter apenas números.")]
        public string? Rg { get; set; }
        public DateTime? DataExpedicao { get; set; }
        public string? OrgaoExpedicao { get; set; }
        public string? Uf { get; set; }
        public DateTime DataDeNascimento { get; set; }

        [Required(ErrorMessage = "O campo sexo é obrigatório.")]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "O estado civil é obrigatório.")]
        public string EstadoCivil { get; set; }
        public List<EnderecoViewModel> Enderecos { get; set; }
    }
}
