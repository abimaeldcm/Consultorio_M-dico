using System.ComponentModel.DataAnnotations;

namespace Consultorio.Web.Models
{
    public class Consult
    {
        public int Id { get; set; }

        [Display(Name = "Paciente")]
        public int IdPatient { get; set; }

        [Display(Name = "Servico")]
        public int IdService { get; set; }

        [Display(Name = "Médico")]
        public int IdDoctor { get; set; }

        [Display(Name = "Convênio")]
        public byte Convenio { get; set; }

        [Display(Name = "Início")]
        public DateTime Start { get; set; }

        [Display(Name = "Fim")]
        public DateTime End { get; set; }
        

        public Patient Patient { get; set; }
        public ServiceEntity Service { get; set; }
        public Doctor Doctor { get; set; }
    }
}
