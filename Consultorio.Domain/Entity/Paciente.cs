namespace Consultorio.Domain.Entity
{
    public class Paciente : Usuario
    {
        public decimal? Altura { get; set; }
        public decimal? Peso { get; set; }
    }
}
