namespace Consultorio.Domain.Entity.OutPutDTOs
{
    public class AtendimentoOutputDTO
    {
        public int Id { get; set; }
        public int IdPaciente { get; set; }
        public int IdServico { get; set; }
        public int IdMedico { get; set; }
        public byte Convenio { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
    }
}
