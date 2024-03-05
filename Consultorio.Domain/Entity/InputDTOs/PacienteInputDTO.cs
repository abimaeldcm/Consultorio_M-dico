namespace Consultorio.Domain.Entity.InputDTOs
{
    public class PacienteInputDTO : Usuario
    {
        public double? Altura { get; set; }
        public double? Peso { get; set; }
    }
}
