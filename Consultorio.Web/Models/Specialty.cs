using System.ComponentModel.DataAnnotations;

namespace Consultorio.Web.Models

{
    public class Specialty
    {
        public int Id { get; set; }

        [Display(Name = "Especialidade Médica")]
        public string MedicalSpecialty { get; set; }
    }
}
