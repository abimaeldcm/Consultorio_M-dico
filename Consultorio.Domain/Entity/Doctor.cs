namespace Consultorio.Domain.Entity
{
    public class Doctor : Person
    {
        public string RegisterCRM { get; set; }

        public int IdSpeciality { get; set; }        
        public Speciality Speciality { get; set; }
    }
}
