using Consultorio.Web.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace Consultorio.Web.Models
{
    public class User
    {
        public int Id { get; set; }
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Display(Name = "Sobrenome")]
        public string LastName { get; set; }

        [Display(Name = "Nome Completo")]
        public string FullName { get { return Name + " " + LastName; } }

        [Display(Name = "Data de Nascimento")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Telefone")]
        public string PhoneNumber { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }

        public string CPF { get; set; }

        [Display(Name = "Tipo Sanguíneo")]
        public ETBloodType BloodType { get; set; }

        [Display(Name = "Endereço")]
        public string Address { get; set; }


    }
}
