namespace Consultorio.Domain.Entity.InputDTOs
{
    public class DoctorInputDTO : User
    {
        public string RegisterCRM { get; set; }
        public int IdSpecialty { get; set; }
    }
}
