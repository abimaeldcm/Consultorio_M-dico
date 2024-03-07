namespace Consultorio.Domain.Entity.InputDTOs
{
    public class PacienteInputDTO : Usuario
    {
        public decimal? Altura { get; set; }
        public decimal? Peso { get; set; }
    }
}
