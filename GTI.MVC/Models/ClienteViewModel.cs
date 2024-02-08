namespace GTI.MVC.Models
{
    public class ClienteViewModel
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
        public EnderecoViewModel Endereco { get; set; }
    }
}
