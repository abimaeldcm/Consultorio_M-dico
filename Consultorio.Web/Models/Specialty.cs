using System.ComponentModel.DataAnnotations;

namespace Consultorio.Web.Models

{
    public class Speciality
    {
        public int Id { get; set; }

        [Display(Name = "Especialidade Médica")]
        public string MedicalSpeciality { get; set; }
    }
}
