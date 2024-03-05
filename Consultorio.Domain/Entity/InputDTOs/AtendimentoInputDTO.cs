using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Domain.Entity.InputDTOs
{
    public class AtendimentoInputDTO
    {
        public int IdPaciente { get; set; }
        public int IdServico { get; set; }
        public int IdMedico { get; set; }
        public byte Convenio { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
    }
}
