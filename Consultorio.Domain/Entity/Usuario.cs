using Consultorio.Domain.Entity.Enum;

namespace Consultorio.Domain.Entity
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public ETipoSanguineo TipoSanguineo { get; set; }
        public string Endereco { get; set; }
    }
}
