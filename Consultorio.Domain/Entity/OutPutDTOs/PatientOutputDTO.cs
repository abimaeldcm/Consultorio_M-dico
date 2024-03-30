namespace Consultorio.Domain.Entity.OutPutDTOs
{
    public class PatientOutputDTO : Person
    {
        public double? Height { get; set; }
        public double? Weight { get; set; }
    }
}
