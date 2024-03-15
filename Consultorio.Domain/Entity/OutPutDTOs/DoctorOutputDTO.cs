namespace Consultorio.Domain.Entity.OutPutDTOs
{
    public class DoctorOutputDTO : User
    {
        public string RegisterCRM { get; set; }

        public int IdSpecialty { get; set; }
        public Specialty Specialty { get; set; }
    }
}
