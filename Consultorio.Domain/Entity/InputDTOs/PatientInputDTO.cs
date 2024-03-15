namespace Consultorio.Domain.Entity.InputDTOs
{
    public class PatientInputDTO : User
    {
        public double? Height { get; set; }
        public double? Weight { get; set; }
    }
}
