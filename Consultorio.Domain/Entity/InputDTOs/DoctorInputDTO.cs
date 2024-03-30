namespace Consultorio.Domain.Entity.InputDTOs
{
    public class DoctorInputDTO : Person
    {
        public string RegisterCRM { get; set; }
        public int IdSpeciality { get; set; }
    }
}
