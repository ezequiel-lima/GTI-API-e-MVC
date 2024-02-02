using GTI.Shared.Entities;

namespace GTI.Domain.Entities
{
    public class Cliente : Entity
    {
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
