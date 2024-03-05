namespace Consultorio.Domain.Entity.OutPutDTOs
{
    public class MedicoOutputDTO : Usuario
    {
        public int IdEspecialidade { get; set; }
        public string RegistroCRM { get; set; }

        public Especialidade Especialidade { get; set; }
    }
}
