using Microsoft.CodeAnalysis;

namespace Consultorio.Web.Models
{
    public class Doctor : User
    {
        public string RegistroCRM { get; set; }

        public int IdSpecialty { get; set; }
        public Specialty Specialty { get; set; }
    }
}
