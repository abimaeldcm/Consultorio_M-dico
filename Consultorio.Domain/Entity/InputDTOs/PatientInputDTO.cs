namespace Consultorio.Domain.Entity.InputDTOs
{
    public class PatientInputDTO : Person
    {
        public double? Height { get; set; }
        public double? Weight { get; set; }
    }
}
