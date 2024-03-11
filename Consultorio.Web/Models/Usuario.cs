using Consultorio.Web.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace Consultorio.Web.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string NomeCompleto => $"{Nome} {Sobrenome}";

        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        public string Telefone { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }

        public string CPF { get; set; }

        [Display(Name = "Tipo Sanguíneo")]
        public ETipoSanguineo TipoSanguineo { get; set; }

        [Display(Name = "Endereço")]
        public string Endereco { get; set; }


    }
}
