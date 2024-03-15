using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Domain.Entity.InputDTOs
{
    public class ConsultInputDTO
    {
        public int Id { get; set; }
        public int IdPatient { get; set; }
        public int IdService { get; set; }
        public int IdDoctor { get; set; }
        public byte Convenio { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string? IdentifiedGoogleCalendar { get; set; }
    }
}
