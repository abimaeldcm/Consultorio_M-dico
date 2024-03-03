namespace Consultorio.Domain.Entity
{
    public class Medico : Usuario
    {
        public int IdEspecialidade { get; set; }        
        public string RegistroCRM { get; set; }
        
        public Especialidade Especialidade { get; set; }
    }
}
