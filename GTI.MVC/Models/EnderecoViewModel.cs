using System.ComponentModel.DataAnnotations;

namespace GTI.MVC.Models
{
    public class EnderecoViewModel
    {
        [Required(ErrorMessage = "O CEP não pode ser nulo ou vazio.")]
        [MinLength(8, ErrorMessage = "O CEP deve ter 8 caracteres.")]
        [MaxLength(8, ErrorMessage = "O CEP deve ter 8 caracteres.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "O CEP deve conter apenas números.")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "O Rua não pode ser nulo ou vazio.")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O Número não pode ser nulo ou vazio.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "deve conter apenas números.")]
        public string Numero { get; set; }
        public string? Complemento { get; set; }

        [Required(ErrorMessage = "O Bairro não pode ser nulo ou vazio.")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O Cidade não pode ser nulo ou vazio.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O UF não pode ser nulo ou vazio.")]
        public string Uf { get; set; }
    }
}
