namespace Consultorio.Domain.Entity
{
    public class Atendimento
    {
        public int Id { get; set; }
        public int IdPaciente { get; set; }
        public int IdServico { get; set; }
        public int IdMedico { get; set; }
        public byte Convenio { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }

        public Paciente Paciente { get; set; }
        public Servico Servico { get; set; }
        public Medico Medico { get; set; }
    }
}
