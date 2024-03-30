namespace Consultorio.Domain.Entity
{
    public class Patient : Person
    {
        public double? Height { get; set; }
        public double? Weight { get; set; }
    }
}
