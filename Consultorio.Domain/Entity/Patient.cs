namespace Consultorio.Domain.Entity
{
    public class Patient : User
    {
        public double? Height { get; set; }
        public double? Weight { get; set; }
    }
}
