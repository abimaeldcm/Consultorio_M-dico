using Microsoft.CodeAnalysis;
using System.ComponentModel.DataAnnotations;

namespace Consultorio.Web.Models
{
    public class Doctor : Person
    {
        [Display(Name = "CRM")]
        public string RegisterCRM { get; set; }

        public int IdSpeciality { get; set; }

        [Display(Name = "Especialidade")]
        public Speciality Speciality { get; set; }
    }
}
