namespace Consultorio.Domain.Entity
{
    public class Doctor : User
    {
        public string RegisterCRM { get; set; }

        public int IdSpecialty { get; set; }        
        public Specialty Specialty { get; set; }
    }
}
