using GTI.Shared.Entities;

namespace GTI.Domain.Entities
{
    public class Cliente : Entity
    {
        public Cliente(string cpf, string nome, string rg, DateTime dataExpedicao, string orgaoExpedicao, string uf, DateTime dataDeNascimento, string sexo, string estadoCivil)
        {
            Cpf = cpf;
            Nome = nome;
            Rg = rg;
            DataExpedicao = dataExpedicao;
            OrgaoExpedicao = orgaoExpedicao;
            Uf = uf;
            DataDeNascimento = dataDeNascimento;
            Sexo = sexo;
            EstadoCivil = estadoCivil;
            Enderecos = new List<Endereco>();
        }

        protected Cliente() { }

        public string Cpf { get; private set; }
        public string Nome { get; private set; }
        public string Rg { get; private set; }
        public DateTime DataExpedicao { get; private set; }
        public string OrgaoExpedicao { get; private set; }
        public string Uf { get; private set; }
        public DateTime DataDeNascimento { get; private set; }
        public string Sexo { get; private set; }
        public string EstadoCivil { get; private set; }
        public IList<Endereco> Enderecos {  get; private set; } 
    }
}
