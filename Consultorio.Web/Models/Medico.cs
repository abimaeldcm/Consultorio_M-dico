namespace Consultorio.Web.Models
{
    public class Medico : Usuario
    {
        public string RegistroCRM { get; set; }

        public int IdEspecialidade { get; set; }        
        public Especialidade Especialidade { get; set; }
    }
}
