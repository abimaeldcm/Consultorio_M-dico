namespace Consultorio.Domain.Entity.OutPutDTOs
{
    public class PacienteOutputDTO : Usuario
    {
        public decimal? Altura { get; set; }
        public decimal? Peso { get; set; }
    }
}
