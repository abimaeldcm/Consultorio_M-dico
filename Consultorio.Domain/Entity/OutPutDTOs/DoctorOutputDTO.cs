namespace Consultorio.Domain.Entity.OutPutDTOs
{
    public class DoctorOutputDTO : Person
    {
        public string RegisterCRM { get; set; }

        public int IdSpeciality { get; set; }
        public Speciality Speciality { get; set; }
    }
}
