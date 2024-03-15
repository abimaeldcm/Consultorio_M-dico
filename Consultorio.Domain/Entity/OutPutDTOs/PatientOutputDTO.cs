namespace Consultorio.Domain.Entity.OutPutDTOs
{
    public class PatientOutputDTO : User
    {
        public double? Height { get; set; }
        public double? Weight { get; set; }
    }
}
